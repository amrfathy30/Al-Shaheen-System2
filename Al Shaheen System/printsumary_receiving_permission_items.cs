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
    public partial class printsumary_receiving_permission_items : Form
    {
        List<summary_receiving_information_quantity_data> mydata = new List<summary_receiving_information_quantity_data>();

        SH_EMPLOYEES mEmployees;
        SH_USER_ACCOUNTS mAccounts;
        SH_USER_PERMISIONS mPermissions; 

        public printsumary_receiving_permission_items(List<summary_receiving_information_quantity_data> anydata , SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mydata = anydata;

            mEmployees = anyemp;
            mAccounts = anyaccount;
            mPermissions = anyperm;
        }

        private void printsumary_receiving_permission_items_Load(object sender, EventArgs e)
        {
            DataTable mydatatabel = new DataTable();
            mydatatabel.Columns.Add("m");
            mydatatabel.Columns.Add("client_name");
            mydatatabel.Columns.Add("client_branch_name");
            mydatatabel.Columns.Add("item_name");
            mydatatabel.Columns.Add("container_name");
            mydatatabel.Columns.Add("no_containers");
            mydatatabel.Columns.Add("total_number_of_items");
           
            if (mydata.Count > 0)
            {
                string[] myvalues = new string[7];
                for (int i = 0; i < mydata.Count; i++)
                {
                    myvalues[0] = (i + 1).ToString();
                    myvalues[1] = (mydata[i].client_name).ToString();
                    myvalues[2] = (mydata[i].client_branch_name).ToString();
                    myvalues[3] = (mydata[i].item_name).ToString();
                    myvalues[4] = (mydata[i].container_name).ToString();
                    myvalues[5] = (mydata[i].no_containers).ToString();
                    myvalues[6] = (mydata[i].no_items).ToString();

                    mydatatabel.Rows.Add(myvalues);

                }

            }
            ReportParameter[] myparm = new ReportParameter[1];
            myparm[0] = new ReportParameter("report_presenter_name", mEmployees.SH_EMPLOYEE_NAME, false);

            this.reportViewer1.LocalReport.SetParameters(myparm);
            ReportDataSource rds = new ReportDataSource("DataSet1", mydatatabel);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.DataBind();
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
