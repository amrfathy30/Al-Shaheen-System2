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

namespace Al_Shaheen_System.Views.Purchasing.SupplierViews
{
    
    public partial class allitemsform : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_ITEMS> itemList = new List<SH_ITEMS>();
        public allitemsform()
        {
            InitializeComponent();
        }
        void loadItemNames()
        {
            string query = "select * from SH_ITEMS";
            try
            {
                myconnection.openConnection();
                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader red = comm.ExecuteReader();
                while (red.Read())
                {
                    itemList.Add(new SH_ITEMS { SH_ID = long.Parse(red["SH_ID"].ToString()), SH_ITEM_NAME = red["SH_ITEM_NAME"].ToString() });
                }
                red.Close();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading from ITEMS DAtA " + ex.Message);
            }
        }

        void fillitemsgridview()
        {
            loadItemNames();
            if (itemList.Count > 0)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    dataGridView1.Rows.Add(new string[] { (i+1).ToString() , itemList[i].SH_ITEM_NAME});
                }
            }
        }
        private void allitemsform_Load(object sender, EventArgs e)
        {
            fillitemsgridview();
        }
    }
}
