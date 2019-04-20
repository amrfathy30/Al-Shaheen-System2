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
    public partial class allprintersform : Form
    {

        List<SH_TIN_PRINTER> printers = new List<SH_TIN_PRINTER>();

        public allprintersform()
        {
            InitializeComponent();
        }

        void loadallprintersdata()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_TIN_PRINTER" , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    printers.Add(new SH_TIN_PRINTER() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_PRINTER = reader["SH_PRINTER"].ToString() , SH_PRINTER_ADDRESS_TEXT = reader["SH_PRINTER_ADDRESS_TEXT"].ToString() , SH_PRINTER_ADDRESS_GPS= reader["SH_PRINTER_ADDRESS_GPS"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTERS DATA "+ex.ToString());
            }   
        }

        void fillprintersgridview()
        {
            loadallprintersdata();
            if (printers.Count <= 0)
            {

            }else
            {
                printers_grid_view.Rows.Clear();
                for (int i = 0; i < printers.Count; i++)
                {
                    printers_grid_view.Rows.Add(new string[] { printers[i].SH_ID.ToString() , printers[i].SH_PRINTER , printers[i].SH_PRINTER_ADDRESS_TEXT , printers[i].SH_PRINTER_ADDRESS_GPS  });
                }

            }
        }
        private void allprintersform_Load(object sender, EventArgs e)
        {
            fillprintersgridview();
        }
    }
}
