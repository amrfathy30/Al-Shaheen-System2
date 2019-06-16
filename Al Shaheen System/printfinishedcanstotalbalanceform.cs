
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class printfinishedcanstotalbalanceform : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        public printfinishedcanstotalbalanceform(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyaacount , SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaacount;
            mPermission = anyperm;
        }

        private void printfinishedcanstotalbalanceform_Load(object sender, EventArgs e)
        {
            DataTable mydatatabel = new DataTable();
            mydatatabel.Columns.Add("m");
            mydatatabel.Columns.Add("client_name");
            mydatatabel.Columns.Add("product_name");
            //size
            mydatatabel.Columns.Add("size_name");

            //no_cans_per_pallet
            mydatatabel.Columns.Add("total_number_of_pallets");
            mydatatabel.Columns.Add("total_number_of_cans_per_pallet");
            mydatatabel.Columns.Add("total_number_of_cans");
            mydatatabel.Columns.Add("addition_date");
            long total_no_pallets = 0;
            long total_no_cans = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_FINISHED_CANS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[8];
                    mydata[0] = (counter).ToString();
                    mydata[1] = reader["SH_CLIENT_COMPANY_NAME"].ToString();
                    mydata[2] = reader["SH_PRODUCT_NAME"].ToString();
                    mydata[3] = reader["product_size"].ToString();
                    mydata[4] = reader["NUMBER_OF_PALLETS"].ToString();
                    total_no_pallets += long.Parse(reader["NUMBER_OF_PALLETS"].ToString());
                    mydata[5] = (long.Parse(reader["TOTAL_NO_CANS"].ToString()) / long.Parse(reader["NUMBER_OF_PALLETS"].ToString())).ToString();
                    total_no_cans += long.Parse(reader["TOTAL_NO_CANS"].ToString());
                    mydata[6] = reader["TOTAL_NO_CANS"].ToString();
                    mydata[7] = reader["SH_ADDITION_DATE"].ToString();
                    mydatatabel.Rows.Add(mydata);
                }

                reader.Close();
                myconnection.closeConnection();
               // MessageBox.Show("ROWS : "+mydatatabel.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETIING FINISHED CANS " + ex.ToString());
            }
            ReportParameter[] myparm = new ReportParameter[3];
            myparm[0] = new ReportParameter("total_no_pallets", total_no_pallets.ToString(), false);
            myparm[1] = new ReportParameter("total_no_cans", total_no_cans.ToString(), false);
            myparm[2] = new ReportParameter("report_presenter_name", mEmployee.SH_EMPLOYEE_NAME, false);

            this.reportViewer1.LocalReport.SetParameters(myparm);
            ReportDataSource rds = new ReportDataSource("mydataset",mydatatabel);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            //reportViewer1.DataBind();
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            
        }
    }
}
