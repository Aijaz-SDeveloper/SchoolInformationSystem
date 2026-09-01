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
    public partial class FrmScrollParameter : Form
    {
        string report = string.Empty;
        string errorMessage = string.Empty;
        string _Document = string.Empty;
        clsCommon objCommon = new clsCommon();
           

        public FrmScrollParameter(string _report)
        {
            report = _report;
            InitializeComponent();
            ContructorInitialization();
            LoadClass();
            

           
            
        }
        public void ContructorInitialization()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                if (report == "FeesActivityReport")
                {
                    label2.Visible = true;
                    label3.Visible = true;
                    tbGRNo.Visible = true;


                    label1.Visible = false;
                    cbClass.Visible = false;

                    this.Text = "Fees Activity Report";
                    _Document = Constants.PRM_FeesActivityReport;
               

                }
                if (report == "rptStudentProfileHistory")
                {
                    label2.Visible = true;
                    label3.Visible = true;
                    tbGRNo.Visible = true;
                    label8.Visible = false;
                    dpFromDate.Visible = false;
                    label4.Visible = false;
                    label9.Visible = false;
                    dpToDate.Visible = false;
                    label7.Visible = false;

                    label1.Visible = false;
                    cbClass.Visible = false;

                    this.Text = "Student Profile History Parameter";
                    _Document = Constants.PRM_rptStudentProfileHistory;


                }
                if (report == "DailyScrollReport")
                {
                   
                  
                    this.Text = "Daily Scroll Report";
                     _Document = Constants.PRM_DailyScrollReport;

                }

                
               

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
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";


            cbClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];

        }

        private void cbardef_PrintClicked()
        {
            if (report == "DailyScrollReport")
            {
                Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
                reportParametersDictionary.Add("FromDate", this.dpFromDate.Value.ToString("dd-MMM-yyyy"));
                reportParametersDictionary.Add("ToDate", this.dpToDate.Value.ToString("dd-MMM-yyyy"));
                reportParametersDictionary.Add("Class", this.cbClass.SelectedValue.ToString());

                Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("DailyScrollReport", reportParametersDictionary);
                obj.ShowDialog();
            }
            if (report == "FeesActivityReport")
            {
                Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
                reportParametersDictionary.Add("FromDate", this.dpFromDate.Value.ToString("dd-MMM-yyyy"));
                reportParametersDictionary.Add("ToDate", this.dpToDate.Value.ToString("dd-MMM-yyyy"));
                reportParametersDictionary.Add("StudentNo", tbGRNo.Text.Trim());

                Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("FeesActivityReport", reportParametersDictionary);
                obj.ShowDialog();
            }
            if (report == "rptStudentProfileHistory")
            {
                Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
                 reportParametersDictionary.Add("StudentNo", tbGRNo.Text.Trim());

                 Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("rptStudentProfileHistory", reportParametersDictionary);
                obj.ShowDialog();
            }
        }

      
    }
}
