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
    public partial class clientreceivalpermissionnumberform : Form
    {
        List<SH_CLIENTS_BRANCHES> client_branches = new List<SH_CLIENTS_BRANCHES>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public clientreceivalpermissionnumberform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (clientreceivalpermissionnumberproducts myform = new clientreceivalpermissionnumberproducts(clients[clients_combo_box.SelectedIndex]))
            {
                myform.ShowDialog();
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
                SqlDataReader reader =  cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY() { SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString()
                      ,SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString()
                      ,SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString()
                      ,  SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString()
                      ,SH_ID =long.Parse(reader["SH_ID"].ToString())
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
                    client_branches.Add(new SH_CLIENTS_BRANCHES() {
                         SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString(),
                         SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString() , 
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
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH DATA "+ex.ToString());
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

        private async void clientreceivalpermissionnumberform_Load(object sender, EventArgs e)
        {
            await fillclientscombobox();
        }

        private async void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                await fillclientbranchescombobox();
            }

        }
    }
}
