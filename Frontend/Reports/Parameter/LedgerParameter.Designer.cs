namespace Frontend.Reports.Parameter
{
    partial class LedgerParameter
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
            this.gbSector = new System.Windows.Forms.GroupBox();
            this.tbGRNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbardef = new ActionToolBar.ToolbarControl();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSector.SuspendLayout();
            this.ssDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSector
            // 
            this.gbSector.Controls.Add(this.tbGRNo);
            this.gbSector.Controls.Add(this.label3);
            this.gbSector.Controls.Add(this.label9);
            this.gbSector.Controls.Add(this.cbYear);
            this.gbSector.Controls.Add(this.label8);
            this.gbSector.Controls.Add(this.label4);
            this.gbSector.Location = new System.Drawing.Point(20, 44);
            this.gbSector.Name = "gbSector";
            this.gbSector.Size = new System.Drawing.Size(393, 143);
            this.gbSector.TabIndex = 27;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "General Information";
            // 
            // tbGRNo
            // 
            this.tbGRNo.Location = new System.Drawing.Point(128, 32);
            this.tbGRNo.Name = "tbGRNo";
            this.tbGRNo.Size = new System.Drawing.Size(187, 20);
            this.tbGRNo.TabIndex = 88;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(321, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Academic Year";
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbYear.Location = new System.Drawing.Point(128, 80);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(185, 21);
            this.cbYear.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "GR No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "*";
            // 
            // cbardef
            // 
            this.cbardef.Location = new System.Drawing.Point(13, 6);
            this.cbardef.Name = "cbardef";
            this.cbardef.Size = new System.Drawing.Size(60, 27);
            this.cbardef.TabIndex = 28;
            this.cbardef.PrintClicked += new ActionToolBar.ToolbarControl.PrintClickedHandler(this.cbardef_PrintClicked);
            // 
            // ssDef
            // 
            this.ssDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssDef.Location = new System.Drawing.Point(0, 239);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(495, 22);
            this.ssDef.TabIndex = 29;
            this.ssDef.Text = "statusStrip1";
            // 
            // tssAction
            // 
            this.tssAction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssAction.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tssAction.Name = "tssAction";
            this.tssAction.Size = new System.Drawing.Size(4, 17);
            // 
            // tssRecord
            // 
            this.tssRecord.Name = "tssRecord";
            this.tssRecord.Size = new System.Drawing.Size(0, 17);
            // 
            // LedgerParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 261);
            this.Controls.Add(this.ssDef);
            this.Controls.Add(this.cbardef);
            this.Controls.Add(this.gbSector);
            this.Name = "LedgerParameter";
            this.Text = "LedgerParameter";
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSector;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private ActionToolBar.ToolbarControl cbardef;
        private System.Windows.Forms.TextBox tbGRNo;
        private System.Windows.Forms.StatusStrip ssDef;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
    }
}