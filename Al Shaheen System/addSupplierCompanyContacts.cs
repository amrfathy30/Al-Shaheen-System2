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
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        public addSupplierCompanyContacts(SH_SUPPLY_COMPANY comp)
        {
            InitializeComponent();
            Mcompany = comp;
        }


  

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxName.Text)|| string.IsNullOrEmpty(textBoxEmail.Text)|| string.IsNullOrEmpty(textBoxTelephone.Text)|| string.IsNullOrEmpty(textBoxCompanyName.Text))
            {
                MessageBox.Show("اكمل البيانات بشكل صحيح");
            }

            else
            {

                string query = "INSERT INTO SH_SUPPLIER_COMPANY_CONTACTS";
                query += "(SH_SUPPLIER_COMPANY_CONTACT_NAME,SH_SUPPLIER_COMPANY_CONTACT_EMAIL,SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE,SH_SUPPLIER_COMPANY_CONTACT_ID)";
                query += "VALUES(@SH_SUPPLIER_COMPANY_CONTACT_NAME,@SH_SUPPLIER_COMPANY_CONTACT_EMAIL,@SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE,@SH_SUPPLIER_COMPANY_CONTACT_ID)";
                try
                {
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_NAME", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_EMAIL", textBoxEmail.Text);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE", textBoxTelephone.Text);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_COMPANY_CONTACT_ID", Mcompany.SH_ID);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الحفظ بنجاح");
                    buttonSave.Enabled = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error in saving SupplierContacts" + ex.ToString());
                }
            }
        }

 

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addSupplierCompanyContacts_Load(object sender, EventArgs e)
        {
            textBoxCompanyName.Text = Mcompany.SH_SUPPLY_COMAPNY_NAME;
        }

     

        private void buttonNew_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            addSupplierCompanyContacts frm = new addSupplierCompanyContacts(Mcompany);
            frm.ShowDialog();
        }
    }
}
