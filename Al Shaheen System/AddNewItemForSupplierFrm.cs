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
    public partial class AddNewItemForSupplierFrm : Form
    {
        List<SH_ITEMS> itemList = new List<SH_ITEMS>();
        SH_SUPPLY_COMPANY MComp = new SH_SUPPLY_COMPANY();
        public AddNewItemForSupplierFrm(SH_SUPPLY_COMPANY anycompany)
        {
            InitializeComponent();
            MComp = anycompany;
        }

        private void AddNewItemForSupplierFrm_Load(object sender, EventArgs e)
        {
            textBoxSupplierName.Text = MComp.SH_SUPPLY_COMAPNY_NAME;
        }


        void loadItemNames()
        {
            string query = "select * from SH_ITEMS";

            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();

                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);

                SqlDataReader red = comm.ExecuteReader();
                while (red.Read())
                {




                    itemList.Add(new SH_ITEMS { SH_ID = long.Parse(red["SH_ID"].ToString()), SH_ITEM_NAME = red["SH_ITEM_NAME"].ToString() });
                }

                conn.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading from SH_ITEM table" + ex.Message);
            }
        }


        long checkItemID()
        {
            long spc_id = 0;
            if (itemList.Count > 0)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (string.Compare(itemList[i].SH_ITEM_NAME, textBoxItemName.Text) == 0)
                    {
                        spc_id = itemList[i].SH_ID;
                        return spc_id;

                    }


                }
            }
            return 0;
        }


        long insertItem()
        {
            string query = "insert into SH_ITEMS(SH_ITEM_NAME)values(@name)";
            query += "SELECT SCOPE_IDENTITY() AS myidentity";
            try
            {

                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();

                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                comm.Parameters.AddWithValue("@name", textBoxItemName.Text);




                SqlDataReader reader = comm.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                conn.closeConnection();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in inserting in Items Table" + ex.Message);
            }
            return 0;

        }
    

      long  insertSupplierItem(long itm_id)
        {

            string query = "insert into SH_SUPPLIER_ITEMS values(@item_ID,@Item_name,@supplier_id,@supplier_name)";
            //query += "SELECT SCOPE_IDENTITY() AS myidentity";
            try
            {

                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();

                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                comm.Parameters.AddWithValue("@item_ID", itm_id);
                comm.Parameters.AddWithValue("@Item_name",textBoxItemName.Text );
                comm.Parameters.AddWithValue("@supplier_id", MComp.SH_ID);
                comm.Parameters.AddWithValue("@supplier_name", MComp.SH_SUPPLY_COMAPNY_NAME);


                SqlDataReader reader = comm.ExecuteReader();

                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in inserting in Supplier Items Table" + ex.Message);
            }

            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadItemNames();
            long item_id = checkItemID();
            if (item_id == 0)
            {
            long idItem = insertItem();
                insertSupplierItem(idItem);

            }
            else
            {
                insertSupplierItem(item_id);
            }
            MessageBox.Show("تمت الاضافه بنجاح ");
          button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewItemForSupplierFrm frm = new AddNewItemForSupplierFrm(MComp);
            frm.ShowDialog();
        }

        private void AddNewItemForSupplierFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AllSelectedSupplierDataFrm frm = new AllSelectedSupplierDataFrm(MComp);
            //frm.ShowDialog();
        }
    }
}
