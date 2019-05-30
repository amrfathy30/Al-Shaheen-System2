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
    public partial class clientmaterialbalanceform : Form
    {
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        List<client_material_balance_items> materials = new List<client_material_balance_items>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public clientmaterialbalanceform( )
        {
            InitializeComponent();
            
        }

        async Task getprintedmaterialdatabyclientproduct()
        {

        }

        async Task getmuranmaterialdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;

            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }


            //if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            //{
            //    product = false;

            //}
            //else
            //{
            //    product = true;
            //    product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
            //}
            try
            {

           
            myconnection.openConnection();
            string query = "SELECT * FROM SH_SPECIFICATION_OF_MURAN_MATERIAL WHERE 1=1 "+client_q;
            SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
            if (client)
            {
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
            }
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                materials.Add(new client_material_balance_items() {
                    container_name = "طرد",
                    material_name = "صفيح مطبوع",
                    no_of_containers = long.Parse(reader["SH_ITEM_TOTAL_NUMBER_OF_PACKAGES"].ToString()),
                    total_no_items = long.Parse(reader["SH_ITEM_TOTAL_NUMBER_OF_SHEETS"].ToString())
                });
            }
            reader.Close();
            myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING MURAN MATERIAL INFO "+ex.ToString());
            }
        }
        async Task getprintedmaterialdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;

            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }


            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_PRODUCT_ID = @SH_PRODUCT_ID";
            }

            try
            {


                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PRINTED_MATERIAL WHERE SH_ID IN (SELECT SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID FROM SH_PRODUCT_OF_CLIENTS_QUANTITIES  WHERE 1=1 " + client_q +product_q+")";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = "طرد",
                        material_name = "صفيح مطبوع",
                        no_of_containers = long.Parse(reader["SH_ITEM_TOTAL_NO_PARCELS"].ToString()),
                        total_no_items = long.Parse(reader["SH_ITEM_TOTAL_NO_SHEETS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTED MATERIAL INFO " + ex.ToString());
            }
        }
        async Task getfinishedcansdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID  ";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID ";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_CALCULATE_TOTAL_FINISHED_PRODUCT  WHERE 1=1 " + client_q + product_q ;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = "بالتة",
                        material_name = "علب منتج تام",
                        no_of_containers = long.Parse(reader["SH_TOTAL_NUMBER_OF_PALLET"].ToString()),
                        total_no_items = long.Parse(reader["SH_TOTAL_NUMBER_OF_CANS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FINISHED CANS MATERIAL INFO " + ex.ToString());
            }
        }
        async Task getcutprintedmaterialdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_PRODUCT_ID = @SH_PRODUCT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL  WHERE 1=1 " + client_q + product_q ;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = "طرد",
                        material_name = "صفيح مقصوص مطبوع ",
                        no_of_containers = long.Parse(reader["SH_TOTAL_NUMBER_OF_PALLETS"].ToString()),
                        total_no_items = long.Parse(reader["SH_TOTAL_NUMBER_OF_BOTTELS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CUT PRINTED MATERIAL INFO " + ex.ToString());
            }
        }
        async Task getcutmuranmaterialdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            
            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL  WHERE 1=1 " + client_q + product_q ;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
               
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = "طرد",
                        material_name = "صفيح مقصوص مورنش ",
                        no_of_containers = long.Parse(reader["SH_TOTAL_NO_PALLETS"].ToString()),
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_BOTTELS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FINISHED CANS MATERIAL INFO " + ex.ToString());
            }
        }
        async Task gettrwistofdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_TWIST_OF  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "تويست أوف ",
                        no_of_containers = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_TEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF  INFO " + ex.ToString());
            }
        }
        async Task getpeeloffdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PEEL_OFF  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "بيل أوف",
                        no_of_containers = 0,
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF  INFO " + ex.ToString());
            }
        }
        async Task getrltdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_RLT  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "RLT ",
                        no_of_containers = 0,
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING RLT  INFO " + ex.ToString());
            }
        }
        async Task getplasticcoverdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            
            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PLASTIC_COVER  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
              
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "غطاء بلاستيك ",
                        no_of_containers = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PLASTIC COVER  INFO " + ex.ToString());
            }
        }
        async Task getplasticmolddata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PLASTIC_MOLD  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "طبة بلاستيك ",
                        no_of_containers = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PLASTIC MOLD  INFO " + ex.ToString());
            }
        }
        async Task getbottomdata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_BOTTOM  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "القاع ",
                        no_of_containers = 0,
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING BOTTOM  INFO " + ex.ToString());
            }
        }
        async Task geteasyopendata()
        {
            bool client = false;
            string client_q = "";
            bool product = false;
            string product_q = "";
            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                client = false;
            }
            else
            {
                client = true;
                client_q = "AND SH_CLIENT_ID = @SH_CLIENT_ID";
            }
            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;

            }
            else
            {
                product = true;
                product_q = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
            }

            try
            {
                myconnection.openConnection();
                string query = "SELECT * FROM SH_SPECIFICATION_OF_EASY_OPEN  WHERE 1=1 " + client_q + product_q;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[client_products_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materials.Add(new client_material_balance_items()
                    {
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        material_name = "إيزى أوبن ",
                        no_of_containers = 0,
                        total_no_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING EASY OPEN  INFO " + ex.ToString());
            }
        }







        async Task  fillmaterialbalancedata()
        {
            DataTable mydatatabel = new DataTable();
            mydatatabel.Columns.Add("م");
            mydatatabel.Columns.Add("إسم النوع");
            mydatatabel.Columns.Add("التعبئة");
            mydatatabel.Columns.Add("عدد التعبئة");
            mydatatabel.Columns.Add("عدد الشرحة أو العلبة");
            if (materials.Count>0)
            {
               
                for (int i = 0; i < materials.Count; i++)
                {
                    string[] mydata = new string[5];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = materials[i].material_name;
                    mydata[2] = materials[i].container_name;
                    mydata[3] = materials[i].no_of_containers.ToString();
                    mydata[4] = materials[i].total_no_items.ToString();
                    mydatatabel.Rows.Add(mydata);
                }
               
            }

            client_material_grid_view.DataSource = mydatatabel;
        }


        private async void search_btn_Click(object sender, EventArgs e)
        {
            materials.Clear();

            if (string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {

            }
            else
            {
                
                await getmuranmaterialdata();
                await getprintedmaterialdata();
                await getfinishedcansdata();
                await getcutprintedmaterialdata();
                await getcutmuranmaterialdata();
                await gettrwistofdata();
                await getpeeloffdata();
                await getrltdata();
                await getplasticcoverdata();
                await getplasticmolddata();
                await getbottomdata();
                await geteasyopendata();

                await fillmaterialbalancedata();

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
            client_name_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    client_name_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }
        void gettingproductsbyclientid()
        {
            client_products.Clear();
            if (string.IsNullOrEmpty(client_name_combo_box.Text))
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
                    cmd.Parameters.AddWithValue("@CLIENT_ID", clients[client_name_combo_box.SelectedIndex].SH_ID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        //getting products data
                        client_products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });


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

        void fillproductscombobox()
        {
            client_products_combo_box.Items.Clear();
            gettingproductsbyclientid();
            for (int i = 0; i < client_products.Count; i++)
            {
                client_products_combo_box.Items.Add(client_products[i].SH_PRODUCT_NAME);
            }

        }
        private async void clientmaterialbalanceform_Load(object sender, EventArgs e)
        {
            await fillclientscombobox();
        }

        private void client_name_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(client_name_combo_box.Text))
            {
                fillproductscombobox();
            }

        }
    }
}
