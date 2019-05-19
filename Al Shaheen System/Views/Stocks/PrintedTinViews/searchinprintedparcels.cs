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
    public partial class searchinprintedparcels : Form
    {
        List<SH_PRINTED_MATERIAL_PARCEL> parcels = new List<SH_PRINTED_MATERIAL_PARCEL>();

        List<SH_PRINTED_MATERIAL_PARCEL> ex_parcels = new List<SH_PRINTED_MATERIAL_PARCEL>();
        SH_USER_ACCOUNTS account = new SH_USER_ACCOUNTS();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();

        public searchinprintedparcels(SH_USER_ACCOUNTS anyAccount)
        {
            InitializeComponent();
            account = anyAccount;
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
                        products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });
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
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
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

        private void searchinprintedparcels_Load(object sender, EventArgs e)
        {
            fill_clients_combo_box();
        }

        private void client_products_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fillproductscombobox();
        }



        void getallclientandproductparcels(long client_id , long product_id)
        {
            parcels.Clear();
            try
            {
                string query = "SELECT * FROM SH_PRINTED_MATERIAL_PARCEL WHERE SH_ID IN ( SELECT SH_PRINTED_MATERIAL_PARCEL_ID FROM SH_PRODUCT_OF_CLIENTS_PARCELS WHERE(SH_CLIENT_ID = @SH_CLIENT_ID AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID) AND ( SH_PRINTED_MATERIAL_PARCEL_ID  NOT IN (SELECT SH_PRINTED_MATERIAL_PARCEL_ID  FROM SH_EXCHANGED_PRINTED_MATERIAL_PARCELS)) )";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", product_id);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , client_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parcels.Add(new SH_PRINTED_MATERIAL_PARCEL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()), SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString(), SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString(), SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString(), SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_SHEET_WEIGHT = double.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()), SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString(), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), SH_ITEM_TOTAL_GROSS_WEIGHT = double.Parse(reader["SH_ITEM_GROSS_WEIGHT"].ToString()), SH_ITEM_TOTAL_NET_WEIGHT = double.Parse( reader["SH_ITEM_NET_WEIGHT"].ToString()),SH_ITEM_TOTAL_NO_SHEETS=long.Parse(reader["SH_ITEM_NO_SHEETS"].ToString()),SH_ITEM_TYPE=reader["SH_ITEM_TYPE"].ToString(),SH_ITEM_WIDTH= double.Parse(reader["SH_ITEM_WIDTH"].ToString()),SH_PARCEL_NET_WEIGHT= double.Parse(reader["SH_ITEM_NET_WEIGHT"].ToString()),SH_PARCEL_NO_SHEETS=long.Parse(reader["SH_ITEM_NO_SHEETS"].ToString()),SH_PRINTER_ID=long.Parse(reader["SH_PRINTER_ID"].ToString()),SH_PRINTER_NAME=reader["SH_PRINTER_NAME"].ToString(),SH_PRINTING_PERMISSION_NUMBER=reader["SH_PRINTING_PERMISSION_NUMBER"].ToString(),SH_QUANTITIES_OF_PRINTED_MATERIAL_ID=long.Parse(reader["SH_QUANTITIES_OF_PRINTED_MATERIAL_ID"].ToString()),SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID=reader["SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID"].ToString(),SH_STOCK_NAME=reader["SH_STOCK_NAME"].ToString(),SH_TOTAL_NUMBER_OF_BOTTELS=long.Parse(reader["SH_TOTAL_NUMBER_OF_BOTTELS"].ToString()),SH_WORK_ORDER_NUMBER=reader["SH_WORK_ORDER_NUMBER"].ToString() } );
                }
                myconnection.closeConnection();
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTED PARCELS  "+ex.ToString());
            }
        }

        void fillprintedparcelsgridview()
        {
            client_products_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    client_products_grid_view.Rows.Add(new string[] { (i + 1).ToString()  , parcels[i].SH_ITEM_CODE , parcels[i].SH_ITEM_TOTAL_NO_SHEETS.ToString() , parcels[i].SH_ITEM_TOTAL_GROSS_WEIGHT.ToString() });
                }
            }
        }


        private void search_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clients_combo_box.Text) || string.IsNullOrEmpty(client_products_combo_box.Text))
            {

            }
            else
            {
                getallclientandproductparcels(clients[clients_combo_box.SelectedIndex].SH_ID , products[client_products_combo_box.SelectedIndex].SH_ID);

                fillprintedparcelsgridview();
            }
        }

        private void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillproductscombobox();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ex_parcels.Clear();
            if (client_products_grid_view.SelectedRows.Count > 0)
            {
                for (int i = 0; i < client_products_grid_view.SelectedRows.Count; i++)
                {
                    ex_parcels.Add(parcels[client_products_grid_view.SelectedRows[i].Index]);

                }

                exchangeofprintedmaterial myform = new exchangeofprintedmaterial(ex_parcels,account);
              
                    myform.Show();
              


            }else
            {
                MessageBox.Show("لابد من تحديد الطرد المراد صرفه " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }

           
        }
    }
}
