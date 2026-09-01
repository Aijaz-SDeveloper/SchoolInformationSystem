using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;
using System.IO;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Frontend.DBML;
using System.Data.SqlClient;

namespace Frontend.Parameter
{
    public partial class StudentProfile : Form
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
        dbSQLHelper objDBHelper = new dbSQLHelper();
        DataSet ds;
       


        int _CurrentAction = Constants.Action.Save.GetHashCode();
        int _CurrentStatus = Constants.State.New.GetHashCode();

        public StudentProfile()
        {
            InitializeComponent();
            ProfileInitialization();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenPhoto();

        }
        public void ProfileInitialization()
        {
            clsCommon objCommon = new clsCommon();
         
            try
            {
                cbardef.ActionAllowedOnToolBar(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, true, true);
                cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());

                int[] actionList = {
                                      Constants.Action.Save.GetHashCode(), 
                                      Constants.Action.Approve.GetHashCode(),                                       
                                      Constants.Action.Delete.GetHashCode(), 
                                      Constants.Action.Amend.GetHashCode(), 
                                      Constants.Action.Search.GetHashCode(), 
                                  };
                cbardef.ReorderToolbar(actionList, false, Constants.PRM_StudentProfile, Frontend.Common.Global.UserId);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");

                 ////                Form Settings

              
                this.Text = "Student Profile";
                this.MaximizeBox = false;
                this.Location = new Point(0, 0);
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

                


                //                COMBO BOX SETTING

                cbFGProff.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 7 ";
                objCommon.FillCombo(ref cbFGProff, ref  strQuery, "Description", "Id");

                cbGuardRelation.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery2 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 17 ";
                objCommon.FillCombo(ref cbGuardRelation, ref  strQuery2, "Description", "Id");

                cbAdClass.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery3 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 1 ORDER BY Description ";
                objCommon.FillCombo(ref cbAdClass, ref  strQuery3, "Description", "Id");

                cbStClass.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery4 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 1 ORDER BY Description ";
                objCommon.FillCombo(ref cbStClass, ref  strQuery4, "Description", "Id");

                cbSection.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery5 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 2 ";
                objCommon.FillCombo(ref cbSection, ref  strQuery5, "Description", "Id");

                cbPoB.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery6 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 5 ";
                objCommon.FillCombo(ref cbPoB, ref  strQuery6, "Description", "Id");

                cbSchool.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery7 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 6 ";
                objCommon.FillCombo(ref cbSchool, ref  strQuery7, "Description", "Id");

                cbCaste.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery8 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 4 ";
                objCommon.FillCombo(ref cbCaste, ref  strQuery8, "Description", "Id");

                cbReligion.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery9 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 3 ";
                objCommon.FillCombo(ref cbReligion, ref  strQuery9, "Description", "Id");

                cbGender.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery10 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 16 ";
                objCommon.FillCombo(ref cbGender, ref  strQuery10, "Description", "Id");

                cbTransaction.DropDownStyle = ComboBoxStyle.DropDownList;
                string strQuery11 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Id = 139  ";
                objCommon.FillCombo(ref cbTransaction, ref  strQuery11, "Description", "Id");
      


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
        void OpenPhoto()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {


                Title = "Browse Image File",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };


            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

                ImagePath.Text = openFileDialog1.FileName;


            }
        }
        protected void NewRecord()
        {
            clsCommon objCommon = new clsCommon();
            try
            {

                this.tbName.Text = string.Empty;
                this.tbFatherName.Text = string.Empty;
                this.tbCnic.Text = string.Empty;
                this.tbGrNo.Text = string.Empty;
                this.tbEmail.Text = string.Empty;
                this.tbRemarks.Text = string.Empty;
                this.tbGuardName.Text = string.Empty;
                this.tbPerMobileNo.Text = string.Empty;
                this.tbPerPhoneNo.Text = string.Empty;
                this.tbPreMobileNo.Text = string.Empty;
                this.tbPresPhone.Text = string.Empty;
                this.tbOfficeMobileNo.Text = string.Empty;
                this.tbPAddress.Text = string.Empty;
                this.tbPresAddress.Text = string.Empty;
                this.tbOfficeAddress.Text = string.Empty;
                this.tbOfficePhoneNo.Text = string.Empty;
                this.dpDob.Value = DateTime.Now;
                pictureBox1.Image = null;
                

                this.cbStClass.SelectedIndex = 0;
                this.cbAdClass.SelectedIndex = 0;
                this.cbSection.SelectedIndex = 0;
                this.cbPoB.SelectedIndex = 0;
                this.cbGender.SelectedIndex = 0;
                this.cbSchool.SelectedIndex = 0;
                this.cbCaste.SelectedIndex = 0;
                this.cbReligion.SelectedIndex = 0;
                this.cbFGProff.SelectedIndex = 0;
                this.cbGuardRelation.SelectedIndex = 0;




                _PrimaryKeyMain = 0;

                _isNewRecord = true;

                _isAnyFieldChanged = false;




                _CurrentAction = Constants.Action.Save.GetHashCode();
                _CurrentStatus = Constants.State.New.GetHashCode();

                
                tbName.Focus();

                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "New", "");
                cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, Constants.State.New.GetHashCode());



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
        private bool IsValidCNIC(string cnic)
        {
            Regex check = new Regex(@"^[0-9]{5}-[0-9]{7}-[0-9]{1}$");
            bool valid = false;
            valid = check.IsMatch(cnic);
            return valid;
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
                if (this.cbPoB.SelectedIndex == 0)
                    errorMessage = "Data can not be saved due to following reasons.\r\rPlease select place of birth.";
                    cbPoB.Focus();

                    if (this.cbAdClass.SelectedIndex == 0)
                        errorMessage = "Data can not be saved due to following reasons.\r\rPlease select class.";
                    cbAdClass.Focus();

                    if (this.cbSection.SelectedIndex == 0)
                        errorMessage = "Data can not be saved due to following reasons.\r\rPlease select section.";
                    cbSection.Focus();

                    if (this.cbReligion.SelectedIndex == 0)
                        errorMessage = "Data can not be saved due to following reasons.\r\rPlease select religion.";
                    cbReligion.Focus();

                    if (this.cbGender.SelectedIndex == 0)
                        errorMessage = "Data can not be saved due to following reasons.\r\rPlease select gender.";
                    cbGender.Focus();

                    if (this.cbCaste.SelectedIndex == 0)
                        errorMessage = "Data can not be saved due to following reasons.\r\rPlease select caste.";
                    cbCaste.Focus();


                if (this.tbName.Text == string.Empty)
                    errorMessage = "Data can not be saved due to following reasons.\r\rPlease fill the name field.";
                    tbName.Focus();

                    if (this.tbFatherName.Text == string.Empty)
                        errorMessage = "Data can not be saved due to following reasons.\r\rPlease fill the father name field.";
                    tbFatherName.Focus();

                    //if (this.tbCnic.Text == string.Empty)
                    //    errorMessage = "Data can not be saved due to following reasons.\r\rPlease fill the CNIC field.";
                    //tbCnic.Focus();

                    //if (tbCnic.Text.Length < 15)
                    //    errorMessage = "Data can not be saved due to following reasons.\r\rCNIC must be 15 digit.";


                    //if (IsValidCNIC(tbCnic.Text) == false)

                    //    errorMessage = errorMessage == string.Empty ? "Data can not be saved due to following reasons.\r\rCNIC is invalid." : errorMessage + "\rCNIC is invalid.";
            

                  




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
        void Save_photo()
        {
            SqlCommand cmd;
            
            SqlConnection con;
            // byte[] photo_aray;

            con = new SqlConnection("data source=PC4-PC;user id=sa;password=saa;database=School");



            cmd = new SqlCommand("update dbo.Student_Profile SET Pic= " + "@photo "+" where Id="+_PrimaryKeyMain, con);

            if (pictureBox1.Image != null)
            {

                MemoryStream ms = new MemoryStream();


                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);

                byte[] photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                cmd.Parameters.AddWithValue("@photo", photo_aray);
            }
            con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            if (n > 0)
            {
                //MessageBox.Show("record inserted");

            }
            else
                MessageBox.Show("Image insertion failed");
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


                    
                    Frontend.DBML.Student_Profile obj = null;


                    if (_isNewRecord)
                    {

                       
                        obj = new Frontend.DBML.Student_Profile();

                        


                       
                        CDB.Student_Profiles.InsertOnSubmit(obj);
                        

                        InitializeForm();
                    }
                    else
                    {

                        
                        obj = CDB.Student_Profiles.SingleOrDefault(where => where.Id == _PrimaryKeyMain);


                    }
                    obj.Name = tbName.Text.ToString();
                    obj.FName = tbFatherName.Text.ToString();
                    obj.CNIC = tbCnic.Text.ToString();
                    obj.DateTime = DateTime.Now;
                    obj.DOB = dpDob.Value;
                    obj.Email = tbEmail.Text.ToString();
                    obj.GRNo = tbGrNo.Text.ToString();
                    obj.GuardianName = tbGuardName.Text.ToString();
                    obj.OfficeAddress = tbOfficeAddress.Text.ToString();
                    obj.OfficeMobileNo = tbOfficeMobileNo.Text.ToString();
                    obj.OfficePhoneNo = tbOfficePhoneNo.Text.ToString();
                    obj.PermAdress = tbPAddress.Text.ToString();
                    obj.PermMobileNo = tbPerMobileNo.Text.ToString();
                    obj.PermPhoneNo = tbPerPhoneNo.Text.ToString();
                    obj.PresentAddress = tbPresAddress.Text.ToString();
                    obj.PresentMobileNo = tbPreMobileNo.Text.ToString();
                    obj.PresentPhoneNo = tbPresPhone.Text.ToString();
                    obj.Remarks = tbRemarks.Text.ToString();
                    obj.PicPath = ImagePath.Text.ToString();
                    //obj.Pic = PbStudent.Text.ToString();
                    obj.IsActive = true;
                    obj.AdmissionClassId = cbAdClass.SelectedValue.ToString().ConvertTo<long>();
                    obj.CasteId = cbCaste.SelectedValue.ToString().ConvertTo<long>();
                    obj.GenderId = cbGender.SelectedValue.ToString().ConvertTo<long>();
                    obj.GuardianRelationId = cbGuardRelation.SelectedValue.ToString().ConvertTo<long>();
                    obj.LastSchoolId = cbSchool.SelectedValue.ToString().ConvertTo<long>();
                    obj.PlaceOBCityId = cbPoB.SelectedValue.ToString().ConvertTo<long>(); 
                    obj.ProfessionId=cbFGProff.SelectedValue.ToString().ConvertTo<long>();
                    obj.ReligionId = cbReligion.SelectedValue.ToString().ConvertTo<long>();
                    obj.SecId = cbSection.SelectedValue.ToString().ConvertTo<long>();
                    obj.StudyClassId = cbStClass.SelectedValue.ToString().ConvertTo<long>();
                    obj.YearId = objCommon.GetYearID();
                    obj.ActionTypeId = cbTransaction.SelectedValue.ToString().ConvertTo<long>();
                    obj.CurrentStatus = objSecurity.GetNextStatus(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, _CurrentStatus, _CurrentAction);
                    CDB.SubmitChanges();

                    




                    objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_StudentProfile, Constants.PRM_StudentProfile, _CurrentAction, DateTime.Now);
                    trans.Commit();

                    _CurrentStatus = obj.CurrentStatus.Value.ToString().ConvertTo<Int32>();
                    
                    _PrimaryKeyMain = obj.Id;
                    if (pictureBox1.Image != null)
                    {
                        Save_photo();
                    }

                    isDataSaved = true;
                    _isNewRecord = false;
                    _isAnyFieldChanged = false;

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


                MessageBox.Show(ex.Message, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

       

        private void cbardef_AmendClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Amend.GetHashCode();
                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, _CurrentStatus);
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
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, _CurrentStatus);
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

        private void cbardef_NewClicked()
        {
            NewRecord();
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

        private void cbardef_PrintClicked()
        {
          

            try
            {
               


                Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
                reportParametersDictionary.Add("Id", _PrimaryKeyMain.ToString());
               
                Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("rptStudentProfile", reportParametersDictionary);
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
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

        private void cbardef_SaveClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Save.GetHashCode();

                if (SaveRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, _CurrentStatus);
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


                
                Frontend.DBML.Student_Profile obj = null;

               
                obj = CDB.Student_Profiles.SingleOrDefault(where=>where.Id==_PrimaryKeyMain);
                CDB.Student_Profiles.DeleteOnSubmit(obj);

                CDB.SubmitChanges();


                objCommon.Log_Master(obj.Id, 0, "", Constants.PRM_StudentProfile, Constants.PRM_StudentProfile, _CurrentAction, DateTime.Now);
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

        private void cbardef_SearchClicked()
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            clsCommon objCommon = new clsCommon();
            try
            {

                
                Frontend.Parameter.SearchForm.SearchStudentProfile objfrmSearch=new Frontend.Parameter.SearchForm.SearchStudentProfile(parentPageSearchList, "StudentProfile");
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

        private void cbardef_DeleteClicked()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 
                _CurrentAction = Constants.Action.Delete.GetHashCode();
                if (DeleteRecord())
                {
                    this.cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, _CurrentStatus);
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
        private DataSet LoadData(long Id)
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            DataSet dataSet = null;
            string sSQL = string.Empty;
            try
            {


                sSQL = "select Id,Name,CNIC,FName,StudyClassId,AdmissionClassId,SecId,Remarks,GuardianName,GuardianRelationId  " +
                    " ,GRNo,ReligionId,CasteId,DOB,PlaceOBCityId,LastSchoolId,ProfessionId,PermAdress,PermMobileNo,PermPhoneNo"+
                    " ,PresentAddress,PresentMobileNo,PresentPhoneNo,OfficeAddress,OfficeMobileNo,OfficePhoneNo,Email"+
                    " ,RollNo,GenderId,Pic,CurrentStatus,ActionTypeId from dbo.Student_Profile" +
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
        void showdata()
        {

            string sql = "select Isnull(Pic,'') as Pic from Student_Profile where id=" + _PrimaryKeyMain;

            ds = objDBHelper.GetDataSet(sql);

            if (ds.Tables[0].Rows.Count > 0)
            {

                pictureBox1.Image = null;



                DataRow r = ds.Tables[0].Rows[0] as DataRow;
                byte[] image = (byte[])(r["pic"]);

                

                MemoryStream ms = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(ms);
                

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
                dsDisplay = LoadData(Id);
                if (dsDisplay != null)
                    if (dsDisplay.Tables[0].Rows.Count > 0)
                    {
                        _PrimaryKeyMain = dsDisplay.Tables[0].Rows[0]["Id"].ToString().ConvertTo<long>();
                        _CurrentStatus = dsDisplay.Tables[0].Rows[0]["CurrentStatus"].ToString().ConvertTo<int>();

                        gr.Text = _PrimaryKeyMain.ToString() ;

                        if (dsDisplay.Tables[0].Rows[0]["Name"] != System.DBNull.Value)
                            tbName.Text = dsDisplay.Tables[0].Rows[0]["Name"].ToString();
                        

                        if (dsDisplay.Tables[0].Rows[0]["Remarks"] != System.DBNull.Value)
                            tbRemarks.Text = dsDisplay.Tables[0].Rows[0]["Remarks"].ToString();

                        if (dsDisplay.Tables[0].Rows[0]["CNIC"] != System.DBNull.Value)
                            tbCnic.Text = dsDisplay.Tables[0].Rows[0]["CNIC"].ToString();

                        if (dsDisplay.Tables[0].Rows[0]["FName"] != System.DBNull.Value)
                            tbFatherName.Text = dsDisplay.Tables[0].Rows[0]["FName"].ToString();

                        if (dsDisplay.Tables[0].Rows[0]["GuardianName"] != System.DBNull.Value)
                            tbGuardName.Text = dsDisplay.Tables[0].Rows[0]["GuardianName"].ToString();

                        
                        
                            if (dsDisplay.Tables[0].Rows[0]["GRNo"] != System.DBNull.Value)
                            tbGrNo.Text = dsDisplay.Tables[0].Rows[0]["GRNo"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["PermAdress"] != System.DBNull.Value)
                                tbPAddress.Text = dsDisplay.Tables[0].Rows[0]["PermAdress"].ToString();


                            if (dsDisplay.Tables[0].Rows[0]["PermMobileNo"] != System.DBNull.Value)
                                tbPerMobileNo.Text = dsDisplay.Tables[0].Rows[0]["PermMobileNo"].ToString();


                            if (dsDisplay.Tables[0].Rows[0]["PermPhoneNo"] != System.DBNull.Value)
                                tbPerPhoneNo.Text = dsDisplay.Tables[0].Rows[0]["PermPhoneNo"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["PresentAddress"] != System.DBNull.Value)
                                tbPresAddress.Text = dsDisplay.Tables[0].Rows[0]["PresentAddress"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["PresentMobileNo"] != System.DBNull.Value)
                                tbPreMobileNo.Text = dsDisplay.Tables[0].Rows[0]["PresentMobileNo"].ToString();



                            if (dsDisplay.Tables[0].Rows[0]["PresentPhoneNo"] != System.DBNull.Value)
                                tbPresPhone.Text = dsDisplay.Tables[0].Rows[0]["PresentPhoneNo"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["OfficeAddress"] != System.DBNull.Value)
                                tbOfficeAddress.Text = dsDisplay.Tables[0].Rows[0]["OfficeAddress"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["OfficeMobileNo"] != System.DBNull.Value)
                                tbOfficeMobileNo.Text = dsDisplay.Tables[0].Rows[0]["OfficeMobileNo"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["OfficePhoneNo"] != System.DBNull.Value)
                                tbOfficePhoneNo.Text = dsDisplay.Tables[0].Rows[0]["OfficePhoneNo"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["Email"] != System.DBNull.Value)
                                tbEmail.Text = dsDisplay.Tables[0].Rows[0]["Email"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["StudyClassId"] != System.DBNull.Value)
                                cbStClass.SelectedValue = dsDisplay.Tables[0].Rows[0]["StudyClassId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["AdmissionClassId"] != System.DBNull.Value)
                                cbAdClass.SelectedValue = dsDisplay.Tables[0].Rows[0]["AdmissionClassId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["SecId"] != System.DBNull.Value)
                                cbSection.SelectedValue = dsDisplay.Tables[0].Rows[0]["SecId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["GuardianRelationId"] != System.DBNull.Value)
                                cbGuardRelation.SelectedValue = dsDisplay.Tables[0].Rows[0]["GuardianRelationId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["ReligionId"] != System.DBNull.Value)
                                cbReligion.SelectedValue = dsDisplay.Tables[0].Rows[0]["ReligionId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["CasteId"] != System.DBNull.Value)
                                cbCaste.SelectedValue = dsDisplay.Tables[0].Rows[0]["CasteId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["PlaceOBCityId"] != System.DBNull.Value)
                                cbPoB.SelectedValue = dsDisplay.Tables[0].Rows[0]["PlaceOBCityId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["LastSchoolId"] != System.DBNull.Value)
                                cbSchool.SelectedValue = dsDisplay.Tables[0].Rows[0]["LastSchoolId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["ProfessionId"] != System.DBNull.Value)
                                cbFGProff.SelectedValue = dsDisplay.Tables[0].Rows[0]["ProfessionId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["GenderId"] != System.DBNull.Value)
                                cbGender.SelectedValue = dsDisplay.Tables[0].Rows[0]["GenderId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["ActionTypeId"] != System.DBNull.Value)
                                cbTransaction.SelectedValue = dsDisplay.Tables[0].Rows[0]["ActionTypeId"].ToString();

                            if (dsDisplay.Tables[0].Rows[0]["DOB"] != System.DBNull.Value)
                                dpDob.Value = dsDisplay.Tables[0].Rows[0]["DOB"].ToString().ConvertTo<DateTime>();

                            if (dsDisplay.Tables[0].Rows[0]["Pic"] != System.DBNull.Value)
                               // tbPresPhone.Text = dsDisplay.Tables[0].Rows[0]["Pic"].ToString();
                            showdata();

                        
                       }


               


                _isAnyFieldChanged = false;
                _isNewRecord = false;


                cbardef.AdjustToolBarButtons(Constants.PRM_StudentProfile, Frontend.Common.Global.UserId, _CurrentStatus);
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

        
    }
}
