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

namespace Frontend.Parameter
{
    public partial class AcademicYear : Form
    {
        long _PrimaryKeyMain = 0;

        bool _isNewRecord = true;
        string errorMessage = string.Empty;
        bool _isAnyFieldChanged = false;
        int _CurrentAction = Constants.Action.Save.GetHashCode();
        int _CurrentStatus = Constants.State.New.GetHashCode();

        private int currentRecIndex;
        private int totalSearchRecords;
        private string searchQuery = string.Empty;
        private DataSet dsSearchResults = new DataSet();

        private List<clsSearchParameter> parentPageSearchList = new List<clsSearchParameter>();

        public AcademicYear()
        {
            InitializeComponent();
            ContructorInitialization();

            this.cbarYeardef.TabIndex = 1;
            this.dpFromDate.TabIndex = 2;
            this.dpTodate.TabIndex = 3;
            this.tbYearName.TabIndex = 4;
         

        }
        public void ContructorInitialization()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                cbarYeardef.ActionAllowedOnToolBar(Constants.PRM_YEARDEFINATION, Global.UserId, true, true);
                cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Global.UserId, Constants.State.New.GetHashCode());

                int[] actionList = {
                                      Constants.Action.Save.GetHashCode(), 
                                      Constants.Action.Approve.GetHashCode(), 
                                      Constants.Action.Close.GetHashCode(), 
                                      Constants.Action.Delete.GetHashCode(), 
                                      Constants.Action.Search.GetHashCode(), 
                                  };
                cbarYeardef.ReorderToolbar(actionList, false, Constants.PRM_YEARDEFINATION, Global.UserId);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");

               

                ////                Form Settings

