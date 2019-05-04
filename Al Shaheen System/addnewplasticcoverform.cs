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
    public partial class addnewplasticcoverform : Form
    {
        List<SH_PLASTIC_COVER_DATA> form_data = new List<SH_PLASTIC_COVER_DATA>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();
        List<SH_COLOR_PILLOW> color_pillows = new List<SH_COLOR_PILLOW>();

        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();

        List<SH_SPECIFICATION_OF_PLASTIC_COVER> specifications = new List<SH_SPECIFICATION_OF_PLASTIC_COVER>();
        List<SH_QUANTITY_OF_PLASTIC_COVER> QUANTITIES = new List<SH_QUANTITY_OF_PLASTIC_COVER>();
        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();

        public addnewplasticcoverform()
        {
            InitializeComponent();
        }

        async Task loadallspecifications()
        {
            specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_PLASTIC_COVER_SPECIFICATIONS", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_PLASTIC_COVER() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_LOGO_OR_NOT = long.Parse(reader["SH_LOGO_OR_NOT"].ToString()), SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()), SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            } catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILe GETTING SPECIFicATIONS DATA " + ex.ToString());
            }
        }
        async Task<long> check_if_specification_exists_or_not(SH_PLASTIC_COVER_DATA mydata)
        {
            loadallspecifications();
            try
            {
                if (specifications.Count > 0)
                {
                    for (int i = 0; i < specifications.Count; i++)
                    {
                        if (specifications[i].SH_CLIENT_ID == mydata.client.SH_ID && specifications[i].SH_LOGO_OR_NOT == mydata.logo_or_not && specifications[i].SH_SIZE_ID == mydata.size.SH_ID && string.Compare(specifications[i].SH_CONTAINER_NAME, mydata.container_name) == 0)
                        {
                            return specifications[i].SH_ID;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE ADDING CHEckiNG NEW SPECiFIcATIONS" + ex.ToString());
            }
            return 0;
        }
        async Task<long> save_new_specification(SH_PLASTIC_COVER_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_PLASTIC_COVER_SPECIFICATION", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mydata.client.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", mydata.size.SH_ID);
                cmd.Parameters.AddWithValue("@SH_LOGO_OR_NOT", mydata.logo_or_not);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items());
                cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", mydata.pillow_color.SH_ID);
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
                MessageBox.Show("ERROR WHILE ADDING NEW SPECIFICATION " + ex.ToString());
            }
            return 0;
        }
        async Task upsate_specifications(long sp_id, SH_PLASTIC_COVER_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_PLASTIC_COVER_SPECIFICATION_QUANTITIES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items());
                cmd.Parameters.AddWithValue("@SH_SP_ID", sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATIONS " + ex.ToString());
            }
        }
        async Task<long> save_new_plastic_cover_quantities(long sp_id, SH_PLASTIC_COVER_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_PLASTIC_COVER_QUANTITIES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PLASTIC_COVER_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID", mydata.supplier.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_ID", mydata.supplier_branch.SH_ID);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", mydata.addition_date);
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                cmd.Parameters.AddWithValue("@SH_NO_OF_ITEMS_PER_CONTAINER", mydata.no_items_per_container);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items());

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
                MessageBox.Show("ERROR WHILE ADDING NEW PLASTIC COVER QIANTITIES " + ex.ToString());
            }
            return 0;
        }
        async Task save_plastic_cover_containers(long qu_id, SH_PLASTIC_COVER_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < mydata.no_of_containers; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_PLASTIC_COVER_CONTAINER", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_PLASTIC_COVER_ID", qu_id);
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                    cmd.Parameters.AddWithValue("@SH_ADDTION_DATE", mydata.addition_date);
                    cmd.Parameters.AddWithValue("@SH_NO_ITEMS", mydata.no_items_per_container);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                    cmd.ExecuteNonQuery();
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW PLASTIC COVER CONTAINERS " + ex.ToString());
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
                    stocks.Add(new SH_SHAHEEN_STOCK() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString(), SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING STOCKS INFORMATION " + ex.ToString());
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
            this.Invoke((MethodInvoker)delegate ()
            {
                client_product_combo_box.Items.Clear();
            });
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
           
            await fillstockscombobox();
            await getallclientsdata();
            await fillclientscombobox();
            await fillwistofcolorpillowcombobox();
            fillsizescombobox();

            no_of_containers_text_box.Enabled = true;
            no_items_per_container.Enabled = true;
            unsimilar_no_items_per_container.Enabled = false;
            unsimilar_no_of_containers.Enabled = false;
            Cursor.Current = Cursors.Default;
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
           
            if (string.IsNullOrWhiteSpace(sizes_combo_box.Text))
            {
                f2_combo_box_error_provider.SetError(sizes_combo_box,"لابد من تحديد المقاس");
                cansave = false;
            }else
            {
                f2_combo_box_error_provider.Clear();
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

                //if (unsimilarquantities_check_box.Checked)
                //{
                //    List<SH_CONTAINERS_OF_PLASTIC_COVER> anycontainers = new List<SH_CONTAINERS_OF_PLASTIC_COVER>();
                //    for (int i = 0; i < long.Parse(unsimilar_no_of_containers.Text); i++)
                //    {
                //        anycontainers.Add(new SH_CONTAINERS_OF_PLASTIC_COVER() { SH_ADDITION_PERMISSION_NUMBER = addition_permission_number_text_box.Text, SH_ADDTION_DATE = DateTime.Now, SH_CONTAINER_NAME = "الكيس البلاستيك", SH_NO_ITEMS = long.Parse(unsimilar_no_items_per_container.Text) });
                //    }

                //    QUANTITIES.Add(new SH_QUANTITY_OF_PLASTIC_COVER() { SH_ADDITION_DATE = DateTime.Now , SH_ADDITION_PERMISSION_NUMBER = addition_permission_number_text_box.Text , SH_NO_OF_CONTAINERS = long.Parse(unsimilar_no_of_containers.Text) , SH_CONTAINER_NAME = "الكيس البلاستيك", SH_NO_OF_ITEMS_PER_CONTAINER = long.Parse(unsimilar_no_items_per_container.Text) , SH_TOTAL_NO_ITEMS = long.Parse(unsimilar_no_items_per_quantity.Text), SH_SUPPLIER_ID = suppliers[suppliers_combo_box.SelectedIndex].SH_ID , SH_SUPPLIER_BRANCH_ID = supplier_branches[supplier_branches_combo_box.SelectedIndex].SH_ID , suppliername = suppliers[suppliers_combo_box.SelectedIndex].SH_SUPPLY_COMAPNY_NAME , supplierbranchname = supplier_branches[supplier_branches_combo_box.SelectedIndex].SH_COMPANY_BRANCH_NAME });
                //}else
                //{
                //    List<SH_CONTAINERS_OF_PLASTIC_COVER> anycontainers = new List<SH_CONTAINERS_OF_PLASTIC_COVER>();
                //    for (int i = 0; i < long.Parse(no_items_per_container.Text); i++)
                //    {
                //        anycontainers.Add(new SH_CONTAINERS_OF_PLASTIC_COVER() { SH_ADDITION_PERMISSION_NUMBER = addition_permission_number_text_box.Text, SH_ADDTION_DATE = DateTime.Now, SH_CONTAINER_NAME = "الكيس البلاستيك", SH_NO_ITEMS = long.Parse(no_items_per_container.Text) });
                //    }
                //    QUANTITIES.Add(new SH_QUANTITY_OF_PLASTIC_COVER() { SH_ADDITION_DATE = DateTime.Now, SH_ADDITION_PERMISSION_NUMBER = addition_permission_number_text_box.Text, SH_NO_OF_CONTAINERS = long.Parse(no_of_containers_text_box.Text), SH_CONTAINER_NAME = "الكيس البلاستيك", SH_NO_OF_ITEMS_PER_CONTAINER = long.Parse(no_items_per_container.Text), SH_TOTAL_NO_ITEMS = long.Parse(no_items_per_quantity.Text), SH_SUPPLIER_ID = suppliers[suppliers_combo_box.SelectedIndex].SH_ID, SH_SUPPLIER_BRANCH_ID = supplier_branches[supplier_branches_combo_box.SelectedIndex].SH_ID , suppliername = suppliers[suppliers_combo_box.SelectedIndex].SH_SUPPLY_COMAPNY_NAME, supplierbranchname = supplier_branches[supplier_branches_combo_box.SelectedIndex].SH_COMPANY_BRANCH_NAME });

                //}

                long logo_or_not = 0;
                if (logo_or_not_check_box.Checked)
                {
                    logo_or_not = 1;
                }else
                {
                    logo_or_not = 0;
                }
                form_data.Add(new SH_PLASTIC_COVER_DATA() { addition_date = DateTime.Now , addition_permission_number = addition_permission_number_text_box.Text , client = clients[clients_combo_box.SelectedIndex] , container_name = "أكياس بلاستيك", logo_or_not  = logo_or_not , no_items_per_container = long.Parse(no_items_per_container.Text) , no_of_containers = long.Parse(no_of_containers_text_box.Text) , size = sizes[sizes_combo_box.SelectedIndex] , supplier = suppliers[suppliers_combo_box.SelectedIndex] , supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex] , pillow_color = color_pillows[client_product_combo_box.SelectedIndex]});

                fillplasticovergridview();
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

        void fillplasticovergridview()
        {
            twist_of_quantities_grid_view.Rows.Clear();
            if (form_data.Count>0)
            {
                for (int i = 0; i < form_data.Count; i++)
                {
                    string[] myparams = new string[9];
                    myparams[0] = (i+1).ToString();
                    myparams[1] = (form_data[i].supplier.SH_SUPPLY_COMAPNY_NAME);
                    myparams[2] = form_data[i].client.SH_CLIENT_COMPANY_NAME;
                    myparams[3] = form_data[i].pillow_color.SH_COLOR_NAME;
                    if (form_data[i].logo_or_not==1)
                    {
                        myparams[4] = "يوجد لوجو";
                    }else
                    {
                        myparams[4] = "لا يوجد لوجو";
                    }
                    //myparams[5] = form_data[i].container_name;
                    myparams[5] = form_data[i].no_of_containers.ToString();
                    myparams[6] = form_data[i].no_items_per_container.ToString();
                    myparams[7] = form_data[i].total_no_items().ToString();
                    twist_of_quantities_grid_view.Rows.Add(myparams);
                }

            }
        }

        private async void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            
              
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
            savenewplasticcoverdata();
        }

        async void savenewplasticcoverdata()
        {
            try
            {
                if (form_data.Count > 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        long sp_id = await check_if_specification_exists_or_not(form_data[i]);
                        if (sp_id !=0)
                        {
                            await upsate_specifications(sp_id,form_data[i]);
                           long q_id =  await save_new_plastic_cover_quantities(sp_id, form_data[i]);
                            await save_plastic_cover_containers(q_id , form_data[i]);
                        }else
                        {
                            sp_id = await save_new_specification(form_data[i]);
                            long q_id = await save_new_plastic_cover_quantities(sp_id, form_data[i]);
                            await save_plastic_cover_containers(q_id, form_data[i]);
                        }
                    }
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                    Cursor.Current = Cursors.Default;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW DATA" +ex.ToString());
            }
        }



        private void no_of_containers_text_box_TextChanged(object sender, EventArgs e)
        {
            calculatenoitemsofquantity();
        }
    }
}
