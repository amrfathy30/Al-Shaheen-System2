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
                    string query = "SELECT PCP.* FROM SH_PRODUCT_OF_CLIENTS_PARCELS PCP WHERE PCP.SH_PRINTED_MATERIAL_PARCEL_ID  = @SH_PRINTED_MATERIAL_PARCEL_ID";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_PRINTED_MATERIAL_PARCEL_ID", parcel.SH_ID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    long i = 0;
                    while (reader.Read())
                    {
                        i++;
                        clients_grid_view.Rows.Add(new string[] { (i + 1).ToString(), reader["SH_CLIENT_NAME"].ToString() , reader["SH_CLIENT_PRODUCT_NAME"].ToString() ,reader["SH_NO_BOTTELS_PER_SHEET"].ToString() , reader["SH_TOTAL_NUMBER_OF_BOTTELS"].ToString() });

                    }
                    reader.Close();
                    myconnection.closeConnection();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTING PARCELS DATA " + ex.ToString());
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
            
        }
    }
}
