﻿using System;
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
    public partial class add_new_client_company_btn : Form
    {
        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        DatabaseConnection myconnection = new DatabaseConnection();
        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        


        public add_new_client_company_btn(SH_CLIENT_COMPANY anycompany , SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS anyperm )
        {
            InitializeComponent();
            mclient = anycompany;
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anyperm;

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_new_company_btn_Click(object sender, EventArgs e)
        {
            
            company_name_text_box.Text = "";
            company_telephone_text_box.Text = "";
            client_company_fax_number_text_box.Text = "";
        }

        async Task<bool> check_if_name_exits_or_not()
        {
            clients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENT_COMPANY ",DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY() {
                        SH_CLIENT_COMPANY_FAX_NUMBER= reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString(),
                        SH_CLIENT_COMPANY_MOBILE= reader["SH_CLIENT_COMPANY_MOBILE"].ToString(),
                        SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString(),
                        SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString())

                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG ALL CLIENTS DATA FROM DB "+ex.ToString());
            }
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    if (string.Compare(company_name_text_box.Text , clients[i].SH_CLIENT_COMPANY_NAME)==0)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }


        private async void save_company_btn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(client_company_fax_number_text_box.Text) || string.IsNullOrEmpty(company_telephone_text_box.Text) || string.IsNullOrEmpty(company_telephone_text_box.Text))
            {
                MessageBox.Show("إملاء البيانات من فضلك", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                if ((errorProvider1.GetError(company_telephone_text_box) == "") && (errorProvider1.GetError(company_telephone_text_box) == ""))
                {


                    if (mclient == null)
                    {

                        //new client

                        if (await check_if_name_exits_or_not())
                        {
                            MessageBox.Show("هذا العميل تم إضافته مسبقا", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {

                            string company_type_text_box = "";
                            if (national_client_radio_btn.Checked)
                            {
                                company_type_text_box = "محلى";
                            }
                            else
                            {
                                company_type_text_box = "دولى";
                            }
                            string query = "INSERT INTO SH_CLIENT_COMPANY";
                            query += " (SH_CLIENT_COMPANY_NAME, SH_CLIENT_COMPANY_TYPE,";
                            query += " SH_CLIENT_COMPANY_TELEPHONE, ";
                            query += "  SH_CLIENT_COMPANY_FAX_NUMBER,SH_CLIENT_COMPANY_MOBILE ";
                            query += ", SH_DATA_ENTRY_USER_ID,SH_DATA_ENTRY_EMPLOYEE_ID,SH_ADDITION_DATE ";
                            query += " ) VALUES ";
                            query += "    (@SH_CLIENT_COMPANY_NAME,@SH_CLIENT_COMPANY_TYPE,@SH_CLIENT_COMPANY_TELEPHONE ,  ";
                            query += "    @SH_CLIENT_COMPANY_FAX_NUMBER,@SH_CLIENT_COMPANY_MOBILE ";
                            query += " , @SH_DATA_ENTRY_USER_ID,@SH_DATA_ENTRY_EMPLOYEE_ID,@SH_ADDITION_DATE ";
                            query += " ) ";
                            try
                            {
                                DatabaseConnection myconnection = new DatabaseConnection();
                                myconnection.openConnection();
                                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_NAME", company_name_text_box.Text);
                                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_TYPE", company_type_text_box);
                                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_TELEPHONE", company_telephone_text_box.Text);

                                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_FAX_NUMBER", client_company_fax_number_text_box.Text);
                                cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_MOBILE", textBoxMobile.Text);
                                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                                myconnection.closeConnection();
                                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                                company_name_text_box.Text = "";
                                company_telephone_text_box.Text = "";
                                client_company_fax_number_text_box.Text = "";


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR WHILE SAVING CLIENT COMPANY" + ex.ToString());
                            }
                        }

                    }
                    else //edite client data
                    {
                        if (await check_if_name_exits_or_not())
                        {
                            MessageBox.Show("هذا العميل تم إضافته مسبقا", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        }
                        else
                        {
                            string company_type_text_box = "";
                            if (national_client_radio_btn.Checked)
                            {
                                company_type_text_box = "محلى";
                            }
                            else
                            {
                                company_type_text_box = "دولى";
                            }

                            string query = " UPDATE SH_CLIENT_COMPANY SET SH_CLIENT_COMPANY_NAME = @SH_CLIENT_COMPANY_NAME, ";
                            query += "SH_CLIENT_COMPANY_TYPE = @SH_CLIENT_COMPANY_TYPE, SH_CLIENT_COMPANY_TELEPHONE = @SH_CLIENT_COMPANY_TELEPHONE, ";
                            query += " SH_DATA_ENTRY_USER_ID = @SH_DATA_ENTRY_USER_ID, ";
                            query += " SH_DATA_ENTRY_EMPLOYEE_ID = @SH_DATA_ENTRY_EMPLOYEE_ID ,";
                            query += " SH_ADDITION_DATE = @SH_ADDITION_DATE , ";
                            query += "   SH_CLIENT_COMPANY_MOBILE = @SH_CLIENT_COMPANY_MOBILE, ";
                            query += "  SH_CLIENT_COMPANY_FAX_NUMBER =  @SH_CLIENT_COMPANY_FAX_NUMBER WHERE  SH_ID = @SH_ID ";

                            DatabaseConnection myconnection = new DatabaseConnection();
                            myconnection.openConnection();
                            SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                            cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_NAME", company_name_text_box.Text);
                            cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_TYPE", company_type_text_box);
                            cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_TELEPHONE", company_telephone_text_box.Text);

                            cmd.Parameters.AddWithValue("@SH_CLIENT_COMPANY_FAX_NUMBER", client_company_fax_number_text_box.Text);
                            cmd.Parameters.AddWithValue("@SH_ID", mclient.SH_ID);
                            cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                            cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                            cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            myconnection.closeConnection();
                            MessageBox.Show("تم التعديل بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                            company_name_text_box.Text = "";
                            company_telephone_text_box.Text = "";
                            client_company_fax_number_text_box.Text = "";


                        }

                    }
                }
                else
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
                    
            }
        }

        private void add_new_client_company_btn_Load(object sender, EventArgs e)
        {
           

            if (mclient==null)
            {
                national_client_radio_btn.Checked = true;
                title_label.Text = "إضافة شركة عميل جديد";
            }
            else
            {
                title_label.Text = "تعديل بيانات شركة عميل ";

                client_company_fax_number_text_box.Text = mclient.SH_CLIENT_COMPANY_FAX_NUMBER;
               
                company_name_text_box.Text = mclient.SH_CLIENT_COMPANY_NAME;
                company_telephone_text_box.Text = mclient.SH_CLIENT_COMPANY_TELEPHONE;
                if (string.Compare(mclient.SH_CLIENT_COMPANY_TYPE, "دولى")==0)
                {
                    international_radio_btn.Checked = true;
                }else
                {
                    national_client_radio_btn.Checked = true;
                }


            }



        }

        private void company_name_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(company_name_text_box.Text))
            {
                errorProvider1.SetError(company_name_text_box, "إملاء بيانات الشركة");
            }
            else
            {
                errorProvider1.Clear();
            }

        }

        private void company_telephone_text_box_TextChanged(object sender, EventArgs e)
        {
            long mytele = 0;
            if (!long.TryParse(company_telephone_text_box.Text , out mytele))
            {
                errorProvider1.SetError(company_telephone_text_box,"إملاء رقم التليفون بالشكل الصحيح 01012312312");
            }else
            {
                errorProvider1.Clear();
            }
        }

        private void company_mobile_text_box_TextChanged(object sender, EventArgs e)
        {
            long mytele = 0;
            if (!long.TryParse(company_telephone_text_box.Text, out mytele))
            {
                errorProvider1.SetError(company_telephone_text_box, "إملاء رقم المحمول بالشكل الصحيح 01012312312");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
