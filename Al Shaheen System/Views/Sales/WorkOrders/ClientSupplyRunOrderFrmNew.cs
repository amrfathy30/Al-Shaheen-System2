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
    public partial class ClientSupplyRunOrderFrmNew : Form
    {
        List<SH_TWIST_OF_SIZE> sizes = new List<SH_TWIST_OF_SIZE>();
        List<SH_CONTAINER_OF_TWIST_OF> mcontainers = new List<SH_CONTAINER_OF_TWIST_OF>();
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        List<SH_TWIST_OF_TYPE> twist_of_types = new List<SH_TWIST_OF_TYPE>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_CLIENTS_PRODUCTS> mproduct = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ITEMS> ItemList = new List<SH_ITEMS>();
        List<SH_CLIENTS_BRANCHES> branchList = new List<SH_CLIENTS_BRANCHES>();
        long id;
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        SH_CLIENT_COMPANY Mclient = new SH_CLIENT_COMPANY();
        CLIENT_ORDER_WORK cw = new CLIENT_ORDER_WORK();
        List<CLIENT_ORDER_WORK> cwList = new List<CLIENT_ORDER_WORK>();
        List<SH_FACE_COLOR> faceList = new List<SH_FACE_COLOR>();
        List<SH_CLIENTS_BRANCHES> mclientBranches = new List<SH_CLIENTS_BRANCHES>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<string> item_types = new List<string>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        SH_EMPLOYEES MEmployee = new SH_EMPLOYEES();
        List<SH_COLOR_PILLOW> color_pillows = new List<SH_COLOR_PILLOW>();
        public ClientSupplyRunOrderFrmNew(SH_EMPLOYEES anyEmployee)
        {
            InitializeComponent();
            MEmployee = anyEmployee;
        }
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
                MessageBox.Show("ERROR WHILE GETTING TWIST OF TYPES KINDS " + ex.ToString());
            }
        }
        void fillitemtypescombobox()
        {
            twist_item_type_combo_box.Items.Clear();
            getallitemtypes();
            if (item_types.Count > 0)
            {
                for (int i = 0; i < item_types.Count; i++)
                {
                    twist_item_type_combo_box.Items.Add(item_types[i]);
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
                cmd.Parameters.AddWithValue("@SH_KIND", item_types[twist_item_type_combo_box.SelectedIndex]);
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
            }
            catch (Exception ex)
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
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENTS_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY() { SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString(), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ClIENTS DATA " + ex.ToString());
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
                    client_products.Add(new SH_CLIENTS_PRODUCTS() { SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()), SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() });
                }
                reader.Read();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GetTING CLIENT PRODUCTS DATA " + ex.ToString());
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
                    faces.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACE COLORS " + ex.ToString());
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
                        comboBoxOutSideMuran.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                        comboBoxInsideMuran.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                        comboBoxCan_Buttom_out_muran.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                        comboBoxCan_Buttom_in_muran.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                        comboBoxInTinFace.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                        comboBoxOutTinFace.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                    });
                }
            }
        }
        async Task loadNewId()
        {
            try  //complete it after dataBase Creation
            {
                string query = "select top 1 * from CLIENT_ORDER_WORK  order by SH_ID desc";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cwList.Add(new CLIENT_ORDER_WORK { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                for (int i = 0; i < cwList.Count; i++)
                {
                    long newId = cwList[i].SH_ID + 1;
                    textBoxOrderWorkClient.Text = "SH_"+ (DateTime.Now.Year).ToString().Substring(2)+"_" + newId.ToString();
                }
               
              
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE ID FROM DB " + ex.ToString());
            }
        }
        void loadallClients()
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
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING clients DATA FROM DB " + ex.ToString());
            }
        }

        async Task fillClientscombobox()
        {
            clients.Clear();
            loadallClients();
            clients_combo_box.Items.Clear();
            if (clients.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }

        void loadallFaces()
        {
            try
            {
                string query = "SELECT * FROM SH_FACE_COLORS";
               
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    faceList.Add(new SH_FACE_COLOR { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING faces DATA FROM DB " + ex.ToString());
            }
        }

        void fillFaces()
        {
            faceList.Clear();
            loadallFaces();
            comboBoxInsideMuran.Items.Clear();
            comboBoxOutSideMuran.Items.Clear();
            if (faceList.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < faceList.Count; i++)
                {
                    comboBoxInsideMuran.Items.Add(faceList[i].SH_FACE_COLOR_NAME);
                    comboBoxOutSideMuran.Items.Add(faceList[i].SH_FACE_COLOR_NAME);
                }
            }
        }

        void loadallstocks()
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

      void fillstockscombobox()
        {
            stocks.Clear();
          loadallstocks();
            comboBoxourFactory.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    comboBoxourFactory.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }
        void loadComboBranches()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select * from SH_CLIENTS_BRANCHES where SH_CLIENT_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", clients[clients_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    branchList.Add(new SH_CLIENTS_BRANCHES { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(), SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS items DATA" + ex.ToString());
            }
        }

        void fillComboBranches()
        {
            branchList.Clear();
            comboBoxClientsBranches.Items.Clear();
            loadComboBranches();
            if (branchList.Count > 0)
            {
                for (int i = 0; i < branchList.Count; i++)
                {
                    comboBoxClientsBranches.Items.Add(branchList[i].SH_CLIENT_BRANCH_ADDRESS_TEXT);

                }
            }
        }


        void getallclientproducts()
        {

            try
            {
                string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS ";
                query += " WHERE(SH_CLIENT_ID = @client_id)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@client_id", clients[clients_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mproduct.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()), SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() });
                }
           

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS " + ex.ToString());
            }
        }

        void fillClientProducts()
        {
            mproduct.Clear();
            client_product_combo_box.Items.Clear();
            getallclientproducts();
            for (int i = 0; i < mproduct.Count; i++)
            {
                client_product_combo_box.Items.Add(mproduct[i].SH_PRODUCT_NAME);
            }

        }


        void getCanDaimetrOFSelectedproducts()
        {

            try
            {
                
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("getCanDaimetrOfSelectedProduct", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", mproduct[client_product_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBoxCanDaimetr.Text = reader["SH_SIZE_NAME"].ToString();
                    textBoxHightOFButtle.Text = reader["SH_BOTTLE_HEIGHT"].ToString();
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING Daimetr PRODUCTS " + ex.ToString());
            }
        }

    

        void loadclientbranchesCombo()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENTS_BRANCHES WHERE SH_CLIENT_ID = @SH_CLIENT_ID", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mclientBranches.Add(new SH_CLIENTS_BRANCHES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(), SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(), SH_CLIENT_BRANCH_TYPE = reader["SH_CLIENT_BRANCH_TYPE"].ToString(), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH FROM DB " + ex.ToString());
            }



        }


        void fillBranchesCombo()
        {


            comboBoxClientsBranches.Items.Clear();
            mclientBranches.Clear();
            loadclientbranchesCombo();
            for (int i = 0; i < mclientBranches.Count; i++)
            {
                comboBoxClientsBranches.Items.Add(mclientBranches[i].SH_CLIENT_BRANCH_ADDRESS_TEXT);
            }



        }
        private async void ClientSupplyRunOrderFrmNew_Load(object sender, EventArgs e)
        {
           await loadNewId();
           await  fillClientscombobox();
            textBoxDateNow.Text = DateTime.Now.ToString();
          
          

            await fillfacescombobox();
            await fillsizescombobox();
            fillitemtypescombobox();
        


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientSupplyRunOrderFrmNew frm = new ClientSupplyRunOrderFrmNew(MEmployee);
            frm.ShowDialog();
        }

        private void textBoxWhenDelivered_TextChanged(object sender, EventArgs e)
        {
        
            calcualtettotalPriceNew();
        }
        void addOrderWorkClient()
        {
            if (checkBoxHasMold.Checked&& comboBoxItemType.SelectedIndex == 0 && radioButton3Pecies.Checked)
            {//علبه
                cw.SH_DIAMETR_TAPPA = long.Parse(comboBoxCanTabaDaimetr.Text);
                
                cw.SH_TABA_COLOR = comboBoxCanTabaColor.Text;
                cw.SH_TABA_TYPE = comboBoxCanTabaType.Text;
                cw.SH_NUMBER_OF_PEICES = 3;
              
            }

            if (checkBoxHasMold.Checked==false && comboBoxItemType.SelectedIndex == 0 )
            {//علبه
                cw.SH_DIAMETR_TAPPA = 0;

                cw.SH_TABA_COLOR = "";
                cw.SH_TABA_TYPE = "";
           

            }
            if (comboBoxItemType.SelectedIndex == 0 &&(radioButtonEasyOpen.Checked|| radioButtonNormalEOE.Checked))
            {
                cw.SH_PRINTING_STATE = comboBoxPrintingState.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(textBoxCanDaimetr.Text);
            }
                if (comboBoxItemType.SelectedIndex == 0)
            {
               
                cw.SH_ITEM_NAME = client_product_combo_box.Text;
                cw.SH_CAN_BUTTLE_HIGHT = double.Parse(textBoxHightOFButtle.Text);
                cw.SH_CAN_DAIMETR = long.Parse(textBoxCanDaimetr.Text);
              
                cw.SH_CANS_THICKNESS = double.Parse(textBoxThichness.Text);
                cw.SH_NUMBER_OF_COLORS_OF_CAN =long.Parse( comboBoxNumberOfColors.Text);
                if (checkBoxThick.Checked)
                {
                    cw.SH_THICKNESS_INCREASE_DECREASE_01 = 1;
                }else
                {
                    cw.SH_THICKNESS_INCREASE_DECREASE_01 = 0;
                }

               

            }

            if(comboBoxItemType.SelectedIndex == 0 && radioButtonRLTCover.Checked)
            {
                cw.SH_RLT_DAIAMETR =long.Parse( comboBoxRLTDaimetr.Text);
            }
            if (comboBoxItemType.SelectedIndex == 0 && radioButtonPeelOffCover.Checked)
            {
                cw.SH_PEELOFF_DAIMETR = long.Parse(comboBoxPeelOffDaimetr.Text);
            }

            if (comboBoxItemType.SelectedIndex==1)
            {//EOE
                cw.SH_EASY_OPEN_MATERIAL = comboBoxEOEMaterial.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(comboBoxDiametrEoE.Text);
                cw.SH_INSIDE_MURAN = comboBoxInsideMuran.Text;
                cw.SH_OUTSIDE_MURAN = comboBoxOutSideMuran.Text;
                cw.SH_OPEN_WAY = comboBoxOpenType.Text;
                cw.SH_PRINTING_STATE = comboBoxPrintingState.Text;



            }

            if (comboBoxItemType.SelectedIndex == 4)
            {//RLT
                cw.SH_RLT_DAIAMETR = long.Parse(comboBoxRLTDaimetr.Text);


            }
            if (comboBoxItemType.SelectedIndex ==5)
            {//Normal end  لوحده بدون علبة
                cw.SH_EASY_OPEN_MATERIAL = comboBoxEOEMaterial.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(comboBoxDiametrEoE.Text);
                cw.SH_INSIDE_MURAN = comboBoxInsideMuran.Text;
                cw.SH_OUTSIDE_MURAN = comboBoxOutSideMuran.Text;
                cw.SH_PRINTING_STATE = comboBoxPrintingState.Text;




            }


            if (comboBoxItemType.SelectedIndex ==0&&(radioButtonEasyOpen.Checked|| radioButtonNormalEOE.Checked))
            { //غطاء ايزي اوبن للعلبة
                cw.SH_EASY_OPEN_MATERIAL = comboBoxEOEMaterial.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(textBoxCanDaimetr.Text);
                cw.SH_INSIDE_MURAN = comboBoxInsideMuran.Text;
                cw.SH_OUTSIDE_MURAN = comboBoxOutSideMuran.Text;
                cw.SH_OPEN_WAY = comboBoxOpenType.Text;
                cw.SH_PRINTING_STATE = comboBoxPrintingState.Text;

            }
            if (comboBoxItemType.SelectedIndex == 7)
            {
                //طبه بلاستيك
                cw.SH_PLASTIC_TABA_DAIMETR = long.Parse(comboBoxPlasticTabaDaimetr.Text);
                cw.SH_PLASTIC_TABA_TYPE = comboBoxPlasticTabaType.Text;
            }


           
            if (comboBoxItemType.SelectedIndex ==6)
            {//غطاء
                cw.SH_PLASTIC_COVER_COLOR_ONLY = comboBoxCoverColor.Text;
                    cw.SH_PLASTIC_COVER_COVER_DAIMETR_ONLY = long.Parse(comboBoxDaimetrCover.Text);
                    
            }
            if (checkBoxHasAklasheh.Checked)
            {
                cw.SH_PLASTIC_COVER_HAS_AKLASHEH =1;
            }
            if (checkBoxHasAklasheh.Checked==false)
            {
                cw.SH_PLASTIC_COVER_HAS_AKLASHEH = 0;
            }
          
            

            if (comboBoxItemType.SelectedIndex == 2)
            {
               
                //تويست
                cw.SH_TWIST_SIZE =long.Parse( f2_combo_box.Text);
                cw.SH_TWIST_TYPE = twist_type_combo_box.Text;
               cw.SH_TWIST_COLOR = f1_combo_box.Text;
                cw.SH_TWIST_DEEP_NORMAL_MEDIUM = twist_item_type_combo_box.Text;
            }
            if (comboBoxPaymentWay1.SelectedIndex == 1)
            {
                cw.SH_DATE_OF_THE_CKECK_SUBMITTED =( dateTimePickerChek1.Text);
            }
            if (comboBoxPaymentWay2.SelectedIndex == 1)
            {
                cw.SH_DATE_OF_THE_CKECK_WHEN_DELIVERD =(dateTimePickerChek2.Text);
            }
            if (comboBoxPaymentWay3.SelectedIndex == 1)
            {
                cw.SH_DATE_OF_THE_CKECK_AFTER_RECIVING = (dateTimePickerChek3.Text);
            }
            if(radioButtonweld.Checked)
            {
                cw.SH_LEHAM = 1;

            }
            if (radioButtonAutomaticWeld.Checked)
            {
                cw.SH_LEHAM_AUTOMATIC = 1;
            }
            if (radioButtonManualWeld.Checked)
            {
                cw.SH_LEHAM_MANUAL= 1;
            }
            if (radioButtonCanHasOutMuran.Checked)
            {
                cw.SH_HAS_MURAN = 1;
            }
            if (radioButtonPowder.Checked)
            {
                cw.SH_HAS_POWDER = 1;
                cw.SH_POWER_COLOR = comboBoxPowderColor.Text;
            }
            if (radioButtonHasNeck.Checked)
            {
                cw.SH_HAS_NECK = 1;

            }
            if (radioButtonHasNeck.Checked==false)
            {
                cw.SH_HAS_NECK = 0;

            }
            if (radioButtonPeding.Checked)
            {
                cw.SH_HAS_PINDING = 1;
            }
            if (radioButtonNoPeding.Checked)
            {
                cw.SH_HAS_PINDING = 0;
            }
            if (radioButtonInsidBead.Checked)
            {
                cw.SH_INSIDE_BEAD = 1;
            }
            if (radioButtonOutSideBead.Checked)
            {
                cw.SH_OUT_BEAD = 1;
            }
            if (radioButtonTafleeg.Checked)
            {
                cw.SH_TAFLEEG = 1;

            }
            if (radioButtonInsidePuls.Checked)
            {
                cw.SH_INSIDE_PULS = 1;
            }
            if (radioButtonOutPuls.Checked)
            {
                cw.SH_OUTSIDE_PULS = 1;
            }
            if (radioButtonHaveCover.Checked)
            {
                cw.SH_HAS_CAN_COVER = 1;
            }
            if (radioButtonHaveCover.Checked==false)
            {
                cw.SH_HAS_CAN_COVER = 0;
            }
            if (radioButtonEasyOpen.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "EOE";
            }

            if (radioButtonNormalEOE.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "قاع";
            }


            if (radioButtonRLTCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "RLT";
            }
            if (radioButtonPeelOffCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "بيل اوف";
            }
            if (radioButtonFaceCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "وش";
            }

            if (checkBoxHavePlasticCover.Checked)
            {
                cw.SH_HAS_PLASTIC_COVER_CAN = 1;
                cw.SH_PLASTIC_COVER_COLOR_CAN = comboBoxPlasticCoverColor.Text;
            }
            if (radioButtonPlasticCoverOfCanHasLogo.Checked)
            {
                cw.SH_HAS_PLASTIC_COVER_LOGO_CAN = 1;

            }
            if (radioButtonPlasticCoverOfCanHasLogo.Checked==false)
            {
                cw.SH_HAS_PLASTIC_COVER_LOGO_CAN = 0;

            }
            if (radioButtonFaceCover.Checked)
            {
                cw.SH_FACE_TYPE = comboBoxFaceType.Text;
            }
            if (comboBoxFaceType.SelectedIndex ==0)
            {
                cw.SH_BOYATE_FACE_TYPE = comboBoxBoyatFace.Text;
            }
            if (comboBoxFaceType.SelectedIndex == 1)
            {
                cw.SH_FACE_DAIMETR =long.Parse( comboBoxTabaDaiametr.Text);
            }
            if (radioButtonToTheClient.Checked)
            {
                cw.SH_DELIVERING_ADDRESS = comboBoxClientsBranches.Text;
            }
            if (radioButtonFromShaheen.Checked)
            {
                cw.SH_DELIVERING_ADDRESS = comboBoxourFactory.Text;
            }
            if (radioButtonLocal.Checked)
            {
                cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "محلى";
            }
            if (radioButtonImported.Checked)
            {
                cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "مستورد";
            }
            if (comboBoxItemType.SelectedIndex == 3)
            {
                cw.SH_PEELOFF_DAIMETR =long.Parse( comboBoxPeelOffDaimetr.Text);
            }
            if (comboBoxPaymentWay3.SelectedIndex==0)
            {
                cw.SH_DURATION_AFTER_RECIVING = comboBoxAfterReciving.Text;
            }
            if (radioButtonHasTinCover.Checked == true)
            {
                cw.SH_CAN_HAS_TIN_COVER_OR_NOT = 1;
            }
            if (radioButtonHasTinCover.Checked == false)
            {
                cw.SH_CAN_HAS_TIN_COVER_OR_NOT = 0;
            }
            if (radioButtonCanHasButtom.Checked)
            {
                cw.SH_CAN_HAS_BUTTOM_OR_NOT = 1;
            }
            if (radioButtonCanHasButtom.Checked==false)
            {
                cw.SH_CAN_HAS_BUTTOM_OR_NOT = 0;
            }
            if (comboBoxPaymentWay1.SelectedIndex == 2)
            {
                cw.SH_BANK_NAME_SUBMITTED = comboBoxBankName1.Text;
            }
            if (comboBoxPaymentWay2.SelectedIndex == 2)
            {
                cw.SH_BANK_NAME_WHEN_RECIVING = comboBoxBankName2.Text;
            }
            if (comboBoxPaymentWay3.SelectedIndex == 2 &&double.Parse(textBoxRemaining.Text)>0)
            {
                cw.SH_BANK_NAME_AFTER_RECIVING = comboBoxBankName3.Text;
            }
            if (radioButtonCanHasButtom.Checked)
            {
                cw.SH_CAN_BUTTUM_INSIDE_MURAN = comboBoxCan_Buttom_out_muran.Text;
                    cw.SH_CAN_BUTTUM_OUTSIDE_MURAN = comboBoxCan_Buttom_in_muran.Text;
            }
            if (radioButtonCanHasButtom.Checked==false)
            {
                cw.SH_CAN_BUTTUM_INSIDE_MURAN ="";
                cw.SH_CAN_BUTTUM_OUTSIDE_MURAN = "";
            }
            if (radioButtonHasTinCover.Checked) 
            {
                cw.SH_CAN_TIN_COVER_INSIDE_MURAN = comboBoxInTinFace.Text;
                cw.SH_CAN_TIN_COVER_OUTSIDE_MURAN = comboBoxOutTinFace.Text;
            }
            if (comboBoxFaceType.SelectedIndex == 1)
            {
                cw.SH_CAN_MOLD_FACE_SHAPE = comboBoxMoldFaceShape.Text;
            }
            if (comboBoxPrintingState.SelectedIndex == 1)
            {
                cw.SH_OUTSIDE_MURAN = "";
            }
          if (double.Parse(textBoxSubmitted.Text) == 0)
            {
                cw.SH_PAYMENT_WAY_SUBMITTED = "";
            }
            if (double.Parse(textBoxWhenDelivered.Text) == 0)
            {
                cw.SH_PAYMENT_WAY_WHEN_DELIVERING = "";
            }
            if (double.Parse(textBoxRemaining.Text) == 0)
            {
                cw.SH_PAYMENT_WAY_AFTER_RECIVING = "";
            }
            try
                {
                
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
    
                SqlCommand cmd = new SqlCommand("addClientOrderWork", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_ID_STRING", textBoxOrderWorkClient.Text);

                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME",clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_TODAY_DATE",DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM", textBoxClientSuppNum.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME",cw.SH_ITEM_NAME);
             
                     cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", comboBoxItemType.Text);
                cmd.Parameters.AddWithValue("@SH_QUANTITY",double.Parse(textBoxItemQnty.Text));
                cmd.Parameters.AddWithValue("@SH_UNIT_PRICE", double.Parse(textBoxItemPrice.Text));
                cmd.Parameters.AddWithValue("@SH_TOTAL_PRICE", double.Parse(textBoxTotalPrice.Text));
                cmd.Parameters.AddWithValue("@SH_CURRENCY_NAME",comboBoxCurrency.Text);
                cmd.Parameters.AddWithValue("@SH_TAX1", double.Parse(textBoxTax1.Text));
                cmd.Parameters.AddWithValue("@SH_TAX14", double.Parse(textBoxTax14.Text));
                cmd.Parameters.AddWithValue("@SH_TOTAL_COST_AFTER_TAXES", double.Parse(textBoxTotatalWithTax.Text));
                cmd.Parameters.AddWithValue("@SH_START_SUPPLY_DATE", DateTime.Parse(dateTimePicker1.Text));
                cmd.Parameters.AddWithValue("@SH_END_SUPPLY_DATE",DateTime.Parse(dateTimePicker2.Text));
                cmd.Parameters.AddWithValue("@SH_NOWLON", comboBoxNolon.Text);
                

                cmd.Parameters.AddWithValue("@SH_DELIVERING_ADDRESS",cw.SH_DELIVERING_ADDRESS);
                cmd.Parameters.AddWithValue("@SH_SUBMITTED_MONEY", double.Parse(textBoxSubmitted.Text));
                cmd.Parameters.AddWithValue("@SH_PAYMENT_WAY_SUBMITTED", cw.SH_PAYMENT_WAY_SUBMITTED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_THE_CKECK_SUBMITTED", cw.SH_DATE_OF_THE_CKECK_SUBMITTED);
                cmd.Parameters.AddWithValue("@SH_MONEY_PAID_WHEN_DELIVERING", double.Parse(textBoxWhenDelivered.Text));

                cmd.Parameters.AddWithValue("@SH_PAYMENT_WAY_WHEN_DELIVERING", cw.SH_PAYMENT_WAY_WHEN_DELIVERING);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_THE_CKECK_WHEN_DELIVERD", cw.SH_DATE_OF_THE_CKECK_WHEN_DELIVERD);
                cmd.Parameters.AddWithValue("@SH_MONEY_AFTER_RECIVING", double.Parse(textBoxRemaining.Text));
                cmd.Parameters.AddWithValue("@SH_PAYMENT_WAY_AFTER_RECIVING", cw.SH_PAYMENT_WAY_AFTER_RECIVING);
                
                cmd.Parameters.AddWithValue("@SH_DATE_OF_THE_CKECK_AFTER_RECIVING", cw.SH_DATE_OF_THE_CKECK_AFTER_RECIVING);
                cmd.Parameters.AddWithValue("@SH_DURATION_AFTER_RECIVING",cw.SH_DURATION_AFTER_RECIVING);
                cmd.Parameters.AddWithValue("@SH_CAN_DAIMETR", cw.SH_CAN_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_CAN_BUTTLE_HIGHT", cw.SH_CAN_BUTTLE_HIGHT);
                cmd.Parameters.AddWithValue("@SH_LEHAM", cw.SH_LEHAM);
                cmd.Parameters.AddWithValue("@SH_LEHAM_AUTOMATIC", cw.SH_LEHAM_AUTOMATIC);
                cmd.Parameters.AddWithValue("@SH_LEHAM_MANUAL", cw.SH_LEHAM_MANUAL);
                cmd.Parameters.AddWithValue("@SH_HAS_NECK", cw.SH_HAS_NECK);
                cmd.Parameters.AddWithValue("@SH_HAS_POWDER", cw.SH_HAS_POWDER);
                cmd.Parameters.AddWithValue("@SH_POWER_COLOR", cw.SH_POWER_COLOR);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_PEICES",cw.SH_NUMBER_OF_PEICES);
                cmd.Parameters.AddWithValue("@SH_CANS_THICKNESS", cw.SH_CANS_THICKNESS);
                cmd.Parameters.AddWithValue("@SH_THICKNESS_INCREASE_DECREASE_01",cw.SH_THICKNESS_INCREASE_DECREASE_01);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_COLORS_OF_CAN",cw.SH_NUMBER_OF_COLORS_OF_CAN);



                cmd.Parameters.AddWithValue("@SH_HAS_MURAN", cw.SH_HAS_MURAN);
                cmd.Parameters.AddWithValue("@SH_HAS_PINDING", cw.SH_HAS_PINDING);
                cmd.Parameters.AddWithValue("@SH_INSIDE_BEAD", cw.SH_INSIDE_BEAD);
                cmd.Parameters.AddWithValue("@SH_OUT_BEAD", cw.SH_OUT_BEAD);
                cmd.Parameters.AddWithValue("@SH_TAFLEEG", cw.SH_TAFLEEG);
                cmd.Parameters.AddWithValue("@SH_INSIDE_PULS", cw.SH_INSIDE_PULS);

                cmd.Parameters.AddWithValue("@SH_OUTSIDE_PULS", cw.SH_OUTSIDE_PULS);
                cmd.Parameters.AddWithValue("@SH_HAS_CAN_COVER", cw.SH_HAS_CAN_COVER);
                cmd.Parameters.AddWithValue("@SH_CAN_COVER_TYPE", cw.SH_CAN_COVER_TYPE);

                cmd.Parameters.AddWithValue("@SH_DIAMETR_TAPPA", cw.SH_DIAMETR_TAPPA); 
                cmd.Parameters.AddWithValue("@SH_TABA_TYPE", cw.SH_TABA_TYPE);
                cmd.Parameters.AddWithValue("@SH_TABA_COLOR", cw.SH_TABA_COLOR);

                cmd.Parameters.AddWithValue("@SH_HAS_PLASTIC_COVER_CAN",cw.SH_HAS_PLASTIC_COVER_CAN);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COLOR_CAN",cw.SH_PLASTIC_COVER_COLOR_CAN);
                cmd.Parameters.AddWithValue("@SH_HAS_PLASTIC_COVER_LOGO_CAN",cw.SH_HAS_PLASTIC_COVER_LOGO_CAN);
                cmd.Parameters.AddWithValue("@SH_INSIDE_MURAN", cw.SH_INSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_OUTSIDE_MURAN", cw.SH_OUTSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_EASY_OPEN_MATERIAL", cw.SH_EASY_OPEN_MATERIAL);
                cmd.Parameters.AddWithValue("@SH_OPEN_WAY", cw.SH_OPEN_WAY);

                cmd.Parameters.AddWithValue("@SH_EASY_OPEN_DAIAMETR", cw.SH_EASY_OPEN_DAIAMETR);
                cmd.Parameters.AddWithValue("@SH_RLT_DAIAMETR",cw.SH_RLT_DAIAMETR);
                cmd.Parameters.AddWithValue("@SH_TWIST_TYPE", cw.SH_TWIST_TYPE);
                cmd.Parameters.AddWithValue("@SH_TWIST_SIZE", cw.SH_TWIST_SIZE);
                cmd.Parameters.AddWithValue("@SH_TWIST_DEEP_NORMAL_MEDIUM", cw.SH_TWIST_DEEP_NORMAL_MEDIUM);
                cmd.Parameters.AddWithValue("@SH_TWIST_COLOR",cw.SH_TWIST_COLOR);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COLOR_ONLY",cw.SH_PLASTIC_COVER_COLOR_ONLY);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COVER_DAIMETR_ONLY",cw.SH_PLASTIC_COVER_COVER_DAIMETR_ONLY);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_HAS_AKLASHEH",cw.SH_PLASTIC_COVER_HAS_AKLASHEH);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_TABA_TYPE", cw.SH_PLASTIC_TABA_TYPE);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_TABA_DAIMETR", cw.SH_PLASTIC_TABA_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_TABA_LOCAL_OR_IMPORTED", cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED);
                cmd.Parameters.AddWithValue("@SH_FACE_TYPE", cw.SH_FACE_TYPE);
                cmd.Parameters.AddWithValue("@SH_BOYATE_FACE_TYPE", cw.SH_BOYATE_FACE_TYPE);
                cmd.Parameters.AddWithValue("@SH_FACE_DAIMETR",cw.SH_FACE_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_PEELOFF_DAIMETR", cw.SH_PEELOFF_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_CAN_HAS_TIN_COVER_OR_NOT", cw.SH_CAN_HAS_TIN_COVER_OR_NOT);
                cmd.Parameters.AddWithValue("@SH_CAN_HAS_BUTTOM_OR_NOT", cw.SH_CAN_HAS_BUTTOM_OR_NOT);


                cmd.Parameters.AddWithValue("@SH_BANK_NAME_SUBMITTED",cw.SH_BANK_NAME_SUBMITTED);
                cmd.Parameters.AddWithValue("@SH_BANK_NAME_WHEN_RECIVING",cw.SH_BANK_NAME_WHEN_RECIVING);
                cmd.Parameters.AddWithValue("@SH_BANK_NAME_AFTER_RECIVING",cw.SH_BANK_NAME_AFTER_RECIVING);
                cmd.Parameters.AddWithValue("@SH_CAN_BUTTUM_OUTSIDE_MURAN",cw.SH_CAN_BUTTUM_OUTSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_CAN_BUTTUM_INSIDE_MURAN", cw.SH_CAN_BUTTUM_INSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_CAN_TIN_COVER_INSIDE_MURAN",cw.SH_CAN_TIN_COVER_INSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_CAN_TIN_COVER_OUTSIDE_MURAN",cw.SH_CAN_TIN_COVER_OUTSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_CAN_MOLD_FACE_SHAPE", cw.SH_CAN_MOLD_FACE_SHAPE);
                cmd.Parameters.AddWithValue("@SH_PRINTING_STATE",cw.SH_PRINTING_STATE);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRED_BY",MEmployee.SH_EMPLOYEE_NAME);

                cmd.ExecuteNonQuery();
                MessageBox.Show("  تم اضافة امر تشغيل التوريد بنجاح"+ " "+comboBoxItemType.Text);
                myconnection.closeConnection();

                buttonSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in OrderWorkClient in DB" + ex.ToString());
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {
                MessageBox.Show("ادخل اسم العميل");
            }
            else if (string.IsNullOrEmpty(textBoxClientSuppNum.Text))
            {
                MessageBox.Show("رقم امر توريد العميل");
            }

            else if (string.IsNullOrEmpty(textBoxItemPrice.Text))
            {
                MessageBox.Show("ادخل سعر الوحده");
            }
            else if (string.IsNullOrEmpty(textBoxItemQnty.Text))
            {
                MessageBox.Show("ادخل الكميه المباعه");
            }
            else if (string.IsNullOrEmpty(textBoxSubmitted.Text))
            {
                MessageBox.Show("ادخل مقدم المبلغ");
            }
            else if (string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {
                MessageBox.Show(" ادخل قيمه المبلغ عند الاستلام");
            }
            else if (comboBoxPaymentWay3.SelectedIndex == 0 && string.IsNullOrEmpty(comboBoxAfterReciving.Text))
            {
                MessageBox.Show(" اختر المده المتاحه للسداد بعد الاستلام");
            }

            else if (comboBoxItemType.SelectedIndex == 0 && string.IsNullOrEmpty(client_product_combo_box.Text))
            {
                MessageBox.Show(" اختر اسم الصنف للعميل");
            }
            else if (string.IsNullOrEmpty(comboBoxCurrency.Text))
            {
                MessageBox.Show("اختر اسم  العملة");
            }
            else if (comboBoxBankName1.Visible && string.IsNullOrEmpty(comboBoxBankName1.Text))
            {
                MessageBox.Show("اختر اسم البنك الذي بتم فيه الابداع");
            }
            else if (comboBoxBankName2.Visible && string.IsNullOrEmpty(comboBoxBankName2.Text))
            {
                MessageBox.Show("اختر اسم البنك الذي بتم فيه الابداع");
            }
            else if (comboBoxBankName3.Visible && string.IsNullOrEmpty(comboBoxBankName3.Text))
            {
                MessageBox.Show("اختر اسم البنك الذي بتم فيه الابداع");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonCanHasOutMuran.Checked == false && radioButtonCanHasNoOutMuran.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد ورنيش خارجي ام لا يوجد");
            }

            else if (string.IsNullOrEmpty(comboBoxNolon.Text))
            {
                MessageBox.Show("اختر النولون");
            }
            else if (string.IsNullOrEmpty(comboBoxClientsBranches.Text) && string.IsNullOrEmpty(comboBoxourFactory.Text))
            {
                MessageBox.Show(" اختر مكان التسليم");
            }


            else if (double.Parse(textBoxSubmitted.Text)>0 && string.IsNullOrEmpty(comboBoxPaymentWay1.Text))
            {
                MessageBox.Show("ادخل طريقة الدفع نقدا ام شيك ام ايداع 1");
            }
            else if (double.Parse(textBoxWhenDelivered.Text) > 0 && string.IsNullOrEmpty(comboBoxPaymentWay2.Text))
            {
                MessageBox.Show("ادخل طريقة الدفع نقدا ام شيك ام ايداع2");
            }
            else if (double.Parse(textBoxRemaining.Text) > 0 && string.IsNullOrEmpty(comboBoxPaymentWay3.Text))
            {
                MessageBox.Show("ادخل طريقة الدفع نقدا ام شيك ام ايداع 3");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && (radioButtonDakWasl.Checked == false && radioButtonweld.Checked == false))
            {
                MessageBox.Show("اختر هل العلبة لحام ام دق وصل");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButton3Pecies.Checked && radioButtonHasNeck.Checked == false && radioButtonHasNONeck.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد رقبه للعلبه ام لا");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && radioButtonweld.Checked && radioButtonAutomaticWeld.Checked == false && radioButtonManualWeld.Checked == false)
            {

                MessageBox.Show("اختر نوع اللحام مانول ام اوتوماتيك");
            }

            else if (comboBoxItemType.SelectedIndex == 0 && string.IsNullOrEmpty(textBoxThichness.Text))
            {
                MessageBox.Show("ادخل سمك العلبة");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && radioButtonPowder.Checked == false && radioButtonNoPowder.Checked == false)
            {
                MessageBox.Show("اختر هل يوجد بودر ام لا");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && radioButtonPowder.Checked && string.IsNullOrEmpty(comboBoxPowderColor.Text))
            {
                MessageBox.Show("اختر لون البودر");

            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButton3Pecies.Checked && radioButtonPeding.Checked == false && radioButtonNoPeding.Checked == false && radioButtonOutSideBead.Checked == false && radioButtonInsidBead.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد بيدنج ام لا يوجد ام خرزه للداخل ام خرزه للخارج");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButton2Peices.Checked && radioButtonOutSideBead.Checked == false && radioButtonInsidBead.Checked == false)
            {
                MessageBox.Show("حدد خرزه للداخل ام للخارج");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonTafleeg.Checked == false && radioButtonInsidePuls.Checked == false && radioButtonOutPuls.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد تفليج ام بلص للداخل ام بلص للخارج");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonHaveCover.Checked == false && radioButtonHaveNoCover.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد غظاء للعلبة ام لا ");
            }


            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonHaveCover.Checked && radioButtonEasyOpen.Checked == false && radioButtonFaceCover.Checked == false && radioButtonNormalEOE.Checked == false && radioButtonRLTCover.Checked == false && radioButtonPeelOffCover.Checked == false)
            {
                MessageBox.Show("حدد نوع الغطاء ايزي ازبن ام قاع ام بييل اوف ام ار ال تي ام غطاء صفيح ");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && string.IsNullOrEmpty(comboBoxNumberOfColors.Text))
            {
                MessageBox.Show("اختر عدد الوان العلبة");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButton2Peices.Checked == false && radioButton3Pecies.Checked == false)
            {
                MessageBox.Show("حدد هل العلبة عادية ام كيسة ");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && checkBoxHasMold.Checked && (string.IsNullOrEmpty(comboBoxCanTabaColor.Text) || string.IsNullOrEmpty(comboBoxCanTabaType.Text) || string.IsNullOrEmpty(comboBoxCanTabaDaimetr.Text)))
            {
                MessageBox.Show("اكمل بيانات الطبة للعلبة القطر النوع اللون");
            }



            else if (comboBoxItemType.SelectedIndex == 2 && (string.IsNullOrEmpty(twist_type_combo_box.Text) || string.IsNullOrEmpty(f2_combo_box.Text) || string.IsNullOrEmpty(twist_item_type_combo_box.Text) || string.IsNullOrEmpty(f1_combo_box.Text)))
            {
                MessageBox.Show("ادخل بيانات التوست بشكل صحيح النوع و المقاس");
            }

            else if (comboBoxItemType.SelectedIndex == 0 && checkBoxHavePlasticCover.Checked && radioButtonPlasticCoverOfCanHasLogo.Checked == false && radioButtonPlasticCoverOfCanHasNoLogo.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد لوجو للغطاء البلاستيك ام لا ");
            }

            else if (checkBoxHavePlasticCover.Checked && string.IsNullOrEmpty(comboBoxPlasticCoverColor.Text))
            {
                MessageBox.Show("ادخل لون الغطاء البلاستيك");
            }


            else if (comboBoxItemType.SelectedIndex == 1 && comboBoxPrintingState.SelectedIndex == 1 && radioButtonEasyOpen.Checked && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxOpenType.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text) || string.IsNullOrEmpty(comboBoxDiametrEoE.Text)))
            {
                MessageBox.Show("اكمل بيانات الايزي اوبن بشكل صحيح الورنيش الداخلي و الخارجي و طريقة الفتح و الخامة");
            }
            else if (comboBoxItemType.SelectedIndex == 5 && comboBoxPrintingState.SelectedIndex == 1 && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxDiametrEoE.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text)))
            {
                MessageBox.Show("اكمل بيانات Normal End بشكل صحيح الورنيش الداخلي و الخارجي و القطر  و الخامة");
            }
            else if (comboBoxItemType.SelectedIndex == 7 && (string.IsNullOrEmpty(comboBoxPlasticTabaDaimetr.Text) || string.IsNullOrEmpty(comboBoxPlasticTabaType.Text)))
            {
                MessageBox.Show("اكمل بيانات الطبة البلاستيك  القطر و النوع و محلى ام مستورد");
            }
            //
            else if (comboBoxItemType.SelectedIndex == 7 && (radioButtonImported.Checked == false && radioButtonLocal.Checked == false))
            {
                MessageBox.Show("حدد الطبة البلاستيك محلى ام مستورد");
            }
            else if (comboBoxItemType.SelectedIndex == 4 && string.IsNullOrEmpty(comboBoxRLTDaimetr.Text))
            {
                MessageBox.Show("ادخل قطر ال ار ال تي");
            }
            else if (comboBoxItemType.SelectedIndex == 3 && string.IsNullOrEmpty(comboBoxPeelOffDaimetr.Text))
            {
                MessageBox.Show("اختر قطر ال بيل اوف");
            }

            else if (comboBoxItemType.SelectedIndex == 6 && (string.IsNullOrEmpty(comboBoxCoverColor.Text) || string.IsNullOrEmpty(comboBoxDaimetrCover.Text)))
            {
                MessageBox.Show("ادخل بيانات الغطاء البلاستيك القطر و اللون ");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && comboBoxPrintingState.SelectedIndex == 1 && radioButtonHaveCover.Checked && radioButtonEasyOpen.Checked && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text) || string.IsNullOrEmpty(comboBoxOpenType.Text)))
            {
                MessageBox.Show("اكمل بيانات الغطاء الايزي اوبن  الخامه الورنيش لبداخلي والخارجي و طريقة الفتح ");
            }

            else if (comboBoxItemType.SelectedIndex == 0 && comboBoxPrintingState.SelectedIndex == 1 && radioButtonHaveCover.Checked && radioButtonNormalEOE.Checked && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text)))
            {
                MessageBox.Show("اكمل بيانات الغطاء القاع   الخامه الورنيش الداخلي والخارجي  ");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonRLTCover.Checked && string.IsNullOrEmpty(comboBoxRLTDaimetr.Text))
            {
                MessageBox.Show("ادخل قطر الغطاء للعلبة");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonPeelOffCover.Checked && string.IsNullOrEmpty(comboBoxPeelOffDaimetr.Text))
            {
                MessageBox.Show("ادخل قطر الغطاء للعلبة");
            }

            else if (comboBoxFaceType.SelectedIndex == 0 && comboBoxItemType.SelectedIndex == 0 && radioButtonHasTinCover.Checked == false && radioButtonHasNoTinCover.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد غطاء صفيح للعلبة ام لا");
            }
            else if (radioButtonCanHasButtom.Checked && comboBoxPrintingState.SelectedIndex == 1 && (string.IsNullOrEmpty(comboBoxCan_Buttom_out_muran.Text) || string.IsNullOrEmpty(comboBoxCan_Buttom_in_muran.Text)))
            {
                MessageBox.Show("ادخل الورنيش الداخلى والخارجي لقاع العلبة");

            }
            else if (comboBoxFaceType.SelectedIndex == 0 && radioButtonHasTinCover.Checked == false && radioButtonHasNoTinCover.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد غطاء صفيح ام لا ");
            }
            else if (radioButtonHasTinCover.Checked && comboBoxPrintingState.SelectedIndex == 1 && (string.IsNullOrEmpty(comboBoxOutTinFace.Text) || string.IsNullOrEmpty(comboBoxInTinFace.Text)))
            {
                MessageBox.Show("حدد الورنيش الداخلى و الخارجي للغطاء الصفيح");
            }
            else if ((comboBoxFaceType.SelectedIndex == 1 || comboBoxFaceType.SelectedIndex == 2) && string.IsNullOrEmpty(comboBoxTabaDaiametr.Text))
            {
                MessageBox.Show("ادخل القطر");
            }
            else if (comboBoxFaceType.SelectedIndex == 1 && string.IsNullOrEmpty(comboBoxMoldFaceShape.Text))
            {
                MessageBox.Show("ادخل شكل الوش البويات");
            }
          
            else
            {
                try
                {
                    addOrderWorkClient();
                    this.Hide();
        
                    ClientSupplyRunOrderFrmNew frm = new ClientSupplyRunOrderFrmNew(MEmployee);
                    frm.ShowDialog();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.ToString());
                }

            }
        }
        

        private void comboBoxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxItemType.SelectedIndex)
            {
                case 1:
                    //easy open
                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    panelUPlipe.Visible = false;
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = true;
                    panelFace.Visible = false;
                    panelPeeding.Visible = false;
                    checkBoxHasMold.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelPecies.Visible = false;
                    panelCansOutMuran.Visible = false;
                    labelnum5.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    labelHightOfButtle.Visible = false;
                    textBoxHightOFButtle.Visible = false;
                    pillow_check_box.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;
                    break;


                case 4:
                    //rlt
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = false;
                    panelFace.Visible = false;
                    checkBoxHasMold.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    labelHightOfButtle.Visible = false;
                    textBoxHightOFButtle.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = true;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    pillow_check_box.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;
                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    break;
                case 3:
                    //peel off
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = false;
                    panelFace.Visible = false;
                    checkBoxHasMold.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    labelHightOfButtle.Visible = false;
                    textBoxHightOFButtle.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = true;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    pillow_check_box.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;
                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    break;
                case 2:
                    //twist



                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;

                    pillow_check_box.Visible = true;

                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelFace.Visible = false;
                    panelEasyopen.Visible = false;
                    checkBoxHasMold.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    labelHightOfButtle.Visible = false;
                    textBoxHightOFButtle.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = true;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                case 6:
                    //غطاء بلاستيك
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelFace.Visible = false;
                    panelEasyopen.Visible = false;
                    checkBoxHasMold.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    labelHightOfButtle.Visible = false;
                    textBoxHightOFButtle.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = true;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    pillow_check_box.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;
                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    break;
                case 0:
                    //علبه
                    labelnum5.Visible = true;
                    panelFace.Visible = false;
                    panelCansDesc.Visible = true;
                    groupBoxTaghleef.Visible = true;
                    checkBoxHasMold.Visible = true;
                    labelCanMold10.Visible = true;
                    panelNeck.Visible = true;
                    client_products_label.Visible = true;
                    client_product_combo_box.Visible = true;
                    panelCanButtom.Visible = true;
                    labelCanDaimetr.Visible = true;
                    textBoxCanDaimetr.Visible = true;
                    labelHightOfButtle.Visible = true;
                    textBoxHightOFButtle.Visible = true;
                    panelHavePlasticCover.Visible = true;
                    panelCover.Visible = true;
                    panelTwistProp.Visible = false;
                    panelEasyopen.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = true;
                    panelUPlipe.Visible = true;
                    panelRLT.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelPecies.Visible = true;
                    panelCansOutMuran.Visible = true;
                    pillow_check_box.Visible = false;
                    label63.Visible = true;
                    label41.Visible = true;
                    label61.Visible = true;
                    break;

                case 7:
                    //طبة بلاستيك
                    panelPlasticTaba.Visible = true;
                    panelEasyopen.Visible = false;
                    panelCansDesc.Visible = false;
                    panelFace.Visible = false;
                    panelPeeding.Visible = false;
                    checkBoxHasMold.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    pillow_check_box.Visible = false;
                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;
                    break;
                case 5:
                    //NormalEasyOpen
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = true;
                    panelFace.Visible = false;
                    panelUPlipe.Visible = false;
                    checkBoxHasMold.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;
                    pillow_check_box.Visible = false;
                    comboBoxOpenType.Visible = false;
                    labelOpenType.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    label63.Visible = false;
                    label41.Visible = false;
                    label61.Visible = false;
                    client_products_label.Visible = false;
                    client_product_combo_box.Visible = false;
                    break;
                default:
                    panelPlasticCover.Visible = false;
                    labelCanMold10.Visible = false;
                    panelNeck.Visible = false;
                    panelTinCover.Visible = false;
                    panelCanButtom.Visible = false;
                    labelCanDaimetr.Visible = false;
                    textBoxCanDaimetr.Visible = false;

                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelEasyopen.Visible = false;
                    panelUPlipe.Visible = false;
                    panelPeeding.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelCansOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
            }
        }

        private void radioButtonweld_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonweld.Checked)
            {
                panelWeldType.Visible = true;
            }
            else
            {
                panelWeldType.Visible = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {


            if (radioButtonPowder.Checked)
            {
                labelPowderColor.Visible = true;
                comboBoxPowderColor.Visible = true;
            }
            else
            {
                labelPowderColor.Visible = false;
                comboBoxPowderColor.Visible = false;
            }
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFaceCover.Checked)
            {
                panelFace.Visible = true;
                comboBoxTabaDaiametr.Visible = false;
                comboBoxTabaDaiametr.Visible = false;

                labelBoyatType.Visible = false;
                comboBoxBoyatFace.Visible = false;


            }
            else
            {
                panelFace.Visible = false;
            }
        }

        private void radioButtonEasyOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEasyOpen.Checked)
            {
                panelEasyopen.Visible = true;
            }
            else
            {
                panelEasyopen.Visible = false;
            }
        }

        private void comboBoxBoyatFace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFaceType.SelectedIndex)
            {
                case 0:
                    labelBoyatType.Visible = true;
                    comboBoxBoyatFace.Visible = true;



                    break;

                case 1:

                    comboBoxTabaDaiametr.Visible = true;
                    labelBoyatType.Visible = true;
                    labelBoyatType.Text = "قطر الطبة";
                    comboBoxBoyatFace.Visible = false;
                    break;
                default:
                    labelBoyatType.Visible = false;
                    comboBoxBoyatFace.Visible = false;
                    comboBoxTabaDaiametr.Visible = false;
                    break;

            }
        }

        void calcualtettotalPrice()
        {
            if (string.IsNullOrEmpty(textBoxItemQnty.Text) || string.IsNullOrEmpty(textBoxItemPrice.Text))
            {

            }
            else
            {
                double testbox = 0;
                if (double.TryParse(textBoxItemQnty.Text, out testbox) && double.TryParse(textBoxItemPrice.Text, out testbox))
                {

                    textBoxTotalPrice.Clear();
                    textBoxTotatalWithTax.Clear();
                    textBoxTotalPrice.Text = (double.Parse(textBoxItemQnty.Text) * double.Parse(textBoxItemPrice.Text)).ToString();
                    textBoxTotatalWithTax.Text = (double.Parse(textBoxTotalPrice.Text) - double.Parse(textBoxTax1.Text) + double.Parse(textBoxTax14.Text)).ToString();
                }
            }
        }


        void calcualtettotalPriceNew()
        {
            if (string.IsNullOrEmpty(textBoxItemQnty.Text) || string.IsNullOrEmpty(textBoxItemPrice.Text) || string.IsNullOrEmpty(textBoxTax1.Text) || string.IsNullOrEmpty(textBoxTax14.Text)  || string.IsNullOrEmpty(textBoxSubmitted.Text) || string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {

            }

            else
            {
              
                double testbox = 0;
                if (double.TryParse(textBoxItemQnty.Text, out testbox) && double.TryParse(textBoxItemPrice.Text, out testbox)&&double.TryParse(textBoxTax1.Text, out testbox) && double.TryParse(textBoxTax14.Text, out testbox) && double.TryParse(textBoxSubmitted.Text, out testbox) && double.TryParse(textBoxWhenDelivered.Text, out testbox))
                {
                
                    textBoxTotalPrice.Clear();
                    textBoxTotatalWithTax.Clear();
                    textBoxTax1.Clear();
                    textBoxTax14.Clear();

                    textBoxRemaining.Clear();

                    textBoxTotalPrice.Text = (double.Parse(textBoxItemQnty.Text) * double.Parse(textBoxItemPrice.Text)).ToString();
                    if (checkBoxTax1.Checked)
                    {
                        textBoxTax1.Text = (double.Parse(textBoxTotalPrice.Text) * .01).ToString();

                    }else
                    {
                        textBoxTax1.Text = "0";
                    }
                    if (checkBox14.Checked)
                    {
                        textBoxTax14.Text = (double.Parse(textBoxTotalPrice.Text) * .14).ToString();

                    }
                    else
                    {
                        textBoxTax14.Text = "0";
                    }
                    textBoxTotatalWithTax.Text = (double.Parse(textBoxTotalPrice.Text) - double.Parse(textBoxTax1.Text) + double.Parse(textBoxTax14.Text)).ToString();
                    double paid = double.Parse(textBoxSubmitted.Text) + double.Parse(textBoxWhenDelivered.Text);
                    textBoxRemaining.Text = (double.Parse(textBoxTotatalWithTax.Text) - paid).ToString();
                 
                }
            }
        }


        void calcualteRemaining()
        {
            if (string.IsNullOrEmpty(textBoxSubmitted.Text) || string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {

            }
            else
            {
                double testbox = 0;
                if (double.TryParse(textBoxSubmitted.Text, out testbox) && double.TryParse(textBoxWhenDelivered.Text, out testbox))
                {

                    textBoxRemaining.Clear();


                    double paid = double.Parse(textBoxSubmitted.Text) + double.Parse(textBoxWhenDelivered.Text);
                    textBoxRemaining.Text = (double.Parse(textBoxTotatalWithTax.Text) - paid).ToString();



                }
            }
        }



        private void textBoxItemQnty_TextChanged(object sender, EventArgs e)
        {  
            calcualtettotalPriceNew();
       

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            calcualtettotalPriceNew();
         
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            calcualtettotalPriceNew();
       
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            client_product_combo_box.Text = "";
            comboBoxClientsBranches.Text = "";
            fillClientProducts();
            fillBranchesCombo();

        }
        private void radioButtonFromShaheen_CheckedChanged(object sender, EventArgs e)
        {
            fillstockscombobox();
            if (radioButtonFromShaheen.Checked)
            {

                comboBoxourFactory.Visible = true;
            }
            else
            {
                comboBoxourFactory.Visible = false;
                comboBoxourFactory.Text = "";
            }

        }

        private void radioButtonToTheClient_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonToTheClient.Checked)
            {

                comboBoxClientsBranches.Visible = true;

            }
            else
            {
                comboBoxClientsBranches.Visible = false;
                comboBoxClientsBranches.Text = "";

            }
        }

        private void textBoxItemPrice_TextChanged(object sender, EventArgs e)
        {
            //calcualtettotalPrice();
            calcualtettotalPriceNew();
        }

        private void textBoxSubmitted_TextChanged(object sender, EventArgs e)
        {
           double testbox = 0;
            if (double.TryParse(textBoxSubmitted.Text, out testbox)){


                if (double.Parse(textBoxSubmitted.Text) > 0)
                {
                    labelPaymentWay1.Visible = true;
                    comboBoxPaymentWay1.Visible = true;
                } else
                {
                    labelPaymentWay1.Visible = false;
                    comboBoxPaymentWay1.Visible = false;
                }
            }
            calcualtettotalPriceNew();
            if (string.Compare(textBoxTotatalWithTax.Text, textBoxSubmitted.Text) == 0)
            {
                panelMoneyInReciving.Visible = false;
                panelMoneyAfterReciving.Visible = false;

            }
            else
            {
                panelMoneyInReciving.Visible = true;
                panelMoneyAfterReciving.Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxCover_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxCover.Checked)
            //{
            //    panelTaba.Visible = false;
            //}
            //else
            //{
            //    panelTaba.Visible = true;
            //}
        }

        private void radioButtonHaveCover_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonHaveCover.Checked)
            {
                panelTypeOFFace.Visible = true;


            }
            else
            {
                panelTypeOFFace.Visible = false;
            }
        }

        private void radioButtonEasyOpen_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonEasyOpen.Checked)
            {
                panelEasyopen.Visible = true;
                panelTinCover.Visible = false;
                labelDaimetrEOE.Visible = false;
                    comboBoxDiametrEoE.Visible = false;
            }
            else
            {
                panelEasyopen.Visible = false;
                labelDaimetrEOE.Visible = true;
                comboBoxDiametrEoE.Visible = true;
            }
        }

        private void radioButton17_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonFaceCover.Checked)
            {
                panelFace.Visible = true;
            }
            else
            {
                panelFace.Visible = false;
            }
        }

        private void comboBoxFaceType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBoxFaceType.SelectedIndex)
            {

                case 0: //بويات
                    comboBoxTabaDaiametr.Text = "";
                    labelBoyatType.Text = "نوع الوش البويات";
                    comboBoxBoyatFace.Visible = true;
                    labelBoyatType.Visible = true;
                    comboBoxTabaDaiametr.Visible = false;
                    comboBoxMoldFaceShape.Visible = false;
                    labelMoldFaceShape.Visible = false;
                    panelTinCover.Visible = true;
                  
                    break;
                case 1:
                    //طبة
                    labelBoyatType.Visible = true;
                    labelBoyatType.Text = "قطر الطبة";
                    comboBoxBoyatFace.Visible = false;
                    comboBoxBoyatFace.Text = "";
                    comboBoxTabaDaiametr.Visible = true;
                    comboBoxMoldFaceShape.Visible = true;
                    labelMoldFaceShape.Visible = true;
                    panelTinCover.Visible = false;

                    break;
                case 2:
                    //قلاوظ

                    comboBoxBoyatFace.Visible = true;
                    comboBoxTabaDaiametr.Visible = true;
                    labelBoyatType.Visible = true;
                    labelBoyatType.Text = "قطر القلاوظ";
                    comboBoxBoyatFace.Visible = false;
                    comboBoxMoldFaceShape.Visible = false;
                    labelMoldFaceShape.Visible = false;
                    panelTinCover.Visible = false;

                    break;
                default:
                    comboBoxBoyatFace.Visible = false;
                    comboBoxTabaDaiametr.Visible = false;
                    labelBoyatType.Visible = false;
                    break;
            }
        }

        private void comboBoxPaymentWay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaymentWay1.SelectedIndex)
            {

                case 0:

                    labelDateOFSheck1.Visible = false;
                    dateTimePickerChek1.Visible = false;
                    comboBoxBankName1.Visible = false;
                    labelBankName1.Visible = false;
                    break;
                case 1:
                    labelDateOFSheck1.Visible = true;
                    dateTimePickerChek1.Visible = true;
                    comboBoxBankName1.Visible = false;
                    labelBankName1.Visible = false;
                    labelDateOFSheck1.Text = "تاريخ الاستحقاق";
                    break;


                case 2:
                    labelDateOFSheck1.Visible = true;
                    dateTimePickerChek1.Visible = true;
                    comboBoxBankName1.Visible = true;
                    labelBankName1.Visible = true;
                    labelDateOFSheck1.Text = "تاريخ الايداع";
                    break;
                default:
                    labelDateOFSheck1.Visible = false;
                    dateTimePickerChek1.Visible = false;
                    break;
            }
        }

        private void comboBoxPaymentWay2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaymentWay2.SelectedIndex)
            {

                case 0:

                    labelDateOFSheck2.Visible = false;
                    dateTimePickerChek2.Visible = false;
                    labelBankName2.Visible = false;

                    break;
                case 1:
                    labelDateOFSheck2.Visible = true;
                    dateTimePickerChek2.Visible = true;
                    labelBankName2.Visible = false;
                    labelDateOFSheck2.Text = "تاريخ الاستحقاق";
                    break;
                case 2:
                    labelDateOFSheck2.Visible = true;
                    dateTimePickerChek2.Visible = true;
                    comboBoxBankName2.Visible = true;
                    labelBankName2.Visible = true;
                    labelDateOFSheck2.Text = "تاريخ الايداع";

                    break;
                default:
                    labelDateOFSheck2.Visible = false;
                    dateTimePickerChek2.Visible = false;
                    break;
            }
        }

        private void textBoxItemPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxItemPrice.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxItemPrice.Text);
                textBoxItemPrice.Text = num.ToString();
            }
        }

        private void textBoxItemQnty_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxItemQnty.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxItemQnty.Text);
                textBoxItemQnty.Text = num.ToString();
            }
        }

        private void textBoxSubmitted_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSubmitted.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxSubmitted.Text);
                textBoxSubmitted.Text = num.ToString();
            }
        

        }

        private void textBoxWhenDelivered_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxWhenDelivered.Text);
                textBoxWhenDelivered.Text = num.ToString();



            }
        }

        private void radioButtonNormalEOE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormalEOE.Checked)
            {
                panelEasyopen.Visible = true;
                comboBoxOpenType.Visible = false;
                labelOpenType.Visible = false;
                panelTinCover.Visible = false;
                labelDaimetrEOE.Visible = false;
                comboBoxDiametrEoE.Visible = false;
            }
            else
            {
                panelEasyopen.Visible = false;
                comboBoxOpenType.Visible = true;
                labelOpenType.Visible = true;
                labelDaimetrEOE.Visible = true;
                comboBoxDiametrEoE.Visible = true;

            }
        }

 
      

     
    

        private void checkBoxHavePlasticCover_CheckedChanged(object sender, EventArgs e)
        {
         
                if (checkBoxHavePlasticCover.Checked)
            {
                comboBoxPlasticCoverColor.Visible = true;
                radioButtonPlasticCoverOfCanHasLogo.Visible = true;
                radioButtonPlasticCoverOfCanHasNoLogo.Visible = true;
                labelCanPlasticCoverColor.Visible = true;
            }
            else
            {
                radioButtonPlasticCoverOfCanHasLogo.Visible = false;
                radioButtonPlasticCoverOfCanHasNoLogo.Visible = false;
                comboBoxPlasticCoverColor.Visible = false;
                labelCanPlasticCoverColor.Visible = false;

            }
        }

        private void comboBoxPaymentWay3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaymentWay3.SelectedIndex)
            {

                case 0:

                    labelDateOFSheck3.Visible = false;
                    dateTimePickerChek3.Visible = false;
                    labelAfterReciving.Visible = true;
                    comboBoxAfterReciving.Visible = true;
                    labelBankName3.Visible = false;


                    break;
                case 1:
                    labelDateOFSheck3.Visible = true;
                    dateTimePickerChek3.Visible = true;
                    labelAfterReciving.Visible = false;
                    comboBoxAfterReciving.Visible = false;
                    labelBankName3.Visible = false;
                    labelDateOFSheck3.Text = "تاريخ الاستحقاق";
                    break;
                case 2:
                    labelDateOFSheck3.Visible = true;
                    dateTimePickerChek3.Visible = true;
                    labelBankName3.Visible = true;
                    comboBoxBankName3.Visible = true;
                    labelDateOFSheck3.Text = "تاريخ الايداع";

                    break;
                default:
                    labelDateOFSheck3.Visible = false;
                    dateTimePickerChek3.Visible = false;
                    break;
            }
        }

        private void radioButtonPowder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPowder.Checked)
            {
                comboBoxPowderColor.Visible = true;
                labelPowderColor.Visible = true;
            }
            else
            {
                comboBoxPowderColor.Visible = false;
                labelPowderColor.Visible = false;

            }
        }

        private void radioButtonImported_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonImported.Checked)
            //{
            //   cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED ="مستورد";
            //}
            //else
            //{
            //    cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "";
            //}
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonLocal.Checked)
            //{
            //    cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "محلى";
            //}
            //else
            //{
            //    cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "";
            //}
        }

        private void radioButtonNormalTwist_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButtonDeepTwist_CheckedChanged_1(object sender, EventArgs e)
        {
            
        }

        private void radioButtonMediumTwist_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void radioButton2Peices_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2Peices.Checked)
            {
                panelTaba.Visible = false;
                panelHavePlasticCover.Visible = false;
                radioButtonPeding.Visible = false;
                radioButtonNoPeding.Visible = false;
                comboBoxCanTabaDaimetr.Text = "";
                comboBoxCanTabaType.Text = "";
                comboBoxCanTabaColor.Text = "";
            }
            else
            {
                panelTaba.Visible = true;
                panelHavePlasticCover.Visible = true;
                radioButtonPeding.Visible = true;
                radioButtonNoPeding.Visible = true;
            }
        }

        private void radioButtonHaveNoCover_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHaveNoCover.Checked)
            {
                panelFace.Visible = false;
            }
            
        }

        private void radioButton2Peices_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2Peices.Checked)
            {
                panelCansDesc.Visible = false;
                panelCansOutMuran.Visible = false;
                labelnum5.Visible = false;
                radioButtonPeding.Visible = false;
                radioButtonNoPeding.Visible = false;
                panelTinCover.Visible = true;
            }
            else
            {
                panelCansDesc.Visible = true;
                panelCansOutMuran.Visible = true;
                labelnum5.Visible = true;
                radioButtonPeding.Visible = true;
                radioButtonNoPeding.Visible = true;
                panelTinCover.Visible = false;

            }
        }

        private void radioButtonRLTCover_CheckedChanged(object sender, EventArgs e)
        {
            
                if (radioButtonRLTCover.Checked)
            {
                panelRLT.Visible = true;
                panelTinCover.Visible = false;

            }
            else
            {
                panelRLT.Visible = false;
            }
        }

        private void radioButtonPeelOffCover_CheckedChanged(object sender, EventArgs e)
        {
            
                if (radioButtonPeelOffCover.Checked)
            {
                panelPeelOFF.Visible = true;
                panelTinCover.Visible = false;

            }
            else
            {
                panelPeelOFF.Visible = false;
            }
        }



        private void checkBoxHasMold_CheckedChanged_1(object sender, EventArgs e)
        {
            if (comboBoxItemType.SelectedIndex == 0&&checkBoxHasMold.Checked  )
            {
                panelTaba.Visible = true;
            }
            else
            {
                panelTaba.Visible = false;
            }
        }

        private void comboBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCanDaimetrOFSelectedproducts();
        }
 
        
   

        private async void  pillow_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (pillow_check_box.Checked)
            {
                client_product_combo_box.Text = "";
                client_product_combo_box.Items.Clear();
                client_products_label.Text = "اللون";
                await fillwistofcolorpillowcombobox();
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
                {
                    client_product_combo_box.Text = "";
                    client_product_combo_box.Items.Clear();
                    client_products_label.Text = "إسم الصنف";
                    await getallclientproducts(clients[clients_combo_box.SelectedIndex].SH_ID);
                    await fillclientproductscombobox();
                }
                else
                {
                    MessageBox.Show(" لابد من تحديد العميل أولا ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

      

        private void radioButtonHasTinCover_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHasTinCover.Checked)
            {
                labelOutFaceTin.Visible = true;
                labelInFaceTin.Visible = true;
                comboBoxInTinFace.Visible = true;
                comboBoxOutTinFace.Visible = true;
            }
            else
            {
                comboBoxInTinFace.Visible = false;
                comboBoxOutTinFace.Visible = false;
                labelOutFaceTin.Visible = false;
                labelInFaceTin.Visible = false;
            }
        }

        private void textBoxWhenDelivered_TextChanged_1(object sender, EventArgs e)
        {
            double testbox = 0;
            if (double.TryParse(textBoxWhenDelivered.Text, out testbox))
            {
                if (double.Parse(textBoxWhenDelivered.Text) > 0)
                {
                    labelPaymentWay2.Visible = true;
                    comboBoxPaymentWay2.Visible = true;
                }
                else
                {
                    labelPaymentWay2.Visible = false;
                    comboBoxPaymentWay2.Visible = false;
                }
            }
            calcualtettotalPriceNew();
            double paid = double.Parse(textBoxSubmitted.Text) + double.Parse(textBoxWhenDelivered.Text);
            if(string.Compare(paid.ToString(), textBoxTotatalWithTax.Text) == 0)
            {
                panelMoneyAfterReciving.Visible = false;
            }else
            {
                panelMoneyAfterReciving.Visible = true;

            }
        }

        private void radioButtonCanHasButtom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCanHasButtom.Checked)
            {
                panelCanButtomDetail.Visible = true;
            }
            else
            {
                panelCanButtomDetail.Visible = false;
            }
        }

        private void comboBoxPaymentWay3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            switch (comboBoxPaymentWay3.SelectedIndex)
            {

                case 0:
                    labelAfterReciving.Visible = true;
                        comboBoxAfterReciving.Visible = true;
                    labelDateOFSheck3.Visible = false;
                    dateTimePickerChek3.Visible = false;
                    labelBankName3.Visible = false;
                    comboBoxBankName3.Visible = false;

                    break;
                case 1:
                    labelAfterReciving.Visible = false;
                    comboBoxAfterReciving.Visible =false;
                    labelDateOFSheck3.Visible = true;
                    dateTimePickerChek3.Visible = true;
                    labelBankName3.Visible = false;
                    labelDateOFSheck3.Text = "تاريخ الاستحقاق";
                    comboBoxBankName3.Visible = false;

                    break;
                case 2:
                    labelAfterReciving.Visible = false;
                    comboBoxAfterReciving.Visible = false;
                    labelDateOFSheck3.Visible = true;
                    dateTimePickerChek3.Visible = true;
                    comboBoxBankName3.Visible = true;
                    labelBankName3.Visible = true;
                    labelDateOFSheck3.Text = "تاريخ الايداع";

                    break;
                default:
                    labelDateOFSheck3.Visible = false;
                    dateTimePickerChek3.Visible = false;
                    break;
            }
        }

        private void comboBoxPaymentWay2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            switch (comboBoxPaymentWay2.SelectedIndex)
            {

                case 0:
                   
                    labelDateOFSheck2.Visible = false;
                    dateTimePickerChek2.Visible = false;
                    labelBankName2.Visible = false;
                    comboBoxBankName2.Visible = false;
                    break;
                case 1:
                    comboBoxBankName2.Visible = false;
                    labelDateOFSheck2.Visible = true;
                    dateTimePickerChek2.Visible = true;
                    labelBankName2.Visible = false;
                    labelDateOFSheck2.Text = "تاريخ الاستحقاق";
                    break;
                case 2:
                    labelDateOFSheck2.Visible = true;
                    dateTimePickerChek2.Visible = true;
                    comboBoxBankName2.Visible = true;
                    labelBankName2.Visible = true;
                    labelDateOFSheck2.Text = "تاريخ الايداع";

                    break;
                default:
                    labelDateOFSheck2.Visible = false;
                    dateTimePickerChek2.Visible = false;
                    break;
            }
        }


        private void textBoxItemPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void comboBoxCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxItemQnty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxSubmitted_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void comboBoxPaymentWay1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dateTimePickerChek1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxWhenDelivered_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void comboBoxPaymentWay2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxRemaining_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void comboBoxPaymentWay3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void dateTimePickerChek3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void comboBoxBankName3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void buttonNewProduct_Click(object sender, EventArgs e)
        {
            if (clients.Count > 0)
            {
                if (string.IsNullOrEmpty(clients_combo_box.Text))
                {
                    MessageBox.Show("لا بد من تحديد العميل المراد إضافة الأصناف له ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    client_portal myform = new client_portal(clients[clients_combo_box.SelectedIndex]);

                    myform.ShowDialog();


                }
            }
        }

        private void comboBoxNolon_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxNolon.SelectedIndex)
            {
                case 0:
                    radioButtonFromShaheen.Enabled = true;
                  
                    
                    break;

                case 1:
                   radioButtonFromShaheen.Enabled = false;
                    
                    break;
            }
        }

        private void textBoxThichness_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxThichness.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxThichness.Text);
                textBoxThichness.Text = num.ToString();
            }
        }

        private void comboBoxPrintingState_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPrintingState.SelectedIndex)
            {
                case 0:
                    labelOutsideMuran.Visible = false;
                    comboBoxOutSideMuran.Visible = false;
                    break;
                case 1:
                    labelOutsideMuran.Visible = true;
                    comboBoxOutSideMuran.Visible = true;
                    break;
            }
        }

        private void textBoxSubmitted_MouseCaptureChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        private void textBoxWhenDelivered_MouseCaptureChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        private void textBoxRemaining_MouseCaptureChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        private void textBoxItemPrice_MouseCaptureChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        private void textBoxItemQnty_MouseCaptureChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        private void twist_item_type_combo_box_TextChanged(object sender, EventArgs e)
        {
            getalltwistoftypes();
            filltwisttypescombobox();
        }

        private void textBoxRemaining_TextChanged(object sender, EventArgs e)
        {
            //if (long.Parse(textBoxRemaining.Text) > 0)
            //{
            //    labelPaymentWay3.Visible = true;
            //    comboBoxPaymentWay3.Visible = true;
            //}
            //else
            //{
            //    labelPaymentWay3.Visible = false;
            //    comboBoxPaymentWay3.Visible = false;
            //}
        }
    }
    }
    

