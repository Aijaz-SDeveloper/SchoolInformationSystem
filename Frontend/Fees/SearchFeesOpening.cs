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
    public partial class SearchFeesOpening : Form
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
            Date = 2,
            FeesType = 3,
            Amount = 4,
            IsOpening = 5
        };
        public SearchFeesOpening(List<clsSearchParameter> _searchArraylist, string CallingForm)
        {
            InitializeComponent();
            LoadFeesType();
            ConfigureSearchGrid();
        }
        public void LoadFeesType()
        {
            cbFeesType.DisplayMember = "Description";
            cbFeesType.ValueMember = "Id";


            cbFeesType.DataSource = new dbSQLHelper().GetDataSet(" Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type in (12)").Tables[0];

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

                this.Text = "Search Fee Opening";
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
        public string GetSearchQuery(bool _isCalledFromParent)
        {
            string strQuery = string.Empty;
            try
            {
                if (chBIsActive.Checked == true)
                {
                    if (_isCallfromAnalysis)
                        strQuery = "Select Id,FeeId,StId,AssignmentDate,OpeningAmount,IsOpening,CurrentStatusId,ActionDate,  " +
                       " dbo.ufn_GetStateName(CurrentStatusId) as State, Description from dbo.Fees_Assignment where 1=1";


                    if (_callFromParent && !_isCallfromAnalysis)

                        strQuery = "Select Id,FeeId,StId,AssignmentDate,OpeningAmount,IsOpening,CurrentStatusId,ActionDate,  " +
                        " dbo.ufn_GetStateName(CurrentStatusId) as State, Description from dbo.Fees_Assignment where 1=1";

                    else if (!_callFromParent && !_isCallfromAnalysis)
                        strQuery = "Select Id,FeeId,StId,AssignmentDate,OpeningAmount,IsOpening,CurrentStatusId,ActionDate,  " +
                       " dbo.ufn_GetStateName(CurrentStatusId) as State, Description from dbo.Fees_Assignment where 1=1";



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

                        if (tbAmount.Text.Trim() != string.Empty
                         && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Amount.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND OpeningAmount='" + tbAmount.Text.Trim().ToString().ConvertTo<decimal>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), tbAmount.Text.Trim().ToString().Trim()));
                        }

                        if (dpAssignmentDate.Checked
                             && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Date.GetHashCode()) == null)
                        {

                            strQuery = strQuery + " AND Cast( convert(varchar(15),AssignmentDate,106)+ ' 00:00:00.000' as datetime) = '" + dpAssignmentDate.Value.ToString("dd-MMM-yyyy") + "'";

                            listSearch.Add(new clsSearchParameter(searchParameter.Date.GetHashCode(), dpAssignmentDate.Value.ToString()));
                        }
                       
                        if (chBIsActive.Checked == true
                                           && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.IsOpening.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND IsOpening='1'";

                        }



                    }
                }
                else
                {
                    strQuery = "Select Id,FeeId,StId,OpeningAmount,0 as IsOpening,CurrentStatusId,ActionDate,dbo.ufn_GetStateName(CurrentStatusId) as State,  " +
                      " Description from dbo.Fees_Open where 1=1";
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

                        if (tbAmount.Text.Trim() != string.Empty
                         && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Amount.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND OpeningAmount='" + tbAmount.Text.Trim().ToString().ConvertTo<decimal>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), tbAmount.Text.Trim().ToString().Trim()));
                        }

                        if (dpAssignmentDate.Checked
                             && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Date.GetHashCode()) == null)
                        {

                            strQuery = strQuery + " AND Cast( convert(varchar(15),ActionDate,106)+ ' 00:00:00.000' as datetime) = '" + dpAssignmentDate.Value.ToString("dd-MMM-yyyy") + "'";

                            listSearch.Add(new clsSearchParameter(searchParameter.Date.GetHashCode(), dpAssignmentDate.Value.ToString()));
                        }

                        



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
            this.cbFeesType.SelectedIndex = 0;
            dpAssignmentDate.Checked = false;
            tbAmount.Text = string.Empty;
            chBIsActive.Checked = false;

            tbStNo.Focus();
        }
    }
}
