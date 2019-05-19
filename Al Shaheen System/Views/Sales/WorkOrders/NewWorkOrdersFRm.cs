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
    public partial class NewWorkOrdersFRm : Form
    {
        List<CLIENT_ORDER_WORK> Orders = new List<CLIENT_ORDER_WORK>();
        SH_USER_ACCOUNTS acc = new SH_USER_ACCOUNTS();
        public NewWorkOrdersFRm()
        {
            InitializeComponent();
           
        }

        private void dataGridViewAllNewWorkOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "RLT")
            {

                     //rlt form

                int row_index = e.RowIndex;
               
                using (ExchangeNewWorkOrders myform = new ExchangeNewWorkOrders(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }

           else if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "بييل اوف")
            {

                //peelOff form

                int row_index = e.RowIndex;

                using (ExchangeNewWorkOrdersPeelOff myform = new ExchangeNewWorkOrdersPeelOff(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }

           else if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "ايزي اوبن")
            {

                //EOE form

                int row_index = e.RowIndex;

                using (ExchangeNewWorkOrdersEOE myform = new ExchangeNewWorkOrdersEOE(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }


            else if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "Normal end")
            {

                //Normal end form

                int row_index = e.RowIndex;

                using (ExchangeNewWorkOrdersNormalEnd myform = new ExchangeNewWorkOrdersNormalEnd(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }


            else if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "تويست")
            {

                //Twist form

                int row_index = e.RowIndex;

                using (ExchangeNewWorkOrderTwist myform = new ExchangeNewWorkOrderTwist(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }


     
            else if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "غطاء بلاستيك")
            {

                //Plastic Cover form

                int row_index = e.RowIndex;

                using (ExchangeNewWorkOrderPlasticCover myform = new ExchangeNewWorkOrderPlasticCover(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }
            else if (Orders[dataGridViewAllNewWorkOrders.CurrentRow.Index].SH_ITEM_TYPE == "طبة")
            {

                //Taba form

                int row_index = e.RowIndex;

                using (ExchangeNewWorkOrderPlasticTappa myform = new ExchangeNewWorkOrderPlasticTappa(Orders[row_index]))

                {
                    myform.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Sorry");
            }

        }

     

      void loadAllClientOrders()
        {
            Orders.Clear();

            try
            {
                string query = "select * from CLIENT_ORDER_WORK  where SH_STATUS= 0 order by SH_CLIENT_NAME";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Orders.Add(new CLIENT_ORDER_WORK() { SH_ID_STRING = reader["SH_ID_STRING"].ToString(), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_ITEM_NAME = reader["SH_ITEM_NAME"].ToString(), SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString(), SH_QUANTITY = double.Parse(reader["SH_QUANTITY"].ToString()), SH_CAN_COVER_TYPE = reader["SH_CAN_COVER_TYPE"].ToString(), SH_TABA_TYPE = reader["SH_TABA_TYPE"].ToString(), SH_PLASTIC_COVER_COLOR_CAN = reader["SH_PLASTIC_COVER_COLOR_CAN"].ToString(), SH_START_SUPPLY_DATE = DateTime.Parse(reader["SH_START_SUPPLY_DATE"].ToString()), SH_RLT_DAIAMETR = long.Parse(reader["SH_RLT_DAIAMETR"].ToString()), SH_PEELOFF_DAIMETR = long.Parse(reader["SH_PEELOFF_DAIMETR"].ToString()), SH_EASY_OPEN_DAIAMETR = long.Parse(reader["SH_EASY_OPEN_DAIAMETR"].ToString()), SH_EASY_OPEN_MATERIAL = reader["SH_EASY_OPEN_MATERIAL"].ToString(), SH_INSIDE_MURAN = reader["SH_INSIDE_MURAN"].ToString(), SH_OUTSIDE_MURAN = reader["SH_OUTSIDE_MURAN"].ToString(), SH_OPEN_WAY = reader["SH_OPEN_WAY"].ToString(), SH_TWIST_COLOR = reader["SH_TWIST_COLOR"].ToString(), SH_TWIST_SIZE = long.Parse(reader["SH_TWIST_SIZE"].ToString()), SH_TWIST_TYPE = reader["SH_TWIST_TYPE"].ToString(), SH_PLASTIC_COVER_COVER_DAIMETR_ONLY = long.Parse(reader["SH_PLASTIC_COVER_COVER_DAIMETR_ONLY"].ToString()), SH_PLASTIC_COVER_COLOR_ONLY = reader["SH_PLASTIC_COVER_COLOR_ONLY"].ToString(), SH_PLASTIC_COVER_HAS_AKLASHEH=long.Parse(reader["SH_PLASTIC_COVER_HAS_AKLASHEH"].ToString()), SH_PLASTIC_TABA_DAIMETR = long.Parse(reader["SH_PLASTIC_TABA_DAIMETR"].ToString()),SH_PLASTIC_TABA_TYPE=reader["SH_PLASTIC_TABA_TYPE"].ToString(),SH_PLASTIC_TABA_LOCAL_OR_IMPORTED=reader["SH_PLASTIC_TABA_LOCAL_OR_IMPORTED"].ToString(), SH_CLIENT_SUPPLY_ORDER_NUM=reader["SH_CLIENT_SUPPLY_ORDER_NUM"].ToString(),SH_ID=long.Parse(reader["SH_ID"].ToString()),SH_CLIENT_ID=long.Parse(reader["SH_CLIENT_ID"].ToString()),SH_DIAMETR_TAPPA=long.Parse(reader["SH_DIAMETR_TAPPA"].ToString()),SH_DELIVERING_ADDRESS=reader["SH_DELIVERING_ADDRESS"].ToString(),SH_TWIST_DEEP_NORMAL_MEDIUM=reader["SH_TWIST_DEEP_NORMAL_MEDIUM"].ToString(),SH_BOYATE_FACE_TYPE=reader["SH_BOYATE_FACE_TYPE"].ToString(),SH_FACE_DAIMETR=long.Parse( reader["SH_FACE_DAIMETR"].ToString()) });
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR  WHILE GETTING CLIENT orders FROM DB " + ex.ToString());
            }

        }
        void fillclientcontactsgridview()
        {
            dataGridViewAllNewWorkOrders.Rows.Clear();
            Orders.Clear();
            loadAllClientOrders();
            if (Orders.Count > 0)
            {
                for (int i = 0; i < Orders.Count; i++)
                {
                    dataGridViewAllNewWorkOrders.Rows.Add(new string[] {  Orders[i].SH_ID_STRING, Orders[i].SH_CLIENT_NAME, Orders[i].SH_ITEM_NAME, Orders[i].SH_ITEM_TYPE, Orders[i].SH_QUANTITY.ToString(), Orders[i].SH_CAN_COVER_TYPE, Orders[i].SH_TABA_TYPE, Orders[i].SH_CAN_COVER_TYPE, Orders[i].SH_START_SUPPLY_DATE.ToString() });
                }
            }
        }

        private void NewWorkOrdersFRm_Load(object sender, EventArgs e)
        {
            fillclientcontactsgridview();
            label2.Text = Orders.Count.ToString();


        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NewWorkOrdersFRm_Activated(object sender, EventArgs e)
        {
            fillclientcontactsgridview();
            label2.Text = Orders.Count.ToString();
        }

     
    }
}

