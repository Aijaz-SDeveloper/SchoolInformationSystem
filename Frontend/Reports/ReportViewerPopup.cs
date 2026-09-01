using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Frontend.DBML;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BusinessLogic;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Globalization;


namespace Frontend.Reports
{
    public partial class ReportViewerPopup : Form
    {
        string errorMessage = string.Empty;
        string ReportTitle = string.Empty;
        string CompanyName = string.Empty;
        string report = string.Empty;

        dbSQLHelper objDBHelper = new dbSQLHelper();
        Dictionary<string, string> reportParameters;
        DataSet resultSet = new DataSet();
       // public event SubreportProcessingEventHandler SubreportProcessing;
        string _InquiryDateTimeFrom = string.Empty;
        string _InquiryDateTimeTo = string.Empty;

        string strReportInquiryType = string.Empty;

        public ReportViewerPopup(string _report, Dictionary<string, string> _reportParameters)
        {
            InitializeComponent();
            report = _report;
            reportParameters = _reportParameters;
            CompanyName = "ZAIN PUBLIC SCHOOL & COLLEGE BADIN";
        }
        private void ReportViewerPopup_Load(object sender, EventArgs e)
        
        {
            try
            {
                if (report == "rptCaneReceiptInquiry1")
                {

                    if (Global.UserId.ToString().ToUpper() == "HANIF" || Global.UserId.ToString().ToUpper() == "NAVEED")
                    {


                        rViewerPrint.ShowPrintButton = false;
                        rViewerPrint.ShowExportButton = false;


                    }
                }
                else if (report == "rptStudentProfile")
                {
                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.RptStudentProfile.rdlc";


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string Date = String.Empty;

                    string Id = reportParameters["Id"];



                    string sSql = "";




                    ReportTitle = "ADMISSION FORM";




                    sSql = "exec [dbo].[RptStudentProfile] " + "'" + Id + "'";


                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);
                    if (Id != "0")
                    {

                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("ReportTitle", ReportTitle);
                    param[1] = new ReportParameter("BU", CompanyName);
                     param[2] = new ReportParameter("Picture", ImageToBase64());
                     rViewerPrint.LocalReport.SetParameters(param);
                    
                    }
                    else
                    {
                       ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("ReportTitle", ReportTitle);
                    param[1] = new ReportParameter("BU", CompanyName);
                     param[2] = new ReportParameter("Picture", "");
                     rViewerPrint.LocalReport.SetParameters(param);
                    }


                    

                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_RptStudentProfile", resultSet.Tables[0]));
                        //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);

                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }
                }
                else if (report == "MonthlyChallanReport" && reportParameters["Format"] == "Voucher")
                {
                    

                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string Date = String.Empty;
                  
                    
                    string sSql = "";
                    ReportTitle = "Monthly Challan FORM";

                   
                        string Month = reportParameters["Month"];
                        string Year = reportParameters["Year"];
                        string Class = reportParameters["Class"];
                        string MonthName = reportParameters["MonthName"];
                        string Format = reportParameters["Format"];
                       

                            rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.MonthlyChallanClass.rdlc";
                       

                        sSql = "exec [dbo].[Rpt_MonthlyChallanClass] " + "'" + Month + "','" + Year + "','" + Class+"'";
                        resultSet = (DataSet)objDBHelper.GetDataSet(sSql);

                        ReportParameter[] param = new ReportParameter[4];
                        param[0] = new ReportParameter("ReportTitle", ReportTitle);
                        param[1] = new ReportParameter("BU", CompanyName);
                        param[2] = new ReportParameter("Month", MonthName);
                        param[3] = new ReportParameter("Year", Year);
                        rViewerPrint.LocalReport.SetParameters(param);
                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_Rpt_MonthlyChallanClass", resultSet.Tables[0]));
                            //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);
                        
                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "MonthlyChallanReport" && reportParameters["Format"] == "List")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string Date = String.Empty;


                    string sSql = "";
                    ReportTitle = "Monthly Challan FORM";


                    string Month = reportParameters["Month"];
                    string Year = reportParameters["Year"];
                    string Class = reportParameters["Class"];
                    string MonthName = reportParameters["MonthName"];
                    string Format = reportParameters["Format"];
                    
