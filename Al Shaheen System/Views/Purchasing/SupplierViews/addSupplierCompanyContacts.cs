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
    public partial class addSupplierCompanyContacts : Form
    {
        SH_SUPPLY_COMPANY Mcompany = new SH_SUPPLY_COMPANY();
        //List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLIER_COMPANY_CONTACTS> supply_contacts = new List<SH_SUPPLIER_COMPANY_CONTACTS>();

        SH_EMPLOYEES mEmployees;
        SH_USER_ACCOUNTS mAccounts;
        SH_USER_PERMISIONS mPermissions;



        public addSupplierCompanyContacts(SH_SUPPLY_COMPANY comp , SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPermission)
        {
            InitializeComponent();
            Mcompany = comp;
            mEmployees = anyemp;
            mAccounts = anyAccount;
            mPermissions = anyPermission;
        }
        void loadDataGridEmployees()
        {
            supply_contacts.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select * from SH_SUPPLIER_COMPANY_CONTACTS where SH_SUPPLIER_COMPANY_CONTACT_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", Mcompany.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    supply_contacts.Add(new SH_SUPPLIER_COMPANY_CONTACTS { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLIER_COMPANY_CONTACT_EMAIL = reader["SH_SUPPLIER_COMPANY_CONTACT_EMAIL"].ToString(), SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE = reader["SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE"].ToString(), SH_SUPPLIER_COMPANY_CONTACT_NAME = reader["SH_SUPPLIER_COMPANY_CONTACT_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING Supplier employees Contacts " + ex.ToString());
            }
        }

        int check_if_client_company_contact_exists_or_not()
        {
            if (supply_contacts.Count>0)
            {
                for (int i = 0; i < supply_contacts.Count; i++)
                {
                    if (string.Compare(supply_contacts[i].SH_SUPPLIER_COMPANY_CONTACT_NAME.Trim() ,textBoxName.Text.Trim())==0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }


        void fillGridEmployees()
        {

            supply_company_contacts_grid_view.Rows.Clear();
            loadDataGridEmployees();
            if (supply_contacts.Count > 0)
            {
                
                for (int i = 0; i < supply_contacts.Count; i++)
                {
                    supply_company_contacts_grid_view.Rows.Add(new string[] { (i + 1).ToString(), supply_contacts[i].SH_SUPPLIER_COMPANY_CONTACT_NAME, supply_contacts[i].SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE, supply_contacts[i].SH_SUPPLIER_COMPANY_CONTACT_EMAIL });
                }
            }
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxName.Text)|| string.IsNullOrEmpty(textBoxEmail.Text)|| string.IsNullOrEmpty(textBoxTelephone.Text)|| string.IsNullOrEmpty(textBoxCompanyName.Text))
            {
                MessageBox.Show("اكمل البيانات بشكل صحيح");
            }

            else
            {
                int current_contact = check_if_client_company_contact_exists_or_not();
                if (current_contact  == -1)
                {
                    string query = "INSERT INTO SH_SUPPLIER_COMPANY_CONTACTS";
                    query += "(SH_SUPPLIER_COMPANY_CONTACT_NAME,SH_SUPPLIER_COMPANY_CONTACT_EMAIL,";
                    query += " SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE,SH_SUPPLIER_COMPANY_CONTACT_ID ";
                    query += " ,SH_DATA_ENTRY_USER_ID,SH_DATA_ENTRY_EMPLOYEE_ID ";
                    query += " , SH_ADDITION_DATE )";
                    query += " VALUES( @SH_SUPPLIER_COMPANY_CONTACT_NAME,";
                    query += " @SH_SUPPLIER_COMPANY_CONTACT_EMAIL,@SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE,";
                    query += " @SH_SUPPLIER_COMPANY_CONTACT_ID ";
                    query += ",@SH_DATA_ENTRY_USER_ID,@SH_DATA_ENTRY_EMPLOYEE_ID";
                    query += " , @SH_ADDITION_DATE )";
                    try
                    {
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_NAME", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_EMAIL", textBoxEmail.Text);
                        cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE", textBoxTelephone.Text);
                        cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_ID", Mcompany.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID",mAccounts.SH_ID );
                        cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID",mAccounts.SH_EMP_ID );
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم الحفظ بنجاح");
                        buttonSave.Enabled = false;
                        fillGridEmployees();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("error in saving SupplierContacts" + ex.ToString());
                    }
                }else
                {
                    supply_company_contacts_grid_view.Rows[current_contact].Selected = true;
                }
              
            }
        }

 

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addSupplierCompanyContacts_Load(object sender, EventArgs e)
        {
            fillGridEmployees();
            textBoxCompanyName.Text = Mcompany.SH_SUPPLY_COMAPNY_NAME;
        }

     

        private void buttonNew_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            addSupplierCompanyContacts frm = new addSupplierCompanyContacts(Mcompany, mEmployees,mAccounts,mPermissions);
            frm.ShowDialog();
        }
    }
}
