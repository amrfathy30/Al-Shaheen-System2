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
    public partial class ExchangeNewWorkOrderPlasticCover : Form
    {
        List<SH_SPECIFICATION_OF_PLASTIC_COVER> SpecPlasticCoverList = new List<SH_SPECIFICATION_OF_PLASTIC_COVER>();
        CLIENT_ORDER_WORK clientOrder = new CLIENT_ORDER_WORK();
        public ExchangeNewWorkOrderPlasticCover(CLIENT_ORDER_WORK anyClient)
        {
            InitializeComponent();
            clientOrder = anyClient;
        }
        long loadPlasticCoverspcification()
        {



            SpecPlasticCoverList.Clear();

            try
            {


                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand("getPlasticCoverSpecificastion", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@colorName", textBoxCoverClor.Text);
                cmd.Parameters.AddWithValue("@sizeName", textBoxDaimetr.Text);
                cmd.Parameters.AddWithValue("@logo", long.Parse(textBoxAklasheh.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    long id_spec = long.Parse(reader["SH_ID"].ToString());
                    SpecPlasticCoverList.Add(new SH_SPECIFICATION_OF_PLASTIC_COVER() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_LOGO_OR_NOT =long.Parse( reader["SH_LOGO_OR_NOT"].ToString()), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()), SH_SIZE_ID=long.Parse(reader["SH_SIZE_ID"].ToString()),SH_NO_OF_CONTAINERS=long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),SH_PILLOW_COLOR_ID=long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()) });


                    textBoxTotalQntyInStock.Clear();
                    textBoxTotalQntyInStock.Text = reader["SH_TOTAL_NO_ITEMS"].ToString();

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
        private void ExchangeNewWorkOrderPlasticCover_Load(object sender, EventArgs e)
        {
            textBoxClintName.Text = clientOrder.SH_CLIENT_NAME;
            textBoxProductName.Text = clientOrder.SH_ITEM_NAME;
            textBoxSupplyNum.Text = clientOrder.SH_ID_STRING;
            textBoxQnt.Text = clientOrder.SH_QUANTITY.ToString();
            textBoxProductType.Text = clientOrder.SH_ITEM_TYPE;
            textBoxAklasheh.Text = clientOrder.SH_PLASTIC_COVER_HAS_AKLASHEH.ToString();
            textBoxCoverClor.Text = clientOrder.SH_PLASTIC_COVER_COLOR_ONLY;
            textBoxDaimetr.Text = clientOrder.SH_PLASTIC_COVER_COVER_DAIMETR_ONLY.ToString();
            loadPlasticCoverspcification();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

       void addNewExchangeRequest()
        {

            try
            {


                loadPlasticCoverspcification();
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("addNewExchangeRequesPlasticCover", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
               
                

               
                 cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", textBoxClintName.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clientOrder.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_ORDER_SUPPLY_WORK", textBoxSupplyNum.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", textBoxProductName.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_TYPE", textBoxProductType.Text);
               
                cmd.Parameters.AddWithValue("@SH_QUANTITIY_REQUIRED",clientOrder.SH_QUANTITY);

                
                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY_IN_STOCKS", long.Parse(textBoxTotalQntyInStock.Text));
                cmd.Parameters.AddWithValue("@SH_DATA_ENTERED_BY", "amr abbas");
                cmd.Parameters.AddWithValue("@SH_REGISTERED_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM",clientOrder.SH_CLIENT_SUPPLY_ORDER_NUM );
             
                long id = loadPlasticCoverspcification();
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID_SPECIFICATION", id);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COLOR", textBoxCoverClor.Text);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_DAIMETR", long.Parse(textBoxDaimetr.Text));
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_HAS_AKLASHEH", long.Parse(textBoxAklasheh.Text));


                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ارسال الطلب الى المخازن");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRor" + ex.ToString());
            }
        }
       void  changeStatusClientOrders()
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
        private void buttonExchangeRequest_Click(object sender, EventArgs e)
        {

            long x = (long.Parse(textBoxTotalQntyInStock.Text) - long.Parse(textBoxQnt.Text));
            if (x >= 0)
            {
                textBoxRemainingQnty.Clear();
                textBoxRemainingQnty.Text = x.ToString();
                addNewExchangeRequest();
                changeStatusClientOrders();
                buttonExchangeRequest.Enabled = false;

            }
            else
            {
                MessageBox.Show("الكمية لا تكفى الرجاء عمل طلب شراء");
                buttonBuyRequest.Visible = true;
            }
        }
    }
}
