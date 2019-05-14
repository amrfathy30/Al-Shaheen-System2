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
        List<SH_SUPPLIER_ITEMS> supply_items = new List<SH_SUPPLIER_ITEMS>();
        SH_SUPPLY_COMPANY MComp = new SH_SUPPLY_COMPANY();
        DatabaseConnection myconnection = new DatabaseConnection();
        public AddNewItemForSupplierFrm(SH_SUPPLY_COMPANY anycompany)
        {
            InitializeComponent();
            MComp = anycompany;
        }

        private void AddNewItemForSupplierFrm_Load(object sender, EventArgs e)
        {
            textBoxSupplierName.Text = MComp.SH_SUPPLY_COMAPNY_NAME;
            fill_all_items_grid_view();
        }


        void loadallsupplier_items()
        {
            supply_items.Clear();
            try
            {
                string query = "SELECT SM.* , (SELECT  M.SH_ITEM_NAME FROM SH_ITEMS M WHERE M.SH_ID  = SM.SH_ITEM_ID )AS SH_SUPPLIER_ITEM_NAME  FROM SH_SUPPLIER_ITEMS  SM WHERE SM.SH_SUPPLIER_ID = @SH_SUPPLIER_ID ";
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_ID" , MComp.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    supply_items.Add(new SH_SUPPLIER_ITEMS() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_ITEM_ID = long.Parse(reader["SH_ITEM_ID"].ToString()), SH_ITEM_NAME = reader["SH_SUPPLIER_ITEM_NAME"].ToString()   });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING SUPPLIER ITEMS "+ex.ToString());
            }
        }

        long check_if_item_exists_for_supply_company_or_not()
        {
            loadallsupplier_items();
            if (supply_items.Count > 0)
            {
                for (int i = 0; i < supply_items.Count; i++)
                {
                    if (string.Compare(supply_items[i].SH_ITEM_NAME.Trim(), textBoxItemName.Text.Trim()) == 0)
                    {
                        return supply_items[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        void fill_all_items_grid_view ()
        {
            loadallsupplier_items();
            item_grid_view.Rows.Clear();
            if (supply_items.Count>0)
            {
                for (int i = 0; i < supply_items.Count; i++)
                {
                    
                    item_grid_view.Rows.Add(new string[] { (i+1).ToString() , supply_items[i].SH_ITEM_NAME });
                }
            }
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


        long checkItemID()
        {
            
            if (itemList.Count > 0)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (string.Compare(itemList[i].SH_ITEM_NAME.Trim(), textBoxItemName.Text.Trim()) == 0)
                    {
                        return  itemList[i].SH_ID;
                       
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

                myconnection.openConnection();

                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                comm.Parameters.AddWithValue("@name", textBoxItemName.Text);




                SqlDataReader reader = comm.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid; 


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
                long myid = 0;
                if (reader.Read())
                {
                    myid =  long.Parse(reader["myidentity"].ToString());

                }
                reader.Close();
                myconnection.closeConnection();
                return myid;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in inserting in Supplier Items Table" + ex.Message);
            }

            return 0;
        }


        int check_if_item_company_exists_or_not()
        {
            if (itemList.Count > 0)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    if (string.Compare(itemList[i].SH_ITEM_NAME.Trim(), textBoxItemName.Text.Trim()) == 0)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBoxItemName.Text))
            {
                MessageBox.Show("الرجاء كتابة إسم الصنف  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {

                long myid = check_if_item_exists_for_supply_company_or_not();
                if (myid==0)
                {
                    loadItemNames();
                    long item_id = checkItemID();
                    if (item_id == 0)
                    {
                        long idItem = insertItem();
                        insertSupplierItem(idItem);
                        fill_all_items_grid_view();
                    }
                    else
                    {
                        insertSupplierItem(item_id);
                        fill_all_items_grid_view();
                    }
                    button1.Enabled = false;
                    MessageBox.Show("تمت الاضافه بنجاح ", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                  
                }
                else
                {
                    MessageBox.Show("هذا الصنف موجود بالفعل ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
            }
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
