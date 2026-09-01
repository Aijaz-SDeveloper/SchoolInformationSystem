namespace Frontend.Parameter.SearchForm
{
    partial class SearchParametrs
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
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.ssSearchParam = new System.Windows.Forms.StatusStrip();
            this.tssSearchAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbParamType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbCode = new System.Windows.Forms.Label();
            this.SearchToolBar = new ActionToolBar.SearchToolBar();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.ssSearchParam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvSearch);
            this.groupBox2.Location = new System.Drawing.Point(11, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 280);
            this.groupBox2.TabIndex = 17;
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
            // ssSearchParam
            // 
            this.ssSearchParam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssSearchAction,
            this.tssRecord});
            this.ssSearchParam.Location = new System.Drawing.Point(0, 406);
            this.ssSearchParam.Name = "ssSearchParam";
            this.ssSearchParam.Size = new System.Drawing.Size(651, 22);
            this.ssSearchParam.TabIndex = 18;
            this.ssSearchParam.Text = "statusStrip1";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbParamType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.lbCode);
            this.groupBox1.Location = new System.Drawing.Point(10, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 74);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // cbParamType
            // 
            this.cbParamType.FormattingEnabled = true;
            this.cbParamType.Location = new System.Drawing.Point(406, 31);
            this.cbParamType.Name = "cbParamType";
            this.cbParamType.Size = new System.Drawing.Size(163, 21);
            this.cbParamType.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(299, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Parameter Type";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(97, 32);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(153, 20);
            this.tbName.TabIndex = 1;
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Location = new System.Drawing.Point(20, 35);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(35, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Name";
            // 
            // SearchToolBar
            // 
            this.SearchToolBar.Location = new System.Drawing.Point(7, 7);
            this.SearchToolBar.Name = "SearchToolBar";
            this.SearchToolBar.Size = new System.Drawing.Size(90, 28);
            this.SearchToolBar.TabIndex = 19;
            this.SearchToolBar.SeachDetailClicked += new ActionToolBar.SearchToolBar.SeachDetailClickedHandler(this.SearchToolBar_SeachDetailClicked);
            this.SearchToolBar.ClearClicked += new ActionToolBar.SearchToolBar.ClearClickedHandler(this.SearchToolBar_ClearClicked);
            this.SearchToolBar.ShowDetailClicked += new ActionToolBar.SearchToolBar.DetailClickedHandler(this.SearchToolBar_ShowDetailClicked);
            // 
            // SearchParametrs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 428);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ssSearchParam);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchToolBar);
            this.Name = "SearchParametrs";
            this.Text = "SearchParametrs";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ssSearchParam.ResumeLayout(false);
            this.ssSearchParam.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.StatusStrip ssSearchParam;
        private System.Windows.Forms.ToolStripStatusLabel tssSearchAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbParamType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbCode;
        private ActionToolBar.SearchToolBar SearchToolBar;

    }
}