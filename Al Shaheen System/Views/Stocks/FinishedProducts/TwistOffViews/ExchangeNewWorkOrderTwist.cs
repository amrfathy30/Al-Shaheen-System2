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
    public partial class ExchangeNewWorkOrderTwist : Form
    {
        List<SH_SPECIFICATION_OF_TWIST_OF> SpecTwistList = new List<SH_SPECIFICATION_OF_TWIST_OF>();
        List<SH_SPECIFICATION_OF_TWIST_OF> TwistSpecificList = new List<SH_SPECIFICATION_OF_TWIST_OF>();
        CLIENT_ORDER_WORK clientOrder = new CLIENT_ORDER_WORK();
        public ExchangeNewWorkOrderTwist(CLIENT_ORDER_WORK anyClientOrder)
        {
            InitializeComponent();
            clientOrder= anyClientOrder  ;
        }

        long loadTwistspcification()
        {
         


            SpecTwistList.Clear();

            try
            {

              
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand("selectTwistProp", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@SH_TYPE", textBoxType.Text);
             cmd.Parameters.AddWithValue("@SH_FACE_COLOR_NAME", textBoxTwistColor.Text);
              cmd.Parameters.AddWithValue("@SH_TWIST_OF_SIZE_VALUE", long.Parse( textBoxTwistSize.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    long id_spec = long.Parse(reader["SH_ID"].ToString());
                    TwistSpecificList.Add(new SH_SPECIFICATION_OF_TWIST_OF() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_TYPE = reader["SH_TYPE"].ToString(), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_FACE_COLOR_ID = long.Parse(reader["SH_FACE_COLOR_ID"].ToString()), SH_FIRST_FACE_PILLOW_OR_NOT = long.Parse(reader["SH_FIRST_FACE_PILLOW_OR_NOT"].ToString()), SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()), SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()), SH_SIZE_ID =long.Parse( reader["SH_SIZE_ID"].ToString()), SH_TOTAL_NO_TEMS = long.Parse(reader["SH_TOTAL_NO_TEMS"].ToString()), SH_TWIST_OF_TYPE_ID = long.Parse(reader["SH_TWIST_OF_TYPE_ID"].ToString()) });
                  
                 
                    textBoxQntyInStock.Clear();
                    textBoxQntyInStock.Text = reader["SH_TOTAL_NO_TEMS"].ToString();

                    return id_spec;
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING Twist specification FROM DB " + ex.ToString());
            }
            return 0;
        }
        void fillTwistSpecifgridview()
        {
            dataGridViewTwistQnty.Rows.Clear();

            loadTwistspcification();
            if (TwistSpecificList.Count > 0)
            {
                for (int i = 0; i < TwistSpecificList.Count; i++)
                {

                  



                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ExchangeNewWorkOrderTwist_Load(object sender, EventArgs e)
        {

            textBoxClintName.Text = clientOrder.SH_CLIENT_NAME;
            textBoxProductName.Text = clientOrder.SH_ITEM_NAME;
            textBoxSupplyNum.Text = clientOrder.SH_ID_STRING;
            textBoxQnt.Text = clientOrder.SH_QUANTITY.ToString();
            textBoxProductType.Text = clientOrder.SH_ITEM_TYPE;
            textBoxTwistColor.Text = clientOrder.SH_TWIST_COLOR;
            textBoxTwistSize.Text = clientOrder.SH_TWIST_SIZE.ToString();
            textBoxType.Text = clientOrder.SH_TWIST_TYPE;
          loadTwistspcification();
        }
      
        void addNewExchangeRequest()
        {
            try
            {


                loadTwistspcification();
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("addNewExchangeRequesTwIST", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", textBoxClintName.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clientOrder.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_ORDER_SUPPLY_WORK", textBoxSupplyNum.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", textBoxProductName.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_TYPE", textBoxProductType.Text);
                cmd.Parameters.AddWithValue("@SH_TWIST_SIZE", long.Parse(textBoxTwistSize.Text));
                cmd.Parameters.AddWithValue("@SH_TWIST_COLOR", textBoxTwistColor.Text);
                cmd.Parameters.AddWithValue("@SH_TWIST_TYPE", textBoxType.Text);

                cmd.Parameters.AddWithValue("@SH_QUANTITIY_REQUIRED", clientOrder.SH_QUANTITY);
                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY_IN_STOCKS", long.Parse(textBoxQntyInStock.Text));
                cmd.Parameters.AddWithValue("@SH_DATA_ENTERED_BY", "amr abbas");
                cmd.Parameters.AddWithValue("@SH_REGISTERED_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM", clientOrder.SH_CLIENT_SUPPLY_ORDER_NUM);
                long id = loadTwistspcification();
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID_SPECIFICATION", id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ارسال الطلب الى المخازن");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRor" + ex.ToString());
            }
        }
      void   changeStatusClientOrders()
        {
            try
            {


                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("update CLIENT_ORDER_WORK set SH_STATUS=1 where SH_ID=@id ", DatabaseConnection.mConnection);

                cmd.Parameters.AddWithValue("@id", clientOrder.SH_ID);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());



            }
        }
        private void buttonExchange_Click(object sender, EventArgs e)
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
            }

        }
    }
}
