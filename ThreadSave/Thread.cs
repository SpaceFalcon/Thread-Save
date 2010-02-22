﻿/* File Created: 10/4/2009
 * Last Modified: 10/6/2009
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
using System.Net;

namespace ThreadSave
{
    class Thread
    {
        public event EventHandler ScanComplete;

        string Source;
        string m_StorageDir = Configuration.StorageDirectory;
        public string ThreadNumber;
        public string ThreadURL;

        int m_imageCount = 0;
        List<string> m_DownloadedFiles = new List<string>();
        Queue<string> m_QueuedFiles = new Queue<string>();
        bool m_isdead = false;

        /// <summary>
        /// URL's of all downloaded files.
        /// </summary>
        public string[] DownloadedFiles
        {
            get
            {
                return m_DownloadedFiles.ToArray();
            }
        }

        /// <summary>
        /// URL's of all currently enqueued files.
        /// </summary>
        public string[] QueuedFiles
        {
            get
            {
                return m_QueuedFiles.ToArray();
            }
        }

        public string Next
        {
            get
            {
                if (m_QueuedFiles.Count > 0)
                {
                    string nextFile = m_QueuedFiles.Dequeue();
                    m_DownloadedFiles.Add(nextFile);
                    return nextFile;
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Number of images in the thread.
        /// </summary>
        public int ImageCount
        {
            get
            {
                return m_imageCount;
            }
        }

        public string StoragePath
        {
            get
            {
                return m_StorageDir + "\\" + ThreadNumber;
            }
        }

        public bool IsDead
        {
            get
            {
                return m_isdead;
            }
        }

        public Thread(string ThreadURL)
        {
            this.ThreadURL = ThreadURL;
            ThreadNumber = ThreadURL.Split("/".ToCharArray())[5].Split(".".ToCharArray())[0];
            System.IO.Directory.CreateDirectory(StoragePath);
            Scan();
        }

        /// <summary>
        /// Scan and parse the thread for new images.
        /// </summary>
        public void Scan()
        {
            NetStream SourceStream = new NetStream(ThreadURL);

            if (SourceStream.HTTPStatusCode == HttpStatusCode.NotFound) m_isdead = true; //404

            if (SourceStream.Exists)
                Source = SourceStream.Encoding.GetString(SourceStream.GetAllData());
            else
                return;

            System.Text.RegularExpressions.Regex ImageRegex = new System.Text.RegularExpressions.Regex("http://images\\.4chan\\.org/b/src/[0-9]+\\.[\\w]{3}");
            System.Text.RegularExpressions.Match ImageMatch = ImageRegex.Match(Source);

            while (ImageMatch.Success)
            {
                if (!m_DownloadedFiles.Contains(ImageMatch.Value) && !m_QueuedFiles.Contains(ImageMatch.Value))
                {
                    m_QueuedFiles.Enqueue(ImageMatch.Value);
                    m_imageCount++;
                }
                ImageMatch = ImageMatch.NextMatch();
            }
            SaveHTML();
            OnScanComplete(EventArgs.Empty);
        }

        private void SaveHTML()
        {
            System.IO.StreamWriter SourceWriter = new System.IO.StreamWriter(StoragePath + "\\" + ThreadNumber + ".html");
            SourceWriter.Write(Source);
            SourceWriter.Close();
        }

        public void ReQueue(string Job)
        {
            m_QueuedFiles.Enqueue(Job);
        }

        protected virtual void OnScanComplete(EventArgs e)
        {
            if (ScanComplete != null)
                ScanComplete(this, e);
        }
    }
}
