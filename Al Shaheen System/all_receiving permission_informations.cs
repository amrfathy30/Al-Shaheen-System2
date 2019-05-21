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
    public partial class all_receiving_permission_informations : Form
    {
        List<SH_RECEIVING_PERMISSION_INFORMATION> myreceits = new List<SH_RECEIVING_PERMISSION_INFORMATION>();
        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public all_receiving_permission_informations(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS anyparm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anyparm;
        }

        void getallreceivingpermissioninformations()
        {
            myreceits.Clear();
            try
            {
                string query = "select * , (select sh_client_company_name from sh_client_company where sh_id = SH_RECEIVING_PERMISSION_INFORMATION.sh_client_id ) as client_name ";
                query += ", (select SH_CLIENTS_BRANCHES.SH_CLIENT_BRANCH_NAME  from SH_CLIENTS_BRANCHES where SH_CLIENTS_BRANCHES.sh_id = SH_RECEIVING_PERMISSION_INFORMATION.SH_CLIENT_BRANCH_ID) as clientbranchname   , ";
                query += "(select SH_EMPLOYEES.SH_EMPLOYEE_NAME from SH_EMPLOYEES where SH_EMPLOYEES.SH_ID = SH_RECEIVING_PERMISSION_INFORMATION.SH_STOCK_MAN_ID ) as stockmanname ";

                query += "from SH_RECEIVING_PERMISSION_INFORMATION order by SH_ADDITION_DATE desc";
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    myreceits.Add(new SH_RECEIVING_PERMISSION_INFORMATION() {
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                        SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                        SH_DRIVER_CAR_NUMBER = reader["SH_DRIVER_CAR_NUMBER"].ToString(),
                        SH_DRIVER_LICENSE_NUMBER = reader["SH_DRIVER_LICENSE_NUMBER"].ToString(),
                        SH_DRIVER_NAME = reader["SH_DRIVER_NAME"].ToString(),
                        SH_DRIVER_TELEPHONE_NUMBER = reader["SH_DRIVER_TELEPHONE_NUMBER"].ToString(),
                        SH_ID= long.Parse(reader["SH_ID"].ToString()),
                        SH_ORDER_NUMBER = reader["SH_ORDER_NUMBER"].ToString(),
                        SH_RECEIVING_PERMISSION_NUMBER = reader["SH_RECEIVING_PERMISSION_NUMBER"].ToString(),
                        SH_STOCK_ID = long.Parse(reader["SH_STOCK_ID"].ToString()),
                        SH_CARDBOARD_DIVIDERS = long.Parse(reader["SH_CARDBOARD_DIVIDERS"].ToString()),
                        SH_NO_PALLETS = long.Parse(reader["SH_NO_PALLETS"].ToString()),
                        SH_NO_WOOD_WINCHES = long.Parse(reader["SH_NO_WOOD_WINCHES"].ToString()),
                        SH_CLIENT_BRANCH_ID = long.Parse(reader["SH_CLIENT_BRANCH_ID"].ToString()),
                        SH_STOCK_MAN_ID = long.Parse(reader["SH_STOCK_MAN_ID"].ToString())
                        , clientname = reader["client_name"].ToString(),
                         clientbranchname = reader["clientbranchname"].ToString(),
                         stockmanname = reader["stockmanname"].ToString()

                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PERMISSION INFROMATION DATA "+ex.ToString());
            }
        }

        void fillreceitsgfridview()
        {
            getallreceivingpermissioninformations();
            allreceitsgridview.Rows.Clear();
            if (myreceits.Count > 0)
            {
                for (int i = 0; i < myreceits.Count; i++)
                {
                    allreceitsgridview.Rows.Add(new string[] {
                        (i+1).ToString(),
                        myreceits[i].SH_RECEIVING_PERMISSION_NUMBER,
                        myreceits[i].SH_ADDITION_DATE.ToString(),
                        myreceits[i].clientname,
                        myreceits[i].clientbranchname,
                       // client name 
                       // client branch_name
                       myreceits[i].SH_DRIVER_NAME,
                       myreceits[i].SH_DRIVER_CAR_NUMBER,
                       myreceits[i].SH_DRIVER_TELEPHONE_NUMBER,
                       myreceits[i].SH_DRIVER_LICENSE_NUMBER,
                       myreceits[i].SH_NO_PALLETS.ToString(),
                       myreceits[i].SH_NO_WOOD_WINCHES.ToString(),
                       myreceits[i].SH_CARDBOARD_DIVIDERS.ToString(),
                       // stock man name
                       myreceits[i].stockmanname



                    });
                }
            }
        }

        private void all_receiving_permission_informations_Load(object sender, EventArgs e)
        {
            fillreceitsgfridview();
        }

        private void all_receiving_permission_informations_Enter(object sender, EventArgs e)
        {

            fillreceitsgfridview();
        }

        private void all_receiving_permission_informations_Activated(object sender, EventArgs e)
        {
            fillreceitsgfridview();
        }

        private void allreceitsgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.ColumnIndex==1)
            {
                printreceivalpermission myform = new printreceivalpermission(myreceits[e.RowIndex].SH_RECEIVING_PERMISSION_NUMBER);
                myform.Show();
            }
        }
    }
}
