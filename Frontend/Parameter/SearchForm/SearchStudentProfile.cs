using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace Frontend.Parameter.SearchForm
{
    public partial class SearchStudentProfile : Form
    {
        string errorMessage = string.Empty;
        int totalRecord = 0;
        int selectedRowIndex = 0;
        public long selectedRecordId = -1;
        bool _callFromParent = false;
        bool _isCallfromAnalysis = false;

        public List<clsSearchParameter> listSearch = new List<clsSearchParameter>();
        public enum searchParameter
        {
            StNo = 1,
            Name = 2,
            CNIC=3,
            Class=4,
            IsActive=5
        };
        public SearchStudentProfile(List<clsSearchParameter> _searchArraylist, string CallingForm)
        {
            InitializeComponent();
            LoadClass();
            ConfigureSearchGrid();
        }
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";


            cbClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];

        }
        public string GetSearchQuery(bool _isCalledFromParent)
        {
            string strQuery = string.Empty;
            try
            {
                if (_isCallfromAnalysis)
                    strQuery = "select Id,Name,CNIC,FName,StudyClassId,AdmissionClassId,SecId,Remarks,GuardianName,dbo.ufn_GetStateName(CurrentStatus) as State,GuardianRelationId  " +
                   " ,GRNo,ReligionId,CasteId,DOB,PlaceOBCityId,LastSchoolId,ProfessionId,PermAdress,PermMobileNo,PermPhoneNo" +
                   " ,PresentAddress,PresentMobileNo,PresentPhoneNo,OfficeAddress,OfficeMobileNo,OfficePhoneNo,Email" +
                   " ,RollNo,GenderId,CurrentStatus from dbo.Student_Profile where 1=1";
                    

                
                if (_callFromParent && !_isCallfromAnalysis)

                    strQuery = "select Id,Name,CNIC,FName,StudyClassId,AdmissionClassId,SecId,Remarks,GuardianName,dbo.ufn_GetStateName(CurrentStatus) as State,GuardianRelationId  " +
                  " ,GRNo,ReligionId,CasteId,DOB,PlaceOBCityId,LastSchoolId,ProfessionId,PermAdress,PermMobileNo,PermPhoneNo" +
                  " ,PresentAddress,PresentMobileNo,PresentPhoneNo,OfficeAddress,OfficeMobileNo,OfficePhoneNo,Email" +
                  " ,RollNo,GenderId,CurrentStatus from dbo.Student_Profile where 1=1";
                   
                else if (!_callFromParent && !_isCallfromAnalysis)
                    strQuery = "select Id,Name,CNIC,FName,StudyClassId,AdmissionClassId,SecId,Remarks,GuardianName,dbo.ufn_GetStateName(CurrentStatus) as State,GuardianRelationId  " +
                  " ,GRNo,ReligionId,CasteId,DOB,PlaceOBCityId,LastSchoolId,ProfessionId,PermAdress,PermMobileNo,PermPhoneNo" +
                  " ,PresentAddress,PresentMobileNo,PresentPhoneNo,OfficeAddress,OfficeMobileNo,OfficePhoneNo,Email" +
                  " ,RollNo,GenderId,CurrentStatus from dbo.Student_Profile where 1=1";
                   


                if (!_isCalledFromParent)
                {

                    if (tbName.Text != string.Empty
                        && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Name.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND Name like ('%" + tbName.Text.ToString() + "%')";
                        listSearch.Add(new clsSearchParameter(searchParameter.Name.GetHashCode(), tbName.Text.Trim()));
                    }
                    else
                    {
                        clsSearchParameter objParameter = listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Name.GetHashCode());
                        if (objParameter != null)
                        {
                            if (tbName.Text.Trim() != string.Empty)
                            {
                                strQuery = strQuery + " AND Name like ('%" + tbName.Text.Trim().ToString().ConvertTo<long>() + "%')";
                                objParameter.SetParamterValue(tbName.Text);
                            }
                            else
                                objParameter.SetParamterValue(tbName.Text.Trim());
                        }
                        else if (tbName.Text.Trim() == string.Empty)
                            listSearch.Add(new clsSearchParameter(searchParameter.Name.GetHashCode(), tbName.Text.Trim()));
                    }




                    if (cbClass.SelectedValue.ToString().Trim() != "0"
                      && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Class.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND AdmissionClassId ='" + cbClass.SelectedValue.ToString().ConvertTo<long>() + "'";
                        listSearch.Add(new clsSearchParameter(searchParameter.Class.GetHashCode(), cbClass.SelectedValue.ToString().Trim()));
                    }

                    if (tbStNo.Text.Trim() != string.Empty
                     && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Class.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND Id='" + tbStNo.Text.Trim().ToString().ConvertTo<long>() + "'";
                        listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), tbStNo.Text.Trim().ToString().Trim()));
                    }

                    if (tbCnic.Text.Trim() != string.Empty
                    && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.CNIC.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND CNIC='" + tbCnic.Text.Trim().ToString() + "'";
                        listSearch.Add(new clsSearchParameter(searchParameter.CNIC.GetHashCode(), tbCnic.Text.Trim().ToString().Trim()));
                    }
                    if (chBIsActive.Checked == false
                                        && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.IsActive.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND IsActive='0'";
                        
                    }
                    if (chBIsActive.Checked == true
                                       && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.IsActive.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND IsActive='1'";

                    }
                    


                }



            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
            }



            return strQuery;

        }
        protected void ConfigureSearchGrid()
        {

            try
            {
                gvSearch.AllowUserToAddRows = false;
                gvSearch.AllowUserToDeleteRows = false;
                gvSearch.AllowUserToOrderColumns = true;
                gvSearch.MultiSelect = false;
                gvSearch.ReadOnly = true;

                gvSearch.AutoResizeColumns();
                gvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                gvSearch.SelectionChanged += new EventHandler(gvSearch_SelectionChanged);
                gvSearch.MouseDoubleClick += new MouseEventHandler(gvSearch_MouseDoubleClick);

                ////                Form Settings

                this.Text = "Search Student Profile";
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        protected void SelectedRowChanged()
        {
            totalRecord = gvSearch.Rows.Count;

            if (gvSearch.CurrentRow != null)
                selectedRowIndex = gvSearch.CurrentRow.Index + 1;

            tssSearchAction.Text = "Record " + selectedRowIndex.ToString() + " / " + totalRecord.ToString();
            if (selectedRowIndex != 0)
            {
                if (gvSearch.CurrentRow != null)
                {
                    selectedRecordId = gvSearch.CurrentRow.Cells[0].Value.ToString().ConvertTo<long>();
                    //tssRecord.Text = gvSearch.CurrentRow.Cells[7].Value.ToString();
                }
            }
        }

        private void gvSearch_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowChanged();

        }

        private void gvSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();

        }

        private void SearchToolBar_SeachDetailClicked()
        {
            dbSQLHelper objHelper = new dbSQLHelper();
            BindingSource bsource = new BindingSource();
            DataSet dsResult = new DataSet();
            try
            {
                string strSql = GetSearchQuery(false);
                dsResult = objHelper.GetDataSet(strSql);
                gvSearch.DataSource = dsResult.Tables[0];
                gvSearch.Columns["Id"].Visible = false;

                SelectedRowChanged();
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                objHelper.Dispose();
                bsource.Dispose();
                dsResult.Dispose();
            }
        }

        private void SearchToolBar_ShowDetailClicked()
        {
            this.Close();
        }

        private void SearchToolBar_ClearClicked()
        {
            errorMessage = string.Empty;
            totalRecord = 0;
            selectedRowIndex = 0;
            selectedRecordId = -1;

            gvSearch.DataSource = null;
            tbStNo.Text = string.Empty;
            this.cbClass.SelectedIndex = 0;
            tbName.Text = string.Empty;
            tbCnic.Text = string.Empty;
            chBIsActive.Checked = true;

            tbStNo.Focus();
        }
    }
}
