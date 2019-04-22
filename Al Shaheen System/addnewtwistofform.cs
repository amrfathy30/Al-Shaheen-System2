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
        DatabaseConnection myconnection = new DatabaseConnection();

        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();
        List<SH_TWIST_OF_TYPE> twist_of_types = new List<SH_TWIST_OF_TYPE>();
        List<SH_COLOR_PILLOW> color_pillows = new List<SH_COLOR_PILLOW>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        public addnewtwistofform()
        {
            InitializeComponent();
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
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANTY_ID", supply_company_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    supplier_branches.Add(new SH_SUPPLY_COMPANY_BRANCHES() { SH_COMPANY_BRANCH_ADDRESS_GPS_LINK = reader["SH_COMPANY_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_COMPANY_BRANCH_ADDRESS_TEXT = reader["SH_COMPANY_BRANCH_ADDRESS_TEXT"].ToString(), SH_COMPANY_BRANCH_NAME = reader["SH_COMPANY_BRANCH_NAME"].ToString(), SH_COMPANY_BRANCH_TYPE = reader["SH_COMPANY_BRANCH_TYPE"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_ID = long.Parse(reader["SH_SUPPLY_COMAPNY_ID"].ToString()), SH_SUPPLY_COMPANY_NAME = reader["SH_SUPPLY_COMPANY_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPPLIER COMPANY BRANCHES " + ex.ToString());
            }
        }
        async Task fillsupplierbranchcombobox()
        {
            supplier_branches_combo_box.Items.Clear();
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
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_TYPES", DatabaseConnection.mConnection);
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
            twist_type_combo_box.Items.Clear();
            if (twist_of_types.Count > 0)
            {
                for (int i = 0; i < twist_of_types.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        twist_type_combo_box.Items.Add(twist_of_types[i].SH_SHORT_TITLE + " \n " + twist_of_types[i].SH_LONG_TITLE.ToLowerInvariant());
                    });
                }
            }
        }
        async Task gettwistofcolorspillow()
        {
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
            if (color_pillows.Count > 0)
            {
                for (int i = 0; i < color_pillows.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        f1_combo_box.Items.Add(color_pillows[i].SH_COLOR_NAME);
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
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY() { SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString() , SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() , SH_CLIENT_COMPANY_TELEPHONE= reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString(), SH_CLIENT_COMPANY_TYPE= reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_ID = long.Parse("SH_ID") });
                }
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
                        clients_combo_box.Items.Add(clients[i].ToString());
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
        async Task<long> savetwistofspecification()
        {
            long size_id = 0;
            long pillow_color_id = 0;
            long face_color_id = 0;
            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SH_ADD_NEW_SPCIFICATION_OF_TWIST_OF", DatabaseConnection.mConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("SH_CLIENT_ID",clients[clients_combo_box.SelectedIndex].SH_ID );
            cmd.Parameters.AddWithValue("SH_CLIENT_PRODUCT_ID", client_products[client_product_combo_box.SelectedIndex].SH_ID);
            cmd.Parameters.AddWithValue("SH_SIZE_ID", size_id);
            cmd.Parameters.AddWithValue("SH_PILLOW_COLOR_ID", pillow_color_id);
            cmd.Parameters.AddWithValue("SH_FACE_COLOR_ID", face_color_id);
            cmd.Parameters.AddWithValue("SH_TWIST_OF_TYPE_ID", twist_of_types[twist_type_combo_box.SelectedIndex].SH_ID);
            cmd.Parameters.AddWithValue("SH_TYPE" , 0);
            cmd.Parameters.AddWithValue("SH_CONTAINER_NAME", 0);
            cmd.Parameters.AddWithValue("SH_NO_OF_CONTAINERS", "");
            cmd.Parameters.AddWithValue("SH_TOTAL_NO_TEMS",0);
            cmd.Parameters.AddWithValue("SH_FIRST_FACE_PILLOW_OR_NOT",0);
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
        async Task<long> savetwistofquantities(long sp_id)
        {
            
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_TWIST_OF_QUANTITIES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_TWIST_OF_ID", "");
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", "");
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER","");
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_OF_ITEMS","");
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER","");
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID","");
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_ID","");
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
                MessageBox.Show("ERROR WHILE ADDING TWIST OFF QUANTITIES "+ex.ToString());
            }
            return 0;
        }
        async Task savetwistofcontainers(long sp_id , long qu_id , long no_containers, string addition_permission_number , long no_items_per_container)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("SH_QUANTITY_OF_TWIST_OF_ID",typeof(long)));
                dt.Columns.Add(new DataColumn("SH_ADDITION_PERMISSION_NUMBER",typeof(string)));
                dt.Columns.Add(new DataColumn("SH_ADDTION_DATE", typeof(DateTime)));
                dt.Columns.Add(new DataColumn("SH_NO_ITEMS", typeof(long)));
                for (int i = 0; i < no_containers; i++)
                {
                    dt.Rows.Add(qu_id, addition_permission_number , no_items_per_container);
                }
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SAVE_NEW_TWIST_OF_CONTAINER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TWIST_OF_CONTAINER_DATA",dt);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle SAVing TWiST of CONTAINER "+ex.ToString());
            }
        }



        void calculatenoitemsofquantity()
        {
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(no_items_per_container.Text)|| string.IsNullOrWhiteSpace(no_of_containers_text_box.Text))
            {
             
            }else
            {
                if (long.TryParse(no_items_per_container.Text, out testnumber) && long.TryParse(no_of_containers_text_box.Text, out testnumber))
                {
                    no_items_per_quantity.Text = (long.Parse(no_items_per_container.Text) + long.Parse(no_of_containers_text_box.Text)).ToString();
                }
            }
        }
        void calculatenoitemsofunsimilarquantity()
        {
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(unsimilar_no_items_per_container.Text) || string.IsNullOrWhiteSpace(unsimilar_no_of_containers.Text))
            {

            }
            else
            {
                if (long.TryParse(unsimilar_no_items_per_container.Text, out testnumber) && long.TryParse(unsimilar_no_of_containers.Text, out testnumber))
                {
                    unsimilar_no_items_per_quantity.Text = (long.Parse(unsimilar_no_items_per_container.Text) + long.Parse(unsimilar_no_of_containers.Text)).ToString();
                }
            }
        }
        void calculatetotalnoofitems()
        {
            if (string.IsNullOrWhiteSpace(no_items_per_quantity.Text) || string.IsNullOrWhiteSpace(unsimilar_no_items_per_quantity.Text))
            {
                total_number_of_items_text_box.Text = (long.Parse(no_items_per_quantity.Text)+long.Parse(unsimilar_no_items_per_quantity.Text)).ToString();
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
    }
}
