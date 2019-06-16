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
    public partial class printplasticcovertotalbalanceform : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public printplasticcovertotalbalanceform(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPermission;
        }

        private void printplasticcovertotalbalanceform_Load(object sender, EventArgs e)
        {
            long no_items = 0;
            long no_containers = 0;

            DataTable mydatatabel = new DataTable();
            mydatatabel.Columns.Add("m");
            mydatatabel.Columns.Add("container_name");
            mydatatabel.Columns.Add("no_items_per_container");
            mydatatabel.Columns.Add("no_containers");
            mydatatabel.Columns.Add("total_no_items");
            mydatatabel.Columns.Add("addition_date");
            mydatatabel.Columns.Add("client_name");
            mydatatabel.Columns.Add("pillow_color_name");
            mydatatabel.Columns.Add("size_name");
            mydatatabel.Columns.Add("logo_or_not");
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SH_SPECIFICATION_OF_PLASTIC_COVER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[10];
                    mydata[0] = counter.ToString();
                    mydata[1] = reader["SH_CONTAINER_NAME"].ToString();
                    mydata[2] = reader["SH_NO_ITEMS"].ToString();
                    mydata[3] = reader["NO_ITEMS"].ToString();
                    no_containers += long.Parse(reader["NO_ITEMS"].ToString());
                    mydata[4] = reader["TOTAL_NO_ITEMS"].ToString();
                    no_items += long.Parse(reader["TOTAL_NO_ITEMS"].ToString());
                    mydata[5] = reader["SH_ADDTION_DATE"].ToString();
                    mydata[6] = reader["CLIENT_NAME"].ToString();
                    mydata[7] = reader["PILLOW_COLOR_NAME"].ToString();
                    mydata[8] = reader["SIZE_NAME"].ToString();
                    if (long.Parse(reader["SH_LOGO_OR_NOT"].ToString())==0)
                    {
                        mydata[9] = "N";
                    }else
                    {
                        mydata[9] = "Y";
                    }
                    mydatatabel.Rows.Add(mydata);           
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTInG PLASTIC COVER DATA "+ex.ToString());
            }
            ReportParameter[] myparams = new ReportParameter[3];
            myparams[0] = new ReportParameter("report_presenter_name", mEmployee.SH_EMPLOYEE_NAME, false);
            myparams[1] = new ReportParameter("total_no_containers", no_containers.ToString(), false);
            myparams[2] = new ReportParameter("total_no_items", no_items.ToString(), false);
            this.reportViewer1.LocalReport.SetParameters(myparams);
            ReportDataSource rds = new ReportDataSource("DataSet1",mydatatabel);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
