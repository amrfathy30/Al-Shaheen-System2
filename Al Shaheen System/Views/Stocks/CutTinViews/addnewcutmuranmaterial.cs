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
    public partial class addnewcutmuranmaterial : Form
    {
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_SHAHEEN_CUTTERS> cutters = new List<SH_SHAHEEN_CUTTERS>();
        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();
        List<SH_PALLETS_OF_CUT_MURAN_MATERIAL> pallets = new List<SH_PALLETS_OF_CUT_MURAN_MATERIAL>();
        List<SH_QUANTITIES_OF_CUT_MURAN_MATERIAL> quantites = new List<SH_QUANTITIES_OF_CUT_MURAN_MATERIAL>();
        List<SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL> specifications = new List<SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL>();
        


        long total_number_of_bottels = 0;
        long total_number_of_pallets = 0;
        long quantity_no_of_pallets = 0;
        long quantity_no_of_bottels = 0;

        public addnewcutmuranmaterial()
        {
            InitializeComponent();
        }
        void loadcutmuranspecifications()
        {
            specifications.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL" , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CAPACITY = double.Parse(reader["SH_CAPACITY"].ToString()) , SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString() ,  SH_FIRST_FACE = reader["SH_FIRST_FACE"].ToString() , SH_HEIGHT = double.Parse(reader["SH_HEIGHT"].ToString()) , SH_MURAN_TYPE = reader["SH_MURAN_TYPE"].ToString() , SH_SECOND_FACE = reader["SH_SECOND_FACE"].ToString() , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString() ) , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString()  });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CUT MURAN SPECIFICATIONS "+ex.ToString());
            }

        }
        long savenewspecification(SH_QUANTITIES_OF_CUT_MURAN_MATERIAL myquantity)
        {
            try
            {
                string query = "INSERT INTO SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL";
                query += "(SH_CLIENT_ID, SH_CLIENT_NAME, SH_FIRST_FACE, SH_SECOND_FACE, SH_MURAN_TYPE, ";
                query += "   SH_HEIGHT, SH_CAPACITY, SH_TOTAL_NO_BOTTELS, SH_TOTAL_NO_PALLETS ,SH_SIZE_ID ,SH_SIZE_NAME ) ";
                query += " VALUES(@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_FIRST_FACE,@SH_SECOND_FACE,@SH_MURAN_TYPE";
                query += ",";
                query += "@SH_HEIGHT,@SH_CAPACITY,@SH_TOTAL_NO_BOTTELS,@SH_TOTAL_NO_PALLETS , @SH_SIZE_ID , @SH_SIZE_NAME)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", myquantity.q_pallets[0].SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", myquantity.q_pallets[0].SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_FIRST_FACE",myquantity.q_pallets[0].SH_FIRST_FACE);
                cmd.Parameters.AddWithValue("@SH_SECOND_FACE", myquantity.q_pallets[0].SH_SECOND_FACE);
                cmd.Parameters.AddWithValue("@SH_MURAN_TYPE",  myquantity.q_pallets[0].SH_MURAN_TYPE);
                cmd.Parameters.AddWithValue("SH_SIZE_ID", myquantity.q_pallets[0].SH_SIZE_ID);
                cmd.Parameters.AddWithValue("SH_SIZE_NAME", myquantity.q_pallets[0].SH_SIZE_NAME);
                cmd.Parameters.AddWithValue("@SH_HEIGHT", myquantity.q_pallets[0].SH_HEIGHT);
                cmd.Parameters.AddWithValue("@SH_CAPACITY", myquantity.q_pallets[0].SH_CAPACITY);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_BOTTELS" , myquantity.SH_TOTAL_NUMBER_OF_BOTTELS);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_PALLETS", myquantity.SH_TOTAL_NUMBER_OF_PALLETS);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return  long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING SPECIFICATION TO DB "+ex.ToString());
            }
            return 0;    
        }
        long check_if_exists_or_not(SH_QUANTITIES_OF_CUT_MURAN_MATERIAL myquantity)
        {
            if (specifications.Count > 0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if ((string.Compare(specifications[i].SH_CLIENT_NAME , myquantity.SH_CLIENT_NAME)==0)&&(specifications[i].SH_CAPACITY == myquantity.SH_CAPACITY)&&(string.Compare(specifications[i].SH_FIRST_FACE, myquantity.SH_FIRST_FACE)==0)&&(string.Compare(specifications[i].SH_MURAN_TYPE  , myquantity.SH_MURAN_TYPE)==0) &&(string.Compare(specifications[i].SH_SECOND_FACE , myquantity.SH_SECOND_FACE)==0) && (specifications[i].SH_SIZE_ID == myquantity.SH_SIZE_ID ))
                    {
                        return specifications[i].SH_ID;
                    }
                }

            }
            return 0;
        }

        void updatespecificationquantity(long sp_id,SH_QUANTITIES_OF_CUT_MURAN_MATERIAL myquantity)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL SET SH_TOTAL_NO_PALLETS = SH_TOTAL_NO_PALLETS + @SH_TOTAL_NO_PALLETS, SH_TOTAL_NO_BOTTELS = SH_TOTAL_NO_BOTTELS + @SH_TOTAL_NO_BOTTELS WHERE(SH_ID = @SH_ID)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query,DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_PALLETS" , myquantity.SH_TOTAL_NUMBER_OF_BOTTELS);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_BOTTELS", myquantity.SH_TOTAL_NUMBER_OF_BOTTELS);
                cmd.Parameters.AddWithValue("@SH_ID" , sp_id);
                cmd.ExecuteNonQuery();               
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING RECORDS "+ex.ToString());
            }
        }

        void savequantity(long sp_id ,    SH_QUANTITIES_OF_CUT_MURAN_MATERIAL myquantity)
        {
            try
            {
                string query = "INSERT INTO SH_QUANTITIES_OF_CUT_MURAN_MATERIAL ";
                query += "(SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID, SH_CLIENT_ID, SH_CLIENT_NAME, SH_MURAN_TYPE, SH_FIRST_FACE, SH_SECOND_FACE, SH_HEIGHT, SH_CAPACITY, SH_ADDITION_DATE,";
                query += " SH_ADDITION_PERMISSION_NUMBER, SH_CUTTER_ID, SH_CUTTER_NAME, SH_STOCK_ID, SH_STOCK_NAME, SH_CUTTER_TECHNICAL_MAN, SH_TOTAL_NUMBER_OF_BOTTELS, SH_TOTAL_NUMBER_OF_PALLETS,";
                query += " SH_SIZE_ID, SH_SIZE_NAME) ";
                query += " VALUES(@SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_MURAN_TYPE,@SH_FIRST_FACE";
                query += ",@SH_SECOND_FACE, @SH_HEIGHT, @SH_CAPACITY,@SH_ADDITION_DATE,@SH_ADDITION_PERMISSION_NUMBER,@SH_CUTTER_ID,@SH_CUTTER_NAME";
                query += ",@SH_STOCK_ID,@SH_STOCK_NAME,@SH_CUTTER_TECHNICAL_MAN,@SH_TOTAL_NUMBER_OF_BOTTELS,@SH_TOTAL_NUMBER_OF_PALLETS,@SH_SIZE_ID,@SH_SIZE_NAME)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , myquantity.q_pallets[0].SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", myquantity.q_pallets[0].SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_MURAN_TYPE", myquantity.q_pallets[0].SH_MURAN_TYPE);
                cmd.Parameters.AddWithValue("@SH_FIRST_FACE", myquantity.q_pallets[0].SH_FIRST_FACE);
                cmd.Parameters.AddWithValue("@SH_SECOND_FACE", myquantity.q_pallets[0].SH_SECOND_FACE);
                cmd.Parameters.AddWithValue("@SH_HEIGHT", myquantity.q_pallets[0].SH_HEIGHT);
                cmd.Parameters.AddWithValue("@SH_CAPACITY", myquantity.q_pallets[0].SH_CAPACITY);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", myquantity.q_pallets[0].SH_ADDTION_DATE);
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", myquantity.q_pallets[0].SH_ADDTION_PERMISSION_NUMBER);
                cmd.Parameters.AddWithValue("@SH_CUTTER_ID" ,myquantity.q_pallets[0].SH_CUTTER_ID);
                cmd.Parameters.AddWithValue("@SH_CUTTER_NAME", myquantity.q_pallets[0].SH_CUTTER_NAME);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", myquantity.q_pallets[0].SH_STOCK_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , myquantity.q_pallets[0].SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_CUTTER_TECHNICAL_MAN" , myquantity.q_pallets[0].SH_CUTTER_TECHNICAL_MAN);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS", myquantity.SH_TOTAL_NUMBER_OF_BOTTELS);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLETS", myquantity.SH_TOTAL_NUMBER_OF_PALLETS);
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", myquantity.q_pallets[0].SH_SIZE_ID);
                cmd.Parameters.AddWithValue("@SH_SIZE_NAME", myquantity.q_pallets[0].SH_SIZE_NAME);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    long q_id = long.Parse(reader["myidentity"].ToString());
                    saveparcels(sp_id , q_id , myquantity.q_pallets);
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SACING CUT MURAN QUANTITIES "+ex.ToString());
            }
        }

        void saveparcels(long sp_id , long qu_id , List<SH_PALLETS_OF_CUT_MURAN_MATERIAL> p_pallets)
        {
            if (p_pallets.Count > 0)
            {
                for (int i = 0; i < p_pallets.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_PALLETS_OF_CUT_MURAN_MATERIAL ";
                        query += "(SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID, SH_QUANTITIES_OF_CUT_MURAN_MATERIAL_ID, SH_CLIENT_ID, SH_CLIENT_NAME, SH_FIRST_FACE, SH_MURAN_TYPE, SH_SECOND_FACE, SH_HEIGHT, ";
                        query += " SH_CAPACITY, SH_ADDITION_DATE, SH_ADDITION_PERMISSION_NUMBER, SH_CUTTER_ID, SH_CUTTER_NAME, SH_CUTTER_TECHNICAL_MAN, SH_STOCK_ID, SH_STOCK_NAME, SH_NUMBER_OF_SEQUENCES,";
                        query += " SH_NUMBER_OF_BOTTELS_PER_SEQUENCE, SH_NUMBER_OF_BOTTELS_PER_PALLET, SH_SIZE_ID, SH_SIZE_NAME)";
                        query += " VALUES(@SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID,@SH_QUANTITIES_OF_CUT_MURAN_MATERIAL_ID,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_FIRST_FACE,@SH_MURAN_TYPE";
                        query += ",@SH_SECOND_FACE,@SH_HEIGHT,@SH_CAPACITY,@SH_ADDITION_DATE,@SH_ADDITION_PERMISSION_NUMBER,@SH_CUTTER_ID,@SH_CUTTER_NAME,@SH_CUTTER_TECHNICAL_MAN,@SH_STOCK_ID ";
                        query += ",@SH_STOCK_NAME,@SH_NUMBER_OF_SEQUENCES,@SH_NUMBER_OF_BOTTELS_PER_SEQUENCE,@SH_NUMBER_OF_BOTTELS_PER_PALLET,@SH_SIZE_ID,@SH_SIZE_NAME)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID", sp_id);
                        cmd.Parameters.AddWithValue("@SH_QUANTITIES_OF_CUT_MURAN_MATERIAL_ID", qu_id);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID", p_pallets[i].SH_CLIENT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME",p_pallets[i].SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_FIRST_FACE", p_pallets[i].SH_FIRST_FACE);
                        cmd.Parameters.AddWithValue("@SH_MURAN_TYPE", p_pallets[i].SH_MURAN_TYPE);
                        cmd.Parameters.AddWithValue("@SH_SECOND_FACE", p_pallets[i].SH_SECOND_FACE);
                        cmd.Parameters.AddWithValue("@SH_HEIGHT", p_pallets[i].SH_HEIGHT);
                        cmd.Parameters.AddWithValue("@SH_CAPACITY", p_pallets[i].SH_CAPACITY);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", p_pallets[i].SH_ADDTION_DATE);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", p_pallets[i].SH_ADDTION_PERMISSION_NUMBER);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_ID", p_pallets[i].SH_CUTTER_ID);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_NAME", p_pallets[i].SH_CUTTER_NAME);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_TECHNICAL_MAN", p_pallets[i].SH_CUTTER_TECHNICAL_MAN);
                        cmd.Parameters.AddWithValue("@SH_STOCK_ID", p_pallets[i].SH_STOCK_ID);
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME", p_pallets[i].SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_SEQUENCES", p_pallets[i].SH_NUMBER_OF_SEQUENCES);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_BOTTELS_PER_SEQUENCE", p_pallets[i].SH_NUMBER_OF_BOTTELS_PER_SEQUENCE);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_BOTTELS_PER_PALLET", p_pallets[i].SH_NUMBER_OF_BOTTELS_PER_PALLET);
                        cmd.Parameters.AddWithValue("@SH_SIZE_ID", p_pallets[i].SH_SIZE_ID);
                        cmd.Parameters.AddWithValue("@SH_SIZE_NAME", p_pallets[i].SH_SIZE_NAME);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING PARCEL DATA " + ex.ToString() );
                    }
                }
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
        void fillsizescombobox()
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
            else if (head_radio_btn.Checked)
            {
                murantype = head_radio_btn.Text;
            }else if (face_radio_btn.Checked)
            {
                murantype = face_radio_btn.Text;
            }

            return murantype;
        }
        void loadcuuttersdata()
        {
            cutters.Clear();
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_CUTTERS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cutters.Add(new SH_SHAHEEN_CUTTERS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CUTTER_NAME = reader["SH_CUTTER_NAME"].ToString(), SH_CUTTER_LOCATION_TEXT = reader["SH_CUTTER_LOCATION_TEXT"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW CUTTER" + ex.ToString());
            }
        }
        void fillcutterscombobox()
        {
            cutters_combo_box.Items.Clear();
            loadcuuttersdata();
            if (cutters.Count > 0)
            {
                for (int i = 0; i < cutters.Count; i++)
                {
                    cutters_combo_box.Items.Add(cutters[i].SH_CUTTER_NAME);
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
                    faces.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACES " + ex.ToString());
            }
        }
        void fillfacescombobox()
        {

            faces.Clear();
            first_face_combo_box.Items.Clear();
            second_face_combo_box.Items.Clear();
            loadallfacecolors();
            if (faces.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < faces.Count; i++)
                {
                    first_face_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                    second_face_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
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
        long calculatetotalnumberofbottelsperpallet()
        {
            if ((!string.IsNullOrEmpty(number_of_bottels_per_sequence_text_box.Text)) && (!string.IsNullOrEmpty(number_of_sequences_per_pallet_text_box.Text)))
            {
                return long.Parse(number_of_bottels_per_sequence_text_box.Text) * long.Parse(number_of_sequences_per_pallet_text_box.Text);
            }
            return 0;
        }
        long calculatequantitynumberofbottels()
        {
            if (((!string.IsNullOrEmpty(number_of_pallets_text_box.Text))))
            {
                return long.Parse(number_of_bottels_per_pallet_text_box.Text) * long.Parse(number_of_pallets_text_box.Text);
            }
            return 0;
        }
        private void number_of_sequences_per_pallet_text_box_TextChanged(object sender, EventArgs e)
        {
            long test_number = 0;
            if (!long.TryParse(number_of_sequences_per_pallet_text_box.Text, out test_number))
            {
                errorProvider1.SetError(number_of_sequences_per_pallet_text_box, "الرجاء إدخال رقم صحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                number_of_bottels_per_pallet_text_box.Text = calculatetotalnumberofbottelsperpallet().ToString();
                quantity_number_of_bottels.Text = calculatequantitynumberofbottels().ToString();
            }

        }
        private void number_of_bottels_per_sequence_text_box_TextChanged(object sender, EventArgs e)
        {
            long test_number = 0;
            if (!long.TryParse(number_of_bottels_per_sequence_text_box.Text, out test_number))
            {
                errorProvider1.SetError(number_of_bottels_per_sequence_text_box, "الرجاء إدخال رقم صحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                number_of_bottels_per_pallet_text_box.Text = calculatetotalnumberofbottelsperpallet().ToString();
                quantity_number_of_bottels.Text = calculatequantitynumberofbottels().ToString();
            }
        }
        private void number_of_pallets_text_box_TextChanged(object sender, EventArgs e)
        {
            long test_number = 0;
            if (!long.TryParse(number_of_pallets_text_box.Text, out test_number))
            {
                errorProvider1.SetError(number_of_pallets_text_box, "الرجاء إدخال رقم صحيح 123 ");
            }
            else
            {
                errorProvider1.Clear();
                number_of_bottels_per_pallet_text_box.Text = calculatetotalnumberofbottelsperpallet().ToString();
                quantity_number_of_bottels.Text = calculatequantitynumberofbottels().ToString();
            }
        }
        private void addnewcutmuranmaterial_Load(object sender, EventArgs e)
        {
            fillcutterscombobox();
            fillfacescombobox();
            fillstockscombobox();
            fill_clients_combo_box();
            fillsizescombobox();
        }
        void fillquantitesgridview()
        {
            cut_muran_quantities_grid_view.Rows.Clear();
            
            if (quantites.Count > 0)
            {
                for (int i = 0; i < quantites.Count; i++)
                {
                    
                    cut_muran_quantities_grid_view.Rows.Add(new string[] { (i + 1).ToString() , quantites[i].q_pallets[0].SH_CLIENT_NAME, quantites[i].q_pallets[0].SH_FIRST_FACE , quantites[i].q_pallets[0].SH_SECOND_FACE ,  quantites[i].q_pallets[0].SH_MURAN_TYPE  , quantites[i].SH_TOTAL_NUMBER_OF_PALLETS.ToString() ,   quantites[i].SH_TOTAL_NUMBER_OF_BOTTELS.ToString() });
                }
            }
        }
        private void add_new_quantity_to_adding_permission_Click(object sender, EventArgs e)
        {
            bool cansaveornot = true;
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(add_new_quantity_to_adding_permission.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(first_face_combo_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(second_face_combo_box.Text))
            {
                cansaveornot = false;
            }
            else if ((!head_radio_btn.Checked) && (!body_radio_btn.Checked)&&(!bottom_radio_btn.Checked)&&(!face_radio_btn.Checked))
            {
                cansaveornot = false;
            }
            
            else if (string.IsNullOrEmpty(stocks_combo_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(cutters_combo_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(cutter_technical_man.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(number_of_sequences_per_pallet_text_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(number_of_bottels_per_sequence_text_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(number_of_pallets_text_box.Text))
            {
                cansaveornot = false;
            }
           
            else if (string.IsNullOrEmpty(capacity_tect_box.Text))
            {
                cansaveornot = false;
            }
            else if (string.IsNullOrEmpty(height_text_box.Text))
            {
                cansaveornot = false;
            }else if (string.IsNullOrEmpty(sizes_combo_box.Text))
            {
                cansaveornot = false;
            }
            else
            {

                cansaveornot = true;
                
            }

            if (cansaveornot)
            {
                double  testnumber = 0; long testint = 0;
                if (!(long.TryParse(number_of_bottels_per_sequence_text_box.Text ,out testint) && (long.TryParse(number_of_pallets_text_box.Text , out testint)) && (long.TryParse(number_of_sequences_per_pallet_text_box.Text , out testint))&&(double.TryParse(capacity_tect_box.Text , out testnumber)) && (double.TryParse(height_text_box.Text , out testnumber))))
                {
                    cansaveornot = false;
                }

            }
            if (cansaveornot)
            {
                              
                //string myclient = "";
                //long myclientid = 1;
                //if (string.IsNullOrEmpty(clients_combo_box.Text))
                //{
                //    myclient = "عام";
                //    myclientid = 0;

                //}
                //else
                //{
                //    myclient = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME;
                //    myclientid = clients[clients_combo_box.SelectedIndex].SH_ID;
                //}
                quantity_no_of_pallets = long.Parse(number_of_pallets_text_box.Text);
                quantity_no_of_bottels = long.Parse(number_of_bottels_per_pallet_text_box.Text) * quantity_no_of_pallets;
                for (int i = 0; i < long.Parse(number_of_pallets_text_box.Text); i++)
                {
                    pallets.Add(new SH_PALLETS_OF_CUT_MURAN_MATERIAL(){ SH_CAPACITY = double.Parse(capacity_tect_box.Text) , SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID , SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME , SH_HEIGHT = double.Parse(height_text_box.Text) , SH_CUTTER_ID = cutters[cutters_combo_box.SelectedIndex].SH_ID , SH_CUTTER_TECHNICAL_MAN = cutter_technical_man.Text , SH_CUTTER_NAME = cutters[cutters_combo_box.SelectedIndex].SH_CUTTER_NAME  , SH_STOCK_ID = stocks[stocks_combo_box.SelectedIndex].SH_ID , SH_STOCK_NAME = stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME , SH_NUMBER_OF_BOTTELS_PER_PALLET = long.Parse(number_of_bottels_per_pallet_text_box.Text) , SH_NUMBER_OF_BOTTELS_PER_SEQUENCE = long.Parse(number_of_bottels_per_sequence_text_box.Text) , SH_NUMBER_OF_SEQUENCES = long.Parse(number_of_sequences_per_pallet_text_box.Text) , SH_ADDTION_DATE = DateTime.Now ,  SH_FIRST_FACE = faces[first_face_combo_box.SelectedIndex].SH_FACE_COLOR_NAME , SH_SECOND_FACE = faces[second_face_combo_box.SelectedIndex].SH_FACE_COLOR_NAME , SH_MURAN_TYPE = getmurantype() ,  SH_ADDTION_PERMISSION_NUMBER = add_new_quantity_to_adding_permission.Text  , SH_SIZE_ID = sizes[sizes_combo_box.SelectedIndex].SH_ID , SH_SIZE_NAME = sizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME });
                }
                total_number_of_bottels += quantity_no_of_pallets;
                total_number_of_pallets += quantity_no_of_pallets;
                total_no_pallets.Text = total_number_of_pallets.ToString();
                quantites.Add(new SH_QUANTITIES_OF_CUT_MURAN_MATERIAL() { q_pallets = pallets , SH_TOTAL_NUMBER_OF_BOTTELS = quantity_no_of_bottels , SH_TOTAL_NUMBER_OF_PALLETS = quantity_no_of_pallets });
                pallets = new List<SH_PALLETS_OF_CUT_MURAN_MATERIAL>();
                quantity_no_of_pallets = 0;
                quantity_no_of_bottels = 0;
                fillquantitesgridview();
            }
            else
            {
                MessageBox.Show("لا يمكن الحفظ البيانات  \n  الرجاء التأكظ من كتابة البيانات بشكل صحيح " , "خطأ"  , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }
        private void new_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewcutmuranmaterial myform = new addnewcutmuranmaterial())
            {
                myform.ShowDialog();
            }
            this.Close();
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (quantites.Count >0)
            {

                loadcutmuranspecifications();
                long sp_id = 0;
                for (int i = 0; i < quantites.Count; i++)
                {
                    sp_id = 0;
                    sp_id =  check_if_exists_or_not(quantites[i]);
                    if (sp_id ==0 )
                    {
                        sp_id   = savenewspecification(quantites[i]);
                        savequantity(sp_id , quantites[i]);
                    }
                    else
                    {
                        savequantity(sp_id, quantites[i]);
                    }
                }
                MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }
    }
}
