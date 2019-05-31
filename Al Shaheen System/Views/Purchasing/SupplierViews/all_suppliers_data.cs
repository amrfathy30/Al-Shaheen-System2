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
    public partial class all_suppliers_data : Form
    {
        List<SH_SUPPLY_COMPANY> SUPPLIERS = new List<SH_SUPPLY_COMPANY>();


        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public all_suppliers_data(SH_EMPLOYEES anyemp,SH_USER_ACCOUNTS anyAccount, SH_USER_PERMISIONS anyPerm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPerm;
        }

        void loadsuppliersdata()
        {
            SUPPLIERS.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SUPPLY_COMPANY" , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SUPPLIERS.Add(new SH_SUPPLY_COMPANY() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString() , SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString() , SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString() , SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString() ,SH_SUPPLY_COMPANY_FAX=reader["SH_SUPPLY_COMPANY_FAX"].ToString()});
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS DATA" + ex.ToString());
            }
        }

        void loadsuppliersdatabyname()
        {
            SUPPLIERS.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SUPPLY_COMPANY WHERE SH_SUPPLY_COMAPNY_NAME LIKE N'%"+ search_text_box.Text+ "%'", DatabaseConnection.mConnection);
               // cmd.Parameters.AddWithValue("@SH_SUPPLY_COMAPNY_NAME" , search_text_box.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SUPPLIERS.Add(new SH_SUPPLY_COMPANY() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString(), SH_SUPPLY_COMPANY_FAX = reader["SH_SUPPLY_COMPANY_FAX"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS DATA" + ex.ToString());
            }

            if (SUPPLIERS.Count > 0)
            {
                suppliers_grid_view.Rows.Clear();
                for (int i = 0; i < SUPPLIERS.Count; i++)
                {
                    suppliers_grid_view.Rows.Add(new string[] { (i + 1).ToString(), SUPPLIERS[i].SH_ID.ToString(), SUPPLIERS[i].SH_SUPPLY_COMAPNY_NAME, SUPPLIERS[i].SH_SUPPLY_COMPANY_TELEPHONE, SUPPLIERS[i].SH_SUPPLY_COMPANY_MOBILE, SUPPLIERS[i].SH_SUPPLY_COMPANY_TYPE });
                }
            }else
            {
                MessageBox.Show("لا يوجد بيانات", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 ,  MessageBoxOptions.RtlReading);
                fillsuppliersgridview();
            }


        }
        void fillsuppliersgridview()
        {
            loadsuppliersdata();
            if (SUPPLIERS.Count > 0)
            {
                suppliers_grid_view.Rows.Clear();
                for (int i = 0; i < SUPPLIERS.Count; i++)
                {
                    suppliers_grid_view.Rows.Add(new string[] { (i+1).ToString() , SUPPLIERS[i].SH_ID.ToString() , SUPPLIERS[i].SH_SUPPLY_COMAPNY_NAME , SUPPLIERS[i].SH_SUPPLY_COMPANY_TELEPHONE , SUPPLIERS[i].SH_SUPPLY_COMPANY_MOBILE , SUPPLIERS[i].SH_SUPPLY_COMPANY_TYPE });
                }
            }
        }

        private void all_suppliers_data_Load(object sender, EventArgs e)
        {
            fillsuppliersgridview();
        }

        private void add_supply_company_branch_Click(object sender, EventArgs e)
        {
         
        }

        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            if (suppliers_grid_view.SelectedRows.Count > 0)
            {
                AddNewItemForSupplierFrm myform = new AddNewItemForSupplierFrm(SUPPLIERS[suppliers_grid_view.SelectedRows[0].Index],mEmployee,mAccount,mPermission);
                
                    myform.ShowDialog();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (suppliers_grid_view.SelectedRows.Count > 0)
            {
                using (DisplaySelectedSupplierItems myform = new DisplaySelectedSupplierItems(SUPPLIERS[suppliers_grid_view.SelectedRows[0].Index]))
                {
                    myform.ShowDialog();
                }
            }
        }

      

     

     

        private void suppliers_grid_view_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (suppliers_grid_view.SelectedRows.Count == 1)
            {
                AllSelectedSupplierDataFrm frm = new AllSelectedSupplierDataFrm(SUPPLIERS[suppliers_grid_view.SelectedRows[0].Index],mEmployee,mAccount,mPermission);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الرجاء تحديد إسم المورد أولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void add_new_supplier_item_Click(object sender, EventArgs e)
        {
            if (suppliers_grid_view.SelectedRows.Count == 1)
            {
                AddNewItemForSupplierFrm frm = new AddNewItemForSupplierFrm(SUPPLIERS[suppliers_grid_view.SelectedRows[0].Index],mEmployee,mAccount,mPermission);
                frm.ShowDialog();
            }else
            {
                MessageBox.Show("الرجاء تحديد إسم المورد أولا", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private void add_new_supplier_branch_btn_Click(object sender, EventArgs e)
        {
            if (suppliers_grid_view.SelectedRows.Count == 1)
            {
                add_new_supply_company_branch frm = new add_new_supply_company_branch(SUPPLIERS[suppliers_grid_view.SelectedRows[0].Index],mEmployee,mAccount,mPermission);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الرجاء تحديد إسم المورد أولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void add_new_supplier_contact_Click(object sender, EventArgs e)
        {
            if (suppliers_grid_view.SelectedRows.Count == 1)
            {
                addSupplierCompanyContacts frm = new addSupplierCompanyContacts(SUPPLIERS[suppliers_grid_view.SelectedRows[0].Index],mEmployee,mAccount,mPermission);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("الرجاء تحديد إسم المورد أولا", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            loadsuppliersdatabyname();
        }

        private void all_suppliers_data_Activated(object sender, EventArgs e)
        {
            fillsuppliersgridview();
        }
    }
}
