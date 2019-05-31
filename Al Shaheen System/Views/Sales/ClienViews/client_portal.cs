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
    public partial class client_portal : Form
    {
        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        List<SH_CLIENTS_BRANCHES> client_branches = new List<SH_CLIENTS_BRANCHES>();
        List<SH_CLIENTS_PRODUCTS> mproduct = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ITEM_SIZE> mSizes = new List<SH_ITEM_SIZE>();
        List<SH_FACE_COLOR> FACES = new List<SH_FACE_COLOR>();
        List<SH_CLIENT_COMPANY_CONTACTS> client_contacts = new List<SH_CLIENT_COMPANY_CONTACTS>();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;


        public client_portal(SH_CLIENT_COMPANY anyclient , SH_EMPLOYEES anyemp,SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mclient = anyclient;

            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyperm;

        }

        private void client_name_label_Load(object sender, EventArgs e)
        {
            client_name_label.Text = mclient.SH_CLIENT_COMPANY_NAME;
            phone_text_box.Text = mclient.SH_CLIENT_COMPANY_TELEPHONE;
            
            fax_number_text_box.Text = mclient.SH_CLIENT_COMPANY_FAX_NUMBER;
            company_type_text_box.Text = mclient.SH_CLIENT_COMPANY_TYPE;
            company_mobile_text_box.Text = mclient.SH_CLIENT_COMPANY_MOBILE;
            fillclientbranchesgridview();
            getallclientproducts();
           
            loadallfacecolors();
            fillclientcontactsgridview();
            productsgridview();


         }
        void loadclientcompanyconatacts()
        {
            client_contacts.Clear();

            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY_CONTACTS WHERE SH_CLIENT_COMPANY_ID = @SH_CLIENT_COMPANY_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_contacts.Add(new SH_CLIENT_COMPANY_CONTACTS() { SH_CLIENT_COMPANY_CONTACT_EMAIL = reader["SH_CLIENT_COMPANY_CONTACT_EMAIL"].ToString(), SH_CLIENT_COMPANY_CONTACT_NAME = reader["SH_CLIENT_COMPANY_CONTACT_NAME"].ToString(), SH_CLIENT_COMPANY_CONTACT_TELEPHONE = reader["SH_CLIENT_COMPANY_CONTACT_TELEPHONE"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_ID = long.Parse(reader["SH_CLIENT_COMPANY_ID"].ToString()) });
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT CONTACTS DATA FROM DB " + ex.ToString());
            }

        }
        void fillclientcontactsgridview()
        {
            client_contacts_grid_view.Rows.Clear();
            loadclientcompanyconatacts();
            if (client_contacts.Count > 0)
            {
                for (int i = 0; i < client_contacts.Count; i++)
                {
                    client_contacts_grid_view.Rows.Add(new string[] { (i + 1).ToString(), client_contacts[i].SH_CLIENT_COMPANY_CONTACT_NAME, client_contacts[i].SH_CLIENT_COMPANY_CONTACT_TELEPHONE, client_contacts[i].SH_CLIENT_COMPANY_CONTACT_EMAIL });
                }
            }
        }
        void getallclientproducts()
        {
            mproduct.Clear();
            try
            {
                string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS ";
                query += " WHERE(SH_CLIENT_ID = @client_id)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@client_id", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mproduct.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()), SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS " + ex.ToString());
            }
        }

        SH_ITEM_SIZE getsizeobjectbyid(long s_id)
        {
            if (mSizes.Count > 0)
            {
                for (int i = 0; i < mSizes.Count; i++)
                {
                    if (mSizes[i].SH_ID == s_id)
                    {
                        return mSizes[i];
                    }
                }
            }
            return null;
        }
        void loadaallsizes()
        {
            mSizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mSizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(), SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(), SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }
        void productsgridview()
        {
            //string d1text = "";
            //string d2text = "";
            products_grid_view.Rows.Clear();
            SH_ITEM_SIZE anysize = new SH_ITEM_SIZE();
            loadaallsizes();
            if (mproduct.Count > 0)
            {
                for (int i = 0; i < mproduct.Count; i++)
                {
                    anysize = getsizeobjectbyid(mproduct[i].SH_SIZE_ID);
                    // MessageBox.Show(anysize.SH_SIZE_SHAPE_NAME);
                    if (anysize == null)
                    {

                    }
                    else
                    {
                        products_grid_view.Rows.Add(new string[] { mproduct[i].SH_ID.ToString(), mproduct[i].SH_PRODUCT_NAME, anysize.SH_SIZE_SHAPE_NAME, mproduct[i].SH_PRINTING_TYPE, anysize.SH_SIZE_FIRST_DIAMETER_NAME, anysize.SH_SIZE_FIRST_DIAMETER.ToString(), anysize.SH_SIZE_SECOND_DIAMETER_NAME, anysize.SH_SIZE_SECOND_DIAMETER.ToString(), anysize.SH_SIZE_SURROUNDING.ToString(), mproduct[i].SH_BOTTLE_HEIGHT.ToString(), mproduct[i].SH_SECOND_FACE_NAME });
                    }
                }
            }
        }
        void loadallfacecolors()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_FACE_COLORS", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FACES.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACES " + ex.ToString());
            }
        }


        void fillclientbranchesgridview()
        {
            client_branches.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENTS_BRANCHES WHERE SH_CLIENT_ID = @SH_CLIENT_ID", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_branches.Add(new SH_CLIENTS_BRANCHES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(), SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(), SH_CLIENT_BRANCH_TYPE = reader["SH_CLIENT_BRANCH_TYPE"].ToString(), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH FROM DB " + ex.ToString());
            }

            if (client_branches.Count > 0)
            {
                client_branches_grid_view.Rows.Clear();
                for (int i = 0; i < client_branches.Count; i++)
                {
                    client_branches_grid_view.Rows.Add(new string[] { (i + 1).ToString(), client_branches[i].SH_CLIENT_BRANCH_NAME, client_branches[i].SH_CLIENT_BRANCH_TYPE, client_branches[i].SH_CLIENT_BRANCH_ADDRESS_TEXT, client_branches[i].SH_CLIENT_BRANCH_ADDRESS_GPS_LINK });
                }

            }


        }

        private void addnew_client_branch_btn_Click(object sender, EventArgs e)
        {
            addclientbranches myform = new addclientbranches(mclient,mEmployee,mAccount,mPermission);
            
                myform.ShowDialog();
            
        }

        private void addnewclientcontact_Click(object sender, EventArgs e)
        {
            addnewclientcompanycontacts myform = new addnewclientcompanycontacts(mclient,mEmployee,mAccount,mPermission) ;
            
                myform.ShowDialog();
            
        }

        private void addnewclientproduct_Click(object sender, EventArgs e)
        {
            addnewclientproduct myform = new addnewclientproduct(mclient,mEmployee,mAccount,mPermission);
            
                myform.ShowDialog();
            
        }

        private void client_portal_Activated(object sender, EventArgs e)
        {

            fillclientbranchesgridview();
            getallclientproducts();

            loadallfacecolors();
            fillclientcontactsgridview();
            productsgridview();
        }
    }
}
