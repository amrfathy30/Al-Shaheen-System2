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
    public partial class addnewmuranmaterialfd : Form
    {
        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();
        List<SH_FACE_COLOR> FACES = new List<SH_FACE_COLOR>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_QUANTITY_OF_MURAN_MATERIAL> quantities = new List<SH_QUANTITY_OF_MURAN_MATERIAL>();
        List<SH_MURAN_MATERIAL_PARCEL> muran_material_parcels = new List<SH_MURAN_MATERIAL_PARCEL>();
        List<SH_SPECIFICATION_OF_MURAN_MATERIAL> muran_materials = new List<SH_SPECIFICATION_OF_MURAN_MATERIAL>();
        List<SH_TIN_PRINTER> printers = new List<SH_TIN_PRINTER>();

        double total_no_packges = 0;
        long all_packages_no_sheets = 0;
        double all_packages_gross_weight = 0;
        double all_packages_net_weight = 0;
        //double all_first_face_net_weight = 0;
        //double all_second_face_net_weight = 0;
        public addnewmuranmaterialfd()
        {
            InitializeComponent();
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



        void loadaallsizes()
        {
            sizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(), SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(), SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }
        void fillsizesgridview()
        {
            loadaallsizes();
            sizes_combo_box.Items.Clear();
            if (sizes.Count > 0)
            {
                string sectext = "";
                for (int i = 0; i < sizes.Count; i++)
                {
                    if (string.Compare(sizes[i].SH_SIZE_SECOND_DIAMETER_NAME, "D2") == 0)
                    {
                        sectext = " ";
                    }
                    else
                    {
                        sectext = sizes[i].SH_SIZE_SECOND_DIAMETER_NAME;
                    }
                    sizes_combo_box.Items.Add(sizes[i].SH_SIZE_NAME);
                }
            }
        }

        long addrewmuranspecification()
        {          
            try
            {
                string query = "INSERT INTO SH_SPECIFICATION_OF_MURAN_MATERIAL ";
                query += "(SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_TYPE, SH_ITEM_NAME, SH_ITEM_CODE, SH_ITEM_INTENSITY, SH_ITEM_TOTAL_NUMBER_OF_PACKAGES, ";
                query += " SH_ITEM_TOTAL_NUMBER_OF_SHEETS, SH_ADDITION_DATE, SH_TOTAL_NET_RAW_MATERIAL_WEIGHT, SH_TOTAL_GROSS_RAW_MATERIAL_WEIGHT, SH_ITEM_FIRST_FACE, SH_ITEM_SECOND_FACE, ";
                query += "  SH_MURAN_TYPE , SH_BOTTLE_CAPACITY ";
                query += " , SH_BOTTLE_HEIGHT ,SH_SIZE_ID ,SH_SIZE_NAME) ";
                query += " VALUES(@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_TYPE,@SH_ITEM_NAME";
                query += ",@SH_ITEM_CODE,@SH_ITEM_INTENSITY,@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES,@SH_ITEM_TOTAL_NUMBER_OF_SHEETS,@SH_ADDITION_DATE,@SH_TOTAL_NET_RAW_MATERIAL_WEIGHT";
                query += ",@SH_TOTAL_GROSS_RAW_MATERIAL_WEIGHT,@SH_ITEM_FIRST_FACE,@SH_ITEM_SECOND_FACE,@SH_MURAN_TYPE";
                query += ",@SH_BOTTLE_CAPACITY";
                query += ",@SH_BOTTLE_HEIGHT , @SH_SIZE_ID , @SH_SIZE_NAME)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text) );
                cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", double.Parse(item_width_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", double.Parse(item_thickness_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_combo_box.Text );
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح" );
                cmd.Parameters.AddWithValue("@SH_ITEM_CODE", item_code_text_box.Text );
                cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY",double.Parse(item_intensity_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES", total_no_packges);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", all_packages_no_sheets);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NET_RAW_MATERIAL_WEIGHT", all_packages_net_weight );
                cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_RAW_MATERIAL_WEIGHT", all_packages_gross_weight);
                cmd.Parameters.AddWithValue("@SH_ITEM_FIRST_FACE", first_face_combo_box.Text );
                cmd.Parameters.AddWithValue("@SH_ITEM_SECOND_FACE", second_face_combo_box.Text );              
                cmd.Parameters.AddWithValue("@SH_MURAN_TYPE", getmurantype() );              
                cmd.Parameters.AddWithValue("@SH_BOTTLE_HEIGHT", double.Parse(height_text_box.Text) );
                cmd.Parameters.AddWithValue("@SH_BOTTLE_CAPACITY", capacity_tect_box.Text );
                cmd.Parameters.AddWithValue("@SH_SIZE_ID",sizes[sizes_combo_box.SelectedIndex].SH_ID );
                cmd.Parameters.AddWithValue("@SH_SIZE_NAME" , sizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME);             
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING SPECIFICATION TO DB "+ex.ToString());
            }
            return 0;
        }


      

        void loadmuranmaterials()
        {
            muran_materials.Clear();
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_MURAN_MATERIAL";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    muran_materials.Add(new SH_SPECIFICATION_OF_MURAN_MATERIAL() { SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()),SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()) , SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()) , SH_BOTTLE_CAPACITY = reader["SH_BOTTLE_CAPACITY"].ToString() , SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()) ,  SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString() , SH_ITEM_FIRST_FACE = reader["SH_ITEM_FIRST_FACE"].ToString() , SH_ITEM_SECOND_FACE = reader["SH_ITEM_SECOND_FACE"].ToString() , SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString() , SH_MURAN_TYPE = reader["SH_MURAN_TYPE"].ToString() , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString()  , SH_ID = long.Parse(reader["SH_ID"].ToString())   });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL MURAN TIN INFORMATION "+ex.ToString());
            }  
        }

       

        string getmurantype()
        {
            string murantype = null;
            if (body_radio_btn.Checked)
            {
                murantype = body_radio_btn.Text;
            }
            else if (bottom_radio_btn.Checked)
            {
                murantype = bottom_radio_btn.Text;
            }

            return murantype;
        }


        long check_is_muran_material_exists_or_not()
        {
            loadmuranmaterials();

            
            


            // MessageBox.Show(muran_materials.Count.ToString());
            if (muran_materials.Count > 0)
            {
                for (int i = 0; i < muran_materials.Count; i++)
                {
                    if ((muran_materials[i].SH_ITEM_LENGTH == double.Parse(item_length_text_box.Text)) && (muran_materials[i].SH_ITEM_WIDTH == double.Parse(item_width_text_box.Text)) && (muran_materials[i].SH_ITEM_THICKNESS == double.Parse(item_thickness_text_box.Text)) && (string.Compare(muran_materials[i].SH_ITEM_CODE , item_code_text_box.Text)==0) && (string.Compare(muran_materials[i].SH_ITEM_TYPE, item_type_combo_box.Text)==0) && (string.Compare(muran_materials[i].SH_MURAN_TYPE, getmurantype())==0) && (muran_materials[i].SH_SIZE_ID == sizes[sizes_combo_box.SelectedIndex].SH_ID))
                    {

                        return muran_materials[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        void updatemuranspecification(long muran_sp_id)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_MURAN_MATERIAL ";
                       query += " SET SH_ITEM_TOTAL_NUMBER_OF_PACKAGES =@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES ,";
                query += "SH_ITEM_TOTAL_NUMBER_OF_SHEETS = @SH_ITEM_TOTAL_NUMBER_OF_SHEETS, ";
                query += "SH_TOTAL_NET_RAW_MATERIAL_WEIGHT = @SH_TOTAL_NET_RAW_MATERIAL_WEIGHT,";
                query += "SH_TOTAL_GROSS_RAW_MATERIAL_WEIGHT = @SH_TOTAL_GROSS_RAW_MATERIAL_WEIGHT WHERE(SH_ID = @sh_id)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES" , total_no_packges);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", all_packages_no_sheets);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NET_RAW_MATERIAL_WEIGHT", all_packages_net_weight);
                cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_RAW_MATERIAL_WEIGHT",all_packages_gross_weight);
                cmd.Parameters.AddWithValue("@sh_id",muran_sp_id);
                cmd.ExecuteNonQuery();        
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE UPDATING MURAN MATERIAL QUANTITIES");
            }

        }
        double getpackagenetweight()
        {
           return double.Parse(item_sheet_weight_text_box.Text)*long.Parse(no_sheets_per_package_text_box.Text);
        }
        void savenewquantityofmurantin(long muran_sp_id)
        {

            if (quantities.Count > 0)
            {
                for (int i = 0; i < quantities.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_QUANTITY_OF_MURAN_MATERIAL ";
                        query += "(SH_SPECIFICATION_OF_MURAN_MATERIAL_ID, SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_TYPE, SH_ITEM_NAME, SH_ITEM_CODE, SH_ITEM_INTENSITY,";
                        query += "SH_ITEM_SHEET_WEIGHT, SH_ITEM_PACKAGE_NET_WEIGHT, SH_ITEM_NUMBER_OF_PACKAGES, SH_ITEM_TOTAL_NUMBER_OF_SHEETS, SH_QUANTITY_NET_WEIGHT, SH_QUANTITY_GROSS_WEIGHT,";
                        query += "SH_PACKAGE_GROSS_WEIGHT, SH_CLIENT_NAME, SH_STOCK_NAME, SH_ITEM_FIRST_FACE, SH_ITEM_SECOND_FACE, SH_MURAN_TYPE,";
                        query += " SH_BOTTLE_CAPACITY";
                        query += ", SH_BOTTLE_HEIGHT , SH_SIZE_ID , SH_SIZE_NAME ) VALUES( @SH_SPECIFICATION_OF_MURAN_MATERIAL_ID , @SH_ITEM_LENGTH , @SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_TYPE,@SH_ITEM_NAME,@SH_ITEM_CODE,@SH_ITEM_INTENSITY";
                        query += ",@SH_ITEM_SHEET_WEIGHT,@SH_ITEM_PACKAGE_NET_WEIGHT,@SH_ITEM_NUMBER_OF_PACKAGES,@SH_ITEM_TOTAL_NUMBER_OF_SHEETS,@SH_QUANTITY_NET_WEIGHT,@SH_QUANTITY_GROSS_WEIGHT";
                        query += ",@SH_PACKAGE_GROSS_WEIGHT,@SH_CLIENT_NAME,@SH_STOCK_NAME,@SH_ITEM_FIRST_FACE,@SH_ITEM_SECOND_FACE,@SH_MURAN_TYPE";
                        query += ",@SH_BOTTLE_CAPACITY, @SH_BOTTLE_HEIGHT  , @SH_SIZE_ID , @SH_SIZE_NAME)";
                        query += "SELECT SCOPE_IDENTITY() AS myidentity";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_MURAN_MATERIAL_ID", muran_sp_id);
                        cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", quantities[i].SH_ITEM_LENGTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", quantities[i].SH_ITEM_WIDTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", quantities[i].SH_ITEM_THICKNESS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", quantities[i].SH_ITEM_TYPE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                        cmd.Parameters.AddWithValue("@SH_ITEM_CODE", quantities[i].SH_ITEM_CODE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY",   quantities[i].SH_ITEM_INTENSITY);
                        cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", quantities[i].SH_ITEM_SHEET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_PACKAGE_NET_WEIGHT", quantities[i].SH_ITEM_PARCEL_NET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NUMBER_OF_PACKAGES",quantities[i].SH_ITEM_NUMBER_OF_PACKAGES );
                        cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS" , quantities[i].SH_ITEM_TOTAL_NUMBER_OF_SHEETS);
                        cmd.Parameters.AddWithValue("@SH_QUANTITY_NET_WEIGHT" , quantities[i].SH_QUANTITY_NET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_QUANTITY_GROSS_WEIGHT" , 0);
                        cmd.Parameters.AddWithValue("@SH_PACKAGE_GROSS_WEIGHT" , 0);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME" , quantities[i].SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , quantities[i].SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_ITEM_FIRST_FACE", quantities[i].SH_ITEM_FIRST_FACE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_SECOND_FACE", quantities[i].SH_ITEM_SECOND_FACE);
                        cmd.Parameters.AddWithValue("@SH_MURAN_TYPE" , quantities[i].SH_MURAN_TYPE);
                        cmd.Parameters.AddWithValue("@SH_BOTTLE_HEIGHT" , quantities[i].SH_BOTTLE_HEIGHT);
                        cmd.Parameters.AddWithValue("@SH_BOTTLE_CAPACITY" , quantities[i].SH_BOTTLE_CAPACITY);
                        cmd.Parameters.AddWithValue("@SH_SIZE_ID", quantities[i].SH_SIZE_ID);
                        cmd.Parameters.AddWithValue("@SH_SIZE_NAME" , quantities[i].SH_SIZE_NAME);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            long q_id =  long.Parse(reader["myidentity"].ToString());
                            savemurantinparcel(muran_sp_id, q_id , quantities[i].SH_ITEM_NUMBER_OF_PACKAGES , quantities[i]);
                        }
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING QUANTITIES" +ex.ToString());
                    }
                }
                MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }

        }

        void savemurantinparcel(long sp_id , long quantity_id , long no_parcels , SH_QUANTITY_OF_MURAN_MATERIAL myquantity)
        {
            if (no_parcels <= 0)
            {

            }
            else
            {
                for (int i = 0; i < no_parcels; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_MURAN_MATERIAL_PARCEL ";
                        query += "(SH_SPECIFICATION_OF_MURAN_MATERIAL_ID, SH_QUANTITY_OF_MURAN_MATERIAL_ID, SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_TYPE, SH_ITEM_NAME, SH_ITEM_CODE, ";
                        query += " SH_ITEM_RAW_MATERIAL_SHEET_WEIGHT, SH_ITEM_NUMBER_OF_SHEETS, SH_ITEM_PACKAGE_RAW_NET_WEIGHT, SH_ITEM_NET_WEIGHT, SH_ITEM_PACKAGE_GROSS_WEIGHT, SH_CLIENT_NAME,";
                        query += " SH_STOCK_NAME, SH_ITEM_FIRST_FACE, SH_ITEM_SECOND_FACE, SH_MURAN_TYPE,  SH_BOTTLE_CAPACITY ";
                        query += " ,   SH_BOTTLE_HEIGHT, SH_ITEM_PARCEL_NUMBER , SH_SIZE_ID , SH_SIZE_NAME)";
                        query += " VALUES(@SH_SPECIFICATION_OF_MURAN_MATERIAL_ID,@SH_QUANTITY_OF_MURAN_MATERIAL_ID,@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_TYPE,@SH_ITEM_NAME,@SH_ITEM_CODE,";
                        query += "@SH_ITEM_RAW_MATERIAL_SHEET_WEIGHT,@SH_ITEM_NUMBER_OF_SHEETS,@SH_ITEM_PACKAGE_RAW_NET_WEIGHT,@SH_ITEM_NET_WEIGHT,@SH_ITEM_PACKAGE_GROSS_WEIGHT,@SH_CLIENT_NAME,@SH_STOCK_NAME";
                        query += ",@SH_ITEM_FIRST_FACE,@SH_ITEM_SECOND_FACE,@SH_MURAN_TYPE,@SH_BOTTLE_CAPACITY ";
                        query += ",@SH_BOTTLE_HEIGHT,@SH_ITEM_PARCEL_NUMBER , @SH_SIZE_ID , @SH_SIZE_NAME )";

                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_MURAN_MATERIAL_ID", sp_id);
                        cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_MURAN_MATERIAL_ID", quantity_id);
                        cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", myquantity.SH_ITEM_LENGTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", myquantity.SH_ITEM_WIDTH);
                        cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", myquantity.SH_ITEM_THICKNESS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", myquantity.SH_ITEM_TYPE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                        cmd.Parameters.AddWithValue("@SH_ITEM_CODE", myquantity.SH_ITEM_CODE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_RAW_MATERIAL_SHEET_WEIGHT", myquantity.SH_ITEM_SHEET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NUMBER_OF_SHEETS", myquantity.SH_PARCELS_NO_SHEETS);
                        cmd.Parameters.AddWithValue("@SH_ITEM_PACKAGE_RAW_NET_WEIGHT", myquantity.SH_ITEM_PARCEL_NET_WEIGHT);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NET_WEIGHT", 0);
                        cmd.Parameters.AddWithValue("@SH_ITEM_PACKAGE_GROSS_WEIGHT", 0);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", myquantity.SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME", myquantity.SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_ITEM_FIRST_FACE", myquantity.SH_ITEM_FIRST_FACE);
                        cmd.Parameters.AddWithValue("@SH_ITEM_SECOND_FACE", myquantity.SH_ITEM_SECOND_FACE);
                        cmd.Parameters.AddWithValue("@SH_MURAN_TYPE", myquantity.SH_MURAN_TYPE);
                        cmd.Parameters.AddWithValue("@SH_BOTTLE_CAPACITY" , myquantity.SH_BOTTLE_CAPACITY);
                        cmd.Parameters.AddWithValue("@SH_BOTTLE_HEIGHT", 0);
                        cmd.Parameters.AddWithValue("@SH_ITEM_PARCEL_NUMBER", DateTime.Now.Year);
                        cmd.Parameters.AddWithValue("@SH_SIZE_ID" , myquantity.SH_SIZE_ID);
                        cmd.Parameters.AddWithValue("@SH_SIZE_NAME" , myquantity.SH_SIZE_NAME);
                        cmd.ExecuteNonQuery();

                        myconnection.closeConnection();
                    }catch(Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING PARCELS" + ex.ToString());
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

        void loadallfacecolors()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_FACE_COLORS", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    FACES.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACES "+ex.ToString());
            }
        }

        void fillfacescombobox()
        {

            FACES.Clear();
            first_face_combo_box.Items.Clear();
            second_face_combo_box.Items.Clear();
            loadallfacecolors();
            if (FACES.Count <=0 )
            {

            }else
            {
                for (int i = 0; i < FACES.Count; i++)
                {
                    first_face_combo_box.Items.Add(FACES[i].SH_FACE_COLOR_NAME);
                    second_face_combo_box.Items.Add(FACES[i].SH_FACE_COLOR_NAME);
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
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() , SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString() ,SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString()});
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB"+ex.ToString());
            }
        }

        void fill_clients_combo_box ()
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
            fillprintersgridview();
            fillstockscombobox();
            fill_clients_combo_box();
            fillfacescombobox();
            fillsizesgridview();
            item_intensity_text_box.Text = 7.85.ToString();
            //item_temper_combo_box.SelectedIndex = 0;
            // item_type_combo_box.SelectedIndex = 0;
            //stock_name_combo_box.SelectedIndex = 0;
           // item_finish_combo_box.SelectedIndex = 0;
            //bottom_radio_btn.Checked = true;
            //shape_circle_radio_btn.Checked = true;
            item_total_number_of_packages.Text = "0";
            parcel_net_weight.Text = "0.00";
            total_net_weight.Text = "0.00";
           // total_gross_weight.Text = "0.00";
            item_sheet_weight_text_box.Text = "0.00";
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

        private void item_coating_text_box_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(item_coating_text_box.Text))
            //{
            //    errorProvider1.SetError(item_coating_text_box, "إدخل ال Coating  بشكل صحيح");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        private void first_face_text_box_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(first_face_text_box.Text))
            //{
            //    errorProvider1.SetError(first_face_text_box, "الرجاء إدخال معلومات الوجة الاول");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        private void sh_first_face_grams_per_meter_text_box_TextChanged(object sender, EventArgs e)
        {
            //double mygross = 0;
            //if (!double.TryParse(sh_first_face_grams_per_meter_text_box.Text, out mygross))
            //{
            //    errorProvider1.SetError(sh_first_face_grams_per_meter_text_box, "ادخل وزن الطلاء للمتر بالجرامات بصورة ارقام 12.012");
            //}
            //else
            //{
            //    errorProvider1.Clear();

            //}
        }

        private void second_face_text_box_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(second_face_text_box.Text))
            //{
            //    errorProvider1.SetError(second_face_text_box, "الرجاء إدخال معلومات الوجة الثانى");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void no_packages_text_box_TextChanged(object sender, EventArgs e)
        {
            long mygross = 0;
            if (!long.TryParse(no_packages_text_box.Text, out mygross))
            {
                errorProvider1.SetError(no_packages_text_box, " 123 ادخل الوزن القائم بصورة ارقام");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

       
        private void capacity_radio_btn_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(capacity_tect_box.Text, out mygross))
            {
                errorProvider1.SetError(capacity_tect_box, "ادخل السعة بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();

            }
        }

        private void height_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(height_text_box.Text, out mygross))
            {
                errorProvider1.SetError(height_text_box, "ادخل الارتفاع بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();

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
                item_quantities_grid_view.Rows.Add(new string[] { (i + 1).ToString(), quantities[i].SH_ITEM_NUMBER_OF_PACKAGES.ToString(), quantities[i].SH_ITEM_TOTAL_NUMBER_OF_SHEETS.ToString() , quantities[i].SH_PARCELS_NO_SHEETS.ToString() , quantities[i].SH_ITEM_PARCEL_NET_WEIGHT.ToString() , quantities[i].SH_QUANTITY_NET_WEIGHT.ToString() });
            }
        }

        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(first_face_combo_box.Text)|| string.IsNullOrEmpty(second_face_combo_box.Text) || string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text) || string.IsNullOrEmpty(item_type_combo_box.Text) || string.IsNullOrEmpty(stock_name_combo_box.Text) || sizes.Count == 0 || string.IsNullOrEmpty(sizes_combo_box.Text)   )
            {
                //DO NOTHING
                MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if ((errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == ""))
            {
                item_code_text_box.Text = item_type_combo_box.Text+removedotinnumber(double.Parse(item_thickness_text_box.Text)) + removedotinnumber(double.Parse(item_width_text_box.Text)) + removedotinnumber(double.Parse(item_length_text_box.Text));
                item_sheet_weight_text_box.Text = ((double.Parse(item_length_text_box.Text) * double.Parse(item_width_text_box.Text) * double.Parse(item_thickness_text_box.Text) / 1000000) * double.Parse(item_intensity_text_box.Text)).ToString();

                if (string.IsNullOrWhiteSpace(no_packages_text_box.Text) || string.IsNullOrWhiteSpace(no_sheets_per_package_text_box.Text) )
                {
                    MessageBox.Show("لا يمكن إضافة فراغات من الكمية  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (errorProvider1.GetError(no_packages_text_box) != "" || errorProvider1.GetError(no_sheets_per_package_text_box) != "")
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    bool addornot = true;
                    if (string.IsNullOrEmpty(item_length_text_box.Text) || string.IsNullOrEmpty(item_width_text_box.Text) || string.IsNullOrEmpty(item_type_combo_box.Text) || string.IsNullOrEmpty(item_thickness_text_box.Text)  || string.IsNullOrEmpty(height_text_box.Text) || string.IsNullOrEmpty(capacity_tect_box.Text))
                    {
                        addornot = false;
                    }
                    else
                    {
                        if (body_radio_btn.Checked || bottom_radio_btn.Checked)
                            {

                            }
                            else
                            {
                                addornot = false;
                            }

                            
                    }
                    if (addornot)
                    {
                        
                        string myclient = "";
                        if (string.IsNullOrEmpty(clients_combo_box.Text))
                        {
                            myclient = "عام";
                        }
                        else
                        {
                            myclient = clients_combo_box.Text;
                        }
                        quantity_net_weight.Text = (long.Parse(no_packages_text_box.Text) * long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();
                        parcel_net_weight.Text = (long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();

                        //  MessageBox.Show(getmurantype() + " ,  SHAPE : "+getshapetype() +" , TYPE : "+ item_type_combo_box.Text);
                        quantities.Add(new SH_QUANTITY_OF_MURAN_MATERIAL { SH_ITEM_TYPE = item_type_combo_box.Text, SH_ITEM_SHEET_WEIGHT = double.Parse(item_sheet_weight_text_box.Text), SH_QUANTITY_NET_WEIGHT = double.Parse(quantity_net_weight.Text), SH_MURAN_TYPE = getmurantype(),  SH_ITEM_FIRST_FACE = first_face_combo_box.Text, SH_ITEM_SECOND_FACE = second_face_combo_box.Text, SH_ITEM_LENGTH = double.Parse(item_length_text_box.Text), SH_ITEM_WIDTH = double.Parse(item_width_text_box.Text), SH_ITEM_THICKNESS = double.Parse(item_thickness_text_box.Text), SH_ITEM_CODE = item_code_text_box.Text, SH_BOTTLE_CAPACITY = capacity_tect_box.Text, SH_BOTTLE_HEIGHT = 0, SH_CLIENT_NAME = myclient,  SH_ITEM_NUMBER_OF_PACKAGES = long.Parse(no_packages_text_box.Text), SH_ITEM_TOTAL_NUMBER_OF_SHEETS = long.Parse(no_sheets_per_package_text_box.Text) * long.Parse(no_packages_text_box.Text), SH_PARCELS_NO_SHEETS = long.Parse(no_sheets_per_package_text_box.Text), SH_ITEM_PACKAGE_NET_WEIGHT = double.Parse(parcel_net_weight.Text), SH_STOCK_NAME = stock_name_combo_box.Text, SH_ITEM_PARCEL_NET_WEIGHT = double.Parse(parcel_net_weight.Text), SH_ITEM_INTENSITY = 7.85 , SH_SIZE_ID  = sizes[sizes_combo_box.SelectedIndex].SH_ID , SH_SIZE_NAME = sizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME });
                        all_packages_no_sheets += long.Parse(no_sheets_per_package_text_box.Text) * long.Parse(no_packages_text_box.Text);
                        total_no_packges += long.Parse(no_packages_text_box.Text);
                        all_packages_net_weight += double.Parse(quantity_net_weight.Text);
                        total_net_weight.Text = all_packages_net_weight.ToString();
                        item_total_number_of_packages.Text = total_no_packges.ToString();
                        // all_packages_net_weight
                        no_packages_text_box.Text = "";
                        no_sheets_per_package_text_box.Text = "";

                        fillgridviewitems();
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
            //check fields there is adata or not 
            bool saveornot = true;
            if (string.IsNullOrEmpty(item_length_text_box.Text) || string.IsNullOrEmpty(item_width_text_box.Text) || string.IsNullOrEmpty(item_type_combo_box.Text) || string.IsNullOrEmpty(item_thickness_text_box.Text) || string.IsNullOrEmpty(height_text_box.Text) || string.IsNullOrEmpty(capacity_tect_box.Text))
            {
                saveornot = false;
            }
            else
            {
                
                    if (body_radio_btn.Checked || bottom_radio_btn.Checked)
                    {
                          
                    }else
                    {
                        saveornot = false;
                    }
     
            }
            if (saveornot && quantities.Count >0)
            {
                //MessageBox.Show("Safe to Save");
                long sp_id = check_is_muran_material_exists_or_not();
                if (sp_id == 0)
                {
                    //savenewdpecification
                    sp_id = addrewmuranspecification();
                    savenewquantityofmurantin(sp_id);
                    //saveallparcels

                }
                else
                {
                    updatemuranspecification(sp_id);
                    savenewquantityofmurantin(sp_id);
                    //saveallparcels
                }
            }
            else
            {
                MessageBox.Show("لا يمكن الحفظ" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);

            }
           
            //check for existance
            // if exist update quantity 
            //add new record 

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

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
