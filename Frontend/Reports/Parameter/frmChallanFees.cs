using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace Frontend.Reports.Parameter
{
    public partial class frmChallanFees : Form
    {
        string report = string.Empty;
        string errorMessage = string.Empty;
        string _Document = string.Empty;

        public frmChallanFees(string _report)
        {
            InitializeComponent();
            ContructorInitialization();
            FillMonth();
            FillYear();
            LoadClass();

            cbMonth.SelectedValue = System.DateTime.Now.Month;
            cbYear.SelectedItem = System.DateTime.Now.Year.ToString();
            
        }
        protected void FillYear()
        {
            clsCommon objCommon = new clsCommon();
            objCommon.FillYear(ref cbYear, 2009, 2100, ref errorMessage);
        }
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";


            cbClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];

        }
        protected void FillMonth()
        {
            string sql = " SELECT 1 as Id,'January' as Description ";

            sql = sql + " union SELECT 2 as Id,'Feburary' as Description ";
            sql = sql + " union SELECT 3 as Id,'March' as Description ";
            sql = sql + " union SELECT 4 as Id,'April' as Description ";
            sql = sql + " union SELECT 5 as Id,'May' as Description ";
            sql = sql + " union SELECT 6 as Id,'June' as Description ";
            sql = sql + " union SELECT 7 as Id,'July' as Description ";
            sql = sql + " union SELECT 8 as Id,'August' as Description ";
            sql = sql + " union SELECT 9 as Id,'September' as Description ";
            sql = sql + " union SELECT 10 as Id,'October' as Description ";
            sql = sql + " union SELECT 11 as Id,'November' as Description ";
            sql = sql + " union SELECT 12 as Id,'December' as Description ";

            cbMonth.DisplayMember = "Description";
            cbMonth.ValueMember = "Id";

            cbMonth.DataSource = new dbSQLHelper().GetDataSet(sql).Tables[0];
        }
        public void ContructorInitialization()
        {
            clsCommon objCommon = new clsCommon();
            try
            {


                this.Text = "Monthly Challan Report";
                _Document = Constants.PRM_MonthlyChallanReport;
               

                cbardef.ActionAllowedOnToolBar(_Document, Global.UserId, true, true, true);
                cbardef.AdjustToolBarButtons(_Document, Global.UserId, Constants.State.New.GetHashCode());

                int[] actionList = {
                                      Constants.Action.Print.GetHashCode() 
                                    
                                  };
                //cbardef.ReorderToolbar(actionList, false);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "", "");

                ////                Form Settings



                this.MaximizeBox = false;
                this.Location = new Point(0, 0);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

                cbFormat.DisplayMember = "Description";
                cbFormat.ValueMember = "Id";


                cbFormat.DataSource = new dbSQLHelper().GetDataSet(" SELECT 1 as Id,'Voucher' Description Union Select 2 as Id,'List' as Description").Tables[0];



            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");
            }
            finally
            {
                objCommon.Dispose();
            }


        }

        private void cbardef_PrintClicked()
        {
            Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
            reportParametersDictionary.Add("Month", this.cbMonth.SelectedValue.ToString());
            reportParametersDictionary.Add("Year", this.cbYear.SelectedItem.ToString());
            reportParametersDictionary.Add("Class", this.cbClass.SelectedValue.ToString());
            reportParametersDictionary.Add("MonthName", this.cbMonth.Text.ToString());
            reportParametersDictionary.Add("Format", this.cbFormat.Text.ToString());
            
            Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("MonthlyChallanReport", reportParametersDictionary);
            obj.ShowDialog();
        }
    }
}
