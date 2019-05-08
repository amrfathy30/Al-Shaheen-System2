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
    public partial class addnewtwistofform : Form
    {

        List<SH_TWIST_OF_DATA> form_data = new List<SH_TWIST_OF_DATA>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();
        List<SH_TWIST_OF_TYPE> twist_of_types = new List<SH_TWIST_OF_TYPE>();
        List<SH_COLOR_PILLOW> color_pillows = new List<SH_COLOR_PILLOW>();
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_SPECIFICATION_OF_TWIST_OF> specifications = new List<SH_SPECIFICATION_OF_TWIST_OF>();
        List<SH_SPECIFICATION_OF_TWIST_OF> form_specifications = new List<SH_SPECIFICATION_OF_TWIST_OF>();

        List<SH_QUANTITY_OF_TWIST_OF> QUANTITIES = new List<SH_QUANTITY_OF_TWIST_OF>();
        List<SH_TWIST_OF_SIZE> sizes = new List<SH_TWIST_OF_SIZE>();
        List<SH_CONTAINER_OF_TWIST_OF> mcontainers = new List<SH_CONTAINER_OF_TWIST_OF>();
        List<string> item_types = new List<string>();

        public addnewtwistofform()
        {
            InitializeComponent();
        }

        long total_no_container_cartons = 0;
        long total_no_container_pallets = 0;
        long total_no_items_cartons = 0;
        long total_no_items_pallets = 0;


        void getallitemtypes()
        {
            try
            {
                item_types.Clear();
                
                    string query = "SELECT DISTINCT SH_KIND FROM SH_TWIST_OF_TYPE";
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        item_types.Add(reader["SH_KIND"].ToString());
                    }
                    reader.Close();
                    myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF TYPES KINDS "+ex.ToString());
            }
        }
        void fillitemtypescombobox()
        {
            item_type_combo_box.Items.Clear();
            getallitemtypes();
            if (item_types.Count>0)
            {
                for (int i = 0; i < item_types.Count; i++)
                {
                    item_type_combo_box.Items.Add(item_types[i]);
                }
            }
        }




        
        async Task getallstocks()
        {
            stocks.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_STOCKS ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString() , SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING STOCKS INFORMATION "+ex.ToString());
            }
        }
        async Task fillstockscombobox()
        {
             await getallstocks();
            this.Invoke((MethodInvoker)delegate ()
            {
                stock_combo_box.Items.Clear();
            });
            if (stocks.Count > 0)
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        stock_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                    });
                }
            }
        }
        async Task getallsupplier()
        {
            suppliers.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SUPPLIERS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_FAX = reader["SH_SUPPLY_COMPANY_FAX"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPPLIERS DATA " + ex.ToString());
            }
        }
        async Task fillsupplierscombobox()
        {
            suppliers_combo_box.Items.Clear();
            await getallsupplier();
            if (suppliers.Count > 0)
            {
                for (int i = 0; i < suppliers.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        suppliers_combo_box.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
                    });
                }
            }
        }
        async Task getallsupplierbranches(long supply_company_id)
        {
            supplier_branches.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SUPPLIER_COMPANTY_BRANCHES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_ID", supply_company_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    supplier_branches.Add(new SH_SUPPLY_COMPANY_BRANCHES() { SH_COMPANY_BRANCH_ADDRESS_GPS_LINK = reader["SH_COMPANY_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_COMPANY_BRANCH_ADDRESS_TEXT = reader["SH_COMPANY_BRANCH_ADDRESS_TEXT"].ToString(), SH_COMPANY_BRANCH_NAME = reader["SH_COMPANY_BRANCH_NAME"].ToString(), SH_COMPANY_BRANCH_TYPE = reader["SH_COMPANY_BRANCH_TYPE"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_ID = long.Parse(reader["SH_SUPPLY_COMPANY_ID"].ToString()), SH_SUPPLY_COMPANY_NAME = reader["SH_SUPPLY_COMPANY_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
              //  MessageBox.Show(supplier_branches.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPPLIER COMPANY BRANCHES " + ex.ToString());
            }
        }
        async Task fillsupplierbranchcombobox()
        {
            this.Invoke((MethodInvoker)delegate ()
            {
                supplier_branches_combo_box.Items.Clear();
            });

           // await getallsupplierbranches();


            if (supplier_branches.Count > 0)
            {
                for (int i = 0; i < supplier_branches.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        supplier_branches_combo_box.Items.Add(supplier_branches[i].SH_COMPANY_BRANCH_NAME);
                    });
                }
            }
        }
        async Task getalltwistoftypes()
        {
            twist_of_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_KIND" , item_types[item_type_combo_box.SelectedIndex]);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_types.Add(new SH_TWIST_OF_TYPE() { SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()), SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_LONG_TITLE = reader["SH_LONG_TITLE"].ToString(), SH_SHORT_TITLE = reader["SH_SHORT_TITLE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF TYPES DATA " + ex.ToString());
            }
        }
        async Task filltwisttypescombobox()
        {
            await getalltwistoftypes();
            twist_type_combo_box.Items.Clear();
           // MessageBox.Show(twist_of_types.Count.ToString());
            if (twist_of_types.Count > 0)
            {
                for (int i = 0; i < twist_of_types.Count; i++)
                {
                    //this.Invoke((MethodInvoker)delegate()
                    //{
                        twist_type_combo_box.Items.Add(twist_of_types[i].SH_SHORT_TITLE);
                    //});
                }
            }
        }
        async Task gettwistofcolorspillow()
        {
            color_pillows.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_COLORS_PILLOW", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    color_pillows.Add(new SH_COLOR_PILLOW() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_COLOR_CODE = reader["SH_COLOR_CODE"].ToString(), SH_COLOR_NAME = reader["SH_COLOR_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            } catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING COLOR PILLOW FROM DB " + ex.ToString());
            }

        }
        async Task fillwistofcolorpillowcombobox()
        {
            await gettwistofcolorspillow();
            client_product_combo_box.Items.Clear();
           
            if (color_pillows.Count > 0)
            {
                for (int i = 0; i < color_pillows.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        client_product_combo_box.Items.Add(color_pillows[i].SH_COLOR_NAME);
                    });
                }

            }
        }
        async Task getallclientsdata()
        {
            clients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENTS_DATA" , DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY() { SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString() , SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() , SH_CLIENT_COMPANY_TELEPHONE= reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString(), SH_CLIENT_COMPANY_TYPE= reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ClIENTS DATA "+ex.ToString());
            }
            

        }
        async Task fillclientscombobox()
        {
            clients_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                    });
                }
            }
        }
        async Task getallclientproducts(long client_id)
        {
            client_products.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_CLIENT_PRODUCTS_BY_CLIENT_ID", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", client_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_products.Add(new SH_CLIENTS_PRODUCTS() { SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) , SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()) , SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME= reader["SH_CLIENT_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME= reader["SH_PRODUCT_NAME"].ToString(), SH_SECOND_FACE_ID= long.Parse(reader["SH_SECOND_FACE_ID"].ToString()), SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() });
                }
                reader.Read();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GetTING CLIENT PRODUCTS DATA "+ex.ToString());
            }
        }        
        async Task fillclientproductscombobox()
        {
            client_product_combo_box.Items.Clear();
            if (client_products.Count > 0)
            {
                for (int i = 0; i < client_products.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        client_product_combo_box.Items.Add(client_products[i].SH_PRODUCT_NAME);
                    });
                }               
            }
        }
        async Task getallfacecolors()
        {
            faces.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_FACE_COLORS ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    faces.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACE COLORS "+ex.ToString());
            }
        }
        async Task getalltwistofsizes()
        {
            try
            {
                sizes.Clear();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_TWIST_OF_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TWIST_OF_SIZE_VALUE = long.Parse(reader["SH_TWIST_OF_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL TWIST OF SIZES DATA " + ex.ToString());
            }
        }

        async Task fillsizescombobox()
        {
            f2_combo_box.Items.Clear();
            await getalltwistofsizes();
            if (sizes.Count > 0)
            {
                for (int i = 0; i < sizes.Count; i++)
                {
                    f2_combo_box.Items.Add(sizes[i].SH_TWIST_OF_SIZE_VALUE.ToString());
                }
            }
        }


        async Task fillfacescombobox()
        {
            faces.Clear();
            this.Invoke((MethodInvoker)delegate ()
            {
                f1_combo_box.Items.Clear();
            });
            await getallfacecolors();
                if (faces.Count > 0)
            {
                for (int i = 0; i < faces.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        f1_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                    });
                }
            }
        }
        async Task<long> savetwistofspecification(SH_TWIST_OF_DATA mydata)
        {
         
            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SH_ADD_NEW_SPCIFICATION_OF_TWIST_OF", DatabaseConnection.mConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SH_CLIENT_ID", mydata.client.SH_ID);
            cmd.Parameters.AddWithValue("SH_SIZE_ID", mydata.size.SH_ID);
            cmd.Parameters.AddWithValue("SH_FACE_COLOR_ID", mydata.second_face.SH_ID);
            cmd.Parameters.AddWithValue("SH_TWIST_OF_TYPE_ID", mydata.twist_type.SH_ID);
            cmd.Parameters.AddWithValue("SH_TYPE", mydata.item_type);
            cmd.Parameters.AddWithValue("SH_CONTAINER_NAME", mydata.container_name);
            cmd.Parameters.AddWithValue("SH_NO_OF_CONTAINERS", mydata.no_of_containers);
            cmd.Parameters.AddWithValue("SH_TOTAL_NO_TEMS", mydata.total_no_items());

            if (mydata.first_face_pillow_or_not==1)
            {
                cmd.Parameters.AddWithValue("SH_PILLOW_COLOR_ID", mydata.pillow_color.SH_ID);
                cmd.Parameters.AddWithValue("SH_FIRST_FACE_PILLOW_OR_NOT", 1);
                cmd.Parameters.AddWithValue("SH_CLIENT_PRODUCT_ID", 0);

            } else
            {
                cmd.Parameters.AddWithValue("SH_PILLOW_COLOR_ID", 0);
                cmd.Parameters.AddWithValue("SH_FIRST_FACE_PILLOW_OR_NOT", 0);
                cmd.Parameters.AddWithValue("SH_CLIENT_PRODUCT_ID", mydata.product.SH_ID);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            long myidentity = 0;
            if (reader.Read())
            {
                myidentity = long.Parse(reader["myidentity"].ToString());
            }
            reader.Close();
            myconnection.closeConnection();
            return myidentity;
        }
        async Task<long> savetwistofquantities(long sp_id, SH_TWIST_OF_DATA mydata)
        {

            // MessageBox.Show(sp_id.ToString());
            // MessageBox.Show(quantity.containers.Count.ToString());
            //// MessageBox.Show(quantity.containers[0].SH_NO_ITEMS.ToString());
            //// MessageBox.Show(quantity.SH_TOTAL_NO_OF_ITEMS.ToString());
            // MessageBox.Show(quantity.SH_ADDITION_PERMISSION_NUMBER);
            // MessageBox.Show(quantity.SH_SUPPLIER_ID.ToString());
            // MessageBox.Show(quantity.SH_SUPPLIER_BRANCH_ID.ToString());
            try
            {
                //SH_SAVE_NEW_TWIST_OF_QUANTITIES
                myconnection.openConnection();
                string query = "INSERT INTO SH_QUANTITY_OF_TWIST_OF";
                query += "(SH_SUPPLIER_ID, SH_ADDITION_PERMISSION_NUMBER, SH_SUPPLIER_BRANCH_ID, SH_TOTAL_NO_OF_ITEMS, SH_NO_ITEMS_PER_CONTAINER, SH_NO_CONTAINERS, SH_SPECIFICATION_OF_TWIST_OF_ID,SH_CONTAINER_NAME)";
                query += " VALUES(@SH_SUPPLIER_ID,@SH_ADDITION_PERMISSION_NUMBER,@SH_SUPPLIER_BRANCH_ID,@SH_TOTAL_NO_OF_ITEMS,@SH_NO_ITEMS_PER_CONTAINER,@SH_NO_CONTAINERS,@SH_SPECIFICATION_OF_TWIST_OF_ID,@SH_CONTAINER_NAME)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
               // cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_TWIST_OF_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", mydata.no_of_item_per_container);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_OF_ITEMS", mydata.total_no_items());
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID", mydata.supplier.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_ID",mydata.supplier_branch.SH_ID);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                SqlDataReader reader = cmd.ExecuteReader();
                long myidentity = 0;
                if (reader.Read())
                {
                    myidentity = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myidentity;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING TWIST OFF QUANTITIES " + ex.ToString());
                return 0;
            }
            //return 0;

        }
        async Task savetwistofcontainers(long sp_id , long qu_id , SH_TWIST_OF_DATA mydata)
        {
            //MessageBox.Show(containers.Count.ToString());
            try
            {
                //DataTable dt = new DataTable();
                //dt.Columns.Add(new DataColumn("SH_QUANTITY_OF_TWIST_OF_ID",typeof(long)));
                //dt.Columns.Add(new DataColumn("SH_ADDITION_PERMISSION_NUMBER",typeof(string)));
                //dt.Columns.Add(new DataColumn("SH_ADDTION_DATE", typeof(DateTime)));
                //dt.Columns.Add(new DataColumn("SH_NO_ITEMS", typeof(long)));
                //dt.Columns.Add(new DataColumn("SH_CONTAINER_NAME", typeof(string)));
                string query = "INSERT INTO SH_CONTAINER_OF_TWIST_OF";
                query += "(SH_CONTAINER_NAME, SH_NO_ITEMS, SH_ADDITION_PERMISSION_NUMBER, SH_QUANTITY_OF_TWIST_OF_ID, SH_ADDTION_DATE)";
                query += " VALUES(@SH_CONTAINER_NAME,@SH_NO_ITEMS,@SH_ADDITION_PERMISSION_NUMBER,@SH_QUANTITY_OF_TWIST_OF_ID,@SH_ADDTION_DATE)";
                //for (int i = 0; i < containers.Count; i++)
                //{
                //  //  dt.Rows.Add(qu_id,containers[i].SH_ADDITION_PERMISSION_NUMBER,DateTime.Now ,containers[i].SH_NO_ITEMS, containers[i].SH_CONTAINER_NAME);
                //    dt.Rows.Add(0,0, DateTime.Now, 0, 0);
                //}
                // myconnection.openConnection();
                //SqlCommand cmd = new SqlCommand("SAVE_NEW_TWIST_OF_CONTAINER", DatabaseConnection.mConnection);
                //SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                // cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@SH_TWIST_OF_CONTAINER_DATA",dt);
                //MessageBox.Show(containers.Count.ToString());
               
                for (int i = 0; i < mydata.no_of_containers; i++)
                {
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                    cmd.Parameters.AddWithValue("@SH_NO_ITEMS", mydata.no_of_item_per_container);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_TWIST_OF_ID", qu_id);
                    cmd.Parameters.AddWithValue("@SH_ADDTION_DATE",mydata.AdditionDate);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
               //cmd.ExecuteNonQuery();    
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING TWIST of CONTAINERS "+ex.ToString());
            }
        }
        async Task getalltwistofspecification()
        {
            specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("GET_ALL_SPECIFICATION_OF_TWIST_OF", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_TWIST_OF() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_FACE_COLOR_ID = long.Parse(reader["SH_FACE_COLOR_ID"].ToString()), SH_FIRST_FACE_PILLOW_OR_NOT = long.Parse(reader["SH_FIRST_FACE_PILLOW_OR_NOT"].ToString()), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()), SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_TWIST_OF_TYPE_ID = long.Parse(reader["SH_TWIST_OF_TYPE_ID"].ToString()), SH_TYPE = reader["SH_TYPE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL TWIST_OF SPECIFICATIONS ");
            }
        }
        async Task<long> CHECK_IF_SPECIFICATION_EXISTS_OR_NOT(SH_TWIST_OF_DATA mydata)
        {
            specifications.Clear();
            await getalltwistofspecification();

            if (specifications.Count > 0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if (specifications[i].SH_CLIENT_ID == mydata.client.SH_ID && specifications[i].SH_SIZE_ID == mydata.size.SH_ID && specifications[i].SH_TWIST_OF_TYPE_ID == mydata.twist_type.SH_ID && string.Compare(specifications[i].SH_CONTAINER_NAME, mydata.container_name) == 0 && specifications[i].SH_FACE_COLOR_ID == mydata.second_face.SH_ID)
                    {
                        if (mydata.first_face_pillow_or_not==1 && specifications[i].SH_PILLOW_COLOR_ID == mydata.pillow_color.SH_ID)
                        {
                            return specifications[i].SH_ID;
                        }
                        else if ((mydata.first_face_pillow_or_not != 1) && specifications[i].SH_CLIENT_PRODUCT_ID == mydata.product.SH_ID)
                        {
                            return specifications[i].SH_ID;
                        }
                    }
                }
            }
            else
            {
                //try
                //{
                //    myconnection.openConnection();
                //    SqlCommand cmd = new SqlCommand("CHECK_IF_TWIST_OF_EXISTS", DatabaseConnection.mConnection);
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                //    if (pillow_check_box.Checked)
                //    {
                //        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", 0);
                //        cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", color_pillows[client_product_combo_box.SelectedIndex].SH_ID);
                //    }else
                //    {
                //        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_product_combo_box.SelectedIndex].SH_ID);
                //        cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", 0);
                //    }
                //    MessageBox.Show("GETTING");

                //    cmd.Parameters.AddWithValue("@SH_SIZE_ID", sizes[f2_combo_box.SelectedIndex].SH_ID);               
                //    cmd.Parameters.AddWithValue("@SH_FACE_COLOR_ID", faces[f1_combo_box.SelectedIndex].SH_ID);
                //    cmd.Parameters.AddWithValue("@SH_TWIST_OF_TYPE_ID", twist_of_types[twist_type_combo_box.SelectedIndex].SH_ID);
                //    cmd.Parameters.AddWithValue("@SH_TYPE", item_type_combo_box.Text);
                //    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", container_type_combo_box.Text);
                //    SqlDataReader reader = cmd.ExecuteReader();
                //    MessageBox.Show("IN");
                //    while (reader.Read())
                //    {
                //        specifications.Add(new SH_SPECIFICATION_OF_TWIST_OF() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()) , SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString() , SH_FACE_COLOR_ID = long.Parse(reader["SH_FACE_COLOR_ID"].ToString()) , SH_FIRST_FACE_PILLOW_OR_NOT = long.Parse(reader["SH_FIRST_FACE_PILLOW_OR_NOT"].ToString()) , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()), SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()) , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , SH_TWIST_OF_TYPE_ID = long.Parse(reader["SH_TWIST_OF_TYPE_ID"].ToString()) , SH_TYPE = reader["SH_TYPE"].ToString() });
                //    }
                //    MessageBox.Show("OUT");
                //    reader.Close();
                //    myconnection.closeConnection();
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("ERROR WHILE ADDING TWIST OFF SPECIFICATION  "+ex.ToString());
                //}
                return 0;
            }
            return 0;
        }
        async Task UPDATE_TWIST_OF_SPECIFICATIONS(long SP_ID , SH_TWIST_OF_DATA mydata )
        {

            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_TWIST_OF_SPECIFICATION_QUANTITIES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_ID" , SP_ID);
                //this.Invoke((MethodInvoker)delegate()
                //{
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_TEMS", mydata.total_no_items());
                //});
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS" ,mydata.no_of_containers );
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("Success updating specifications");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATIONS OBJECT "+ex.ToString());
            }

           
        }
        void calculatenoitemsofquantity()
        {
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(no_items_per_container.Text) || string.IsNullOrWhiteSpace(no_of_containers_text_box.Text))
            {
                no_items_per_quantity.Text = "";
            }
            else
            {
                if (long.TryParse(no_items_per_container.Text, out testnumber) && long.TryParse(no_of_containers_text_box.Text, out testnumber))
                {
                    no_items_per_quantity.Text = (long.Parse(no_items_per_container.Text) * long.Parse(no_of_containers_text_box.Text)).ToString();
                }
            }
        }
        void calculatenoitemsofunsimilarquantity()
        {
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(unsimilar_no_items_per_container.Text) || string.IsNullOrWhiteSpace(unsimilar_no_of_containers.Text))
            {
                unsimilar_no_items_per_quantity.Text = "";
            }
            else
            {
                if (long.TryParse(unsimilar_no_items_per_container.Text, out testnumber) && long.TryParse(unsimilar_no_of_containers.Text, out testnumber))
                {
                    unsimilar_no_items_per_quantity.Text = (long.Parse(unsimilar_no_items_per_container.Text) * (long.Parse(unsimilar_no_of_containers.Text))).ToString();
                }
            }
        }
        void calculatetotalnoofitems()
        {
            if (!string.IsNullOrWhiteSpace(no_items_per_quantity.Text) && !string.IsNullOrWhiteSpace(unsimilar_no_items_per_quantity.Text))
            {
                total_number_of_items_text_box.Text = (long.Parse(no_items_per_quantity.Text)+long.Parse(unsimilar_no_items_per_quantity.Text)).ToString();
            }
            else if (!string.IsNullOrWhiteSpace(no_items_per_quantity.Text))
            {
                total_number_of_items_text_box.Text = no_items_per_quantity.Text;
            }
            else if(!string.IsNullOrWhiteSpace(unsimilar_no_items_per_quantity.Text))
            {
                total_number_of_items_text_box.Text = unsimilar_no_items_per_quantity.Text;
            }
        }
        private void add_new_twist_of_timer_Tick(object sender, EventArgs e)
        {
            timer_label.Text = DateTime.Now.ToShortDateString();
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private void twist_type_combo_box_DrawItem(object sender, DrawItemEventArgs e)
        {
              
        }
        private async void addnewtwistofform_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            await fillsupplierscombobox();
           // await getalltwistoftypes();
            //await filltwisttypescombobox();
            await fillstockscombobox();
            await getallclientsdata();
            await fillclientscombobox();
            await fillfacescombobox();
            await fillsizescombobox();
            fillitemtypescombobox();
            no_of_containers_text_box.Enabled = true;
            no_items_per_container.Enabled = true;
            unsimilar_no_items_per_container.Enabled = false;
            unsimilar_no_of_containers.Enabled = false;
            Cursor.Current = Cursors.Default;
        }
        async void savetwistofdata()
        {
            try
            {
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        
                            long sp_id = await CHECK_IF_SPECIFICATION_EXISTS_OR_NOT(form_data[i]);
                            if (sp_id!=0)
                            {
                                await UPDATE_TWIST_OF_SPECIFICATIONS(sp_id,form_data[i]);
                                long qu_id = await savetwistofquantities(sp_id , form_data[i]);
                                //MessageBox.Show("Quantity id : "+qu_id.ToString());
                                await savetwistofcontainers(sp_id, qu_id , form_data[i]);
                            }else
                            {
                                sp_id = await savetwistofspecification(form_data[i]);
                                long qu_id = await savetwistofquantities(sp_id, form_data[i]);
                               // MessageBox.Show("Quantity id : " + qu_id.ToString());
                                await savetwistofcontainers(sp_id, qu_id, form_data[i]);
                            }                                                                 
                    }
                }
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE SAVE " + ex.ToString());
                MessageBox.Show("لم يتم الحفظ بنجاح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }
        private async void addnewtwistofform_ControlAdded(object sender, ControlEventArgs e)
        {
           
        }
        private void add_new_quantity_button_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            if (string.IsNullOrWhiteSpace(suppliers_combo_box.Text))
            {
                supplier_error_provier.SetError(suppliers_combo_box,"لابد من إدخال إسم المورد");
                cansave = false;
            }else
            {
                supplier_error_provier.Clear();
            }
            if (string.IsNullOrWhiteSpace(supplier_branches_combo_box.Text))
            {
                supplier_branches_error_provider.SetError(supplier_branches_combo_box, "لابد من تحديد إسم فرع المورد");
                cansave = false;
            }else
            {
                supplier_branches_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(stock_combo_box.Text))
            {
                stocks_combo_box_error_provider.SetError(stock_combo_box , "لابد من تحديد إسم المخزن ");
                cansave = false;
            }else
            {
                stocks_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(addition_permission_number_text_box.Text))
            {
                addition_permission_number_error_provider.SetError(addition_permission_number_text_box, "لابد من إدخال رقم إذن الإضافة");
                cansave = false;
            }else
            {
                addition_permission_number_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                clients_combo_box_error_provider.SetError(clients_combo_box ," لابد من تحديد إسم العميل");
                cansave = false;
            }else
            {
                clients_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(client_product_combo_box.Text))
            {
                client_product_combo_box_error_provide.SetError(client_product_combo_box, "لابد من إختيار إسم الصنف للعميل");
                cansave = false;
            }else
            {
                client_product_combo_box_error_provide.Clear();
            }
            if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
            {
                f1_combo_box_error_provider.SetError(f1_combo_box,"لابد من تحديد الورنيش الداخلى");
                cansave = false;
            }else
            {
                f1_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
            {
                f2_combo_box_error_provider.SetError(f2_combo_box,"لابد من تحديد المقاس");
                cansave = false;
            }else
            {
                f2_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(twist_type_combo_box.Text))
            {
                twist_type_combo_box_error_provider.SetError(twist_type_combo_box,"لابد من تحديد نوع التويست أوف");
                cansave = false;
            }else
            {
                twist_type_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(item_type_combo_box.Text))
            {
                item_type_combo_box_error_provider.SetError(item_type_combo_box,"لابد من تحديد نوع التويست");
                cansave = false;
            }else
            {
                item_type_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(container_type_combo_box.Text))
            {
                container_type_combo_box_error_provider.SetError(container_type_combo_box, "لابد من تحديد نوع التعبئة");
                cansave = false;
            }else
            {
                container_type_combo_box_error_provider.Clear();
            }
            if (!unsimilarquantities_check_box.Checked)
            {
                if (string.IsNullOrWhiteSpace(no_of_containers_text_box.Text))
                {
                    no_of_container_text_box_error_provider.SetError(no_of_containers_text_box , "لابد من كتابة العدد");
                    cansave = false;
                }else
                {
                    no_of_container_text_box_error_provider.Clear();
                }
                if (string.IsNullOrWhiteSpace(no_items_per_container_text_box.Text))
                {
                    no_of_items_per_container_error_provider.SetError(no_items_per_container_text_box, "لابد من كتابة العدد");
                    cansave = false;
                }else
                {
                    no_of_items_per_container_error_provider.Clear();
                }               
            }else
            {
                if (string.IsNullOrWhiteSpace(unsimilar_no_of_containers.Text))
                {
                    unsimilar_no_of_containers_error_provider.SetError(unsimilar_no_of_containers, "لابد من كتابة العدد");
                    cansave = false;
                }else
                {
                    unsimilar_no_of_containers_error_provider.Clear();
                }
                if (string.IsNullOrWhiteSpace(unsimilar_no_items_per_container.Text))
                {
                    unsimilar_no_items_per_container_error_provider.SetError(unsimilar_no_items_per_container, "لابد من كتابة العدد");
                    cansave = false;
                }else
                {
                    unsimilar_no_items_per_container_error_provider.Clear();
                }
            }
            if (cansave)
            {

                try
                {
                    if (pillow_check_box.Checked)
                    {
                        if (unsimilarquantities_check_box.Checked)
                        {
                            form_data.Add(new SH_TWIST_OF_DATA() { AdditionDate = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, client = clients[clients_combo_box.SelectedIndex], container_name = container_type_combo_box.Text, first_face_pillow_or_not = 1, item_type = item_type_combo_box.Text, product = null, size = sizes[f2_combo_box.SelectedIndex], pillow_color = color_pillows[client_product_combo_box.SelectedIndex], supplier = suppliers[suppliers_combo_box.SelectedIndex], twist_type = twist_of_types[twist_type_combo_box.SelectedIndex], supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex], second_face = faces[f1_combo_box.SelectedIndex], no_of_containers = long.Parse(unsimilar_no_of_containers.Text), no_of_item_per_container = long.Parse(unsimilar_no_items_per_container.Text) });
                        }
                        else
                        {
                            form_data.Add(new SH_TWIST_OF_DATA() { AdditionDate = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, client = clients[clients_combo_box.SelectedIndex], container_name = container_type_combo_box.Text, first_face_pillow_or_not = 1, item_type = item_type_combo_box.Text, product = null, size = sizes[f2_combo_box.SelectedIndex], pillow_color = color_pillows[client_product_combo_box.SelectedIndex], supplier = suppliers[suppliers_combo_box.SelectedIndex], twist_type = twist_of_types[twist_type_combo_box.SelectedIndex], supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex], second_face = faces[f1_combo_box.SelectedIndex], no_of_containers = long.Parse(no_of_containers_text_box.Text), no_of_item_per_container = long.Parse(no_items_per_container.Text) });
                        }
                    }
                    else
                    {
                        if (unsimilarquantities_check_box.Checked)
                        {
                            form_data.Add(new SH_TWIST_OF_DATA() { AdditionDate = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, client = clients[clients_combo_box.SelectedIndex], container_name = container_type_combo_box.Text, first_face_pillow_or_not = 0, item_type = item_type_combo_box.Text, product = client_products[client_product_combo_box.SelectedIndex], size = sizes[f2_combo_box.SelectedIndex], pillow_color = null, supplier = suppliers[suppliers_combo_box.SelectedIndex], twist_type = twist_of_types[twist_type_combo_box.SelectedIndex], supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex], second_face = faces[f1_combo_box.SelectedIndex], no_of_containers = long.Parse(unsimilar_no_of_containers.Text), no_of_item_per_container = long.Parse(unsimilar_no_items_per_container.Text) });
                        }
                        else
                        {
                            form_data.Add(new SH_TWIST_OF_DATA() { AdditionDate = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, client = clients[clients_combo_box.SelectedIndex], container_name = container_type_combo_box.Text, first_face_pillow_or_not = 0, item_type = item_type_combo_box.Text, product = client_products[client_product_combo_box.SelectedIndex], size = sizes[f2_combo_box.SelectedIndex], pillow_color = null, supplier = suppliers[suppliers_combo_box.SelectedIndex], twist_type = twist_of_types[twist_type_combo_box.SelectedIndex], supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex], second_face = faces[f1_combo_box.SelectedIndex], no_of_containers = long.Parse(no_of_containers_text_box.Text), no_of_item_per_container = long.Parse(no_items_per_container.Text) });
                        }
                    }
                    
                }catch(Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING NEW QUAntITY"+ex.ToString());
                }
                filltwistofgridview();
                // mcontainers.Clear();
            }
        }

        int check_if_specification_exists_or_not()
        {
            if (form_specifications.Count > 0)
            {
                for (int i = 0; i < form_specifications.Count; i++)
                {
                    long client_id = clients[clients_combo_box.SelectedIndex].SH_ID;
                    string clientname = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME;
                    long pillow_or_not = 0;
                    long client_product_id = 0;
                    string client_product_name = "0";
                    long pillow_color_id = 0;
                    string pillow_color_name = "0";
                    if (pillow_check_box.Checked)
                    {
                        pillow_or_not = 1;
                        pillow_color_id = color_pillows[client_product_combo_box.SelectedIndex].SH_ID;
                        pillow_color_name = color_pillows[client_product_combo_box.SelectedIndex].SH_COLOR_NAME;
                    } else
                    {
                        pillow_or_not = 0;
                        client_product_id = client_products[client_product_combo_box.SelectedIndex].SH_ID;
                        client_product_name = client_products[client_product_combo_box.SelectedIndex].SH_PRODUCT_NAME;
                     }
                    long size_id = sizes[f2_combo_box.SelectedIndex].SH_ID;
                    string sizetitle = sizes[f2_combo_box.SelectedIndex].SH_TWIST_OF_SIZE_VALUE.ToString();
                    long face_id = faces[f1_combo_box.SelectedIndex].SH_ID;
                    string face_name = faces[f1_combo_box.SelectedIndex].SH_FACE_COLOR_NAME;
                    long twist_type_id = twist_of_types[twist_type_combo_box.SelectedIndex].SH_ID;
                    string twist_type_name = twist_of_types[twist_type_combo_box.SelectedIndex].SH_SHORT_TITLE;
                    string item_type = item_type_combo_box.Text;

                    if (form_specifications[i].SH_CLIENT_ID==client_id  && string.Compare(form_specifications[i].clientname,clientname)==0 && form_specifications[i].SH_FACE_COLOR_ID == face_id && string.Compare(form_specifications[i].SH_CONTAINER_NAME, container_type_combo_box.Text)==0 && form_specifications[i].SH_TWIST_OF_TYPE_ID == twist_type_id && string.Compare(form_specifications[i].SH_TYPE,item_type)==0 && form_specifications[i].SH_SIZE_ID == size_id)
                    {
                        if (pillow_or_not==1)
                        {

                            if (form_specifications[i].SH_PILLOW_COLOR_ID == pillow_color_id)
                            {
                                return i;
                            }

                        }else
                        {
                            if (form_specifications[i].SH_CLIENT_PRODUCT_ID == client_product_id)
                            {
                                return i;
                            }
                        }
                    }



                }
            }
            return -1;
        }

        int addnewspecification ()
        {
            int res = check_if_specification_exists_or_not();
            if (res != -1)
            {
                //there is one 
                //return this 
                return res;
            }
            else
            {


                long client_id = clients[clients_combo_box.SelectedIndex].SH_ID;
                string clientname = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME;
                long pillow_or_not = 0;
                long client_product_id = 0;
                string client_product_name = "0";
                long pillow_color_id = 0;
                string pillow_color_name = "0";
                if (pillow_check_box.Checked)
                {
                    pillow_or_not = 1;
                    pillow_color_id = color_pillows[client_product_combo_box.SelectedIndex].SH_ID;
                    pillow_color_name = color_pillows[client_product_combo_box.SelectedIndex].SH_COLOR_NAME;
                }
                else
                {
                    pillow_or_not = 0;
                    client_product_id = client_products[client_product_combo_box.SelectedIndex].SH_ID;
                    client_product_name = client_products[client_product_combo_box.SelectedIndex].SH_PRODUCT_NAME;
                }
                long size_id = sizes[f2_combo_box.SelectedIndex].SH_ID;
                string sizetitle = sizes[f2_combo_box.SelectedIndex].SH_TWIST_OF_SIZE_VALUE.ToString();
                long face_id = faces[f1_combo_box.SelectedIndex].SH_ID;
                string face_name = faces[f1_combo_box.SelectedIndex].SH_FACE_COLOR_NAME;
                long twist_type_id = twist_of_types[twist_type_combo_box.SelectedIndex].SH_ID;
                string twist_type_name = twist_of_types[twist_type_combo_box.SelectedIndex].SH_SHORT_TITLE;
                string item_type = item_type_combo_box.Text;

                SH_SPECIFICATION_OF_TWIST_OF anyspecification = new SH_SPECIFICATION_OF_TWIST_OF();
                anyspecification.clientname = clientname;
                anyspecification.clientproductname = client_product_name;
                anyspecification.SH_CLIENT_ID = client_id;
                anyspecification.SH_CLIENT_PRODUCT_ID = client_product_id;
                anyspecification.SH_CONTAINER_NAME = container_type_combo_box.Text;
                anyspecification.SH_FACE_COLOR_ID = face_id;
                anyspecification.facecolorname = face_name;
                anyspecification.SH_FIRST_FACE_PILLOW_OR_NOT = pillow_or_not;
             //   anyspecification.






            }
            return -1;
        }




        void filltwistofgridview()
        {
            twist_of_quantities_grid_view.Rows.Clear();
            if (form_data.Count>0)
            {
                for (int i = 0; i < form_data.Count; i++)
                {
                    string[] myitem = new string[11];
                    myitem[0] = (i+1).ToString();
                    myitem[1] = form_data[i].supplier.SH_SUPPLY_COMAPNY_NAME;
                    myitem[2] = form_data[i].client.SH_CLIENT_COMPANY_NAME;
                    if (form_data[i].first_face_pillow_or_not==1)
                    {
                        myitem[3] = form_data[i].pillow_color.SH_COLOR_NAME;
                    }else
                    {
                        myitem[3] = form_data[i].product.SH_PRODUCT_NAME;
                    }
                    //MessageBox.Show("here");
                    myitem[4] = form_data[i].size.SH_TWIST_OF_SIZE_VALUE.ToString();
                    myitem[5] = form_data[i].twist_type.SH_SHORT_TITLE;
                    myitem[6] = form_data[i].second_face.SH_FACE_COLOR_NAME;
                    myitem[7] = form_data[i].container_name;                  
                    myitem[8] = form_data[i].no_of_containers.ToString();
                    myitem[9] = form_data[i].no_of_item_per_container.ToString();
                    myitem[10] = form_data[i].total_no_items().ToString();
                    // myitem[9] = ;
                    twist_of_quantities_grid_view.Rows.Add(myitem);

                }
            }
        }


        private async void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (pillow_check_box.Checked)
            {
                //fill client_product_combo_box with pillow colors
                client_product_combo_box.Text = "";
                client_product_combo_box.Items.Clear();
                client_products_label.Text = "اللون";

                await fillwistofcolorpillowcombobox();
            }
            else
            {
                //fill client_product_combo_box with client products
                if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
                {
                    client_product_combo_box.Text = "";
                    client_product_combo_box.Items.Clear();
                    client_products_label.Text = "إسم الصنف";
                    await getallclientproducts(clients[clients_combo_box.SelectedIndex].SH_ID);
                    await fillclientproductscombobox();
                }else
                {
                    MessageBox.Show(" لابد من تحديد العميل أولا ", "تحذير" , MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }
        }
        private async void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                if (clients_combo_box_error_provider.GetError(clients_combo_box) !="")
                {
                    clients_combo_box_error_provider.Clear();
                }
            }
            if (pillow_check_box.Checked)
            {

            }
            else
            {            
                
                client_product_combo_box.Text = "";
                await getallclientproducts(clients[clients_combo_box.SelectedIndex].SH_ID);
                await fillclientproductscombobox();
            }   
        }
        private async void client_product_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private async void suppliers_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(suppliers_combo_box.Text))
            {
                if (supplier_error_provier.GetError(suppliers_combo_box)!="")
                {
                    supplier_error_provier.Clear();
                }
                // fill supplier branches combo box 
                await getallsupplierbranches(suppliers[suppliers_combo_box.SelectedIndex].SH_ID);
                await fillsupplierbranchcombobox();
            }
            else
            {
                MessageBox.Show("لابد من تحديد إسم المورد أولا", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void container_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            no_of_containers_label.Text = "عدد "+container_type_combo_box.Text;
            unsimilar_no_of_containers_label.Text = "عدد "+ container_type_combo_box.Text;
            unsimilar_no_items_per_container_label.Text = "الكمية / " + container_type_combo_box.Text;
            no_items_per_container_text_box.Text = "الكمية / " + container_type_combo_box.Text;
        }

        private void no_of_containers_text_box_TextChanged(object sender, EventArgs e)
        {
            calculatenoitemsofquantity();
        }

        private void no_items_per_container_TextChanged(object sender, EventArgs e)
        {
            calculatenoitemsofquantity();
        }

        private void unsimilar_no_of_containers_TextChanged(object sender, EventArgs e)
        {
            calculatenoitemsofunsimilarquantity();
        }

        private void unsimilar_no_items_per_container_TextChanged(object sender, EventArgs e)
        {
            calculatenoitemsofunsimilarquantity();
        }

        private void no_items_per_quantity_TextChanged(object sender, EventArgs e)
        {
            calculatetotalnoofitems();
        }

        private void unsimilar_no_items_per_quantity_TextChanged(object sender, EventArgs e)
        {
            calculatetotalnoofitems();
        }

        private void unsimilarquantities_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (unsimilarquantities_check_box.Checked)
            {
                no_of_containers_text_box.Enabled = false;
                no_items_per_container.Enabled = false;
                unsimilar_no_items_per_container.Enabled = true;
                unsimilar_no_of_containers.Enabled = true;
            }
            else
            {
                no_of_containers_text_box.Enabled = true;
                no_items_per_container.Enabled = true;
                unsimilar_no_items_per_container.Enabled = false;
                unsimilar_no_of_containers.Enabled = false;
            }
        }

        private void supplier_branches_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(supplier_branches_combo_box.Text))
            {
                if (supplier_branches_error_provider.GetError(supplier_branches_combo_box)!="")
                {
                    supplier_branches_error_provider.Clear();
                }
                
            }
        }

        private void stock_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(stock_combo_box.Text))
            {
                if (stocks_combo_box_error_provider.GetError(stock_combo_box) != "")
                {
                    stocks_combo_box_error_provider.Clear();
                }
            }
        }

        private void addition_permission_number_text_box_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(addition_permission_number_text_box.Text))
            {
                if (addition_permission_number_error_provider.GetError(addition_permission_number_text_box)!="")
                {
                    addition_permission_number_error_provider.Clear();
                }
            }
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            savetwistofdata();     
        }

        private void item_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            getalltwistoftypes();
            filltwisttypescombobox();
        }

        private void remove_quantity_button_Click(object sender, EventArgs e)
        {
            if (twist_of_quantities_grid_view.SelectedRows.Count > 0)
            {

                form_data.RemoveAt(twist_of_quantities_grid_view.SelectedRows[0].Index);
                filltwistofgridview();

            }else
            {
                MessageBox.Show("لم يتم تحديد الكمية المراد حزفها");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewtwistofform myform = new addnewtwistofform())
            {
                myform.ShowDialog();
            }
            this.Close();
        }
    }
}
