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
    public partial class ExchangeNewWorkOrders : Form
    {
        SH_SPECIFICATION_OF_RLT specf = new SH_SPECIFICATION_OF_RLT();
        List<SH_SPECIFICATION_OF_RLT> RLTSpecList = new List<SH_SPECIFICATION_OF_RLT>();
        CLIENT_ORDER_WORK clientOrder = new CLIENT_ORDER_WORK();
        SH_USER_ACCOUNTS acc = new SH_USER_ACCOUNTS();
        public ExchangeNewWorkOrders(CLIENT_ORDER_WORK anyclientOrder)
        {
            InitializeComponent();
            clientOrder = anyclientOrder;
        }



         long  loadRLTSpcification()
        {
            RLTSpecList.Clear();

            try
            {
                //SH_SIZE_NAME,SH_CLIENT_PRODUCT_NAME,SH_TOTAL_NO_ITEMS,SH_CONTAINER_NAME 
                string query = "select * from SH_SPECIFICATION_OF_RLT WHERE  SH_SIZE_NAME=@size";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@size", textBoxDaimetr.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RLTSpecList.Add(new SH_SPECIFICATION_OF_RLT() {SH_ID=long.Parse(reader["SH_ID"].ToString()), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_CLIENT_PRODUCT_NAME=reader["SH_CLIENT_PRODUCT_NAME"].ToString(), SH_TOTAL_NO_ITEMS=long.Parse( reader["SH_TOTAL_NO_ITEMS"].ToString()), SH_CONTAINER_NAME=reader["SH_CONTAINER_NAME"].ToString() });
                    long id_spec =long.Parse( reader["SH_ID"].ToString());
                    textBoxQntyInStock.Clear();
                    textBoxQntyInStock.Text = reader["SH_TOTAL_NO_ITEMS"].ToString();
                    return id_spec;
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING RLT specification FROM DB " + ex.ToString());
            }
            return 0;
        }
        void fillRLTSpecifgridview()
        {
            dataGridViewRLTQnty.Rows.Clear();

            loadRLTSpcification();
            if (RLTSpecList.Count > 0)
            {
                for (int i = 0; i < RLTSpecList.Count; i++)
                {
                    dataGridViewRLTQnty.Rows.Add(new string[] { RLTSpecList[i]. SH_SIZE_NAME, RLTSpecList[i].SH_CLIENT_PRODUCT_NAME, RLTSpecList[i].SH_TOTAL_NO_ITEMS.ToString(), RLTSpecList[i].SH_CONTAINER_NAME });
                  
                   
                  
                }
            }
        }

  
        private void button2_Click(object sender, EventArgs e)
        {
            using (searchinmuranparcels myform = new searchinmuranparcels())
            {
                myform.ShowDialog();
            }
        }

        private void ExchangeNewWorkOrders_Load(object sender, EventArgs e)
        {
          

            textBoxClintName.Text = clientOrder.SH_CLIENT_NAME;
            textBoxProductName.Text = clientOrder.SH_ITEM_NAME;
            textBoxSupplyNum.Text = clientOrder.SH_ID_STRING;
            textBoxQnt.Text = clientOrder.SH_QUANTITY.ToString();
            textBoxProductType.Text = clientOrder.SH_ITEM_TYPE;
            textBoxDaimetr.Text = clientOrder.SH_RLT_DAIAMETR.ToString();
            fillRLTSpecifgridview();
        }

      



        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        void addNewExchangeRequest()
        {
            try
            {

                loadRLTSpcification();
                  DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("addNewExchangeRequest", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", textBoxClintName.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clientOrder.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_ORDER_SUPPLY_WORK", textBoxSupplyNum.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", textBoxProductName.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_TYPE", textBoxProductType.Text);
                cmd.Parameters.AddWithValue("@SH_RLT_DAIMETR",long.Parse( textBoxDaimetr.Text));
                cmd.Parameters.AddWithValue("@SH_QUANTITIY_REQUIRED",clientOrder.SH_QUANTITY);
                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY_IN_STOCKS",long.Parse( textBoxQntyInStock.Text));
                cmd.Parameters.AddWithValue("@SH_DATA_ENTERED_BY", "amr abbas");
                cmd.Parameters.AddWithValue("@SH_REGISTERED_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM", clientOrder.SH_CLIENT_SUPPLY_ORDER_NUM);
                long id = loadRLTSpcification();
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID_SPECIFICATION",id);
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ارسال الطلب الى المخازن");
            } catch(Exception ex)
            {
                MessageBox.Show("ERRor" + ex.ToString());
            }
            }
        void changeStatusClientOrders()
        {

            try
            {


                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("update CLIENT_ORDER_WORK set SH_STATUS=1 where SH_ID=@id ", DatabaseConnection.mConnection);

                cmd.Parameters.AddWithValue("@id", clientOrder.SH_ID);
                cmd.ExecuteNonQuery();
                
            } catch(Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());
                


            }
            }
        private void buttonExchangeRLT_Click(object sender, EventArgs e)
        {

            long x = (long.Parse(textBoxQntyInStock.Text) - long.Parse(textBoxQnt.Text));
            if (x >= 0)
            {
                textBoxRemaining.Clear();
                textBoxRemaining.Text = x.ToString();
                addNewExchangeRequest();
                changeStatusClientOrders();
               


            }
            else
            {
                MessageBox.Show("الكمية لا تكفى الرجاء عمل طلب شراء");
                buttonBuyRequest.Visible = true;
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            long id=  loadRLTSpcification();
          
            MessageBox.Show("id" + id);
        }

        private void dataGridViewRLTQnty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxRemaining_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBoxQntyInStock_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxProductType_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxClintName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSupplyNum_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxQnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDaimetr_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
