namespace Frontend.Reports.Parameter
{
    partial class FrmAmountWiseParam
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
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.gbSector = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCondition = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbSector.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(335, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 80;
            this.label8.Text = "Amount";
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(128, 35);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(187, 20);
            this.tbAmount.TabIndex = 88;
            // 
            // gbSector
            // 
            this.gbSector.Controls.Add(this.cbCondition);
            this.gbSector.Controls.Add(this.label7);
            this.gbSector.Controls.Add(this.label1);
            this.gbSector.Controls.Add(this.tbAmount);
            this.gbSector.Controls.Add(this.label8);
            this.gbSector.Controls.Add(this.label4);
            this.gbSector.Location = new System.Drawing.Point(66, 59);
            this.gbSector.Name = "gbSector";
            this.gbSector.Size = new System.Drawing.Size(393, 143);
            this.gbSector.TabIndex = 28;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "General Information";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(384, 226);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 29;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 89;
            this.label1.Text = "Condition";
            // 
            // cbCondition
            // 
            this.cbCondition.FormattingEnabled = true;
            this.cbCondition.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbCondition.Location = new System.Drawing.Point(128, 78);
            this.cbCondition.Name = "cbCondition";
            this.cbCondition.Size = new System.Drawing.Size(185, 21);
            this.cbCondition.TabIndex = 91;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(335, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 90;
            this.label7.Text = "*";
            // 
            // FrmAmountWiseParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 261);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gbSector);
            this.Name = "FrmAmountWiseParam";
            this.Text = "FrmAmountWiseParam";
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.GroupBox gbSector;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCondition;
        private System.Windows.Forms.Label label7;

    }
}