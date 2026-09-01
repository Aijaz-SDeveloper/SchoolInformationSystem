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
    public partial class LedgerParameter : Form
    {
        string report = string.Empty;
        string errorMessage = string.Empty;
        string _Document = string.Empty;

        public LedgerParameter(string _report)
        {
            InitializeComponent();
            report = _report;
            ContructorInitialization();
            

           
        }
        public void ContructorInitialization()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                this.Text = "Student LedgerCard";
                _Document = Constants.PRM_LEDGERCARD;


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

               

                string strYear = "select 0 as Id, '--Current Year--' as YearName  union select Id, YearName  from YearDefination where currentstatusid =13";

                 objCommon.FillCombo(ref  cbYear, ref strYear, "YearName", "Id");

              
                
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                //objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");
            }
            finally
            {
                objCommon.Dispose();
            }


        }

        private void cbardef_PrintClicked()
        {
            Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
            if (report == "rptLedgerCard")
            {
                reportParametersDictionary.Clear();
                

                reportParametersDictionary.Add("StudentNo", tbGRNo.Text.Trim());
                reportParametersDictionary.Add("YearId", this.cbYear.SelectedValue.ToString());
          

                Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("rptLedgerCard", reportParametersDictionary);  /// change report name

                obj.ShowDialog();
            }
        }

    }
}
