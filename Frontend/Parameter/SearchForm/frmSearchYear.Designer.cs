namespace Frontend.Parameter.SearchForm
{
    partial class frmSearchYear
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvSearchSeason = new System.Windows.Forms.DataGridView();
            this.tssSearchAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbYearName = new System.Windows.Forms.TextBox();
            this.ssSearchSeason = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.lbSeasonName = new System.Windows.Forms.Label();
            this.seasonSearchToolBar = new ActionToolBar.SearchToolBar();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchSeason)).BeginInit();
            this.ssSearchSeason.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvSearchSeason);
            this.groupBox2.Location = new System.Drawing.Point(13, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 280);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Results";
            // 
            // gvSearchSeason
            // 
            this.gvSearchSeason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearchSeason.Location = new System.Drawing.Point(13, 19);
            this.gvSearchSeason.Name = "gvSearchSeason";
            this.gvSearchSeason.Size = new System.Drawing.Size(555, 255);
            this.gvSearchSeason.TabIndex = 0;
            this.gvSearchSeason.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvSearchSeason_MouseDoubleClick);
            this.gvSearchSeason.SelectionChanged += new System.EventHandler(this.gvSearchSeason_SelectionChanged);
            // 
            // tssSearchAction
            // 
            this.tssSearchAction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssSearchAction.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tssSearchAction.Name = "tssSearchAction";
            this.tssSearchAction.Size = new System.Drawing.Size(4, 17);
            // 
            // tssRecord
            // 
            this.tssRecord.Name = "tssRecord";
            this.tssRecord.Size = new System.Drawing.Size(0, 17);
            // 
            // tbYearName
            // 
            this.tbYearName.Location = new System.Drawing.Point(93, 17);
            this.tbYearName.Name = "tbYearName";
            this.tbYearName.Size = new System.Drawing.Size(153, 20);
            this.tbYearName.TabIndex = 1;
            // 
            // ssSearchSeason
            // 
            this.ssSearchSeason.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSearchAction,
            this.tssRecord});
            this.ssSearchSeason.Location = new System.Drawing.Point(0, 404);
            this.ssSearchSeason.Name = "ssSearchSeason";
            this.ssSearchSeason.Size = new System.Drawing.Size(630, 22);
            this.ssSearchSeason.TabIndex = 10;
            this.ssSearchSeason.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dpFromDate);
            this.groupBox1.Controls.Add(this.lbFromDate);
            this.groupBox1.Controls.Add(this.tbYearName);
            this.groupBox1.Controls.Add(this.lbSeasonName);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 74);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // dpFromDate
            // 
            this.dpFromDate.Checked = false;
            this.dpFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpFromDate.Location = new System.Drawing.Point(335, 17);
            this.dpFromDate.Name = "dpFromDate";
            this.dpFromDate.ShowCheckBox = true;
            this.dpFromDate.Size = new System.Drawing.Size(234, 20);
            this.dpFromDate.TabIndex = 3;
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Location = new System.Drawing.Point(260, 20);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(56, 13);
            this.lbFromDate.TabIndex = 2;
            this.lbFromDate.Text = "From Date";
            // 
            // lbSeasonName
            // 
            this.lbSeasonName.AutoSize = true;
            this.lbSeasonName.Location = new System.Drawing.Point(7, 20);
            this.lbSeasonName.Name = "lbSeasonName";
            this.lbSeasonName.Size = new System.Drawing.Size(60, 13);
            this.lbSeasonName.TabIndex = 0;
            this.lbSeasonName.Text = "Year Name";
            // 
            // seasonSearchToolBar
            // 
            this.seasonSearchToolBar.Location = new System.Drawing.Point(0, 0);
            this.seasonSearchToolBar.Name = "seasonSearchToolBar";
            this.seasonSearchToolBar.Size = new System.Drawing.Size(93, 29);
            this.seasonSearchToolBar.TabIndex = 7;
            this.seasonSearchToolBar.SeachDetailClicked += new ActionToolBar.SearchToolBar.SeachDetailClickedHandler(this.seasonSearchToolBar_SeachDetailClicked);
            this.seasonSearchToolBar.ClearClicked += new ActionToolBar.SearchToolBar.ClearClickedHandler(this.seasonSearchToolBar_ClearClicked);
            this.seasonSearchToolBar.ShowDetailClicked += new ActionToolBar.SearchToolBar.DetailClickedHandler(this.seasonSearchToolBar_ShowDetailClicked);
            // 
            // frmSearchYear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 426);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ssSearchSeason);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.seasonSearchToolBar);
            this.Name = "frmSearchYear";
            this.Text = "frmSearchYear";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearchSeason)).EndInit();
            this.ssSearchSeason.ResumeLayout(false);
            this.ssSearchSeason.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvSearchSeason;
        private System.Windows.Forms.ToolStripStatusLabel tssSearchAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.TextBox tbYearName;
        private System.Windows.Forms.StatusStrip ssSearchSeason;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dpFromDate;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.Label lbSeasonName;
        private ActionToolBar.SearchToolBar seasonSearchToolBar;
    }
}