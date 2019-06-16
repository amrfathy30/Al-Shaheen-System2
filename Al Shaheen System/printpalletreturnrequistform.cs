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
    public partial class printpalletreturnrequistform : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        string returnpermissionnumber;
        public printpalletreturnrequistform(string anyreturnnumber)
        {
            InitializeComponent();
            returnpermissionnumber = anyreturnnumber;
        }

        private void printpalletreturnrequistform_Load(object sender, EventArgs e)
        {
            string drivername = "";
            string requistnumber = "";
            string clientname = "";
            DateTime additiondate = DateTime.Now;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * , (select cc.sh_client_company_name from sh_client_company cc where cc.sh_id = SH_CLIENT_ID ) as clientname FROM SH_PALLETS_RETURN_REQUIST WHERE SH_PALLETS_RETURN_REQUIST_NUMBER LIKE N'%"+ returnpermissionnumber+"%'", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    drivername = reader["SH_DRIVER_NAME"].ToString();
                    requistnumber = reader["SH_PALLETS_RETURN_REQUIST_NUMBER"].ToString();
                    clientname = reader["clientname"].ToString();
                    additiondate = DateTime.Parse(reader["SH_ADDTION_DATE"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ADDING PALLET RETURN REQUIST "+ex.ToString());
            }
            ReportParameter[] myparm = new ReportParameter[4];
            myparm[0] = new ReportParameter("requist_addition_date", additiondate.ToString(), true);
            myparm[1] = new ReportParameter("requist_client_name", clientname, true);
            myparm[2] = new ReportParameter("requist_driver_name", drivername, true);
            myparm[3] = new ReportParameter("returnpermissionnumber", returnpermissionnumber, true);
            this.reportViewer1.LocalReport.SetParameters(myparm);
            this.reportViewer1.RefreshReport();
        }
    }
}
