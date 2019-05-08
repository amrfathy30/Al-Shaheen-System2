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
    public partial class addnewclientcompanycontacts : Form
    {
        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        List<SH_CLIENT_COMPANY_CONTACTS> client_contacts = new List<SH_CLIENT_COMPANY_CONTACTS>();
        long editeclientconctactid = 0;
        public addnewclientcompanycontacts(SH_CLIENT_COMPANY client)
        {
            InitializeComponent();
            mclient = client;
        }

        void loadclientcompanyconatacts()
        {
            client_contacts.Clear();

            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY_CONTACTS WHERE SH_CLIENT_COMPANY_ID = @SH_CLIENT_COMPANY_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_contacts.Add(new SH_CLIENT_COMPANY_CONTACTS() { SH_CLIENT_COMPANY_CONTACT_EMAIL = reader["SH_CLIENT_COMPANY_CONTACT_EMAIL"].ToString()  , SH_CLIENT_COMPANY_CONTACT_NAME = reader["SH_CLIENT_COMPANY_CONTACT_NAME"].ToString()  , SH_CLIENT_COMPANY_CONTACT_TELEPHONE = reader["SH_CLIENT_COMPANY_CONTACT_TELEPHONE"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_CLIENT_COMPANY_ID = long.Parse(reader["SH_CLIENT_COMPANY_ID"].ToString()) });
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT CONTACTS DATA FROM DB "+ex.ToString());
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
                    client_contacts_grid_view.Rows.Add(new string[] { (i+1).ToString() , client_contacts[i].SH_CLIENT_COMPANY_CONTACT_NAME , client_contacts[i].SH_CLIENT_COMPANY_CONTACT_TELEPHONE , client_contacts[i].SH_CLIENT_COMPANY_CONTACT_EMAIL });
                }
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            client_company_contact_name.Text = "";
            client_company_conact_email_text_box.Text = "";
            client_company_contact_telephone_text_box.Text = "";
        }

        private void addnewclientcompanycontacts_Load(object sender, EventArgs e)
        {
            this.client_company_name_text_box.Text = mclient.SH_CLIENT_COMPANY_NAME;
            fillclientcontactsgridview();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(client_company_conact_email_text_box.Text) || string.IsNullOrWhiteSpace(client_company_contact_name.Text) || string.IsNullOrWhiteSpace(client_company_contact_telephone_text_box.Text))
            {

            }else
            {

                if (editeclientconctactid == 0) //new button
                {
                    try
                    {
                        string query = "INSERT INTO SH_CLIENT_COMPANY_CONTACTS ";
                        query += "(SH_CLIENT_COMPANY_ID, SH_CLIENT_COMPANY_CONTACT_NAME, SH_CLIENT_COMPANY_CONTACT_TELEPHONE, SH_CLIENT_COMPANY_CONTACT_EMAIL) ";
                        query += " VALUES(@SH_CLIENT_COMPANY_ID,@SH_CLIENT_COMPANY_CONTACT_NAME,@SH_CLIENT_COMPANY_CONTACT_TELEPHONE,@SH_CLIENT_COMPANY_CONTACT_EMAIL)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_ID", mclient.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_CONTACT_NAME", client_company_contact_name.Text);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_CONTACT_TELEPHONE", client_company_contact_telephone_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_CONTACT_EMAIL", client_company_conact_email_text_box.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        client_company_contact_name.Text = "";
                        client_company_conact_email_text_box.Text = "";
                        client_company_contact_telephone_text_box.Text = "";
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE ADDING NEW CLIENT CONTACT IN DB " + ex.ToString());
                    }
                    fillclientcontactsgridview();
                }else // edite
                {

                    try
                    {
                        string query = "UPDATE       SH_CLIENT_COMPANY_CONTACTS";
                        query += " SET SH_CLIENT_COMPANY_CONTACT_NAME = @SH_CLIENT_COMPANY_CONTACT_NAME, SH_CLIENT_COMPANY_CONTACT_TELEPHONE = @SH_CLIENT_COMPANY_CONTACT_TELEPHONE, ";
                        query += "SH_CLIENT_COMPANY_CONTACT_EMAIL = @SH_CLIENT_COMPANY_CONTACT_EMAIL  WHERE SH_ID = @SH_ID";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_ID", mclient.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_CONTACT_NAME", client_company_contact_name.Text);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_CONTACT_TELEPHONE", client_company_contact_telephone_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_CONTACT_EMAIL", client_company_conact_email_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ID" , editeclientconctactid);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم التعديل بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        client_company_contact_name.Text = "";
                        client_company_conact_email_text_box.Text = "";
                        client_company_contact_telephone_text_box.Text = "";
                        myconnection.closeConnection();
                        editeclientconctactid = 0;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("ERROR WHILE EDITING  CLIENT CONTACT IN DB " + ex.ToString());
                    }
                    fillclientcontactsgridview();
                }
                editeclientconctactid = 0;

            }


        }

        private void edite_btn_Click(object sender, EventArgs e)
        {
            if (client_contacts_grid_view.SelectedRows.Count >0)
            {

                client_company_contact_name.Text = client_contacts[client_contacts_grid_view.SelectedRows[0].Index].SH_CLIENT_COMPANY_CONTACT_NAME;
                client_company_conact_email_text_box.Text = client_contacts[client_contacts_grid_view.SelectedRows[0].Index].SH_CLIENT_COMPANY_CONTACT_EMAIL;
                client_company_contact_telephone_text_box.Text = client_contacts[client_contacts_grid_view.SelectedRows[0].Index].SH_CLIENT_COMPANY_CONTACT_TELEPHONE;


                editeclientconctactid = client_contacts[client_contacts_grid_view.SelectedRows[0].Index].SH_ID;
            }
            else
            {
                MessageBox.Show("الرجاء تحديد الموظف المراد تعديل بياناته" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }
    }
}
