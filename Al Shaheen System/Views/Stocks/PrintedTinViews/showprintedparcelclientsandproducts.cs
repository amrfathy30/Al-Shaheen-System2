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
    public partial class showprintedparcelclientsandproducts : Form
    {
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_PRODUCT_OF_CLIENTS_PARCELS> products = new List<SH_PRODUCT_OF_CLIENTS_PARCELS>();
        SH_PRINTED_MATERIAL_PARCEL parcel = new SH_PRINTED_MATERIAL_PARCEL();
        public showprintedparcelclientsandproducts(SH_PRINTED_MATERIAL_PARCEL anyparcel)
        {
            InitializeComponent();
            parcel = anyparcel;
        }



        void fillclientsgridview()
        {

            if (parcel !=null)
            {
                try
                {
                    string query = "SELECT * FROM SH_PRODUCT_OF_CLIENTS_PARCELS WHERE SH_PRINTED_MATERIAL_PARCEL_ID = @SH_PRINTED_MATERIAL_PARCEL_ID";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_PRINTED_MATERIAL_PARCEL_ID", parcel.SH_ID );
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        clients.Add(new SH_CLIENT_COMPANY() { SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) });
                    }
                    myconnection.closeConnection();

                    if (clients.Count > 0)
                    {
                        clients_grid_view.Rows.Clear();
                        for (int i = 0; i < clients.Count; i++)
                        {
                            clients_grid_view.Rows.Add(new string[] { (i + 1).ToString(), clients[i].SH_CLIENT_COMPANY_NAME });
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTING PARCELS DATA "+ex.ToString());
                }





            }



              
        }


        void fillproductsgridview()
        {
            products_grid_view.Rows.Clear();
            products.Clear();
            if (clients_grid_view.SelectedCells.Count > 0)
            {
                try
                {
                    string query = "SELECT * FROM SH_PRODUCT_OF_CLIENTS_PARCELS WHERE SH_CLIENT_ID = @SH_CLIENT_ID AND SH_PRINTED_MATERIAL_PARCEL_ID = @SH_PRINTED_MATERIAL_PARCEL_ID";
                    DatabaseConnection myconection = new DatabaseConnection();
                    myconection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , clients[clients_grid_view.SelectedCells[0].RowIndex].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_PRINTED_MATERIAL_PARCEL_ID" , parcel.SH_ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        products.Add(new SH_PRODUCT_OF_CLIENTS_PARCELS() { SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()) , SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString() , SH_NO_BOTTLES_PER_SHEET = long.Parse(reader["SH_NO_BOTTELS_PER_SHEET"].ToString()) });
                    }
                    myconection.closeConnection();

                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTING PARCEL CLIENT PRODUCTS"+ex.ToString());
                }


                if (products.Count > 0)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        products_grid_view.Rows.Add(new string[] { (i + 1).ToString(), products[i].SH_CLIENT_PRODUCT_NAME, products[i].SH_NO_BOTTLES_PER_SHEET.ToString() });
                    }
                }
            }
        }

        private void clients_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void showprintedparcelclientsandproducts_Load(object sender, EventArgs e)
        {
            fillclientsgridview();
        }

        private void clients_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillproductsgridview();
        }
    }
}
