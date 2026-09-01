using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows.Forms;
using BusinessLogic;
using System.Deployment.Application;

namespace Frontend
{
    public partial class Login : Form
    {
        string error = string.Empty;
       
        Login objLogin = null;

        public Login()
        {
            InitializeComponent();
           

            initializeConnectionString();
            LoadBranch();
            objLogin = this;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            myBtnClick();
        }
        public void LoadBranch()
        {
            try
            {
                clsCommon objCommon = new clsCommon(Global.AWSMConn);
                string sSQL = "Select nLocationId as Event, vcLocationName as Description From dbo.comLocation ";
                objCommon.FillCombo(ref this.cbDatbase, ref sSQL, "Description", "Event");

                this.tbUserName.Focus();

               
                this.cbDatbase.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                
            }
        }
        private void myBtnClick()
        {
            dbSQLHelper db_SQLHelper = new dbSQLHelper();
            clsSecurity objSecurity = new clsSecurity();
            try
            {
                /*
                string query = "SELECT Hrm_EmployeeProfile.Id FROM ComUsers INNER JOIN Hrm_EmployeeProfile ON ComUsers.vcEmployeeID = Hrm_EmployeeProfile.EmployeeNo  WHERE     ltrim(rtrim(UPPER(ComUsers.vcUserId))) = ltrim(rtrim(UPPER('" + this.tbUserName.Text.Trim() + "')))";
                DataSet ds = (DataSet)db_SQLHelper.GetDataSet(query);
                if (ds != null)
                    Frontend.Common.Global.UserEmpId = ds.Tables[0].Rows[0]["Id"].ToString().ConvertTo<long>();
                */
                Frontend.Common.Global.UserId = this.tbUserName.Text.Trim();
                //Frontend.Common.Global.BranchId = int.Parse(this.cbBranch.SelectedValue.ToString());

                //BusinessLogic.Global.UserEmpId = Frontend.Common.Global.UserEmpId;
                BusinessLogic.Global.UserId = Frontend.Common.Global.UserId;
                //BusinessLogic.Global.BranchId = Frontend.Common.Global.BranchId;


                if (!IsValid())
                {
                    MessageBox.Show(error, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool isMaster = false;
                if (objSecurity.Login(this.tbUserName.Text.Trim(), this.tbPassword.Text.Trim(), ref error, ref isMaster))
                {
                    string sSQL = "SELECT  ComUsers.vcUserId FROM ComUsers inner join ComUserGroups on ComUsers.vcUserId=ComUserGroups.vcUserId where ComUsers.vcUserId = '" + this.tbUserName.Text.Trim() + "'";
                    DataSet dsTemp = (DataSet)db_SQLHelper.GetDataSet(sSQL);
                    if (dsTemp.Tables[0].Rows.Count <= 0)
                    {
                        //if ((dsTemp.Tables[0].Rows[0]["CurrentStatusId"].ToString() != "3") || (dsTemp.Tables[0].Rows[0]["IsActive"].ToString() != "True"))
                        //{
                            MessageBox.Show("Unable to Login due to Following Reason\nCurrent Staff is not Active.", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                       // }
                    }
                    string sSQL2 = "Select ComUserGroups.vcUserId from dbo.ComUserGroups inner join ComAccessRights on ComUserGroups.nGroupId=ComAccessRights.nGroupId where ComUserGroups.vcUserId = '" + this.tbUserName.Text.Trim() + "'";
                    DataSet dsTemp2 = (DataSet)db_SQLHelper.GetDataSet(sSQL2);
                    if (dsTemp2.Tables[0].Rows.Count <= 0)
                    {
                        //if ((dsTemp.Tables[0].Rows[0]["CurrentStatusId"].ToString() != "3") || (dsTemp.Tables[0].Rows[0]["IsActive"].ToString() != "True"))
                        //{
                        MessageBox.Show("Unable to Login due to Following Reason\nThere is no privilege..", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        // }
                    }

                    this.Hide();
                    MainMdi mainwindow = new MainMdi();
                    //mainwindow.Text = " AWSM Cane Accounting (  " + Frontend.Common.Global.UserId + "  )";
                    mainwindow.Text = " ZAIN PUBLIC SCHOOL & COLLEGE BADIN (  " + Frontend.Common.Global.UserId + "  )";

                    mainwindow.ShowDialog();
                    this.Close();
                }
                else
                {
                    error = "Invaild User Name or Password!";
                    MessageBox.Show(error, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Record is not available", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsValid()
        {
            error = string.Empty;
            bool isValid = false;
            if (String.IsNullOrEmpty(this.tbUserName.Text))
                error = "Can't Login due to following reasons.\r\rUser Name is missing";

            if (String.IsNullOrEmpty(this.tbPassword.Text))
                error = error == string.Empty ? "Can't Login due to following reasons.\r\rPassword is missing" : error + "\rPassword is missing";
            
            isValid = error == string.Empty ? true : false;

            return isValid;
        }
        public void initializeConnectionString()
        {
            Frontend.Common.Global.AWSMConn = Frontend.Properties.Settings.Default.DatabaseConnection;
            BusinessLogic.Global.AWSMConn = Frontend.Common.Global.AWSMConn;
            Frontend.Common.Global.LocationId = 1;
            BusinessLogic.Global.LocationId = Frontend.Common.Global.LocationId;


            string host_name = Dns.GetHostName();
            //int ips_lenght = Dns.GetHostAddresses(host_name).Length;
            //IPAddress[] ips = new IPAddress[ips_lenght];
            //ips = Dns.GetHostAddresses(host_name);

            clsCommon.IP_Address = IPNetworking.GetIP4Address();

            Frontend.Common.Global.IPAddress = IPNetworking.GetIP4Address();
            BusinessLogic.Global.IPAddress = Frontend.Common.Global.IPAddress;
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Return)
            {
                myBtnClick();
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        

    }
}
