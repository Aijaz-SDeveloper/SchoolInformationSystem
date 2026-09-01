namespace Frontend.Parameter
{
    partial class AcademicYear
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
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.ssSeason = new System.Windows.Forms.StatusStrip();
            this.label5 = new System.Windows.Forms.Label();
            this.tbYearName = new System.Windows.Forms.TextBox();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.cbarYeardef = new ActionToolBar.ToolbarControl();
            this.dpTodate = new System.Windows.Forms.DateTimePicker();
            this.gbSeanson = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ssSeason.SuspendLayout();
            this.gbSeanson.SuspendLayout();
            this.SuspendLayout();
            // 
            // tssRecord
            // 
            this.tssRecord.Name = "tssRecord";
            this.tssRecord.Size = new System.Drawing.Size(0, 17);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(378, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "*";
            // 
            // tssAction
            // 
            this.tssAction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssAction.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tssAction.Name = "tssAction";
            this.tssAction.Size = new System.Drawing.Size(4, 17);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(378, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(12, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "*";
            // 
            // ssSeason
            // 
            this.ssSeason.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssSeason.Location = new System.Drawing.Point(0, 352);
            this.ssSeason.Name = "ssSeason";
            this.ssSeason.Size = new System.Drawing.Size(567, 22);
            this.ssSeason.TabIndex = 8;
            this.ssSeason.Text = "statusStrip1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(378, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "*";
            // 
            // tbYearName
            // 
            this.tbYearName.Location = new System.Drawing.Point(157, 138);
            this.tbYearName.MaxLength = 1000;
            this.tbYearName.Name = "tbYearName";
            this.tbYearName.Size = new System.Drawing.Size(200, 20);
            this.tbYearName.TabIndex = 4;
            // 
            // dpFromDate
            // 
            this.dpFromDate.Location = new System.Drawing.Point(157, 29);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dpFromDate.TabIndex = 2;
            // 
            // cbarYeardef
            // 
            this.cbarYeardef.Location = new System.Drawing.Point(0, 2);
            this.cbarYeardef.Name = "cbarYeardef";
            this.cbarYeardef.Size = new System.Drawing.Size(268, 27);
            this.cbarYeardef.TabIndex = 6;
            this.cbarYeardef.SearchClicked += new ActionToolBar.ToolbarControl.SearchClickedHandler(this.cbarYeardef_SearchClicked);
            this.cbarYeardef.DeleteClicked += new ActionToolBar.ToolbarControl.DeleteClickedHandler(this.cbarYeardef_DeleteClicked);
            this.cbarYeardef.ApproveClicked += new ActionToolBar.ToolbarControl.ApproveClickedHandler(this.cbarYeardef_ApproveClicked);
            this.cbarYeardef.CloseClicked += new ActionToolBar.ToolbarControl.CloseClickedHandler(this.cbarYeardef_CloseClicked);
            this.cbarYeardef.SaveClicked += new ActionToolBar.ToolbarControl.SaveClickedHandler(this.cbarYeardef_SaveClicked);
            this.cbarYeardef.NextClicked += new ActionToolBar.ToolbarControl.NextClickedHandler(this.cbarYeardef_NextClicked);
            this.cbarYeardef.PreviousClicked += new ActionToolBar.ToolbarControl.PreviousClickedHandler(this.cbarYeardef_PreviousClicked);
            this.cbarYeardef.LastClicked += new ActionToolBar.ToolbarControl.LastClickedHandler(this.cbarYeardef_LastClicked);
            this.cbarYeardef.FirstClicked += new ActionToolBar.ToolbarControl.FirstClickedHandler(this.cbarYeardef_FirstClicked);
            this.cbarYeardef.NewClicked += new ActionToolBar.ToolbarControl.NewClickedHandler(this.cbarYeardef_NewClicked);
           
            // 
            // dpTodate
            // 
            this.dpTodate.Checked = false;
            this.dpTodate.Enabled = false;
            this.dpTodate.Location = new System.Drawing.Point(157, 85);
            this.dpTodate.Name = "dpTodate";
            this.dpTodate.ShowCheckBox = true;
            this.dpTodate.Size = new System.Drawing.Size(200, 20);
            this.dpTodate.TabIndex = 4;
            this.dpTodate.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            // 
            // gbSeanson
            // 
            this.gbSeanson.Controls.Add(this.label7);
            this.gbSeanson.Controls.Add(this.label6);
            this.gbSeanson.Controls.Add(this.label5);
            this.gbSeanson.Controls.Add(this.tbYearName);
            this.gbSeanson.Controls.Add(this.dpTodate);
            this.gbSeanson.Controls.Add(this.dpFromDate);
            this.gbSeanson.Controls.Add(this.label3);
            this.gbSeanson.Controls.Add(this.label2);
            this.gbSeanson.Controls.Add(this.label1);
            this.gbSeanson.Location = new System.Drawing.Point(13, 51);
            this.gbSeanson.Name = "gbSeanson";
            this.gbSeanson.Size = new System.Drawing.Size(499, 205);
            this.gbSeanson.TabIndex = 7;
            this.gbSeanson.TabStop = false;
            this.gbSeanson.Text = "General Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Year Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // AcademicYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 374);
            this.Controls.Add(this.ssSeason);
            this.Controls.Add(this.cbarYeardef);
            this.Controls.Add(this.gbSeanson);
            this.Name = "AcademicYear";
            this.Text = "AcademicYear";
            this.ssSeason.ResumeLayout(false);
            this.ssSeason.PerformLayout();
            this.gbSeanson.ResumeLayout(false);
            this.gbSeanson.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.StatusStrip ssSeason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbYearName;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private ActionToolBar.ToolbarControl cbarYeardef;
        private System.Windows.Forms.DateTimePicker dpTodate;
        private System.Windows.Forms.GroupBox gbSeanson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}