namespace ThreadSave
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtThreadUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.appStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tSecond = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stThreadImagePreviewLabel = new System.Windows.Forms.Label();
            this.stPreviewNextImage = new System.Windows.Forms.Label();
            this.stPreviewPreviousImage = new System.Windows.Forms.Label();
            this.stPreviewImage = new System.Windows.Forms.PictureBox();
            this.stThreadExists = new System.Windows.Forms.Label();
            this.stNextThreadCheck = new System.Windows.Forms.Label();
            this.stStorageLocation = new System.Windows.Forms.Label();
            this.btnShowPreferences = new System.Windows.Forms.Button();
            this.stImagesDownloaded = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowDownloaders = new System.Windows.Forms.Button();
            this.ActionLog = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StatusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stPreviewImage)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtThreadUrl
            // 
            this.txtThreadUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThreadUrl.Location = new System.Drawing.Point(87, 13);
            this.txtThreadUrl.Name = "txtThreadUrl";
            this.txtThreadUrl.Size = new System.Drawing.Size(332, 20);
            this.txtThreadUrl.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thread URL:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(344, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.appStatus});
            this.StatusStrip.Location = new System.Drawing.Point(0, 303);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(667, 22);
            this.StatusStrip.TabIndex = 4;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // appStatus
            // 
            this.appStatus.Name = "appStatus";
            this.appStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // TrayIcon
            // 
            this.TrayIcon.Text = "notifyIcon1";
            this.TrayIcon.Visible = true;
            // 
            // tSecond
            // 
            this.tSecond.Interval = 1000;
            this.tSecond.Tick += new System.EventHandler(this.tSecond_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.stThreadImagePreviewLabel);
            this.panel1.Controls.Add(this.stPreviewNextImage);
            this.panel1.Controls.Add(this.stPreviewPreviousImage);
            this.panel1.Controls.Add(this.stPreviewImage);
            this.panel1.Controls.Add(this.stThreadExists);
            this.panel1.Controls.Add(this.stNextThreadCheck);
            this.panel1.Controls.Add(this.stStorageLocation);
            this.panel1.Controls.Add(this.btnShowPreferences);
            this.panel1.Controls.Add(this.stImagesDownloaded);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnShowDownloaders);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(457, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 303);
            this.panel1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.Location = new System.Drawing.Point(8, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Next Thread Check:";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.Location = new System.Drawing.Point(8, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Thread Exists:";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Location = new System.Drawing.Point(8, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Storage Location:";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(8, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Images Downloaded:";
            // 
            // stThreadImagePreviewLabel
            // 
            this.stThreadImagePreviewLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stThreadImagePreviewLabel.AutoEllipsis = true;
            this.stThreadImagePreviewLabel.Location = new System.Drawing.Point(24, 221);
            this.stThreadImagePreviewLabel.Name = "stThreadImagePreviewLabel";
            this.stThreadImagePreviewLabel.Size = new System.Drawing.Size(161, 13);
            this.stThreadImagePreviewLabel.TabIndex = 19;
            this.stThreadImagePreviewLabel.Text = "Thread Image Preview";
            this.stThreadImagePreviewLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stPreviewNextImage
            // 
            this.stPreviewNextImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stPreviewNextImage.AutoSize = true;
            this.stPreviewNextImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stPreviewNextImage.Location = new System.Drawing.Point(186, 216);
            this.stPreviewNextImage.Name = "stPreviewNextImage";
            this.stPreviewNextImage.Size = new System.Drawing.Size(18, 20);
            this.stPreviewNextImage.TabIndex = 18;
            this.stPreviewNextImage.Text = "»";
            this.stPreviewNextImage.Click += new System.EventHandler(this.stPreviewNextImage_Click);
            // 
            // stPreviewPreviousImage
            // 
            this.stPreviewPreviousImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stPreviewPreviousImage.AutoSize = true;
            this.stPreviewPreviousImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stPreviewPreviousImage.Location = new System.Drawing.Point(7, 216);
            this.stPreviewPreviousImage.Name = "stPreviewPreviousImage";
            this.stPreviewPreviousImage.Size = new System.Drawing.Size(18, 20);
            this.stPreviewPreviousImage.TabIndex = 17;
            this.stPreviewPreviousImage.Text = "«";
            this.stPreviewPreviousImage.Click += new System.EventHandler(this.stPreviewPreviousImage_Click);
            // 
            // stPreviewImage
            // 
            this.stPreviewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stPreviewImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stPreviewImage.Location = new System.Drawing.Point(11, 98);
            this.stPreviewImage.Name = "stPreviewImage";
            this.stPreviewImage.Size = new System.Drawing.Size(189, 115);
            this.stPreviewImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stPreviewImage.TabIndex = 16;
            this.stPreviewImage.TabStop = false;
            // 
            // stThreadExists
            // 
            this.stThreadExists.AutoEllipsis = true;
            this.stThreadExists.Location = new System.Drawing.Point(117, 80);
            this.stThreadExists.Name = "stThreadExists";
            this.stThreadExists.Size = new System.Drawing.Size(80, 15);
            this.stThreadExists.TabIndex = 15;
            // 
            // stNextThreadCheck
            // 
            this.stNextThreadCheck.AutoEllipsis = true;
            this.stNextThreadCheck.Location = new System.Drawing.Point(120, 63);
            this.stNextThreadCheck.Name = "stNextThreadCheck";
            this.stNextThreadCheck.Size = new System.Drawing.Size(80, 13);
            this.stNextThreadCheck.TabIndex = 14;
            // 
            // stStorageLocation
            // 
            this.stStorageLocation.AutoEllipsis = true;
            this.stStorageLocation.Location = new System.Drawing.Point(117, 46);
            this.stStorageLocation.Name = "stStorageLocation";
            this.stStorageLocation.Size = new System.Drawing.Size(82, 13);
            this.stStorageLocation.TabIndex = 13;
            this.stStorageLocation.Click += new System.EventHandler(this.stStorageLocation_Click);
            // 
            // btnShowPreferences
            // 
            this.btnShowPreferences.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowPreferences.Location = new System.Drawing.Point(6, 241);
            this.btnShowPreferences.Name = "btnShowPreferences";
            this.btnShowPreferences.Size = new System.Drawing.Size(198, 23);
            this.btnShowPreferences.TabIndex = 12;
            this.btnShowPreferences.Text = "Preferences";
            this.btnShowPreferences.UseVisualStyleBackColor = true;
            // 
            // stImagesDownloaded
            // 
            this.stImagesDownloaded.AutoEllipsis = true;
            this.stImagesDownloaded.Location = new System.Drawing.Point(117, 29);
            this.stImagesDownloaded.Name = "stImagesDownloaded";
            this.stImagesDownloaded.Size = new System.Drawing.Size(81, 13);
            this.stImagesDownloaded.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Statistics";
            // 
            // btnShowDownloaders
            // 
            this.btnShowDownloaders.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowDownloaders.Location = new System.Drawing.Point(6, 270);
            this.btnShowDownloaders.Name = "btnShowDownloaders";
            this.btnShowDownloaders.Size = new System.Drawing.Size(198, 23);
            this.btnShowDownloaders.TabIndex = 8;
            this.btnShowDownloaders.Text = "Downloader Progress";
            this.btnShowDownloaders.UseVisualStyleBackColor = true;
            this.btnShowDownloaders.Click += new System.EventHandler(this.btnShowDownloaders_Click);
            // 
            // ActionLog
            // 
            this.ActionLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ActionLog.Location = new System.Drawing.Point(15, 68);
            this.ActionLog.Name = "ActionLog";
            this.ActionLog.Size = new System.Drawing.Size(404, 225);
            this.ActionLog.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ActionLog);
            this.panel2.Controls.Add(this.txtThreadUrl);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 303);
            this.panel2.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 325);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusStrip);
            this.Name = "frmMain";
            this.Text = "ThreadSave";
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stPreviewImage)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtThreadUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel appStatus;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.Timer tSecond;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowDownloaders;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox ActionLog;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label stImagesDownloaded;
        private System.Windows.Forms.Button btnShowPreferences;
        private System.Windows.Forms.Label stStorageLocation;
        private System.Windows.Forms.Label stNextThreadCheck;
        private System.Windows.Forms.Label stThreadExists;
        private System.Windows.Forms.Label stThreadImagePreviewLabel;
        private System.Windows.Forms.Label stPreviewNextImage;
        private System.Windows.Forms.Label stPreviewPreviousImage;
        private System.Windows.Forms.PictureBox stPreviewImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

