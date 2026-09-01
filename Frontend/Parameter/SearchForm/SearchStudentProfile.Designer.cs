namespace Frontend.Parameter.SearchForm
{
    partial class SearchStudentProfile
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
            this.SearchToolBar = new ActionToolBar.SearchToolBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chBIsActive = new System.Windows.Forms.CheckBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.tbCnic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStNo = new System.Windows.Forms.TextBox();
            this.lbCode = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.ssSearchParam = new System.Windows.Forms.StatusStrip();
            this.tssSearchAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.ssSearchParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchToolBar
            // 
            this.SearchToolBar.Location = new System.Drawing.Point(3, 3);
            this.SearchToolBar.Name = "SearchToolBar";
            this.SearchToolBar.Size = new System.Drawing.Size(94, 28);
            this.SearchToolBar.TabIndex = 20;
            this.SearchToolBar.SeachDetailClicked += new ActionToolBar.SearchToolBar.SeachDetailClickedHandler(this.SearchToolBar_SeachDetailClicked);
            this.SearchToolBar.ClearClicked += new ActionToolBar.SearchToolBar.ClearClickedHandler(this.SearchToolBar_ClearClicked);
            this.SearchToolBar.ShowDetailClicked += new ActionToolBar.SearchToolBar.DetailClickedHandler(this.SearchToolBar_ShowDetailClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chBIsActive);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.cbClass);
            this.groupBox1.Controls.Add(this.tbCnic);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbStNo);
            this.groupBox1.Controls.Add(this.lbCode);
            this.groupBox1.Location = new System.Drawing.Point(6, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 107);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Criteria";
            // 
            // chBIsActive
            // 
            this.chBIsActive.AutoSize = true;
            this.chBIsActive.Checked = true;
            this.chBIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBIsActive.Location = new System.Drawing.Point(509, 78);
            this.chBIsActive.Name = "chBIsActive";
            this.chBIsActive.Size = new System.Drawing.Size(64, 17);
            this.chBIsActive.TabIndex = 33;
            this.chBIsActive.Text = "IsActive";
            this.chBIsActive.UseVisualStyleBackColor = true;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(420, 20);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(153, 20);
            this.tbName.TabIndex = 32;
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(420, 51);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(153, 21);
            this.cbClass.TabIndex = 31;
            // 
            // tbCnic
            // 
            this.tbCnic.Location = new System.Drawing.Point(101, 48);
            this.tbCnic.Name = "tbCnic";
            this.tbCnic.Size = new System.Drawing.Size(153, 20);
            this.tbCnic.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(326, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "CNIC No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(326, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Student Name";
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
            this.lbCode.Location = new System.Drawing.Point(20, 23);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(61, 13);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Student No";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gvSearch);
            this.groupBox2.Location = new System.Drawing.Point(11, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 280);
            this.groupBox2.TabIndex = 22;
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
            this.ssSearchParam.Location = new System.Drawing.Point(0, 445);
            this.ssSearchParam.Name = "ssSearchParam";
            this.ssSearchParam.Size = new System.Drawing.Size(603, 22);
            this.ssSearchParam.TabIndex = 23;
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
            // SearchStudentProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 467);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ssSearchParam);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.SearchToolBar);
            this.Name = "SearchStudentProfile";
            this.Text = "SearchStudentProfile";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ssSearchParam.ResumeLayout(false);
            this.ssSearchParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ActionToolBar.SearchToolBar SearchToolBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.TextBox tbCnic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStNo;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.CheckBox chBIsActive;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.StatusStrip ssSearchParam;
        private System.Windows.Forms.ToolStripStatusLabel tssSearchAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
    }
}