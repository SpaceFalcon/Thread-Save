/* File Created: 10/6/2009
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreadSave
{
    public partial class frmThreads : Form
    {
        frmMain MainFormReference;
        List<Label> IndexLabels = new List<Label>();
        List<Label> CurrentJobLabels = new List<Label>();
        List<Label> JobProgressLabels = new List<Label>();
        List<ProgressBar> ProgressBars = new List<ProgressBar>();

        int curPosX = 5;
        int curPosY = 5;

        int columnWidth = 0;
        int rowHeight = 30;
        int totalHeight = 30;

        int marginX = 7;
        int counter = 0;

        public frmThreads(frmMain MainFormReference)
        {
            InitializeComponent();
            this.MainFormReference = MainFormReference;
            this.TopMost = true;
            this.LostFocus += new EventHandler(frmThreads_LostFocus);
            this.GotFocus += new EventHandler(frmThreads_GotFocus);
            foreach (BackgroundWorker thread in MainFormReference.ConcurrentOperations)
            {
                Label indexLabel = new Label();
                indexLabel.Location = new Point(curPosX, curPosY + 3);
                indexLabel.AutoSize = true;
                indexLabel.Text = "Thread " + (counter + 1);
                IndexLabels.Add(indexLabel);
                this.Controls.Add(indexLabel);

                ProgressBar progressBar = new ProgressBar();
                progressBar.Location = new Point(indexLabel.Size.Width + marginX, curPosY);
                progressBar.Size = new Size(150, 20);
                progressBar.Value = MainFormReference.ConcurrentOperationsProgress[counter];
                ProgressBars.Add(progressBar);
                this.Controls.Add(progressBar);

                Label jobProgressLabel = new Label();
                jobProgressLabel.Location = new Point(indexLabel.Size.Width + progressBar.Size.Width + marginX, curPosY + 3);
                jobProgressLabel.AutoSize = true;
                jobProgressLabel.Text = MainFormReference.ConcurrentOperationsProgress[counter].ToString() + "%";
                JobProgressLabels.Add(jobProgressLabel);
                this.Controls.Add(jobProgressLabel);

                Label currentJobLabel = new Label();
                currentJobLabel.Location = new Point(indexLabel.Size.Width + progressBar.Size.Width + 30 + marginX * 3, curPosY + 3);
                currentJobLabel.AutoSize = true;
                currentJobLabel.Text = "Current Job: " + MainFormReference.ConcurrentOperationsCurrentJob[counter];
                CurrentJobLabels.Add(currentJobLabel);
                this.Controls.Add(currentJobLabel);

                int thisColumnWidth = indexLabel.Size.Width + progressBar.Size.Width + 30 + currentJobLabel.Size.Width + marginX * 4;
                if (thisColumnWidth > columnWidth) columnWidth = thisColumnWidth;

                totalHeight += rowHeight;
                curPosY += rowHeight;
                if (this.Size.Height < totalHeight) this.Size = new Size(this.Size.Width, totalHeight + 5);
                if (this.Size.Width < columnWidth) this.Size = new Size(columnWidth + 5, this.Size.Height);
                counter++;
            }
        }

        void frmThreads_GotFocus(object sender, EventArgs e)
        {
            this.Opacity = 1;
        }

        void frmThreads_LostFocus(object sender, EventArgs e)
        {
            this.Opacity = 0.7;
        }

        private void UpdateDisplay()
        {
            for (int counter = 0; counter < Configuration.MaxThreads; counter++)
            {
                int thisColumnWidth = IndexLabels[counter].Size.Width + ProgressBars[counter].Size.Width + 30 + CurrentJobLabels[counter].Size.Width + marginX * 4;
                if (thisColumnWidth > columnWidth) columnWidth = thisColumnWidth;
                if (this.Size.Height < totalHeight) this.Size = new Size(this.Size.Width, totalHeight + 5);
                if (this.Size.Width < columnWidth) this.Size = new Size(columnWidth + 5, this.Size.Height);

                CurrentJobLabels[counter].Text = MainFormReference.ConcurrentOperationsCurrentJob[counter];
                JobProgressLabels[counter].Text = MainFormReference.ConcurrentOperationsProgress[counter].ToString() + "%";
                ProgressBars[counter].Value = MainFormReference.ConcurrentOperationsProgress[counter];
            }
        }

        private void tCheckThreadStatus_Tick(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void AutoPositionWindow()
        {
            if (MainFormReference.WindowState == FormWindowState.Normal)
            {
                this.Location = new Point(MainFormReference.Location.X + this.Size.Width / 2, MainFormReference.Location.Y + MainFormReference.Size.Height);
            }
            else if (MainFormReference.WindowState == FormWindowState.Maximized)
            {
                this.Location = new Point(0, (Screen.PrimaryScreen.WorkingArea.Height - this.Size.Height)); 
            }
        }

        private void frmThreads_Load(object sender, EventArgs e)
        {
            AutoPositionWindow();
        }
    }
}
