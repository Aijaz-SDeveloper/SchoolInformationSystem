using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using Frontend.DBML;

namespace Frontend.Fees
{
    public partial class IndividualFeesProcess : Form
    {
        long _PrimaryKeyMain = 0;


        bool _isNewRecord = true;
        string errorMessage = string.Empty;
        bool _isAnyFieldChanged = false;
        int _CurrentAction = Constants.Action.Save.GetHashCode();
        int _CurrentStatus = Constants.State.New.GetHashCode();
        clsCommon objCommon = new clsCommon();

        long _GrowerContractorId = 0;

        private int currentRecIndex;
        private int totalSearchRecords;
        private string searchQuery = string.Empty;
        private DataSet dsSearchResults = new DataSet();

        private List<clsSearchParameter> parentPageSearchList = new List<clsSearchParameter>();
        private List<clsSearchParameter> parentPageSearchList2 = new List<clsSearchParameter>();
        public IndividualFeesProcess()
        {
            InitializeComponent();
            LoadFeesType();
            FeeInitialization();
            FillMonth();
            FillYear();
            cbMonth.SelectedValue = System.DateTime.Now.Month;
            cbYear.SelectedItem = System.DateTime.Now.Year.ToString();
            
        }
        protected void FillYear()
        {


            objCommon.FillYear(ref cbYear, 2018, 2100, ref errorMessage);

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
        public void FeeInitialization()
        {
            clsCommon objCommon = new clsCommon();

            try
            {
                cbardef.ActionAllowedOnToolBar(Constants.PRM_OpeningFees, Frontend.Common.Global.UserId, true, true);
                cbardef.AdjustToolBarButtons(Constants.PRM_OpeningFees, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());

                int[] actionList = {
                                      Constants.Action.Save.GetHashCode(), 
                                      Constants.Action.Approve.GetHashCode(),                                       
                                      Constants.Action.Delete.GetHashCode(), 
                                      Constants.Action.Amend.GetHashCode(), 
                                      Constants.Action.Search.GetHashCode(), 
                                  };
                cbardef.ReorderToolbar(actionList, false, Constants.PRM_OpeningFees, Frontend.Common.Global.UserId);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");

                ////                Form Settings


                this.Text = "Individual Fees Process";
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
        public void LoadFeesType()
        {
            cbFeesType.DisplayMember = "Description";
            cbFeesType.ValueMember = "Id";


            cbFeesType.DataSource = new dbSQLHelper().GetDataSet(" Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type in (12) and Id <> 68").Tables[0];

        }
        private void DisplayCode(long Id, bool _isByCode, string code)
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            DataSet dataSet = null;
            try
            {
                string sSQL = string.Empty;
                if (Id == 0)
                {
                    sSQL = " Select Id,Name from dbo.Student_Profile where Id = " + code + "";
                }
                else
                {
                    sSQL = " Select Id,Name from dbo.Student_Profile where Id = " + Id + "";
                }
                dataSet = (DataSet)objDBHelper.GetDataSet(sSQL);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    //tbContractorGrower.Text = dataSet.Tables[0].Rows[0]["Code"].ToString();
                    lbGrowerContractorName.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();
                    tbStudent.Text = dataSet.Tables[0].Rows[0]["Id"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDBHelper.Dispose();
            }

        }

        private void tbStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                DisplayCode(0, true, tbStudent.Text.Trim());
            }
        }
       

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Frontend.Parameter.SearchForm.SearchStudentProfile objfrmSearch = new Frontend.Parameter.SearchForm.SearchStudentProfile(parentPageSearchList2, "OpeningForm");
            objfrmSearch.ShowDialog();
            if (objfrmSearch.selectedRecordId != -1)
            {
                DisplayCode(objfrmSearch.selectedRecordId, false, "");
            }

        }
        protected void NewRecord()
        {
            clsCommon objCommon = new clsCommon();
            try
            {

                this.tbStudent.Text = string.Empty;
                this.lbGrowerContractorName.Text = string.Empty;
                this.tbOpeningAmount.Text = string.Empty;
                this.lblAdvance.Text = string.Empty;

                this.txtDescription.Text = string.Empty;
               
                cbFeesType.SelectedIndex = 0;
                this.dpOpeningDate.Text = DateTime.Now.ToShortTimeString();
                _PrimaryKeyMain = 0;
                _GrowerContractorId = 0;
                _isNewRecord = true;
                _isAnyFieldChanged = false;
                cbMonth.SelectedValue = System.DateTime.Now.Month;
                cbYear.SelectedItem = System.DateTime.Now.Year.ToString();
            

                _CurrentAction = Constants.Action.Save.GetHashCode();
                _CurrentStatus = Constants.State.New.GetHashCode();
                cbFeesType.Focus();
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");
                cbardef.AdjustToolBarButtons(Constants.PRM_OpeningFees, Global.UserId, Constants.State.New.GetHashCode());

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objCommon.Dispose();
            }
        }

