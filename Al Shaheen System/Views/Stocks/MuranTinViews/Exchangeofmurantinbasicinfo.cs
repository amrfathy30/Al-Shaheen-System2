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
    public partial class Exchangeofmurantinbasicinfo : Form
    {
        List<SH_DEPARTEMENTS> deptList = new List<SH_DEPARTEMENTS>();
        List<SH_EMPLOYEES> empList = new List<SH_EMPLOYEES>();
        List<SH_MURAN_MATERIAL_PARCEL> parcels = new List<SH_MURAN_MATERIAL_PARCEL>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();
        public Exchangeofmurantinbasicinfo(List<SH_MURAN_MATERIAL_PARCEL> anyparcels,SH_USER_ACCOUNTS anyAccount)
        {
            InitializeComponent();
            parcels = anyparcels;
            Maccount = anyAccount;
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
        void fillparcelsgridview()
        {

            muran_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    muran_parcels_grid_view.Rows.Add(new string[] { (i + 1).ToString(), parcels[i].SH_ID.ToString(), parcels[i].SH_ITEM_CODE, parcels[i].SH_CLIENT_NAME, parcels[i].SH_ITEM_FIRST_FACE, parcels[i].SH_ITEM_SECOND_FACE, parcels[i].SH_SIZE_NAME, parcels[i].SH_MURAN_TYPE, parcels[i].SH_ITEM_NUMBER_OF_SHEETS.ToString(), parcels[i].SH_ITEM_PARCEL_GROSS_WEIGHT.ToString() });
                }
            }
        }
        void laodComboBxDept()
        {

            try
            {
                string query = "SELECT * FROM SH_DEPARTEMENTS where SH_ID=5 or SH_ID=6";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    deptList.Add(new SH_DEPARTEMENTS { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_DEPARTEMNT_NAME = reader["SH_DEPARTEMNT_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING departements Parts DATA FROM DB " + ex.ToString());
            }
        }

        void fillComboBxDept()
        {

            deptList.Clear();
            laodComboBxDept();
            comboBoxDept.Items.Clear();
            if (deptList.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < deptList.Count; i++)
                {
                    comboBoxDept.Items.Add(deptList[i].SH_DEPARTEMNT_NAME);
                }
            }
        }
        void loadReciver()
        {
            try
            {
                string query = "select * from SH_EMPLOYEES where SH_DEPARTMENT_ID=@id";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", deptList[comboBoxDept.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    empList.Add(new SH_EMPLOYEES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in getting deptID" + ex.ToString());
            }
        }
        void fillReciverCombobox()
        {
            empList.Clear();
            comboBoxreceival_man.Items.Clear();
            loadReciver();
            if (empList.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < empList.Count; i++)
                {
                    comboBoxreceival_man.Items.Add(empList[i].SH_EMPLOYEE_NAME);
                }
            }
        }
        private void Exchangerawtinbasicinfo_Load(object sender, EventArgs e)
        {
            stock_man_text_box.Text =Maccount.SH_EMP_NAME;
            fillparcelsgridview();
            fillstockscombobox();
            fillComboBxDept();
        }

        private void printering_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "إسم المطبعة";
        }

        private void production_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "مرحلة الانتاج";
        }

       
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private string get_change_reason()

        {
            if (printering_radio_btn.Checked)
            {
                return "الطباعة";

            }
            else if (muraning_radio_btn.Checked)
            {
                return "الورنشة";
            }
            else if (production_radio_btn.Checked)
            {
                return "الانتاج";
            }
            else
            {
                return null;
            }
        }
      long saveexchangemurantinheader()
        {
            try
            {
                string query = "INSERT INTO SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS ";
                query += " (SH_EXCHANGE_PERMISSION_NUMBER, SH_STOCK_ID, SH_STOCK_NAME, SH_EXCHANGE_DATE, SH_RECEIVED_MAN_NAME, SH_STOCK_MAN_NAME, SH_WORK_ORDER_NUMBER, SH_CONFIDENTIAL_MAN_NAME, ";
                query += " SH_REASON_OF_EXCHANGE, SH_PLACE_OF_EXCHANGE) ";
                query += " VALUES(@SH_EXCHANGE_PERMISSION_NUMBER,@SH_STOCK_ID,@SH_STOCK_NAME,@SH_EXCHANGE_DATE,@SH_RECEIVED_MAN_NAME,@SH_STOCK_MAN_NAME,@SH_WORK_ORDER_NUMBER,@SH_CONFIDENTIAL_MAN_NAME,@SH_REASON_OF_EXCHANGE,@SH_PLACE_OF_EXCHANGE)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER", exchange_permission_number.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID" , stocks[stock_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME", stock_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_RECEIVED_MAN_NAME", comboBoxreceival_man.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME"  , stock_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_WORK_ORDER_NUMBER" , work_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CONFIDENTIAL_MAN_NAME" , confidential_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_REASON_OF_EXCHANGE", get_change_reason());
                cmd.Parameters.AddWithValue("@SH_PLACE_OF_EXCHANGE" , p_text_box.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR SAVING MURAN TIN SPECIFICATION "+ ex.ToString());
            }
            return 0;
        }

      long getallno_sheets()
        {
            long no_sh = 0;
            for (int i = 0; i < parcels.Count; i++)
            {
                no_sh += parcels[i].SH_PARCELS_NO_SHEETS;
            }
            return no_sh;
        }
      long saveexchangemuranquantity(long sp_id)
        {
            try
            {
                string query = "INSERT INTO SH_QUANTITY_OF_EXCHANGED_MURAN_MATERIAL ";
                query += "(SH_NUMBER_OF_PARCELS, SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID, SH_TOTAL_NUMBER_OF_SHEETS, SH_EXCHANGE_DATE, SH_EXCHANGE_PERMISSION_NUMBER)";
                query += " VALUES(@SH_NUMBER_OF_PARCELS,@SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID,@SH_TOTAL_NUMBER_OF_SHEETS,@SH_EXCHANGE_DATE,@SH_EXCHANGE_PERMISSION_NUMBER)";
                query += " SELECT SCOPE_IDENTITY() AS myidentity ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_PARCELS" , parcels.Count);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID" , sp_id);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_SHEETS" , getallno_sheets());
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE", DateTime.Now);
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
                MessageBox.Show("ERROR WHILE SAVING EXCHANGE MURAN QUANTITY "+ex.ToString());
            }
            return 0;
        }

        void saveexchangedmuranparcels(long sp_id , long qu_id)
        {
            try
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    updatemuranmaterialspecifications(parcels[i].SH_ITEM_NUMBER_OF_SHEETS , 1 , parcels[i].SH_SPECIFICATION_OF_MURAN_MATERIAL_ID);
                    string query = "INSERT INTO SH_EXCHAGED_MURAN_PARCELS ";
                    query += "(SH_EXCHANGE_PERMISSION_NUMBER, SH_EXCHANGE_DATE, SH_QUANTITY_OF_EXCHANGED_MURAN_MATERIAL_ID, SH_MURAN_PARCEL_ID, SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID) ";
                    query += " VALUES(@SH_EXCHANGE_PERMISSION_NUMBER,@SH_EXCHANGE_DATE,@SH_QUANTITY_OF_EXCHANGED_MURAN_MATERIAL_ID,@SH_MURAN_PARCEL_ID,@SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER" , exchange_permission_number.Text);
                    cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_EXCHANGED_MURAN_MATERIAL_ID" , qu_id);
                    cmd.Parameters.AddWithValue("@SH_MURAN_PARCEL_ID", parcels[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID" , sp_id);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                MessageBox.Show("تم الحفظ بنجاح" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING EXCHANGED MURAN PARCELS "+ex.ToString());
            }
        }


        void updatemuranmaterialspecifications(long NO_SHEETS , long NO_PACKAGES  , long SP_ID)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_MURAN_MATERIAL ";
                query += " SET SH_ITEM_TOTAL_NUMBER_OF_SHEETS = SH_ITEM_TOTAL_NUMBER_OF_SHEETS -  @SH_ITEM_TOTAL_NUMBER_OF_SHEETS, SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = SH_ITEM_TOTAL_NUMBER_OF_PACKAGES -  @SH_ITEM_TOTAL_NUMBER_OF_PACKAGES  WHERE SH_ID = @SH_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS" , NO_SHEETS);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES" , NO_PACKAGES);
                cmd.Parameters.AddWithValue("@SH_ID", SP_ID);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING MURAN MATERIAL SPECIFICATIONS "+ex.ToString());
            }
        }







        private void save_btn_Click(object sender, EventArgs e)
        {
            bool cansaevornot = true;

            if (string.IsNullOrEmpty(work_number_text_box.Text))
            {
                cansaevornot = false;
            }

            if (string.IsNullOrEmpty(exchange_permission_number.Text))
            {
                cansaevornot = false;
            }


            if (string.IsNullOrEmpty(stock_combo_box.Text))
            {
                cansaevornot = false;
            }

            if (string.IsNullOrEmpty(stock_man_text_box.Text))
            {
                cansaevornot = false;
            }

            if (string.IsNullOrEmpty(confidential_man_text_box.Text))
            {
                cansaevornot = false;
            }

            if (string.IsNullOrEmpty(comboBoxreceival_man.Text))
            {
                cansaevornot = false;
            }

            if (parcels.Count <= 0)
            {
                cansaevornot = false;
            }

            if (get_change_reason() == null)
            {
                cansaevornot = false;
            }


            if (cansaevornot)
            {
                long sp_id = saveexchangemurantinheader();
                long q_id = saveexchangemuranquantity(sp_id);
                saveexchangedmuranparcels(sp_id , q_id);
            }else

            {
                MessageBox.Show("الرجاء كتابة البيانات بشكل كامل وصحيح " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private void comboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillReciverCombobox();
        }
    }
}
