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
    public partial class addnewacccounttreeitem : Form
    {
        List<SH_ACCOUNTING_ACCOUNTS_TREE> tree_items = new List<SH_ACCOUNTING_ACCOUNTS_TREE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewacccounttreeitem()
        {
            InitializeComponent();
        }

        async Task<long> getcurrentaccountnumberbymotherid(long parent_id)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_CURRENT_CHILD_ACCOUNT_NUMBER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_PARENT_ACCOUNT_ID", parent_id);
                SqlDataReader reader = cmd.ExecuteReader();
                long numberofitems = 0;
                
                if (reader.Read())
                {
                    numberofitems = long.Parse(reader["account_current_number"].ToString());
                }
                reader.Close();
                myconnection.openConnection();
                return numberofitems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING GETTING ACCOUT CHILD NUMBER "+ex.ToString());
            }
            return 0;
        }



        async Task getalltreeitems ()
        {
            tree_items.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd  = new SqlCommand("SH_GET_ALL_SH_ACCOUNTING_ACCOUNTS_TREE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tree_items.Add(new SH_ACCOUNTING_ACCOUNTS_TREE() { SH_ACCOUNT_ACTIVE = long.Parse(reader["SH_ACCOUNT_ACTIVE"].ToString()), SH_ACCOUNT_LEVEL = long
                        .Parse(reader["SH_ACCOUNT_LEVEL"].ToString()),
                        SH_ACCOUNT_NAME = reader["SH_ACCOUNT_NAME"].ToString(),
                        SH_ACCOUNT_NO = reader["SH_ACCOUNT_NO"].ToString(),
                        SH_ACCOUNT_REVENU_AND_COST_CENTER_ID = long.Parse(reader["SH_ACCOUNT_REVENU_AND_COST_CENTER_ID"].ToString()),
                        SH_ACCOUNT_REVENU_AND_COST_CENTER_NAME = reader["SH_ACCOUNT_REVENU_AND_COST_CENTER_NAME"].ToString(),
                        SH_ACCOUNT_TYPE_ID = long.Parse(reader["SH_ACCOUNT_TYPE_ID"].ToString()),
                        SH_ACCOUNT_TYPE_NAME = reader["SH_ACCOUNT_TYPE_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_LAST_LEVEL_OR_NOT = long.Parse(reader["SH_LAST_LEVEL_OR_NOT"].ToString()),
                        SH_PARENT_ACCOUNT_ID = long.Parse(reader["SH_PARENT_ACCOUNT_ID"].ToString()),
                        SH_PARENT_ACCOUNT_NO = reader["SH_PARENT_ACCOUNT_NO"].ToString()
                    });
                }
                reader.Read();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL ACCOUTING TREE ITEMS "+ex.ToString());
            }
        }

        async Task fillaccountscombobox()
        {
            getalltreeitems();
            mother_branch_tree_account.Items.Clear();
            if (tree_items.Count>0)
            {
                for (int i = 0; i < tree_items.Count; i++)
                {
                    mother_branch_tree_account.Items.Add(tree_items[i].SH_ACCOUNT_NO + tree_items[i].SH_ACCOUNT_NAME);
                }
            }
        }
        

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewacccounttreeitem myform = new addnewacccounttreeitem())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private async void addnewacccounttreeitem_Load(object sender, EventArgs e)
        {
            await fillaccountscombobox();
           
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            if (string.IsNullOrWhiteSpace(mother_branch_tree_account.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(account_name.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(account_type_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(revenu_and_cost_center_combo_box.Text))
            {
                cansave = false;
            }

            if(cansave)
            {
                long last_or_not = 0;
                if (last_child_or_not.Checked)
                {
                    last_or_not = 1;
                }else
                {
                    last_or_not = 0;
                }

                long active_or_not = 0;
                if (active_check_box.Checked)
                {
                        active_or_not = 1;
                }else
                {
                        active_or_not = 0;
                }


                try
                {
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand("SH_ADD_NEW_ACCOUNTING_ACCOUNTS_TREE", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_NO", account_code.Text);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_NAME", account_name.Text);
                    cmd.Parameters.AddWithValue("@SH_PARENT_ACCOUNT_ID", tree_items[mother_branch_tree_account.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PARENT_ACCOUNT_NO", tree_items[mother_branch_tree_account.SelectedIndex].SH_ACCOUNT_NO);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_LEVEL", tree_items[mother_branch_tree_account.SelectedIndex].SH_ACCOUNT_LEVEL+1);
                    cmd.Parameters.AddWithValue("@SH_LAST_LEVEL_OR_NOT", last_or_not);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_ACTIVE", active_or_not);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_TYPE_NAME", account_type_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_TYPE_ID", account_type_combo_box.SelectedIndex);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_REVENU_AND_COST_CENTER_ID", revenu_and_cost_center_combo_box.SelectedIndex);
                    cmd.Parameters.AddWithValue("@SH_ACCOUNT_REVENU_AND_COST_CENTER_NAME", revenu_and_cost_center_combo_box.Text);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING NEW ACCOUNT TREE ITEM "+ex.ToString());
                }
            }
                    
         }

        private async void mother_branch_tree_account_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mother_branch_tree_account.SelectedIndex > -1)
            {
                account_code.Text = tree_items[mother_branch_tree_account.SelectedIndex].SH_ACCOUNT_NO+(await getcurrentaccountnumberbymotherid(tree_items[mother_branch_tree_account.SelectedIndex].SH_ID)).ToString();
                account_level.Text = (tree_items[mother_branch_tree_account.SelectedIndex].SH_ACCOUNT_LEVEL + 1).ToString();
            }
        }

        private void account_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void addnewacccounttreeitem_Activated(object sender, EventArgs e)
        {
            await fillaccountscombobox();
        }
    }
}
