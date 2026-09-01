namespace Frontend.Reports.Parameter
{
    partial class FrmScrollParameter
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
            this.cbardef = new ActionToolBar.ToolbarControl();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSector = new System.Windows.Forms.GroupBox();
            this.tbGRNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dpToDate = new System.Windows.Forms.DateTimePicker();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ssDef.SuspendLayout();
            this.gbSector.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbardef
            // 
            this.cbardef.Location = new System.Drawing.Point(0, 0);
            this.cbardef.Name = "cbardef";
            this.cbardef.Size = new System.Drawing.Size(60, 27);
            this.cbardef.TabIndex = 63;
            this.cbardef.PrintClicked += new ActionToolBar.ToolbarControl.PrintClickedHandler(this.cbardef_PrintClicked);
            // 
            // ssDef
            // 
            this.ssDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssDef.Location = new System.Drawing.Point(0, 303);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(529, 22);
            this.ssDef.TabIndex = 64;
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
            // gbSector
            // 
            this.gbSector.Controls.Add(this.tbGRNo);
            this.gbSector.Controls.Add(this.label2);
            this.gbSector.Controls.Add(this.label3);
            this.gbSector.Controls.Add(this.dpToDate);
            this.gbSector.Controls.Add(this.dpFromDate);
            this.gbSector.Controls.Add(this.label1);
            this.gbSector.Controls.Add(this.cbClass);
            this.gbSector.Controls.Add(this.label9);
            this.gbSector.Controls.Add(this.label8);
            this.gbSector.Controls.Add(this.label4);
            this.gbSector.Controls.Add(this.label7);
            this.gbSector.Location = new System.Drawing.Point(28, 46);
            this.gbSector.Name = "gbSector";
            this.gbSector.Size = new System.Drawing.Size(457, 188);
            this.gbSector.TabIndex = 65;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "General Information";
            // 
            // tbGRNo
            // 
            this.tbGRNo.Location = new System.Drawing.Point(126, 114);
            this.tbGRNo.Name = "tbGRNo";
            this.tbGRNo.Size = new System.Drawing.Size(187, 20);
            this.tbGRNo.TabIndex = 91;
            this.tbGRNo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 90;
            this.label2.Text = "GR No";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(317, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 89;
            this.label3.Text = "*";
            this.label3.Visible = false;
            // 
            // dpToDate
            // 
            this.dpToDate.Location = new System.Drawing.Point(129, 77);
            this.dpToDate.Name = "dpToDate";
            this.dpToDate.Size = new System.Drawing.Size(200, 20);
            this.dpToDate.TabIndex = 86;
            // 
            // dpFromDate
            // 
            this.dpFromDate.Location = new System.Drawing.Point(129, 27);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dpFromDate.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Class";
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbClass.Location = new System.Drawing.Point(129, 126);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(200, 21);
            this.cbClass.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "ToDate";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "From Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(356, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "*";
            //this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // FrmScrollParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 325);
            this.Controls.Add(this.gbSector);
            this.Controls.Add(this.ssDef);
            this.Controls.Add(this.cbardef);
            this.Name = "FrmScrollParameter";
            this.Text = "FrmScrollParameter";
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ActionToolBar.ToolbarControl cbardef;
        private System.Windows.Forms.StatusStrip ssDef;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.GroupBox gbSector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dpToDate;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.TextBox tbGRNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}