        private void cbardef_NewClicked()
        {
            try
            {
                NewRecord();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        protected bool IsValidInformation()
        {
            bool isValidInput = true;
            errorMessage = string.Empty;
            try
            {

                if (cbFeesType.SelectedIndex == 0)

                    errorMessage = "Data can not be saved due to following reasons.\r\rFee Type is missing.";

                if (tbStudent.Text == string.Empty)
                {

                    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rStudent is missing." : errorMessage + "\rStudent is missing.";
                }

                if (tbOpeningAmount.Text == string.Empty)
                    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rOpening Amount is missing." : errorMessage + "\rOpening Amount is missing.";





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            isValidInput = errorMessage == string.Empty ? true : false;

            return isValidInput;
        }
        private void InitializeForm()
        {
            dsSearchResults = null;
            currentRecIndex = -1;
            totalSearchRecords = 0;
        }
        protected bool IsAlreaadyExist()
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            SchoolDBDataContext CDB = new SchoolDBDataContext();
            DataSet dataSet = null;
            string sSQL = string.Empty;
            bool isValidInput = true;
            try
            {
                sSQL = "Select count (*) as cnt from dbo.Fees_Assignment where StId=" + tbStudent.Text.ToString() + " and FeeId=" + cbFeesType.SelectedValue.ToString().ConvertTo<long>() + " and Month=" + cbMonth.SelectedValue.ToString().ConvertTo<long>() + " and Year= " + cbYear.SelectedItem.ToString().ConvertTo<long>();
                dataSet = (DataSet)objDBHelper.GetDataSet(sSQL);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0 && isValidInput == true)
                {
                    
                        if (dataSet.Tables[0].Rows[0]["cnt"].ToString() == "1" || dataSet.Tables[0].Rows[0]["cnt"].ToString() == "2")
                        {
                            errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rFees is already opened." : errorMessage + "\rFees is already opened.";
                        }
                    
                }

                isValidInput = errorMessage == string.Empty ? true : false;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                CDB.Dispose();
                objCommon.Dispose();
            }





            return isValidInput;
        }
        private bool SaveRecord()
        {
            bool isDataSaved = false;
            System.Data.Common.DbTransaction trans = null;
            SchoolDBDataContext CDB = new SchoolDBDataContext();
            clsCommon objCommon = new clsCommon();
            clsSecurity objSecurity = new clsSecurity();
          
            try
            {
               
                    if (_CurrentAction == Constants.Action.Amend.GetHashCode())
                    {
                        if (objCommon.IsPostedFeesUsedinGeneration(_PrimaryKeyMain))
                        {
                            MessageBox.Show("Can't Amend Record, Because it is used in Generation.", Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (IsValidInformation())
                    {
                        if (CDB.Connection.State == ConnectionState.Closed)
                            CDB.Connection.Open();

                        trans = CDB.Connection.BeginTransaction();
                        CDB.Transaction = trans;


                        Fees_Assignment obj = null;
               


                        if (_isNewRecord)
                        {
                            if (IsAlreaadyExist())
                            {

                                obj = new Fees_Assignment();

                                CDB.Fees_Assignments.InsertOnSubmit(obj);
                                InitializeForm();
                            }
                        }
                        else
                        {


                            obj = CDB.Fees_Assignments.SingleOrDefault(where => where.Id == _PrimaryKeyMain);
                          
                        }

                        obj.FeeId = cbFeesType.SelectedValue.ToString().ConvertTo<long>();
                        obj.AssignmentDate = dpOpeningDate.Text.ToString().ConvertTo<DateTime>().Date;
                        obj.OpeningAmount = tbOpeningAmount.Text.ToString().ConvertTo<decimal>();
                        obj.Month=cbMonth.SelectedValue.ToString().ConvertTo<long>();
                        obj.Year = cbYear.SelectedItem.ToString().ConvertTo<long>();
                        obj.Type = "Fee Individual";
                        
                        obj.IsOpening = false;
                        obj.StId = tbStudent.Text.ToString().ConvertTo<long>();

                        obj.CurrentStatusId = objSecurity.GetNextStatus(Constants.PRM_OpeningFees, Global.UserId, _CurrentStatus, _CurrentAction);
                        obj.ActionDate = System.DateTime.Today.Date;
                        obj.Description = txtDescription.Text;

                       

                        CDB.SubmitChanges();

                        objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_OpeningFees, Constants.PRM_OpeningFees, _CurrentAction, DateTime.Now);
                        trans.Commit();


                        _CurrentStatus = obj.CurrentStatusId.Value;
                       

                        _PrimaryKeyMain = obj.Id;
                        isDataSaved = true;
                        _isNewRecord = false;
                        _isAnyFieldChanged = false;
                        PK.Text = obj.Id.ToString();

                    }
                    else
                    {
                        MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        isDataSaved = false;
                    }
               
                

            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();


                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isDataSaved = false;

            }
            finally
            {
                if (CDB.Connection.State == ConnectionState.Open)
                    CDB.Connection.Close();

                objCommon.Dispose();
                objSecurity = null;
            }
            return isDataSaved;
        }

        private void cbardef_SaveClicked()
        {
            string datett = dpOpeningDate.Text;
            DateTime dt = Convert.ToDateTime(datett);

            string lastDate = "Tuesday, October 01, 2019";
            DateTime dtLast = Convert.ToDateTime(lastDate);

            if (dt > DateTime.Now)
            {
                MessageBox.Show("You can not insert data in future date");
            }
            else if (dt < dtLast)
            {
                MessageBox.Show("You can not insert data in previous Year");
            }
            else
            {
                clsCommon objCommon = new clsCommon();
                try
                {
                    //--------------- Businees Rules Checks ------------------// 
                    _CurrentAction = Constants.Action.Save.GetHashCode();

                    if (SaveRecord())
                    {
                        this.cbardef.AdjustToolBarButtons(Constants.PRM_OpeningFees, Global.UserId, _CurrentStatus);
                        objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.saveMessage + " : " + "Record 1 of 1", "");

                    }
                }
                catch (Exception ex)
                {
                    errorMessage = ex.Message;
                    MessageBox.Show(Constants.ErrorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");
                    _isAnyFieldChanged = false;
                }

                finally
                {
                    objCommon.Dispose();
                }
            }
        }

        private void cbardef_ApproveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Approve.GetHashCode();
                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_OpeningFees, Global.UserId, _CurrentStatus);
                    objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ApproveMessage + " : " + "Record 1 of 1", "");

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                MessageBox.Show(Constants.ErrorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");
                _isAnyFieldChanged = false;
            }
            finally
            {
                objCommon.Dispose();
            }
        }
        private bool DeleteRecord()
        {
            bool isDataDeleted = false;
            System.Data.Common.DbTransaction trans = null;
            SchoolDBDataContext CDB = new SchoolDBDataContext();
            clsCommon objCommon = new clsCommon();
            clsSecurity objSecurity = new clsSecurity();
            try
            {

                //   ----------------------------  START TRANSACTION  ----------------------
                if (CDB.Connection.State == ConnectionState.Closed)
                    CDB.Connection.Open();

                trans = CDB.Connection.BeginTransaction();
                CDB.Transaction = trans;

               
                    Fees_Assignment obj = null;

                    obj = CDB.Fees_Assignments.SingleOrDefault(where => where.Id == _PrimaryKeyMain);
                    CDB.Fees_Assignments.DeleteOnSubmit(obj);
                    CDB.SubmitChanges();
                    objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_OpeningFees, Constants.PRM_OpeningFees, _CurrentAction, DateTime.Now);
                    trans.Commit();

                



                isDataDeleted = true;

            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();


                MessageBox.Show(ex.Message, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //objCommon.SetStatusBar(ref this.tbStatusBarLeft, ref tbStatusBarRight, ref this.imgStatusBar, "Error ...", -1, Constants.StatusBarMessageType.Error.GetHashCode(), ref Error);
                isDataDeleted = false;

            }
            finally
            {
                if (CDB.Connection.State == ConnectionState.Open)
                    CDB.Connection.Close();

                objCommon.Dispose();
                objSecurity = null;
            }
            return isDataDeleted;
        }    

