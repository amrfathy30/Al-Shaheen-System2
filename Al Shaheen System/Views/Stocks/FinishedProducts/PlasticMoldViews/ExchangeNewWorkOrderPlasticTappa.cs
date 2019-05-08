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
    public partial class ExchangeNewWorkOrderPlasticTappa : Form
    {
        List<SH_SPECIFICATION_OF_PLASTIC_MOLD> SpecList = new List<SH_SPECIFICATION_OF_PLASTIC_MOLD>();
        CLIENT_ORDER_WORK clientOrder = new CLIENT_ORDER_WORK();
        public ExchangeNewWorkOrderPlasticTappa(CLIENT_ORDER_WORK anyClientOrder)
        {
            InitializeComponent();
            clientOrder = anyClientOrder;
        }
        long loadPlasticTappaspcification()
        {



          SpecList.Clear();

            try
            {
                

               DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand("getPlasticMoldSpecification", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_MOLD_TYPE_NAME", textBoxType.Text);
                cmd.Parameters.AddWithValue("@SH_MOLD_SIZE_VALUE",double.Parse( textBoxClintName.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    long id_spec = long.Parse(reader["SH_ID"].ToString());
                


                    textBoxQuntityInStock.Clear();
                    textBoxQuntityInStock.Text = reader["SH_TOTAL_NO_ITEMS"].ToString();

                    return id_spec;
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING Plastic Mold specification FROM DB " + ex.ToString());
            }
            return 0;
        }
        void addNewExchangeRequest()
        {

            try
            {


                loadPlasticTappaspcification();
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("addNewExchangeRequesTappa", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;




                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", textBoxClintName.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clientOrder.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_ORDER_SUPPLY_WORK", textBoxSupplyNum.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", textBoxProductName.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_TYPE", textBoxProductType.Text);

                cmd.Parameters.AddWithValue("@SH_QUANTITIY_REQUIRED", clientOrder.SH_QUANTITY);


                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY_IN_STOCKS", long.Parse(textBoxQuntityInStock.Text));
                cmd.Parameters.AddWithValue("@SH_DATA_ENTERED_BY", "amr abbas");
                cmd.Parameters.AddWithValue("@SH_REGISTERED_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM", clientOrder.SH_CLIENT_SUPPLY_ORDER_NUM);

             long id = loadPlasticTappaspcification();
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID_SPECIFICATION", id);
                cmd.Parameters.AddWithValue("@SH_TAPPA_TYPE", textBoxType.Text);
                cmd.Parameters.AddWithValue("@SH_TAPPA_IMPORTED_OR_LOCAL", textBoxImported_Exported.Text);
                cmd.Parameters.AddWithValue("@SH_TAPPA_DAIMETR", long.Parse(textBoxDaimetr.Text));


                cmd.ExecuteNonQuery();
                MessageBox.Show("تم ارسال الطلب الى المخازن");
            }
            catch (Exception ex)
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

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.ToString());



            }
        }
        private void ExchangeNewWorkOrderPlasticTappa_Load(object sender, EventArgs e)
        {
            textBoxClintName.Text = clientOrder.SH_CLIENT_NAME;
            textBoxProductName.Text = clientOrder.SH_ITEM_NAME;
            textBoxSupplyNum.Text = clientOrder.SH_ID_STRING;
            textBoxQnt.Text = clientOrder.SH_QUANTITY.ToString();
            textBoxProductType.Text = clientOrder.SH_ITEM_TYPE;
            textBoxDaimetr.Text = clientOrder.SH_PLASTIC_TABA_DAIMETR.ToString();
            textBoxType.Text =clientOrder.SH_PLASTIC_TABA_TYPE;
            textBoxImported_Exported.Text = clientOrder.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED;
            loadPlasticTappaspcification();
        }

        private void buttonExchange_Click(object sender, EventArgs e)
        {

            long x = (long.Parse(textBoxQuntityInStock.Text) - long.Parse(textBoxQnt.Text));
            if (x >= 0)
            {
                textBoxRemainingQnty.Clear();
                textBoxRemainingQnty.Text = x.ToString();
                addNewExchangeRequest();
                changeStatusClientOrders();
                buttonExchange.Enabled = false;

            }
            else
            {
                MessageBox.Show("الكمية لا تكفى الرجاء عمل طلب شراء");
                buttonBuyRequest.Visible = true;
            }
        }

        private void buttonBuyRequest_Click(object sender, EventArgs e)
        {

        }
    }
}
