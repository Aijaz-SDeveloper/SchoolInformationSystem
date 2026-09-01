namespace Frontend.Reports
{
    partial class ReportViewerPopup
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
            this.lblError = new System.Windows.Forms.Label();
            this.rViewerPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(30, 5);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(39, 13);
            this.lblError.TabIndex = 1;
            this.lblError.Text = "lblError";
            // 
            // rViewerPrint
            // 
            this.rViewerPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rViewerPrint.Location = new System.Drawing.Point(3, 30);
            this.rViewerPrint.Name = "rViewerPrint";
            this.rViewerPrint.Size = new System.Drawing.Size(850, 700);
            this.rViewerPrint.TabIndex = 2;
            this.rViewerPrint.Load += new System.EventHandler(this.ReportViewer_Load_1);
            this.rViewerPrint.Print += new System.ComponentModel.CancelEventHandler(this.ReportViewer_Print);
            // 
            // ReportViewerPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 742);
            this.Controls.Add(this.rViewerPrint);
            this.Controls.Add(this.lblError);
            this.Name = "ReportViewerPopup";
            this.Text = "ReportViewerPopup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ReportViewerPopup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblError;
        public Microsoft.Reporting.WinForms.ReportViewer rViewerPrint;
    }
}