        private void cbardef_AmendClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Amend.GetHashCode();
                //if (ValidNetPayable())
                // {
                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_OpeningFees, Global.UserId, _CurrentStatus);
                    objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.AmendMessage + " : " + "Record 1 of 1", "");

                }
                // }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                MessageBox.Show(Constants.ErrorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");
                _isAnyFieldChanged = false;
            }
            finally
            {
                objCommon.Dispose();
            }
        }

        private void cbardef_DeleteClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Delete.GetHashCode();
                if (DeleteRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_LOANASSIGNMENT, Global.UserId, _CurrentStatus);
                    objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.DeleteMessage + " : " + "Record 1 of 1", "");
                    NewRecord();

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                MessageBox.Show(Constants.ErrorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");
                _isAnyFieldChanged = false;
            }
            finally
            {
                objCommon.Dispose();
            }
        }

        private void cbardef_FirstClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                if (currentRecIndex > -1 && dsSearchResults != null)
                {
                    if (SaveChanges() == false)
                    {
                        return;
                    }

                    currentRecIndex = 0;

                    _PrimaryKeyMain = dsSearchResults.Tables[0].Rows[currentRecIndex]["Id"].ToString().ConvertTo<long>();
                    DisplayData(_PrimaryKeyMain);

                }
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
        private DataSet GetData(long Id)
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            DataSet dataSet = null;
            try
            {
                string sSQL = string.Empty;

                sSQL = " Select *," +
                    "(	Select Id from dbo.Student_Profile where Id = StId) as StId,(	Select Name from dbo.Student_Profile where Id = StId) as Name, " +
               "dbo.ufn_GetStateName(CurrentStatusId) as State from Fees_Assignment Where Id= " + Id + "";

                dataSet = (DataSet)objDBHelper.GetDataSet(sSQL);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objDBHelper.Dispose();
            }
            return dataSet;

        }
        protected void DisplayData(long Id)
        {
            dbSQLHelper objHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            DataSet dsDisplay = new DataSet();
            string status = string.Empty;
            try
            {
                dsDisplay = GetData(Id);
                if (dsDisplay != null)
                    if (dsDisplay.Tables[0].Rows.Count > 0)
                    {
                        _PrimaryKeyMain = dsDisplay.Tables[0].Rows[0]["Id"].ToString().ConvertTo<long>();
                        PK.Text = dsDisplay.Tables[0].Rows[0]["Id"].ToString();

                        _CurrentStatus = dsDisplay.Tables[0].Rows[0]["CurrentStatusId"].ToString().ConvertTo<int>();

                        cbFeesType.SelectedValue = dsDisplay.Tables[0].Rows[0]["FeeId"].ToString();

                        cbMonth.SelectedValue = dsDisplay.Tables[0].Rows[0]["Month"].ToString();

                        cbYear.SelectedItem = dsDisplay.Tables[0].Rows[0]["Year"].ToString();
                        

                        _GrowerContractorId = dsDisplay.Tables[0].Rows[0]["StId"].ToString().ConvertTo<long>();

                        dpOpeningDate.Value = dsDisplay.Tables[0].Rows[0]["AssignmentDate"].ToString().ConvertTo<DateTime>();

                       
                        tbStudent.Text = dsDisplay.Tables[0].Rows[0]["StId"].ToString();
                        lbGrowerContractorName.Text = dsDisplay.Tables[0].Rows[0]["Name"].ToString();


                        tbOpeningAmount.Text = dsDisplay.Tables[0].Rows[0]["OpeningAmount"].ToString();



                        txtDescription.Text = dsDisplay.Tables[0].Rows[0]["Description"].ToString();


                        status = dsDisplay.Tables[0].Rows[0]["State"].ToString().Trim();
                        _isAnyFieldChanged = false;
                        _isNewRecord = false;


                        cbardef.AdjustToolBarButtons(Constants.PRM_OpeningFees, Global.UserId, _CurrentStatus);
                        objCommon.SetStatusbar(ref tssAction, ref tssRecord, "Record " + (currentRecIndex + 1) + " / " + totalSearchRecords, status);
                    }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                dsDisplay.Dispose();
                objHelper.Dispose();
                objCommon.Dispose();
            }
        }

        private void cbardef_NextClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                if (currentRecIndex > -1 && dsSearchResults != null)
                {
                    if (SaveChanges() == false)
                    {
                        return;
                    }

                    if (currentRecIndex != (totalSearchRecords - 1))
                    {
                        currentRecIndex = currentRecIndex + 1;
                    }

                    _PrimaryKeyMain = dsSearchResults.Tables[0].Rows[currentRecIndex]["Id"].ToString().ConvertTo<long>();
                    DisplayData(_PrimaryKeyMain);


                }
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

        private void cbardef_LastClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                if (currentRecIndex > -1 && dsSearchResults != null)
                {
                    if (SaveChanges() == false)
                    {
                        return;
                    }

                    currentRecIndex = totalSearchRecords - 1;

                    _PrimaryKeyMain = dsSearchResults.Tables[0].Rows[currentRecIndex]["Id"].ToString().ConvertTo<long>();
                    DisplayData(_PrimaryKeyMain);

                }
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
        private Boolean SaveChanges()
        {
            if (_isAnyFieldChanged == true)
            {
                if (MessageBox.Show(Constants.FieldChangeMessage, Constants.ModuleName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    return true;
                }
                else
                {
                    return false; //on same record
                }
            }
            return true;
        }

        private void cbardef_PreviousClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                if (currentRecIndex > -1 && dsSearchResults != null)
                {
                    if (SaveChanges() == false)
                    {
                        return;
                    }

                    if (currentRecIndex != 0)
                    {
                        currentRecIndex = currentRecIndex - 1;
                    }

                    _PrimaryKeyMain = dsSearchResults.Tables[0].Rows[currentRecIndex]["Id"].ToString().ConvertTo<long>();
                    DisplayData(_PrimaryKeyMain);
                }
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

        private void cbardef_SearchClicked()
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            try
            {
                  Frontend.Fees.SearchFeesIndividualProcess objfrmSearch = new SearchFeesIndividualProcess(parentPageSearchList, Constants.PRM_OpeningFees);
                objfrmSearch.ShowDialog();
                if (objfrmSearch.selectedRecordId != -1)
                {
                    parentPageSearchList = objfrmSearch.listSearch;
                    searchQuery = objfrmSearch.GetSearchQuery(true);
                    dsSearchResults = (DataSet)objDBHelper.GetDataSet(searchQuery);


                    //get currentindex
                    DataColumn[] dc = new DataColumn[1];
                    dc[0] = dsSearchResults.Tables[0].Columns[0];

                    dsSearchResults.Tables[0].PrimaryKey = dc;
                    currentRecIndex = dsSearchResults.Tables[0].Rows.IndexOf(dsSearchResults.Tables[0].Rows.Find(objfrmSearch.selectedRecordId));
                    _PrimaryKeyMain = objfrmSearch.selectedRecordId;
                    totalSearchRecords = dsSearchResults.Tables[0].Rows.Count;

                    
                        DisplayData(objfrmSearch.selectedRecordId);
                    

                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                objDBHelper.Dispose();
            }
        }

        private void cbardef_PrintClicked()
        {
            try
            {



                Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
                reportParametersDictionary.Add("Id", _PrimaryKeyMain.ToString());
                reportParametersDictionary.Add("StId", tbStudent.Text.ToString());

                Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("MonthlyChallanReportIndividual", reportParametersDictionary);
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
    }
}
