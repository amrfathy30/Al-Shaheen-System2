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
    public partial class addnewprintingmaterialfd : Form
    {
        List<SH_FACE_COLOR> FACES = new List<SH_FACE_COLOR>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_PRODUCT_OF_CLIENTS_PARCELS> client_products = new List<SH_PRODUCT_OF_CLIENTS_PARCELS>();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_QUANTITIES_OF_PRINTED_MATERIAL> quantities = new List<SH_QUANTITIES_OF_PRINTED_MATERIAL>();
        List<SH_MURAN_MATERIAL_PARCEL> muran_material_parcels = new List<SH_MURAN_MATERIAL_PARCEL>();
        List<SH_SPECIFICATION_OF_PRINTED_MATERIAL> printed_materials = new List<SH_SPECIFICATION_OF_PRINTED_MATERIAL>();
        List<SH_TIN_PRINTER> printers = new List<SH_TIN_PRINTER>();

        long total_no_packges = 0;
        long all_packages_no_sheets = 0;
        //double all_packages_gross_weight = 0;
        double all_packages_net_weight = 0;
        //double all_first_face_net_weight = 0;
        //double all_second_face_net_weight = 0;

        long total_number_of_bottel_per_sheet = 0;


        public addnewprintingmaterialfd()
        {
            InitializeComponent();
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

        void fillstockscombobox()
        {
            stocks.Clear();
            loadallstocks();
            stock_name_combo_box.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stock_name_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }

        long saveprintedmaterialspecification()
        {

            try
            {
                string query = "INSERT INTO SH_SPECIFICATION_OF_PRINTED_MATERIAL ";
                query += "(SH_ITEM_LENGTH,SH_ITEM_INTENSITY ,SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_CODE, SH_ITEM_TYPE, SH_ITEM_SHEET_WEIGHT, SH_ITEM_TOTAL_NO_SHEETS, SH_ITEM_TOTAL_NET_WEIGHT,";
                query += " SH_ITEM_TOTAL_GROSS_WEIGHT, SH_ITEM_NAME, SH_ITEM_TOTAL_NO_PARCELS) ";
                query += " VALUES(@SH_ITEM_LENGTH,@SH_ITEM_INTENSITY ,@SH_ITEM_WIDTH ,@SH_ITEM_THICKNESS,@SH_ITEM_CODE,@SH_ITEM_TYPE";
                query += ",@SH_ITEM_SHEET_WEIGHT,@SH_ITEM_TOTAL_NO_SHEETS,@SH_ITEM_TOTAL_NET_WEIGHT,@SH_ITEM_TOTAL_GROSS_WEIGHT,@SH_ITEM_NAME,@SH_ITEM_TOTAL_NO_PARCELS)";
                query += " SELECT SCOPE_IDENTITY() AS myidentity";

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", double.Parse(item_width_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", double.Parse(item_thickness_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_CODE", item_code_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", double.Parse(item_sheet_weight_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_SHEETS", all_packages_no_sheets);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NET_WEIGHT", all_packages_net_weight);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_GROSS_WEIGHT", 0);
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY" , double.Parse(item_intensity_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_PARCELS", total_no_packges);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE PRINTED MATERIAL TO DB " + ex.ToString());
            }

            return 0;

        }


        void loadallspecifications()
        {
            printed_materials.Clear();
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PRINTED_MATERIAL";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    printed_materials.Add(new SH_SPECIFICATION_OF_PRINTED_MATERIAL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString(), SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), SH_ITEM_TOTAL_GROSS_WEIGHT = double.Parse(reader["SH_ITEM_TOTAL_GROSS_WEIGHT"].ToString()), SH_ITEM_SHEET_WEIGHT = double.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()), SH_ITEM_TOTAL_NET_WEIGHT = double.Parse(reader["SH_ITEM_TOTAL_NET_WEIGHT"].ToString()), SH_ITEM_TOTAL_NO_PARCELS = long.Parse(reader["SH_ITEM_TOTAL_NO_PARCELS"].ToString()), SH_ITEM_TOTAL_NO_SHEETS = long.Parse(reader["SH_ITEM_TOTAL_NO_SHEETS"].ToString()), SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString(), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTED MATERIAL INFO " + ex.ToString());
            }

        }


        long check_where_specification_exists_or_not()
        {
            long sp_id = 0;
            if (printed_materials.Count > 0)
            {
                for (int i = 0; i < printed_materials.Count; i++)
                {
                    if ((string.Compare(printed_materials[i].SH_ITEM_CODE , item_code_text_box.Text)==0) && (printed_materials[i].SH_ITEM_LENGTH == double.Parse(item_length_text_box.Text)) && (printed_materials[i].SH_ITEM_THICKNESS == double.Parse(item_thickness_text_box.Text)) && (printed_materials[i].SH_ITEM_WIDTH == double.Parse(item_width_text_box.Text)) && (string.Compare(printed_materials[i].SH_ITEM_TYPE , item_type_combo_box.Text)==0))
                    {
                        sp_id = printed_materials[i].SH_ID;
                    }
                }
            }
           return sp_id;
        }

        void updatespecificationvalues(long sp_id)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_PRINTED_MATERIAL ";
                query += "SET SH_ITEM_TOTAL_NO_SHEETS = SH_ITEM_TOTAL_NO_SHEETS + @SH_ITEM_TOTAL_NO_SHEETS, SH_ITEM_TOTAL_NET_WEIGHT = SH_ITEM_TOTAL_NET_WEIGHT + @SH_ITEM_TOTAL_NET_WEIGHT, SH_ITEM_TOTAL_GROSS_WEIGHT = SH_ITEM_TOTAL_GROSS_WEIGHT + @SH_ITEM_TOTAL_GROSS_WEIGHT, SH_ITEM_TOTAL_NO_PARCELS = SH_ITEM_TOTAL_NO_PARCELS + @SH_ITEM_TOTAL_NO_PARCELS ";
                query += " WHERE(SH_ID = @SH_ID)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_SHEETS", all_packages_no_sheets);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NET_WEIGHT" , total_net_weight);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_GROSS_WEIGHT" , 0);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_PARCELS" , total_no_packges);
                cmd.Parameters.AddWithValue("@SH_ID" , sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE SETTING NEW VLUES TO SPECIFICATION");
            }
        }


        void saveprintedmaterialquantity(long sp_id)
        {
            
            if (quantities.Count > 0)
            {
                long quant_id = 0;
                for (int i = 0; i < quantities.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_QUANTITIES_OF_PRINTED_MATERIAL ";
                        query += "(SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID, SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_CODE, SH_ITEM_TYPE, SH_ITEM_SHEET_WEIGHT, SH_ITEM_NO_SHEETS, SH_ITEM_NET_WEIGHT, ";
                        query += " SH_ITEM_GROSS_WEIGHT, SH_ITEM_NO_PARCELS, SH_ADDITION_DATE, SH_STOCK_NAME, SH_PRINTER_ID, SH_PRINTER_NAME, SH_PRINTING_PERMISSION_NUMBER, SH_TOTAL_NUMBER_OF_BOTTELS, ";
                        query += " SH_PARCEL_NET_WEIGHT) VALUES( @SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID,@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_CODE,@SH_ITEM_TYPE,@SH_ITEM_SHEET_WEIGHT,@SH_ITEM_NO_SHEETS,@SH_ITEM_NET_WEIGHT,@SH_ITEM_GROSS_WEIGHT";
                        query += ",@SH_ITEM_NO_PARCELS,@SH_ADDITION_DATE,@SH_STOCK_NAME,@SH_PRINTER_ID,@SH_PRINTER_NAME,@SH_PRINTING_PERMISSION_NUMBER,@SH_TOTAL_NUMBER_OF_BOTTELS,@SH_PARCEL_NET_WEIGHT)";
                        query += "SELECT SCOPE_IDENTITY() AS myidentity";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID", sp_id);
                        cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", quantities[i].SH_ITEM_LENGTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH" , quantities[i].SH_ITEM_WIDTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS" , quantities[i].SH_ITEM_THICKNESS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CODE" , quantities[i].SH_ITEM_CODE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE" , quantities[i].SH_ITEM_TYPE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT" , quantities[i].SH_ITEM_SHEET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NO_SHEETS" , quantities[i].SH_ITEM_TOTAL_NO_SHEETS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NET_WEIGHT", quantities[i].SH_ITEM_TOTAL_NET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_GROSS_WEIGHT" , quantities[i].SH_ITEM_TOTAL_GROSS_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NO_PARCELS" , quantities[i].SH_ITEM_TOTAL_NO_PARCELS);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE" , DateTime.Now);
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , quantities[i].SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_PRINTER_ID" , quantities[i].SH_PRINTER_ID);
                        cmd.Parameters.AddWithValue("@SH_PRINTER_NAME" , quantities[i].SH_PRINTER_NAME);
                        cmd.Parameters.AddWithValue("@SH_PRINTING_PERMISSION_NUMBER" , quantities[i].SH_PRINTING_PERMISSION_NUMBER);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS" , quantities[i].SH_TOTAL_NUMBER_OF_BOTTELS);
                        cmd.Parameters.AddWithValue("@SH_PARCEL_NET_WEIGHT" , quantities[i].SH_PARCEL_NET_WEIGHT);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            quant_id = long.Parse(reader["myidentity"].ToString());
                            savequantity_clients_and_products(sp_id , quant_id);
                            saveparcels(sp_id , quant_id , quantities[i].SH_ITEM_TOTAL_NO_PARCELS , quantities[i]);
                        }

                        myconnection.closeConnection();
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show("ERROR WHILE ADDING QUANTITIES to db "+EX.ToString());
                    }
                }
            }
            else
            {

            }
        }

        void savequantity_clients_and_products(long sp_id  , long quantity_id )
        {
            if (client_products.Count > 0)
            {
                for (int i = 0; i < client_products.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_PRODUCT_OF_CLIENTS_QUANTITIES ";
                        query += "(SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID, SH_QUANTITIES_OF_PRINTED_MATERIAL_ID, SH_CLIENT_ID, SH_PRODUCT_ID, SH_CLIENT_NAME, SH_PRODUCT_NAME, SH_PRODUCT_NO_OF_BOTTELS, ";
                        query += " SH_ADDITION_DATE) VALUES(@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID,@SH_QUANTITIES_OF_PRINTED_MATERIAL_ID,@SH_CLIENT_ID,@SH_PRODUCT_ID,@SH_CLIENT_NAME,@SH_PRODUCT_NAME,@SH_PRODUCT_NO_OF_BOTTELS,@ADDITION_DATE)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID", sp_id);
                        cmd.Parameters.AddWithValue("@SH_QUANTITIES_OF_PRINTED_MATERIAL_ID", quantity_id);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID", client_products[i].SH_CLIENT_ID);
                        cmd.Parameters.AddWithValue("@SH_PRODUCT_ID" ,client_products[i].SH_CLIENT_PRODUCT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME" , client_products[i].SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME" , client_products[i].SH_CLIENT_PRODUCT_NAME);
                        cmd.Parameters.AddWithValue("@SH_PRODUCT_NO_OF_BOTTELS", client_products[i].SH_NO_BOTTLES_PER_SHEET);
                        cmd.Parameters.AddWithValue("@ADDITION_DATE" , DateTime.Now);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show("ERROR WHILE SAVING CLIENT PRODUCTS QUANTITES "+ex.ToString());
                    }
                }
            }
        }

        void saveparcels(long sp_id , long quantity_id , long no_parcels , SH_QUANTITIES_OF_PRINTED_MATERIAL myquantity )
        {
            if (no_parcels <=0)
            {

            }
            else
            {
                long parcel_id = 0;
                for (int i = 0; i < no_parcels; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_PRINTED_MATERIAL_PARCEL ";
                        query += "(SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID, SH_QUANTITIES_OF_PRINTED_MATERIAL_ID, SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_CODE, SH_ITEM_TYPE, SH_ITEM_SHEET_WEIGHT,";
                        query += " SH_ITEM_NO_SHEETS, SH_ITEM_GROSS_WEIGHT, SH_ITEM_NET_WEIGHT, SH_ADDITION_DATE, SH_ITEM_INTENSITY, SH_STOCK_NAME, SH_PRINTER_ID, SH_PRINTER_NAME, SH_TOTAL_NUMBER_OF_BOTTELS, ";
                        query += " SH_PRINTING_PERMISSION_NUMBER) VALUES(@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID,@SH_QUANTITIES_OF_PRINTED_MATERIAL_ID,@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_CODE,@SH_ITEM_TYPE,@SH_ITEM_SHEET_WEIGHT,@SH_ITEM_NO_SHEETS,@SH_ITEM_GROSS_WEIGHT,";
                        query += "@SH_ITEM_NET_WEIGHT,@SH_ADDITION_DATE,@SH_ITEM_INTENSITY,@SH_STOCK_NAME,@SH_PRINTER_ID,@SH_PRINTER_NAME,@SH_TOTAL_NUMBER_OF_BOTTELS,@SH_PRINTING_PERMISSION_NUMBER)";
                        query += "SELECT SCOPE_IDENTITY() AS myidentity";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID", sp_id );
                        cmd.Parameters.AddWithValue("@SH_QUANTITIES_OF_PRINTED_MATERIAL_ID", quantity_id);
                        cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH" , myquantity.SH_ITEM_LENGTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH" , myquantity.SH_ITEM_WIDTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS" , myquantity.SH_ITEM_THICKNESS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CODE" , myquantity.SH_ITEM_CODE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE",myquantity.SH_ITEM_TYPE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", myquantity.SH_ITEM_SHEET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NO_SHEETS" , myquantity.SH_PARCEL_NO_SHEETS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_GROSS_WEIGHT" ,0);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NET_WEIGHT",myquantity.SH_PARCEL_NET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY" , double.Parse(item_intensity_text_box.Text));
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME", myquantity.SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_PRINTER_ID" , myquantity.SH_PRINTER_ID);
                        cmd.Parameters.AddWithValue("@SH_PRINTER_NAME" , myquantity.SH_PRINTER_NAME);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS", (myquantity.SH_TOTAL_NUMBER_OF_BOTTELS/myquantity.SH_ITEM_TOTAL_NO_SHEETS )*myquantity.SH_PARCEL_NO_SHEETS);
                        cmd.Parameters.AddWithValue("@SH_PRINTING_PERMISSION_NUMBER", myquantity.SH_PRINTING_PERMISSION_NUMBER);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            parcel_id = long.Parse(reader["myidentity"].ToString());
                            save_parcels_products_and_clients(sp_id , quantity_id , parcel_id , (myquantity.SH_TOTAL_NUMBER_OF_BOTTELS / myquantity.SH_ITEM_TOTAL_NO_SHEETS) * myquantity.SH_PARCEL_NO_SHEETS);
                        }
                       myconnection.closeConnection();

                    }
                    catch (Exception ex )
                    {
                        MessageBox.Show("ERROR WHILE SAVING PARCELS "+ex.ToString());
                    }
                }

                MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }

        void save_parcels_products_and_clients(long sp_id , long quantity_id , long parcel_id , long parcel_no_bottels )
        {
            if (client_products.Count >0)
            {            
                for (int i = 0; i < client_products.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_PRODUCT_OF_CLIENTS_PARCELS ";
                        query += "(SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID, SH_QUANTITIES_OF_PRINTED_MATERIAL_ID, SH_PRINTED_MATERIAL_PARCEL_ID, SH_CLIENT_ID, SH_CLIENT_NAME, SH_CLIENT_PRODUCT_ID, ";
                        query += " SH_NO_BOTTELS_PER_SHEET, SH_CLIENT_PRODUCT_NAME, SH_TOTAL_NUMBER_OF_BOTTELS) ";
                        query += " VALUES(@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID,@SH_QUANTITIES_OF_PRINTED_MATERIAL_ID,@SH_PRINTED_MATERIAL_PARCEL_ID,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_CLIENT_PRODUCT_ID,@SH_NO_BOTTELS_PER_SHEET,@SH_CLIENT_PRODUCT_NAME,@SH_TOTAL_NUMBER_OF_BOTTELS)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID", sp_id );
                        cmd.Parameters.AddWithValue("@SH_QUANTITIES_OF_PRINTED_MATERIAL_ID" , quantity_id);
                        cmd.Parameters.AddWithValue("@SH_PRINTED_MATERIAL_PARCEL_ID" , parcel_id);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , client_products[i].SH_CLIENT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME" , client_products[i].SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID" , client_products[i].SH_CLIENT_PRODUCT_ID);
                        cmd.Parameters.AddWithValue("@SH_NO_BOTTELS_PER_SHEET", client_products[i].SH_NO_BOTTLES_PER_SHEET);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME" , client_products[i].SH_CLIENT_PRODUCT_NAME);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS" , parcel_no_bottels);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING PARCEL CLIENTS PRODUCTS "+ex.ToString());
                    }
                }
            }
        }
       
        void loadallprintersdata()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
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
            loadallprintersdata();
            if (printers.Count <= 0)
            {

            }
            else
            {
                printers_combo_box.Items.Clear();
                for (int i = 0; i < printers.Count; i++)
                {
                    printers_combo_box.Items.Add(printers[i].SH_PRINTER);
                }

            }
        }


        void loadclientsdata()
        {
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
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB"+ex.ToString());
            }
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

        private void addnewmuranmaterialfd_Load(object sender, EventArgs e)
        {
           
            item_intensity_text_box.Text = 7.85.ToString();
            fillprintersgridview();
            fillstockscombobox();
            item_total_number_of_packages.Text = "0";
            parcel_net_weight.Text = "0.00";
            total_net_weight.Text = "0.00";
           // total_gross_weight.Text = "0.00";
            item_sheet_weight_text_box.Text = "0.00";
            fill_clients_combo_box();

        }
        private void item_length_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_length_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_length_text_box, "ادخل الطول بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();

            }
        }

        private void item_width_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_width_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_width_text_box, "ادخل العرض بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();

            }
        }

        private void item_thickness_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_thickness_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_thickness_text_box, "ادخل السمك بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();

            }
        }

        private void no_sheets_per_package_text_box_TextChanged(object sender, EventArgs e)
        {
            long mygross = 0;
            if (!long.TryParse(no_sheets_per_package_text_box.Text, out mygross))
            {
                errorProvider1.SetError(no_sheets_per_package_text_box, " 123 ادخل عدد الشيتات  بصورة ارقام");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        
        string removedotinnumber(double number)
        {
            string numerFDS = number.ToString();
            return numerFDS.Replace(".", "");
        }
        private void printer_name_text_box_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(printer_name_text_box.Text))
            //{
            //    errorProvider1.SetError(printer_name_text_box, "ادخل إسم المطبعة");

            //}
        }

        void fillgridviewitems()
        {
            item_quantities_grid_view.Rows.Clear();

            for (int i = 0; i < quantities.Count; i++)
            {
                item_quantities_grid_view.Rows.Add(new string[] { (i + 1).ToString(), quantities[i].SH_ITEM_TOTAL_NO_PARCELS.ToString(), quantities[i].SH_ITEM_TOTAL_NO_SHEETS.ToString() ,  quantities[i].SH_PARCEL_NET_WEIGHT.ToString() , quantities[i].SH_ITEM_TOTAL_NET_WEIGHT.ToString() , quantities[i].SH_TOTAL_NUMBER_OF_BOTTELS.ToString() });
            }
        }
        bool check_if_quantity_is_exists_or_not()
        {
            if (quantities.Count > 0)
            {

                for (int i = 0; i < quantities.Count; i++)
                {

                    if ((string.Compare(quantities[i].SH_ITEM_CODE ,item_code_text_box.Text)==0) &&(quantities[i].SH_ITEM_SHEET_WEIGHT == double.Parse(item_sheet_weight_text_box.Text)) && (quantities[i].SH_ITEM_TOTAL_NO_SHEETS ==( long.Parse(no_packages_text_box.Text) * long.Parse(no_sheets_per_package_text_box.Text))) && (quantities[i].SH_PRINTER_ID == printers[printers_combo_box.SelectedIndex].SH_ID) && (quantities[i].SH_ITEM_TOTAL_NO_PARCELS == long.Parse(no_packages_text_box.Text)) && (string.Compare(quantities[i].SH_STOCK_NAME , stock_name_combo_box.Text)==0))
                    {
                        return true;
                    }


                }

            }


            return false;
        }
        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text) || string.IsNullOrEmpty(item_type_combo_box.Text) || string.IsNullOrEmpty(stock_name_combo_box.Text))
            {
                //DO NOTHING
                MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if ((errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == ""))
            {
                item_code_text_box.Text = item_type_combo_box.Text + removedotinnumber(double.Parse(item_thickness_text_box.Text)) + removedotinnumber(double.Parse(item_width_text_box.Text)) + removedotinnumber(double.Parse(item_length_text_box.Text));
                item_sheet_weight_text_box.Text = ((double.Parse(item_length_text_box.Text) * double.Parse(item_width_text_box.Text) * double.Parse(item_thickness_text_box.Text) / 1000000) * double.Parse(item_intensity_text_box.Text)).ToString();

                if (string.IsNullOrWhiteSpace(no_packages_text_box.Text) || string.IsNullOrWhiteSpace(no_sheets_per_package_text_box.Text))
                {
                    MessageBox.Show("لا يمكن إضافة فراغات من الكمية  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (errorProvider1.GetError(no_packages_text_box) != "" || errorProvider1.GetError(no_sheets_per_package_text_box) != "")
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (string.IsNullOrEmpty(printers_combo_box.Text))
                {
                    MessageBox.Show("يجب إختيار إسم المطبعة " , " خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
                else
                {
                    long total_n_bottels = total_number_of_bottel_per_sheet * long.Parse(no_packages_text_box.Text)*long.Parse(no_sheets_per_package_text_box.Text);
                    quantity_net_weight.Text = (long.Parse(no_packages_text_box.Text) * long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();
                    parcel_net_weight.Text = (long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();


                    if (check_if_quantity_is_exists_or_not())
                    {

                        MessageBox.Show("الكمية موجودة"  , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);

                    }else
                    {
                        quantities.Add(new SH_QUANTITIES_OF_PRINTED_MATERIAL() { SH_ITEM_CODE  = item_code_text_box.Text  , SH_ITEM_LENGTH = long.Parse(item_length_text_box.Text)  , SH_ITEM_THICKNESS = double.Parse(item_thickness_text_box.Text) , SH_ITEM_TOTAL_NO_PARCELS = long.Parse(no_packages_text_box.Text) , SH_ITEM_TOTAL_NO_SHEETS = long.Parse(no_packages_text_box.Text)*long.Parse(no_sheets_per_package_text_box.Text) , SH_ITEM_SHEET_WEIGHT = double.Parse(item_sheet_weight_text_box.Text) , SH_PARCEL_NET_WEIGHT = double.Parse(parcel_net_weight.Text) , SH_PRINTER_ID = printers[printers_combo_box.SelectedIndex].SH_ID , SH_PRINTER_NAME = printers_combo_box.Text , SH_ITEM_TOTAL_NET_WEIGHT = double.Parse(quantity_net_weight.Text) , SH_STOCK_NAME = stock_name_combo_box.Text , SH_TOTAL_NUMBER_OF_BOTTELS = total_n_bottels , SH_ITEM_TYPE = item_type_combo_box.Text , SH_PRINTING_PERMISSION_NUMBER = printing_permission_number.Text   , SH_ITEM_WIDTH = double.Parse(item_width_text_box.Text) , SH_PARCEL_NO_SHEETS = long.Parse(no_sheets_per_package_text_box.Text) });
                        fillgridviewitems();
                        all_packages_no_sheets += long.Parse(no_sheets_per_package_text_box.Text) * long.Parse(no_packages_text_box.Text);
                        total_no_packges += long.Parse(no_packages_text_box.Text);
                        all_packages_net_weight += double.Parse(quantity_net_weight.Text);
                        total_net_weight.Text = all_packages_net_weight.ToString();
                        item_total_number_of_packages.Text = total_no_packges.ToString();
                    }
                }
            }
        }
        private void remove_quantity_btn_Click(object sender, EventArgs e)
        {
            if (item_quantities_grid_view.SelectedRows.Count > 0)
            {
                quantities.Remove(quantities[item_quantities_grid_view.SelectedRows[0].Index]);
            }
            fillgridviewitems();
        }

        private void new_record_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewmuranmaterialfd myform = new addnewmuranmaterialfd())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_data_btn_Click(object sender, EventArgs e)
        {
            if (client_products.Count < 1)
            {
                MessageBox.Show("الرجاء إضافة الأصناف المراد حفظها" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else if (quantities.Count <1)
            {
                MessageBox.Show("الرجاء إضافة الكميات المطبوعة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            if  (string.IsNullOrEmpty(printers_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم المطبعة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            } else if (string.IsNullOrEmpty(printing_permission_number.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم المطبعة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            else if (string.IsNullOrEmpty(printing_permission_number.Text))
            {
                MessageBox.Show("الرجاء إختيار إذن خروج من المطبعة ");
            }else 
            {
                //MessageBox.Show("safe to save");

                loadallspecifications();
                long sp_id =  check_where_specification_exists_or_not();
                if (sp_id == 0)
                {
                    sp_id = saveprintedmaterialspecification();
                    saveprintedmaterialquantity(sp_id);
                }
                else
                {
                    updatespecificationvalues(sp_id);
                    saveprintedmaterialquantity(sp_id);

                }
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
                    string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS WHERE(SH_CLIENT_ID = @CLIENT_ID)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        //getting products data
                        products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString() , SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()) ,  SH_PRINTING_TYPE  = reader["SH_PRINTING_TYPE"].ToString() , SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString() , SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });


                    }

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
            //gettingproductsbyclientid();
            fillproductscombobox();
        }

        private void add_new_product_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {

            }else
            {
                using (addnewclientproduct myform = new addnewclientproduct(clients[clients_combo_box.SelectedIndex]))
                {
                    myform.ShowDialog();
                }
            }
        }


        void fillclientproductsgridview()
        {
            client_products_grid_view.Rows.Clear();
            if (client_products.Count > 0)
            {
                for (int i = 0; i < client_products.Count; i++)
                {
                    client_products_grid_view.Rows.Add(new string[] { (i+1).ToString() , client_products[i].SH_CLIENT_NAME , client_products[i].SH_CLIENT_PRODUCT_NAME , client_products[i].SH_NO_BOTTLES_PER_SHEET.ToString() });
                }
            }
        }
        bool check_if_client_product_is_exists_or_not()
        {
            if (client_products.Count > 0)
            {
                for (int i = 0; i < client_products.Count; i++)
                {
                  //  MessageBox.Show(i.ToString());
                    if ((string.Compare(client_products[i].SH_CLIENT_PRODUCT_NAME, client_products_combo_box.Text) == 0) && (string.Compare(client_products[i].SH_CLIENT_NAME, clients_combo_box.Text) == 0) && (client_products[i].SH_NO_BOTTLES_PER_SHEET == long.Parse(no_bottels_per_sheet.Text)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void add_new_client_product_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم العميل" , "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else if (string.IsNullOrEmpty(client_products_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrEmpty(no_bottels_per_sheet.Text))
            {
                MessageBox.Show("الرجاء إدخال قيمة عدد العلب" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else
            {
                if (check_if_client_product_is_exists_or_not())
                {
                    MessageBox.Show("هذا الصنف موجود من قبل"  , "خطأ"  , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }else
                {
                    client_products.Add(new SH_PRODUCT_OF_CLIENTS_PARCELS() { SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID, SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME, SH_NO_BOTTLES_PER_SHEET = long.Parse(no_bottels_per_sheet.Text) ,SH_CLIENT_PRODUCT_ID = products[client_products_combo_box.SelectedIndex].SH_ID, SH_CLIENT_PRODUCT_NAME = products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME });
                    total_number_of_bottel_per_sheet += long.Parse(no_bottels_per_sheet.Text);
                    total_number_of_bottels_per_sheet.Text = total_number_of_bottel_per_sheet.ToString();
                    fillclientproductsgridview();
                }
            }
        }

        private void client_products_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
           // fillproductscombobox();
        }

        private void remove_client_product_Click(object sender, EventArgs e)
        {
            //if (client_products.Count > 0)
            //{
                if (client_products_grid_view.SelectedRows.Count > 0)
                {
                    total_number_of_bottel_per_sheet -= client_products[client_products_grid_view.SelectedRows[0].Index].SH_NO_BOTTLES_PER_SHEET;
                    client_products.Remove(client_products[client_products_grid_view.SelectedRows[0].Index]);
                fillclientproductsgridview();
            } else
                {
                    MessageBox.Show("لا بد من تحديد الصنف المراد مسحة ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
                }
            //}
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void client_products_combo_box_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
        void competecode()
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text) || string.IsNullOrWhiteSpace(item_type_combo_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text))
            {

            }
            else
            {
                item_code_text_box.Text = item_type_combo_box.Text + removedotinnumber(double.Parse(item_thickness_text_box.Text)) + removedotinnumber(double.Parse(item_width_text_box.Text)) + removedotinnumber(double.Parse(item_length_text_box.Text));
            }
        }
        private void addnewprintingmaterialfd_Activated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {

            }
            else
            {
                fillproductscombobox();
            }
        }

        private void item_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_type_combo_box.Text))
            {

            }else
            {
                competecode();
            }
        }

        private void item_thickness_text_box_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {

            }
            else
            {
                double num = double.Parse(item_thickness_text_box.Text);
                item_thickness_text_box.Text = num.ToString();
            }
        }
    }
}
