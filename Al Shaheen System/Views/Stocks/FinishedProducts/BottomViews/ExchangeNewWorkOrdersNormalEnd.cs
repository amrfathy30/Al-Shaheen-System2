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
    public partial class ExchangeNewWorkOrdersNormalEnd : Form
    {
        List<SH_SPECIFICATION_OF_BOTTOM> specList = new List<SH_SPECIFICATION_OF_BOTTOM>();
        CLIENT_ORDER_WORK clientOrder = new CLIENT_ORDER_WORK();
        public ExchangeNewWorkOrdersNormalEnd(CLIENT_ORDER_WORK anyOrder)
        {
            InitializeComponent();
            clientOrder = anyOrder;
        }
        long loadpcification()
        {
            specList.Clear();

            try
            {

                string query = "SELECT* FROM SH_SPECIFICATION_OF_BOTTOM WHERE SH_RAW_MATERIAL_TYPE = @type AND SH_SIZE_NAME =@size AND SH_FIRST_FACE_NAME =@firstFace AND SH_SECOND_FACE_NAME = @secondFace ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@type", textBoxMaterial.Text);
                cmd.Parameters.AddWithValue("@size", textBoxDaimetr.Text);
                cmd.Parameters.AddWithValue("@firstFace", textBoxInsideMuran.Text);
                cmd.Parameters.AddWithValue("@secondFace", textBoxOutSideMuran.Text);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specList.Add(new SH_SPECIFICATION_OF_BOTTOM() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(), SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString(), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),  SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString() });
                    long id_spec = long.Parse(reader["SH_ID"].ToString());
                    textBoxQntyInStock.Clear();
                    textBoxQntyInStock.Text = reader["SH_TOTAL_NO_ITEMS"].ToString();
                    return id_spec;
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING Buttom specification FROM DB " + ex.ToString());
            }
            return 0;
        }
        void fillPeelOffSpecifgridview()
        {
            dataGridViewEOEQnty.Rows.Clear();

            loadpcification();
            if (specList.Count > 0)
            {
                for (int i = 0; i < specList.Count; i++)
                {
                    dataGridViewEOEQnty.Rows.Add(new string[] { specList[i].SH_SIZE_NAME, specList[i].SH_RAW_MATERIAL_TYPE, specList[i].SH_FIRST_FACE_NAME, specList[i].SH_SECOND_FACE_NAME });

                }
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
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

                MessageBox.Show("تم ارسال طلب الصرف الى المخازن");
            }
            else
            {
                MessageBox.Show("الكمية لا تكفى الرجاء عمل طلب شراء");
            }
        }
        void addNewExchangeRequest()
        {
            try
            {



                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("addNewExchangeRequestNormalEndOrEasyOpen", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", textBoxClintName.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clientOrder.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_ORDER_SUPPLY_WORK", textBoxSupplyNum.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", textBoxProductName.Text);
                cmd.Parameters.AddWithValue("@SH_PRODUCT_TYPE", textBoxProductType.Text);

                cmd.Parameters.AddWithValue("@SH_NORMAL_END_DAIMETR", long.Parse(textBoxDaimetr.Text));
                cmd.Parameters.AddWithValue("@SH_NORMAL_END_MATERIAL", textBoxMaterial.Text);
                cmd.Parameters.AddWithValue("@SH_NORMAL_END_INSIDE_MURAN", textBoxInsideMuran.Text);
                cmd.Parameters.AddWithValue("@SH_NORMAL_END_OUTSIDE_MURAN", textBoxOutSideMuran.Text);
                cmd.Parameters.AddWithValue("@SH_NORMAL_END_OPENWAY", "");


                cmd.Parameters.AddWithValue("@SH_QUANTITIY_REQUIRED", clientOrder.SH_QUANTITY);
                cmd.Parameters.AddWithValue("@SH_TOTAL_QUANTITY_IN_STOCKS", long.Parse(textBoxQntyInStock.Text));
                cmd.Parameters.AddWithValue("@SH_DATA_ENTERED_BY", "amr abbas");
                cmd.Parameters.AddWithValue("@SH_REGISTERED_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM", clientOrder.SH_CLIENT_SUPPLY_ORDER_NUM);
                long id = loadpcification();
                cmd.Parameters.AddWithValue("@SH_PRODUCT_ID_SPECIFICATION", id);

                cmd.ExecuteNonQuery();

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
        private void ExchangeNewWorkOrdersNormalEnd_Load(object sender, EventArgs e)
        {

            textBoxClintName.Text = clientOrder.SH_CLIENT_NAME;
            textBoxProductName.Text = clientOrder.SH_ITEM_NAME;
            textBoxSupplyNum.Text = clientOrder.SH_ID_STRING;
            textBoxQnt.Text = clientOrder.SH_QUANTITY.ToString();
            textBoxProductType.Text = clientOrder.SH_ITEM_TYPE;
            textBoxDaimetr.Text = clientOrder.SH_EASY_OPEN_DAIAMETR.ToString();
            textBoxInsideMuran.Text = clientOrder.SH_INSIDE_MURAN;
            textBoxOutSideMuran.Text = clientOrder.SH_OUTSIDE_MURAN;
          
            textBoxMaterial.Text = clientOrder.SH_EASY_OPEN_MATERIAL;
            fillPeelOffSpecifgridview();
        }
    }
}
