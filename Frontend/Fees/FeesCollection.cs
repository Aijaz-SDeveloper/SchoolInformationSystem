using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Frontend.DBML;
using BusinessLogic;

namespace Frontend.Fees
{
    public partial class FeesCollection : Form
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
        public FeesCollection()
        {
            InitializeComponent();
            FeeInitialization();
        }
        public void FeeInitialization()
        {
            clsCommon objCommon = new clsCommon();

            try
            {
                cbardef.ActionAllowedOnToolBar(Constants.PRM_FeesCollection, Frontend.Common.Global.UserId, true, true);
                cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());

                int[] actionList = {
                                      Constants.Action.Save.GetHashCode(), 
                                      Constants.Action.Approve.GetHashCode(),                                       
                                      Constants.Action.Delete.GetHashCode(), 
                                      Constants.Action.Amend.GetHashCode(), 
                                      Constants.Action.Search.GetHashCode(), 
                                  };
                cbardef.ReorderToolbar(actionList, false, Constants.PRM_FeesCollection, Frontend.Common.Global.UserId);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");

                ////                Form Settings


                this.Text = "Fees Collection";
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

        private void tbStudent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                DisplayCode(0, true, tbStudent.Text.Trim());
            }
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
                    sSQL = " Select Student_Profile.Id,Name,isnull(sum(PrincipleBalance),0) as Balance from dbo.Student_Profile"+
                        " left join Fee_GenerationMaster on Student_Profile.Id=Fee_GenerationMaster.StId where Student_Profile.Id=" + code + " group by Student_Profile.Id,Name";
                }
                else
                {
                    sSQL = " Select Student_Profile.Id,Name,isnull(sum(PrincipleBalance),0) as Balance from dbo.Student_Profile" +
                       " left join Fee_GenerationMaster on Student_Profile.Id=Fee_GenerationMaster.StId where Student_Profile.Id=" + Id + " group by Student_Profile.Id,Name";
              
                  
                }
                dataSet = (DataSet)objDBHelper.GetDataSet(sSQL);
                if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    //tbContractorGrower.Text = dataSet.Tables[0].Rows[0]["Code"].ToString();
                    lbGrowerContractorName.Text = dataSet.Tables[0].Rows[0]["Name"].ToString();
                    tbStudent.Text = dataSet.Tables[0].Rows[0]["Id"].ToString();
                    lbBalanceAmount.Text = dataSet.Tables[0].Rows[0]["Balance"].ToString();
                    lbBalanceAmount.Visible = true;
                    
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
                this.lbBalanceAmount.Text = string.Empty;

                this.txtDescription.Text = string.Empty;

                
                this.dpOpeningDate.Text = DateTime.Now.ToShortTimeString();
                _PrimaryKeyMain = 0;
                _GrowerContractorId = 0;
                _isNewRecord = true;
                _isAnyFieldChanged = false;
               

                _CurrentAction = Constants.Action.Save.GetHashCode();
                _CurrentStatus = Constants.State.New.GetHashCode();
                tbStudent.Focus();
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");
                cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Global.UserId, Constants.State.New.GetHashCode());

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
                

                if (tbStudent.Text == string.Empty )
                {
                    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rStudent is missing." : errorMessage + "\rStudent is missing.";
                }
                
                if (tbOpeningAmount.Text == string.Empty)
                    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rAmount is missing." : errorMessage + "\rAmount is missing.";

                if (tbOpeningAmount.Text.Trim() != string.Empty)
                    if (tbOpeningAmount.Text.Trim().ConvertTo<decimal>() > lbBalanceAmount.Text.ConvertTo<decimal>())
                        errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rAmount Can't be greater than Balance amount." : errorMessage + "\rAmount Can't be greater than Balance amount.";





            }
            catch (Exception ex)
            {
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

                   
                    Fees_Collection obj = null;
                    
                    if (_isNewRecord)
                    {

                        obj = new Fees_Collection();

                        
                     
                        CDB.Fees_Collections.InsertOnSubmit(obj);
                       
                        
                        InitializeForm();
                    }
                    else
                    {


                        
                        obj = CDB.Fees_Collections.SingleOrDefault(where=>where.Id==_PrimaryKeyMain);

                    }
                    
                    obj.PaidDate = dpOpeningDate.Text.ToString().ConvertTo<DateTime>().Date;
                    
                    
                    if (tbOpeningAmount.Text != "")
                        obj.TotalAmount = tbOpeningAmount.Text.ToString().ConvertTo<decimal>() > 0 ? tbOpeningAmount.Text.ToString().ConvertTo<decimal>() * -1 : tbOpeningAmount.Text.ToString().ConvertTo<decimal>();
                    

                    obj.Remarks = txtDescription.Text;
                    obj.StId = tbStudent.Text.ToString().ConvertTo<long>();

                    obj.ActionDate = DateTime.Now;

                    obj.CurrentStatusId = objSecurity.GetNextStatus(Constants.PRM_FeesCollection, Global.UserId, _CurrentStatus, _CurrentAction).ToString().ConvertTo<byte>();



                    CDB.SubmitChanges();
                    objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_FeesCollection, Constants.PRM_FeesCollection, _CurrentAction, DateTime.Now);
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
                    //objCommon.SetStatusBar(ref this.tbStatusBarLeft, ref tbStatusBarRight, ref this.imgStatusBar, "Validation Error ...", -1, Constants.StatusBarMessageType.Validation.GetHashCode(), ref Error);

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

        private void cbardef_SaveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Save.GetHashCode();
                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Global.UserId, _CurrentStatus);
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

        private void cbardef_AmendClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Amend.GetHashCode();
                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Global.UserId, _CurrentStatus);
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

        private void cbardef_ApproveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Approve.GetHashCode();
                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Global.UserId, _CurrentStatus);
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

                
                Fees_Collection obj = null;
               
                obj = CDB.Fees_Collections.SingleOrDefault(where=>where.Id==_PrimaryKeyMain);
                CDB.Fees_Collections.DeleteOnSubmit(obj);
               

                CDB.SubmitChanges();
                objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_FeesCollection, Constants.PRM_FeesCollection, _CurrentAction, DateTime.Now);
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

        private void cbardef_DeleteClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Delete.GetHashCode();
                if (DeleteRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Global.UserId, _CurrentStatus);
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
                        _CurrentStatus = dsDisplay.Tables[0].Rows[0]["CurrentStatusID"].ToString().ConvertTo<int>();


                        tbStudent.Text = dsDisplay.Tables[0].Rows[0]["StId"].ToString();

                        dpOpeningDate.Value = dsDisplay.Tables[0].Rows[0]["PaidDate"].ToString().ConvertTo<DateTime>();

                        lbGrowerContractorName.Text = dsDisplay.Tables[0].Rows[0]["Name"].ToString();

                        tbOpeningAmount.Text = dsDisplay.Tables[0].Rows[0]["TotalAmount"].ToString();
                        txtDescription.Text = dsDisplay.Tables[0].Rows[0]["Remarks"].ToString();

                        lbBalanceAmount.Text = dsDisplay.Tables[0].Rows[0]["Balance"].ToString();
                        lbBalanceAmount.Visible = true;





                        status = dsDisplay.Tables[0].Rows[0]["State"].ToString().Trim();
                        _isAnyFieldChanged = false;
                        _isNewRecord = false;

                        DisplayCode(tbStudent.Text.ToString().ConvertTo<int>(), false, "");
                        cbardef.AdjustToolBarButtons(Constants.PRM_FeesCollection, Global.UserId, _CurrentStatus);
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
        private DataSet GetData(long Id)
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            DataSet dataSet = null;
            try
            {
                string sSQL = string.Empty;


                sSQL = "  Select Fees_Collection.Id,Name,Student_Profile.Id as StId,Isnull(Fees_Collection.Remarks,'') as Remarks,Fees_Collection.PaidDate,Isnull(Fees_Collection.TotalAmount,0) as TotalAmount,isnull(sum(PrincipleBalance),0) as Balance,Fees_Collection.CurrentStatusID," +
                      " dbo.ufn_GetStateName(Fees_Collection.CurrentStatusID) as State from dbo.Student_Profile left join Fee_GenerationMaster "+
                      " on Student_Profile.Id=Fee_GenerationMaster.StId  left join Fees_Collection on Student_Profile.Id=Fees_Collection.StId where Fees_Collection.Id="+
                      " " + Id + " group by Student_Profile.Id,Name,Fees_Collection.PaidDate,Fees_Collection.CurrentStatusID,Fees_Collection.Id,Student_Profile.Id,Fees_Collection.TotalAmount,Fees_Collection.Remarks";
              

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
       
       

        private void cbardef_SearchClicked()
        {

            dbSQLHelper objDBHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            try
            {
                Frontend.Fees.SearchFeesCollection objfrmSearch = new SearchFeesCollection(parentPageSearchList, Constants.PRM_FeesCollection);
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
                MessageBox.Show(ex.Message, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                objDBHelper.Dispose();
            }
        }
    }
}
