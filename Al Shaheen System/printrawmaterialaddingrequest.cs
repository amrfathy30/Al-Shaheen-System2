using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class printrawmaterialaddingrequest : Form
    {
        List<SH_QUANTITY_OF_RAW_MATERIAL> quantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
        string request_number;
        string adding_date;
        string stockname;
        string stockmanname;

        public printrawmaterialaddingrequest( string req_number  , string addition_date , string stock_name , string stock_man_name ,List<SH_QUANTITY_OF_RAW_MATERIAL> mq)
        {
            InitializeComponent();
            request_number = req_number;
            adding_date = addition_date;
            stockname = stock_name;
            stockmanname = stock_man_name;
            quantities = mq;
        }

        private void printrawmaterialaddingrequest_Load(object sender, EventArgs e)
        {
            SH_QUANTITY_OF_RAW_MATERIALBindingSource.DataSource = quantities;

            ReportParameter[] myparameters = new ReportParameter[4];
            myparameters[0] = new ReportParameter("pra_adding_request_number", request_number);
            myparameters[1] = new ReportParameter("pra_adding_request_addition_date", adding_date);
            myparameters[2] = new ReportParameter("pra_adding_request_stock_name", stockname);
            myparameters[3] = new ReportParameter("pra_adding_request_stock_man_name", stockmanname);
            this.reportViewer1.LocalReport.SetParameters(myparameters);
           this.reportViewer1.RefreshReport();
        }
    }
}
