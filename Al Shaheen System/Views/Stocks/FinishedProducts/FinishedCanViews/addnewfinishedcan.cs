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
    public partial class addnewfinishedcan : Form
    {
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT> parcels = new List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT>();
        List<SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS> quantities = new List<SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS>();
        List<SH_CALCULATE_TOTAL_FINISHED_PRODUCT> specifications = new List<SH_CALCULATE_TOTAL_FINISHED_PRODUCT>();

        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        long total_number_of_pallets = 0;
        long total_number_of_cans = 0;

        void loadallfinishedproductspecifications()
        {
            specifications.Clear();
            try
            {
                string query = " SELECT SH_CALCULATE_TOTAL_FINISHED_PRODUCT.* FROM SH_CALCULATE_TOTAL_FINISHED_PRODUCT";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_CALCULATE_TOTAL_FINISHED_PRODUCT() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SPECIFICATIONS FROM DB"+ex.ToString());
            }
        }

        long check_if_item_details_exists_or_not(SH_ADDED_PARCELS_OF_FINISHED_PRODUCT anyparcel)
        {
            loadallfinishedproductspecifications();
            if (specifications.Count >0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if ((specifications[i].SH_CLIENT_ID == anyparcel.SH_CLIENT_ID && specifications[i].SH_CLIENT_PRODUCT_ID == anyparcel.SH_CLIENT_PRODUCT_ID) )
                    {
                        return specifications[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        async Task autogenerateadditionpermisionnumber()
        {
            long mycount = 0; 
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_ADDITION_PERMISSION_NUMBERS_FINISHED_CANS  ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.Read())
                {
                    if (string.IsNullOrWhiteSpace(reader["lastedid"].ToString()))
                    {
                        reader.Close();
                    }else
                    {
                        mycount = long.Parse(reader["lastedid"].ToString());
                    }   
                }

                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting new permission number "+ex.ToString());
            }


            if (mycount ==0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                permissionnumber += "CANS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                adding_request_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber +="CANS-" ;
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5- currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                adding_request_number_text_box.Text = permissionnumber;
            }     
        }



        long savenewfinishedproductspecification(SH_ADDED_PARCELS_OF_FINISHED_PRODUCT anyparcel)
        {
            try
            {
                string query = "INSERT INTO SH_CALCULATE_TOTAL_FINISHED_PRODUCT ";
                query += "(SH_CLIENT_ID, SH_CLIENT_PRODUCT_ID, SH_CLIENT_NAME, SH_TOTAL_NUMBER_OF_PALLET, SH_CLIENT_PRODUCT_NAME, SH_TOTAL_NUMBER_OF_CANS, SH_TOTAL_NUMBER_OF_ENTERED_CANS, ";
                query += " SH_TOTAL_NUMBER_OF_ENTERED_PALLETS ) ";
                query += " VALUES( @SH_CLIENT_ID,@SH_CLIENT_PRODUCT_ID,@SH_CLIENT_NAME,@SH_TOTAL_NUMBER_OF_PALLET,@SH_CLIENT_PRODUCT_NAME,@SH_TOTAL_NUMBER_OF_CANS,@SH_TOTAL_NUMBER_OF_ENTERED_CANS,";
                query += "@SH_TOTAL_NUMBER_OF_ENTERED_PALLETS )";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", anyparcel.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", anyparcel.SH_CLIENT_PRODUCT_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", anyparcel.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLET" , 1);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME", anyparcel.SH_CLIENT_PRODUCT_NAME);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CANS", anyparcel.SH_TOTAL_NUMBER_OF_CANS);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_ENTERED_CANS", anyparcel.SH_TOTAL_NUMBER_OF_CANS);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_ENTERED_PALLETS", anyparcel.SH_TOTAL_NUMBER_OF_CANS);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW CLIENT PRODUCT SPECIFICATION"+ex.ToString());
            }
            return 0;
        }


        void updatecurrentfinishedproductspecification(SH_ADDED_PARCELS_OF_FINISHED_PRODUCT anyparcel , long sp_id)
        {
            try
            {
               // MessageBox.Show(anyparcel.SH_TOTAL_NUMBER_OF_CANS.ToString());
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                string query = "UPDATE SH_CALCULATE_TOTAL_FINISHED_PRODUCT SET ";
                query += " SH_TOTAL_NUMBER_OF_PALLET = SH_TOTAL_NUMBER_OF_PALLET + @SH_TOTAL_NUMBER_OF_PALLET , ";
                query += " SH_TOTAL_NUMBER_OF_CANS = SH_TOTAL_NUMBER_OF_CANS + @SH_TOTAL_NUMBER_OF_CANS ";
                query += " WHERE(SH_ID = @SH_ID)";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLET", 1);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CANS", anyparcel.SH_TOTAL_NUMBER_OF_CANS);
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                   
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING FINISHED PRODUCT SPCIFICATIONS "+ex.ToString());
            }
        }



        long savefinishedcansquantities(SH_ADDED_PARCELS_OF_FINISHED_PRODUCT anyparcel,long sp_id)
        {
            try
            {
                string query = "INSERT INTO SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS ";
                query += " (SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID, SH_CLIENT_ID, SH_CLIENT_NAME, SH_CLIENT_PRODUCT_ID, SH_CLIENT_PRODUCT_NAME, SH_TOTAL_NUMBER_OF_PALLETS, SH_TOTAL_NUMBER_OF_CANS, ";
                query += " SH_STOCK_NAME, SH_STOCK_ID, SH_ADDING_PERMISSION_NUMBER, SH_ADDITION_DATE) ";
                query += " VALUES(@SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_CLIENT_PRODUCT_ID,@SH_CLIENT_PRODUCT_NAME,@SH_TOTAL_NUMBER_OF_PALLETS";
                query += ",@SH_TOTAL_NUMBER_OF_CANS,@SH_STOCK_NAME,@SH_STOCK_ID,@SH_ADDING_PERMISSION_NUMBER,@SH_ADDITION_DATE)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", anyparcel.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", anyparcel.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", anyparcel.SH_CLIENT_PRODUCT_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME", anyparcel.SH_CLIENT_PRODUCT_NAME);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLETS", 1);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CANS", anyparcel.SH_TOTAL_NUMBER_OF_CANS);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME", anyparcel.SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", anyparcel.SH_STOCK_ID);
                cmd.Parameters.AddWithValue("@SH_ADDING_PERMISSION_NUMBER", anyparcel.SH_ADDING_PERMISSION_NUMBER);
                cmd.Parameters.AddWithValue("SH_ADDITION_DATE", DateTime.Now);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING FINISHED PRODUCT QUANTITES "+ex.ToString());
            }
            return 0;
        }

        void save_finished_cans_parcels(SH_ADDED_PARCELS_OF_FINISHED_PRODUCT anyparcel,long sp_id , long quantity_id )
        {
                    try
                    {
                        string query = "";
                        query = "INSERT INTO SH_ADDED_PARCELS_OF_FINISHED_PRODUCT";
                        query += "(SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID, SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID, SH_CLIENT_ID, SH_CLIENT_PRODUCT_ID, SH_CLIENT_NAME, SH_ADDING_PERMISSION_NUMBER,";
                        query += "SH_CLIENT_PRODUCT_NAME, SH_STOCK_NAME, SH_STOCK_ID, SH_NUMBER_OF_CANS_LENGTH, SH_NUMBER_OF_CANS_WIDTH, SH_ADDITION_DATE, SH_TOTAL_NUMBER_OF_CANS,";
                        query += "SH_LAST_RECORD_NUMBER_OF_CANS, SH_NUMBER_OF_CANS_HEIGHT)";
                        query += "VALUES(@SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID,@SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID,@SH_CLIENT_ID,@SH_CLIENT_PRODUCT_ID,@SH_CLIENT_NAME,@SH_ADDING_PERMISSION_NUMBER,";
                        query += "@SH_CLIENT_PRODUCT_NAME,@SH_STOCK_NAME,@SH_STOCK_ID,@SH_NUMBER_OF_CANS_LENGTH,@SH_NUMBER_OF_CANS_WIDTH,@SH_ADDITION_DATE,@SH_TOTAL_NUMBER_OF_CANS,@SH_LAST_RECORD_NUMBER_OF_CANS,@SH_NUMBER_OF_CANS_HEIGHT)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID",quantity_id);
                        cmd.Parameters.AddWithValue("@SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID", sp_id);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , anyparcel.SH_CLIENT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID" , anyparcel.SH_CLIENT_PRODUCT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", anyparcel.SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_ADDING_PERMISSION_NUMBER", anyparcel.SH_ADDING_PERMISSION_NUMBER);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME" , anyparcel.SH_CLIENT_PRODUCT_NAME);
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME", anyparcel.SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_STOCK_ID", anyparcel.SH_STOCK_ID);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_CANS_LENGTH", anyparcel.SH_NUMBER_OF_CANS_LENGTH);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_CANS_WIDTH", anyparcel.SH_NUMBER_OF_CANS_WIDTH);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE" , anyparcel.SH_ADDITION_DATE);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CANS" , anyparcel.SH_TOTAL_NUMBER_OF_CANS);
                        cmd.Parameters.AddWithValue("@SH_LAST_RECORD_NUMBER_OF_CANS", anyparcel.SH_LAST_RECORD_NUMBER_OF_CANS);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_CANS_HEIGHT" , anyparcel.SH_NUMBER_OF_CANS_HEIGHT);

                        cmd.ExecuteNonQuery();

                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING FINISHED PARCELS "+ex.ToString());
                    }
               
                           
        }



        public addnewfinishedcan(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPerm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPerm;
        }

        void loadallstocks()
        {
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_STOCKS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK { SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(), SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(), SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING STOCKS DATA FROM DB " + ex.ToString());
            }
        }

        void loadclientsdata()
        {

            //if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            //{
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),  SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
                    }
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
                }
        //    }else
        //    {
        //        try
        //        {
        //            string query = "SELECT * FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'%"+ clients_combo_box.Text + "%' ";
        //        DatabaseConnection myconnection = new DatabaseConnection();
        //        myconnection.openConnection();
        //        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_CLIENT_COMPANY_MOBILE = reader["SH_CLIENT_COMPANY_MOBILE"].ToString(), SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
        //        }
        //        myconnection.closeConnection();
        //    }
        //        catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
        //    }
        //}

            
        }
        void fill_clients_combo_box()
        {
            loadclientsdata();
            clients_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }


        void loadclientsbytext()
        {
            clients.Clear();
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'%" + clients_combo_box.Text + "%' ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),  SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
            }
        }




     


        void fillstockscombobox()
        {
            stocks.Clear();
            loadallstocks();
            stocks_combo_box.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stocks_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }


        private async void addnewfinishedcan_Load(object sender, EventArgs e)
        {
            await autogenerateadditionpermisionnumber();
            stock_man_name_text_box.Text = mEmployee.SH_EMPLOYEE_NAME;
            fillstockscombobox();
            fill_clients_combo_box();
        }

        void calculatesimiller_pallets_cans()
        {
            if ((!string.IsNullOrEmpty(number_of_cans_width_text_box.Text))  && (!string.IsNullOrEmpty(number_of_cans_height_text_box.Text)) && (!string.IsNullOrEmpty(number_of_cans_length_text_box.Text)))
            {
                long testnumber = 0;
                if (long.TryParse(number_of_cans_width_text_box.Text , out testnumber) && (long.TryParse(number_of_cans_length_text_box.Text , out testnumber  )) && (long.TryParse(number_of_cans_height_text_box.Text , out testnumber)) )
                {
                    smiller_quanatity_cans_per_pallet_text_box.Text = (long.Parse(number_of_cans_width_text_box.Text) * long.Parse(number_of_cans_length_text_box.Text) * long.Parse(number_of_cans_height_text_box.Text)).ToString();
                }
            }
        }
        private void number_of_cans_length_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if ( !long.TryParse(number_of_cans_length_text_box.Text , out examnumber))
            {
                errorProvider1.SetError(number_of_cans_length_text_box , " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                calculatesimiller_pallets_cans();
            }
        }

        private void number_of_cans_width_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(number_of_cans_width_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(number_of_cans_width_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                calculatesimiller_pallets_cans();
            }
        }

        private void number_of_cans_height_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(number_of_cans_width_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(number_of_cans_width_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                calculatesimiller_pallets_cans();
            }
        }

        private void smiller_quanatity_cans_per_pallet_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(smiller_quanatity_cans_per_pallet_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(smiller_quanatity_cans_per_pallet_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void number_of_pallets_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(number_of_pallets_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(number_of_pallets_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }


        long calculatetotalquantityofcans()
        {
            long totalquantity = 0;
            long test_num = 0;
            if ((!string.IsNullOrEmpty(unsmiller_number_of_cans_width_text_box.Text)) && (!string.IsNullOrEmpty(unsmiller_number_of_cans_height_text_box.Text)) && (!string.IsNullOrEmpty(unsmiller_number_of_cans_last_record_text_box.Text)) && (!string.IsNullOrEmpty(unsmiller_number_of_cans_length_text_box.Text)))
            {
                if (long.TryParse(unsmiller_number_of_cans_width_text_box.Text, out test_num) && (long.TryParse(unsmiller_number_of_cans_height_text_box.Text, out test_num)) && (long.TryParse(unsmiller_number_of_cans_length_text_box.Text, out test_num)) && (long.TryParse(unsmiller_number_of_cans_last_record_text_box.Text, out test_num)))
                {
                    totalquantity = ((long.Parse(unsmiller_number_of_cans_length_text_box.Text) * (long.Parse(unsmiller_number_of_cans_width_text_box.Text)) * (long.Parse(unsmiller_number_of_cans_height_text_box.Text)) + long.Parse(unsmiller_number_of_cans_last_record_text_box.Text)));
                }
            }
            return totalquantity;
        }


        private void unsmiller_number_of_cans_length_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(unsmiller_number_of_cans_length_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(unsmiller_number_of_cans_length_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                unsmiller_quanatity_cans_per_pallet_text_box.Text =  calculatetotalquantityofcans().ToString();


            }
        }

        private void adding_request_number_text_box_TextChanged(object sender, EventArgs e)
        {
            //long examnumber = 0;
            //if (!long.TryParse(adding_request_number_text_box.Text, out examnumber))
            //{
            //    errorProvider1.SetError(adding_request_number_text_box , " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        private void unsmiller_number_of_cans_last_record_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(unsmiller_number_of_cans_last_record_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(unsmiller_number_of_cans_last_record_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                unsmiller_quanatity_cans_per_pallet_text_box.Text = calculatetotalquantityofcans().ToString();

            }
        }

        private void unsmiller_quanatity_cans_per_pallet_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(unsmiller_quanatity_cans_per_pallet_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(unsmiller_quanatity_cans_per_pallet_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void unsmiller_number_of_cans_height_text_box_TextChanged(object sender, EventArgs e)
        {
            long examnumber = 0;
            if (!long.TryParse(unsmiller_number_of_cans_height_text_box.Text, out examnumber))
            {
                errorProvider1.SetError(unsmiller_number_of_cans_height_text_box, " الرجاء إدخال عدد العلب بالشكل الصحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void unsimiller_pallet_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (unsimiller_pallet_check_box.Checked)
            {
                if (unsimiller_group_box.Enabled)
                {
                    //DoNothing
                    if(similler_pallets_group_box.Enabled)
                    {
                        similler_pallets_group_box.Enabled = false;
                    }
                }
                else
                {
                    unsimiller_group_box.Enabled = true;
                    if (similler_pallets_group_box.Enabled)
                    {
                        similler_pallets_group_box.Enabled = false;
                    }
                }
            }
            else
            {
                if (unsimiller_group_box.Enabled)
                {
                    //DoNothing
                    unsimiller_group_box.Enabled = false;
                    if (!similler_pallets_group_box.Enabled)
                    {
                        similler_pallets_group_box.Enabled = true;
                    }
                }
                else
                {
                    if (!similler_pallets_group_box.Enabled)
                    {
                        similler_pallets_group_box.Enabled = true;
                    }
                }
            }
        }

        private void add_new_product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {

            }
            else
            {
                addnewclientproduct myform = new addnewclientproduct(clients[clients_combo_box.SelectedIndex],mEmployee,mAccount,mPermission);
                
                    myform.ShowDialog();
                
            }
        }
        void gettingproductsbyclientid()
        {
            products.Clear();
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {

            }
            else
            {
                try
                {
                    string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS WHERE (SH_CLIENT_ID = @CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام'  )) AND (SH_PRINTING_TYPE = @SH_PRINTING_TYPE OR SH_PRINTING_TYPE = @SH_PRINTING_TYPE2 )";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE","علبة");
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE2","بدن");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        //getting products data
                        products.Add(new SH_CLIENTS_PRODUCTS() {
                            SH_ID = long.Parse(reader["SH_ID"].ToString()),
                            SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                            SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                            SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()),
                            SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(),
                            SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(),
                            SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString())
                        });
                    }
                    reader.Close();
                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS");
                }
            }
        }

        void fillproductscombobox()
        {
            client_products_combo_box.Items.Clear();
            gettingproductsbyclientid();
            for (int i = 0; i < products.Count; i++)
            {
                client_products_combo_box.Items.Add(products[i].SH_PRODUCT_NAME);
            }

        }
        private void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillproductscombobox();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void add_new_pallets_btn_Click(object sender, EventArgs e)
        {
            bool saveornot = true;
           

            if (unsimiller_pallet_check_box.Checked)
            {
                unsmiller_quanatity_cans_per_pallet_text_box.Text = calculatetotalquantityofcans().ToString();
                if (string.IsNullOrEmpty(adding_request_number_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(clients_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(client_products_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(unsmiller_number_of_cans_length_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(unsmiller_number_of_cans_width_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(unsmiller_number_of_cans_height_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(unsmiller_number_of_cans_last_record_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(unsmiller_quanatity_cans_per_pallet_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(stocks_combo_box.Text))
                {
                    saveornot = false;
                }
                else
                {
                    saveornot = true;
                    parcels.Add(new SH_ADDED_PARCELS_OF_FINISHED_PRODUCT() {
                        SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID ,
                        SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME ,
                        SH_CLIENT_PRODUCT_ID = products[client_products_combo_box.SelectedIndex].SH_ID ,
                        SH_CLIENT_PRODUCT_NAME = products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME ,
                        SH_LAST_RECORD_NUMBER_OF_CANS = long.Parse(unsmiller_number_of_cans_last_record_text_box.Text) 
                        ,SH_ADDING_PERMISSION_NUMBER = adding_request_number_text_box.Text 
                        , SH_ADDITION_DATE = DateTime.Now 
                        , SH_NUMBER_OF_CANS_HEIGHT = long.Parse(unsmiller_number_of_cans_height_text_box.Text) ,
                         SH_NUMBER_OF_CANS_LENGTH = long.Parse(unsmiller_number_of_cans_length_text_box.Text) 
                        , SH_NUMBER_OF_CANS_WIDTH = long.Parse(unsmiller_number_of_cans_width_text_box.Text) 
                        , SH_STOCK_ID = stocks[stocks_combo_box.SelectedIndex].SH_ID 
                        , SH_STOCK_NAME = stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME 
                        , SH_TOTAL_NUMBER_OF_CANS = long.Parse(unsmiller_quanatity_cans_per_pallet_text_box.Text)} );
                    total_number_of_pallets++;
                    fillparcelsgridview();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(adding_request_number_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(clients_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(client_products_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(number_of_cans_height_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(number_of_cans_width_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(number_of_cans_height_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(number_of_pallets_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(smiller_quanatity_cans_per_pallet_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(stocks_combo_box.Text))
                {
                    saveornot = false;
                }
                else
                {
                    saveornot = true;
                    for (int i = 0; i < long.Parse(number_of_pallets_text_box.Text); i++)
                    {
                        parcels.Add(new SH_ADDED_PARCELS_OF_FINISHED_PRODUCT() { SH_LAST_RECORD_NUMBER_OF_CANS = 0, SH_NUMBER_OF_CANS_HEIGHT = long.Parse(number_of_cans_height_text_box.Text), SH_ADDING_PERMISSION_NUMBER = adding_request_number_text_box.Text, SH_ADDITION_DATE = DateTime.Now, SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID, SH_NUMBER_OF_CANS_LENGTH = long.Parse(number_of_cans_length_text_box.Text), SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME, SH_CLIENT_PRODUCT_ID = products[client_products_combo_box.SelectedIndex].SH_ID, SH_NUMBER_OF_CANS_WIDTH = long.Parse(number_of_cans_width_text_box.Text), SH_STOCK_ID = stocks[stocks_combo_box.SelectedIndex].SH_ID, SH_STOCK_NAME = stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME, SH_CLIENT_PRODUCT_NAME = products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME, SH_TOTAL_NUMBER_OF_CANS = long.Parse(smiller_quanatity_cans_per_pallet_text_box.Text) });
                        total_number_of_pallets++;
                        total_number_of_cans = long.Parse(smiller_quanatity_cans_per_pallet_text_box.Text) * long.Parse(number_of_pallets_text_box.Text);
                        fillparcelsgridview();
                    }
                }
            }
            if (saveornot)
            {
                
             //   MessageBox.Show(parcels.Count.ToString());
                
            }
            else
            {
                MessageBox.Show("الرجاء كتابة جميع البيانات بشكل صحيح " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private void new_quantity_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewfinishedcan myform = new addnewfinishedcan(mEmployee,mAccount,mPermission))
            {
                myform.ShowDialog();
            }
            this.Close();
        }
        void fillparcelsgridview()
        {
            if (parcels.Count > 0)
            {
                parcels_grid_view.Rows.Clear();
                for (int i = 0; i < parcels.Count; i++)
                {
                    parcels_grid_view.Rows.Add(new string[] {  (i+1).ToString() , parcels[i].SH_CLIENT_NAME , parcels[i].SH_CLIENT_PRODUCT_NAME , 1.ToString() , parcels[i].SH_TOTAL_NUMBER_OF_CANS.ToString() , parcels[i].SH_TOTAL_NUMBER_OF_CANS.ToString() });
                }
            }
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_new_quantity_btn_Click(object sender, EventArgs e)
        {
            bool saveornot = true;


            if (unsimiller_pallet_check_box.Checked)
            {
                if (string.IsNullOrEmpty(adding_request_number_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(clients_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(client_products_combo_box.Text))
                {
                    saveornot = false;
                }
                
                else if (string.IsNullOrEmpty(stocks_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (parcels.Count <=0)
                {
                    saveornot = false;
                }
                else

                {
                    saveornot = true;
                  
                }
            }
            else
            {
                if (string.IsNullOrEmpty(adding_request_number_text_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(clients_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (string.IsNullOrEmpty(client_products_combo_box.Text))
                {
                    saveornot = false;
                }
                else  if (string.IsNullOrEmpty(stocks_combo_box.Text))
                {
                    saveornot = false;
                }
                else if (parcels.Count <=0)
                {
                    saveornot = true;
                    
                }
            }
            if (saveornot)
            {
                long qu_id = 0;
                //loadallfinishedproductspecifications();


                Cursor.Current = Cursors.WaitCursor;
                    if (parcels.Count > 0)
                    {

                    savenewpermssionnumber();
                        for (int i = 0; i < parcels.Count; i++)
                        {
                        long sp_id = check_if_item_details_exists_or_not(parcels[i]);
                        if (sp_id == 0)
                        { 
                    
                            sp_id = savenewfinishedproductspecification(parcels[i]);
                            qu_id = savefinishedcansquantities(parcels[i], sp_id);
                            save_finished_cans_parcels(parcels[i],sp_id, qu_id);
                        }
                        else
                        {
                            updatecurrentfinishedproductspecification(parcels[i], sp_id);
                            qu_id = savefinishedcansquantities(parcels[i], sp_id);
                            save_finished_cans_parcels(parcels[i], sp_id, qu_id);

                        }
                    }
                    
                    MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    this.Hide();
                    using (addnewfinishedcan myform = new addnewfinishedcan(mEmployee, mAccount, mPermission))
                    {
                        myform.ShowDialog();
                    }
                    this.Close();
                }
                Cursor.Current = Cursors.Default;
                this.Hide();
                using (addnewfinishedcan myform = new addnewfinishedcan(mEmployee,mAccount,mPermission))
                {
                    myform.ShowDialog();
                }
                this.Close();
            }
            
            else
            {
                MessageBox.Show("الرجاء كتابة جميع البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void savenewpermssionnumber()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_ADDITION_PERMISSION_NUMBERS_FINISHED_CANS (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER" ,1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private void addnewfinishedcan_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {

            }else
            {

                fillproductscombobox();


            }
        }

        private void clients_combo_box_TextUpdate(object sender, EventArgs e)
        {
           // fill_clients_combo_box();
        }

        private void clients_combo_box_TextChanged(object sender, EventArgs e)
        {
            //fillclientsbytextcombobox();
        }
    }
}
