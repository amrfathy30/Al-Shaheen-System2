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
    public partial class allfacecolors : Form
    {
        List<SH_FACE_COLOR> colors = new List<SH_FACE_COLOR>();
        public allfacecolors()
        {
            InitializeComponent();
        }
        
        void loadcolorsdata()
        {
            try
            {
                string query = "SELECT * FROM SH_FACE_COLORS ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colors.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection(); 
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING FACE COLORS "+ex.ToString());
                
            }
        }   
        void fillcolorsgridview()
        {
            colors.Clear();
            loadcolorsdata();
            colors_grid_view.Rows.Clear();
            if (colors.Count > 0 )
            {
                for (int i = 0; i < colors.Count; i++)
                {
                    colors_grid_view.Rows.Add(new string[] { colors[i].SH_ID.ToString() , colors[i].SH_FACE_COLOR_NAME });
                }
            }
        }
        private void allfacecolors_Load(object sender, EventArgs e)
        {
            fillcolorsgridview();
        }
    }
}
