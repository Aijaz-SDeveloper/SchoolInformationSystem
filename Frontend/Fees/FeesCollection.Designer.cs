namespace Frontend.Fees
{
    partial class FeesCollection
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
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCode = new System.Windows.Forms.Label();
            this.PK = new System.Windows.Forms.Label();
            this.lbGrowerContractorName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gb = new System.Windows.Forms.GroupBox();
            this.lbBalanceAmount = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.tbOpeningAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpOpeningDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStudent = new System.Windows.Forms.TextBox();
            this.lblContractorGrower = new System.Windows.Forms.Label();
            this.cbardef = new ActionToolBar.ToolbarControl();
            this.ssDef.SuspendLayout();
            this.gb.SuspendLayout();
            this.SuspendLayout();
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
            this.ssDef.Location = new System.Drawing.Point(0, 435);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(612, 22);
            this.ssDef.TabIndex = 23;
            this.ssDef.Text = "statusStrip1";
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
            this.lbCode.Location = new System.Drawing.Point(334, 34);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(0, 15);
            this.lbCode.TabIndex = 24;
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
            // lbGrowerContractorName
            // 
            this.lbGrowerContractorName.AutoSize = true;
            this.lbGrowerContractorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGrowerContractorName.Location = new System.Drawing.Point(315, 62);
            this.lbGrowerContractorName.Name = "lbGrowerContractorName";
            this.lbGrowerContractorName.Size = new System.Drawing.Size(0, 13);
            this.lbGrowerContractorName.TabIndex = 69;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(273, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "*";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.lbBalanceAmount);
            this.gb.Controls.Add(this.txtDescription);
            this.gb.Controls.Add(this.label4);
            this.gb.Controls.Add(this.PK);
            this.gb.Controls.Add(this.lbGrowerContractorName);
            this.gb.Controls.Add(this.btnSelect);
            this.gb.Controls.Add(this.label3);
            this.gb.Controls.Add(this.tbOpeningAmount);
            this.gb.Controls.Add(this.label6);
            this.gb.Controls.Add(this.dpOpeningDate);
            this.gb.Controls.Add(this.label8);
            this.gb.Controls.Add(this.label1);
            this.gb.Controls.Add(this.label5);
            this.gb.Controls.Add(this.tbStudent);
            this.gb.Controls.Add(this.lblContractorGrower);
            this.gb.Location = new System.Drawing.Point(20, 50);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(550, 341);
            this.gb.TabIndex = 22;
            this.gb.TabStop = false;
            this.gb.Text = "General Information";
            // 
            // lbBalanceAmount
            // 
            this.lbBalanceAmount.AutoSize = true;
            this.lbBalanceAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBalanceAmount.Location = new System.Drawing.Point(426, 73);
            this.lbBalanceAmount.Name = "lbBalanceAmount";
            this.lbBalanceAmount.Size = new System.Drawing.Size(53, 13);
            this.lbBalanceAmount.TabIndex = 76;
            this.lbBalanceAmount.Text = "Balance";
            this.lbBalanceAmount.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(119, 230);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(306, 76);
            this.txtDescription.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Narration";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(276, 37);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(29, 23);
            this.btnSelect.TabIndex = 67;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // tbOpeningAmount
            // 
            this.tbOpeningAmount.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbOpeningAmount.Location = new System.Drawing.Point(124, 166);
            this.tbOpeningAmount.MaxLength = 20;
            this.tbOpeningAmount.Name = "tbOpeningAmount";
            this.tbOpeningAmount.Size = new System.Drawing.Size(131, 20);
            this.tbOpeningAmount.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "Amount";
            // 
            // dpOpeningDate
            // 
            this.dpOpeningDate.Location = new System.Drawing.Point(124, 101);
            this.dpOpeningDate.Name = "dpOpeningDate";
            this.dpOpeningDate.Size = new System.Drawing.Size(200, 20);
            this.dpOpeningDate.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 45;
            this.label8.Text = "Paid Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(365, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(12, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(365, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "*";
            // 
            // tbStudent
            // 
            this.tbStudent.Location = new System.Drawing.Point(124, 39);
            this.tbStudent.MaxLength = 1000;
            this.tbStudent.Name = "tbStudent";
            this.tbStudent.Size = new System.Drawing.Size(131, 20);
            this.tbStudent.TabIndex = 4;
            this.tbStudent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbStudent_KeyPress);
            // 
            // lblContractorGrower
            // 
            this.lblContractorGrower.AutoSize = true;
            this.lblContractorGrower.Location = new System.Drawing.Point(24, 46);
            this.lblContractorGrower.Name = "lblContractorGrower";
            this.lblContractorGrower.Size = new System.Drawing.Size(44, 13);
            this.lblContractorGrower.TabIndex = 1;
            this.lblContractorGrower.Text = "Student";
            // 
            // cbardef
            // 
            this.cbardef.Location = new System.Drawing.Point(2, 0);
            this.cbardef.Name = "cbardef";
            this.cbardef.Size = new System.Drawing.Size(280, 31);
            this.cbardef.TabIndex = 25;
            this.cbardef.SearchClicked += new ActionToolBar.ToolbarControl.SearchClickedHandler(this.cbardef_SearchClicked);
            this.cbardef.DeleteClicked += new ActionToolBar.ToolbarControl.DeleteClickedHandler(this.cbardef_DeleteClicked);
            this.cbardef.ApproveClicked += new ActionToolBar.ToolbarControl.ApproveClickedHandler(this.cbardef_ApproveClicked);
            this.cbardef.SaveClicked += new ActionToolBar.ToolbarControl.SaveClickedHandler(this.cbardef_SaveClicked);
            this.cbardef.NextClicked += new ActionToolBar.ToolbarControl.NextClickedHandler(this.cbardef_NextClicked);
            this.cbardef.PreviousClicked += new ActionToolBar.ToolbarControl.PreviousClickedHandler(this.cbardef_PreviousClicked);
            this.cbardef.LastClicked += new ActionToolBar.ToolbarControl.LastClickedHandler(this.cbardef_LastClicked);
            this.cbardef.FirstClicked += new ActionToolBar.ToolbarControl.FirstClickedHandler(this.cbardef_FirstClicked);
            this.cbardef.NewClicked += new ActionToolBar.ToolbarControl.NewClickedHandler(this.cbardef_NewClicked);
            this.cbardef.AmendClicked += new ActionToolBar.ToolbarControl.AmendClickedHandler(this.cbardef_AmendClicked);
            // 
            // FeesCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 457);
            this.Controls.Add(this.ssDef);
            this.Controls.Add(this.lbCode);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.cbardef);
            this.Name = "FeesCollection";
            this.Text = "FeesCollection";
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            this.gb.ResumeLayout(false);
            this.gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.StatusStrip ssDef;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.Label PK;
        private System.Windows.Forms.Label lbGrowerContractorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.TextBox tbOpeningAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpOpeningDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStudent;
        private System.Windows.Forms.Label lblContractorGrower;
        private ActionToolBar.ToolbarControl cbardef;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbBalanceAmount;
    }
}