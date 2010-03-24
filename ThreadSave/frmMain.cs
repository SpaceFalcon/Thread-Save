/* File Created: 10/4/2009
 * Last Modified: 3/23/2010
 * 
 * This file is part of ThreadSave.
 * 
 * ThreadSave is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * ThreadSave is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with ThreadSave.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ThreadSave
{
    public partial class frmMain : Form
    {
        int timeCounter;

        public List<BackgroundWorker> ConcurrentOperations = new List<BackgroundWorker>();
        public int[] ConcurrentOperationsProgress = new int[Configuration.MaxThreads];
        public string[] ConcurrentOperationsString = new string[Configuration.MaxThreads];
        public string[] ConcurrentOperationsCurrentJob = new string[Configuration.MaxThreads];
        public List<string> JobLog = new List<string>();
        
        Thread currentThread;
        DateTime currentTime = DateTime.Now;
        int previewImageIndex = 0;

        public frmMain()
        {
            InitializeComponent();
            stStorageLocation.Cursor = Cursors.Hand;
            stPreviewNextImage.Cursor = Cursors.Hand;
            stPreviewPreviousImage.Cursor = Cursors.Hand;

            //Initialize Configuration.MaxThreads threads and point them to the worker methods.
            for (int i = 0; i < Configuration.MaxThreads; i++)
            {
                BackgroundWorker newThread = new BackgroundWorker();
                newThread.WorkerReportsProgress = true;
                newThread.DoWork += new DoWorkEventHandler(Thread_DoWork);
                newThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Thread_ExecutionComplete);
                ConcurrentOperations.Add(newThread);
            }
            Config.LoadFile("ThreadSave.cfg");
        }

        bool ThreadsBusy()
        {
            foreach (BackgroundWorker thread in ConcurrentOperations)
            {
                if (thread.IsBusy)
                    return true;
            }
            return false;
        }

        void ExecuteAllThreads()
        {
            foreach (BackgroundWorker thread in ConcurrentOperations)
            {
                if (!thread.IsBusy && currentThread.QueuedFiles.Length > 0)
                    thread.RunWorkerAsync();
            }
        }

        void Thread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker callingThread = (BackgroundWorker)sender;
            NetStream JobStream = null;
            string currentJob = currentThread.Next;
            if (currentJob != null)
            {
                JobStream = new NetStream(currentJob);
                byte[] data = new byte[JobStream.Length];
                int offset = 0;

                while (JobStream.HasData)
                {
                    offset += JobStream.Read(data, offset, Configuration.ChunkSize);
                    ConcurrentOperationsProgress[ConcurrentOperations.IndexOf(callingThread)] = (int)JobStream.PercentComplete;
                    ConcurrentOperationsString[ConcurrentOperations.IndexOf(callingThread)] = Util.FileSizeToString(JobStream.Position, 2) + " / " + Util.FileSizeToString(JobStream.Length, 2) + "      " + JobStream.PercentComplete + "%";
                    ConcurrentOperationsCurrentJob[ConcurrentOperations.IndexOf(callingThread)] = currentJob;
                }
                if (data.Length > 0)
                {
                    try
                    {
                        MemoryStream bitmapData = new MemoryStream(data);
                        Bitmap bmp = new Bitmap(bitmapData);
                        bmp.Save(currentThread.StoragePath + "\\" + Path.GetFileName(currentJob), MimeType.ToImageFormat(JobStream.MimeType));
                    }
                    catch { JobLog.Add("Error in job [" + currentJob + "] Bitmap Data"); }
                }
                JobLog.Add("Job completed without errors: [" + currentJob + "]");
            }
            if (JobStream != null && JobStream.LastError != null)
            {
                if (JobStream.HTTPStatusCode != System.Net.HttpStatusCode.NotFound)
                {
                    currentThread.ReQueue(currentJob);
                    JobLog.Add("Error occured in job: [" + currentJob + "] re-entering job queue.");
                    JobLog.Add(JobStream.LastError);
                }
                else
                    JobLog.Add("Image doesn't exist. Skipping.");
            }
        }

        void Thread_ExecutionComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateStatistics();
            BackgroundWorker callingThread = (BackgroundWorker)sender;
            if(currentThread.QueuedFiles.Length > 0)
                callingThread.RunWorkerAsync();
            foreach (string action in JobLog)
            {
                    ActionLog.Items.Add(action);
            }
            JobLog.Clear();
        }

        void tSecond_Tick(object sender, EventArgs e)
        {
            timeCounter++;
            if (timeCounter % 30 == 0)
            {
                if (!ThreadsBusy())
                {
                    currentThread.Scan();
                    if (currentThread.QueuedFiles.Length > 0)
                        ExecuteAllThreads();
                }
            }
            stNextThreadCheck.Text = (30 - (timeCounter % 30)).ToString();
        }

        private void UpdateStatistics()
        {
            stImagesDownloaded.Text = currentThread.DownloadedFiles.Length + " / " + currentThread.ImageCount;
            stStorageLocation.Text = Path.GetPathRoot(currentThread.StoragePath) + "..\\" + currentThread.ThreadNumber;
            stThreadExists.Text = (!currentThread.IsDead).ToString();
        }

        public void SetAppStatus(string status)
        {
            appStatus.Text = status;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtThreadUrl.Text.Length > 0)
            {
                currentThread = new Thread(txtThreadUrl.Text);
                tSecond.Start();
                ExecuteAllThreads();
            }
            else
            {
                tsappStatus.Text = "Please enter a thread URL";
            }
        }

        private void btnShowDownloaders_Click(object sender, EventArgs e)
        {
            new frmThreads(this).Show();
        }

        private void stStorageLocation_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(currentThread.StoragePath);
            }
            catch { }
        }

        private void stPreviewNextImage_Click(object sender, EventArgs e)
        {
            if (currentThread != null)
            {
                if (previewImageIndex >= currentThread.DownloadedFiles.Length) previewImageIndex = 0;
                string imageFile = currentThread.StoragePath + "\\" + Path.GetFileName(currentThread.DownloadedFiles[previewImageIndex]);
                if (File.Exists(imageFile))
                {
                    stPreviewImage.Image = (System.Drawing.Image)Bitmap.FromFile(imageFile);
                    stThreadImagePreviewLabel.Text = "Thread Image Preview (" + (previewImageIndex + 1) + ")";
                    previewImageIndex++;
                }
            }
        }

        private void stPreviewPreviousImage_Click(object sender, EventArgs e)
        {
            if (currentThread != null)
            {
                if (previewImageIndex == 0) previewImageIndex = currentThread.DownloadedFiles.Length - 1;
                string imageFile = currentThread.StoragePath + "\\" + Path.GetFileName(currentThread.DownloadedFiles[previewImageIndex]);
                if (File.Exists(imageFile))
                {
                    stPreviewImage.Image = (System.Drawing.Image)Bitmap.FromFile(imageFile);
                    stThreadImagePreviewLabel.Text = "Thread Image Preview (" + (previewImageIndex - 1) + ")";
                    previewImageIndex--;
                }
            }
        }
    }
}
