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
    public partial class addnewcutprintedmaterial : Form
    {
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_SHAHEEN_CUTTERS> cutters = new List<SH_SHAHEEN_CUTTERS>();
        List<SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL> quantities = new List<SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL>();
        List<SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL> specifications = new List<SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL>();
        List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> pallets = new List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL>();

        long mtotal_number_of_pallets = 0;
        long mtotal_number_of_bottels = 0;

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;


        public addnewcutprintedmaterial(SH_EMPLOYEES anyemp,SH_USER_ACCOUNTS anyAccount, SH_USER_PERMISIONS anyPermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPermission;
        }

        void loadspecificationsofcutprintedmaterial()
        {
            specifications.Clear();
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_PRODUCT_ID = long.Parse(reader["SH_PRODUCT_ID"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SPECIFICATIONS OF CUT PRINTED MATERIAL " + ex.ToString());
            }
        }
        long check_if_specification_exists_or_not()
        {
           
            if (specifications.Count > 0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if (specifications[i].SH_CLIENT_ID == clients[clients_combo_box.SelectedIndex].SH_ID && specifications[i].SH_PRODUCT_ID == products[client_products_combo_box.SelectedIndex].SH_ID)
                    {
                        return specifications[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        long savenewspecification()
        {
            try
            {
                string query = "INSERT INTO SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL ";
                query += "(SH_CLIENT_ID, SH_CLIENT_NAME, SH_PRODUCT_ID, SH_PRODUCT_NAME, SH_TOTAL_NUMBER_OF_BOTTELS, SH_TOTAL_NUMBER_OF_PALLETS) ";
                query += " VALUES(@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_PRODUCT_ID,@SH_PRODUCT_NAME,@SH_TOTAL_NUMBER_OF_BOTTELS,@SH_TOTAL_NUMBER_OF_PALLETS)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID", products[client_products_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS", mtotal_number_of_bottels);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLETS", mtotal_number_of_pallets);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING SPECIFICATION OF CUT PRINTED MATERIAL " + ex.ToString());
            }
            return 0;
        }

        void updatespecificationvalues(long sp_id)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL SET SH_TOTAL_NUMBER_OF_BOTTELS = SH_TOTAL_NUMBER_OF_BOTTELS + @SH_TOTAL_NUMBER_OF_BOTTELS, SH_TOTAL_NUMBER_OF_PALLETS = SH_TOTAL_NUMBER_OF_PALLETS + @SH_TOTAL_NUMBER_OF_PALLETS WHERE SH_ID = @SH_ID ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS", mtotal_number_of_bottels);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLETS", mtotal_number_of_pallets);
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATION VALUES " + ex.ToString());
            }
        }


        long savequantitiesofcutprintedmaterial(long sp_id)
        {
            try
            {
                string query = "INSERT INTO SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL ";
                query += "(SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL_ID, SH_CLIENT_ID, SH_CLIENT_NAME, SH_PRODUCT_ID, SH_PRODUCT_NAME, SH_STOCK_ID, SH_STOCK_NAME, SH_CUTTER_ID, SH_CUTTER_NAME,";
                query += " SH_TOTAL_NUMBER_OF_PALLETS, SH_TOTAL_NUMBER_OF_BOTTELS, SH_ADDITION_PERMISSION_NUMBER, SH_CUTTER_TECHNICAL_NAME , SH_ADDITION_DATE)";
                query += " VALUES(@SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL_ID,@SH_CLIENT_ID,@SH_CLIENT_NAME";
                query += ",@SH_PRODUCT_ID,@SH_PRODUCT_NAME,@SH_STOCK_ID,@SH_STOCK_NAME,@SH_CUTTER_ID,@SH_CUTTER_NAME,@SH_TOTAL_NUMBER_OF_PALLETS,@SH_TOTAL_NUMBER_OF_BOTTELS,@SH_ADDITION_PERMISSION_NUMBER,@SH_CUTTER_TECHNICAL_NAME , @SH_ADDITION_DATE)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID", products[client_products_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID" ,stocks[stocks_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME" ,stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_CUTTER_ID" , cutters[cutters_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_CUTTER_NAME" ,cutters[cutters_combo_box.SelectedIndex].SH_CUTTER_NAME);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLETS" ,mtotal_number_of_pallets);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS", mtotal_number_of_bottels);
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", adding_request_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CUTTER_TECHNICAL_NAME" , cutter_technical_man.Text);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now );
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING CUT PRINTED MATERIAL QUANTITIES "+ex.ToString());
            }
            return 0;
        }

        void savequantitypalletsofcutprintedmaterial(long sp_id , long quantity_id , List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> mypallets)
        {
            if (pallets.Count > 0)
            {
                for (int i = 0; i < mypallets.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_PALLETS_OF_CUT_PRINTED_MATERIAL ";
                        query += "(SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID, SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL_ID, SH_CLIENT_ID, SH_CLIENT_NAME, SH_PRODUCT_ID, SH_PRODUCT_NAME, SH_ADDITION_DATE, SH_CUTTER_ID,";
                        query += " SH_CUTTER_NAME, SH_CUTTER_TECHNICAL_MAN, SH_NUMBER_OF_SEQUENCES, SH_NUMBER_OF_BOTTLES_PER_SEQUENCE, SH_TOTAL_NUMBER_OF_BOTTELS, SH_STOCK_ID, SH_STOCK_NAME,";
                        query += " SH_ADDTION_PERMISSION_NUMBER)";
                        query += " VALUES(@SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID,@SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL_ID,@SH_CLIENT_ID,@SH_CLIENT_NAME";
                        query += ",@SH_PRODUCT_ID,@SH_PRODUCT_NAME,@SH_ADDITION_DATE,@SH_CUTTER_ID,@SH_CUTTER_NAME,@SH_CUTTER_TECHNICAL_MAN,@SH_NUMBER_OF_SEQUENCES,@SH_NUMBER_OF_BOTTLES_PER_SEQUENCE,@SH_TOTAL_NUMBER_OF_BOTTELS,@SH_STOCK_ID,@SH_STOCK_NAME,@SH_ADDTION_PERMISSION_NUMBER)";

                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID", sp_id);
                        cmd.Parameters.AddWithValue("@SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL_ID", quantity_id);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mypallets[i].SH_CLIENT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", mypallets[i].SH_CLIENT_NAME);
                        cmd.Parameters.AddWithValue("@SH_PRODUCT_ID", mypallets[i].SH_PRODUCT_ID);
                        cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", mypallets[i].SH_PRODUCT_NAME);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", mypallets[i].SH_ADDITION_DATE);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_ID", mypallets[i].SH_CUTTER_ID);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_NAME", mypallets[i].SH_CUTTER_NAME);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_TECHNICAL_MAN", mypallets[i].SH_CUTTER_TECHNICAL_MAN);
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_SEQUENCES", mypallets[i].SH_NUMBER_OF_SEQUENCES );
                        cmd.Parameters.AddWithValue("@SH_NUMBER_OF_BOTTLES_PER_SEQUENCE", mypallets[i].SH_NUMBER_OF_BOTTLES_PER_SEQUENCE);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS", mypallets[i].SH_TOTAL_NUMBER_OF_BOTTELS);
                        cmd.Parameters.AddWithValue("@SH_STOCK_ID", mypallets[i].SH_STOCK_ID);
                        cmd.Parameters.AddWithValue("@SH_STOCK_NAME", mypallets[i].SH_STOCK_NAME);
                        cmd.Parameters.AddWithValue("@SH_ADDTION_PERMISSION_NUMBER", mypallets[i].SH_ADDTION_PERMISSION_NUMBER);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING PALLETS OF CUT PRINTED MATERIALS" + ex.ToString());
                    }
                }
              
            }
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
                        products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()),  SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });


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
        private void addnewcutprintedmaterial_Load(object sender, EventArgs e)
        {
            fillstockscombobox();
            fill_clients_combo_box();
            fillcutterscombobox();
        }

        private void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillproductscombobox();
        }

        private void adding_request_number_text_box_TextChanged(object sender, EventArgs e)
        {
            long testnumber = 0;
            if (!long.TryParse(adding_request_number_text_box.Text , out testnumber))
            {
                errorProvider1.SetError(adding_request_number_text_box , "الرجاء إدخال رقم إذن الإضافة بشكل صحيح123 ");
            }else
            {
                errorProvider1.Clear();
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

        private void number_of_sequences_per_pallet_text_box_TextChanged(object sender, EventArgs e)
        {
            long test_number = 0;
            if (!long.TryParse(number_of_sequences_per_pallet_text_box.Text , out test_number))
            {
                errorProvider1.SetError(number_of_sequences_per_pallet_text_box,"الرجاء إدخال رقم صحيح 123 ");
            }else
            {
                errorProvider1.Clear();
                number_of_bottels_per_pallet_text_box.Text= calculatetotalnumberofbottelsperpallet().ToString();
                quantity_number_of_bottels.Text =  calculatequantitynumberofbottels().ToString();
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

        private void number_of_bottels_per_pallet_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        long calculatetotalnumberofbottelsperpallet()
        {
            if ((!string.IsNullOrEmpty(number_of_bottels_per_sequence_text_box.Text)) && ( !string.IsNullOrEmpty(number_of_sequences_per_pallet_text_box.Text)))
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

        private void addnewquantitybtn_Click(object sender, EventArgs e)
        {
            bool saveornot = true;
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
            else if (string.IsNullOrEmpty(number_of_bottels_per_sequence_text_box.Text))
            {
                saveornot = false;
            }
            else if (string.IsNullOrEmpty(number_of_sequences_per_pallet_text_box.Text))
            {
                saveornot = false;
            }
            else if (string.IsNullOrEmpty(stocks_combo_box.Text))
            {
                saveornot = false;
            }
            else if (string.IsNullOrEmpty(cutters_combo_box.Text))
            {
                saveornot = false;
            }
            else if (string.IsNullOrEmpty(cutter_technical_man.Text))
            {
                saveornot = false;
            }
            else
            {
                pallets.Clear();
                //will addition here 
                long no_of_pallets = long.Parse(number_of_pallets_text_box.Text);
                for (int i = 0; i < no_of_pallets; i++)
                {
                    pallets.Add(new SH_PALLETS_OF_CUT_PRINTED_MATERIAL() { SH_ADDITION_DATE = DateTime.Now, SH_ADDTION_PERMISSION_NUMBER = adding_request_number_text_box.Text, SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID, SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME, SH_CUTTER_ID = cutters[cutters_combo_box.SelectedIndex].SH_ID, SH_CUTTER_NAME = cutters[cutters_combo_box.SelectedIndex].SH_CUTTER_NAME, SH_CUTTER_TECHNICAL_MAN = cutter_technical_man.Text, SH_PRODUCT_ID = products[client_products_combo_box.SelectedIndex].SH_ID, SH_PRODUCT_NAME = products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME, SH_STOCK_ID = stocks[stocks_combo_box.SelectedIndex].SH_ID, SH_STOCK_NAME = stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME, SH_NUMBER_OF_BOTTLES_PER_SEQUENCE = long.Parse(number_of_bottels_per_sequence_text_box.Text), SH_NUMBER_OF_SEQUENCES = long.Parse(number_of_sequences_per_pallet_text_box.Text), SH_TOTAL_NUMBER_OF_BOTTELS = long.Parse(quantity_number_of_bottels.Text) });
                }
                quantities.Add(new SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL() {  pallets = pallets ,  SH_ADDTION_PERMISSION_NUMBER = adding_request_number_text_box.Text , SH_ADDTTION_DATE = DateTime.Now , SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID , SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME , SH_CUTTER_ID = cutters[cutters_combo_box.SelectedIndex].SH_ID , SH_CUTTER_NAME = cutters[cutters_combo_box.SelectedIndex].SH_CUTTER_NAME , SH_CUTTER_TECHNICAL_MAN = cutter_technical_man.Text , SH_PRODUCT_ID = products[client_products_combo_box.SelectedIndex].SH_ID , SH_PRODUCT_NAME = products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME , SH_STOCK_ID= stocks[stocks_combo_box.SelectedIndex].SH_ID  , SH_STOCK_NAME = stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME , SH_TOTAL_NUMBER_OF_PALLETS = long.Parse(number_of_pallets_text_box.Text) , SH_TOTAL_NUMBER_OF_BOTTELS = long.Parse(quantity_number_of_bottels.Text)  });
                fillquanttiesdatagridview();
            }
            if (!saveornot)
            {
                MessageBox.Show("يرجي التأكد أن البيانات مكتوبة بشكل صحيح" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        void fillquanttiesdatagridview()
        {
            quantities_data_grid_view.Rows.Clear();
            if (quantities.Count > 0)
            {
                for (int i = 0; i < quantities.Count; i++)
                {
                    quantities_data_grid_view.Rows.Add(new string[] { (i+1).ToString() , quantities[i]. SH_CLIENT_NAME , quantities[i].SH_PRODUCT_NAME , quantities[i].SH_TOTAL_NUMBER_OF_PALLETS.ToString() ,quantities[i].pallets[0].SH_NUMBER_OF_SEQUENCES.ToString() , quantities[i].SH_TOTAL_NUMBER_OF_BOTTELS.ToString() });
                }
            }
        }



        private void save_btn_Click(object sender, EventArgs e)
        {
            if (quantities.Count >0)
            {
                long sp_id = 0;
                for (int i = 0; i < quantities.Count; i++)
                {
                    sp_id = 0;
                    loadspecificationsofcutprintedmaterial();
                    sp_id = check_if_specification_exists_or_not();
                    if (sp_id ==0 )
                    {
                        sp_id = savenewspecification();
                        long q_id = savequantitiesofcutprintedmaterial(sp_id);
                        savequantitypalletsofcutprintedmaterial(sp_id  , q_id , quantities[i].pallets );

                    }else
                    {
                        updatespecificationvalues(sp_id);
                        long q_id = savequantitiesofcutprintedmaterial(sp_id);
                        savequantitypalletsofcutprintedmaterial(sp_id, q_id, quantities[i].pallets);
                    }

                }
                MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);


            }
        }

        private void add_new_cutprinted_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            addnewcutprintedmaterial myform = new addnewcutprintedmaterial(mEmployee,mAccount,mPermission);
            
                myform.ShowDialog();
            
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
