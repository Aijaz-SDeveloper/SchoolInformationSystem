using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace Frontend.Fees
{
    public partial class SearchFeesIndividualProcess : Form
    {
        string errorMessage = string.Empty;
        int totalRecord = 0;
        int selectedRowIndex = 0;
        public long selectedRecordId = -1;
        bool _callFromParent = false;
        bool _isCallfromAnalysis = false;
        clsCommon objCommon = new clsCommon();

        public List<clsSearchParameter> listSearch = new List<clsSearchParameter>();
        public enum searchParameter
        {
            StNo = 1,
            Date = 2,
            FeesType = 3,
            Amount = 4,
            Month=5,
            Year=6
        };
        public SearchFeesIndividualProcess(List<clsSearchParameter> _searchArraylist, string CallingForm)
        {
            InitializeComponent();
            LoadFeesType();
            ConfigureSearchGrid();
            FillMonth();
            FillYear();
            LoadClass();
            
            cbYear.SelectedItem = System.DateTime.Now.Year.ToString();
            
        }
        protected void FillYear()
        {


            
            //cbYear.DisplayMember = "Description";
            //cbYear.ValueMember = "Id";


            //cbYear.DataSource = new dbSQLHelper().GetDataSet(" Exec GetYear").Tables[0];


            cbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            //string strQuery = "Exec GetYear ";
            //objCommon.FillCombo(ref cbYear, ref  strQuery, "Description", "Id");
            objCommon.FillYear(ref cbYear);



        }
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";


            cbClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadFeesType()
        {
            cbFeesType.DisplayMember = "Description";
            cbFeesType.ValueMember = "Id";


            cbFeesType.DataSource = new dbSQLHelper().GetDataSet(" Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type in (12)").Tables[0];
            cbFeesType.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        protected void FillMonth()
        {
            string sql = " SELECT 0 as Id, '--Select--' as Description union Select 1 as Id,'Jaunary' as Description ";

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
            cbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
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

                this.Text = "Search Individual Fees Process";
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        public string GetSearchQuery(bool _isCalledFromParent)
        {
            string strQuery = string.Empty;
            try
            {
                
                    if (_isCallfromAnalysis)
                        strQuery = "Select Id,FeeId,StId,AssignmentDate,OpeningAmount,IsOpening,CurrentStatusId,ActionDate,  " +
                       " dbo.ufn_GetStateName(CurrentStatusId) as State, Description from dbo.Fees_Assignment where 1=1";


                    if (_callFromParent && !_isCallfromAnalysis)

                        strQuery = "Select Id,FeeId,StId,AssignmentDate,OpeningAmount,IsOpening,CurrentStatusId,ActionDate,  " +
                        " dbo.ufn_GetStateName(CurrentStatusId) as State, Description from dbo.Fees_Assignment where  IsOpening='0'";

                    else if (!_callFromParent && !_isCallfromAnalysis)
                        strQuery = "Select Id,FeeId,StId,AssignmentDate,OpeningAmount,IsOpening,CurrentStatusId,ActionDate,  " +
                       " dbo.ufn_GetStateName(CurrentStatusId) as State, Description from dbo.Fees_Assignment where  IsOpening='0'";



                    if (!_isCalledFromParent)
                    {

                        if (tbStNo.Text != string.Empty
                            && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.StNo.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND StId = " + tbStNo.Text.ToString() + "";
                            listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), tbStNo.Text.Trim()));
                        }
                        else
                        {
                            clsSearchParameter objParameter = listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.StNo.GetHashCode());
                            if (objParameter != null)
                            {
                                if (tbStNo.Text.Trim() != string.Empty)
                                {
                                    strQuery = strQuery + " AND StId=" + tbStNo.Text.Trim().ToString().ConvertTo<long>() + "";
                                    objParameter.SetParamterValue(tbStNo.Text);
                                }
                                else
                                    objParameter.SetParamterValue(tbStNo.Text.Trim());
                            }
                            else if (tbStNo.Text.Trim() == string.Empty)
                                listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), tbStNo.Text.Trim()));
                        }




                        if (cbFeesType.SelectedValue.ToString().Trim() != "0"
                          && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.FeesType.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND FeeId ='" + cbFeesType.SelectedValue.ToString().ConvertTo<long>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.FeesType.GetHashCode(), cbFeesType.SelectedValue.ToString().Trim()));
                        }
                        
                        if (cbMonth.SelectedValue.ToString().Trim() != "0"
                         && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Month.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND Month ='" + cbMonth.SelectedValue.ToString().ConvertTo<long>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.Month.GetHashCode(), cbMonth.SelectedValue.ToString().Trim()));
                        }
                        
                        if (cbYear.SelectedValue.ToString().Trim() != "0"
                        && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Year.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND Year ='" + this.cbYear.Text.ToString().ConvertTo<long>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.Year.GetHashCode(), cbYear.SelectedItem.ToString().Trim()));
                        }
                       
                        if (cbClass.SelectedValue.ToString().Trim() != "0"
                         && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Amount.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " and StId in (Select Id from Student_Profile where AdmissionClassId='" + cbClass.SelectedValue.ToString().Trim().ConvertTo<decimal>() + "')";
                            listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), cbClass.SelectedValue.ToString().Trim().Trim()));
                        }

                        if (dpAssignmentDate.Checked
                             && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Date.GetHashCode()) == null)
                        {

                            strQuery = strQuery + " AND Cast( convert(varchar(15),AssignmentDate,106)+ ' 00:00:00.000' as datetime) = '" + dpAssignmentDate.Value.ToString("dd-MMM-yyyy") + "'";

                            listSearch.Add(new clsSearchParameter(searchParameter.Date.GetHashCode(), dpAssignmentDate.Value.ToString()));
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

        private void gvSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void gvSearch_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowChanged();
        }

        private void SearchToolBar_ClearClicked()
        {
            errorMessage = string.Empty;
            totalRecord = 0;
            selectedRowIndex = 0;
            selectedRecordId = -1;

            gvSearch.DataSource = null;
            tbStNo.Text = string.Empty;
            this.cbFeesType.SelectedIndex = 0;
            dpAssignmentDate.Checked = false;
            
            this.cbMonth.SelectedIndex = 0;
            this.cbYear.SelectedIndex = 0;
            this.cbClass.SelectedIndex = 0;
            
            


            tbStNo.Focus();
        
        }
    }
}
