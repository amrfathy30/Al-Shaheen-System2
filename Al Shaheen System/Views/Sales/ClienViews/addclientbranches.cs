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
    public partial class addclientbranches : Form
    {
        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        List<SH_CLIENTS_BRANCHES> client_branches = new List<SH_CLIENTS_BRANCHES>();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;


        public addclientbranches(SH_CLIENT_COMPANY anyclient ,SH_EMPLOYEES anyemp,SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPerm)
        {
            this.mclient = anyclient;
            InitializeComponent();

            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPerm;


        }
        void fillclientbranchesgridview()
        {
            client_branches.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENTS_BRANCHES WHERE SH_CLIENT_ID = @SH_CLIENT_ID" , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_branches.Add(new SH_CLIENTS_BRANCHES() { SH_ID = long.Parse(reader["SH_ID"].ToString())  , SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString() , SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString() , SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString() , SH_CLIENT_BRANCH_TYPE = reader["SH_CLIENT_BRANCH_TYPE"].ToString() , SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString()});
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH FROM DB " +ex.ToString());
            }

            if (client_branches.Count > 0)
            {
                client_branches_grid_view.Rows.Clear();
                for (int i = 0; i < client_branches.Count; i++)
                {
                    client_branches_grid_view.Rows.Add(new string[] {(i+1).ToString() ,  client_branches[i].SH_CLIENT_BRANCH_NAME , client_branches[i].SH_CLIENT_BRANCH_TYPE , client_branches[i].SH_CLIENT_BRANCH_ADDRESS_TEXT  , client_branches[i].SH_CLIENT_BRANCH_ADDRESS_GPS_LINK });
                }

            }


        }
        private void new_client_branch_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            addclientbranches myform = new addclientbranches(mclient,mEmployee,mAccount,mPermission);
            
                myform.ShowDialog();
            
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addclientbranches_Load(object sender, EventArgs e)
        {
            national_client_radio_btn.Checked = true;
            client_name_text_box.Text = mclient.SH_CLIENT_COMPANY_NAME;
            fillclientbranchesgridview();
        }

        private void save_client_branch_btn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(branch_address_text_box.Text)) || (string.IsNullOrEmpty(branch_address_link_text_box.Text)) || string.IsNullOrEmpty(client_branch_name_text_box.Text))
            {
                MessageBox.Show("لم يتم إدخال بيانات بشكل صحيح " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                string branchetype = "";

                if (national_client_radio_btn.Checked)
                {
                    branchetype = "محلى";
                }
                else
                {
                    branchetype = "دولى";
                }

                try
                {
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    string query = "INSERT INTO SH_CLIENTS_BRANCHES(SH_CLIENT_ID, ";
                    query += " SH_CLIENT_COMPANY_NAME, SH_CLIENT_BRANCH_NAME, ";
                    query += " SH_CLIENT_BRANCH_TYPE, SH_CLIENT_BRANCH_ADDRESS_TEXT, ";
                    query += "SH_CLIENT_BRANCH_ADDRESS_GPS_LINK ";
                    query += " , SH_DATA_ENTRY_USER_ID , SH_DATA_ENTRY_EMPLOYEE_ID , SH_ADDITION_DATE ";
                    query += " ) VALUES ( @SH_CLIENT_ID, ";
                    query += " @SH_CLIENT_COMPANY_NAME, @SH_CLIENT_BRANCH_NAME , ";
                    query += " @SH_CLIENT_BRANCH_TYPE, @SH_CLIENT_BRANCH_ADDRESS_TEXT,";
                    query += " @SH_CLIENT_BRANCH_ADDRESS_GPS_LINK ";
                    query += " , @SH_DATA_ENTRY_USER_ID , @SH_DATA_ENTRY_EMPLOYEE_ID , @SH_ADDITION_DATE ";
                    query += " )";
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_NAME", mclient.SH_CLIENT_COMPANY_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_NAME", client_branch_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_TYPE", branchetype);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_ADDRESS_TEXT", branch_address_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_ADDRESS_GPS_LINK", branch_address_link_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    fillclientbranchesgridview();
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING CLIENT BRANCH NAME " + ex.ToString());
                }
            }
        }

        private void client_branch_name_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(client_branch_name_text_box.Text))
            {
                errorProvider1.SetError(client_branch_name_text_box , "لم يتم إدخال بيانات");
            }else
            {
                errorProvider1.Clear();
            }
        }

        private void branch_address_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(client_branch_name_text_box.Text))
            {
                errorProvider1.SetError(client_branch_name_text_box, "لم يتم إدخال بيانات");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void branch_address_link_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(branch_address_link_text_box.Text))
            {
                errorProvider1.SetError(branch_address_link_text_box, "لم يتم إدخال بيانات");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void client_name_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
