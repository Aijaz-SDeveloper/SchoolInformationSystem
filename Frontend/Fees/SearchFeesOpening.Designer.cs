namespace Frontend.Fees
{
    partial class SearchFeesOpening
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dpAssignmentDate = new System.Windows.Forms.DateTimePicker();
            this.cbFeesType = new System.Windows.Forms.ComboBox();
            this.chBIsActive = new System.Windows.Forms.CheckBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.lbAmount = new System.Windows.Forms.Label();
            this.lbGrowerCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStNo = new System.Windows.Forms.TextBox();
            this.lbCode = new System.Windows.Forms.Label();
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ssSearchSeason = new System.Windows.Forms.StatusStrip();
            this.tssSearchAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.SearchToolBar = new ActionToolBar.SearchToolBar();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.ssSearchSeason.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dpAssignmentDate);
            this.groupBox1.Controls.Add(this.cbFeesType);
            this.groupBox1.Controls.Add(this.chBIsActive);
            this.groupBox1.Controls.Add(this.tbAmount);
            this.groupBox1.Controls.Add(this.lbAmount);
            this.groupBox1.Controls.Add(this.lbGrowerCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbStNo);
            this.groupBox1.Controls.Add(this.lbCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 100);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // dpAssignmentDate
            // 
            this.dpAssignmentDate.Checked = false;
            this.dpAssignmentDate.CustomFormat = "dd-MMM-yyyy";
            this.dpAssignmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpAssignmentDate.Location = new System.Drawing.Point(420, 20);
            this.dpAssignmentDate.Name = "dpAssignmentDate";
            this.dpAssignmentDate.ShowCheckBox = true;
            this.dpAssignmentDate.Size = new System.Drawing.Size(128, 20);
            this.dpAssignmentDate.TabIndex = 36;
            // 
            // cbFeesType
            // 
            this.cbFeesType.FormattingEnabled = true;
            this.cbFeesType.Location = new System.Drawing.Point(101, 51);
            this.cbFeesType.Name = "cbFeesType";
            this.cbFeesType.Size = new System.Drawing.Size(153, 21);
            this.cbFeesType.TabIndex = 35;
            // 
            // chBIsActive
            // 
            this.chBIsActive.AutoSize = true;
            this.chBIsActive.Location = new System.Drawing.Point(474, 77);
            this.chBIsActive.Name = "chBIsActive";
            this.chBIsActive.Size = new System.Drawing.Size(74, 17);
            this.chBIsActive.TabIndex = 34;
            this.chBIsActive.Text = "IsOpening";
            this.chBIsActive.UseVisualStyleBackColor = true;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(420, 51);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(128, 20);
            this.tbAmount.TabIndex = 7;
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Location = new System.Drawing.Point(298, 51);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(43, 13);
            this.lbAmount.TabIndex = 6;
            this.lbAmount.Text = "Amount";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvSearch);
            this.groupBox2.Location = new System.Drawing.Point(13, 153);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 280);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Results";
            // 
            // ssSearchSeason
            // 
            this.ssSearchSeason.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSearchAction,
            this.tssRecord});
            this.ssSearchSeason.Location = new System.Drawing.Point(0, 442);
            this.ssSearchSeason.Name = "ssSearchSeason";
            this.ssSearchSeason.Size = new System.Drawing.Size(652, 22);
            this.ssSearchSeason.TabIndex = 26;
            this.ssSearchSeason.Text = "statusStrip1";
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
            // SearchToolBar
            // 
            this.SearchToolBar.Location = new System.Drawing.Point(0, 0);
            this.SearchToolBar.Name = "SearchToolBar";
            this.SearchToolBar.Size = new System.Drawing.Size(80, 28);
            this.SearchToolBar.TabIndex = 27;
            this.SearchToolBar.SeachDetailClicked += new ActionToolBar.SearchToolBar.SeachDetailClickedHandler(this.SearchToolBar_SeachDetailClicked);
            this.SearchToolBar.ClearClicked += new ActionToolBar.SearchToolBar.ClearClickedHandler(this.SearchToolBar_ClearClicked);
            this.SearchToolBar.ShowDetailClicked += new ActionToolBar.SearchToolBar.DetailClickedHandler(this.SearchToolBar_ShowDetailClicked);
            // 
            // SearchFeesOpening
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ssSearchSeason);
            this.Controls.Add(this.SearchToolBar);
            this.Name = "SearchFeesOpening";
            this.Text = "SearchFeesOpening";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ssSearchSeason.ResumeLayout(false);
            this.ssSearchSeason.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.Label lbGrowerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStNo;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.StatusStrip ssSearchSeason;
        private System.Windows.Forms.ToolStripStatusLabel tssSearchAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private ActionToolBar.SearchToolBar SearchToolBar;
        private System.Windows.Forms.CheckBox chBIsActive;
        private System.Windows.Forms.ComboBox cbFeesType;
        private System.Windows.Forms.DateTimePicker dpAssignmentDate;
    }
}