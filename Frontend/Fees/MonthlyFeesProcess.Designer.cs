namespace Frontend.Fees
{
    partial class MonthlyFeesProcess
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
            this.gbCriteria = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbFees = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dpLastDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.gvSearch = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.gbCriteria.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ssDef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCriteria
            // 
            this.gbCriteria.Controls.Add(this.tbAmount);
            this.gbCriteria.Controls.Add(this.label10);
            this.gbCriteria.Controls.Add(this.tbDescription);
            this.gbCriteria.Controls.Add(this.label1);
            this.gbCriteria.Controls.Add(this.label6);
            this.gbCriteria.Controls.Add(this.cbFees);
            this.gbCriteria.Controls.Add(this.btnPrint);
            this.gbCriteria.Controls.Add(this.btnGenerate);
            this.gbCriteria.Controls.Add(this.btnLoad);
            this.gbCriteria.Controls.Add(this.dpLastDate);
            this.gbCriteria.Controls.Add(this.label5);
            this.gbCriteria.Controls.Add(this.label2);
            this.gbCriteria.Controls.Add(this.cbClass);
            this.gbCriteria.Controls.Add(this.label3);
            this.gbCriteria.Controls.Add(this.label9);
            this.gbCriteria.Controls.Add(this.cbYear);
            this.gbCriteria.Controls.Add(this.label8);
            this.gbCriteria.Controls.Add(this.cbMonth);
            this.gbCriteria.Controls.Add(this.label4);
            this.gbCriteria.Controls.Add(this.label7);
            this.gbCriteria.Location = new System.Drawing.Point(14, 16);
            this.gbCriteria.Name = "gbCriteria";
            this.gbCriteria.Size = new System.Drawing.Size(667, 170);
            this.gbCriteria.TabIndex = 24;
            this.gbCriteria.TabStop = false;
            this.gbCriteria.Text = "Search Criteria";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(452, 106);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(185, 20);
            this.tbDescription.TabIndex = 96;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(343, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 95;
            this.label1.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 94;
            this.label6.Text = "Fees Type";
            // 
            // cbFees
            // 
            this.cbFees.FormattingEnabled = true;
            this.cbFees.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbFees.Location = new System.Drawing.Point(452, 70);
            this.cbFees.Name = "cbFees";
            this.cbFees.Size = new System.Drawing.Size(185, 21);
            this.cbFees.TabIndex = 93;
            
            this.cbFees.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(481, 141);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 92;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(580, 141);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 91;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(400, 141);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 90;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dpLastDate
            // 
            this.dpLastDate.Location = new System.Drawing.Point(128, 113);
            this.dpLastDate.Name = "dpLastDate";
            this.dpLastDate.Size = new System.Drawing.Size(185, 20);
            this.dpLastDate.TabIndex = 89;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 88;
            this.label5.Text = "Last Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Class";
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbClass.Location = new System.Drawing.Point(128, 62);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(185, 21);
            this.cbClass.TabIndex = 86;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(319, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 85;
            this.label3.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(343, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "Year";
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbYear.Location = new System.Drawing.Point(452, 19);
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
            this.label4.Location = new System.Drawing.Point(319, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(643, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "*";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ssDef);
            this.groupBox2.Controls.Add(this.gvSearch);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 313);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Results";
            // 
            // ssDef
            // 
            this.ssDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssDef.Location = new System.Drawing.Point(3, 288);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(663, 22);
            this.ssDef.TabIndex = 12;
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
            // gvSearch
            // 
            this.gvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSearch.Location = new System.Drawing.Point(13, 19);
            this.gvSearch.Name = "gvSearch";
            this.gvSearch.Size = new System.Drawing.Size(644, 271);
            this.gvSearch.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 97;
            this.label10.Text = "Amount";
            this.label10.Visible = false;
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(128, 143);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(185, 20);
            this.tbAmount.TabIndex = 98;
            this.tbAmount.Visible = false;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // MonthlyFeesProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 516);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbCriteria);
            this.Name = "MonthlyFeesProcess";
            this.Text = "Class Wise Fees Process";
            this.gbCriteria.ResumeLayout(false);
            this.gbCriteria.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriteria;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dpLastDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView gvSearch;
        private System.Windows.Forms.StatusStrip ssDef;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbFees;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label10;
    }
}