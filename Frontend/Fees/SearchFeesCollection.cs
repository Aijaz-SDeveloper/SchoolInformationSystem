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
    public partial class SearchFeesCollection : Form
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
            Class = 3,
            Amount = 4
        };
        public SearchFeesCollection(List<clsSearchParameter> _searchArraylist, string CallingForm)
        {
            InitializeComponent();
            LoadClass();
            ConfigureSearchGrid();
        }
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";
            


            cbClass.DataSource = new dbSQLHelper().GetDataSet(" Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type in (1)").Tables[0];

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

                this.Text = "Search Fee Collection";
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
                
                    if (_isCallfromAnalysis)
                        strQuery = " Select Fees_Collection.Id,TotalAmount,StId,PaidDate,CurrentStatusId,Fees_Collection.Remarks,ActionDate,  " +
                       "  dbo.ufn_GetStateName(CurrentStatusId) as State from Fees_Collection inner join Student_Profile on Fees_Collection.StId=Student_Profile.Id where 1=1";


                    if (_callFromParent && !_isCallfromAnalysis)

                        strQuery = " Select Fees_Collection.Id,TotalAmount,StId,PaidDate,CurrentStatusId,Fees_Collection.Remarks,ActionDate,  " +
                       "  dbo.ufn_GetStateName(CurrentStatusId) as State from Fees_Collection inner join Student_Profile on Fees_Collection.StId=Student_Profile.Id where 1=1";

                    else if (!_callFromParent && !_isCallfromAnalysis)
                        strQuery = " Select Fees_Collection.Id,TotalAmount,StId,PaidDate,CurrentStatusId,Fees_Collection.Remarks,ActionDate,  " +
                       "  dbo.ufn_GetStateName(CurrentStatusId) as State from Fees_Collection inner join Student_Profile on Fees_Collection.StId=Student_Profile.Id where 1=1";



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

                        


                        if (cbClass.SelectedValue.ToString().Trim() != "0"
                          && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Class.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND AdmissionClassId ='" + cbClass.SelectedValue.ToString().ConvertTo<long>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.Class.GetHashCode(), cbClass.SelectedValue.ToString().Trim()));
                        }

                        if (tbAmount.Text.Trim() != string.Empty
                         && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Amount.GetHashCode()) == null)
                        {
                            strQuery = strQuery + " AND TotalAmount='" + tbAmount.Text.Trim().ToString().ConvertTo<decimal>() + "'";
                            listSearch.Add(new clsSearchParameter(searchParameter.StNo.GetHashCode(), tbAmount.Text.Trim().ToString().Trim()));
                        }

                        if (dpAssignmentDate.Checked
                             && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.Date.GetHashCode()) == null)
                        {

                            strQuery = strQuery + " AND Cast( convert(varchar(15),PaidDate,106)+ ' 00:00:00.000' as datetime) = '" + dpAssignmentDate.Value.ToString("dd-MMM-yyyy") + "'";

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
            dpAssignmentDate.Checked = false;
            tbAmount.Text = string.Empty;
           

            tbStNo.Focus();
        }

        private void gvSearch_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowChanged();
        }

        private void gvSearch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
