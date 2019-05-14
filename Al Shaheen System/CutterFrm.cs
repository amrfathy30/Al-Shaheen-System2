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
    public partial class CutterFrm : Form
    {
        List<SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL> QntExchPrntMaterialLst = new List<SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL>();
        List<SH_SHAHEEN_CUTTERS> cutters = new List<SH_SHAHEEN_CUTTERS>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        public CutterFrm()
        {
            InitializeComponent();
        }
        void loadcuuttersdata()
        {
            cutters.Clear();
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_CUTTERS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cutters.Add(new SH_SHAHEEN_CUTTERS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CUTTER_NAME = reader["SH_CUTTER_NAME"].ToString(), SH_CUTTER_LOCATION_TEXT = reader["SH_CUTTER_LOCATION_TEXT"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW CUTTER" + ex.ToString());
            }
        }
        void fillcutterscombobox()
        {
            cutters_combo_box.Items.Clear();
            loadcuuttersdata();
            if (cutters.Count > 0)
            {
                for (int i = 0; i < cutters.Count; i++)
                {
                    cutters_combo_box.Items.Add(cutters[i].SH_CUTTER_NAME);
                }
            }
        }
        void loadallClients()
        {
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING clients DATA FROM DB " + ex.ToString());
            }
        }

        async Task fillClientscombobox()
        {
            clients.Clear();
            loadallClients();
            clients_combo_box.Items.Clear();
            if (clients.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }
        void loadDataGrid()
        {

            try
            {
                string query = "select * from SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL where SH_CUTTER_ID=@id";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", cutters[cutters_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    QntExchPrntMaterialLst.Add(new SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CUTTER_NAME = reader["SH_CUTTER_NAME"].ToString(), SH_CONFIDENTIAL_MAN_ID = long.Parse(reader["SH_CONFIDENTIAL_MAN_ID"].ToString()), SH_EXCHANGE_PERMISSION_NUMBER = reader["SH_EXCHANGE_PERMISSION_NUMBER"].ToString(), SH_CONFIDENTIAL_MAN_NAME = reader["SH_CONFIDENTIAL_MAN_NAME"].ToString(), SH_CUTTER_ID = long.Parse(reader["SH_CUTTER_ID"].ToString()), SH_CUTTER_MAN_NAME = reader["SH_CUTTER_MAN_NAME"].ToString(), SH_DEPARTMENET_ID = long.Parse(reader["SH_DEPARTMENET_ID"].ToString()), SH_DEPARTMENT_NAME = reader["SH_DEPARTMENT_NAME"].ToString(), SH_NUMBER_OF_PARCELS = long.Parse(reader["SH_NUMBER_OF_PARCELS"].ToString()), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(), SH_NUMBER_OF_SHEETS = long.Parse(reader["SH_NUMBER_OF_SHEETS"].ToString()), SH_RECEIVED_MAN_ID = long.Parse(reader["SH_RECEIVED_MAN_ID"].ToString()), SH_RECEIVED_MAN_NAME = reader["SH_RECEIVED_MAN_NAME"].ToString(), SH_STOCK_ID = long.Parse(reader["SH_STOCK_ID"].ToString()), SH_STOCK_MAN_ID = long.Parse(reader["SH_STOCK_MAN_ID"].ToString()), SH_STOCK_MAN_NAME = reader["SH_STOCK_MAN_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL  DATA FROM DB " + ex.ToString());
            }

        }

        void filltGridView()
        {
            dataGridView1.Rows.Clear();
            loadDataGrid();
            if (QntExchPrntMaterialLst.Count > 0)
            {
                for (int i = 0; i < QntExchPrntMaterialLst.Count; i++)
                {
                    dataGridView1.Rows.Add(new string[] { (i + 1).ToString(),  });

                }
            }
        }



        private void CutterFrm_Load(object sender, EventArgs e)
        {
            fillClientscombobox();
            fillcutterscombobox();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
