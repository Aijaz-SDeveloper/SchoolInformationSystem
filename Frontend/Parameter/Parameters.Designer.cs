namespace Frontend.Parameter
{
    partial class Parameters
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cbParamType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.ssParam = new System.Windows.Forms.StatusStrip();
            this.tssAction = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssRecord = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbar = new ActionToolBar.ToolbarControl();
            this.ssParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(174, 143);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 20);
            this.txtName.TabIndex = 1;
            // 
            // cbParamType
            // 
            this.cbParamType.FormattingEnabled = true;
            this.cbParamType.Location = new System.Drawing.Point(174, 84);
            this.cbParamType.Name = "cbParamType";
            this.cbParamType.Size = new System.Drawing.Size(173, 21);
            this.cbParamType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Remarks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(372, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "*";
            // 
            // tbRemarks
            // 
            this.tbRemarks.Location = new System.Drawing.Point(174, 223);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.Size = new System.Drawing.Size(444, 156);
            this.tbRemarks.TabIndex = 91;
            // 
            // ssParam
            // 
            this.ssParam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssAction,
            this.tssRecord});
            this.ssParam.Location = new System.Drawing.Point(0, 427);
            this.ssParam.Name = "ssParam";
            this.ssParam.Size = new System.Drawing.Size(658, 22);
            this.ssParam.TabIndex = 93;
            this.ssParam.Text = "statusStrip1";
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
            // cbar
            // 
            this.cbar.Location = new System.Drawing.Point(8, 4);
            this.cbar.Name = "cbar";
            this.cbar.Size = new System.Drawing.Size(274, 25);
            this.cbar.TabIndex = 92;
            this.cbar.SearchClicked += new ActionToolBar.ToolbarControl.SearchClickedHandler(this.cbar_SearchClicked);
            this.cbar.DeleteClicked += new ActionToolBar.ToolbarControl.DeleteClickedHandler(this.cbar_DeleteClicked);
            this.cbar.ApproveClicked += new ActionToolBar.ToolbarControl.ApproveClickedHandler(this.cbar_ApproveClicked);
            this.cbar.SaveClicked += new ActionToolBar.ToolbarControl.SaveClickedHandler(this.cbar_SaveClicked);
            this.cbar.NextClicked += new ActionToolBar.ToolbarControl.NextClickedHandler(this.cbar_NextClicked);
            this.cbar.PreviousClicked += new ActionToolBar.ToolbarControl.PreviousClickedHandler(this.cbar_PreviousClicked);
            this.cbar.LastClicked += new ActionToolBar.ToolbarControl.LastClickedHandler(this.cbar_LastClicked);
            this.cbar.FirstClicked += new ActionToolBar.ToolbarControl.FirstClickedHandler(this.cbar_FirstClicked);
            this.cbar.NewClicked += new ActionToolBar.ToolbarControl.NewClickedHandler(this.cbar_NewClicked);
            this.cbar.AmendClicked += new ActionToolBar.ToolbarControl.AmendClickedHandler(this.cbar_AmendClicked);
            // 
            // Parameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 449);
            this.Controls.Add(this.ssParam);
            this.Controls.Add(this.cbar);
            this.Controls.Add(this.tbRemarks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbParamType);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "Parameters";
            this.Text = "Parameters";
            this.ssParam.ResumeLayout(false);
            this.ssParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbParamType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRemarks;
        private ActionToolBar.ToolbarControl cbar;
        private System.Windows.Forms.StatusStrip ssParam;
        private System.Windows.Forms.ToolStripStatusLabel tssAction;
        private System.Windows.Forms.ToolStripStatusLabel tssRecord;
    }
}