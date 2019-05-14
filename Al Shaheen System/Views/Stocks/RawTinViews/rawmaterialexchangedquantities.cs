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
    public partial class rawmaterialexchangedquantities : Form
    {
        List<SH_EXCHANGE_OF_RAW_MATERIAL> quntities = new List<SH_EXCHANGE_OF_RAW_MATERIAL>();

      
        List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        public rawmaterialexchangedquantities(List<SH_EXCHANGE_OF_RAW_MATERIAL> myquantity)
        {
            InitializeComponent();
            quntities = myquantity;
        }

        void fillquantitiesgridview()
        {
            quantities_grid_view.Rows.Clear();
            if (quntities.Count > 0)
            {
                for (int i = 0; i < quntities.Count; i++)
                {
                    quantities_grid_view.Rows.Add(new string[] { (i+1).ToString() , quntities[i].SH_ID.ToString() });
                }
            }
        }


        void getechangedrawparcels(long er_id)
        {
            parcels.Clear();
            er_id = 0;
            try
            {
                string query = "SELECT * FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL WHERE SH_EXCHANGE_OF_RAW_MATERIAL_ID  = @myvalue)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@myvalue", er_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   // MessageBox.Show("Test");
                    parcels.Add(new SH_RAW_MATERIAL_PARCEL() { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING EXCHANGED PARCELS " + ex.ToString());
            }
        }

        void fillparcelsgridview()
        {
            quantity_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    quantity_parcels_grid_view.Rows.Add(new string[] { (i+1).ToString() , parcels[i].SH_ID.ToString() });
                }

            }


        }

        private void quantities_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  MessageBox.Show(quantities_grid_view.SelectedCells[0].RowIndex.ToString());
            getechangedrawparcels(quntities[quantities_grid_view.SelectedCells[0].RowIndex].SH_ID);
            fillparcelsgridview();
        }

        private void rawmaterialexchangedquantities_Load(object sender, EventArgs e)
        {
            fillquantitiesgridview();
        }

        private void quantities_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
