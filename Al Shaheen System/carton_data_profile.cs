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
    public partial class carton_data_profile : Form
    {

        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_SPECIFICATION_OF_CARTON_DIVIDERS> CARTON_DIVIDERS_specifications = new List<SH_SPECIFICATION_OF_CARTON_DIVIDERS>();
        List<SH_EMPLOYEES> stock_men = new List<SH_EMPLOYEES>();


        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        long p_length = 0;
        long p_width = 0;

        string mpallet_size = "";

        public carton_data_profile(string pallet_size , long anylength,long anywidth , SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS anypermission )
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;
            mpallet_size = pallet_size;

            p_length = anylength;
            p_width = anywidth;

        }
        async Task getstocksmantoexamination()
        {
            stock_men.Clear();
            try
            {
                string query = "SELECT EMP.* FROM SH_EMPLOYEES EMP ";
                query += " LEFT JOIN SH_DEPARTEMENTS DPT ON ";
                query += " DPT.SH_ID = EMP.SH_DEPARTMENT_ID ";
                query += " WHERE DPT.SH_DEPARTEMNT_NAME LIKE N'%مخازن%' ";
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stock_men.Add(new SH_EMPLOYEES()
                    {
                        SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                        SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(),
                        SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                        SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString(),
                        SH_DEPARTMENT_ID = long.Parse(reader["SH_DEPARTMENT_ID"].ToString()),
                        SH_DEPARTMENT_NAME = reader["SH_DEPARTMENT_NAME"].ToString(),
                        SH_EMPLOYEE_ADDRESS = reader["SH_EMPLOYEE_ADDRESS"].ToString(),
                        SH_EMPLOYEE_EMAIL = reader["SH_EMPLOYEE_EMAIL"].ToString(),
                        SH_EMPLOYEE_FUNCTION_ID = long.Parse(reader["SH_EMPLOYEE_FUNCTION_ID"].ToString()),
                        SH_EMPLOYEE_FUNCTION_NAME = reader["SH_EMPLOYEE_FUNCTION_NAME"].ToString(),
                        SH_EMPLOYEE_GENDER = reader["SH_EMPLOYEE_GENDER"].ToString(),
                        SH_EMPLOYEE_MOBILE = reader["SH_EMPLOYEE_MOBILE"].ToString(),
                        SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString(),
                        SH_EMPLOYEE_NATIONAL_ID = reader["SH_EMPLOYEE_NATIONAL_ID"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_EMPLOYEMENT_DATE = DateTime.Parse(reader["SH_EMPLOYEMENT_DATE"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING STOCK_MEN " + ex.ToString());
            }

            if (stock_men.Count > 0)
            {
                monitors_one.Items.Clear();
                monitors_two.Items.Clear();
                monitor_one_combo_box.Items.Clear();
                monitor_two_combo_box.Items.Clear();
                for (int i = 0; i < stock_men.Count; i++)
                {
                    monitors_one.Items.Add(stock_men[i].SH_EMPLOYEE_NAME);
                    monitors_two.Items.Add(stock_men[i].SH_EMPLOYEE_NAME);
                    monitor_one_combo_box.Items.Add(stock_men[i].SH_EMPLOYEE_NAME);
                    monitor_two_combo_box.Items.Add(stock_men[i].SH_EMPLOYEE_NAME);
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
                    stocks.Add(new SH_SHAHEEN_STOCK {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(),
                        SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(),
                        SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING STOCKS DATA FROM DB " + ex.ToString());
            }
            if (stocks.Count > 0)
            {
                stocks_combo_box.Items.Clear();
                stock_combo_box.Items.Clear();
                for (int i = 0; i < stocks.Count; i++)
                {
                    stocks_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                    stock_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);

                }
            }
        }

        async Task loadallCARTON_DIVIDERSsuppliers()
        {
            suppliers.Clear();
            try
            {
                myconnection.openConnection();
                string query = "select SC.* from SH_SUPPLY_COMPANY SC ";
                query += " LEFT JOIN SH_SUPPLIER_ITEMS SITM ON ";
                query += " SITM.SH_SUPPLIER_ID = SC.SH_ID ";
                query += " WHERE SITM.SH_ITEM_NAME LIKE '%فواصل كرتون%' ";
                query += " OR SITM.SH_ITEM_NAME LIKE '%فاصل كرتون%' ";
                query += " OR SITM.SH_ITEM_NAME LIKE '%فاصل كرتونى%'";
                query += " OR SITM.SH_ITEM_NAME LIKE '%فاصل كرتوني%'";
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY() {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(),
                        SH_SUPPLY_COMPANY_FAX = reader["SH_SUPPLY_COMPANY_FAX"].ToString(),
                        SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(),
                        SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(),
                        SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString()    
                    });
                }
                reader.Close();
                myconnection.closeConnection();
                    
            }
            catch (Exception ex )
            {
                MessageBox.Show("ERROR WHIle GETTInG SUPPLIERS DATA "+ex.ToString());
            }
            if (suppliers.Count >0)
            {
                suppliers_combo_box.Items.Clear();
                for (int i = 0; i < suppliers.Count; i++)
                {
                    suppliers_combo_box.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
                }
            }
        }

        async Task getstocktotalquantities()
        {
            try
            {
                myconnection.openConnection();
                string query = "SELECT COUNT(ADQP.SH_ID) AS TOTAL_QUANTITY FROM sh_individual_CARTON_DIVIDERS  ADQP  ";
                query += " LEFT JOIN SH_ADDED_QUANTITY_OF_CARTON_DIVIDERS AQP ON ";
                query += " AQP.SH_ID = ADQP.SH_ADDED_QUANTITY_OF_CARTON_DIVIDERS_ID ";
                query += " WHERE ADQP.SH_ID not in (select SH_INDIVIDUAL_CARTON_DIVIDERS_ID ";
                query += " from SH_EXCHANGE_OF_CARTON_DIVIDERS ) AND ";
                query += " AQP.SH_SIZE_LENGTH = @length  AND AQP.SH_SIZE_WIDTH = @width";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@length", p_length);
                cmd.Parameters.AddWithValue("@width", p_width);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    quantity_in_stocks_label.Text = reader["TOTAL_QUANTITY"].ToString();
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHile GETTING STOCkS QUANTITIES "+ex.ToString());
            }
        }

        async Task getallclientsdata()
        {
            clients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENTS_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY()
                    {
                        SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString()
                      ,
                        SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString()
                      ,
                        SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString()
                      ,
                        SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString()
                      ,
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG ALL CLIENTS DATA ");
            }
        }
        async Task fillclientscombobox()
        {
            await getallclientsdata();
            clients_combo_box.Items.Clear();
            clients_text_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                    clients_text_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }

        async Task fillclientsrecordsgridview()
        {
            try
            {
                string query = "select (SUM(SH_NO_PALLETS) - (select SUM(SH_QUANTITY_NO_ITEMS) as retured_quantities from SH_ADDED_QUANTITY_OF_PALLETS where SH_CLIENT_ID = SH_CLIENT_ID and SH_SIZE_LENGTH = @length and SH_SIZE_WIDTH = @width)) as PALLETS ,SUM(SH_NO_WOOD_WINCHES) as wooden_top , ";
                query += "(SELECT SH_CLIENT_COMPANY_NAME from SH_CLIENT_COMPANY where SH_CLIENT_COMPANY.SH_ID = SH_CLIENT_ID) as clientname  ";
                query += "from SH_RECEIVING_PERMISSION_INFORMATION ";
                query += "group by SH_CLIENT_ID ";
                clients_pallets_records_grid_view.Rows.Clear();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@length",p_length);
                cmd.Parameters.AddWithValue("@width",p_width);
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] row = new string[5];
                    row[0] = counter.ToString();
                    row[1] = reader["clientname"].ToString();
                    row[2] = reader["PALLETS"].ToString();
                    row[3] = 0.ToString();
                    row[4] = 0.ToString();
                    clients_pallets_records_grid_view.Rows.Add(row);
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE FillING CLIENTs RECORDS Grid VIEW "+ex.ToString());
            }
        }


        private async void pallet_data_profile_Load(object sender, EventArgs e)
        {
            await fillclientsrecordsgridview();
            await autogeneratepalletreturnpermissionnumber();
            await getstocksmantoexamination();
            await fillclientscombobox();
            await autogenerateCARTON_DIVIDERSreturnrequistnumber();
            await getstocktotalquantities();
            await loadallstocks();
            await loadallCARTON_DIVIDERSsuppliers();
            await autogeneratebottomaddtion_permission_number();
            await getstocktotalquantities();
            //op_tab_panel.TabPages[0].BackColor = Color.Green;
            tabPage1.Text = "إضافة";
            
            tabPage2.Text = "إرتجاع";
            tabPage3.Text = "طلب إرتجاع";
            tabPage4.Text = "بيان الكميات لدى العملاء";
            tabPage5.Text = "كارت الصنف";
            //    listView1.Items.Clear();
            //    // listView1.HeaderStyle = ColumnHeaderStyle.None;


            //    ColumnHeader h2 = new ColumnHeader();
            //    h2.Text = "إسم الصنف";
            //    h2.Width = 100;
            //    ColumnHeader h3 = new ColumnHeader();
            //    h3.Text = "المقاس";
            //    h3.Width = 150;
            //    ColumnHeader h4 = new ColumnHeader();
            //    h4.Text = "الرصيد فى المخزن";
            //    h4.Width = 150;
            //    listView1.Columns.AddRange(new ColumnHeader[]
            //    {h2,h3,h4 });
            //    ListViewItem anyitem = new ListViewItem(new string[]
            //    {
            //        "prometal" ,
            //    "الموظف المسئول : "+"أحمد محمد أحمد ",
            //    "نوع التوريد  : " + "داخلى"}, 0);


            //    ListViewItem anyitem2 = new ListViewItem(new string[]
            //  {  "prometal" ,
            //    "الموظف المسئول : "+"أحمد محمد أحمد ",
            //    "نوع التوريد  : " + "داخلى"}, 0);
            //    ListViewItem anyitem3 = new ListViewItem(new string[]
            //{  "prometal" ,
            //    "الموظف المسئول : "+"أحمد محمد أحمد ",
            //    "نوع التوريد  : " + "داخلى"}, 0);

            //    listView1.Items.Add(anyitem);
            //    listView1.Items.Add(anyitem2);
            //    listView1.Items.Add(anyitem3);

            pallet_size_label.Text = mpallet_size;
            pallet_size_text_box.Text = mpallet_size;
            quantity_in_production.Text = 0.ToString();
           // quantity_in_stocks_label.Text = 0.ToString();
            quantity_per_client_label.Text = 0.ToString();
            stock_man_text_box.Text = mEmployee.SH_EMPLOYEE_NAME;
            stock_man1_text_box.Text = mEmployee.SH_EMPLOYEE_NAME;
            requist_presenter_text_box.Text = mEmployee.SH_EMPLOYEE_NAME;

        }

        
        async Task autogeneratebottomaddtion_permission_number()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_CARTON_DIVIDERS_ADDITION_PERMISSION_NUMBER  ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (string.IsNullOrWhiteSpace(reader["lastedid"].ToString()))
                    {
                        reader.Close();
                    }
                    else
                    {
                        mycount = long.Parse(reader["lastedid"].ToString());
                    }
                }

                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                mycount = 0;
                //MessageBox.Show("Error while getting new permission number " + ex.ToString());
            }


            if (mycount == 0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                permissionnumber += "CARTON_DIVIDERS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                addition_permission_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber += "CARTON_DIVIDERS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                addition_permission_number_text_box.Text = permissionnumber;
            }
        }


        private void savenewpermssionnumber()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_CARTON_DIVIDERS_ADDITION_PERMISSION_NUMBER (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER", 1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        async Task autogeneratepalletreturnpermissionnumber()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_RETURN_PERMISSION_NUMBER  ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (string.IsNullOrWhiteSpace(reader["lastedid"].ToString()))
                    {
                        reader.Close();
                    }
                    else
                    {
                        mycount = long.Parse(reader["lastedid"].ToString());
                    }
                }

                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                mycount = 0;
                //MessageBox.Show("Error while getting new permission number " + ex.ToString());
            }


            if (mycount == 0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                permissionnumber += "RETURN_CARTON_DIVIDERS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                return_permission_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber += "RETURN_CARTON_DIVIDERS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                return_permission_number_text_box.Text = permissionnumber;
            }
        }


        private void savenewreturnpermission_number()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_RETURN_PERMISSION_NUMBER (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER", 1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        async Task autogenerateCARTON_DIVIDERSreturnrequistnumber()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER  ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (string.IsNullOrWhiteSpace(reader["lastedid"].ToString()))
                    {
                        reader.Close();
                    }
                    else
                    {
                        mycount = long.Parse(reader["lastedid"].ToString());
                    }
                }

                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                mycount = 0;
                //MessageBox.Show("Error while getting new permission number " + ex.ToString());
            }


            if (mycount == 0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                permissionnumber += "RE_CARTON_DIVIDERS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                return_requist_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber += "RE_CARTON_DIVIDERS-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                return_requist_number_text_box.Text = permissionnumber;
            }
        }


        private void savenewreturnrequistnumber()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER", 1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        async Task loadallCARTON_DIVIDERSspecifications()
        {
            CARTON_DIVIDERS_specifications.Clear();
            try
            {
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SPECIFICATION_OF_CARTON_DIVIDERS ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CARTON_DIVIDERS_specifications.Add(new SH_SPECIFICATION_OF_CARTON_DIVIDERS() {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_CARTON_DIVIDERS_LENGTH = long.Parse(reader["SH_CARTON_DIVIDERS_LENGTH"].ToString()),
                        SH_CARTON_DIVIDERS_WIDTH = long.Parse(reader["SH_CARTON_DIVIDERS_WIDTH"].ToString()),
                        SH_CARTON_DIVIDERS_SIZE_TEXT = reader["SH_CARTON_DIVIDERS_SIZE_TEXT"].ToString(),
                       
                        SH_TOTAL_QUANTITY = long.Parse(reader["SH_TOTAL_QUANTITY"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CARTON_DIVIDERS SPECIFICATIONS "+ex.ToString());
            }
        }
        async Task<long> check_if_pallet_specification_exists_or_not()
        {
            if (CARTON_DIVIDERS_specifications.Count>0)
            {
                for (int i = 0; i < CARTON_DIVIDERS_specifications.Count; i++)
                {
                    if (string.Compare(CARTON_DIVIDERS_specifications[i].SH_CARTON_DIVIDERS_SIZE_TEXT,pallet_size_text_box.Text)==0 )
                    {
                        return CARTON_DIVIDERS_specifications[i].SH_ID;
                    }
                }
            }
            return 0;
        }
        async Task <long> savenewCARTON_DIVIDERSpecification(long quantity )
        {
            try
            {
                myconnection.openConnection();
                string query = " INSERT INTO SH_SPECIFICATION_OF_CARTON_DIVIDERS ";
                query += " (SH_CARTON_DIVIDERS_LENGTH,  SH_CARTON_DIVIDERS_WIDTH, SH_TOTAL_QUANTITY, SH_CARTON_DIVIDERS_SIZE_TEXT) ";
                query += " VALUES(@SH_CARTON_DIVIDERS_LENGTH,  @SH_CARTON_DIVIDERS_WIDTH, @SH_TOTAL_QUANTITY, @SH_CARTON_DIVIDERS_SIZE_TEXT)";
                query += " SELECT SCOPE_IDENTITY() AS myidentity ";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_LENGTH", p_length);              
                cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_WIDTH", p_width);
                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY", quantity);
                cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_SIZE_TEXT", pallet_size_label.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW PALLET SPECIFICATION "+ex.ToString());
            }
            return 0;
        }
        async Task<long> saveexaminationofCARTON_DIVIDERS(string examination_number , long m_one , long m_two)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_EXAMINATION_RECORD_OF_CARTON_DIVIDERS" , DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_EXAMINATION_RECORD_NUMBER", examination_number);
                cmd.Parameters.AddWithValue("@SH_EXAMINATION_MONITOR_ONE_ID ", m_one);
                cmd.Parameters.AddWithValue("@SH_EXAMINATION_MONITOR_TWO_ID ", m_two);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID ",mAccount.SH_ID );
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID ", mEmployee.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE SAVING EXAMINATION OF CARTON_DIVIDERS "+ex.ToString());
            }
            return 0;
        }
        async Task  saveCARTON_DIVIDERSquantities(long sp_id,long quantity)
        {
            long ex_id = await saveexaminationofCARTON_DIVIDERS(examination_record_number_text_box.Text , stock_men[monitors_one.SelectedIndex].SH_ID , stock_men[monitors_two.SelectedIndex].SH_ID);
            if (ex_id == 0)
            {
                MessageBox.Show("  لايمكن حفظ الكمية لعدم وجود محضر فحص ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error ,MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                try
                {
                    myconnection.openConnection();
                    string query = "INSERT INTO SH_ADDED_QUANTITY_OF_CARTON_DIVIDERS ";
                    query += " ( SH_SPECIFICATION_OF_CARTON_DIVIDERS_ID ";
                    query += " ,SH_EXAMINATION_RECORD_OF_CARTON_DIVIDERS_ID ";
                    query += ", SH_CARTON_DIVIDER_SIZE_TEXT ";
                    query += "    ,SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += "  SH_DATA_ENTRY_USER_ID, ";
                    query += "  SH_ADDITION_PERMISSION_NUMBER, ";
                    query += " SH_ADDITION_DATE, SH_STOCK_MAN_ID, ";
                    query += " SH_SIZE_WIDTH, SH_SIZE_LENGTH, ";
                    query += " SH_QUANTITY_NO_ITEMS, ";
                    query += " SH_STOCK_ID, ";
                    query += " SH_SUPPLIER_ID) ";
                    query += " VALUES( ";
                    query += " @SH_SPECIFICATION_OF_CARTON_DIVIDERS_ID ";
                    query += " ,@SH_EXAMINATION_RECORD_OF_CARTON_DIVIDERS_ID ";
                    query += ", @SH_CARTON_DIVIDER_SIZE_TEXT , ";
                    query += " @SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += " @SH_DATA_ENTRY_USER_ID, @SH_ADDITION_PERMISSION_NUMBER, ";
                    query += " @SH_ADDITION_DATE, @SH_STOCK_MAN_ID, @SH_SIZE_WIDTH, ";
                    query += " @SH_SIZE_LENGTH, @SH_QUANTITY_NO_ITEMS, ";
                    query += " @SH_STOCK_ID, @SH_SUPPLIER_ID )";
                    query += " SELECT SCOPE_IDENTITY() AS myidentity";
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mEmployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", addition_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", mEmployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SIZE_WIDTH", p_width);
                    cmd.Parameters.AddWithValue("@SH_SIZE_LENGTH", p_length);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_NO_ITEMS", long.Parse(quantity_combo_box.Text));
                    cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID", suppliers[suppliers_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_CARTON_DIVIDERS_ID", sp_id);
                    cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDER_SIZE_TEXT", pallet_size_label.Text);
                    cmd.Parameters.AddWithValue("@SH_EXAMINATION_RECORD_OF_CARTON_DIVIDERS_ID", ex_id);
                    long myid = 0;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        myid = long.Parse(reader["myidentity"].ToString());
                    }
                    reader.Close();
                    myconnection.closeConnection();
                    await savenewindividaulCARTON_DIVIDERS(myid, quantity);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING NEW CARTON_DIVIDERS QUANTITIES " + ex.ToString());
                }
            }
           
        }

        async Task saveCARTON_DIVIDERSreturnquantities(long sp_id , long quantity)
        {
            long ex_id = await saveexaminationofCARTON_DIVIDERS(examination_record_number_textbox.Text , stock_men[monitor_one_combo_box.SelectedIndex].SH_ID , stock_men[monitor_two_combo_box.SelectedIndex].SH_ID);
            if (ex_id == 0)
            {
                MessageBox.Show("  لايمكن حفظ الكمية لعدم وجود محضر فحص ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                try
                {
                    myconnection.openConnection();
                    string query = "INSERT INTO SH_ADDED_QUANTITY_OF_CARTON_DIVIDERS ";
                    query += " ( SH_SPECIFICATION_OF_CARTON_DIVIDERS_ID ";
                    query += " ,SH_EXAMINATION_RECORD_OF_CARTON_DIVIDERS_ID ";
                    query += ", SH_CARTON_DIVIDER_SIZE_TEXT ";
                    query += "    ,SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += "  SH_DATA_ENTRY_USER_ID, ";
                    query += " SH_CLIENT_ID , SH_RETURN_PERMISSION_NUMBER ,SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER ,";
                    query += " SH_ADDITION_DATE, SH_STOCK_MAN_ID, ";
                    query += " SH_SIZE_WIDTH, SH_SIZE_LENGTH, ";
                    query += " SH_QUANTITY_NO_ITEMS, ";
                    query += " SH_STOCK_ID ";
                    query += "  ) ";
                    query += " VALUES( ";
                    query += " @SH_SPECIFICATION_OF_CARTON_DIVIDERS_ID ";
                    query += " ,@SH_EXAMINATION_RECORD_OF_CARTON_DIVIDERS_ID ";
                    query += ", @SH_CARTON_DIVIDERS_SIZE_TEXT , ";
                    query += " @SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += " @SH_DATA_ENTRY_USER_ID , ";
                    query += " @SH_CLIENT_ID , @SH_RETURN_PERMISSION_NUMBER ,@SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER ,";
                    query += " @SH_ADDITION_DATE, @SH_STOCK_MAN_ID, @SH_SIZE_WIDTH, ";
                    query += " @SH_SIZE_LENGTH, @SH_QUANTITY_NO_ITEMS, ";
                    query += " @SH_STOCK_ID  )";
                    query += " SELECT SCOPE_IDENTITY() AS myidentity";
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mEmployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_text_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", mEmployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SIZE_WIDTH", p_width);
                    cmd.Parameters.AddWithValue("@SH_SIZE_LENGTH", p_length);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_NO_ITEMS", quantity);
                    cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stock_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_CARTON_DIVIDERS_ID", sp_id);
                    cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_SIZE_TEXT", pallet_size_label.Text);
                    cmd.Parameters.AddWithValue("@SH_EXAMINATION_RECORD_OF_CARTON_DIVIDERS_ID", ex_id);
                    cmd.Parameters.AddWithValue("@SH_RETURN_PERMISSION_NUMBER", return_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER", client_return_permission_number.Text);
                    long myid = 0;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        myid = long.Parse(reader["myidentity"].ToString());
                    }
                    reader.Close();
                    myconnection.closeConnection();
                    await savenewindividaulCARTON_DIVIDERS(myid , quantity);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING NEW CARTON_DIVIDERS QUANTITIES " + ex.ToString());
                }
            }

        }


        async Task  updateCARTON_DIVIDERSspecification(long sp_id , long quantity)
        {
            try
            {
                myconnection.openConnection();
                string query = "UPDATE SH_SPECIFICATION_OF_CARTON_DIVIDERS ";
                query += " SET ";      
                query += " SH_TOTAL_QUANTITY = SH_TOTAL_QUANTITY + @SH_TOTAL_QUANTITY ";
                query += " WHERE SH_ID = @SH_ID ";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY",quantity);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE UPDATING SPECIFICATION QUANTITITES "+ex.ToString());
            }         
        }
        async Task savenewindividaulCARTON_DIVIDERS(long qu_id ,long quantity)
        {
            try
            {
                myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand("SH_SAVE_CARTON_DIVIDERS_INDIVIDUALS_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_QUANTITY_NUMBER", quantity);
                cmd.Parameters.AddWithValue("@SH_ADDED_QUANTITY_OF_CARTON_DIVIDERS_ID", qu_id);
                cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_SIZE_TEXT", pallet_size_label.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex )
            {
                MessageBox.Show("ERROR WHILE SAVING PALLET inDiviDuAL DATA "+ex.ToString());
            }
        }

        private async void save_new_pallets_quantity_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(quantity_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(suppliers_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(stocks_combo_box.Text))
            {
                cansave = false;
            }
            else if (!long.TryParse(quantity_combo_box.Text, out testnumber))
            {
                cansave = false;
            }else if (string.IsNullOrWhiteSpace(examination_record_number_text_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(monitors_one.Text))
            {
                cansave = false;
            }
            else if(string.IsNullOrWhiteSpace(monitors_two.Text))
            {
                cansave = false;
            }

            if (cansave)
            {
                await loadallCARTON_DIVIDERSspecifications();
                long sp_id = await check_if_pallet_specification_exists_or_not();
                if (sp_id==0)
                {
                    sp_id = await savenewCARTON_DIVIDERSpecification(long.Parse(quantity_combo_box.Text));
                     await saveCARTON_DIVIDERSquantities(sp_id , long.Parse(quantity_combo_box.Text));
                  
                }else
                {
                    await updateCARTON_DIVIDERSspecification(sp_id, long.Parse(quantity_combo_box.Text));
                    await saveCARTON_DIVIDERSquantities(sp_id, long.Parse(quantity_combo_box.Text));
                  
                }
                savenewpermssionnumber();
                await autogeneratebottomaddtion_permission_number();
                quantity_combo_box.Text = "";
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
              
            }
            else
            {
                MessageBox.Show("لا يمكن الحفظ لعدم إكتمال البيانات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private async void saverequist_andprint_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                cansave = false;
            }else if (string.IsNullOrWhiteSpace(driver_name_text_box.Text))
            {
                cansave = false;
            }

            if (cansave)
            {
                try
                {
                    myconnection.openConnection();
                    string query = "INSERT INTO SH_CARTON_DIVIDERS_RETURN_REQUIST ";
                    query += " (SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += "  SH_DATA_ENTRY_USER_ID, SH_ADDTION_DATE, ";
                    query += " SH_CLIENT_ID, SH_DRIVER_NAME, ";
                    query += " SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER) ";
                    query += " VALUES(@SH_DATA_ENTRY_EMPLOYEE_ID, ";
                    query += " @SH_DATA_ENTRY_USER_ID, @SH_ADDTION_DATE, ";
                    query += " @SH_CLIENT_ID, @SH_DRIVER_NAME,  ";
                    query += " @SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER )";
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mEmployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_ADDTION_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DRIVER_NAME", driver_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_CARTON_DIVIDERS_RETURN_REQUIST_NUMBER", return_requist_number_text_box.Text);
                   
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    savenewreturnrequistnumber();
                    string perm_numer = return_requist_number_text_box.Text;
                    await autogenerateCARTON_DIVIDERSreturnrequistnumber();
                    MessageBox.Show("تم الحفظ", "معلومات ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    printpalletreturnrequistform myform = new printpalletreturnrequistform(perm_numer);
                    myform.Show();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDICNG NEW RETURN PALLET REQUIST " + ex.ToString());
                }
            }else
            {
                MessageBox.Show("لا يمكن الحفظ لعدم إكتمال البيانات", "خطأ",MessageBoxButtons.OK ,MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private async void panel1_Enter(object sender, EventArgs e)
        {
            await autogeneratebottomaddtion_permission_number();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            quantity_combo_box.Text = "";
        }

        private async void save_return_pallet_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(return_permission_number_text_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(client_return_permission_number.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(clients_text_box.Text))
            {
                cansave = false;
            }
            else if (!long.TryParse(quantity_text_box.Text, out testnumber))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(examination_record_number_textbox.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(monitor_one_combo_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(monitor_two_combo_box.Text))
            {
                cansave = false;
            }

            if (cansave)
            {
                await loadallCARTON_DIVIDERSspecifications();
                long sp_id = await check_if_pallet_specification_exists_or_not();
                if (sp_id == 0)
                {
                    sp_id = await savenewCARTON_DIVIDERSpecification(long.Parse(quantity_text_box.Text));
                    await saveCARTON_DIVIDERSreturnquantities(sp_id, long.Parse(quantity_text_box.Text));

                }
                else
                {
                    await updateCARTON_DIVIDERSspecification(sp_id, long.Parse(quantity_text_box.Text));
                    await saveCARTON_DIVIDERSreturnquantities(sp_id , long.Parse(quantity_text_box.Text));

                }
                savenewreturnpermission_number();
                await autogeneratepalletreturnpermissionnumber();
                quantity_text_box.Text = "";
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
