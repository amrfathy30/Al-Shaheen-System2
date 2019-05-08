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
    public partial class exchange_of_cut_printed_material : Form
    {
        List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> parcels = new List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        public exchange_of_cut_printed_material(List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> anyparcels)
        {
            InitializeComponent();
            parcels = anyparcels;

        }

        void loadallstocks()
        {
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_STOCKS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK { SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(), SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(), SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING STOCKS DATA FROM DB " + ex.ToString());
            }
        }

        void fillstockscombobox()
        {
            stocks.Clear();
            loadallstocks();
            stock_combo_box.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stock_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }

        void updateparcelsspecification(SH_PALLETS_OF_CUT_PRINTED_MATERIAL parcel)
        {
            if (parcel != null)
            {
                try
                {
                    string query = "UPDATE  SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL ";
                    query += " SET SH_TOTAL_NUMBER_OF_BOTTELS = SH_TOTAL_NUMBER_OF_BOTTELS - @SH_TOTAL_NUMBER_OF_BOTTELS, SH_TOTAL_NUMBER_OF_PALLETS = SH_TOTAL_NUMBER_OF_PALLETS - @SH_TOTAL_NUMBER_OF_PALLETS  WHERE SH_ID = @SH_ID ";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_BOTTELS" , parcel.SH_TOTAL_NUMBER_OF_BOTTELS);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLETS", 1);
                    cmd.Parameters.AddWithValue("@SH_ID" , parcel.SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE UPDATING CUT PRINTED SPECIFICATION DETAILS "+ex.ToString());
                }
            }
        }

        void saveexchangedprintedmaterialpallets()
        {
            if (parcels.Count > 0)
            {
                long q_id = saveexchangedcutprintedquantity();
                for (int i = 0; i < parcels.Count; i++)
                {
                    updateparcelsspecification(parcels[i]);
                    try
                    {
                        string query = "INSERT INTO SH_EXCHANGED_PALLETS_OD_CUT_PRINTED_TIN ";
                        query += "(SH_QUANTITIES_OF_EXCHANGED_CUT_PRINTED_TIN_ID, SH_PALLETS_OF_CUT_PRINTED_MATERIAL_ID, SH_EXCHANGE_DATE, SH_EXCHANGE_PERMISSION_NUMBER, SH_WORK_ORDER_NUMBER)";
                       query += " VALUES(@SH_QUANTITIES_OF_EXCHANGED_CUT_PRINTED_TIN_ID,@SH_PALLETS_OF_CUT_PRINTED_MATERIAL_ID,@SH_EXCHANGE_DATE,@SH_EXCHANGE_PERMISSION_NUMBER,@SH_WORK_ORDER_NUMBER)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_QUANTITIES_OF_EXCHANGED_CUT_PRINTED_TIN_ID" , q_id);
                        cmd.Parameters.AddWithValue("@SH_PALLETS_OF_CUT_PRINTED_MATERIAL_ID" , parcels[i].SH_ID);
                        cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now);
                        cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER" , exchange_permission_number.Text);
                        cmd.Parameters.AddWithValue("@SH_WORK_ORDER_NUMBER" , work_number_text_box.Text);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING EXCHANGED PALLETS "+ex.ToString());
                    }
                }
                MessageBox.Show("تم الحفظ بنجاح" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);

            }
        }

        private void exchange_of_cut_printed_material_Load(object sender, EventArgs e)
        {
            fillstockscombobox();
            fillcutprintedparcelsgridview();
         }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        long gettotalbottels()
        {
            long bottels = 0;
            for (int i = 0; i < parcels.Count; i++)
            {
                bottels += parcels[i].SH_TOTAL_NUMBER_OF_BOTTELS;
            }
            return bottels;
        }

        long saveexchangedcutprintedquantity()
        {
            try
            {
                string query = "INSERT INTO SH_QUANTITIES_OF_EXCHANGED_CUT_PRINTED_TIN ";
                query += "( SH_NO_OF_PARCELS, SH_NO_OF_BOTTELS, SH_EXCHANGE_DATE, SH_EXCHANGE_PLACE, SH_EXCHANGE_REASON, SH_RECEIVED_MAN_NAME, SH_STOCK_ID, SH_STOCK_NAME,";
                query += " SH_STOCK_MAN_NAME, SH_CONFIDENTIAL_MAN_NAME, SH_WORK_ORDER_NUMBER, SH_EXCHANGE_PERMISSION_NUMBER)";
                query += " VALUES(@SH_NO_OF_PARCELS,@SH_NO_OF_BOTTELS,@SH_EXCHANGE_DATE,@SH_EXCHANGE_PLACE,";
                query+= "@SH_EXCHANGE_REASON,@SH_RECEIVED_MAN_NAME,@SH_STOCK_ID,@SH_STOCK_NAME,@SH_STOCK_MAN_NAME,@SH_CONFIDENTIAL_MAN_NAME,@SH_WORK_ORDER_NUMBER,@SH_EXCHANGE_PERMISSION_NUMBER)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NO_OF_PARCELS", parcels.Count );
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PLACE" , p_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_REASON" , "الانتاج");
                cmd.Parameters.AddWithValue("@SH_RECEIVED_MAN_NAME", receival_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID" , stocks[stock_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , stocks[stock_combo_box.SelectedIndex].SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_NO_OF_BOTTELS" , gettotalbottels());
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME" , stock_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CONFIDENTIAL_MAN_NAME" , confidential_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_WORK_ORDER_NUMBER" , work_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER" , exchange_permission_number.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING EXCHANGE CUT PRINTED TIN IN DB "+ex.ToString());
            }

            return 0;
        }

        void fillcutprintedparcelsgridview()
        {
            if (parcels.Count >0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    cut_printed_parcels_grid_view.Rows.Add(new string[] { (i + 1).ToString() , parcels[i].SH_CLIENT_NAME , parcels[i].SH_PRODUCT_NAME , parcels[i].SH_TOTAL_NUMBER_OF_BOTTELS.ToString()  , parcels[i].SH_NUMBER_OF_SEQUENCES.ToString() , parcels[i].SH_NUMBER_OF_BOTTLES_PER_SEQUENCE.ToString() });
                }
            
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if ( parcels.Count <= 0 ||    string.IsNullOrEmpty(work_number_text_box.Text) || string.IsNullOrEmpty(exchange_permission_number.Text) || string.IsNullOrEmpty(receival_man_text_box.Text) || string.IsNullOrEmpty(stock_man_text_box.Text) || string.IsNullOrEmpty(confidential_man_text_box.Text) || string.IsNullOrEmpty(p_text_box.Text))
            {
                MessageBox.Show("يرجي التاكد من كتابة البيانات بشكل صحيح " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else
            {
                saveexchangedprintedmaterialpallets();
            }
        }
    }
}
