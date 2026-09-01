using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using BusinessLogic;
using System.Windows.Forms;

namespace Frontend.Parameter.SearchForm
{
    public partial class frmSearchYear : Form
    {
        string errorMessage = string.Empty;
        int totalRecord = 0;
        int selectedRowIndex = 0;
        public long selectedRecordId = -1;

        public List<clsSearchParameter> listSearch = new List<clsSearchParameter>();
        public enum searchParameter
        {
            YearName = 1,
            FromDate = 2
        };

        public frmSearchYear(List<clsSearchParameter> _searchArraylist)
        {
            InitializeComponent();
            ConfigureSearchGrid();
        }
        public string GetSearchQuery(bool _isCalledFromParent)
        {
            string strQuery = string.Empty;
            try
            {
                strQuery = " Select Id,Convert(varchar(12),fromdate,106) as [From Date],Convert(varchar(12),todate,106) as [To Date],YearName as  [Year Name],dbo.ufn_GetStateName(CurrentStatusId) as State from YearDefination Where 1=1";

                if (!_isCalledFromParent)
                {
                    
                    if (tbYearName.Text.Trim() != string.Empty
                        && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.YearName.GetHashCode()) == null)
                    {

                        strQuery = strQuery + " AND YearName = '" + tbYearName.Text.Trim() + "'";
                        listSearch.Add(new clsSearchParameter(searchParameter.YearName.GetHashCode(), tbYearName.Text.Trim()));
                    }
                    else
                    {
                        clsSearchParameter objParameter = listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.YearName.GetHashCode());
                        if (objParameter != null)
                        {
                            if (tbYearName.Text.Trim() != string.Empty)
                            {
                                strQuery = strQuery + " AND YearName = '" + tbYearName.Text.Trim() + "'";
                                objParameter.SetParamterValue(tbYearName.Text.Trim());
                            }
                            else
                                objParameter.SetParamterValue(tbYearName.Text.Trim());
                        }
                        else if (tbYearName.Text.Trim() == string.Empty)
                            listSearch.Add(new clsSearchParameter(searchParameter.YearName.GetHashCode(), tbYearName.Text.Trim()));


                    }

                    if (dpFromDate.Checked
                        && listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.FromDate.GetHashCode()) == null)
                    {

                        strQuery = strQuery + " AND Cast( convert(varchar(15),fromdate,106)+ ' 00:00:00.000' as datetime) = '" + dpFromDate.Value.ToString("dd-MMM-yyyy") + "'";
                               
                        listSearch.Add(new clsSearchParameter(searchParameter.FromDate.GetHashCode(), dpFromDate.Value.ToString()));
                    }
                    else
                    {
                        clsSearchParameter objParameter = listSearch.SingleOrDefault(where => where.GetParameterID() == searchParameter.FromDate.GetHashCode());
                        if (objParameter != null)
                        {
                            if (dpFromDate.Checked)
                            {
                                strQuery = strQuery + " AND Cast( convert(varchar(15),fromdate,106)+ ' 00:00:00.000' as datetime) = '" + dpFromDate.Value.ToString() + "'";
                                objParameter.SetParamterValue(dpFromDate.Value.ToString());
                            }
                            else
                                objParameter.SetParamterValue(string.Empty);
                        }
                        else if (dpFromDate.Checked)
                            listSearch.Add(new clsSearchParameter(searchParameter.FromDate.GetHashCode(), dpFromDate.Value.ToString()));


                    }


                }


                //if (dpFromDate.Value  != null)
                //    strQuery = strQuery + " AND fromdate='" + dpFromDate.Value.ToString("dd-MMM-yyyy") + "'";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                gvSearchSeason.AllowUserToAddRows = false;
                gvSearchSeason.AllowUserToDeleteRows = false;
                gvSearchSeason.AllowUserToOrderColumns = true;
                gvSearchSeason.MultiSelect = false;
                gvSearchSeason.ReadOnly = true;

                gvSearchSeason.AutoResizeColumns();
                gvSearchSeason.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                gvSearchSeason.SelectionChanged += new EventHandler(gvSearchSeason_SelectionChanged);
                gvSearchSeason.MouseDoubleClick += new MouseEventHandler(gvSearchSeason_MouseDoubleClick);

                ////                Form Settings

                this.Text = "Search Year";
                this.MaximizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        private void gvSearchSeason_SelectionChanged(object sender, EventArgs e)
        {
            SelectedRowChanged();

        }

        private void gvSearchSeason_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Close();

        }
        protected void SelectedRowChanged()
        {
            totalRecord = gvSearchSeason.Rows.Count;

            if (gvSearchSeason.CurrentRow != null)
                selectedRowIndex = gvSearchSeason.CurrentRow.Index + 1;

            tssSearchAction.Text = "Record " + selectedRowIndex.ToString() + " / " + totalRecord.ToString();
            if (selectedRowIndex != 0)
            {
                if (gvSearchSeason.CurrentRow != null)
                {
                    selectedRecordId = gvSearchSeason.CurrentRow.Cells[0].Value.ToString().ConvertTo<long>();
                    tssRecord.Text = gvSearchSeason.CurrentRow.Cells[4].Value.ToString();
                }
            }
        }

        private void seasonSearchToolBar_SeachDetailClicked()
        {
            dbSQLHelper objHelper = new dbSQLHelper();
            BindingSource bsource = new BindingSource();
            DataSet dsResult = new DataSet();
            try
            {
                string strSql = GetSearchQuery(false);
                dsResult = objHelper.GetDataSet(strSql);
                gvSearchSeason.DataSource = dsResult.Tables[0];
                gvSearchSeason.Columns["Id"].Visible = false;
                gvSearchSeason.Columns["State"].Visible = false;
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

        private void seasonSearchToolBar_ShowDetailClicked()
        {
            this.Close();
        }

        private void seasonSearchToolBar_ClearClicked()
        {
            errorMessage = string.Empty;
            totalRecord = 0;
            selectedRowIndex = 0;
            selectedRecordId = -1;

            gvSearchSeason.DataSource = null;
            tbYearName.Text = string.Empty;
            dpFromDate.Checked = false;
            dpFromDate.Value = DateTime.Now;
        }
    }
}
