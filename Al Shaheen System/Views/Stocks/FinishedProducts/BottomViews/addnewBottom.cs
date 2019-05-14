using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class addnewBottom : Form
    {

        List<SH_BOTTOM_DATA> form_data = new List<SH_BOTTOM_DATA>();
        List<SH_MATERIAL_TYPES> material_types = new List<SH_MATERIAL_TYPES>();
        List<SH_EASY_OPEN_USAGE> usages = new List<SH_EASY_OPEN_USAGE>();


        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> c_products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_EMPLOYEES> stock_men = new List<SH_EMPLOYEES>();
        List<SH_SPECIFICATION_OF_BOTTOM> specifications = new List<SH_SPECIFICATION_OF_BOTTOM>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewBottom()
        {
            InitializeComponent();
        }

        async Task getalleasyopenusage()
        {
            usages.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_USAGE_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usages.Add(new SH_EASY_OPEN_USAGE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_USAGE_TYPE = reader["SH_USAGE_TYPE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL EASYOPEN USAGE TYPES" + ex.ToString());
            }
        }
        async Task fillsuagesgridview()
        {
            await getalleasyopenusage();
            usage_combo_box.Items.Clear();
            if (usages.Count > 0)
            {
                for (int i = 0; i < usages.Count; i++)
                {
                    usage_combo_box.Items.Add( usages[i].SH_USAGE_TYPE);
                }
            }
        }

        async Task getallmaterialtypes()
        {
            material_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_MATERIAL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    material_types.Add(new SH_MATERIAL_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_MATERIAL_TYPE_NAME = reader["SH_MATERIAL_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle ADDING NEW "+ex.ToString());
            }
        }

        async Task fillmaterialtypescombobox()
        {
            await getallmaterialtypes();
            material_type_combo_box.Items.Clear();
            if (material_types.Count > 0)
            {
                for (int i = 0; i < material_types.Count; i++)
                {
                    material_type_combo_box.Items.Add(material_types[i].SH_MATERIAL_TYPE_NAME);
                }
            }
        }

        async Task loadallstockmendata()
        {
            stock_men.Clear();
            string mystring = "امين مخزن";
            try
            {
                string query = "SELECT * FROM SH_EMPLOYEES WHERE  SH_EMPLOYEE_FUNCTION_NAME LIKE N'%" + mystring + "%' OR SH_EMPLOYEE_FUNCTION_NAME LIKE N'" + mystring + "%' OR SH_EMPLOYEE_FUNCTION_NAME LIKE N'%" + mystring + "'";
                
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stock_men.Add(new SH_EMPLOYEES() { SH_EMPLOYEE_ADDRESS = reader["SH_EMPLOYEE_ADDRESS"].ToString(), SH_EMPLOYEMENT_DATE = DateTime.Parse(reader["SH_EMPLOYEMENT_DATE"].ToString()), SH_EMPLOYEE_EMAIL = reader["SH_EMPLOYEE_EMAIL"].ToString(), SH_EMPLOYEE_FUNCTION_ID = long.Parse(reader["SH_EMPLOYEE_FUNCTION_ID"].ToString()), SH_EMPLOYEE_FUNCTION_NAME = reader["SH_EMPLOYEE_FUNCTION_NAME"].ToString(), SH_EMPLOYEE_GENDER = reader["SH_EMPLOYEE_GENDER"].ToString(), SH_EMPLOYEE_MOBILE = reader["SH_EMPLOYEE_MOBILE"].ToString(), SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString(), SH_EMPLOYEE_NATIONAL_ID = reader["SH_EMPLOYEE_NATIONAL_ID"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()) , SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING STOCK MEN FROM DB "+ex.ToString());
            }

        }

         async void fillstockmencombobox()
        {
            await loadallstockmendata();
            stock_men_combo_box.Items.Clear();
            if (stock_men.Count > 0)
            {
                for (int i = 0; i < stock_men.Count; i++)
                {
                    stock_men_combo_box.Items.Add(stock_men[i].SH_EMPLOYEE_NAME);
                }   
            }
        }



        async Task loadallstocks()
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
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING STOCKS DATA FROM DB " + ex.ToString());
            }
        }

        async void fillstockscombobox()
        {
            stocks.Clear();
            await loadallstocks();
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
        async Task  loadaallsizes()
        {
            sizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE";
                
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(), SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(), SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }
       async void fillsizesgridview()
        {
            await loadaallsizes();
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


        async Task loadsuppliersdata()
        {
            suppliers.Clear();
            try
            {
                string query = "SELECT SH_SUPPLY_COMPANY.* FROM SH_SUPPLY_COMPANY";
              
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPPLIERS DATA" + ex.ToString());
            }
        }
        async void fillsupplierscombobox()
        {
            await loadsuppliersdata();
            suppliers_combo_box.Items.Clear();
            if (suppliers.Count > 0)
            {
                for (int i = 0; i < suppliers.Count; i++)
                {
                    suppliers_combo_box.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
                }
            }

        }

        async Task  gettingsupplierbranchesbyid()
        {
            if (suppliers.Count > 0)
            {
                if (!string.IsNullOrEmpty(suppliers_combo_box.Text))
                {
                    try
                    {
                        string query = "SELECT SH_SUPPLY_COMPANY_BRANCHES.* FROM SH_SUPPLY_COMPANY_BRANCHES WHERE(SH_SUPPLY_COMPANY_ID = @supplier_id)";
                      
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@supplier_id", suppliers[suppliers_combo_box.SelectedIndex].SH_ID);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            supplier_branches.Add(new SH_SUPPLY_COMPANY_BRANCHES() { SH_COMPANY_BRANCH_ADDRESS_GPS_LINK = reader["SH_COMPANY_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_COMPANY_BRANCH_ADDRESS_TEXT = reader["SH_COMPANY_BRANCH_ADDRESS_TEXT"].ToString(), SH_COMPANY_BRANCH_NAME = reader["SH_COMPANY_BRANCH_NAME"].ToString(), SH_COMPANY_BRANCH_TYPE = reader["SH_COMPANY_BRANCH_TYPE"].ToString(), SH_SUPPLY_COMPANY_NAME = reader["SH_SUPPLY_COMPANY_NAME"].ToString() });
                        }
                        reader.Close();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE GETTING SPPLIER BRANCHES" + ex.ToString());
                    }
                }
            }
        }

       async void fillsupplierbranchescombobox()
        {
            await gettingsupplierbranchesbyid();
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
        async Task loadallfacecolors()
        {
            try
            {
                
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_FACE_COLORS", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    faces.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACES " + ex.ToString());
            }
        }

       
        private async void fillfacescombobox()
        {
            faces.Clear();
            F1_combo_box.Items.Clear();
            f2_combo_box.Items.Clear();
            await loadallfacecolors();
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

        async Task loadclientsdata()
        {
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY";
              
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),  SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
                }

                reader.Close();

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
            }
        }
      
        private async void fillclientproductcombobox()
        {
            f2_combo_box.Items.Clear();
            await gettingproductsbyclientid();
            for (int i = 0; i < c_products.Count; i++)
            {
                f2_combo_box.Items.Add(c_products[i].SH_PRODUCT_NAME);
            }
        }

        private async void fillclientscombobox()
        {
            await loadclientsdata();
            F1_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    F1_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }
        async Task gettingproductsbyclientid()
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
                    reader.Close();
                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS");
                }
            }
        }


        private async void Easyopenaddingform_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            fillsupplierscombobox();
            fillsizesgridview();
            fillstockscombobox();
            fillstockmencombobox();
            await fillsuagesgridview();
            await fillmaterialtypescombobox();
            F1_combo_box.Visible = false;
            f1_label.Visible = false;
            f2_combo_box.Visible = false;
            f2_label.Visible = false;
            //  f1_printing_stat.SelectedIndex = 2;
            //f2_printing_stat.SelectedIndex = 2;
            Cursor.Current = Cursors.Default;
        }



        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (container_types_combo_box.Items.Count > 0)
            {
                p_no_per_comtainer_label.Text = "عدد الأكياس / " + container_types_combo_box.Text;
                p_container_no_label.Text = "عدد " + container_types_combo_box.Text;
            }
        }
        
        void calcualtettotalitems()
        {
            if ( string.IsNullOrWhiteSpace(no_items_per_bage.Text)||string.IsNullOrEmpty(no_of_bages_per_container.Text) || string.IsNullOrEmpty(no_of_container_text_box.Text))
            {

            }else
            {
                long testbox = 0;
                if (long.TryParse(no_items_per_bage.Text, out testbox) && long.TryParse(no_of_container_text_box.Text , out  testbox) && long.TryParse(no_of_bages_per_container.Text , out testbox))
                {
                    total_no_of_products_text_box.Text = ((long.Parse(no_items_per_bage.Text)) *long.Parse(no_of_container_text_box.Text) * long.Parse(no_of_bages_per_container.Text)).ToString();
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
            calculatetotalnoofbages();
        }

        private void no_of_items_per_container_TextChanged(object sender, EventArgs e)
        {
            calcualtettotalitems();
            calculatetotalnoofbages();
        }

        async Task  saveeasyopensdata()
        {
            if (form_data.Count > 0)
            {
                for (int i = 0; i < form_data.Count; i++)
                {
                    long t_sp_id = checkifeasyopenspecificationsexistsornot(form_data[i]);
                    if (t_sp_id == 0)
                    {
                        t_sp_id = await saveneweasyopenspecifications(form_data[i]);
                        long q_id = await saveneweasyopenquantities(t_sp_id, form_data[i]);
                        await saveeasyopencontainers(t_sp_id, q_id, form_data[i]);
                        MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    else
                    {
                        await updateeasyopenspecifications(t_sp_id, form_data[i]);
                        long q_id = await saveneweasyopenquantities(t_sp_id, form_data[i]);
                        await saveeasyopencontainers(t_sp_id, q_id, form_data[i]);

                        MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            }
        }
        private async void save_easy_open_btn_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            ////Task t = Task.Run(async () =>
            ////{
            ////    Stopwatch mywatch = Stopwatch.StartNew();
            ////    await saveeasyopensdata();
            ////    mywatch.Stop();
            ////    Console.WriteLine(mywatch.Elapsed.ToString());
            ////});
            //Task t = Task.Run((Action) saveeasyopensdata);
            //  //t.Start();
            //  Cursor.Current = Cursors.Default;
            Cursor.Current = Cursors.WaitCursor;
            await saveeasyopensdata();
            Cursor.Current = Cursors.Default;
        }

        void loadalleasyopenspecifications()
        {
            specifications.Clear();
            try
            {
                string query = "SELECT  SH_SPECIFICATION_OF_BOTTOM.* FROM SH_SPECIFICATION_OF_BOTTOM";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_BOTTOM() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString() , SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()) , SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString()  , SH_FIRST_FACE_ID = long.Parse(reader["SH_FIRST_FACE_ID"].ToString()) , SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_PRINTING_TYPE = long.Parse(reader["SH_PRINTING_TYPE"].ToString())  , SH_PRINTING_TYPE_NAME = reader["SH_PRINTING_TYPE_NAME"].ToString() , SH_RAW_MATERIAL_TYPE = reader["SH_RAW_MATERIAL_TYPE"].ToString() , SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()) , SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString() , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() , SH_USAGE = reader["SH_USAGE"].ToString()  , SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString() , SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())});
                }
                reader.Read();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SPECIFICATIONS "+ex.ToString());
            }

        }

        long checkifeasyopenspecificationsexistsornot( SH_BOTTOM_DATA mydata)
        {
            specifications.Clear();
            loadalleasyopenspecifications();
            if (specifications.Count > 0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if (mydata.SH_PRINTING_TYPE ==0 )
                    {
                        //printed
                        if (specifications[i].SH_SIZE_ID == mydata.size.SH_ID && specifications[i].SH_PRINTING_TYPE == mydata.SH_PRINTING_TYPE && specifications[i].SH_CLIENT_ID == mydata.client.SH_ID && specifications[i].SH_CLIENT_PRODUCT_ID == mydata.product.SH_ID && string.Compare(specifications[i].SH_USAGE , mydata.SH_USAGE.SH_USAGE_TYPE) ==0 && string.Compare(specifications[i].SH_RAW_MATERIAL_TYPE , mydata.SH_RAW_MATERIAL_TYPE.SH_MATERIAL_TYPE_NAME) == 0 && string.Compare(container_types_combo_box.Text , mydata.container_name) ==0 )
                        {
                            return specifications[i].SH_ID;
                        }
                    }else
                    {
                        //muran
                        if (specifications[i].SH_SIZE_ID == mydata.size.SH_ID && specifications[i].SH_PRINTING_TYPE == mydata.SH_PRINTING_TYPE && specifications[i].SH_FIRST_FACE_ID == mydata.first_face.SH_ID && specifications[i].SH_SECOND_FACE_ID == mydata.second_face.SH_ID && string.Compare(specifications[i].SH_USAGE, mydata.SH_USAGE.SH_USAGE_TYPE) == 0 && string.Compare(specifications[i].SH_RAW_MATERIAL_TYPE, mydata.SH_RAW_MATERIAL_TYPE.SH_MATERIAL_TYPE_NAME) == 0 && string.Compare(container_types_combo_box.Text, mydata.container_name) == 0)
                       {
                            return specifications[i].SH_ID;
                        }
                    }
                }
            }
            return 0;
        }

        async Task updateeasyopenspecifications(long sp_id , SH_BOTTOM_DATA mydata)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_BOTTOM SET SH_TOTAL_NO_ITEMS = SH_TOTAL_NO_ITEMS + @SH_TOTAL_NO_ITEMS WHERE SH_ID = @SH_ID";
             
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , mydata.SH_TOTAL_NO_ITEMS);
                cmd.Parameters.AddWithValue("@SH_ID" , sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATIONS QUANTITIES" +ex.ToString());
            }
        }

        async Task<long> saveneweasyopenspecifications(SH_BOTTOM_DATA mydata)
        {
            if (f1_printing_stat.SelectedIndex == 0)
            {
                try
                {
                    string query = "INSERT INTO SH_SPECIFICATION_OF_BOTTOM ";
                    query += "(SH_USAGE, SH_RAW_MATERIAL_TYPE, SH_SIZE_ID, SH_PRINTING_TYPE, SH_SIZE_NAME, SH_PRINTING_TYPE_NAME, SH_CLIENT_ID, SH_CLIENT_NAME, SH_CLIENT_PRODUCT_NAME, SH_CLIENT_PRODUCT_ID, ";
                    query += " SH_FIRST_FACE_ID, SH_FIRST_FACE_NAME, SH_SECOND_FACE_ID, SH_SECOND_FACE_NAME , SH_TOTAL_NO_ITEMS , SH_CONTAINER_NAME) ";
                    query += " VALUES(@SH_USAGE,@SH_RAW_MATERIAL_TYPE,@SH_SIZE_ID,@SH_PRINTING_TYPE,@SH_SIZE_NAME,@SH_PRINTING_TYPE_NAME,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_CLIENT_PRODUCT_NAME,@SH_CLIENT_PRODUCT_ID,@SH_FIRST_FACE_ID,@SH_FIRST_FACE_NAME,@SH_SECOND_FACE_ID,@SH_SECOND_FACE_NAME , @SH_TOTAL_NO_ITEMS , @SH_CONTAINER_NAME)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                   
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_USAGE", mydata.SH_USAGE.SH_USAGE_TYPE);
                    cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", mydata.SH_RAW_MATERIAL_TYPE.SH_MATERIAL_TYPE_NAME);
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", mydata.size.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", mydata.SH_PRINTING_TYPE);
                    cmd.Parameters.AddWithValue("@SH_SIZE_NAME", mydata.size.SH_SIZE_NAME);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", mydata.SH_PRINTING_TYPE_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mydata.client.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", mydata.client.SH_CLIENT_COMPANY_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME", mydata.product.SH_PRODUCT_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", mydata.product.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , mydata.SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME" , mydata.container_name);
                    SqlDataReader reader = cmd.ExecuteReader();
                    long myid = 0;
                    if (reader.Read())
                    {
                        myid =  long.Parse(reader["myidentity"].ToString());
                    }
                    reader.Close();
                    myconnection.closeConnection();
                    return myid;
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
                    string query = "INSERT INTO SH_SPECIFICATION_OF_BOTTOM ";
                    query += "(SH_CONTAINER_NAME , SH_TOTAL_NO_ITEMS , SH_USAGE, SH_RAW_MATERIAL_TYPE, SH_SIZE_ID, SH_PRINTING_TYPE, SH_SIZE_NAME, SH_PRINTING_TYPE_NAME, SH_CLIENT_ID, SH_CLIENT_NAME, SH_CLIENT_PRODUCT_NAME, SH_CLIENT_PRODUCT_ID, ";
                    query += " SH_FIRST_FACE_ID, SH_FIRST_FACE_NAME, SH_SECOND_FACE_ID, SH_SECOND_FACE_NAME) ";
                    query += " VALUES(@SH_CONTAINER_NAME,@SH_TOTAL_NO_ITEMS , @SH_USAGE,@SH_RAW_MATERIAL_TYPE,@SH_SIZE_ID,@SH_PRINTING_TYPE,@SH_SIZE_NAME,@SH_PRINTING_TYPE_NAME,@SH_CLIENT_ID,@SH_CLIENT_NAME,@SH_CLIENT_PRODUCT_NAME,@SH_CLIENT_PRODUCT_ID,@SH_FIRST_FACE_ID,@SH_FIRST_FACE_NAME,@SH_SECOND_FACE_ID,@SH_SECOND_FACE_NAME)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                   
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_USAGE", mydata.SH_USAGE.SH_USAGE_TYPE);
                    cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", mydata.SH_RAW_MATERIAL_TYPE.SH_MATERIAL_TYPE_NAME);
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", mydata.size.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", mydata.SH_PRINTING_TYPE);
                    cmd.Parameters.AddWithValue("@SH_SIZE_NAME", mydata.size.SH_SIZE_NAME);
                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", mydata.SH_PRINTING_TYPE_NAME);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_NAME", 0);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", 0);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_ID", mydata.first_face.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_NAME", mydata.first_face.SH_FACE_COLOR_NAME);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", mydata.second_face.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_NAME", mydata.second_face.SH_FACE_COLOR_NAME);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);

                    SqlDataReader reader = cmd.ExecuteReader();
                    long myid = 0;
                    if (reader.Read())
                    {
                        myid= long.Parse(reader["myidentity"].ToString());
                    }
                    reader.Close();
                    myconnection.closeConnection();
                    return myid;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING NEW EASY OPEN SPECIFICATION " + ex.ToString());
                }
            }
            return 0;
        }

        async Task<long> saveneweasyopenquantities(long sp_id , SH_BOTTOM_DATA mydata)
        {
           
                try
                {
                    string query = "INSERT INTO SH_QUANTITY_OF_BOTTOM ";
                    query += "(SH_SPECIFICATION_OF_BOTTOM_ID, SH_ADDITION_PERMISSION_NUMBER, SH_ADDTION_DATE, SH_STOCK_ID, SH_STOCK_NAME, SH_STOCK_MAN_ID, SH_STOCK_MAN_NAME, SH_SUPPLY_DATE, SH_SUPPLIER_ID,";
                    query += " SH_SUPPLIER_BRANCH_ID, SH_SUPPLIER_NAME, SH_SUPPLIER_BRANCH_NAME, SH_CONTAINER_NAME, SH_NO_ITEMS_PER_CONTAINER, SH_TOTAL_NO_ITEMS, SH_NO_OF_CONTAINERS";
                    query += ",SH_SUBCONTAINER_NAME , SH_NO_OF_SUB_CONTAINER_PER_CONTAINER,SH_TOTAL_NUMBER_OF_SUB_CONTAINERS,SH_NO_ITEMS_PER_SUB_CONTAINER";
                    query += ") VALUES(@SH_SPECIFICATION_OF_BOTTOM_ID,@SH_ADDITION_PERMISSION_NUMBER,@SH_ADDTION_DATE,@SH_STOCK_ID,@SH_STOCK_NAME,@SH_STOCK_MAN_ID,@SH_STOCK_MAN_NAME,@SH_SUPPLY_DATE,@SH_SUPPLIER_ID,@SH_SUPPLIER_BRANCH_ID,@SH_SUPPLIER_BRANCH_NAME,@SH_SUPPLIER_NAME,@SH_CONTAINER_NAME,@SH_NO_ITEMS_PER_CONTAINER";
                    query += ",@SH_TOTAL_NO_ITEMS,@SH_NO_OF_CONTAINERS , @SH_SUBCONTAINER_NAME , @SH_NO_OF_SUB_CONTAINER_PER_CONTAINER,@SH_TOTAL_NUMBER_OF_SUB_CONTAINERS,@SH_NO_ITEMS_PER_SUB_CONTAINER)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                   
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_BOTTOM_ID", sp_id);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                    cmd.Parameters.AddWithValue("@SH_ADDTION_DATE",mydata.addition_date);
                    cmd.Parameters.AddWithValue("@SH_STOCK_ID", mydata.stock.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME",mydata.stock.SH_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID",mydata.stock_man.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", mydata.stock_man.SH_EMPLOYEE_NAME);
                    cmd.Parameters.AddWithValue("@SH_SUPPLY_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID", mydata.supplier.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_ID", mydata.supplier_branch.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_NAME", mydata.supplier.SH_SUPPLY_COMAPNY_NAME);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_NAME", mydata.supplier_branch.SH_SUPPLY_COMPANY_NAME);
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name );
                    cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", mydata.no_of_items_per_container);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", mydata.no_of_container);
                    cmd.Parameters.AddWithValue("@SH_SUBCONTAINER_NAME", mydata.sub_container_name);
                    cmd.Parameters.AddWithValue("@SH_NO_OF_SUB_CONTAINER_PER_CONTAINER",mydata.no_of_subcontainer_per_container);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_SUB_CONTAINERS", mydata.total_number_of_sub_container);
                    cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_SUB_CONTAINER", mydata.no_items_per_subcontainer);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                    {
                    myid= long.Parse(reader["myidentity"].ToString());
                    }else
                {
                    myid= 0;
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING EASY OPEN QUANTITY TO DB " + ex.ToString());
                    return 0;
                }
          
        }

        async Task  saveeasyopencontainers(long sp_id , long qu_id , SH_BOTTOM_DATA mydata)
        {
            try
            {
                //string query = "INSERT INTO SH_CONTAINER_OF_BOTTOM ";
                //query += "(SH_QUANTITY_OF_BOTTOM_ID, SH_SPECIFICATION_OF_BOTTOM_ID, SH_CONTAINER_NAME, SH_TOTAL_NO_ITEMS, SH_ADDITION_DATE";
                //query += " ,SH_SUBCONTAINER_NAME , SH_NO_OF_SUB_CONTAINER_PER_CONTAINER,SH_TOTAL_NUMBER_OF_SUB_CONTAINERS,SH_NO_ITEMS_PER_SUB_CONTAINER )VALUES(@SH_QUANTITY_OF_BOTTOM_ID,@SH_SPECIFICATION_OF_BOTTOM_ID,@SH_CONTAINER_NAME,@SH_TOTAL_NO_ITEMS,@SH_ADDITION_DATE,@SH_SUBCONTAINER_NAME , @SH_NO_OF_SUB_CONTAINER_PER_CONTAINER,@SH_TOTAL_NUMBER_OF_SUB_CONTAINERS,@SH_NO_ITEMS_PER_SUB_CONTAINER)";

                //myconnection.openConnection();
                //for (int i = 0; i < mydata.no_of_container; i++)
                //{
                //        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //        cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_BOTTOM_ID", qu_id);
                //        cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_BOTTOM_ID", sp_id);
                //        cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                //        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.no_of_items_per_container);
                //        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", mydata.addition_date);
                //        cmd.Parameters.AddWithValue("@SH_SUBCONTAINER_NAME", mydata.sub_container_name);
                //        cmd.Parameters.AddWithValue("@SH_NO_OF_SUB_CONTAINER_PER_CONTAINER", mydata.no_of_subcontainer_per_container);
                //        cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_SUB_CONTAINERS", mydata.total_number_of_sub_container);
                //        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_SUB_CONTAINER", mydata.no_items_per_subcontainer);
                //        cmd.ExecuteNonQuery();
                //    }

                //    myconnection.closeConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_BOTTOM_CONTAINERS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_container);
                cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_BOTTOM_ID", qu_id);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_BOTTOM_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.no_of_items_per_container);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", mydata.addition_date);
                cmd.Parameters.AddWithValue("@SH_SUBCONTAINER_NAME", mydata.sub_container_name);
                cmd.Parameters.AddWithValue("@SH_NO_OF_SUB_CONTAINER_PER_CONTAINER", mydata.no_of_subcontainer_per_container);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_SUB_CONTAINERS", mydata.total_number_of_sub_container);
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_SUB_CONTAINER", mydata.no_items_per_subcontainer);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW EASY IOPEN CONTAINER "+ex.ToString());
            }
        }

        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            if (string.IsNullOrWhiteSpace(addition_permission_number_text_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(stocks_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(stock_men_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(suppliers_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(supplier_branches_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(material_type_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(sizes_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(usage_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(f1_printing_stat.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(F1_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(container_types_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(no_of_container_text_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(no_of_bages_per_container.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(total_no_of_products_text_box.Text))
            {
                cansave = false;
            }

            if (cansave)
            {
                if (f1_printing_stat.SelectedIndex==0)
                {
                    form_data.Add(new SH_BOTTOM_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, client = clients[F1_combo_box.SelectedIndex], container_name = container_types_combo_box.Text, first_face = null,second_face=null ,no_of_container = long.Parse(no_of_container_text_box.Text), no_of_items_per_container = (long.Parse(no_items_per_bage.Text) * long.Parse(no_of_bages_per_container.Text)), product = c_products[f2_combo_box.SelectedIndex], no_items_per_subcontainer = long.Parse(no_items_per_bage.Text) , no_of_subcontainer_per_container= long.Parse(no_of_bages_per_container.Text) , SH_PRINTING_TYPE = f1_printing_stat.SelectedIndex , SH_PRINTING_TYPE_NAME = f1_printing_stat.Text , SH_RAW_MATERIAL_TYPE = material_types[material_type_combo_box.SelectedIndex] , SH_USAGE = usages[usage_combo_box.SelectedIndex] , SH_TOTAL_NO_ITEMS = long.Parse(total_no_of_products_text_box.Text) , size = sizes[sizes_combo_box.SelectedIndex] , stock = stocks[stocks_combo_box.SelectedIndex] , stock_man = stock_men[stock_men_combo_box.SelectedIndex] , sub_container_name= "أكياس" , supplier = suppliers[suppliers_combo_box.SelectedIndex] , supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex] , total_number_of_sub_container = long.Parse(total_no_bages.Text) });
                }else
                {
                    form_data.Add(new SH_BOTTOM_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, client = null, container_name = container_types_combo_box.Text, first_face = faces[F1_combo_box.SelectedIndex], second_face = faces[f2_combo_box.SelectedIndex], no_of_container = long.Parse(no_of_container_text_box.Text), no_of_items_per_container = (long.Parse(no_items_per_bage.Text) * long.Parse(no_of_bages_per_container.Text)), product = null, no_items_per_subcontainer = long.Parse(no_items_per_bage.Text), no_of_subcontainer_per_container = long.Parse(no_of_bages_per_container.Text), SH_PRINTING_TYPE = f1_printing_stat.SelectedIndex, SH_PRINTING_TYPE_NAME = f1_printing_stat.Text, SH_RAW_MATERIAL_TYPE = material_types[material_type_combo_box.SelectedIndex], SH_USAGE = usages[usage_combo_box.SelectedIndex], SH_TOTAL_NO_ITEMS = long.Parse(total_no_of_products_text_box.Text), size = sizes[sizes_combo_box.SelectedIndex], stock = stocks[stocks_combo_box.SelectedIndex], stock_man = stock_men[stock_men_combo_box.SelectedIndex], sub_container_name = "أكياس", supplier = suppliers[suppliers_combo_box.SelectedIndex], supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex], total_number_of_sub_container = long.Parse(total_no_bages.Text) });

                }
                filleasyopengridview();
            }
            else
            {
                MessageBox.Show("لا يمكن الاضافة لعدم إكتمال البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        void filleasyopengridview()
        {
            BOTTOM_form_data_grid_view.Rows.Clear();
            if (form_data.Count > 0)
            {
                for (int i = 0; i < form_data.Count; i++)
                {
                    string[] myparms = new string[13];
                    myparms[0] = (i+1).ToString();
                    myparms[1] = form_data[i].supplier.SH_SUPPLY_COMAPNY_NAME;
                    myparms[2] = form_data[i].SH_RAW_MATERIAL_TYPE.SH_MATERIAL_TYPE_NAME;
                    myparms[3] = form_data[i].SH_USAGE.SH_USAGE_TYPE;
                    myparms[4] = form_data[i].size.SH_SIZE_NAME;
                    myparms[5] = form_data[i].SH_PRINTING_TYPE_NAME;
                    if (form_data[i].SH_PRINTING_TYPE==0)
                    {
                        myparms[6] = form_data[i].product.SH_PRODUCT_NAME;
                        myparms[7] = form_data[i].product.SH_SECOND_FACE_NAME;
                    }else
                    {
                        myparms[6] = form_data[i].first_face.SH_FACE_COLOR_NAME;
                        myparms[7] = form_data[i].second_face.SH_FACE_COLOR_NAME;
                    }
                    myparms[8] = form_data[i].no_items_per_subcontainer.ToString();
                    myparms[9] = form_data[i].container_name;
                    myparms[10] = form_data[i].no_of_container.ToString();
                    myparms[11] = form_data[i].no_of_items_per_container.ToString();
                    myparms[12] = form_data[i].SH_TOTAL_NO_ITEMS.ToString();
                    BOTTOM_form_data_grid_view.Rows.Add(myparms);
                }
            }
        }

        void calculatetotalnoofbages()
        {
            if ( string.IsNullOrEmpty(no_of_bages_per_container.Text) || string.IsNullOrEmpty(no_of_container_text_box.Text))
            {

            }
            else
            {
                long testbox = 0;
                if ( long.TryParse(no_of_container_text_box.Text, out testbox) && long.TryParse(no_of_bages_per_container.Text, out testbox))
                {
                    total_no_bages.Text =  ( long.Parse(no_of_container_text_box.Text) * long.Parse(no_of_bages_per_container.Text)).ToString();
                }
            }
        }



        private void no_items_per_bage_TextChanged(object sender, EventArgs e)
        {
            calcualtettotalitems();
        }

        private void total_no_bages_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_text_box.Text = DateTime.Now.ToShortDateString();
        }

        private void remove_quantity_btn_Click(object sender, EventArgs e)
        {
            if (BOTTOM_form_data_grid_view.SelectedRows.Count > 0)
            {
                form_data.RemoveAt(BOTTOM_form_data_grid_view.SelectedRows[0].Index);
                filleasyopengridview();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewBottom myform = new  addnewBottom())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
