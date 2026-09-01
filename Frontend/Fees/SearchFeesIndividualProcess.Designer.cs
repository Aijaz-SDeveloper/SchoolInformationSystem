namespace Frontend.Fees
{
    partial class SearchFeesIndividualProcess
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.dpAssignmentDate = new System.Windows.Forms.DateTimePicker();
            this.ssSearchSeason = new System.Windows.Forms.StatusStrip();
            this.tssSearchAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbFeesType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbGrowerCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStNo = new System.Windows.Forms.TextBox();
            this.lbCode = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchToolBar = new ActionToolBar.SearchToolBar();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.ssSearchSeason.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tssRecord
            // 
            this.tssRecord.Name = "tssRecord";
            this.tssRecord.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvSearch);
            this.groupBox2.Location = new System.Drawing.Point(13, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 280);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Results";
            // 
            // gvSearch
            // 
            this.gvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Location = new System.Drawing.Point(13, 19);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.Size = new System.Drawing.Size(555, 255);
            this.gvSearch.TabIndex = 0;
            this.gvSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gvSearch_MouseDoubleClick);
            this.gvSearch.SelectionChanged += new System.EventHandler(this.gvSearch_SelectionChanged);
            // 
            // dpAssignmentDate
            // 
            this.dpAssignmentDate.Checked = false;
            this.dpAssignmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dpAssignmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpAssignmentDate.Location = new System.Drawing.Point(393, 20);
            this.dpAssignmentDate.Name = "dpAssignmentDate";
            this.dpAssignmentDate.ShowCheckBox = true;
            this.dpAssignmentDate.Size = new System.Drawing.Size(155, 20);
            this.dpAssignmentDate.TabIndex = 36;
            // 
            // ssSearchSeason
            // 
            this.ssSearchSeason.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSearchAction,
            this.tssRecord});
            this.ssSearchSeason.Location = new System.Drawing.Point(0, 484);
            this.ssSearchSeason.Name = "ssSearchSeason";
            this.ssSearchSeason.Size = new System.Drawing.Size(662, 22);
            this.ssSearchSeason.TabIndex = 30;
            this.ssSearchSeason.Text = "statusStrip1";
            // 
            // tssSearchAction
            // 
            this.tssSearchAction.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssSearchAction.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.tssSearchAction.Name = "tssSearchAction";
            this.tssSearchAction.Size = new System.Drawing.Size(4, 17);
            // 
            // cbFeesType
            // 
            this.cbFeesType.FormattingEnabled = true;
            this.cbFeesType.Location = new System.Drawing.Point(101, 51);
            this.cbFeesType.Name = "cbFeesType";
            this.cbFeesType.Size = new System.Drawing.Size(153, 21);
            this.cbFeesType.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbYear);
            this.groupBox1.Controls.Add(this.cbClass);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbMonth);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dpAssignmentDate);
            this.groupBox1.Controls.Add(this.cbFeesType);
            this.groupBox1.Controls.Add(this.lbAmount);
            this.groupBox1.Controls.Add(this.lbGrowerCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbStNo);
            this.groupBox1.Controls.Add(this.lbCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 118);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(298, 51);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(32, 13);
            this.lbAmount.TabIndex = 6;
            this.lbAmount.Text = "Class";
            // 
            // lbGrowerCode
            // 
            this.lbGrowerCode.AutoSize = true;
            this.lbGrowerCode.Location = new System.Drawing.Point(7, 54);
            this.lbGrowerCode.Name = "lbGrowerCode";
            this.lbGrowerCode.Size = new System.Drawing.Size(57, 13);
            this.lbGrowerCode.TabIndex = 4;
            this.lbGrowerCode.Text = "Fees Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Date";
            // 
            // tbStNo
            // 
            this.tbStNo.Location = new System.Drawing.Point(101, 17);
            this.tbStNo.Name = "tbStNo";
            this.tbStNo.Size = new System.Drawing.Size(153, 20);
            this.tbStNo.TabIndex = 1;
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Location = new System.Drawing.Point(7, 20);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(61, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Student No";
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(101, 85);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(153, 21);
            this.cbMonth.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Month";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Year";
            // 
            // SearchToolBar
            // 
            this.SearchToolBar.Location = new System.Drawing.Point(0, 0);
            this.SearchToolBar.Name = "SearchToolBar";
            this.SearchToolBar.Size = new System.Drawing.Size(80, 28);
            this.SearchToolBar.TabIndex = 31;
            this.SearchToolBar.SeachDetailClicked += new ActionToolBar.SearchToolBar.SeachDetailClickedHandler(this.SearchToolBar_SeachDetailClicked);
            this.SearchToolBar.ClearClicked += new ActionToolBar.SearchToolBar.ClearClickedHandler(this.SearchToolBar_ClearClicked);
            this.SearchToolBar.ShowDetailClicked += new ActionToolBar.SearchToolBar.DetailClickedHandler(this.SearchToolBar_ShowDetailClicked);
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(393, 49);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(153, 21);
            this.cbClass.TabIndex = 41;
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(393, 81);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(153, 21);
            this.cbYear.TabIndex = 42;
            // 
            // SearchFeesIndividualProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 506);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ssSearchSeason);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchToolBar);
            this.Name = "SearchFeesIndividualProcess";
            this.Text = "SearchFeesIndividualProcess";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ssSearchSeason.ResumeLayout(false);
            this.ssSearchSeason.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.DateTimePicker dpAssignmentDate;
        private System.Windows.Forms.StatusStrip ssSearchSeason;
        private System.Windows.Forms.ToolStripStatusLabel tssSearchAction;
        private System.Windows.Forms.ComboBox cbFeesType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbGrowerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStNo;
        private System.Windows.Forms.Label lbCode;
        private ActionToolBar.SearchToolBar SearchToolBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.ComboBox cbYear;
    }
}