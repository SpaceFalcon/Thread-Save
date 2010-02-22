namespace ThreadSave
{
    partial class frmThreads
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
            this.tCheckThreadStatus = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // tCheckThreadStatus
            // 
            this.tCheckThreadStatus.Enabled = true;
            this.tCheckThreadStatus.Interval = 1;
            this.tCheckThreadStatus.Tick += new System.EventHandler(this.tCheckThreadStatus_Tick);
            // 
            // frmThreads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 85);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmThreads";
            this.Text = " Thread Statistics";
            this.Load += new System.EventHandler(this.frmThreads_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tCheckThreadStatus;
    }
}