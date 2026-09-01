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
    public partial class SearchParametrs : Form
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
            Name = 1,
            Type = 2
        };
        public SearchParametrs(List<clsSearchParameter> _searchArraylist, bool callFrom, bool _isFromAnalysis)
        {
            InitializeComponent();
            LoadTypes();
            ConfigureSearchGrid();
        }
        public void LoadTypes()
        {
            cbParamType.DisplayMember = "Description";
            cbParamType.ValueMember = "Id";


            cbParamType.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from dbo.ComParameterType").Tables[0];
            



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

                this.Text = "Search Parameter";
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
                    strQuery = " Select Id,Description,Type,CurrentStatusId,Remarks,dbo.ufn_GetStateName(CurrentStatusId) as State from dbo.ComParameters where 1=1 ";
                if (_callFromParent && !_isCallfromAnalysis)
                    strQuery = " Select Id,Description,Type,CurrentStatusId,Remarks,dbo.ufn_GetStateName(CurrentStatusId) as State from dbo.ComParameters where 1=1";
                else if (!_callFromParent && !_isCallfromAnalysis)
                    strQuery = " Select Id,Description,Type,CurrentStatusId,Remarks,dbo.ufn_GetStateName(CurrentStatusId) as State from dbo.ComParameters where CurrentStatusId=" + Constants.State.Approved.GetHashCode();
                    

                
                if (!_isCalledFromParent)
                {

                    if (tbName.Text.Trim() != string.Empty
                        && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Name.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND Description like ('%" + tbName.Text.Trim().ToString().ConvertTo<long>() + "%')";
                        listSearch.Add(new clsSearchParameter(searchParameter.Name.GetHashCode(), tbName.Text.Trim()));
                    }
                    else
                    {
                        clsSearchParameter objParameter = listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Name.GetHashCode());
                        if (objParameter != null)
                        {
                            if (tbName.Text.Trim() != string.Empty)
                            {
                                strQuery = strQuery + " AND Description like ('%" + tbName.Text.Trim().ToString().ConvertTo<long>() + "%')";
                                objParameter.SetParamterValue(tbName.Text);
                            }
                            else
                                objParameter.SetParamterValue(tbName.Text.Trim());
                        }
                        else if (tbName.Text.Trim() == string.Empty)
                            listSearch.Add(new clsSearchParameter(searchParameter.Name.GetHashCode(), tbName.Text.Trim()));
                    }




                    if (cbParamType.SelectedValue.ToString().Trim() != "0"
                      && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Type.GetHashCode()) == null)
                    {
                        strQuery = strQuery + " AND Type='" + cbParamType.SelectedValue.ToString().ConvertTo<long>() + "'";
                        listSearch.Add(new clsSearchParameter(searchParameter.Type.GetHashCode(), cbParamType.SelectedValue.ToString().Trim()));
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

        private void SearchToolBar_ClearClicked()
        {
            errorMessage = string.Empty;
            totalRecord = 0;
            selectedRowIndex = 0;
            selectedRecordId = -1;

            gvSearch.DataSource = null;
            tbName.Text = string.Empty;
            this.cbParamType.SelectedIndex = 0;
        
            tbName.Focus();
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

       
    }
}
