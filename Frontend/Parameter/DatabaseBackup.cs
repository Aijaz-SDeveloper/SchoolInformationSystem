using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using Frontend.Common;
using System.Data.SqlClient;
using BusinessLogic;

namespace Frontend.Parameter
{
    public partial class DatabaseBackup : Form
    {

        string _Document = string.Empty;

        public DatabaseBackup()
        {
            _Document = Constants.PRM_DBBackup;

            InitializeComponent();
            if (!hasReportRights(_Document))
            {
                MessageBox.Show(" Sorry ! You don't have rights.", Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDlg = new FolderBrowserDialog();
            folderBrowserDlg.ShowNewFolderButton = false;
            DialogResult dlgResult = folderBrowserDlg.ShowDialog();
            if (dlgResult.Equals(DialogResult.OK))
            {
                txtPath.Text = folderBrowserDlg.SelectedPath;
                Environment.SpecialFolder rootFolder = folderBrowserDlg.RootFolder;
            }
        }

        private void DatabaseBackup_Load(object sender, EventArgs e)
        {
            clsCommon objCommon = new clsCommon();
            

            cbDBName.DropDownStyle = ComboBoxStyle.DropDownList;
            string strQuery = "Select database_id as Id,Name from sys.databases where name ='School' ";
            objCommon.FillCombo(ref cbDBName, ref  strQuery, "Name", "Id");          
            
  
            
        }
        public bool hasReportRights(string _strReportName)
        {
            bool hasRights = false;
            clsSecurity objSecturity = new clsSecurity();
            try
            {
                hasRights = objSecturity.IsActionAllowed(_strReportName, Frontend.Common.Global.UserId, Constants.Action.Print.GetHashCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Constants.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return hasRights;
        }
       

        public void BackupDatabase(String databaseName,String destinationPath)
        {
            try
            {
                string sSQL = string.Empty;
            
                BusinessLogic.dbSQLHelper objDBHelper = new BusinessLogic.dbSQLHelper();
                Int32 dataSet = 0;

                sSQL = "exec dbo.DBBackup '" + databaseName + "','" + destinationPath + "'";

            dataSet = objDBHelper.RunCommand(sSQL, CommandType.Text, null);
            MessageBox.Show("Database Backup created successfully");
            
            }
            catch (Exception ex)
            {
              
                MessageBox.Show("Error Occured During DB backup process !<br>" + ex.ToString());
           
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {

           
         try
         {
              string path;
                if (!(txtPath.Text.EndsWith("\\")))
                {
                    path = txtPath.Text + "\\";
                }
                else
                {
                    path = txtPath.Text;
                }
                if (cbDBName.Text == string.Empty || path == "\\")
                {

                    MessageBox.Show("Please select DB / Destination Path.");
                }
                else
                {

                    BackupDatabase(this.cbDBName.Text.ToString(), path);
                   
                   
                }
                        
                  
                

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        }
    }

