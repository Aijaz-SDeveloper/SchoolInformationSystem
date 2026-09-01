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
    public partial class Parameters : Form
    {
        string errorMessage = string.Empty;
        long _PrimaryKeyMain = 0;
        bool _isAnyFieldChanged = false;
        bool _isNewRecord = true;
        private DataSet dsSearchResults = new DataSet();
        private List<clsSearchParameter> parentPageSearchList = new List<clsSearchParameter>();
        private string searchQuery = string.Empty;
            
      
         private int totalSearchRecords;
         private int currentRecIndex;


        int _CurrentAction = Constants.Action.Save.GetHashCode();
        int _CurrentStatus = Constants.State.New.GetHashCode();

        public Parameters()
        {
            InitializeComponent();
            ParameterInitialization();
        }
        public void ParameterInitialization()
        {
            clsCommon objCommon = new clsCommon();
            
         
           
            try
            {

                cbar.ActionAllowedOnToolBar(Constants.PRM_Paramter, Frontend.Common.Global.UserId, true, true);
                cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());

                int[] actionList = {
                                      Constants.Action.Save.GetHashCode(), 
                                      Constants.Action.Approve.GetHashCode(),                                       
                                      Constants.Action.Delete.GetHashCode(), 
                                      Constants.Action.Amend.GetHashCode(), 
                                      Constants.Action.Search.GetHashCode(), 
                                  };
                cbar.ReorderToolbar(actionList, false, Constants.PRM_Paramter, Frontend.Common.Global.UserId);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");

              
                ////                Form Settings

               
                this.Text = "Parameters Definition";
                this.MaximizeBox = false;
                this.Location = new Point(0, 0);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;



                //                COMBO BOX SETTING

                cbParamType.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameterType ";
                objCommon.FillCombo(ref cbParamType, ref  strQuery, "Description", "Id");

                


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
               
                this.tbRemarks.Text = string.Empty;
                this.txtName.Text = string.Empty;
                this.cbParamType.SelectedIndex = 0;
                

               
                
                _PrimaryKeyMain = 0;

                _isNewRecord = true;

                _isAnyFieldChanged = false;

             


                _CurrentAction = Constants.Action.Save.GetHashCode();
                _CurrentStatus = Constants.State.New.GetHashCode();

                txtName.Focus();

                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");
                cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());


             
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

            clsCommon objCommon = new clsCommon();
            SchoolDBDataContext CDB = new SchoolDBDataContext();
            dbSQLHelper objDBHelper = new dbSQLHelper();
           

           
           
            try
            {
                if (this.cbParamType.SelectedIndex == 0)
                   
                errorMessage = "Data can not be saved due to following reasons.\r\rPlease select Parameter Type.";
                cbParamType.Focus();
                if (this.txtName.Text == string.Empty)
                 
                errorMessage = "Data can not be saved due to following reasons.\r\rPlease fill the name field.";
                txtName.Focus();

              


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


                    Frontend.DBML.ComParameter obj = null;


                    if (_isNewRecord)
                    {

                        obj = new Frontend.DBML.ComParameter();




                        CDB.ComParameters.InsertOnSubmit(obj);

                        InitializeForm();
                    }
                    else
                    {

                        obj = CDB.ComParameters.SingleOrDefault(where => where.Id == _PrimaryKeyMain);


                    }
                    obj.Description = txtName.Text.ToString();
                    obj.Remarks = tbRemarks.Text.ToString();
                    obj.Type = cbParamType.SelectedValue.ToString().ConvertTo<long>();


                    obj.BranchId = 1;
                    obj.Status = true;
                    obj.ParentId = 0;
                    obj.Code = "";




                    obj.CurrentStatusId = objSecurity.GetNextStatus(Constants.PRM_Paramter, Frontend.Common.Global.UserId, _CurrentStatus, _CurrentAction);

                    CDB.SubmitChanges();






                    objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_Paramter, Constants.PRM_Paramter, _CurrentAction, DateTime.Now);
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

        private void cbar_AmendClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Amend.GetHashCode();
                if (SaveRecord())
                {
                    this.cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, _CurrentStatus);
                    objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.AmendMessage + " : " + "Record 1 of 1", "");

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

        private void cbar_NewClicked()
        {
            NewRecord();
        }

        private void cbar_SaveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Save.GetHashCode();

                if (SaveRecord())
                {
                    
                    this.cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, _CurrentStatus);
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

        private void cbar_ApproveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Approve.GetHashCode();
                if (SaveRecord())
                {
                    this.cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, _CurrentStatus);
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

              

                //   - ---------------------------  START TRANSACTION  ----------------------
                if (CDB.Connection.State == ConnectionState.Closed)
                    CDB.Connection.Open();

                trans = CDB.Connection.BeginTransaction();
                CDB.Transaction = trans;

                
                Frontend.DBML.ComParameter obj = null;
                
                obj = CDB.ComParameters.SingleOrDefault(where => where.Id == _PrimaryKeyMain);

                CDB.ComParameters.DeleteOnSubmit(obj);
               
                CDB.SubmitChanges();


                objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_Paramter, Constants.PRM_Paramter, _CurrentAction, DateTime.Now);
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

        private void cbar_DeleteClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Delete.GetHashCode();
                if (DeleteRecord())
                {
                    this.cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, _CurrentStatus);
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
        private DataSet LoadData(long Id)
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            DataSet dataSet = null;
            string sSQL = string.Empty;
            try
            {


                sSQL = "Select Id,Description,Type,Remarks,CurrentStatusId from ComParameters  " +
                           " Where Id =" + Id;
              
                
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
                dsDisplay = LoadData(Id);
                if (dsDisplay != null)
                    if (dsDisplay.Tables[0].Rows.Count > 0)
                    {
                        _PrimaryKeyMain = dsDisplay.Tables[0].Rows[0]["Id"].ToString().ConvertTo<long>();
                        _CurrentStatus = dsDisplay.Tables[0].Rows[0]["CurrentStatusId"].ToString().ConvertTo<int>();

                        if (dsDisplay.Tables[0].Rows[0]["Description"] != System.DBNull.Value)
                            txtName.Text = dsDisplay.Tables[0].Rows[0]["Description"].ToString();
                        




                        if (dsDisplay.Tables[0].Rows[0]["Remarks"] != System.DBNull.Value)
                        
                            tbRemarks.Text = dsDisplay.Tables[0].Rows[0]["Remarks"].ToString();
                            
                        
                        }

                       
                        if (dsDisplay.Tables[0].Rows[0]["Type"] != System.DBNull.Value)
                            cbParamType.SelectedValue = dsDisplay.Tables[0].Rows[0]["Type"].ToString();
                


                        _isAnyFieldChanged = false;
                        _isNewRecord = false;

                       
                        cbar.AdjustToolBarButtons(Constants.PRM_Paramter, Frontend.Common.Global.UserId, _CurrentStatus);
                        objCommon.SetStatusbar(ref tssAction, ref tssRecord, "Record " + (currentRecIndex + 1) + " / " + totalSearchRecords, status);
                    
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

        private void cbar_NextClicked()
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

        private void cbar_PreviousClicked()
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

        private void cbar_LastClicked()
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

        private void cbar_FirstClicked()
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

        private void cbar_SearchClicked()
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            try
            {

                
                Frontend.Parameter.SearchForm.SearchParametrs objfrmSearch = new Frontend.Parameter.SearchForm.SearchParametrs(parentPageSearchList, true, false);
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
                    //   LoadDataGrowerGroup();

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
    }
}
