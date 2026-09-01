namespace Frontend.Reports.Parameter
{
    partial class FrmStudentProfileList
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
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbSector = new System.Windows.Forms.GroupBox();
            this.ssDef = new System.Windows.Forms.StatusStrip();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbardef = new ActionToolBar.ToolbarControl();
            this.cbPersonDetail = new System.Windows.Forms.CheckBox();
            this.cbGuardian = new System.Windows.Forms.CheckBox();
            this.cbContact = new System.Windows.Forms.CheckBox();
            this.gbSector.SuspendLayout();
            this.ssDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbClass.Location = new System.Drawing.Point(111, 41);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(200, 21);
            this.cbClass.TabIndex = 83;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Class";
            // 
            // gbSector
            // 
            this.gbSector.Controls.Add(this.cbContact);
            this.gbSector.Controls.Add(this.cbGuardian);
            this.gbSector.Controls.Add(this.cbPersonDetail);
            this.gbSector.Controls.Add(this.label1);
            this.gbSector.Controls.Add(this.cbClass);
            this.gbSector.Location = new System.Drawing.Point(28, 46);
            this.gbSector.Name = "gbSector";
            this.gbSector.Size = new System.Drawing.Size(457, 217);
            this.gbSector.TabIndex = 68;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "General Information";
            // 
            // ssDef
            // 
            this.ssDef.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssDef.Location = new System.Drawing.Point(0, 354);
            this.ssDef.Name = "ssDef";
            this.ssDef.Size = new System.Drawing.Size(581, 22);
            this.ssDef.TabIndex = 67;
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
            // cbardef
            // 
            this.cbardef.Location = new System.Drawing.Point(0, 0);
            this.cbardef.Name = "cbardef";
            this.cbardef.Size = new System.Drawing.Size(60, 27);
            this.cbardef.TabIndex = 66;
            // 
            // cbPersonDetail
            // 
            this.cbPersonDetail.AutoSize = true;
            this.cbPersonDetail.Location = new System.Drawing.Point(111, 91);
            this.cbPersonDetail.Name = "cbPersonDetail";
            this.cbPersonDetail.Size = new System.Drawing.Size(97, 17);
            this.cbPersonDetail.TabIndex = 85;
            this.cbPersonDetail.Text = "Personal Detail";
            this.cbPersonDetail.UseVisualStyleBackColor = true;
            // 
            // cbGuardian
            // 
            this.cbGuardian.AutoSize = true;
            this.cbGuardian.Location = new System.Drawing.Point(111, 129);
            this.cbGuardian.Name = "cbGuardian";
            this.cbGuardian.Size = new System.Drawing.Size(99, 17);
            this.cbGuardian.TabIndex = 86;
            this.cbGuardian.Text = "Guardian Detail";
            this.cbGuardian.UseVisualStyleBackColor = true;
            // 
            // cbContact
            // 
            this.cbContact.AutoSize = true;
            this.cbContact.Location = new System.Drawing.Point(111, 165);
            this.cbContact.Name = "cbContact";
            this.cbContact.Size = new System.Drawing.Size(93, 17);
            this.cbContact.TabIndex = 87;
            this.cbContact.Text = "Contact Detail";
            this.cbContact.UseVisualStyleBackColor = true;
            // 
            // FrmStudentProfileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 376);
            this.Controls.Add(this.gbSector);
            this.Controls.Add(this.ssDef);
            this.Controls.Add(this.cbardef);
            this.Name = "FrmStudentProfileList";
            this.Text = "FrmStudentProfileList";
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.ssDef.ResumeLayout(false);
            this.ssDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbSector;
        private System.Windows.Forms.StatusStrip ssDef;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
        private ActionToolBar.ToolbarControl cbardef;
        private System.Windows.Forms.CheckBox cbGuardian;
        private System.Windows.Forms.CheckBox cbPersonDetail;
        private System.Windows.Forms.CheckBox cbContact;
    }
}