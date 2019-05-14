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
    public partial class quantities_of_selected_sp_raw_tin : Form
    {
        List<SH_QUANTITY_OF_RAW_MATERIAL> quantites = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
        long msp_id;

        public quantities_of_selected_sp_raw_tin(long sp_id)
        {
            InitializeComponent();
            MessageBox.Show(msp_id.ToString());
            msp_id = sp_id;
        }

        void get_sp_quantites()
        {
            quantites.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT SH_QUANTITY_OF_RAW_MATERIAL.* FROM SH_QUANTITY_OF_RAW_MATERIAL WHERE(SH_SPECIFICATION_OF_RAW_MATERIAL_ID = @mysp_id)" , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@mysp_id" , msp_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    quantites.Add(new SH_QUANTITY_OF_RAW_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SPECIFICATION_OF_RAW_MATERIAL_ID = long.Parse(reader["SH_SPECIFICATION_OF_RAW_MATERIAL_ID"].ToString()) , SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString() , SH_NET_WEIGHT = double.Parse(reader["SH_NET_WEIGHT"].ToString()) , SH_ITEM_GROSS_WEIGHT = double.Parse(reader["SH_ITEM_GROSS_WEIGHT"].ToString()) , SH_TOTAL_NUMBER_OF_PACKAGES = long.Parse(reader["SH_TOTAL_NUMBER_OF_PACKAGES"].ToString()) , SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE = long.Parse(reader["SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING DATA" + ex.ToString());
            }  
        }
        void fill_data_grid_view()
        {
            quantites_data_grid_view.Rows.Clear();
            if (quantites.Count > 0)
            {
                for (int i = 0; i < quantites.Count; i++)
                {
                    quantites_data_grid_view.Rows.Add(new string[] { quantites[i].SH_ID.ToString() , quantites[i].SH_SPECIFICATION_OF_RAW_MATERIAL_ID.ToString(), quantites[i].SH_ITEM_CODE ,  quantites[i].SH_TOTAL_NUMBER_OF_PACKAGES.ToString() , quantites[i].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE.ToString() , quantites[i].SH_NET_WEIGHT.ToString() , quantites[i].SH_ITEM_GROSS_WEIGHT.ToString() });
                }
            }
        }

        private void quantities_of_selected_sp_raw_tin_Load(object sender, EventArgs e)
        {
            get_sp_quantites();
            fill_data_grid_view();
        }
    }
}
