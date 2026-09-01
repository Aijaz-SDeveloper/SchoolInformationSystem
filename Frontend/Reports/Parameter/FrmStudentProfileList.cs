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
    public partial class FrmStudentProfileList : Form
    {
        string report = string.Empty;
        string errorMessage = string.Empty;
        string _Document = string.Empty;
        clsCommon objCommon = new clsCommon();

        public FrmStudentProfileList(string _report)
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
               
                    this.Text = "List Of Student Profile Report";
                    _Document = Constants.PRM_rptStudentProfileList;



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

    }
}