                this.Text = "Academic Year Definition";
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
        protected void NewRecord()
        {
            clsCommon objCommon = new clsCommon();
            try
            {

             

                this.dpFromDate.Value = DateTime.Now;
                this.dpTodate.Value = DateTime.Now;
                this.tbYearName.Text = string.Empty;
                

                dpTodate.Enabled = false;
                dpFromDate.Enabled = true;
                dpTodate.Checked = false;



                _PrimaryKeyMain = 0;

                _isNewRecord = true;

                _isAnyFieldChanged = false;




                _CurrentAction = Constants.Action.Save.GetHashCode();
                _CurrentStatus = Constants.State.New.GetHashCode();

                tbYearName.Focus();

                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");
                cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());



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
        protected bool IsValidInformation()
        {
            bool isValidInput = true;
            errorMessage = string.Empty;
            
            if (tbYearName.Text == string.Empty)
                errorMessage = "Data can not be saved due to following reasons.\r\rYear Name is missing.";

           
            if (_CurrentAction == Constants.Action.Close.GetHashCode())
            {
                if (dpTodate.Checked == false)
                    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rTo Date is missing." : errorMessage + "\rTo Date is missing.";

                if (dpTodate.Value < dpFromDate.Value)
                    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rTo Date is less than From Date." : errorMessage + "\rTo Date is less than From Date.";
            }
            if (isAnySeasonOpened())
            {
                errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rThere is already an open Year exist,  First close it." : errorMessage + "\rThere is already an open Year exist,  First close it.";
            }

            isValidInput = errorMessage == string.Empty ? true : false;

            return isValidInput;
        }
        protected bool isAnySeasonOpened()
        {
            bool isExist = false;
            SchoolDBDataContext CDB = new SchoolDBDataContext();
           
            try
            {
                var getOpenedSeason = from year in CDB.YearDefinations
                                      where year.CurrentStatusId != Constants.State.Closed.GetHashCode()
                                      && year.Id != _PrimaryKeyMain
                                      select year;
                if (getOpenedSeason.Count() > 0)
                    isExist = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                CDB.Dispose();
            }
            return isExist;
        }
       
        private void InitializeForm()
        {
            dsSearchResults = null;
            currentRecIndex = -1;
            totalSearchRecords = 0;
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
                if (IsValidInformation())
                {
                    //   - ---------------------------  START TRANSACTION  ----------------------
                    if (CDB.Connection.State == ConnectionState.Closed)
                        CDB.Connection.Open();

                    trans = CDB.Connection.BeginTransaction();
                    CDB.Transaction = trans;


                  
                    Frontend.DBML.YearDefination obj = null;


                    if (_isNewRecord)
                    {

                       
                        obj = new YearDefination();


                        CDB.YearDefinations.InsertOnSubmit(obj);

                        InitializeForm();
                    }
                    else
                    {

                       
                        obj = CDB.YearDefinations.SingleOrDefault(where=>where.Id==_PrimaryKeyMain);


                    }

                    obj.FromDate = dpFromDate.Value;
                    obj.YearName = tbYearName.Text.Trim();
                    
                    obj.CurrentStatusId = objSecurity.GetNextStatus(Constants.PRM_YEARDEFINATION, Global.UserId, _CurrentStatus, _CurrentAction);
                   
                    if (_CurrentAction == Constants.Action.Close.GetHashCode())
                        obj.ToDate = dpTodate.Value;




                   
                    CDB.SubmitChanges();






                    objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_YEARDEFINATION, Constants.PRM_YEARDEFINATION, _CurrentAction, DateTime.Now);
                    trans.Commit();

                    _CurrentStatus = obj.CurrentStatusId.Value;
                    _PrimaryKeyMain = obj.Id;



                    isDataSaved = true;
                    _isNewRecord = false;
                    _isAnyFieldChanged = false;

                }
                else
                {
                    MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //objCommon.SetStatusbar(ref this.tbStatusBarLeft, ref tbStatusBarRight, ref this.imgStatusBar, "Validation Error ...", -1, Constants.StatusBarMessageType.Validation.GetHashCode(), ref Error);

                    isDataSaved = false;
                }

            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();


                MessageBox.Show(ex.Message, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //objCommon.SetStatusBar(ref this.tbStatusBarLeft, ref tbStatusBarRight, ref this.imgStatusBar, "Error ...", -1, Constants.StatusBarMessageType.Error.GetHashCode(), ref Error);
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

        private void cbarYeardef_NewClicked()
        {
            NewRecord();
        }

        private void cbarYeardef_NextClicked()
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

       
        private void cbarYeardef_ApproveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Approve.GetHashCode();
                if (SaveRecord())
                {
                    dpTodate.Checked = true;
                    dpTodate.Enabled = true;
                    dpTodate.Value = System.DateTime.Now;
                    
                    this.cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Global.UserId, _CurrentStatus);
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
        private void SetEnablePropertyofToDate(int status)
        {
            if (status == Constants.State.Approved.GetHashCode())
            {
                dpTodate.Enabled = true;
                dpFromDate.Enabled = false;
                
            }
            else
            {
                dpTodate.Enabled = false;
                dpFromDate.Enabled = true;
                
            }
        }
        private DataSet GetData(long Id)
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            DataSet dataSet = null;
            try
            {
                string sSQL = string.Empty;
                sSQL = " Select *,dbo.ufn_GetStateName(CurrentStatusId) as State from YearDefination Where Id= " + Id + "";
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
                        _CurrentStatus = dsDisplay.Tables[0].Rows[0]["CurrentStatusId"].ToString().ConvertTo<int>();

                        if (dsDisplay.Tables[0].Rows[0]["FromDate"] != System.DBNull.Value)
                            dpFromDate.Value = dsDisplay.Tables[0].Rows[0]["FromDate"].ToString().ConvertTo<DateTime>();

                        if (dsDisplay.Tables[0].Rows[0]["ToDate"] != System.DBNull.Value)
                        {
                            dpTodate.Value = dsDisplay.Tables[0].Rows[0]["ToDate"].ToString().ConvertTo<DateTime>();
                            dpTodate.Checked = true;
                        }
                        else
                            dpTodate.Checked = false;

                        
                        SetEnablePropertyofToDate(_CurrentStatus);

                        tbYearName.Text = dsDisplay.Tables[0].Rows[0]["YearName"].ToString().Trim();
                        
                        status = dsDisplay.Tables[0].Rows[0]["State"].ToString().Trim();
                        _isAnyFieldChanged = false;
                        _isNewRecord = false;

                        cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Global.UserId, _CurrentStatus);
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

        private void cbarYeardef_FirstClicked()
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

        private void cbarYeardef_LastClicked()
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

        private void cbarYeardef_SearchClicked()
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            try
            {

               
                Frontend.Parameter.SearchForm.frmSearchYear obj = new Frontend.Parameter.SearchForm.frmSearchYear(parentPageSearchList);
                obj.ShowDialog();
                if (obj.selectedRecordId != -1)
                {
                    parentPageSearchList = obj.listSearch;
                    searchQuery = obj.GetSearchQuery(true);
                    dsSearchResults = (DataSet)objDBHelper.GetDataSet(searchQuery);

                    //get currentindex
                    DataColumn[] dc = new DataColumn[1];
                    dc[0] = dsSearchResults.Tables[0].Columns[0];
                    dsSearchResults.Tables[0].PrimaryKey = dc;
                    currentRecIndex = dsSearchResults.Tables[0].Rows.IndexOf(dsSearchResults.Tables[0].Rows.Find(obj.selectedRecordId));
                    _PrimaryKeyMain = obj.selectedRecordId;
                    totalSearchRecords = dsSearchResults.Tables[0].Rows.Count;

                    DisplayData(obj.selectedRecordId);

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

        private void cbarYeardef_SaveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Save.GetHashCode();
                if (SaveRecord())
                {
                    
                    this.cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Global.UserId, _CurrentStatus);
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

        private void cbarYeardef_PreviousClicked()
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

        private void cbarYeardef_CloseClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Close.GetHashCode();
                if (SaveRecord())
                {
                    
                    this.cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Global.UserId, _CurrentStatus);
                    objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.SeasonMessage + " : " + "Record 1 of 1", "");

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

                //   - ---------------------------  START TRANSACTION  ----------------------
                if (CDB.Connection.State == ConnectionState.Closed)
                    CDB.Connection.Open();

                trans = CDB.Connection.BeginTransaction();
                CDB.Transaction = trans;

           
                YearDefination obj = null;
                
                obj = CDB.YearDefinations.SingleOrDefault(where=>where.Id==_PrimaryKeyMain);
              
                CDB.YearDefinations.DeleteOnSubmit(obj);

                CDB.SubmitChanges();
                objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_YEARDEFINATION, Constants.PRM_YEARDEFINATION, _CurrentAction, DateTime.Now);
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

        private void cbarYeardef_DeleteClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Delete.GetHashCode();
                if (DeleteRecord())
                {
                    

                    this.cbarYeardef.AdjustToolBarButtons(Constants.PRM_YEARDEFINATION, Global.UserId, _CurrentStatus);
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

    }
}
