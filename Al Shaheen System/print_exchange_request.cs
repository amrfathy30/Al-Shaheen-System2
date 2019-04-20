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
    public partial class print_exchange_request : Form
    {
        public string mWorkNumber { get; set; }
        public string mExchangeprmission_number { get; set; }
        public string mStockManName { get; set; }
        public List<SH_RAW_MATERIAL_PARCEL> sh = new List<SH_RAW_MATERIAL_PARCEL>();
        public string mConfidentialManName { get; set; }
        public string exchangereason { get; set; }
        public string mRecievalManName { get; set; }

        public string StockManName { get; set; }
        public print_exchange_request ( string word_number , string pra_exchange_permission_number , string stock_man , string conf_man , string rec_man , string stock_name , List<SH_RAW_MATERIAL_PARCEL> myparcels , string exchange_reason)
        {
            InitializeComponent();
            mWorkNumber = word_number;
            mExchangeprmission_number = pra_exchange_permission_number;
            mStockManName = stock_man;
            mConfidentialManName = conf_man ;
            mRecievalManName = rec_man;
            StockManName = stock_name;
            this.sh = myparcels;
            exchangereason = exchange_reason;
           // MessageBox.Show(mWorkNumber);


        }

        private void print_exchange_request_Load(object sender, EventArgs e)
        {

            SH_RAW_MATERIAL_PARCELBindingSource.DataSource = sh;



            ReportParameter[] mydata = new ReportParameter[8];
            mydata[0] = new ReportParameter("pra_word_order_number", mWorkNumber);
            mydata[1] = new ReportParameter("pra_exchange_permission_number", mExchangeprmission_number);
            mydata[2] = new ReportParameter("pra_exchange_date", DateTime.Now.ToString());
            mydata[3] = new ReportParameter("pra_stock_man_name", mStockManName);
            mydata[4] = new ReportParameter("pra_confidential_man_name",mConfidentialManName );
            mydata[5] = new ReportParameter("pra_receival_man_name",mRecievalManName );
            mydata[6] = new ReportParameter("pra_stock_name", StockManName );
            mydata[7] = new ReportParameter("pra_reason_of_exchange" , exchangereason);
           // mydata[8] = new ReportParameter();
          
            this.reportViewer1.LocalReport.SetParameters(mydata);
            this.reportViewer1.RefreshReport();
        }
    }
}
