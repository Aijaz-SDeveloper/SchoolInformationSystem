namespace Frontend.Reports.Parameter
{
    partial class frmChallanFees
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.cbardef = new ActionToolBar.ToolbarControl();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbSector.SuspendLayout();
            this.ssDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSector
            // 
            this.gbSector.Controls.Add(this.label2);
            this.gbSector.Controls.Add(this.cbFormat);
            this.gbSector.Controls.Add(this.label3);
            this.gbSector.Controls.Add(this.label1);
            this.gbSector.Controls.Add(this.cbClass);
            this.gbSector.Controls.Add(this.label9);
            this.gbSector.Controls.Add(this.cbYear);
            this.gbSector.Controls.Add(this.label8);
            this.gbSector.Controls.Add(this.cbMonth);
            this.gbSector.Controls.Add(this.label4);
            this.gbSector.Controls.Add(this.label7);
            this.gbSector.Location = new System.Drawing.Point(12, 48);
            this.gbSector.Name = "gbSector";
            this.gbSector.Size = new System.Drawing.Size(393, 143);
            this.gbSector.TabIndex = 26;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "General Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Class";
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbClass.Location = new System.Drawing.Point(128, 109);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(185, 21);
            this.cbClass.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Year";
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbYear.Location = new System.Drawing.Point(128, 46);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(185, 21);
            this.cbYear.TabIndex = 81;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Month";
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbMonth.Location = new System.Drawing.Point(128, 19);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(185, 21);
            this.cbMonth.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(319, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(319, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "*";
            // 
            // tssRecord
            // 
            this.tssRecord.Name = "tssRecord";
            this.tssRecord.Size = new System.Drawing.Size(0, 17);
            // 
            // tssAction
            // 
            this.tssAction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssAction.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tssAction.Name = "tssAction";
            this.tssAction.Size = new System.Drawing.Size(4, 17);
            // 
            // ssDef
            // 
            this.ssDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssDef.Location = new System.Drawing.Point(0, 209);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(426, 22);
            this.ssDef.TabIndex = 25;
            this.ssDef.Text = "statusStrip1";
            // 
            // cbardef
            // 
            this.cbardef.Location = new System.Drawing.Point(0, 0);
            this.cbardef.Name = "cbardef";
            this.cbardef.Size = new System.Drawing.Size(60, 27);
            this.cbardef.TabIndex = 24;
            this.cbardef.PrintClicked += new ActionToolBar.ToolbarControl.PrintClickedHandler(this.cbardef_PrintClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Format";
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbFormat.Location = new System.Drawing.Point(130, 79);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(185, 21);
            this.cbFormat.TabIndex = 86;
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
            // frmChallanFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 231);
            this.Controls.Add(this.gbSector);
            this.Controls.Add(this.ssDef);
            this.Controls.Add(this.cbardef);
            this.Name = "frmChallanFees";
            this.Text = "frmChallanFees";
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSector;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.StatusStrip ssDef;
        private ActionToolBar.ToolbarControl cbardef;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label label3;
    }
}