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
    public partial class all_clients_data : Form
    {
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        long editeclientcompany = 0;
        public all_clients_data()
        {
            InitializeComponent();
        }
        void load_clients_data()
        {
            clients.Clear();
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() , SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString(),SH_CLIENT_COMPANY_MOBILE=reader["SH_CLIENT_COMPANY_MOBILE"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
            }
        }

        void fillclientsgridview()
        {
            
            clients_grid_view.Rows.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_grid_view.Rows.Add(new string[] { clients[i].SH_ID.ToString() , clients[i].SH_CLIENT_COMPANY_NAME , clients[i].SH_CLIENT_COMPANY_TELEPHONE ,  clients[i].SH_CLIENT_COMPANY_FAX_NUMBER , clients[i].SH_CLIENT_COMPANY_TYPE });
                }
            }else
            {
                MessageBox.Show("لا يوجد بيانات للعملاء" , "معلومات"  , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void add_client_branches_Click(object sender, EventArgs e)
        {
            if (clients.Count > 0)
            {
                if (clients_grid_view.SelectedRows.Count > 0)
                {
                    using (addclientbranches myform = new addclientbranches(clients[clients_grid_view.SelectedRows[0].Index]))
                    {
                        myform.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("لا بد من تحديد العميل المراد إضافة الفروع له " , "تحذير"  , MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }
            
        }

        private void all_clients_data_Load(object sender, EventArgs e)
        {
            load_clients_data();
            fillclientsgridview();
            Message_label.Text = "";
        }

        private void add_client_product_Click(object sender, EventArgs e)
        {
            if (clients.Count > 0)
            {
                if (clients_grid_view.SelectedRows.Count > 0)
                {
                    using (addnewclientproduct myform = new addnewclientproduct(clients[clients_grid_view.SelectedRows[0].Index]))
                    {
                        myform.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("لا بد من تحديد العميل المراد إضافة الأصناف له ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        void load_clients_data_search(string clientname )
        {

            clients.Clear();
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'%"+clientname+"' OR SH_CLIENT_COMPANY_NAME LIKE N'%"+clientname+"%' OR SH_CLIENT_COMPANY_NAME LIKE N'"+clientname+"%' ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
              //  cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_NAME" ,clientname);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),  SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString()  , SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString()});
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
               MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB"+ex.ToString());
            }
        }


        void searchwithclientname()
        {
            load_clients_data_search(textBox1.Text);
            fillclientsgridview();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void بحث_Click(object sender, EventArgs e)
        {
            searchwithclientname();
        }

        private void addnewclientcontacts_Click(object sender, EventArgs e)
        {
            if (clients.Count > 0)
            {
                if (clients_grid_view.SelectedRows.Count > 0)
                {
                    using (addnewclientcompanycontacts myform = new addnewclientcompanycontacts(clients[clients_grid_view.SelectedRows[0].Index]))
                    {
                        myform.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("لا بد من تحديد العميل المراد إضافة متصلين له ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void edite_client_company_btn_Click(object sender, EventArgs e)
        {
            if (clients.Count > 0)
            {
                if (clients_grid_view.SelectedRows.Count > 0)
                {
                    using (add_new_client_company_btn myform = new add_new_client_company_btn(clients[clients_grid_view.SelectedRows[0].Index]))
                    {
                        myform.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("لا بد من تحديد العميل المراد تعديل بياناته  ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void all_clients_data_Activated(object sender, EventArgs e)
        {
            //MessageBox.Show("activated");
            //Message_label.Text = "activated";
            load_clients_data();
            fillclientsgridview();
            Message_label.Text = "";

        }

        private void all_clients_data_Deactivate(object sender, EventArgs e)
        {
           // Message_label.Text = "Disactivated";
        }

        private void clients_grid_view_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void clients_grid_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int row_index = e.RowIndex;
            using (client_portal myform = new client_portal(clients[row_index]))

            {
                myform.ShowDialog();
            }
        }
    }
}
