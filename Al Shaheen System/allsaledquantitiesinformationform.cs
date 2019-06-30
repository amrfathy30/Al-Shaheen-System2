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
    public partial class allsaledquantitiesinformationformbydate : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_BRANCHES> client_branches = new List<SH_CLIENTS_BRANCHES>();

        List<allsolditemsfullinformationdetails> mydata = new List<allsolditemsfullinformationdetails>();

        public allsaledquantitiesinformationformbydate()
        {
            InitializeComponent();
        }

        void fillallsoldquantities()
        {
            mydata.Clear();
            string client_name = "";
            bool client_data = false;
            string client_branch_name = "";
            bool client_branch_data = false;
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                client_name = "";
                client_data = false;
            }
            else
            {
                client_name = " AND  SRPI.SH_CLIENT_ID = @SH_CLIENT_ID";
                client_data = true;
            }

            if (string.IsNullOrWhiteSpace(client_branches_combo_box.Text))
            {
                client_branch_name = "";
                client_branch_data = false;
            }
            else
            {
                client_branch_name = " AND SRPI.SH_CLIENT_BRANCH_ID =@SH_CLIENT_BRANCH_ID ";
                client_branch_data = true;
            }

            try
            {
                myconnection.openConnection();
                string query = " select SRPI.SH_RECEIVING_PERMISSION_NUMBER, SRPI.SH_ADDITION_DATE, ";
                query += " CC.SH_CLIENT_COMPANY_NAME , CCB.SH_CLIENT_BRANCH_NAME ,SEPIQI.SH_ITEM_NAME , ";
                query += " SEPIQI.SH_ITEM_CONTAINER ,SEPIQI.SH_NO_ITEMS_PER_CONTAINER,SEPIQI.SH_NO_CONTAINERS ,SEPIQI.SH_TOTAL_NO_ITEMS , ";
                query += " SRPI.SH_DRIVER_NAME,SS.SH_STOCK_NAME , SEMP.SH_EMPLOYEE_NAME ";
                query += " from SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION SEPIQI ";
                query += " left join SH_RECEIVING_PERMISSION_INFORMATION SRPI ";
                query += " on SEPIQI.SH_RECEIVING_PERMISSION_INFORMATION_ID = SRPI.SH_ID ";
                query += " LEFT JOIN SH_CLIENT_COMPANY CC ON ";
                query += "  CC.SH_ID = SRPI.SH_CLIENT_ID ";
                query += "  LEFT JOIN SH_CLIENTS_BRANCHES CCB ON ";
                query += "  CCB.SH_ID = SRPI.SH_CLIENT_BRANCH_ID ";
                query += "  LEFT JOIN SH_SHAHEEN_STOCKS SS ON ";
                query += "  SS.SH_ID = SRPI.SH_STOCK_ID ";
                query += " LEFT JOIN SH_EMPLOYEES SEMP ON ";
                query += " SEMP.SH_ID = SRPI.SH_STOCK_MAN_ID ";
                query += "  WHERE 1=1  "+ client_name + client_branch_name;
               
                query += " AND SRPI.SH_ADDITION_DATE BETWEEN @date_one AND @date_two ";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@date_one", DateTime.Parse(start_date_one.Text));
                cmd.Parameters.AddWithValue(" @date_two", DateTime.Parse(end_date_two.Text));
                if (client_data)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);

                }

                if (client_branch_data)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_ID", client_branches[client_branches_combo_box.SelectedIndex].SH_ID);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mydata.Add(new allsolditemsfullinformationdetails() {
                        client_branch_name = reader["SH_CLIENT_BRANCH_NAME"].ToString(),
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        container_name= reader["SH_ITEM_CONTAINER"].ToString(),
                        driver_name = reader["SH_DRIVER_NAME"].ToString(),
                        //no_carton_dividers = long.Parse(),

                        no_containers = long.Parse(reader["SH_NO_CONTAINERS"].ToString()),
                        no_items_per_container = long.Parse(reader["SH_NO_ITEMS_PER_CONTAINER"].ToString()),
                        //no_pallets = long.Parse(),
                        //no_wooden_faces = long.Parse(),
                        receival_permission_date = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        receival_permission_number = reader["SH_RECEIVING_PERMISSION_NUMBER"].ToString(),
                        stock_man_name = reader["SH_EMPLOYEE_NAME"].ToString(),
                        stock_name  = reader["SH_STOCK_NAME"].ToString(),
                        total_number_of_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                        

                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERROR WHILE GETTING SOLD DATA "+ex.ToString());
            }

            if (mydata.Count>0)
            {
                total_receival_information_quantities_data_grid_view.Rows.Clear();
                for (int i = 0; i < mydata.Count; i++)
                {
                    string[] myvalues = new string[13];
                    myvalues[0] = (i+1).ToString();
                }
            }


        }


        private void allsaledquantitiesinformationformbydate_Load(object sender, EventArgs e)
        {
            
        }
    }
}
