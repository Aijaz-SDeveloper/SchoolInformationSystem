using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Frontend.Parameter;
using BusinessLogic;

namespace Frontend
{
    public partial class MainMdi : Form
    {
        public MainMdi()
        {
            InitializeComponent();
        }

      

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Frontend.Parameter.Parameters obj = new Frontend.Parameter.Parameters();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }
        public bool hasReportRights(string _strReportName)
        {
            bool hasRights = false;
            clsSecurity objSecturity = new clsSecurity();
            try
            {
                hasRights = objSecturity.IsActionAllowed(_strReportName, Global.UserId, Constants.Action.Print.GetHashCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hasRights;
        }


        private void studentProfileToolStripMenuItem1_Click(object sender, EventArgs e)
        {

           

            Frontend.Parameter.StudentProfile obj = new StudentProfile();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();

        }

        private void dataBaseBackupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasReportRights("DBBackup"))
            {
                MessageBox.Show(" Sorry ! You don't have rights.", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Frontend.Parameter.DatabaseBackup db = new DatabaseBackup();
            db.MdiParent = this;
            db.MaximizeBox = false;
            db.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainMdi_Load(object sender, EventArgs e)
        {

        }

       

        private void studentSeperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Frontend.Parameter.AcademicYear obj = new AcademicYear();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();

        }

        private void feesOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Frontend.Fees.FeesOpening obj = new Frontend.Fees.FeesOpening();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void claasWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Fees.MonthlyFeesProcess obj = new Frontend.Fees.MonthlyFeesProcess();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void individualToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Frontend.Fees.IndividualFeesProcess obj = new Frontend.Fees.IndividualFeesProcess();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void feesAmendmentAfterFeesProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Frontend.Fees.FeesCollection obj = new Frontend.Fees.FeesCollection();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void challanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Reports.Parameter.frmChallanFees obj = new Frontend.Reports.Parameter.frmChallanFees("RptChallan");

            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void scrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Frontend.Reports.Parameter.FrmScrollParameter obj = new Frontend.Reports.Parameter.FrmScrollParameter("DailyScrollReport");
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void studentLedgerCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Reports.Parameter.LedgerParameter objrpt = new Frontend.Reports.Parameter.LedgerParameter("rptLedgerCard");
            objrpt.Text = "Student Ledger Card";
            objrpt.MdiParent = this;
            objrpt.MaximizeBox = false;
            objrpt.Show();
        }

        private void generalParToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Reports.ReportViewerPopup rptobj = new Frontend.Reports.ReportViewerPopup("rptParamList", null);
            rptobj.ShowDialog();

        }

        private void studentShiftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Parameter.StudentTransfer obj = new StudentTransfer();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();

        }

        private void amountBalanceWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasReportRights("RptAmountBalance"))
            {
                MessageBox.Show(" Sorry ! You don't have rights.", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
         
            Frontend.Reports.Parameter.FrmAmountWiseParam obj = new Frontend.Reports.Parameter.FrmAmountWiseParam();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();

        }

        private void generalParameterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Reports.ReportViewerPopup rptobj = new Frontend.Reports.ReportViewerPopup("rptParamList", null);
            rptobj.ShowDialog();

        }

        private void studentLedgerCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Reports.Parameter.LedgerParameter objrpt = new Frontend.Reports.Parameter.LedgerParameter("rptLedgerCard");
            objrpt.Text = "Student Ledger Card";
            objrpt.MdiParent = this;
            objrpt.MaximizeBox = false;
            objrpt.Show();
        }

        private void studentChallanToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Reports.Parameter.frmChallanFees obj = new Frontend.Reports.Parameter.frmChallanFees("RptChallan");

            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void dailyScrollReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Reports.Parameter.FrmScrollParameter obj = new Frontend.Reports.Parameter.FrmScrollParameter("DailyScrollReport");
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void amoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!hasReportRights("RptAmountBalance"))
            {
                MessageBox.Show(" Sorry ! You don't have rights.", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Frontend.Reports.Parameter.FrmAmountWiseParam obj = new Frontend.Reports.Parameter.FrmAmountWiseParam();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void studentFeesActivityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frontend.Reports.Parameter.FrmScrollParameter obj = new Frontend.Reports.Parameter.FrmScrollParameter("FeesActivityReport");
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void studentProfileHistoryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Frontend.Reports.Parameter.FrmScrollParameter obj = new Frontend.Reports.Parameter.FrmScrollParameter("rptStudentProfileHistory");
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void listOfStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Reports.Parameter.FrmStudentProfileList obj = new Frontend.Reports.Parameter.FrmStudentProfileList("rptStudentProfileList");
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();

        }

        private void contactUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Help.ContactUs obj = new Frontend.Help.ContactUs();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Help.ClientList obj = new Frontend.Help.ClientList();
        
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

        private void developedSoftwareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frontend.Help.DevelopedSystem obj = new Frontend.Help.DevelopedSystem();
            obj.MdiParent = this;
            obj.MaximizeBox = false;
            obj.Show();
        }

       

       

       
       
       
    }
}
