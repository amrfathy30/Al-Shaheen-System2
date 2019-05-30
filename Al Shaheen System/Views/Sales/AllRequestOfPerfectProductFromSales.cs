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
    public partial class AllRequestOfPerfectProductFromSales : Form
    {
        SH_EMPLOYEES emp = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS acc = new SH_USER_ACCOUNTS();
        List<SH_EXCHANGE_REQUEST_FROM_SALES> requestList = new List<SH_EXCHANGE_REQUEST_FROM_SALES>();
        public AllRequestOfPerfectProductFromSales(SH_USER_ACCOUNTS anyaccount, SH_EMPLOYEES anyEmp)
        {
            InitializeComponent();
            acc = anyaccount;
            emp = anyEmp;
        }

        void loadAllClientOrdersFromSales()
        {
            requestList.Clear();

            try
            {
                string query = "select * from SH_EXCHANGE_REQUEST_FROM_SALES where SH_STATUS=0 order by SH_CLIENT_NAME";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new SH_EXCHANGE_REQUEST_FROM_SALES() { SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_CLIENT_SUPPLY_ORDER_NUM = reader["SH_CLIENT_SUPPLY_ORDER_NUM"].ToString(), SH_DATA_ENTERED_BY = reader["SH_DATA_ENTERED_BY"].ToString(), SH_ORDER_SUPPLY_WORK = reader["SH_ORDER_SUPPLY_WORK"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_QUANTITIY_REQUIRED = long.Parse(reader["SH_QUANTITIY_REQUIRED"].ToString()), SH_REGISTERED_DATE = DateTime.Parse(reader["SH_REGISTERED_DATE"].ToString()), SH_TOTAL_QUANTITY_IN_STOCKS = long.Parse(reader["SH_TOTAL_QUANTITY_IN_STOCKS"].ToString()), SH_STATUS = long.Parse(reader["SH_STATUS"].ToString()), SH_PRODUCT_TYPE = reader["SH_PRODUCT_TYPE"].ToString(), SH_PRODUCT_ID_SPECIFICATION = long.Parse(reader["SH_PRODUCT_ID_SPECIFICATION"].ToString()), SH_RLT_DAIMETR = long.Parse(reader["SH_RLT_DAIMETR"].ToString()), SH_NORMAL_END_DAIMETR = long.Parse(reader["SH_NORMAL_END_DAIMETR"].ToString()), SH_NORMAL_END_INSIDE_MURAN = reader["SH_NORMAL_END_INSIDE_MURAN"].ToString(), SH_NORMAL_END_MATERIAL = reader["SH_NORMAL_END_MATERIAL"].ToString(), SH_NORMAL_END_OPENWAY = reader["SH_NORMAL_END_OPENWAY"].ToString(), SH_NORMAL_END_OUTSIDE_MURAN = reader["SH_NORMAL_END_OUTSIDE_MURAN"].ToString(), SH_TWIST_COLOR = reader["SH_TWIST_COLOR"].ToString(), SH_TWIST_SIZE = long.Parse(reader["SH_TWIST_SIZE"].ToString()), SH_TWIST_TYPE = reader["SH_TWIST_TYPE"].ToString(), SH_PLASTIC_COVER_COLOR = reader["SH_PLASTIC_COVER_COLOR"].ToString(),SH_PLASTIC_COVER_DAIMETR=long.Parse(reader["SH_PLASTIC_COVER_DAIMETR"].ToString()),SH_PLASTIC_COVER_HAS_AKLASHEH=long.Parse(reader["SH_PLASTIC_COVER_HAS_AKLASHEH"].ToString()),SH_PLASTIC_MOLD_DAIMETR=long.Parse(reader["SH_PLASTIC_MOLD_DAIMETR"].ToString()),SH_PLASTIC_MOLD_IMPORTEDOR_LOCAL=reader["SH_PLASTIC_MOLD_IMPORTEDOR_LOCAL"].ToString(),SH_PLASTIC_MOLD_TYPE=reader["SH_PLASTIC_MOLD_TYPE"].ToString() });
                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR   WHILE GETTING CLIENT orders FROM DB " + ex.ToString());
            }

        }
        void fillclientcontactsgridview()
        {
            dataGridViewAllRequests.Rows.Clear();
            requestList.Clear();
            loadAllClientOrdersFromSales();
            if (requestList.Count > 0)
            {
                for (int i = 0; i < requestList.Count; i++)
                {
                    dataGridViewAllRequests.Rows.Add(new string[] { (i + 1).ToString(),requestList[i].SH_CLIENT_NAME, requestList[i].SH_PRODUCT_TYPE , requestList[i].SH_PRODUCT_NAME });
                }
            }
        }

        private void AllRequestOfPerfectProductFromSales_Load(object sender, EventArgs e)
        {
            fillclientcontactsgridview();
        }

        private void dataGridViewAllRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = e.RowIndex;
           using (ProductDetailsForExchangeFrm myform = new ProductDetailsForExchangeFrm(requestList[row_index], acc,emp))

            {
                myform.ShowDialog();
            }
        }

        private void AllRequestOfPerfectProductFromSales_Activated(object sender, EventArgs e)
        {
            fillclientcontactsgridview();
        }

     
    }
}