                        rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.rptChallanList.rdlc";
                    

                    sSql = "exec [dbo].[Rpt_MonthlyChallanClassList] " + "'" + Month + "','" + Year + "','" + Class + "'";
                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);

                    ReportParameter[] param = new ReportParameter[4];
                    param[0] = new ReportParameter("ReportTitle", ReportTitle);
                    param[1] = new ReportParameter("BU", CompanyName);
                    param[2] = new ReportParameter("Month", MonthName);
                    param[3] = new ReportParameter("Year", Year);
                    rViewerPrint.LocalReport.SetParameters(param);
                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_Rpt_MonthlyChallanClassList", resultSet.Tables[0]));
                        //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);

                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "DailyScrollReport")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string ClassName = string.Empty;
                  
                    string FromDate = reportParameters["FromDate"];
                    string ToDate = reportParameters["ToDate"];
                    string Class = reportParameters["Class"];

                    string ReportCriteria = "From " + FromDate + " To " + ToDate;


                    string sSql = "";
                    ReportTitle = "Daily Scroll Report";
                    if (Class != "0")
                    {
                        DataSet dataSet = null;
                        string query = "  SELECT  Isnull(Description,'') FROM ComParameters where Id=" + Class + " ";
                        dataSet = (DataSet)objDBHelper.GetDataSet(query);
                        if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                        {
                            ClassName = dataSet.Tables[0].Rows[0][0].ToString();
                        }
                    }

                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.DailyScrollReport.rdlc";



                    sSql = "exec [dbo].[Rpt_DailyScrollReport] " + "'" + FromDate + "','" + ToDate + "','" + Class+"'";
                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);

                    if (Class != "0")
                    {

                        ReportParameter[] param = new ReportParameter[4];
                        param[0] = new ReportParameter("ReportTitle", ReportTitle);
                        param[1] = new ReportParameter("BU", CompanyName);
                        param[2] = new ReportParameter("ReportCriteria", ReportCriteria);
                        param[3] = new ReportParameter("Class", ClassName);
                        rViewerPrint.LocalReport.SetParameters(param);
                    }
                    else
                    {

                        ReportParameter[] param = new ReportParameter[4];
                        param[0] = new ReportParameter("ReportTitle", ReportTitle);
                        param[1] = new ReportParameter("BU", CompanyName);
                        param[2] = new ReportParameter("ReportCriteria", ReportCriteria);
                        param[3] = new ReportParameter("Class", "-1");
                        rViewerPrint.LocalReport.SetParameters(param);
                    }
             
                   
                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_Rpt_DailyScrollReport", resultSet.Tables[0]));
                        //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);

                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "FeesActivityReport")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    
                    string FromDate = reportParameters["FromDate"];
                    string ToDate = reportParameters["ToDate"];
                    string StudentNo = reportParameters["StudentNo"];

                    string ReportCriteria = "From " + FromDate + " To " + ToDate;


                    string sSql = "";
                    ReportTitle = "Fees Activity Report";


                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.RptFeesActivityReport.rdlc";



                    sSql = "exec [dbo].[Rpt_FeesActivityReport] " + "'" + FromDate + "','" + ToDate + "','" + StudentNo + "'";
                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);

                   

                        ReportParameter[] param = new ReportParameter[4];
                        param[0] = new ReportParameter("ReportTitle", ReportTitle);
                        param[1] = new ReportParameter("BU", CompanyName);
                        param[2] = new ReportParameter("ReportCriteria", ReportCriteria);
                        param[3] = new ReportParameter("StudentNo", StudentNo);
                        rViewerPrint.LocalReport.SetParameters(param);
                   


                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_Rpt_FeesActivityReport", resultSet.Tables[0]));
                        //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);

                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "rptStudentProfileHistory")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;

                   string StudentNo = reportParameters["StudentNo"];


                    string sSql = "";
                    ReportTitle = "Student Profile History Report";


                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.rptStudentProfileHistory.rdlc";



                    sSql = "exec [dbo].[rptStudentProfileHistory] '"  + StudentNo + "'";
                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);



                    ReportParameter[] param = new ReportParameter[3];
                    param[0] = new ReportParameter("ReportTitle", ReportTitle);
                    param[1] = new ReportParameter("BU", CompanyName);
                    param[2] = new ReportParameter("StudentNo", StudentNo);
                    rViewerPrint.LocalReport.SetParameters(param);



                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_rptStudentProfileHistory", resultSet.Tables[0]));
                        
                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "rptParamList")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string ClassName = string.Empty;


                    string sSql = "";
                    ReportTitle = "General Parameter List";
                   

                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.rptParameterList.rdlc";



                    sSql = "exec [dbo].[rpt_ParameterList] ";
                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);

                   

                        ReportParameter[] param = new ReportParameter[2];
                        param[0] = new ReportParameter("ReportTitle", ReportTitle);
                        param[1] = new ReportParameter("BU", CompanyName);
                        rViewerPrint.LocalReport.SetParameters(param);
                   


                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_rpt_ParameterList", resultSet.Tables[0]));
                        //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);

                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "RptAmountBalance")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string ClassName = string.Empty;
                     string Amount = reportParameters["Amount"];
                     string Condition = reportParameters["Condition"];



                    string sSql = "";
                    ReportTitle = "Remaining Balance Amount List";


                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.RptBalanceList.rdlc";



                    sSql = "exec [dbo].[Rpt_BalanceList]  " + "'" + Amount + "','"+Condition+"'";
                    resultSet = (DataSet)objDBHelper.GetDataSet(sSql);



                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("ReportTitle", ReportTitle);
                    param[1] = new ReportParameter("BU", CompanyName);
                    rViewerPrint.LocalReport.SetParameters(param);



                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_Rpt_BalanceList", resultSet.Tables[0]));
                        //ReportViewer.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(SubreportProcessingEventHandler);

                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }
                else if (report == "rptLedgerCard")
                {


                    
                    rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.rptLedgerCard.rdlc";

                    DataSet resultData = new DataSet();
                    string reportQuery = String.Empty;
                    string reportType = String.Empty;
                    string Date = String.Empty;
                    string YearName = String.Empty;
                    
                    string sSql = "";
                    string GRNo = reportParameters["StudentNo"].ToString();
                   
                     string Year = reportParameters["YearId"];
                     DataSet dataSet = null;
                     string query = "  Select YearName from YearDefination   where ( " + Year + " = 0 and CurrentStatusId = 3) or (" + Year + " != 0 and Id =" + Year +" )  order by Id desc ";
                     dataSet = (DataSet)objDBHelper.GetDataSet(query);
                     if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                     {
                          YearName = dataSet.Tables[0].Rows[0][0].ToString();
                     }

                    ReportTitle = "Student Ledger Card for the year of " + YearName;

                   
                    sSql = "exec rpt_StudentLedgerCard '" + GRNo + "','" + Year +"'";

                    ReportParameter[] param = new ReportParameter[2];
                    param[0] = new ReportParameter("ReportTitle", ReportTitle);
                    param[1] = new ReportParameter("BU", CompanyName);

                    rViewerPrint.LocalReport.SetParameters(param);

                    DataSet result = new DataSet();
                    result = (DataSet)objDBHelper.GetDataSet(sSql);

                    if (result != null && result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                        this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_rpt_StudentLedgerCard", result.Tables[0]));
                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }
                }
                else if (report == "MonthlyChallanReportIndividual")
                {


                    DataSet resultData = new DataSet();
                    string reportQuery = string.Empty;
                    string reportType = String.Empty;
                    string Date = String.Empty;
                    string Id = reportParameters["Id"];
                    string StId = reportParameters["StId"];

                    string sSql = "";
                    ReportTitle = "Monthly Challan Form";
               
                        rViewerPrint.LocalReport.ReportEmbeddedResource = "Frontend.Reports.MonthlyChallanIndividual.rdlc";


                        sSql = "exec [dbo].[Rpt_MonthlyChallan3] " + "'" + Id + "','" + StId+"'";
                        resultSet = (DataSet)objDBHelper.GetDataSet(sSql);

                        ReportParameter[] param = new ReportParameter[4];
                        param[0] = new ReportParameter("ReportTitle", ReportTitle);
                        param[1] = new ReportParameter("BU", CompanyName);
                        param[2] = new ReportParameter("Month", "");
                        param[3] = new ReportParameter("Year", "");
                        rViewerPrint.LocalReport.SetParameters(param);
                    if (resultSet != null && resultSet.Tables.Count > 0 && resultSet.Tables[0].Rows.Count > 0)
                    {
                        this.lblError.Text = "";
                        this.rViewerPrint.Visible = true;
                        rViewerPrint.ProcessingMode = ProcessingMode.Local;
                       

                            this.rViewerPrint.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Schoolds_Rpt_MonthlyChallan3", resultSet.Tables[0]));
                        this.rViewerPrint.RefreshReport();
                    }
                    else
                    {
                        this.rViewerPrint.Visible = false;
                        this.lblError.Text = "No record found.";
                    }

                }                                                            


            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                this.lblError.Text = Constants.ErrorMessage;

            }




            this.rViewerPrint.RefreshReport();
        }


        public string ImageToBase64()
        {
            string sql = "select Isnull(Pic,'') as Pic from Student_Profile where Id=" + reportParameters["Id"];
            DataSet ds = new DataSet();
            ds = objDBHelper.GetDataSet(sql);
            ///record count check here
            DataRow r = ds.Tables[0].Rows[0] as DataRow;
            byte[] image = (byte[])(r["Pic"]);

            string base64String = Convert.ToBase64String(image);
            return base64String;
        }

        public void SubreportProcessingEventHandler(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            try
            {
                if (e.ReportPath == "rptPRODSubChemicalDepartmentDailyReport") //combined all profile section reports pending
                {
                    e.DataSources.Add(new ReportDataSource("PRODUCTION_PROD_rptSubChemicalDepartmentDailyReport", resultSet.Tables[1]));
                }
                if (e.ReportPath == "RptCashCode_Sub") //combined all profile section reports pending
                {
                    DataSet result = new DataSet();
                    string FromDate = _InquiryDateTimeFrom;
                    string ToDate = _InquiryDateTimeTo;
                    string Grower = e.Parameters["GrowerId"].Values[0];

                    result = (DataSet)objDBHelper.GetDataSet(" exec AWSM_rpt_CashCodeCaneRecieptInquiry '" + FromDate + "','" + ToDate + "','" + Grower + "'");

                    e.DataSources.Add(new ReportDataSource("cane2ds_AWSM_rpt_CashCodeCaneRecieptInquiry", result.Tables[0]));
                }
                if (e.ReportPath == "rptPayrollSalarySlipSub")
                {
                    DataSet result = new DataSet();
                    int employeeId = Int32.Parse(e.Parameters["EmployeeId"].Values[0]);
                    result = (DataSet)objDBHelper.GetDataSet(" exec HRM_rptPayrolSalarySlipSub '" + employeeId + "'");
                    e.DataSources.Add(new ReportDataSource("cane4ds_HRM_rptPayrolSalarySlipSub", result.Tables[0]));
                }
                if (e.ReportPath == "rptPayrollSalarySlipPermanentSUb")
                {
                    DataSet result = new DataSet();
                    int employeeId = Int32.Parse(e.Parameters["EmployeeId"].Values[0]);
                    result = (DataSet)objDBHelper.GetDataSet(" exec HRM_rptPayrolSalarySlipPermanentSub '" + employeeId + "'");
                    e.DataSources.Add(new ReportDataSource("cane4ds_HRM_rptPayrolSalarySlipPermanentSub", result.Tables[0]));
                }

                if (e.ReportPath == "rptTransfer") //combined all profile section reports pending
                {
                    DataSet result = new DataSet();
                    int GenId = Int32.Parse(e.Parameters["GenId"].Values[0]);
                    int PaymentID = Int32.Parse(e.Parameters["toPaymentId"].Values[0]);
                    result = (DataSet)objDBHelper.GetDataSet(" exec rpt_CA_sp_GrowerPaymentVoucherTransferDetail '" + GenId + "'," + PaymentID + "");
                    e.DataSources.Add(new ReportDataSource("CANE_rpt_CA_sp_GrowerPaymentVoucherTransferDetail", result.Tables[0]));
                }
                if (e.ReportPath == "rptSubCaneReceiptInquiry")
                {
                    DataSet result = new DataSet();
                    string GrowerId = e.Parameters["GrowerId"].Values[0];
                    string DateTimeFrom = _InquiryDateTimeFrom;
                    //reportParameters["FromDateTime"].ConvertTo<DateTime>().ToString("dd MMM yyyy");
                    string DateTimeTo = _InquiryDateTimeTo;
                    //reportParameters["ToDateTime"].ConvertTo<DateTime>().ToString("dd MMM yyyy");
                    // int PaymentID = Int32.Parse(e.Parameters["toPaymentId"].Values[0]);
                    result = (DataSet)objDBHelper.GetDataSet(" exec AWSM_rpt_subreportCaneRecieptInquiryGroupinfo '" + GrowerId + "','" + DateTimeFrom + "','" + DateTimeTo + "'," + strReportInquiryType + "");
                    e.DataSources.Add(new ReportDataSource("CANE_AWSM_rpt_subreportCaneRecieptInquiryGroupinfo", result.Tables[0]));
                }
                if (e.ReportPath == "rptSubCaneReceiptInquiryForGrower")
                {
                    DataSet result = new DataSet();
                    string GrowerId = e.Parameters["GrowerId"].Values[0];
                    string DateTimeFrom = _InquiryDateTimeFrom;
                    //reportParameters["FromDateTime"].ConvertTo<DateTime>().ToString("dd MMM yyyy");
                    string DateTimeTo = _InquiryDateTimeTo;
                    //reportParameters["ToDateTime"].ConvertTo<DateTime>().ToString("dd MMM yyyy");
                    // int PaymentID = Int32.Parse(e.Parameters["toPaymentId"].Values[0]);
                    result = (DataSet)objDBHelper.GetDataSet(" exec AWSM_rpt_subreportCaneRecieptInquiryGroupinfo '" + GrowerId + "','" + DateTimeFrom + "','" + DateTimeTo + "'," + strReportInquiryType + "");
                    e.DataSources.Add(new ReportDataSource("CANE_AWSM_rpt_subreportCaneRecieptInquiryGroupinfo", result.Tables[0]));
                }
                if (e.ReportPath == "rptSubIndentQuotaScheduleForGrower")
                {
                    DataSet result = new DataSet();
                    string GrowerId = e.Parameters["GrowerId"].Values[0];
                    string DateTimeFrom = _InquiryDateTimeFrom;
                    //reportParameters["FromDateTime"].ConvertTo<DateTime>().ToString("dd MMM yyyy");
                    string DateTimeTo = _InquiryDateTimeTo;
                    //reportParameters["ToDateTime"].ConvertTo<DateTime>().ToString("dd MMM yyyy");
                    // int PaymentID = Int32.Parse(e.Parameters["toPaymentId"].Values[0]);
                    result = (DataSet)objDBHelper.GetDataSet(" exec rptIndentQuotaScheduleForGrower '" + GrowerId+"'" );
                    e.DataSources.Add(new ReportDataSource("CANE_rptIndentQuotaScheduleForGrower", result.Tables[0]));
                }
                if (e.ReportPath == "rptPRODDailyPerformanceReport_Sub")
                {


                    e.DataSources.Add(new ReportDataSource("PRODUCTION_PROD_rptDailyPerformanceReport_Sub", resultSet.Tables[1]));
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }


        }


        private byte[] ConvertBytestoJpegBytes(byte[] pixels24bpp, int W, int H)
        {
            GCHandle gch = GCHandle.Alloc(pixels24bpp, GCHandleType.Pinned);
            int stride = 4 * ((24 * W + 31) / 32);
            Bitmap bmp = new Bitmap(W, H, stride, PixelFormat.Format24bppRgb, gch.AddrOfPinnedObject());
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Jpeg);
            gch.Free();
            return ms.ToArray();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void ReportViewer_Load_1(object sender, EventArgs e)
        {
            
        }

        private void ReportViewer_Print(object sender, CancelEventArgs e)
        {
            if (report == "rptWCard_Plain")
            {
                
            }

            if (report == "PrintAutoCheque")
            {
               
            }

                
                
            }
        }
        }




    

