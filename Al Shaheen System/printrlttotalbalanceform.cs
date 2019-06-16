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
    public partial class printrlttotalbalanceform : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        public printrlttotalbalanceform(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyAccount, SH_USER_PERMISIONS anyPermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPermission;
        }

        private void printrlttotalbalanceform_Load(object sender, EventArgs e)
        {
            long total_no_items = 0;
            long total_no_containers = 0;
            long total_no_pallets = 0;
            long total_no_cartons = 0;

            DataTable mydatatabel = new DataTable();
            mydatatabel.Columns.Add("m");
            mydatatabel.Columns.Add("item_material_type");
            mydatatabel.Columns.Add("printing_type");
            mydatatabel.Columns.Add("size_name");
            mydatatabel.Columns.Add("client_name");
            mydatatabel.Columns.Add("first_face");
            mydatatabel.Columns.Add("second_face");
            mydatatabel.Columns.Add("container_name");
            mydatatabel.Columns.Add("no_items_per_container");
            mydatatabel.Columns.Add("total_no_items");
            mydatatabel.Columns.Add("usage");
            mydatatabel.Columns.Add("addition_date");

            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFICATION_OF_RLT", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[12];
                    mydata[0] = counter.ToString();
                    mydata[1] = reader["SH_RAW_MATERIAL_TYPE"].ToString();
                    mydata[2] = reader["SH_PRINTING_TYPE_NAME"].ToString();
                    if (long.Parse(reader["SH_PRINTING_TYPE"].ToString()) == 0)
                    {
                        mydata[3] = reader["SIZE_NAME"].ToString();
                        mydata[4] = reader["CLIENT_NAME"].ToString();
                        mydata[5] = reader["CLIENT_PRODUCT_NAME"].ToString();
                        mydata[6] = reader["PRODUCT_SECOND_FACE"].ToString();
                    }
                    else
                    {
                        mydata[3] = reader["SIZE_NAME"].ToString();
                        mydata[4] = "عام";
                        mydata[5] = reader["FIRST_FACE"].ToString();
                        mydata[6] = reader["SECOND_FACE"].ToString();
                    }

                    mydata[7] = reader["SH_CONTAINER_NAME"].ToString();
                    if (string.Compare(reader["SH_CONTAINER_NAME"].ToString(), "بالتة") == 0)
                    {
                        total_no_pallets += long.Parse(reader["NUMBER_OF_CONTAINERS"].ToString());
                    }
                    else
                    {
                        total_no_cartons += long.Parse(reader["NUMBER_OF_CONTAINERS"].ToString());
                    }
                    total_no_containers += long.Parse(reader["NUMBER_OF_CONTAINERS"].ToString());
                    mydata[8] = (long.Parse(reader["NO_ITEMS"].ToString()) / long.Parse(reader["NUMBER_OF_CONTAINERS"].ToString())).ToString();
                    total_no_items += long.Parse(reader["NO_ITEMS"].ToString());
                    mydata[9] = reader["NO_ITEMS"].ToString();
                    mydata[10] = reader["SH_USAGE"].ToString();
                    mydata[11] = reader["SH_ADDITION_DATE"].ToString();
                    mydatatabel.Rows.Add(mydata);
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING BOTTOM INFO " + ex.ToString());
            }

            ReportParameter[] myparams = new ReportParameter[6];
            myparams[0] = new ReportParameter("total_no_items", total_no_items.ToString(), false);
            myparams[1] = new ReportParameter("total_no_containers", total_no_containers.ToString(), false);
            myparams[2] = new ReportParameter("total_no_pallets", total_no_pallets.ToString(), false);
            myparams[3] = new ReportParameter("total_no_cartons", total_no_cartons.ToString(), false);
            myparams[4] = new ReportParameter("report_presenter_name", mEmployee.SH_EMPLOYEE_NAME, false);
            myparams[5] = new ReportParameter("doc_title_text", "الأرصدة من المنتج التام ( RLT )", false);
            this.reportViewer1.LocalReport.SetParameters(myparams);
            ReportDataSource rds = new ReportDataSource("DataSet1", mydatatabel);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
