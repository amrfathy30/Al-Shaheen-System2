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
    public partial class printrawtinaddedquantities : Form
    {
        rawtinaddingprinterdata mQuntities;
        DataTable mdatatabel = new DataTable();
        public printrawtinaddedquantities(rawtinaddingprinterdata mydata)
        {
            InitializeComponent();
            mQuntities = mydata;
        }

        private void printrawtinaddedquantities_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            mdatatabel.Columns.Add("no");
            mdatatabel.Columns.Add("item_code");
            mdatatabel.Columns.Add("item_temper");
            mdatatabel.Columns.Add("item_finish");
            mdatatabel.Columns.Add("item_coating");
            mdatatabel.Columns.Add("item_no_parcels");
            mdatatabel.Columns.Add("item_no_sheets_per_parcel");
            mdatatabel.Columns.Add("item_total_no_sheets");
            mdatatabel.Columns.Add("item_net_weight");
            mdatatabel.Columns.Add("item_gross_weight");
            for (int i = 0; i < mQuntities.quantities.Count; i++)
            {
                mdatatabel.Rows.Add(
                 (i+1), (mQuntities.quantities[i].SH_ITEM_CODE) ,
                 (mQuntities.quantities[i].SH_ITEM_TEMPER),
                 (mQuntities.quantities[i].SH_ITEM_FINISH),
                 (mQuntities.quantities[i].SH_ITEM_COATING),
                 (mQuntities.quantities[i].SH_TOTAL_NUMBER_OF_PACKAGES),
                 (mQuntities.quantities[i].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE)
                 ,(mQuntities.quantities[i].SH_TOTAL_NUMBER_OF_SHEETS()),
                 (mQuntities.quantities[i].SH_NET_WEIGHT),
                 (mQuntities.quantities[i].SH_ITEM_GROSS_WEIGHT)
                );
            }

            ReportParameter[] myparm = new ReportParameter[4];
            myparm[0] = new ReportParameter("addition_permission_number", mQuntities.addition_permission_number, true);
            myparm[1] = new ReportParameter("addition_permission_date", mQuntities.additiondate.ToString(), true);
            myparm[2] = new ReportParameter("stock_name", mQuntities.stock.SH_STOCK_NAME, true);
            myparm[3] = new ReportParameter("stock_man_name", mQuntities.stock_man_name.SH_EMPLOYEE_NAME.ToString(), true);

            this.reportViewer1.LocalReport.SetParameters(myparm);
            this.reportViewer1.LocalReport.DataSources.Add(
                      new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", mdatatabel)
                        );

            this.reportViewer1.RefreshReport();
        }
    }
}
