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
    public partial class summary_receiving_information_form : Form
    {
        List<summary_receiving_information_quantity_data> mydata = new List<summary_receiving_information_quantity_data>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_BRANCHES> client_branches = new List<SH_CLIENTS_BRANCHES>();
        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public summary_receiving_information_form(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyAcount , SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAcount;
            mPermission = anyperm;
        }

        void getallquantities()
        {
            string client_name = "";
            bool client_data = false;
            string client_branch_name = "";
            bool client_branch_data = false;
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                client_name = "";
                client_data = false;
            }else
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


            mydata.Clear();
            try
            {
                myconnection.openConnection();
                string query = "SELECT SRPI.SH_CLIENT_ID ,  ";
                query += "(select cc.SH_CLIENT_COMPANY_NAME from SH_CLIENT_COMPANY cc where cc.SH_ID = SRPI.SH_CLIENT_ID ) as client_name, ";
                query += " (SELECT CCB.SH_CLIENT_BRANCH_NAME FROM SH_CLIENTS_BRANCHES CCB WHERE CCB.SH_ID = SRPI.SH_CLIENT_BRANCH_ID )  ";
                query += "  AS CLIENT_BRANCH_NAME ,";
                query += " SRPQI.SH_ITEM_NAME , SRPQI.SH_ITEM_CONTAINER ,  ";
                query += " sum(SRPQI.SH_NO_CONTAINERS) as number_containers , sum(SRPQI.SH_TOTAL_NO_ITEMS) as total_quantity ";
                query += " FROM SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION  SRPQI ";
                query += " left join SH_RECEIVING_PERMISSION_INFORMATION SRPI ";
                query += " on SRPQI.SH_RECEIVING_PERMISSION_INFORMATION_ID = SRPI.SH_ID ";
                query += " where 1 = 1 "+ client_name + client_branch_name ;
                query += " group by SRPI.SH_CLIENT_ID ,SRPI.SH_CLIENT_BRANCH_ID  ,";
                query += " SRPQI.SH_ITEM_NAME ,SRPQI.SH_ITEM_CONTAINER ";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client_data)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);

                }

                if (client_branch_data)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_ID", client_branches[client_branches_combo_box.SelectedIndex].SH_ID );
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mydata.Add(new summary_receiving_information_quantity_data() {
                        client_name = reader["client_name"].ToString(),
                        client_branch_name = reader["CLIENT_BRANCH_NAME"].ToString(),
                        item_name = reader["SH_ITEM_NAME"].ToString(),
                        client_id = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        no_containers = long.Parse(reader["number_containers"].ToString()),
                        no_items = long.Parse(reader["total_quantity"].ToString()),
                        container_name = reader["SH_ITEM_CONTAINER"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS SUMMARY DATA "+ex.ToString());
            }

            if (mydata.Count > 0)
            {
                receving_permission_quantities_grid_view.Rows.Clear();
                for (int i = 0; i < mydata.Count; i++)
                {
                    string[] mydatavalues = new string[7];
                    mydatavalues[0] = (i + 1).ToString();
                    mydatavalues[1] = (mydata[i].client_name).ToString();
                    mydatavalues[2] = (mydata[i].client_branch_name).ToString();
                    mydatavalues[3] = (mydata[i].item_name).ToString();
                    mydatavalues[4] = (mydata[i].container_name).ToString();
                    mydatavalues[5] = (mydata[i].no_containers).ToString();
                    mydatavalues[6] = (mydata[i].no_items).ToString();

                    receving_permission_quantities_grid_view.Rows.Add(mydatavalues);
                }
            }


        }
        async Task getallclientsdata()
        {
            clients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENTS_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY()
                    {
                        SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString()
                      ,
                        SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString()
                      ,
                        SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString()
                      ,
                        SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString()
                      ,
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG ALL CLIENTS DATA ");
            }
        }
        async Task fillclientscombobox()
        {
            await getallclientsdata();
            clients_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }
        private async void summary_receiving_information_form_Load(object sender, EventArgs e)
        {
            await fillclientscombobox();
            getallquantities();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getallquantities();
        }
        async Task getallclientbranchdata()
        {
            client_branches.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENT_BRANCHES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_branches.Add(new SH_CLIENTS_BRANCHES()
                    {
                        SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString(),
                        SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(),
                        SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(),
                        SH_CLIENT_BRANCH_TYPE = reader["SH_CLIENT_BRANCH_TYPE"].ToString(),
                        SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH DATA " + ex.ToString());
            }
        }
        async Task fillclientbranchescombobox()
        {
            await getallclientbranchdata();
            client_branches_combo_box.Items.Clear();
            if (client_branches.Count > 0)
            {
                for (int i = 0; i < client_branches.Count; i++)
                {
                    client_branches_combo_box.Items.Add(client_branches[i].SH_CLIENT_BRANCH_NAME);
                }
            }
        }
        private async void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                await fillclientbranchescombobox();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            printsumary_receiving_permission_items myform = new printsumary_receiving_permission_items(mydata , mEmployee ,mAccount,mPermission);
            myform.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            allsaledquantitiesinformationformbydate myform = new allsaledquantitiesinformationformbydate();
            myform.Show();
        }
    }
}
