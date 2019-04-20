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
    public partial class BillOffaddingform : Form
    {
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> c_products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_EMPLOYEES> stock_men = new List<SH_EMPLOYEES>();
        List<SH_SPECIFICATION_OF_BILL_OFF> specifications = new List<SH_SPECIFICATION_OF_BILL_OFF>();
        public BillOffaddingform()
        {
            InitializeComponent();
        }

        void loadallstockmendata()
        {
            stock_men.Clear();
            string mystring = "امين مخزن";
            try
            {
                string query = "SELECT * FROM SH_EMPLOYEES WHERE  SH_EMPLOYEE_FUNCTION_NAME LIKE N'%" + mystring + "%' OR SH_EMPLOYEE_FUNCTION_NAME LIKE N'" + mystring + "%' OR SH_EMPLOYEE_FUNCTION_NAME LIKE N'%" + mystring + "'";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stock_men.Add(new SH_EMPLOYEES() { SH_EMPLOYEE_ADDRESS = reader["SH_EMPLOYEE_ADDRESS"].ToString(), SH_EMPLOYEMENT_DATE = DateTime.Parse(reader["SH_EMPLOYEMENT_DATE"].ToString()), SH_EMPLOYEE_EMAIL = reader["SH_EMPLOYEE_EMAIL"].ToString(), SH_EMPLOYEE_FUNCTION_ID = long.Parse(reader["SH_EMPLOYEE_FUNCTION_ID"].ToString()), SH_EMPLOYEE_FUNCTION_NAME = reader["SH_EMPLOYEE_FUNCTION_NAME"].ToString(), SH_EMPLOYEE_GENDER = reader["SH_EMPLOYEE_GENDER"].ToString(), SH_EMPLOYEE_MOBILE = reader["SH_EMPLOYEE_MOBILE"].ToString(), SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString(), SH_EMPLOYEE_NATIONAL_ID = reader["SH_EMPLOYEE_NATIONAL_ID"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()), SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING STOCK MEN FROM DB " + ex.ToString());
            }

        }
        void fillstockmencombobox()
        {
            loadallstockmendata();
            stock_men_combo_box.Items.Clear();
            if (stock_men.Count > 0)
            {
                for (int i = 0; i < stock_men.Count; i++)
                {
                    stock_men_combo_box.Items.Add(stock_men[i].SH_EMPLOYEE_NAME);
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


        void loadsuppliersdata()
        {
            suppliers.Clear();
            try
            {
                string query = "SELECT SH_SUPPLY_COMPANY.* FROM SH_SUPPLY_COMPANY";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPPLIERS DATA" + ex.ToString());
            }
        }
        void fillsupplierscombobox()
        {
            loadsuppliersdata();
            suppliers_combo_box.Items.Clear();
            if (suppliers.Count > 0)
            {
                for (int i = 0; i < suppliers.Count; i++)
                {
                    suppliers_combo_box.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
                }
            }

        }

        void gettingsupplierbranchesbyid()
        {
            if (suppliers.Count > 0)
            {
                if (!string.IsNullOrEmpty(suppliers_combo_box.Text))
                {
                    try
                    {
                        string query = "SELECT SH_SUPPLY_COMPANY_BRANCHES.* FROM SH_SUPPLY_COMPANY_BRANCHES WHERE(SH_SUPPLY_COMPANY_ID = @supplier_id)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@supplier_id", suppliers[suppliers_combo_box.SelectedIndex].SH_ID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            supplier_branches.Add(new SH_SUPPLY_COMPANY_BRANCHES() { SH_COMPANY_BRANCH_ADDRESS_GPS_LINK = reader["SH_COMPANY_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_COMPANY_BRANCH_ADDRESS_TEXT = reader["SH_COMPANY_BRANCH_ADDRESS_TEXT"].ToString(), SH_COMPANY_BRANCH_NAME = reader["SH_COMPANY_BRANCH_NAME"].ToString(), SH_COMPANY_BRANCH_TYPE = reader["SH_COMPANY_BRANCH_TYPE"].ToString(), SH_SUPPLY_COMPANY_NAME = reader["SH_SUPPLY_COMPANY_NAME"].ToString() });
                        }
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE GETTING SPPLIER BRANCHES" + ex.ToString());
                    }
                }
            }
        }

        void fillsupplierbranchescombobox()
        {
            gettingsupplierbranchesbyid();
            supplier_branches_combo_box.Items.Clear();
            if (supplier_branches.Count > 0)
            {
                for (int i = 0; i < supplier_branches.Count; i++)
                {
                    supplier_branches_combo_box.Items.Add(supplier_branches[i].SH_COMPANY_BRANCH_NAME);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

    

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (f1_printing_stat.SelectedIndex)
            {
                case 0 :
                    {
                        // مطبوع
                        f1_label.Text = "إسم العميل";
                        f2_label.Text = "إسم الصنف";
                        F1_combo_box.Visible = true;
                        F1_combo_box.Text = "";
                        f1_label.Visible = true;
                        f2_combo_box.Visible = true;
                        f2_combo_box.Text = ""; 
                        f2_label.Visible = true;
                        fillclientscombobox();
                        
                        break;
                    }
                case 1:
                    {
                        // مورنش
                        f1_label.Text = "الوجة الاول";
                        F1_combo_box.Visible = true;
                        F1_combo_box.Text = "";
                        f1_label.Visible = true;
                        f2_label.Text = "الوجة الثانى";
                        f2_label.Visible = true;
                        f2_combo_box.Visible = true;
                        f2_combo_box.Text = "";
                        fillfacescombobox();
                        break;
                    }


                default:
                    break;
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

       
        private void fillfacescombobox()
        {
            faces.Clear();
            F1_combo_box.Items.Clear();
            f2_combo_box.Items.Clear();
            loadallfacecolors();
            if (faces.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < faces.Count; i++)
                {
                    F1_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                    f2_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
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
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
            }
        }
      
        private void fillclientproductcombobox()
        {
            f2_combo_box.Items.Clear();
            gettingproductsbyclientid();
            for (int i = 0; i < c_products.Count; i++)
            {
                f2_combo_box.Items.Add(c_products[i].SH_PRODUCT_NAME);
            }
        }

        private void fillclientscombobox()
        {
            loadclientsdata();
            F1_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    F1_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }
        void gettingproductsbyclientid()
        {
            c_products.Clear();
            if (string.IsNullOrEmpty(F1_combo_box.Text))
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
                    cmd.Parameters.AddWithValue("@CLIENT_ID", clients[F1_combo_box.SelectedIndex].SH_ID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        //getting products data
                        c_products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });


                    }

                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS");
                }
            }
        }

       
        private void Easyopenaddingform_Load(object sender, EventArgs e)
        {
            fillsupplierscombobox();
            fillsizesgridview();
            fillstockscombobox();
            fillstockmencombobox();
            F1_combo_box.Visible = false;
            f1_label.Visible = false;
            f2_combo_box.Visible = false;
            f2_label.Visible = false;
          //  f1_printing_stat.SelectedIndex = 2;
            //f2_printing_stat.SelectedIndex = 2;
        }

      

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (container_types_combo_box.Items.Count > 0)
            {
                p_no_per_comtainer_label.Text = "العدد / " + container_types_combo_box.Text;
                p_container_no_label.Text = "عدد " + container_types_combo_box.Text;
            }
        }
        
        void calcualtettotalitems()
        {
            if (string.IsNullOrEmpty(no_of_items_per_container.Text) || string.IsNullOrEmpty(no_of_container_text_box.Text))
            {

            }else
            {
                long testbox = 0;
                if (long.TryParse(no_of_container_text_box.Text , out  testbox) && long.TryParse(no_of_items_per_container.Text , out testbox))
                {
                    total_no_of_products_text_box.Text = (long.Parse(no_of_container_text_box.Text) * long.Parse(no_of_items_per_container.Text)).ToString();
                }
            }
        } 



        private void suppliers_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillsupplierbranchescombobox();
        }

        private void F1_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f1_printing_stat.SelectedIndex == 0)
            {
                fillclientproductcombobox();
            }
        }

        private void no_of_container_text_box_TextChanged(object sender, EventArgs e)
        {
            calcualtettotalitems();
        }

        private void no_of_items_per_container_TextChanged(object sender, EventArgs e)
        {
            calcualtettotalitems();
        }

        private void save_BILL_OFF_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            if (string.IsNullOrWhiteSpace(addition_permission_number_text_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(stocks_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(stock_men_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(suppliers_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(supplier_branches_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(material_type_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(sizes_combo_box.Text))
            {
                cansave = false;
            }else if (string.IsNullOrWhiteSpace(usage_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(f1_printing_stat.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(F1_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(container_types_combo_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(no_of_container_text_box.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(no_of_items_per_container.Text))
            {
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(total_no_of_products_text_box.Text))
            {
                cansave = false;
            }

            if (cansave)
            {
                long t_sp_id = checkifeasyopenspecificationsexistsornot();
                if (t_sp_id ==0)
                {
                   t_sp_id = saveneweasyopenspecifications();
                    long q_id = saveneweasyopenquantities(t_sp_id);
                    for (int i = 0; i < long.Parse(no_of_container_text_box.Text); i++)
                    {
                        saveeasyopencontainers(t_sp_id , q_id);
                    }
                    MessageBox.Show("تم الحفظ" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }else
                {
                    updateeasyopenspecifications(t_sp_id);
                    long q_id = saveneweasyopenquantities(t_sp_id);
                    for (int i = 0; i < long.Parse(no_of_container_text_box.Text); i++)
                    {
                        saveeasyopencontainers(t_sp_id, q_id);
                    }
                    MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }

            }else
            {
                MessageBox.Show("لا يمكن الحفظ لعدم إكتمال البيانات" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
            }



        }

        void loadalleasyopenspecifications()
        {
            specifications.Clear();
            try
            {
                string query = "SELECT  SH_SPECIFICATION_OF_BILL_OFF.* FROM SH_SPECIFICATION_OF_BILL_OFF";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_BILL_OFF() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString() , SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()) , SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString()  , SH_FIRST_FACE_ID = long.Parse(reader["SH_FIRST_FACE_ID"].ToString()) , SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_PRINTING_TYPE = long.Parse(reader["SH_PRINTING_TYPE"].ToString())  , SH_PRINTING_TYPE_NAME = reader["SH_PRINTING_TYPE_NAME"].ToString() , SH_RAW_MATERIAL_TYPE = reader["SH_RAW_MATERIAL_TYPE"].ToString() , SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()) , SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString() , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() , SH_USAGE = reader["SH_USAGE"].ToString()  , SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString() , SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())});
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SPECIFICATIONS "+ex.ToString());
            }

        }

        long checkifeasyopenspecificationsexistsornot()
        {
            specifications.Clear();
            loadalleasyopenspecifications();
            if (specifications.Count > 0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if (f1_printing_stat.SelectedIndex ==0 )
                    {
                        //printed
                        if (specifications[i].SH_SIZE_ID == sizes[sizes_combo_box.SelectedIndex].SH_ID && specifications[i].SH_PRINTING_TYPE == f1_printing_stat.SelectedIndex && specifications[i].SH_CLIENT_ID == clients[F1_combo_box.SelectedIndex].SH_ID && specifications[i].SH_CLIENT_PRODUCT_ID == c_products[f2_combo_box.SelectedIndex].SH_ID && string.Compare(specifications[i].SH_USAGE , usage_combo_box.Text)==0 && string.Compare(specifications[i].SH_RAW_MATERIAL_TYPE , material_type_combo_box.Text) == 0 && string.Compare(container_types_combo_box.Text , specifications[i].SH_CONTAINER_NAME)==0 )
                        {
                            return specifications[i].SH_ID;
                        }
                    }else
                    {
                        //muran
                        if (specifications[i].SH_SIZE_ID == sizes[sizes_combo_box.SelectedIndex].SH_ID && specifications[i].SH_PRINTING_TYPE == f1_printing_stat.SelectedIndex && specifications[i].SH_FIRST_FACE_ID == faces[F1_combo_box.SelectedIndex].SH_ID && specifications[i].SH_SECOND_FACE_ID == faces[f2_combo_box.SelectedIndex].SH_ID && string.Compare(specifications[i].SH_USAGE, usage_combo_box.Text) == 0 && string.Compare(specifications[i].SH_RAW_MATERIAL_TYPE, material_type_combo_box.Text) == 0 && string.Compare(container_types_combo_box.Text, specifications[i].SH_CONTAINER_NAME) == 0)
                        {
                            return specifications[i].SH_ID;
                        }
                    }
                }
            }
            return 0;
        }

        void updateeasyopenspecifications(long sp_id)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_BILL_OFF SET SH_TOTAL_NO_ITEMS = SH_TOTAL_NO_ITEMS + @SH_TOTAL_NO_ITEMS WHERE SH_ID = @SH_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , long.Parse(total_no_of_products_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ID" , sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATIONS QUANTITIES" +ex.ToString());
            }
        }

        long saveneweasyopenspecifications()
        {
            if (f1_printing_stat.SelectedIndex == 0)
            {
                try
                {
                    string query = "INSERT INTO SH_SPECIFICATION_OF_BILL_OFF ";
                    query += "(SH_USAGE, SH_RAW_MATERIAL_TYPE, SH_SIZE_ID, SH_PRINTING_TYPE, SH_SIZE_NAME, SH_PRINTING_TYPE_NAME, SH_CLIENT_ID, SH_CLIENT_NAME, SH_CLIENT_PRODUCT_NAME, SH_CLIENT_PRODUCT_ID, ";
                    query += " SH_FIRST_FACE_ID, SH_FIRST_FACE_NAME, SH_SECOND_FACE_ID, SH_SECOND_FACE_NAME , SH_TOTAL_NO_ITEMS , SH_CONTAINER_NAME) ";
                    query += " VALUES(@SH_USAGE,@SH_RAW_MATERIAL_TYPE,@SH_SIZE_ID,@SH_PRINTING_TYPE,@SH_SIZE_NAME,@SH_PRINTING_TYPE_NAME,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_CLIENT_PRODUCT_NAME,@SH_CLIENT_PRODUCT_ID,@SH_FIRST_FACE_ID,@SH_FIRST_FACE_NAME,@SH_SECOND_FACE_ID,@SH_SECOND_FACE_NAME , @SH_TOTAL_NO_ITEMS , @SH_CONTAINER_NAME)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_USAGE", usage_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", material_type_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", sizes[sizes_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", f1_printing_stat.SelectedIndex);
                    cmd.Parameters.AddWithValue("@SH_SIZE_NAME", sizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", f1_printing_stat.Text);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[F1_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", clients[F1_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME", c_products[f2_combo_box.SelectedIndex].SH_PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", c_products[f2_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , long.Parse(total_no_of_products_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME" , container_types_combo_box.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return long.Parse(reader["myidentity"].ToString());
                    }
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING NEW EASY OPEN SPECIFICATION " + ex.ToString());
                }
            }
            else
            {
                try
                {
                    string query = "INSERT INTO SH_SPECIFICATION_OF_BILL_OFF ";
                    query += "(SH_CONTAINER_NAME , SH_TOTAL_NO_ITEMS , SH_USAGE, SH_RAW_MATERIAL_TYPE, SH_SIZE_ID, SH_PRINTING_TYPE, SH_SIZE_NAME, SH_PRINTING_TYPE_NAME, SH_CLIENT_ID, SH_CLIENT_NAME, SH_CLIENT_PRODUCT_NAME, SH_CLIENT_PRODUCT_ID, ";
                    query += " SH_FIRST_FACE_ID, SH_FIRST_FACE_NAME, SH_SECOND_FACE_ID, SH_SECOND_FACE_NAME) ";
                    query += " VALUES(@SH_CONTAINER_NAME,@SH_TOTAL_NO_ITEMS , @SH_USAGE,@SH_RAW_MATERIAL_TYPE,@SH_SIZE_ID,@SH_PRINTING_TYPE,@SH_SIZE_NAME,@SH_PRINTING_TYPE_NAME,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_CLIENT_PRODUCT_NAME,@SH_CLIENT_PRODUCT_ID,@SH_FIRST_FACE_ID,@SH_FIRST_FACE_NAME,@SH_SECOND_FACE_ID,@SH_SECOND_FACE_NAME)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_USAGE", usage_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", material_type_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", sizes[sizes_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", f1_printing_stat.SelectedIndex);
                    cmd.Parameters.AddWithValue("@SH_SIZE_NAME", sizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", f1_printing_stat.Text);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_ID", faces[F1_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_NAME", faces[F1_combo_box.SelectedIndex].SH_FACE_COLOR_NAME);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", faces[f2_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_NAME", faces[f2_combo_box.SelectedIndex].SH_FACE_COLOR_NAME);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", long.Parse(total_no_of_products_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", container_types_combo_box.Text);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return long.Parse(reader["myidentity"].ToString());
                    }
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING NEW EASY OPEN SPECIFICATION " + ex.ToString());
                }
            }
            return 0;
        }

        long saveneweasyopenquantities(long sp_id)
        {
           
                try
                {
                    string query = "INSERT INTO SH_QUANTITY_OF_BILL_OFF ";
                    query += "(SH_SPECIFICATION_OF_BILL_OFF_ID, SH_ADDITION_PERMISSION_NUMBER, SH_ADDTION_DATE, SH_STOCK_ID, SH_STOCK_NAME, SH_STOCK_MAN_ID, SH_STOCK_MAN_NAME, SH_SUPPLY_DATE, SH_SUPPLIER_ID,";
                    query += " SH_SUPPLIER_BRANCH_ID, SH_SUPPLIER_NAME, SH_SUPPLIER_BRANCH_NAME, SH_CONTAINER_NAME, SH_NO_ITEMS_PER_CONTAINER, SH_TOTAL_NO_ITEMS, SH_NO_OF_CONTAINERS)";
                    query += " VALUES(@SH_SPECIFICATION_OF_BILL_OFF_ID,@SH_ADDITION_PERMISSION_NUMBER,@SH_ADDTION_DATE,@SH_STOCK_ID,@SH_STOCK_NAME,@SH_STOCK_MAN_ID,@SH_STOCK_MAN_NAME,@SH_SUPPLY_DATE,@SH_SUPPLIER_ID,@SH_SUPPLIER_BRANCH_ID,@SH_SUPPLIER_BRANCH_NAME,@SH_SUPPLIER_NAME,@SH_CONTAINER_NAME,@SH_NO_ITEMS_PER_CONTAINER";
                    query += ",@SH_TOTAL_NO_ITEMS,@SH_NO_OF_CONTAINERS)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_BILL_OFF_ID", sp_id);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", addition_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ADDTION_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME", stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", stock_men[stock_men_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", stock_men[stock_men_combo_box.SelectedIndex].SH_EMPLOYEE_NAME);
                    cmd.Parameters.AddWithValue("@SH_SUPPLY_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID", suppliers[suppliers_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_ID", supplier_branches[supplier_branches_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_NAME", suppliers[suppliers_combo_box.SelectedIndex].SH_SUPPLY_COMAPNY_NAME);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_NAME", supplier_branches[supplier_branches_combo_box.SelectedIndex].SH_COMPANY_BRANCH_NAME);
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", container_types_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", long.Parse(no_of_items_per_container.Text));
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", long.Parse(total_no_of_products_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", long.Parse(no_of_container_text_box.Text));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return long.Parse(reader["myidentity"].ToString());
                    }else
                {
                    return 0;
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING EASY OPEN QUANTITY TO DB " + ex.ToString());
                    return 0;
                }
          
        }

        void saveeasyopencontainers(long sp_id , long qu_id)
        {
            try
            {
                string query = "INSERT INTO SH_CONTAINER_OF_BILL_OFF ";
                query += "(SH_QUANTITY_OF_BILL_OFF_ID, SH_SPECIFICATION_OF_BILL_OFF_ID, SH_CONTAINER_NAME, SH_TOTAL_NO_ITEMS, SH_ADDITION_DATE)";
                query += " VALUES(@SH_QUANTITY_OF_BILL_OFF_ID,@SH_SPECIFICATION_OF_BILL_OFF_ID,@SH_CONTAINER_NAME,@SH_TOTAL_NO_ITEMS,@SH_ADDITION_DATE)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_BILL_OFF_ID", qu_id);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_BILL_OFF_ID" , sp_id);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME" , container_types_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , long.Parse(no_of_items_per_container.Text));
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE" , DateTime.Now);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW EASY IOPEN CONTAINER "+ex.ToString());
            }
        }



        
    }
}
