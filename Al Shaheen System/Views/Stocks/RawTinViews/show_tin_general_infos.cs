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
    public partial class show_tin_general_infos : Form
    {
        List<SH_QUANTITY_OF_RAW_MATERIAL> mquantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
        List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        public show_tin_general_infos(List<SH_QUANTITY_OF_RAW_MATERIAL> anyquantity)
        {
            InitializeComponent();
            mquantities = anyquantity;
        }

        void fillquantitiesgridview()
        {
            if (mquantities.Count>0)
            {
                for (int i = 0; i < mquantities.Count; i++)
                {
                    quantities_grid_view.Rows.Add(new string[] { (i+1).ToString() , mquantities[i].SH_ID.ToString() , mquantities[i].SH_ITEM_LENGTH.ToString() , mquantities[i].SH_ITEM_WIDTH.ToString() , mquantities[i].SH_ITEM_THICKNESS.ToString() , mquantities[i].SH_ITEM_CODE , mquantities[i].SH_TOTAL_NUMBER_OF_PACKAGES.ToString() , mquantities[i].SH_TOTAL_NUMBER_OF_SHEETS().ToString() , mquantities[i].SH_DATE_SUPPLY.ToString() , mquantities[i].SH_SUPPLIER_NAME , mquantities[i].SH_ITEM_TYPE , mquantities[i].SH_ITEM_TEMPER , mquantities[i].SH_ITEM_COATING , mquantities[i].SH_ITEM_FINISH });
                }
            }
        }


        void loadquantityparcels(long qu_id)
        {
            parcels.Clear();
            try
            {
                string query = "SELECT * FROM SH_RAW_MATERIAL_PARCEL WHERE SH_QUANTITY_OF_RAW_MATERIAL_ID = @SH_QUANTITY_OF_RAW_MATERIAL_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_RAW_MATERIAL_ID", qu_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parcels.Add(new SH_RAW_MATERIAL_PARCEL() { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }


                myconnection.closeConnection();
                fillquantityparcelsgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PARCELS INFOS " +ex.ToString());
            }  
        }

        void fillquantityparcelsgridview()
        {

            quantity_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
              //  quantity_parcels_grid_view.Rows.Clear();
                for (int i = 0; i < parcels.Count; i++)
                {
                    quantity_parcels_grid_view.Rows.Add( new string[] { (i+1).ToString(), parcels[i].SH_ID.ToString() });
                }
            }



        }




        private void show_tin_general_infos_Load(object sender, EventArgs e)
        {
            fillquantitiesgridview();
        }

        private void quantities_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void quantities_grid_view_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void quantities_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow myrow = quantities_grid_view.SelectedCells[0].OwningRow;
            loadquantityparcels(mquantities[myrow.Index].SH_ID);
        }
    }
}
