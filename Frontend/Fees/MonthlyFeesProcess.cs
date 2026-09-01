using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Frontend.DBML;
using Frontend.Reports;
using BusinessLogic;
using Microsoft.Reporting.WinForms;

namespace Frontend.Fees
{
    public partial class MonthlyFeesProcess : Form
    {
        string errorMessage = string.Empty;
        clsCommon objCommon = new clsCommon();
       
        
        public MonthlyFeesProcess()
        {
            InitializeComponent();
            LoadClass();
            LoadFeesType();
            FillMonth();
            FillYear();
            cbMonth.SelectedValue = System.DateTime.Now.Month;
            cbYear.SelectedItem = System.DateTime.Now.Year.ToString();
            
        }
        public void LoadClass()
        {
            cbClass.DisplayMember = "Description";
            cbClass.ValueMember = "Id";

            
            cbClass.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (1)").Tables[0];

        }
       
        public void LoadFeesType()
        {
            cbFees.DisplayMember = "Description";
            cbFees.ValueMember = "Id";


            cbFees.DataSource = new dbSQLHelper().GetDataSet(" Select Id,Description from dbo.ComParameters where Type in (12) and Id not in (68,70,72,73,74,75)").Tables[0];

        }
        protected void FillYear()
        {
            
           
            objCommon.FillYear(ref cbYear, 2018, 2100, ref errorMessage);
            
        }
        protected void FillMonth()
        {
            string sql = " SELECT 1 as Id,'January' as Description ";

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
        }
        protected bool IsValidInformation()
        {
            bool isValidInput = true;
            errorMessage = string.Empty;

         
       
            dbSQLHelper objDBHelper = new dbSQLHelper();




            try
            {
                
                if (cbMonth.SelectedValue.ToString().ConvertTo<long>() == 0)
                    errorMessage = "Data can not be saved due to following reasons.\r\rPlease select Month.";
                cbMonth.Focus();

                if ( this.cbYear.SelectedIndex == 0)
                    errorMessage = "Data can not be saved due to following reasons.\r\rPlease select Year.";
                cbYear.Focus();

                if (cbClass.SelectedValue.ToString().ConvertTo<long>() == 0)
                    errorMessage = "Data can not be saved due to following reasons.\r\rPlease select class.";
                cbClass.Focus();


                isValidInput = errorMessage == string.Empty ? true : false;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            finally
            {
          
                objCommon.Dispose();
            }




            return isValidInput;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
             if (IsValidInformation())
                {
                    DisplayGenerationData();

             }
             else
             {
                 MessageBox.Show(errorMessage, Constants.ModuleName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                 
             }
        }
        private void DisplayGenerationData()
        {
            string searchCriteria = string.Empty;
            string strQuery = string.Empty;
            DataSet dsResult = new DataSet();
            dbSQLHelper objDBHelper = new dbSQLHelper();
            
            try
            {
                if (cbFees.SelectedValue.ToString().Trim() != "71")
                {
                   
                    this.tbAmount.Text = "0";
                    
                }
                
                searchCriteria = searchCriteria + "'" + cbMonth.SelectedValue.ToString().ConvertTo<long>() + "','" + cbYear.SelectedItem + "','" + cbClass.SelectedValue.ToString().ConvertTo<long>() + "','" + dpLastDate.Value + "','" + cbFees.SelectedValue.ToString().ConvertTo<long>() + "','"+tbAmount.Text.ToString()+"'";

                strQuery = " EXEC sp_SearchGenerationData " + searchCriteria;
                dsResult = new dbSQLHelper().GetDataSet(strQuery);
                this.gvSearch.DataSource = null;
                this.gvSearch.Columns.Clear();
                if (dsResult.Tables[0].Rows.Count > 0)
                {
                    this.gvSearch.DataSource = dsResult.Tables[0];

                    ////Grid Property Settings 
                    gvSearch.Columns["Id"].Width = 40;
                    gvSearch.Columns["Name"].Width = 80;
                    gvSearch.Columns["FName"].Width = 150;
                    gvSearch.Columns["Class"].Width = 40;
                    gvSearch.Columns["Section"].Width = 50;
                    gvSearch.Columns["Gender"].Width = 50;
                    gvSearch.Columns["Amount"].Width = 70;
                    gvSearch.Columns["Arrears"].Width = 50;
                   

                   
                   
                }
                               
            }
            catch (Exception ex)
            {

                errorMessage = ex.Message; 
                objCommon.SetStatusbar(ref tssAction, ref tssRecord, "Successfully Searched" + " : " + "Record 1 of 1", "");

               
               
            }
            finally
            {
                dsResult.Dispose();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
       
            Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
            reportParametersDictionary.Add("Month", this.cbMonth.SelectedItem.ToString());
            reportParametersDictionary.Add("Year", this.cbYear.SelectedItem.ToString());
            reportParametersDictionary.Add("Fees", this.cbFees.SelectedItem.ToString());


            Frontend.Reports.ReportViewerPopup obj = new ReportViewerPopup("", reportParametersDictionary);
            
            obj.rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.RptFeesProcess.rdlc";

            ReportParameter[] param = new ReportParameter[3];
            param[0] = new ReportParameter("Month", this.cbMonth.Text.ToString());
            param[1] = new ReportParameter("Year", this.cbYear.SelectedItem.ToString());
            param[2] = new ReportParameter("Fees", this.cbFees.Text.ToString());

           
            obj.rViewerPrint.LocalReport.SetParameters(param);
            
           
            obj.rViewerPrint.ProcessingMode = ProcessingMode.Local;
            obj.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_RptFeesProcess", gvSearch.DataSource));
            obj.rViewerPrint.RefreshReport();
            obj.ShowDialog();


        }
         private void GeneratePayment()
        {
            dbSQLHelper objDBHelper = new dbSQLHelper();
            try
            {
                if (cbFees.SelectedValue.ToString().Trim() != "71")
                {

                    this.tbAmount.Text = "0";

                }
                string searchCriteria = cbMonth.SelectedValue.ToString().ConvertTo<long>() + "," +
                                  cbYear.SelectedItem + "," +
                                  cbClass.SelectedValue.ToString().ConvertTo<long>() + ",'" +
                                  dpLastDate.Value.ToString() + "'," +
                                  cbFees.SelectedValue.ToString() + ",'" +
                                  tbDescription.Text.ToString() + "','" + tbAmount.Text.ToString() + "'";

                string strQuery = " EXEC [Generate_Payment] " + searchCriteria;
                bool dsResult2 = new dbSQLHelper().ExecuteCommand(strQuery);
                if (dsResult2 == true)
                { 
                    MessageBox.Show("Generation Successfully Completed.", "Success");
                }
                else
                {

                    MessageBox.Show("Generation is not  Completed.", "");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
               
                objDBHelper.Dispose();
                objCommon.Dispose();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (gvSearch.DataSource != string.Empty)
            {
                GeneratePayment();
            }
            else
            {
                MessageBox.Show("Please Load Data for Generation.", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void tbAmount_TextChanged(object sender, EventArgs e)
        {
            if (cbFees.SelectedValue.ToString().Trim() == "71")
            {
                tbAmount.Visible = true;
                label10.Visible = true;
            }
            else
            {
                tbAmount.Visible = false;
                label10.Visible = false;


            }
        }
    }
}
