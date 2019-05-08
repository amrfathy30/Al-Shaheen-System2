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
    public partial class addnewplasticmoldform : Form
    {

        List<SH_PLASTIC_MOLD_DATA> form_data = new List<SH_PLASTIC_MOLD_DATA>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SUPPLY_COMPANY_BRANCHES> supplier_branches = new List<SH_SUPPLY_COMPANY_BRANCHES>();     
        List<SH_COLOR_PILLOW> color_pillows = new List<SH_COLOR_PILLOW>();     
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_MOLD_TYPES> MOLD_TYPES = new List<SH_MOLD_TYPES>();
        List<SH_SPECIFICATION_OF_PLASTIC_MOLD> specifications = new List<SH_SPECIFICATION_OF_PLASTIC_MOLD>();
        List<SH_QUANTITY_OF_PLASTIC_MOLD> QUANTITIES = new List<SH_QUANTITY_OF_PLASTIC_MOLD>();
        List<SH_MOLD_SIZE> sizes = new List<SH_MOLD_SIZE>();
        List<SH_CONTAINERS_OF_PLASTIC_MOLD> mcontainers = new List<SH_CONTAINERS_OF_PLASTIC_MOLD>();
        List<string> item_types = new List<string>();

        public addnewplasticmoldform()
        {
            InitializeComponent();
        }
        async Task loadallplasticmoldspecifications()
        {
            specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_PLASTIC_MOLD_SPECIFICATIONS" , DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifications.Add(new SH_SPECIFICATION_OF_PLASTIC_MOLD() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MOLD_TYPE_ID = long.Parse(reader["SH_MOLD_TYPE_ID"].ToString()), SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()), SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()) , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SPECIFICATIONS DATA "+ex.ToString());
            }
        }
        async Task<long> check_if_specification_exists_or_not(SH_PLASTIC_MOLD_DATA mydata)
        {
            await loadallplasticmoldspecifications();
            if (specifications.Count>0)
            {
                for (int i = 0; i < specifications.Count; i++)
                {
                    if (specifications[i].SH_CLIENT_ID==mydata.client.SH_ID && specifications[i].SH_MOLD_TYPE_ID == mydata.mold_types.SH_ID&& specifications[i].SH_PILLOW_COLOR_ID == mydata.color.SH_ID && specifications[i].SH_SIZE_ID == mydata.size.SH_ID && string.Compare(specifications[i].SH_CONTAINER_NAME , mydata.container_name)==0)
                    {
                        return specifications[i].SH_ID;
                    }
                }
            }
            return 0;
        }
        async Task <long> savenewspecifications(SH_PLASTIC_MOLD_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_PLASTIC_MOLD_SPECIFICATION", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mydata.client.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", mydata.size.SH_ID);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS",mydata.total_number_of_items());
                cmd.Parameters.AddWithValue("@SH_MOLD_TYPE_ID", mydata.mold_types.SH_ID);
                cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", mydata.color.SH_ID);
               
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
                MessageBox.Show("ERROR WHILE SAVING NEW SPECIFICATIONS DATA "+ex.ToString());
            }
            return 0;
        }
        async Task update_specification(long sp_id , SH_PLASTIC_MOLD_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , mydata.total_number_of_items());
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS" , mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_SP_ID" , sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATION DATA "+ex.ToString());
            }
        }
        async Task<long> savenewquantity(long sp_id, SH_PLASTIC_MOLD_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_PLASTIC_MOLD_QUANTITY" , DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PLASTIC_MOLD_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID" , mydata.supplier.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_BRANCH_ID" , mydata.supplier_branch.SH_ID);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", mydata.Addition_date);
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER",mydata.addition_permission_number);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME",mydata.container_name);
                cmd.Parameters.AddWithValue("@SH_NO_OF_ITEMS_PER_CONTAINER",mydata.no_of_items_per_container);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS",mydata.no_of_containers);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS" , mydata.total_number_of_items());
                long q_id = 0;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    q_id = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return q_id;
            }
            catch (Exception EX)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW QUANTITY "+EX.ToString());
            }
            return 0;
        }
        async Task save_containers(long q_id , SH_PLASTIC_MOLD_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < mydata.no_of_containers; i++)
                {


                    SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_PLASTIC_MOLD_CONTAINER", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", mydata.container_name);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_PLASTIC_MOLD_ID", q_id);
                    cmd.Parameters.AddWithValue("@SH_NO_ITEMS", mydata.no_of_items_per_container);
                    cmd.Parameters.AddWithValue("@SH_ADDTION_DATE", mydata.Addition_date);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW CONTAINERS "+ex.ToString());
            }
        }
        async Task getallmoldtypes()
        {
            MOLD_TYPES.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_MOLD_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MOLD_TYPES.Add(new SH_MOLD_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MOLD_TYPE_NAME = reader["SH_MOLD_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL MOLD TYPES " + ex.ToString());
            }
        }
        async  Task fillallmoldtypesgridview()
        {
            await getallmoldtypes();
            plastic_mold_type_combo_box.Items.Clear();
            if (MOLD_TYPES.Count > 0)
            {
                for (int i = 0; i < MOLD_TYPES.Count; i++)
                {
                    plastic_mold_type_combo_box.Items.Add( MOLD_TYPES[i].SH_MOLD_TYPE_NAME );
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
       
      
       
        async Task getalltwistofsizes()
        {
            try
            {
                sizes.Clear();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_MOLD_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_MOLD_SIZE_VALUE = double.Parse(reader["SH_MOLD_SIZE_VALUE"].ToString()) });
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
                    f2_combo_box.Items.Add(Math.Round(sizes[i].SH_MOLD_SIZE_VALUE,1).ToString());
                }
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
            await fillwistofcolorpillowcombobox();
            await fillstockscombobox();
            await getallclientsdata();
            await fillclientscombobox();
            await fillallmoldtypesgridview();
            await fillsizescombobox();
  
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
                Cursor.Current = Cursors.WaitCursor;
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        long sp_id = await check_if_specification_exists_or_not(form_data[i]);
                        if (sp_id==0)
                        {
                            sp_id = await savenewspecifications(form_data[i]);
                            long q_id = await savenewquantity(sp_id, form_data[i]);
                            await  save_containers(q_id , form_data[i]);
                        }else
                        {
                            await update_specification(sp_id , form_data[i]);
                            long q_id = await savenewquantity(sp_id, form_data[i]);
                            await save_containers(q_id, form_data[i]);
                        }
                    }

                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE SAVE " + ex.ToString());
                MessageBox.Show("لم يتم الحفظ بنجاح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
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
          
            if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
            {
                f2_combo_box_error_provider.SetError(f2_combo_box,"لابد من تحديد المقاس");
                cansave = false;
            }else
            {
                f2_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(plastic_mold_type_combo_box.Text))
            {
                twist_type_combo_box_error_provider.SetError(plastic_mold_type_combo_box,"لابد من تحديد نوع التويست أوف");
                cansave = false;
            }else
            {
                twist_type_combo_box_error_provider.Clear();
            }
            if (string.IsNullOrWhiteSpace(plastic_mold_type_combo_box.Text))
            {
                item_type_combo_box_error_provider.SetError(plastic_mold_type_combo_box,"لابد من تحديد نوع الطبة");
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
                try {

                    if (unsimilarquantities_check_box.Checked)
                    {

                        form_data.Add(new SH_PLASTIC_MOLD_DATA() { addition_permission_number = addition_permission_number_text_box.Text , client = clients[clients_combo_box.SelectedIndex] , container_name = container_type_combo_box.Text , mold_types = MOLD_TYPES[plastic_mold_type_combo_box.SelectedIndex] , no_of_containers = long.Parse(unsimilar_no_of_containers.Text) , no_of_items_per_container = long.Parse(unsimilar_no_items_per_container.Text) , size = sizes[f2_combo_box.SelectedIndex] , stock = stocks[stock_combo_box.SelectedIndex] , supplier = suppliers[suppliers_combo_box.SelectedIndex] , supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex], color = color_pillows[client_product_combo_box.SelectedIndex] , Addition_date = DateTime.Now });

                    }else
                    {
                        form_data.Add(new SH_PLASTIC_MOLD_DATA() { addition_permission_number = addition_permission_number_text_box.Text, client = clients[clients_combo_box.SelectedIndex], container_name = container_type_combo_box.Text, mold_types = MOLD_TYPES[plastic_mold_type_combo_box.SelectedIndex], no_of_containers = long.Parse(no_of_containers_text_box.Text), no_of_items_per_container = long.Parse(no_items_per_container.Text), size = sizes[f2_combo_box.SelectedIndex], stock = stocks[stock_combo_box.SelectedIndex], supplier = suppliers[suppliers_combo_box.SelectedIndex], supplier_branch = supplier_branches[supplier_branches_combo_box.SelectedIndex]  , color = color_pillows[client_product_combo_box.SelectedIndex], Addition_date = DateTime.Now });
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING NEW QUAntITY"+ex.ToString());
                }
                filltwistofgridview();
                // mcontainers.Clear();
            }
        }

       

      


        void filltwistofgridview()
        {
            twist_of_quantities_grid_view.Rows.Clear();
            if (form_data.Count>0)
            {
                for (int i = 0; i < form_data.Count; i++)
                {
                    string[] myitem = new string[10];
                    myitem[0] = (i+1).ToString();
                    myitem[1] = form_data[i].supplier.SH_SUPPLY_COMAPNY_NAME;
                    myitem[2] = form_data[i].client.SH_CLIENT_COMPANY_NAME;
                    myitem[3] = form_data[i].color.SH_COLOR_NAME;
                    myitem[4] = Math.Round(form_data[i].size.SH_MOLD_SIZE_VALUE,1).ToString();
                    myitem[5] = form_data[i].mold_types.SH_MOLD_TYPE_NAME;
                    myitem[6] = form_data[i].container_name;
                    myitem[7] = form_data[i].no_of_containers.ToString();
                    myitem[8] = form_data[i].no_of_items_per_container.ToString();
                    myitem[9] = form_data[i].total_number_of_items().ToString();
                  
                   
                    twist_of_quantities_grid_view.Rows.Add(myitem);

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
    }
}
