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
    public partial class DisplaySelectedSupplierItems : Form
    {
        SH_SUPPLY_COMPANY MComp = new SH_SUPPLY_COMPANY();
        List<SH_SUPPLIER_ITEMS> suppItemList = new List<SH_SUPPLIER_ITEMS>();
        public DisplaySelectedSupplierItems(SH_SUPPLY_COMPANY comp)
        {
            InitializeComponent();
            MComp = comp;
        }
        void loadDataGrid()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select distinct SH_ITEM_NAME from  SH_SUPPLIER_ITEMS where SH_SPPLIER_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", MComp.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                  suppItemList.Add(new SH_SUPPLIER_ITEMS { SH_ITEM_NAME=reader["SH_ITEM_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS items DATA" + ex.ToString());
            }
        }

        void fillGrid()
        {
            loadDataGrid();
            if (suppItemList.Count > 0)
            {
                dataGridViewItems.Rows.Clear();
                for (int i = 0; i < suppItemList.Count; i++)
                {
                    dataGridViewItems.Rows.Add(new string[] {(i+1).ToString(),suppItemList[i].SH_ITEM_NAME  });
                }
            }
        }

        private void DisplaySelectedSupplierItems_Load(object sender, EventArgs e)
        {
            fillGrid();
        }
    }
}
