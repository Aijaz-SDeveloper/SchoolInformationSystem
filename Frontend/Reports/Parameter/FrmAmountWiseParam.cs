using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace Frontend.Reports.Parameter
{
    public partial class FrmAmountWiseParam : Form
    {
        public FrmAmountWiseParam()
        {
            InitializeComponent();
            LoadCondition();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> reportParametersDictionary = new Dictionary<string, string>();
            reportParametersDictionary.Add("Amount", tbAmount.Text);
            reportParametersDictionary.Add("Condition", this.cbCondition.SelectedValue.ToString());
            
            Reports.ReportViewerPopup obj = new Reports.ReportViewerPopup("RptAmountBalance", reportParametersDictionary);
            obj.ShowDialog();
        }
        public void LoadCondition()
        {
            cbCondition.DisplayMember = "Description";
            cbCondition.ValueMember = "Id";


            cbCondition.DataSource = new dbSQLHelper().GetDataSet(" SELECT 0 as Id,'--Select--' Description Union Select Id,Description from ComParameters where type in (18)").Tables[0];

        }
    }
}
