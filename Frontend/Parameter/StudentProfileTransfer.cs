using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace Frontend.Parameter
{
    public partial class StudentTransfer : Form
    {
        string errorMessage = "";
        clsCommon objCommon = new clsCommon();

        int TotalCheckBoxes = 0;
        int TotalCheckedCheckBoxes = 0;
        CheckBox HeaderCheckBox = null;
        bool IsHeaderCheckBoxClicked = false;


        public StudentTransfer()
        {
            InitializeComponent();
            ContructorInitialization();
        }
        public void ContructorInitialization()
        {

            clsSecurity objSecurity = new clsSecurity();
            try
            {
                LoadClass();
                LoadSection();

                LoadClassTo();
                LoadSectionTo();

                LoadSeperaion();


                cbClass.TabIndex = 1;
                cbSection.TabIndex = 2;
                ConfigureGrid();

                //btnAmendAll.Enabled = objSecurity.IsActionAllowed(Constants.PRM_ClassAMENDMENT, Frontend.Common.Global.UserId, Constants.Action.Amend.GetHashCode());




            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }


        }
        protected void ConfigureGrid()
        {

            try
            {
                gvGrid.AutoGenerateColumns = false;
                gvGrid.AllowUserToAddRows = false;
                gvGrid.AllowUserToDeleteRows = false;
                gvGrid.AllowUserToOrderColumns = true;
                gvGrid.MultiSelect = false;
                gvGrid.ReadOnly = false;


                gvGrid.AutoResizeColumns();
                gvGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                AddHeaderCheckBox();

                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);

                gvGrid.CurrentCellDirtyStateChanged += new EventHandler(gvGrid_CurrentCellDirtyStateChanged);
                gvGrid.CellPainting += new DataGridViewCellPaintingEventHandler(gvGrid_CellPainting);


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }
        private void AddHeaderCheckBox()
        {
            HeaderCheckBox = new CheckBox();

            HeaderCheckBox.Size = new Size(15, 15);

            //Add the CheckBox into the DataGridView
            this.gvGrid.Controls.Add(HeaderCheckBox);
        }
        private void gvGrid_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }
        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            //Get the column header cell bounds
            Rectangle oRectangle = this.gvGrid.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);

            Point oPoint = new Point();

            oPoint.X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1;
            oPoint.Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1;

            //Change the location of the CheckBox to make it stay on the header
            HeaderCheckBox.Location = oPoint;
        }
        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }
        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            IsHeaderCheckBoxClicked = true;

            foreach (DataGridViewRow Row in gvGrid.Rows)
                ((DataGridViewCheckBoxCell)Row.Cells["chkBox"]).Value = HCheckBox.Checked;

            gvGrid.RefreshEdit();

            TotalCheckedCheckBoxes = HCheckBox.Checked ? TotalCheckBoxes : 0;

            IsHeaderCheckBoxClicked = false;
        }
        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }
        private void gvGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gvGrid.CurrentCell is DataGridViewCheckBoxCell)
                gvGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";


            cbClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];
            cbClass.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadSection()
        {
            cbSection.DropDownStyle = ComboBoxStyle.DropDownList;
            string strQuery5 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 2 ";
            objCommon.FillCombo(ref cbSection, ref  strQuery5, "Description", "Id");
        }
        public void LoadClassTo()
        {
            cbToClass.DisplayMember = "Description";
            cbToClass.ValueMember = "Id";


            cbToClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];
            cbToClass.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void LoadSectionTo()
        {
            cbToSection.DropDownStyle = ComboBoxStyle.DropDownList;
            string strQuery5 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 2 ";
            objCommon.FillCombo(ref cbToSection, ref  strQuery5, "Description", "Id");
        }
        public void LoadSeperaion()
        {
            cbType.DropDownStyle = ComboBoxStyle.DropDownList;
            string strQuery5 = "Select 0 as id,'--Select--' as Description UNION Select Id,Description from dbo.ComParameters where Type = 13 and Id <> 139";
            objCommon.FillCombo(ref cbType, ref  strQuery5, "Description", "Id");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                //--------------- Businees Rules Checks ------------------// 

                LoadStudentInfo();


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                MessageBox.Show(Constants.ErrorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");

            }
            finally
            {
                objCommon.Dispose();
            }

        }
        protected void LoadStudentInfo()
        {
            //CaneDBDataContext CDB = new CaneDBDataContext();
            clsCommon objCommon = new clsCommon();
            try
            {

                string strQuer = "EXEC sp_SearchStudentProfile" + "'" + this.cbClass.SelectedValue.ToString() + "','" + this.cbSection.SelectedValue.ToString() + "','" + tbGrNo.Text + "'";
                bool hasRows = false;
                DataSet dsResult = (new dbSQLHelper().GetDataSet(strQuer));
                if (dsResult != null)
                    if (dsResult.Tables != null)
                        if (dsResult.Tables[0] != null)
                            if (dsResult.Tables[0].Rows.Count > 0)
                            {
                                gvGrid.DataSource = dsResult.Tables[0];
                                hasRows = true;
                            }


                if (!hasRows)
                    gvGrid.DataSource = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, Constants.ErrorMessage, "");


            }
            finally
            {

                objCommon.Dispose();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool _hasRecord = false;
            if (this.gvGrid.Rows.Count == 0)
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Search Student for Transfer.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            errorMessage = string.Empty;
            foreach (DataGridViewRow Row in gvGrid.Rows)
            {
                if ((bool)Row.Cells["chkBox"].FormattedValue)
                    _hasRecord = true;
            }
            if (!_hasRecord)
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Select Any Record For Amendment.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.cbToClass.SelectedIndex == 0)
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Select Class For Amendment.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if (this.cbSection.SelectedValue.ToString().ConvertTo<long>() == 0)
            //{
            //    errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Select Section For Amendment.";

            //    MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
           
            if (this.cbType.SelectedIndex == 0)
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Select Transaction Type For Amendment.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (tbFees.Text == "")
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease enter Monthly Fees.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GenerateStudentTransfer();

        }
        private void GenerateStudentTransfer()
        {
           
            string StudentId = "";
             dbSQLHelper objDBHelper = new dbSQLHelper();
            try
            {


                
               for (int k = 0; k < gvGrid.Rows.Count; k++)
                {
                    if (Convert.ToBoolean(gvGrid.Rows[k].Cells["chkBox"].FormattedValue))
                   
                   {
                        if (StudentId == "")
                        {
                            StudentId = StudentId + gvGrid.Rows[k].Cells[2].Value.ToString();
                        }
                        else
                        {

                            StudentId = StudentId + "," + gvGrid.Rows[k].Cells[2].Value.ToString();


                        }
                    }
                   
                }
           
               // MessageBox.Show(StudentId);
                string Class=this.cbToClass.SelectedValue.ToString();
                string Section = this.cbToSection.SelectedValue.ToString();
                string TransferType = this.cbType.SelectedValue.ToString();
                decimal MonthlyFees = tbFees.Text.ToString().ConvertTo<decimal>();
                string Remarks=tbRemarksTo.Text.ToString();

                string strQuery = " EXEC [Student_Transfer] " + "'" + StudentId + "','" + Class + "','" + Section + "','" + TransferType + "','" + MonthlyFees + "','" + Remarks+"'";
               // sSql = "exec [dbo].[Rpt_DailyScrollReport] " + "'" + FromDate + "','" + ToDate + "','" + Class + "'";
                   
                   
                bool dsResult = new dbSQLHelper().ExecuteCommand(strQuery);
                if (dsResult == true)
                {
                    MessageBox.Show("Student Transfer Successfully Completed.", "Success");
                }
                else
                {

                    MessageBox.Show("Student Transfer is not  Completed.", "");

                }




                 }
            catch (Exception ex)
            {
            }

              finally
            {
              
                objDBHelper.Dispose();
                objCommon.Dispose();
            }
        }
        private void GenerateStudentDelete()
        {

            string StudentId = "";
            dbSQLHelper objDBHelper = new dbSQLHelper();
            try
            {



                for (int k = 0; k < gvGrid.Rows.Count; k++)
                {
                    if (Convert.ToBoolean(gvGrid.Rows[k].Cells["chkBox"].FormattedValue))
                    {
                        if (StudentId == "")
                        {
                            StudentId = StudentId + gvGrid.Rows[k].Cells[2].Value.ToString();
                        }
                        else
                        {

                            StudentId = StudentId + "," + gvGrid.Rows[k].Cells[2].Value.ToString();


                        }
                    }

                }

                  string Remarks = tbRemarksTo.Text.ToString();

                string strQuery = " EXEC [Student_Delete] " + "'" + StudentId + "','" + Remarks + "'";
                // sSql = "exec [dbo].[Rpt_DailyScrollReport] " + "'" + FromDate + "','" + ToDate + "','" + Class + "'";


                bool dsResult = new dbSQLHelper().ExecuteCommand(strQuery);
                if (dsResult == true)
                {
                    MessageBox.Show("Student Delete is Successfully Completed.", "Success");
                }
                else
                {

                    MessageBox.Show("Student Delete is not  Completed.", "");

                }




            }
            catch (Exception ex)
            {
            }

            finally
            {

                objDBHelper.Dispose();
                objCommon.Dispose();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool _hasRecord = false;
            if (this.gvGrid.Rows.Count == 0)
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Search Student for Delete.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            errorMessage = string.Empty;
            foreach (DataGridViewRow Row in gvGrid.Rows)
            {
                if ((bool)Row.Cells["chkBox"].FormattedValue)
                    _hasRecord = true;
            }
            if (!_hasRecord)
            {
                errorMessage = "Data can not be transfered due to following reasons.\r\rPlease Select Any Record For Delete.";

                MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            GenerateStudentDelete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gvGrid.DataSource = null;
           
            tbFees.Text = string.Empty;
             tbRemarksTo.Text = string.Empty;
             tbGrNo.Text = string.Empty;
            ContructorInitialization();
        }
        }
    }

