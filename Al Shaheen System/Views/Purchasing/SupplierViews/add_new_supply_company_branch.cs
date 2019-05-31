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
    public partial class add_new_supply_company_branch : Form
    {
        SH_SUPPLY_COMPANY msupply = new SH_SUPPLY_COMPANY();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        public add_new_supply_company_branch(SH_SUPPLY_COMPANY anycompany , SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            msupply = anycompany;

            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anyperm;


        }


        void fillsupplierbranchesgridview()
        {
            supplier_branches.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SUPPLY_COMPANY_BRANCHES WHERE SH_SUPPLY_COMPANY_ID = @SH_SUPPLY_COMPANY_ID"  , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_ID", msupply.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    supplier_branches.Add(new SH_SUPPLY_COMPANY_BRANCHES { SH_ID=long.Parse(reader["SH_ID"].ToString()),SH_COMPANY_BRANCH_ADDRESS_GPS_LINK=reader["SH_COMPANY_BRANCH_ADDRESS_GPS_LINK"].ToString(),SH_COMPANY_BRANCH_ADDRESS_TEXT=reader["SH_COMPANY_BRANCH_ADDRESS_TEXT"].ToString(),SH_COMPANY_BRANCH_NAME=reader["SH_COMPANY_BRANCH_NAME"].ToString(),SH_COMPANY_BRANCH_TYPE=reader["SH_COMPANY_BRANCH_TYPE"].ToString(),SH_SUPPLY_COMAPNY_ID=long.Parse(reader["SH_SUPPLY_COMPANY_ID"].ToString()),SH_SUPPLY_COMPANY_NAME=reader["SH_SUPPLY_COMPANY_NAME"].ToString()});
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPPLIER BRANCHES " + ex.ToString());
            }

            if (supplier_branches.Count > 0)
            {
                supply_company_grid_view.Rows.Clear();
                for (int i = 0; i < supplier_branches.Count; i++)
                {
                    supply_company_grid_view.Rows.Add(new string[] { (i+1).ToString() , supplier_branches[i].SH_COMPANY_BRANCH_NAME , supplier_branches[i].SH_COMPANY_BRANCH_TYPE  , supplier_branches[i].SH_COMPANY_BRANCH_ADDRESS_TEXT , supplier_branches[i].SH_COMPANY_BRANCH_ADDRESS_GPS_LINK });
                }
            }

        }


        private void add_new_supply_company_brach_Load(object sender, EventArgs e)
        {
            national_client_radio_btn.Checked = true;
            client_name_text_box.Text = msupply.SH_SUPPLY_COMAPNY_NAME;
            fillsupplierbranchesgridview();
        }

        private void client_branch_name_text_box_TextChanged(object sender, EventArgs e)
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

        private void new_client_branch_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (add_new_supply_company_branch myform = new add_new_supply_company_branch(msupply,mEmployee,mAccount,mPermission))
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_client_branch_btn_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(branch_address_text_box.Text)) || (string.IsNullOrEmpty(branch_address_link_text_box.Text)) || string.IsNullOrEmpty(client_branch_name_text_box.Text))
            {
                MessageBox.Show("لم يتم إدخال بيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
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
                    string query = "INSERT INTO SH_SUPPLY_COMPANY_BRANCHES ";
                    query += "(SH_SUPPLY_COMPANY_ID, SH_SUPPLY_COMPANY_NAME, SH_COMPANY_BRANCH_TYPE, SH_COMPANY_BRANCH_NAME, SH_COMPANY_BRANCH_ADDRESS_TEXT, ";
                    query += " SH_COMPANY_BRANCH_ADDRESS_GPS_LINK ,";
                    query += " SH_DATA_ENTRY_USER_ID , SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += " SH_ADDITION_DATE ) ";
                        query += "VALUES(@SH_SUPPLY_COMPANY_ID,@SH_SUPPLY_COMPANY_NAME,@SH_COMPANY_BRANCH_TYPE,@SH_COMPANY_BRANCH_NAME,@SH_COMPANY_BRANCH_ADDRESS_TEXT,@SH_COMPANY_BRANCH_ADDRESS_GPS_LINK)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_ID", msupply.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_NAME", msupply.SH_SUPPLY_COMAPNY_NAME);
                    cmd.Parameters.AddWithValue("@SH_COMPANY_BRANCH_NAME", client_branch_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_COMPANY_BRANCH_TYPE", branchetype);
                    cmd.Parameters.AddWithValue("@SH_COMPANY_BRANCH_ADDRESS_TEXT", branch_address_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_COMPANY_BRANCH_ADDRESS_GPS_LINK", branch_address_link_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID );
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID",mEmployee.SH_ID ) ;
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now );
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    fillsupplierbranchesgridview();
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING CLIENT BRANCH NAME " + ex.ToString());
                }
            }
        }
    }
}
