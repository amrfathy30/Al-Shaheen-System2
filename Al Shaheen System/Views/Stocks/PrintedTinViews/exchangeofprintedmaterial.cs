using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class exchangeofprintedmaterial : Form
    {
        SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();
        List<SH_EMPLOYEES> empList = new List<SH_EMPLOYEES>();
        List<SH_DEPARTEMENTS> deptList = new List<SH_DEPARTEMENTS>();
        List<SH_PRINTED_MATERIAL_PARCEL> parcels = new List<SH_PRINTED_MATERIAL_PARCEL>();
        List<SH_SHAHEEN_CUTTERS> cutters = new List<SH_SHAHEEN_CUTTERS>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_SPECIFICATION_OF_PRINTED_MATERIAL> specifMuranMaterialLst = new List<SH_SPECIFICATION_OF_PRINTED_MATERIAL>();
        List<SH_SPECIFICATION_OF_PRINTED_MATERIAL> specifPrntMaterialLst = new List<SH_SPECIFICATION_OF_PRINTED_MATERIAL>();
        public exchangeofprintedmaterial(List<SH_PRINTED_MATERIAL_PARCEL> anyparcels,SH_USER_ACCOUNTS anyacount)
        {
            InitializeComponent();
            parcels = anyparcels;
            Maccount = anyacount;
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




        void laodComboStockMen()
        {

            try
            {
                string query = "select  * from SH_EMPLOYEES where SH_DEPARTMENT_ID=3";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    empList.Add(new SH_EMPLOYEES { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING departements Parts DATA FROM DB " + ex.ToString());
            }
        }

        //void fillComboStockMen()
        //{

        //    empList.Clear();
        //    laodComboStockMen();
        //    comboBoxStockMan.Items.Clear();
        //    if (empList.Count <= 0)
        //    {

        //    }
        //    else
        //    {
        //        for (int i = 0; i < empList.Count; i++)
        //        {
        //            comboBoxStockMan.Items.Add(empList[i].SH_EMPLOYEE_NAME);
        //        }
        //    }
        //}


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
                    empList.Add(new SH_EMPLOYEES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_EMPLOYEE_NAME=reader["SH_EMPLOYEE_NAME"].ToString() });
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

        long calcualtetotalsheets()
        {
            long totalsheets = 0;
            if (parcels.Count>0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    totalsheets += parcels[i].SH_PARCEL_NO_SHEETS;
                }
                return totalsheets;
            }
            return 0;
        }
        double calculatenetweight()
        {
            double totalnetweight = 0;
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    totalnetweight += parcels[i].SH_PARCEL_NET_WEIGHT;
                }
                return totalnetweight;
            }
            return 0;
        }
        double calculategrossweight()
        {
            double totalgrossweight = 0;
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    totalgrossweight += parcels[i].SH_ITEM_TOTAL_GROSS_WEIGHT;
                }
                return totalgrossweight;
            }
            return 0;
        }

        void updatespecificationvalues(SH_PRINTED_MATERIAL_PARCEL myparcel)
        {
          
            try
            {
                string query = "UPDATE  SH_SPECIFICATION_OF_PRINTED_MATERIAL ";
                query += " SET SH_ITEM_TOTAL_NO_SHEETS = SH_ITEM_TOTAL_NO_SHEETS - @SH_ITEM_TOTAL_NO_SHEETS , SH_ITEM_TOTAL_NET_WEIGHT = SH_ITEM_TOTAL_NET_WEIGHT - @SH_ITEM_TOTAL_NET_WEIGHT, SH_ITEM_TOTAL_GROSS_WEIGHT = SH_ITEM_TOTAL_GROSS_WEIGHT - @SH_ITEM_TOTAL_GROSS_WEIGHT, SH_ITEM_TOTAL_NO_PARCELS =  SH_ITEM_TOTAL_NO_PARCELS  - @SH_ITEM_TOTAL_NO_PARCELS  WHERE SH_ID  = @SH_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query  ,DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_SHEETS" , myparcel.SH_PARCEL_NO_SHEETS);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NET_WEIGHT" , myparcel.SH_PARCEL_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_GROSS_WEIGHT" , myparcel.SH_ITEM_TOTAL_GROSS_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_PARCELS" , 1);
                cmd.Parameters.AddWithValue("@SH_ID" , myparcel.SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SPECIFICATIONS VALUES "+ ex.ToString());
            }
             






        }
        long saveexchangedquantities()
        {
            try
            {
                string query = "INSERT INTO SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL";
                query += "(SH_NUMBER_OF_PARCELS, SH_NUMBER_OF_SHEETS, SH_EXCHANGE_DATE, SH_EXCHANGE_PERMISSION_NUMBER, SH_STOCK_MAN_NAME, SH_STOCK_MAN_ID, SH_STOCK_ID, SH_CUTTER_ID, SH_CUTTER_NAME,";
                query += " SH_CUTTER_MAN_NAME, SH_RECEIVED_MAN_NAME, SH_CONFIDENTIAL_MAN_NAME, SH_STOCK_NAME)";
                query += " VALUES(@SH_NUMBER_OF_PARCELS,@SH_NUMBER_OF_SHEETS,@SH_EXCHANGE_DATE,@SH_EXCHANGE_PERMISSION_NUMBER,@SH_STOCK_MAN_NAME,@SH_STOCK_MAN_ID,@SH_STOCK_ID,";
                query += "@SH_CUTTER_ID,@SH_CUTTER_NAME,@SH_CUTTER_MAN_NAME,@SH_RECEIVED_MAN_NAME,@SH_CONFIDENTIAL_MAN_NAME,@SH_STOCK_NAME)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query  , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_PARCELS", parcels.Count);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_SHEETS" , calcualtetotalsheets());
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER" , exchange_permission_number.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME" ,Maccount.SH_EMP_NAME);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID" , stocks[stock_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_CUTTER_ID"  , 0);//removed
                cmd.Parameters.AddWithValue("@SH_CUTTER_NAME"  , "");//removed
                cmd.Parameters.AddWithValue("@SH_CUTTER_MAN_NAME", "");//removed
                cmd.Parameters.AddWithValue("@SH_RECEIVED_MAN_NAME" , comboBoxreceival_man.Text);
                cmd.Parameters.AddWithValue("@SH_CONFIDENTIAL_MAN_NAME"  , confidential_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , stocks[stock_combo_box.SelectedIndex].SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID",Maccount.SH_EMP_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING EXCHANGED QUANTITIES IN DB "+ex.ToString());
            }
            return 0;
        }

        void saveexchangedprintedparcels(long quantity_id)
        {
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    try
                    {
                        string query = "INSERT INTO SH_EXCHANGED_PRINTED_MATERIAL_PARCELS ";
                        query += "(SH_EXCHANGE_DATE, SH_PRINTED_MATERIAL_PARCEL_ID, SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL_ID) VALUES(@SH_EXCHANGE_DATE,@SH_PRINTED_MATERIAL_PARCEL_ID,@SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL_ID)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(    query , DatabaseConnection.mConnection );
                        cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now);
                        cmd.Parameters.AddWithValue("@SH_PRINTED_MATERIAL_PARCEL_ID" , parcels[i].SH_ID);
                        cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL_ID" , quantity_id);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING EXCHANGED PRINTED PARCELS "+ex.ToString());
                    }
                }
                MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
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

        //may be error 
        void loadPrintedMuran(SH_PRINTED_MATERIAL_PARCEL myparcel)
        {
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PRINTED_MATERIAL WHERE SH_ID  = @SH_ID ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ID", myparcel.SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   specifPrntMaterialLst.Add(new SH_SPECIFICATION_OF_PRINTED_MATERIAL { SH_ID=long.Parse(reader["SH_ID"].ToString()),SH_ITEM_COATING=reader["SH_ITEM_COATING"].ToString(),SH_ITEM_CODE=reader["SH_ITEM_CODE"].ToString(),SH_ITEM_FINISH=reader["SH_ITEM_FINISH"].ToString(),SH_ITEM_LENGTH=long.Parse(reader["SH_ITEM_LENGTH"].ToString()),SH_ITEM_SHEET_WEIGHT=long.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()),SH_ITEM_TEMPER=reader["SH_ITEM_TEMPER"].ToString(),SH_ITEM_THICKNESS=double.Parse( reader["SH_ITEM_THICKNESS"].ToString()),SH_ITEM_TOTAL_GROSS_WEIGHT=double.Parse( reader["SH_ITEM_TOTAL_GROSS_WEIGHT"].ToString()),SH_ITEM_TOTAL_NET_WEIGHT=double.Parse(reader["SH_ITEM_TOTAL_NET_WEIGHT"].ToString()),SH_ITEM_TOTAL_NO_PARCELS=long.Parse(reader["SH_ITEM_TOTAL_NO_PARCELS"].ToString()),SH_ITEM_TOTAL_NO_SHEETS=long.Parse(reader["SH_ITEM_TOTAL_NO_SHEETS"].ToString()),SH_ITEM_TYPE=reader["SH_ITEM_TYPE"].ToString(),SH_ITEM_WIDTH=double.Parse(reader["SH_ITEM_WIDTH"].ToString()) });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING printed material DATA FROM DB " + ex.ToString());
            }
        }



        void loadPrintedMaterial(SH_PRINTED_MATERIAL_PARCEL myparcel)
        {
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_PRINTED_MATERIAL WHERE SH_ID  = @SH_ID ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ID", myparcel.SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    specifPrntMaterialLst.Add(new SH_SPECIFICATION_OF_PRINTED_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString(), SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString(), SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString(), SH_ITEM_LENGTH = long.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_SHEET_WEIGHT = long.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()), SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString(), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), SH_ITEM_TOTAL_GROSS_WEIGHT = double.Parse(reader["SH_ITEM_TOTAL_GROSS_WEIGHT"].ToString()), SH_ITEM_TOTAL_NET_WEIGHT = double.Parse(reader["SH_ITEM_TOTAL_NET_WEIGHT"].ToString()), SH_ITEM_TOTAL_NO_PARCELS = long.Parse(reader["SH_ITEM_TOTAL_NO_PARCELS"].ToString()), SH_ITEM_TOTAL_NO_SHEETS = long.Parse(reader["SH_ITEM_TOTAL_NO_SHEETS"].ToString()), SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString(), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()) });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING printed material DATA FROM DB " + ex.ToString());
            }
        }



        void loadMuranMaterial(SH_PRINTED_MATERIAL_PARCEL myparcel)
        {
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_MURAN_MATERIAL WHERE SH_ID  = @SH_ID ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ID", myparcel.SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
              //error      specifMuranMaterialLst.Add(new SH_SPECIFICATION_OF_MURAN_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString(), SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString(), SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString(), SH_ITEM_LENGTH = long.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_SHEET_WEIGHT = long.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()), SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString(), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), , SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString(), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()) });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING printed material DATA FROM DB " + ex.ToString());
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
        //void fillcutterscombobox()
        //{
        //    cutters_combo_box.Items.Clear();
        //    loadcuuttersdata();
        //    if (cutters.Count > 0)
        //    {
        //        for (int i = 0; i < cutters.Count; i++)
        //        {
        //            cutters_combo_box.Items.Add(cutters[i].SH_CUTTER_NAME);
        //        }
        //    }
        //}
        void fillparcelsgridview()
        {
            exchanged_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    exchanged_parcels_grid_view.Rows.Add(new string[] { (i+1).ToString() , parcels[i].SH_ITEM_LENGTH.ToString() , parcels[i].SH_ITEM_WIDTH.ToString() , parcels[i].SH_ITEM_THICKNESS.ToString() , parcels[i].SH_ITEM_CODE , parcels[i].SH_PARCEL_NO_SHEETS.ToString() , parcels[i].SH_TOTAL_NUMBER_OF_BOTTELS.ToString() , parcels[i].SH_ITEM_TOTAL_GROSS_WEIGHT.ToString()  , " عرض تفاصيل الشيت "   });
                }

            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void insertInCutterDaily()
        {

        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (parcels.Count >0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    updatespecificationvalues(parcels[i]);
                }
                
                long qu = saveexchangedquantities();
                saveexchangedprintedparcels(qu);
            }

            if(comboBoxDept.Text== "المقصات")
            {
          
            }
        }

        private void exchangeofprintedmaterial_Load(object sender, EventArgs e)
        {
            fillstockscombobox();
          //  fillcutterscombobox();
            fillparcelsgridview();
            fillComboBxDept();
            textBoxStockManName.Text = Maccount.SH_EMP_NAME;
           // fillComboStockMen();
        }

        private void exchanged_parcels_grid_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (exchanged_parcels_grid_view.SelectedCells[0].ColumnIndex== 8)
            {
                using (showprintedparcelclientsandproducts myform = new showprintedparcelclientsandproducts(parcels[exchanged_parcels_grid_view.SelectedCells[0].RowIndex]))
                {
                    myform.ShowDialog();
                }
            }
        }

        private void comboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxreceival_man.Text = "";
            fillReciverCombobox();
        }

        private void comboBoxDept_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            fillReciverCombobox();
        }
    }
}
