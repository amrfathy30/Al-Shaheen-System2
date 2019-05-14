using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions;
using System.Data.SqlClient;

namespace Al_Shaheen_System
{
    public partial class printreceivalpermission : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();

        public string order_number { get; set; }
        public string stock_name { get; set; }
        public string stock_man_name { get; set; }
        public string client_name { get; set; }
        public string client_branch { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public string SH_DRIVER_NAME { get; set; }
        public string SH_DRIVER_TELEPHONE_NUMBER { get; set; }
        public string SH_DRIVER_LICENSE_NUMBER { get; set; }
        public string SH_DRIVER_CAR_NUMBER { get; set; }
        public long SH_NO_PALLETS { get; set; }
        public long SH_NO_WOOD_WINCHES { get; set; }
        public long SH_CARDBOARD_DIVIDERS { get; set; }
        // public string SH_ORDER_NUMBER { get; set; }

        DataTable mdatatabel = new DataTable();

        List<SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION> order_items = new List<SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION>();
        public printreceivalpermission(string any_number)
        {
            InitializeComponent();
            order_number = any_number;
        }

        public async Task getorderinformation (string number)
        {
            try
            {
                myconnection.openConnection();
                string query = "SELECT TOP(1)RPI.* ,";
                query += "(SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID  = RPI.SH_CLIENT_ID ) AS SH_CLIENT_COMPANY_NAME , ";
                query += "(SELECT CCB.SH_CLIENT_BRANCH_NAME FROM SH_CLIENTS_BRANCHES CCB WHERE CCB.SH_ID = RPI.SH_CLIENT_BRANCH_ID ) AS SH_CLIENT_BRANCH_NAME , ";
                query += "(SELECT SSK.SH_STOCK_NAME FROM SH_SHAHEEN_STOCKS SSK WHERE SSK.SH_ID = RPI.SH_STOCK_ID ) AS SH_STOCK_NAME ,";
                query += "(SELECT EMP.SH_EMPLOYEE_NAME FROM SH_EMPLOYEES EMP WHERE EMP.SH_ID = RPI.SH_STOCK_MAN_ID ) AS SH_EMPLOYEE_NAME ";
                query += "FROM SH_RECEIVING_PERMISSION_INFORMATION RPI WHERE RPI.SH_RECEIVING_PERMISSION_NUMBER LIKE N'%" + number + "%'";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    order_number = reader["SH_RECEIVING_PERMISSION_NUMBER"].ToString();
                    stock_name = reader["SH_STOCK_NAME"].ToString();
                    stock_man_name = reader["SH_EMPLOYEE_NAME"].ToString();
                    client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString();
                    client_branch = reader["SH_CLIENT_BRANCH_NAME"].ToString();
                    SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString());
                    SH_DRIVER_NAME = reader["SH_DRIVER_NAME"].ToString();
                    SH_DRIVER_TELEPHONE_NUMBER = reader["SH_DRIVER_TELEPHONE_NUMBER"].ToString();
                    SH_DRIVER_LICENSE_NUMBER = reader["SH_DRIVER_LICENSE_NUMBER"].ToString();
                    SH_DRIVER_CAR_NUMBER = reader["SH_DRIVER_CAR_NUMBER"].ToString();
                    SH_NO_PALLETS = long.Parse(reader["SH_NO_PALLETS"].ToString());
                    SH_NO_WOOD_WINCHES = long.Parse(reader["SH_NO_WOOD_WINCHES"].ToString());
                    SH_CARDBOARD_DIVIDERS = long.Parse(reader["SH_CARDBOARD_DIVIDERS"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG RECEIVING ORDER DATA "+ex.ToString());
            }
        }

        public async Task getallorderinformationitems ()
        {
            order_items.Clear();
            try
            {
                myconnection.openConnection();
                string query = "SELECT RPIQI.* ";
                query += "FROM SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION RPIQI WHERE ";
                query += "SH_RECEIVING_PERMISSION_NUMBER LIKE N'%"+ order_number+"%'";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    order_items.Add(new SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION() {
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_ITEM_CONTAINER = reader["SH_ITEM_CONTAINER"].ToString(),
                        SH_ITEM_NAME = reader["SH_ITEM_NAME"].ToString(),
                        SH_ITEM_RECEIT_NUMBER = reader["SH_ITEM_RECEIT_NUMBER"].ToString(),
                        SH_ITEM_TYPE_NAME = reader["SH_ITEM_TYPE_NAME"].ToString(),
                        SH_NO_CONTAINERS= long.Parse(reader["SH_NO_CONTAINERS"].ToString()),
                        SH_NO_ITEMS_PER_CONTAINER= long.Parse(reader["SH_NO_ITEMS_PER_CONTAINER"].ToString()),
                        SH_RECEIVING_PERMISSION_INFORMATION_ID= long.Parse(reader["SH_RECEIVING_PERMISSION_INFORMATION_ID"].ToString()),
                        SH_RECEIVING_PERMISSION_NUMBER= reader["SH_RECEIVING_PERMISSION_NUMBER"].ToString(),
                        SH_TOTAL_NO_ITEMS= long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }

                reader.Close();
                myconnection.closeConnection();


            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlLE GETTING NEW ORdER INFORMATION ITEMS "+ex.ToString());
            }
        }


        private async void printreceivalpermission_Load(object sender, EventArgs e)
        {
            mdatatabel.Columns.Add("No");
            mdatatabel.Columns.Add("SH_ITEM_TYPE");
            mdatatabel.Columns.Add("SH_ITEM_NAME");
            mdatatabel.Columns.Add("SH_ITEM_CONTAINER");
            mdatatabel.Columns.Add("SH_NO_CONTAINERS");
            mdatatabel.Columns.Add("SH_NO_ITEMS_PER_CONTAINER");
            mdatatabel.Columns.Add("SH_TOTAL_NO_ITEMS");
            await getorderinformation(order_number);
            await getallorderinformationitems();
            for (int i = 0; i < order_items.Count; i++)
            {
                string[] mydata = new string[7];
                mydata[0] = (i + 1).ToString();
                mydata[1] = order_items[i].SH_ITEM_TYPE_NAME;
                mydata[2] = order_items[i].SH_ITEM_NAME;
                mydata[3] = order_items[i].SH_ITEM_CONTAINER;
                mydata[4] = order_items[i].SH_NO_CONTAINERS.ToString();
                mydata[5] = order_items[i].SH_NO_ITEMS_PER_CONTAINER.ToString();
                mydata[6] = order_items[i].SH_TOTAL_NO_ITEMS.ToString();

                mdatatabel.Rows.Add(mydata);
            }
            client_receit_order_report myreport = new client_receit_order_report();
            myreport.Database.Tables["Client_order_items"].SetDataSource(mdatatabel);
            myreport.SetParameterValue("clientreceitnumber", order_number+ " : إذن رقم");
            myreport.SetParameterValue("drivername", "إسم السائق : " + SH_DRIVER_NAME);
            myreport.SetParameterValue("drivercarnumber", "رقم السيارة : " + SH_DRIVER_CAR_NUMBER);
            myreport.SetParameterValue("driverlisencenumber", "رقم رخصة القيادة : "+SH_DRIVER_LICENSE_NUMBER);
            myreport.SetParameterValue("clientname", "  إسم العميل :  "+client_name);
            myreport.SetParameterValue("clientbranchname", " مكان التسليم : "+client_branch);
            myreport.SetParameterValue("stockname", " المخزن  : "+stock_name);
            myreport.SetParameterValue("stockmanname", "أمين المخزن : "+stock_man_name);
            myreport.SetParameterValue("additiondate", DateTime.Now);
            myreport.SetParameterValue("1stfieldname","عدد البالتات");
            myreport.SetParameterValue("1stfieldvalue", SH_NO_PALLETS);
            myreport.SetParameterValue("2ndfieldname", "عدد الفواصل الكرتون");
            myreport.SetParameterValue("2ndfieldvalue", SH_CARDBOARD_DIVIDERS);
            myreport.SetParameterValue("3rdfieldname", "عدد الزوايا الكوتونية");
            myreport.SetParameterValue("3rdfieldvalue", SH_NO_WOOD_WINCHES);

            crystalReportViewer2.ReportSource = myreport;
            crystalReportViewer2.Refresh();
        }
    }
}
