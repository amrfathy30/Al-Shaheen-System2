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
    public partial class AllSelectedSupplierDataFrm : Form
    {
        List<SH_SUPPLIER_COMPANY_CONTACTS> suppCompanyContactList = new List<SH_SUPPLIER_COMPANY_CONTACTS>();
        List<SH_SUPPLY_COMPANY_BRANCHES> branchList = new List<SH_SUPPLY_COMPANY_BRANCHES>();
        List<SH_SUPPLIER_ITEMS> suppItemList = new List<SH_SUPPLIER_ITEMS>();
        SH_SUPPLY_COMPANY comp = new SH_SUPPLY_COMPANY();
        public AllSelectedSupplierDataFrm(SH_SUPPLY_COMPANY anycompany)
        {
            InitializeComponent();
            comp = anycompany;
        }

        //select * from SH_SUPPLIER_ITEMS where SH_ITEM_ID=@id

        void loadDataGridItems()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select distinct SH_ITEM_NAME from  SH_SUPPLIER_ITEMS where SH_SUPPLIER_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", comp.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppItemList.Add(new SH_SUPPLIER_ITEMS { SH_ITEM_NAME = reader["SH_ITEM_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS items DATA" + ex.ToString());
            }
        }

        void fillGriditems()
        {
            suppItemList.Clear();
            
            loadDataGridItems();
            if (suppItemList.Count > 0)
            {
                dataGridViewItems.Rows.Clear();
                for (int i = 0; i < suppItemList.Count; i++)
                {
                    dataGridViewItems.Rows.Add(new string[] { (i + 1).ToString(), suppItemList[i].SH_ITEM_NAME });
                }
            }
        }



        void loadDataGridBranches()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select * from SH_SUPPLY_COMPANY_BRANCHES where SH_SUPPLY_COMPANY_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", comp.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    branchList.Add(new SH_SUPPLY_COMPANY_BRANCHES { SH_ID=long.Parse(reader["SH_ID"].ToString()),SH_SUPPLY_COMPANY_NAME=reader["SH_SUPPLY_COMPANY_NAME"].ToString(),SH_COMPANY_BRANCH_ADDRESS_GPS_LINK=reader["SH_COMPANY_BRANCH_ADDRESS_GPS_LINK"].ToString(),SH_COMPANY_BRANCH_ADDRESS_TEXT=reader["SH_COMPANY_BRANCH_ADDRESS_TEXT"].ToString(),SH_COMPANY_BRANCH_NAME=reader["SH_COMPANY_BRANCH_NAME"].ToString(),SH_COMPANY_BRANCH_TYPE=reader["SH_COMPANY_BRANCH_TYPE"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS items DATA" + ex.ToString());
            }
        }

        void fillGridBranches()
        {
            branchList.Clear();
            dataGridViewBranch.Rows.Clear();
            loadDataGridBranches();
            if (branchList.Count > 0)
            {
                dataGridViewBranch.Rows.Clear();
                for (int i = 0; i < branchList.Count; i++)
                {
                    dataGridViewBranch.Rows.Add(new string[] { (i + 1).ToString(), branchList[i].SH_COMPANY_BRANCH_NAME, branchList[i].SH_COMPANY_BRANCH_TYPE, branchList[i].SH_COMPANY_BRANCH_ADDRESS_TEXT, branchList[i].SH_COMPANY_BRANCH_ADDRESS_GPS_LINK});
                }
            }
        }

        //
        void loadDataGridEmployees()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select * from SH_SUPPLIER_COMPANY_CONTACTS where SH_SUPPLIER_COMPANY_CONTACT_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", comp.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppCompanyContactList.Add(new SH_SUPPLIER_COMPANY_CONTACTS{ SH_ID = long.Parse(reader["SH_ID"].ToString()),SH_SUPPLIER_COMPANY_CONTACT_EMAIL=reader["SH_SUPPLIER_COMPANY_CONTACT_EMAIL"].ToString(),SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE=reader["SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE"].ToString(),SH_SUPPLIER_COMPANY_CONTACT_NAME=reader["SH_SUPPLIER_COMPANY_CONTACT_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING Supplier employees Contacts "+ ex.ToString());
            }
        }

        void fillGridEmployees()
        {
            suppCompanyContactList.Clear();
            dataGridViewEmpLoyees.Rows.Clear();
            loadDataGridEmployees();
            if (suppCompanyContactList.Count > 0)
            {
                dataGridViewEmpLoyees.Rows.Clear();
                for (int i = 0; i < suppCompanyContactList.Count; i++)
                {
                    dataGridViewEmpLoyees.Rows.Add(new string[] { (i + 1).ToString(), suppCompanyContactList[i].SH_SUPPLIER_COMPANY_CONTACT_NAME, suppCompanyContactList[i].SH_SUPPLIER_COMPANY_CONTACT_TELEPHONE, suppCompanyContactList[i].SH_SUPPLIER_COMPANY_CONTACT_EMAIL });
                }
            }
        }
        private void AllSelectedSupplierDataFrm_Load(object sender, EventArgs e)
        {
            labelCompanyName.Text = comp.SH_SUPPLY_COMAPNY_NAME;
            textBoxType.Text = comp.SH_SUPPLY_COMPANY_TYPE;
            textBoxMobile.Text = comp.SH_SUPPLY_COMPANY_MOBILE;
            textBoxFax.Text = comp.SH_SUPPLY_COMPANY_FAX;
            textBoxTelphone.Text = comp.SH_SUPPLY_COMPANY_TELEPHONE;


            fillGridBranches();
            fillGridEmployees();
            fillGriditems();
        }

        private void buttonAddBranch_Click(object sender, EventArgs e)
        {
            add_new_supply_company_branch myform = new add_new_supply_company_branch(comp);
           
                myform.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (AddNewItemForSupplierFrm myform = new AddNewItemForSupplierFrm(comp))
            {
                myform.ShowDialog();
            }
        }

        private void buttonAddEmployee_Click(object sender, EventArgs e)
        {
            addSupplierCompanyContacts frm = new addSupplierCompanyContacts(comp);
            frm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddNewItemForSupplierFrm frm = new AddNewItemForSupplierFrm(comp);
            frm.ShowDialog();
        }


       

        private void AllSelectedSupplierDataFrm_Activated(object sender, EventArgs e)
        {
            //labelCompanyName.Text = comp.SH_SUPPLY_COMAPNY_NAME;
            textBoxType.Text = comp.SH_SUPPLY_COMPANY_TYPE;
            textBoxMobile.Text = comp.SH_SUPPLY_COMPANY_MOBILE;
            textBoxFax.Text = comp.SH_SUPPLY_COMPANY_FAX;
            textBoxTelphone.Text = comp.SH_SUPPLY_COMPANY_TELEPHONE;
            textBoxFax.Text = comp.SH_SUPPLY_COMPANY_FAX;

            fillGridBranches();
            fillGridEmployees();
            fillGriditems();
        }
    }
}
