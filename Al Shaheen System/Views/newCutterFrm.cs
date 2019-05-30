using System;
using System.Collections.Generic;

using System.Data;
using System.Data.SqlClient;

using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class newCutterFrm : Form
    { SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();
        public newCutterFrm(SH_USER_ACCOUNTS anyaccount)
        {
            InitializeComponent();
            Maccount = anyaccount;
        }
        void gettingClientproducts()
        {

            products.Clear();
           
           
                try
                {
                    string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS ";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                 
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //getting products data
                        products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString() });
                    }

                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE GETTING CLIENT  PRODUCTS");
                }
            }
        void fillclientproductsgridview()
        {
            gettingClientproducts();
            dataGridView1.Rows.Clear();
            if (products.Count > 0)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    dataGridView1.Rows.Add(new string[] { (i + 1).ToString(), products[i].SH_CLIENT_NAME, products[i].SH_PRODUCT_NAME });
                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newCutterFrm_Load(object sender, EventArgs e)
        {
            fillclientproductsgridview();

        }
        void gettingClientproductsByiD()
        {

          //  products.Clear();


            try
            {
                string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS  where SH_CLIENTS_PRODUCTS.SH_CLIENT_ID=@id";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", products[dataGridView1.CurrentRow.Index].SH_CLIENT_ID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //getting products data
                    products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString()  });
                }

                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS by id");
            }
        }
        void fillControls()
        {
            gettingClientproductsByiD();
            for (int i = 0; i < products.Count; i++)
            {


                textBoxClientName.Text = products[i].SH_CLIENT_NAME;
                textBoxHieght.Text = products[i].SH_BOTTLE_HEIGHT.ToString();
                textBoxInFace.Text = products[i].SH_SECOND_FACE_NAME;
                textBoxOutFace.Text = products[i].SH_CLIENT_NAME;
                textBoxProductName.Text = products[i].SH_PRODUCT_NAME;
                textBoxSize.Text = products[i].SH_SIZE_NAME;
              
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            fillControls();
        }
        void saveCutterDaily()
        {
            DatabaseConnection myconnection = new DatabaseConnection();
            try
            {
               
                myconnection.openConnection();
 
                       SqlCommand cmd = new SqlCommand("addCutter_daily", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME",textBoxClientName.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID",0);//pending
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", textBoxProductName.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_SIZE", textBoxSize.Text);

                cmd.Parameters.AddWithValue("@SH_PRODUCT_HIGHT", double.Parse(textBoxHieght.Text));
                cmd.Parameters.AddWithValue("@SH_OUT_FACE", textBoxOutFace.Text);
                cmd.Parameters.AddWithValue("@SH_INSIDE_FACE", textBoxInFace.Text);
                cmd.Parameters.AddWithValue("@SH_PRINTER_TYPE", textBoxPrinterType.Text);
                cmd.Parameters.AddWithValue("@SH_PRINTER_STATUS", textBoxPrinterStatus.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NUMBER_OF_SHEET",long.Parse(textBoxQntyWithSheet.Text));//العدد في الشيت ام العدد بالشيت تميز
                cmd.Parameters.AddWithValue("@SH_PARCEL_HIGHT", double.Parse(textBoxTardHieht.Text));
                cmd.Parameters.AddWithValue("@SH_PARCEL_WIDTH", double.Parse(textBoxParcelWidth.Text));
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_SHEETS_PER_ONE_PARCEL", long.Parse(textBoxNumberOFSheetsPerParcel.Text));
                cmd.Parameters.AddWithValue("@SH_QUANTITY_DESTROYED_BY_CUTTER", long.Parse(textBoxCutterDestroy.Text));
                cmd.Parameters.AddWithValue("@SH_EXPECTED_QUNTITY", long.Parse(textBoxExpectedQnty.Text));
                cmd.Parameters.AddWithValue("@SH_QUANTITY_DESTROYED_BY_PRINTER", long.Parse(textBoxPrinterDestroy.Text));
                cmd.Parameters.AddWithValue("@SH_ACTUAL_QUNTITY", long.Parse(textBoxAcualQnty.Text));
                cmd.Parameters.AddWithValue("@SH_REGISTERED_DATE",DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_REGISTERED_BY",Maccount.SH_EMP_NAME);
           
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تسجيل البيانات");
                buttonSave.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in inserting Cutter Daily" + ex.ToString());
                myconnection.closeConnection();
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveCutterDaily();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            newCutterFrm frm = new newCutterFrm(Maccount);
            frm.Show();
        }

        private void textBoxPrinterDestroy_TextChanged(object sender, EventArgs e)
        {
            long totalDestroyed=0;
            totalDestroyed = long.Parse(textBoxPrinterDestroy.Text) + long.Parse(textBoxCutterDestroy.Text);
      
            textBoxAcualQnty.Text = (long.Parse(textBoxExpectedQnty.Text) - totalDestroyed).ToString();
        }

        private void textBoxCutterDestroy_TextChanged(object sender, EventArgs e)
        {
            long totalDestroyed = 0;
            totalDestroyed = long.Parse(textBoxPrinterDestroy.Text) + long.Parse(textBoxCutterDestroy.Text);

            textBoxAcualQnty.Text = (long.Parse(textBoxExpectedQnty.Text) - totalDestroyed).ToString();
        }
    }
}
