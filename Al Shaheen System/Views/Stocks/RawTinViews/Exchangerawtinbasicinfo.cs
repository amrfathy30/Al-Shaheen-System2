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
    public partial class Exchangerawtinbasicinfo : Form
    {
        List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_TIN_PRINTER> printers = new List<SH_TIN_PRINTER>();

        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        


        DatabaseConnection myconnection = new DatabaseConnection();

        long mtotal_no_sheets = 0;
        double mtotal_net_weight = 0;

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public Exchangerawtinbasicinfo(List<SH_RAW_MATERIAL_PARCEL> anyparcels , long total_no_sheets, double total_net_weight , SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPerm)
        {
            InitializeComponent();
            parcels = anyparcels;
            mtotal_no_sheets = total_no_sheets;
            mtotal_net_weight = total_net_weight;
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPerm;

        }
        void loadallprintersdata()
        {
            try
            {
                 
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_TIN_PRINTER", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    printers.Add(new SH_TIN_PRINTER() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_PRINTER = reader["SH_PRINTER"].ToString(), SH_PRINTER_ADDRESS_TEXT = reader["SH_PRINTER_ADDRESS_TEXT"].ToString(), SH_PRINTER_ADDRESS_GPS = reader["SH_PRINTER_ADDRESS_GPS"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTERS DATA " + ex.ToString());
            }
        }

        void fillprintersgridview()
        {
            printers.Clear();
            loadallprintersdata();
            if (printers.Count <= 0)
            {

            }
            else
            {
                p_text_box.Items.Clear();
                for (int i = 0; i < printers.Count; i++)
                {
                    p_text_box.Items.Add(printers[i].SH_PRINTER);
                }

            }
        }
        void loadallstocks()
        {
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_STOCKS";
                
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
                MessageBox.Show("ERROR WHILE GETTING STOCKS DATA FROM DB " + ex.ToString());
            }
        }
        void fillstockscombobox()
        {
            stocks.Clear();
            loadallstocks();
            stock_combo_box.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stock_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }
        void fillparcelsgridview()
        {
            raw_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    raw_parcels_grid_view.Rows.Add(new string[] { (i + 1).ToString(), parcels[i].SH_ID.ToString(), parcels[i].SH_ITEM_LENGTH.ToString(), parcels[i].SH_ITEM_WIDTH.ToString(), parcels[i].SH_ITEM_THICKNESS.ToString(), parcels[i].SH_ITEM_CODE, parcels[i].SH_ITEM_TEMPER, parcels[i].SH_ITEM_COATING, parcels[i].SH_ITEM_TYPE, parcels[i].SH_ITEM_SHEET_WEIGHT.ToString(), parcels[i].SH_ITEM_PARCEL_NET_WEIGHT.ToString(), parcels[i].SH_ITEM_PARCEL_GROSS_WEIGHT.ToString() });
                }
            }
            else
            {
                MessageBox.Show("لا يوجد بيانات ", "معلومات ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void Exchangerawtinbasicinfo_Load(object sender, EventArgs e)
        {
            stock_man_text_box.Text = mEmployee.SH_EMPLOYEE_NAME;
            fillparcelsgridview();
            fillstockscombobox();
            total_net_weight_text_box.Text = mtotal_net_weight.ToString();
            item_total_no_sheets_text_box.Text = mtotal_no_sheets.ToString();
        }

        private void printering_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "إسم المطبعة";
            p_text_box.DropDownStyle = ComboBoxStyle.DropDown;
            fillprintersgridview();
            // printing_panel.Visible = true;
            //fill clients combobox 
            //fillclientscombobox();
            if (receival_information_groupbox.Visible==false)
            {
                receival_information_groupbox.Visible = true;
                driver_name_text_box.Text = "";
                driver_driving_license_number_text_box.Text = "";
                driver_telephone_number_text_box.Text = "";
                driver_Car_number_text_box.Text = "";
            }
           

        }

        //void fillclientscombobox()
        //{
        //    clients.Clear();
        //    try
        //    {
        //        myconnection.openConnection();
        //        SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENTS_DATA",DatabaseConnection.mConnection);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            clients.Add(new SH_CLIENT_COMPANY() {
        //                SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString(),
        //                SH_CLIENT_COMPANY_MOBILE = reader["SH_CLIENT_COMPANY_MOBILE"].ToString(),
        //                SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
        //                SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString(),
        //                SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),
        //                SH_ID = long.Parse(reader["SH_ID"].ToString())
        //            });
        //        }
        //        reader.Close();
        //        myconnection.closeConnection();

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR WHILE GETTING CLIENTS COMBO Box "+ex.ToString());
        //    }

        //    if (clients.Count > 0)
        //    {
        //        clients_combo_box.Items.Clear();
        //        for (int i = 0; i < clients.Count; i++)
        //        {
        //            clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
        //        }
        //    }
        //}


        private void production_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "مرحلة الانتاج";
            p_text_box.DropDownStyle = ComboBoxStyle.DropDown;
            fillproductionddepartments();
            if (receival_information_groupbox.Visible == true)
            {
                receival_information_groupbox.Visible = false;
            }
        }
        void fillproductionddepartments()
        {
            try
            {
                p_text_box.Text = "";
                p_text_box.Items.Clear();
                p_text_box.Items.Add("المقصات");
                p_text_box.Items.Add("المكابس");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING PRODUTIoN DEPARTMENTS "+ex.ToString());
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void addexchangedparcels(long exchangerequest_id, long parcel_id)
        {
            try
            {
                string query = "INSERT INTO SH_PACKAGES_DISBURSED_RAW_MATERIAL ";
                query += "(SH_RAW_MATERIAL_PARCEL_ID, SH_EXCHANGE_OF_RAW_MATERIAL_ID, SH_EXCHANGE_DATE) ";
                query += " VALUES(@SH_EXCHANGE_OF_RAW_MATERIAL_ID,@SH_RAW_MATERIAL_PARCEL_ID,@SH_EXCHANGE_DATE)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_OF_RAW_MATERIAL_ID", exchangerequest_id);
                cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_PARCEL_ID", parcel_id);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE", DateTime.Now);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING TO ECHANGED PARCEL TABLE " + ex.ToString());
            }
        }

        private string get_change_reason()

        {
            if (printering_radio_btn.Checked)
            {
                return "الطباعة";

            }
            else if (muraning_radio_btn.Checked)
            {
                return "الورنشة";
            }
            else if (production_radio_btn.Checked)
            {
                return "الانتاج";
            }
            else
            {
                return null;
            }
        }
        long saveexchangerawtin()
        {

            try
            {
                string query = "INSERT INTO SH_EXCHANGE_OF_RAW_MATERIAL ";
                query += "(SH_STOCK_MAN_NAME, SH_STOCK_NAME, SH_RECIPICIENT_MAN_NAME, SH_CONFIDENTIEL_MAN_NAME, SH_WORK_NUMBER, SH_EXCHANGE_DATE, SH_EXCHANGE_PERMISSION_NUMBER , SH_REASON_OF_EXCHANGE, SH_PLACE_OF_EXCHANGE , SH_EXCHANGED_NO_PARCELS) ";
                query += "VALUES(@SH_STOCK_MAN_NAME,@SH_STOCK_NAME,@SH_RECIPICIENT_MAN_NAME,@SH_CONFIDENTIEL_MAN_NAME,@SH_WORK_NUMBER,@SH_EXCHANGE_DATE,@SH_EXCHANGE_PERMISSION_NUMBER , @SH_REASON_OF_EXCHANGE, @SH_PLACE_OF_EXCHANGE  , @SH_EXCHANGED_NO_PARCELS)";
                query += " SELECT SCOPE_IDENTITY() AS myidentity";
                
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
           
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME", stock_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", stock_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_RECIPICIENT_MAN_NAME", receival_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CONFIDENTIEL_MAN_NAME", confidential_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_WORK_NUMBER", work_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER", exchange_permission_number.Text);
                cmd.Parameters.AddWithValue("@SH_REASON_OF_EXCHANGE", get_change_reason());
                cmd.Parameters.AddWithValue("@SH_PLACE_OF_EXCHANGE", p_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_EXCHANGED_NO_PARCELS" , parcels.Count);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING TO EXCHANGE TABLE IN DB " + ex.ToString());
            }
            return 0;
        }
        void updateitemtotalrecords()
        {
            for (int i = 0; i < parcels.Count; i++)
            {
                //MessageBox.Show(parcels[i].SH_ITEM_PARCEL_NET_WEIGHT.ToString());
                try
                {
                    string query = "UPDATE SH_SPECIFICATION_OF_RAW_MATERIAL ";
                    query += "  SET SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = SH_ITEM_TOTAL_NUMBER_OF_PACKAGES - @SH_ITEM_TOTAL_NUMBER_OF_PACKAGES     ";
                    query += ", SH_ITEM_TOTAL_NUMBER_OF_SHEETS = SH_ITEM_TOTAL_NUMBER_OF_SHEETS - @SH_ITEM_TOTAL_NUMBER_OF_SHEETS  ";
                    query += ", SH_TOTAL_NET_WEIGHT = SH_TOTAL_NET_WEIGHT - @SH_TOTAL_NET_WEIGHT ";
                    query += ", SH_TOTAL_GROSS_WEIGHT = SH_TOTAL_GROSS_WEIGHT - @SH_TOTAL_GROSS_WEIGHT ";
                    query += "  WHERE(SH_ID = @SH_ID)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES", 1);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", parcels[i].SH_ITEM_NUMBER_OF_SHEETS);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT", parcels[i].SH_ITEM_PARCEL_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT", parcels[i].SH_ITEM_GROSS_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_ID", parcels[i].SH_SPECIFICATION_OF_RAW_MATERIAL_ID);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE UPDATING SPECIFICATION " + ex.ToString());
                }
            }
        }
        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (parcels.Count != 0)
            {
                if ((errorProvider1.GetError(exchange_permission_number) == "") && (errorProvider1.GetError(work_number_text_box) == "") && (errorProvider1.GetError(stock_man_text_box) == "") && (errorProvider1.GetError(receival_man_text_box) == "") && (errorProvider1.GetError(confidential_man_text_box) == ""))
                {

                    if (string.IsNullOrEmpty(stock_combo_box.Text) || string.IsNullOrEmpty(stock_man_text_box.Text) || string.IsNullOrEmpty(confidential_man_text_box.Text) || string.IsNullOrEmpty(p_text_box.Text) || string.IsNullOrEmpty(work_number_text_box.Text) || string.IsNullOrEmpty(exchange_permission_number.Text) || string.IsNullOrEmpty(receival_man_text_box.Text))
                    {
                        MessageBox.Show("الرجاء ادخال البيانات المراد حفظها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                    else
                    {



                        if (printering_radio_btn.Checked || muraning_radio_btn.Checked)
                        {
                            if (string.IsNullOrWhiteSpace(driver_name_text_box.Text))
                            {
                                MessageBox.Show(" الرجاء كتابة إسم السائق  ( المسلتم )",  "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                            }else if (string.IsNullOrWhiteSpace(driver_Car_number_text_box.Text))
                            {
                                MessageBox.Show(" الرجاء كتابة رقم سيارة السائق ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                            }else if (string.IsNullOrWhiteSpace(driver_driving_license_number_text_box.Text))
                            {
                                MessageBox.Show(" الرجاء كتابة رقم رخصة السائق ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            }
                            else if (string.IsNullOrWhiteSpace(driver_telephone_number_text_box.Text))
                            {
                                MessageBox.Show(" الرجاء كتابة رقم تليفون السائق ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            }
                            long process_id = saveexchangerawtin();
                            if (process_id == 0)
                            {
                                //error not ssaved
                            }
                            else
                            {
                                for (int i = 0; i < parcels.Count; i++)
                                {
                                    //MessageBox.Show(process_id.ToString() + " ::: " + parcels[i].SH_ITEM_ID.ToString());

                                    addexchangedparcels(process_id, parcels[i].SH_ID);
                                }
                                updateitemtotalrecords();
                                //ADD _PARCELS_TO PRINTER
                                await saveprinterrawtinquantities();

                            }
                        }
                        else
                        {

                            long process_id = saveexchangerawtin();
                            if (process_id == 0)
                            {
                                //error not ssaved
                            }
                            else
                            {
                                for (int i = 0; i < parcels.Count; i++)
                                {
                                    //MessageBox.Show(process_id.ToString() + " ::: " + parcels[i].SH_ITEM_ID.ToString());

                                    addexchangedparcels(process_id, parcels[i].SH_ID);
                                }
                                updateitemtotalrecords();
                            }
                        }

                            MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            using (print_exchange_request myform = new print_exchange_request(work_number_text_box.Text, exchange_permission_number.Text, stock_man_text_box.Text, confidential_man_text_box.Text, receival_man_text_box.Text, stock_combo_box.Text, parcels, get_change_reason()))
                            {
                                myform.ShowDialog();
                            }
                        }

                    
                }
                else
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("الرجاء ادخال البيانات المراد حفظها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        async Task saveprinterrawtinquantities()
        {
            for (int i = 0; i < parcels.Count; i++)
            {

          
            try
            {
                myconnection.openConnection();
                string query = " INSERT INTO SH_PRINTER_ADDING_QUANTITY_OF_RAW_MATERIAL ";
                query += " (SH_SPECIFICATION_OF_RAW_MATERIAL_ID, SH_ITEM_LENGTH, ";
                query += "          SH_ITEM_WIDTH, SH_ITEM_INTENSITY, ";
                query += "         SH_ITEM_THICKNESS, SH_ITEM_TEMPER, SH_ITEM_FINISH, ";
                query += "           SH_ITEM_COATING, ";
                query += "          SH_ITEM_TYPE, SH_ITEM_NAME, ";
                query += "          SH_ITEM_SHEET_WEIGHT, SH_ITEM_CODE, SH_SHAHEEN_STOCK_ID, ";
                query += "          SH_DRIVER_NAME, ";
                query += "          SH_TOTAL_NUMBER_OF_PACKAGES, ";
                query += "          SH_SHAHEEN_STOCK_MAN_ID, SH_NO_SHEETS_PER_PACKAGE, ";
                query += "           SH_TOTAL_NO_SHEETS_PER_QUANTITY, SH_PACKAGE_NET_WEIGHT, ";
                query += "          SH_TOTAL_NET_WEIGHT, ";
                query += "          SH_PRINTER_ID, SH_ADDITION_DATE, ";
                query += "          SH_QUANTITY_GROSS_WEIGHT, SH_DATA_ENTRY_USER_ID, ";
                query += "          SH_EXCHANGE_PERMISSION_NUMBER_OF_RAW_TIN_FROM_SHAHEEN_STOCK, ";
                query += "          SH_DATA_ENTRY_USER_NAME, ";
                query += "           SH_DATA_ENTRY_EMPLOYEE_ID, ";
                query += "          SH_DATA_ENTRY_EMPLOYEE_NAME, SH_DRIVER_CAR_NUMBER, ";
                query += "          SH_DRIVER_DRIVING_LICENSE, SH_DRIVER_TELEPHONE_NUMBER ) ";
                query += " VALUES ";
                query += " (@SH_SPECIFICATION_OF_RAW_MATERIAL_ID, ";
                query += " @SH_ITEM_LENGTH, @SH_ITEM_WIDTH, ";
                query += " @SH_ITEM_INTENSITY, ";
                query += " @SH_ITEM_THICKNESS, @SH_ITEM_TEMPER, @SH_ITEM_FINISH, @SH_ITEM_COATING, ";
                query += " @SH_ITEM_TYPE, @SH_ITEM_NAME, ";
                query += " @SH_ITEM_SHEET_WEIGHT, @SH_ITEM_CODE, @SH_SHAHEEN_STOCK_ID, @SH_DRIVER_NAME, ";
                query += " @SH_TOTAL_NUMBER_OF_PACKAGES, ";
                query += " @SH_SHAHEEN_STOCK_MAN_ID, @SH_NO_SHEETS_PER_PACKAGE, ";
                query += " @SH_TOTAL_NO_SHEETS_PER_QUANTITY, @SH_PACKAGE_NET_WEIGHT ";
                query += " , @SH_TOTAL_NET_WEIGHT, @SH_PRINTER_ID, @SH_ADDITION_DATE, ";
                query += " @SH_QUANTITY_GROSS_WEIGHT, @SH_DATA_ENTRY_USER_ID, ";
                query += " @SH_EXCHANGE_PERMISSION_NUMBER_OF_RAW_TIN_FROM_SHAHEEN_STOCK, ";
                query += " @SH_DATA_ENTRY_USER_NAME, @SH_DATA_ENTRY_EMPLOYEE_ID, ";
                query += " @SH_DATA_ENTRY_EMPLOYEE_NAME, @SH_DRIVER_CAR_NUMBER, ";
                query += " @SH_DRIVER_DRIVING_LICENSE, @SH_DRIVER_TELEPHONE_NUMBER)  ";
                query += " SELEcT SCOPE_IDENTITY AS myidentity";
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", parcels[i].SH_SPECIFICATION_OF_RAW_MATERIAL_ID );
                cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", parcels[i].SH_ITEM_LENGTH);
                cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", parcels[i].SH_ITEM_WIDTH);
                cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY", parcels[i].SH_ITEM_INTENSITY);
                cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", parcels[i].SH_ITEM_THICKNESS);
                cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", parcels[i].SH_ITEM_TEMPER);
                cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", parcels[i].SH_ITEM_FINISH);
                cmd.Parameters.AddWithValue("@SH_ITEM_COATING", parcels[i].SH_ITEM_COATING);
                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", parcels[i].SH_ITEM_TYPE);
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", parcels[i].SH_ITEM_SHEET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_CODE", parcels[i].SH_ITEM_CODE);
                cmd.Parameters.AddWithValue("@SH_SHAHEEN_STOCK_ID", stocks[stock_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_DRIVER_NAME",  driver_name_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PACKAGES", 1 );
                cmd.Parameters.AddWithValue("@SH_SHAHEEN_STOCK_MAN_ID", mEmployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_NO_SHEETS_PER_PACKAGE", parcels[i].SH_ITEM_NUMBER_OF_SHEETS);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_SHEETS_PER_QUANTITY", parcels[i].SH_ITEM_NUMBER_OF_SHEETS);
                cmd.Parameters.AddWithValue("@SH_PACKAGE_NET_WEIGHT", parcels[i].SH_ITEM_PARCEL_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT", parcels[i].SH_ITEM_PARCEL_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_PRINTER_ID", printers[p_text_box.SelectedIndex].SH_ID );
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_QUANTITY_GROSS_WEIGHT", parcels[i].SH_ITEM_PARCEL_GROSS_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID",mAccount.SH_ID );
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER_OF_RAW_TIN_FROM_SHAHEEN_STOCK",exchange_permission_number.Text );
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME", mAccount.SH_EMP_USER_NAME);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID",mEmployee.SH_ID );
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mEmployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_DRIVER_CAR_NUMBER", driver_Car_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_DRIVING_LICENSE",driver_driving_license_number_text_box.Text );
                cmd.Parameters.AddWithValue("@SH_DRIVER_TELEPHONE_NUMBER",driver_telephone_number_text_box.Text );
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                while (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR wHILE SAVING PRINTER QUANTITIES "+ex.ToString());
            }
            }
        }

        private void muraning_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "إسم المطبعة";
            p_text_box.DropDownStyle = ComboBoxStyle.DropDown;
            fillprintersgridview();
            if (receival_information_groupbox.Visible == false)
            {
                receival_information_groupbox.Visible = true;
                driver_name_text_box.Text = "";
                driver_driving_license_number_text_box.Text = "";
                driver_telephone_number_text_box.Text = "";
                driver_Car_number_text_box.Text = "";
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
