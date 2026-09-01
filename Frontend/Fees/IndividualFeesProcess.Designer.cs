namespace Frontend.Fees
{
    partial class IndividualFeesProcess
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
            this.label15 = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.PK = new System.Windows.Forms.Label();
            this.lblAdvance = new System.Windows.Forms.Label();
            this.lbGrowerContractorName = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbOpeningAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpOpeningDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFeesType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbStudent = new System.Windows.Forms.TextBox();
            this.lblContractorGrower = new System.Windows.Forms.Label();
            this.lblLoan = new System.Windows.Forms.Label();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCode = new System.Windows.Forms.Label();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.cbardef = new ActionToolBar.ToolbarControl();
            this.gb.SuspendLayout();
            this.ssDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 329);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 85;
            this.label15.Text = "Description";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.label10);
            this.gb.Controls.Add(this.label9);
            this.gb.Controls.Add(this.cbYear);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.cbMonth);
            this.gb.Controls.Add(this.label2);
            this.gb.Controls.Add(this.label15);
            this.gb.Controls.Add(this.txtDescription);
            this.gb.Controls.Add(this.PK);
            this.gb.Controls.Add(this.lblAdvance);
            this.gb.Controls.Add(this.lbGrowerContractorName);
            this.gb.Controls.Add(this.btnSelect);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.tbOpeningAmount);
            this.gb.Controls.Add(this.label6);
            this.gb.Controls.Add(this.dpOpeningDate);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.cbFeesType);
            this.gb.Controls.Add(this.label5);
            this.gb.Controls.Add(this.label7);
            this.gb.Controls.Add(this.tbStudent);
            this.gb.Controls.Add(this.lblContractorGrower);
            this.gb.Controls.Add(this.lblLoan);
            this.gb.Location = new System.Drawing.Point(13, 50);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(550, 366);
            this.gb.TabIndex = 18;
            this.gb.TabStop = false;
            this.gb.Text = "General Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(365, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 13);
            this.label10.TabIndex = 91;
            this.label10.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(365, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 13);
            this.label9.TabIndex = 90;
            this.label9.Text = "*";
            // 
            // cbYear
            // 
            this.cbYear.DisplayMember = "Code";
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(124, 129);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(143, 21);
            this.cbYear.TabIndex = 89;
            this.cbYear.ValueMember = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 88;
            this.label4.Text = "Year";
            // 
            // cbMonth
            // 
            this.cbMonth.DisplayMember = "Code";
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(124, 82);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(143, 21);
            this.cbMonth.TabIndex = 87;
            this.cbMonth.ValueMember = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Month";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(124, 322);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(420, 20);
            this.txtDescription.TabIndex = 84;
            // 
            // PK
            // 
            this.PK.AutoSize = true;
            this.PK.Location = new System.Drawing.Point(448, 60);
            this.PK.Name = "PK";
            this.PK.Size = new System.Drawing.Size(31, 13);
            this.PK.TabIndex = 71;
            this.PK.Text = "lblPK";
            this.PK.Visible = false;
            // 
            // lblAdvance
            // 
            this.lblAdvance.AutoSize = true;
            this.lblAdvance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvance.Location = new System.Drawing.Point(409, 187);
            this.lblAdvance.Name = "lblAdvance";
            this.lblAdvance.Size = new System.Drawing.Size(70, 13);
            this.lblAdvance.TabIndex = 70;
            this.lblAdvance.Text = "lblAdvance";
            this.lblAdvance.Visible = false;
            // 
            // lbGrowerContractorName
            // 
            this.lbGrowerContractorName.AutoSize = true;
            this.lbGrowerContractorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGrowerContractorName.Location = new System.Drawing.Point(315, 62);
            this.lbGrowerContractorName.Name = "lbGrowerContractorName";
            this.lbGrowerContractorName.Size = new System.Drawing.Size(0, 13);
            this.lbGrowerContractorName.TabIndex = 69;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(276, 177);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(29, 23);
            this.btnSelect.TabIndex = 67;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "*";
            // 
            // tbOpeningAmount
            // 
            this.tbOpeningAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbOpeningAmount.Location = new System.Drawing.Point(124, 281);
            this.tbOpeningAmount.MaxLength = 20;
            this.tbOpeningAmount.Name = "tbOpeningAmount";
            this.tbOpeningAmount.Size = new System.Drawing.Size(131, 20);
            this.tbOpeningAmount.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Amount";
            // 
            // dpOpeningDate
            // 
            this.dpOpeningDate.Location = new System.Drawing.Point(124, 225);
            this.dpOpeningDate.Name = "dpOpeningDate";
            this.dpOpeningDate.Size = new System.Drawing.Size(200, 20);
            this.dpOpeningDate.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "*";
            // 
            // cbFeesType
            // 
            this.cbFeesType.DisplayMember = "Code";
            this.cbFeesType.FormattingEnabled = true;
            this.cbFeesType.Location = new System.Drawing.Point(124, 29);
            this.cbFeesType.Name = "cbFeesType";
            this.cbFeesType.Size = new System.Drawing.Size(235, 21);
            this.cbFeesType.TabIndex = 43;
            this.cbFeesType.ValueMember = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(365, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "*";
            // 
            // tbStudent
            // 
            this.tbStudent.Location = new System.Drawing.Point(124, 179);
            this.tbStudent.MaxLength = 1000;
            this.tbStudent.Name = "tbStudent";
            this.tbStudent.Size = new System.Drawing.Size(131, 20);
            this.tbStudent.TabIndex = 4;
            this.tbStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStudent_KeyPress);
            // 
            // lblContractorGrower
            // 
            this.lblContractorGrower.AutoSize = true;
            this.lblContractorGrower.Location = new System.Drawing.Point(24, 186);
            this.lblContractorGrower.Name = "lblContractorGrower";
            this.lblContractorGrower.Size = new System.Drawing.Size(44, 13);
            this.lblContractorGrower.TabIndex = 1;
            this.lblContractorGrower.Text = "Student";
            // 
            // lblLoan
            // 
            this.lblLoan.AutoSize = true;
            this.lblLoan.Location = new System.Drawing.Point(22, 37);
            this.lblLoan.Name = "lblLoan";
            this.lblLoan.Size = new System.Drawing.Size(57, 13);
            this.lblLoan.TabIndex = 0;
            this.lblLoan.Text = "Fees Type";
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
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCode.Location = new System.Drawing.Point(350, 34);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(0, 15);
            this.lbCode.TabIndex = 20;
            // 
            // ssDef
            // 
            this.ssDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssDef.Location = new System.Drawing.Point(0, 427);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(628, 22);
            this.ssDef.TabIndex = 19;
            this.ssDef.Text = "statusStrip1";
            // 
            // cbardef
            // 
            this.cbardef.Location = new System.Drawing.Point(0, 0);
            this.cbardef.Name = "cbardef";
            this.cbardef.Size = new System.Drawing.Size(280, 31);
            this.cbardef.TabIndex = 21;
            this.cbardef.SearchClicked += new ActionToolBar.ToolbarControl.SearchClickedHandler(this.cbardef_SearchClicked);
            this.cbardef.DeleteClicked += new ActionToolBar.ToolbarControl.DeleteClickedHandler(this.cbardef_DeleteClicked);
            this.cbardef.ApproveClicked += new ActionToolBar.ToolbarControl.ApproveClickedHandler(this.cbardef_ApproveClicked);
            this.cbardef.PrintClicked += new ActionToolBar.ToolbarControl.PrintClickedHandler(this.cbardef_PrintClicked);
            this.cbardef.SaveClicked += new ActionToolBar.ToolbarControl.SaveClickedHandler(this.cbardef_SaveClicked);
            this.cbardef.NextClicked += new ActionToolBar.ToolbarControl.NextClickedHandler(this.cbardef_NextClicked);
            this.cbardef.PreviousClicked += new ActionToolBar.ToolbarControl.PreviousClickedHandler(this.cbardef_PreviousClicked);
            this.cbardef.LastClicked += new ActionToolBar.ToolbarControl.LastClickedHandler(this.cbardef_LastClicked);
            this.cbardef.FirstClicked += new ActionToolBar.ToolbarControl.FirstClickedHandler(this.cbardef_FirstClicked);
            this.cbardef.NewClicked += new ActionToolBar.ToolbarControl.NewClickedHandler(this.cbardef_NewClicked);
            this.cbardef.AmendClicked += new ActionToolBar.ToolbarControl.AmendClickedHandler(this.cbardef_AmendClicked);
            // 
            // IndividualFeesProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 449);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.lbCode);
            this.Controls.Add(this.ssDef);
            this.Controls.Add(this.cbardef);
            this.Name = "IndividualFeesProcess";
            this.Text = "IndividualFeesProcess";
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label PK;
        private System.Windows.Forms.Label lblAdvance;
        private System.Windows.Forms.Label lbGrowerContractorName;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOpeningAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpOpeningDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFeesType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStudent;
        private System.Windows.Forms.Label lblContractorGrower;
        private System.Windows.Forms.Label lblLoan;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.StatusStrip ssDef;
        private ActionToolBar.ToolbarControl cbardef;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}