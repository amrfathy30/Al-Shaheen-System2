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
    public partial class searchincutprintedmaterial : Form
    {
        List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> parcels = new List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL>();
        List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> ex_parcels = new List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();
        public searchincutprintedmaterial(SH_USER_ACCOUNTS anyAccount)
        {
            InitializeComponent();
            Maccount = anyAccount;
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
        void fillprintedmaterialparcelsgridview()
        {
            parcels.Clear();
            try
            {
                string query = "SELECT SH_PALLETS_OF_CUT_PRINTED_MATERIAL.* ";
                query += " FROM SH_PALLETS_OF_CUT_PRINTED_MATERIAL ";
                query += "WHERE(SH_CLIENT_ID = @SH_CLIENT_ID) AND(SH_PRODUCT_ID = @SH_PRODUCT_ID)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , clients[clients_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID" , client_products[client_products_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parcels.Add(new SH_PALLETS_OF_CUT_PRINTED_MATERIAL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString() , SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()) , SH_ADDTION_PERMISSION_NUMBER = reader["SH_ADDTION_PERMISSION_NUMBER"].ToString() , SH_CUTTER_ID = long.Parse(reader["SH_CUTTER_ID"].ToString()) , SH_CUTTER_NAME = reader["SH_CUTTER_NAME"].ToString() , SH_CUTTER_TECHNICAL_MAN = reader["SH_CUTTER_TECHNICAL_MAN"].ToString() , SH_NUMBER_OF_BOTTLES_PER_SEQUENCE = long.Parse(reader["SH_NUMBER_OF_BOTTLES_PER_SEQUENCE"].ToString()) , SH_NUMBER_OF_SEQUENCES = long.Parse(reader["SH_NUMBER_OF_SEQUENCES"].ToString()) , SH_PRODUCT_ID = long.Parse(reader["SH_PRODUCT_ID"].ToString())  , SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString() , SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL_ID = long.Parse(reader["SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL_ID"].ToString()) , SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID = long.Parse(reader["SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID"].ToString()) , SH_STOCK_ID = long.Parse(reader["SH_STOCK_ID"].ToString()) , SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() , SH_TOTAL_NUMBER_OF_BOTTELS = long.Parse(reader["SH_TOTAL_NUMBER_OF_BOTTELS"].ToString()) , SH_WORK_ORDER_NUMBER = reader["SH_WORK_ORDER_NUMBER"].ToString()});
                   
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING MURAN MATERIAL PARCELS DATA "+ex.ToString());
            }

            if (parcels.Count > 0)
            {
          
                for (int i = 0; i < parcels.Count; i++)
                {
                    parcels_cut_printed_parcels_grid_view.Rows.Add(new string[] { (i+1).ToString() , parcels[i].SH_CLIENT_NAME , parcels[i].SH_PRODUCT_NAME , parcels[i].SH_TOTAL_NUMBER_OF_BOTTELS.ToString() , parcels[i].SH_NUMBER_OF_SEQUENCES.ToString()  });
                }
            }


        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            parcels_cut_printed_parcels_grid_view.Rows.Clear();
            fillprintedmaterialparcelsgridview();
        }

        private void searchincutprintedmaterial_Load(object sender, EventArgs e)
        {
            fill_clients_combo_box();
        }
        void gettingproductsbyclientid()
        {
            client_products.Clear();
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
                        client_products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });


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
            for (int i = 0; i < client_products.Count; i++)
            {
                client_products_combo_box.Items.Add(client_products[i].SH_PRODUCT_NAME);
            }

        }

        private void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillproductscombobox();
        }

        private void exchange_btn_Click(object sender, EventArgs e)
        {
            if (parcels_cut_printed_parcels_grid_view.SelectedRows.Count > 0)
            {
                for (int i = 0; i < parcels_cut_printed_parcels_grid_view.SelectedRows.Count; i++)
                {
                    ex_parcels.Add(parcels[parcels_cut_printed_parcels_grid_view.SelectedRows[i].Index]);
                }
                exchange_of_cut_printed_material myform = new exchange_of_cut_printed_material(ex_parcels,Maccount);
               
                    myform.Show();
               
            }

        }
    }
}
