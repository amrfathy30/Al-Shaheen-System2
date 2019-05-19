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
        List<SH_PRODUCT_OF_CLIENTS_PARCELS> client_products = new List<SH_PRODUCT_OF_CLIENTS_PARCELS>();
        List<SH_PRINTED_MATERIAL_PARCEL> parcels = new List<SH_PRINTED_MATERIAL_PARCEL>();
        List<SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL> QntExchPrntMaterialLst = new List<SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL>();
        List<SH_SHAHEEN_CUTTERS> cutters = new List<SH_SHAHEEN_CUTTERS>();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        long total_number_of_bottel_per_sheet = 0;
        public CutterFrm()
        {
            InitializeComponent();
        }


        void getallclientandproductparcels()
        {
            try
            {
                //  WHERE SH_ID IN(SELECT SH_PRINTED_MATERIAL_PARCEL_ID FROM SH_PRODUCT_OF_CLIENTS_PARCELS WHERE(SH_CLIENT_ID = @SH_CLIENT_ID AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID) AND(SH_PRINTED_MATERIAL_PARCEL_ID  NOT IN(SELECT SH_PRINTED_MATERIAL_PARCEL_ID  FROM SH_EXCHANGED_PRINTED_MATERIAL_PARCELS))
              
                   string query = "SELECT * FROM SH_PRINTED_MATERIAL_PARCEL";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parcels.Add(new SH_PRINTED_MATERIAL_PARCEL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()), SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString(), SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString(), SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString(), SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_SHEET_WEIGHT = double.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()), SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString(), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), SH_ITEM_TOTAL_GROSS_WEIGHT = double.Parse(reader["SH_ITEM_GROSS_WEIGHT"].ToString()), SH_ITEM_TOTAL_NET_WEIGHT = double.Parse(reader["SH_ITEM_NET_WEIGHT"].ToString()), SH_ITEM_TOTAL_NO_SHEETS = long.Parse(reader["SH_ITEM_NO_SHEETS"].ToString()), SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString(), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()), SH_PARCEL_NET_WEIGHT = double.Parse(reader["SH_ITEM_NET_WEIGHT"].ToString()), SH_PARCEL_NO_SHEETS = long.Parse(reader["SH_ITEM_NO_SHEETS"].ToString()), SH_PRINTER_ID = long.Parse(reader["SH_PRINTER_ID"].ToString()), SH_PRINTER_NAME = reader["SH_PRINTER_NAME"].ToString(), SH_PRINTING_PERMISSION_NUMBER = reader["SH_PRINTING_PERMISSION_NUMBER"].ToString(), SH_QUANTITIES_OF_PRINTED_MATERIAL_ID = long.Parse(reader["SH_QUANTITIES_OF_PRINTED_MATERIAL_ID"].ToString()), SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID = reader["SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID"].ToString(), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(), SH_TOTAL_NUMBER_OF_BOTTELS = long.Parse(reader["SH_TOTAL_NUMBER_OF_BOTTELS"].ToString()), SH_WORK_ORDER_NUMBER = reader["SH_WORK_ORDER_NUMBER"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTED PARCELS  " + ex.ToString());
            }
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


        void fillclientproductsgridview()
        {
            client_product_grid_view.Rows.Clear();
            if (client_products.Count > 0)
            {
                for (int i = 0; i < client_products.Count; i++)
                {
                    client_product_grid_view.Rows.Add(new string[] { (i + 1).ToString(), client_products[i].SH_CLIENT_NAME, client_products[i].SH_CLIENT_PRODUCT_NAME, client_products[i].SH_NO_BOTTLES_PER_SHEET.ToString() });
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
        void gettingproductsbyclientid()
        {
            products.Clear();
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {

            }
            else
            {
                try
                {
                    string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS WHERE(SH_CLIENT_ID = @CLIENT_ID)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        //getting products data
                        products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });


                    }

                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS");
                }
            }
        }

        void fillproductscombobox()
        {
            client_products_combo_box.Items.Clear();
            gettingproductsbyclientid();
            for (int i = 0; i < products.Count; i++)
            {
                client_products_combo_box.Items.Add(products[i].SH_PRODUCT_NAME);
            }

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        bool check_if_client_product_is_exists_or_not()
        {
            if (client_products.Count > 0)
            {
                for (int i = 0; i < client_products.Count; i++)
                {
                    //  MessageBox.Show(i.ToString());
                    if ((string.Compare(client_products[i].SH_CLIENT_PRODUCT_NAME, client_products_combo_box.Text) == 0) && (string.Compare(client_products[i].SH_CLIENT_NAME, clients_combo_box.Text) == 0) && (client_products[i].SH_NO_BOTTLES_PER_SHEET == long.Parse(no_bottels_per_sheet.Text)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(clients_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrEmpty(client_products_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrEmpty(no_bottels_per_sheet.Text))
            {
                MessageBox.Show("الرجاء إدخال قيمة عدد العلب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                if (check_if_client_product_is_exists_or_not())
                {
                    MessageBox.Show("هذا الصنف موجود من قبل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    client_products.Add(new SH_PRODUCT_OF_CLIENTS_PARCELS() { SH_CLIENT_ID = clients[clients_combo_box.SelectedIndex].SH_ID, SH_CLIENT_NAME = clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME, SH_NO_BOTTLES_PER_SHEET = long.Parse(no_bottels_per_sheet.Text), SH_CLIENT_PRODUCT_ID = products[client_products_combo_box.SelectedIndex].SH_ID, SH_CLIENT_PRODUCT_NAME = products[client_products_combo_box.SelectedIndex].SH_PRODUCT_NAME });
                    total_number_of_bottel_per_sheet += long.Parse(no_bottels_per_sheet.Text);
                    total_number_of_bottels_per_sheet.Text = total_number_of_bottel_per_sheet.ToString();
                    fillclientproductsgridview();
                }
            }
        }

        private void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillproductscombobox();
        }

        private void radioButtonCan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCan.Checked)
            {
                panelCan.Visible = true;
            }
            else
            {
                panelCan.Visible = false;
            }
        }

        private void radioButtonSlice_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSlice.Checked)
            {
                panelSlice.Visible = true;
            }else
            {
                panelSlice.Visible = false;

            }
        }
    }
}
