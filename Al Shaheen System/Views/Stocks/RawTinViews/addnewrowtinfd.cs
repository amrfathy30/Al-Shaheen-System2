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
    public partial class addnewrowtinfd : Form
    {
        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();


        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        SH_SPECIFICATION_OF_RAW_MATERIAL myprop = new SH_SPECIFICATION_OF_RAW_MATERIAL();
        List<SH_QUANTITY_OF_RAW_MATERIAL> quantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
        //bool savedate = true;
        double total_no_packges = 0;
        long all_packages_no_sheets = 0;
        double all_packages_gross_weight = 0;
      //  double item_total_cost = 0;
        public addnewrowtinfd(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;
        }

        void competecode()
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text) || string.IsNullOrWhiteSpace(item_type_combo_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text))
            {

            }
            else
            {
                item_code_text_box.Text = item_type_combo_box.Text + removedotinnumber(item_thickness_text_box.Text) + removedotinnumber(item_width_text_box.Text) + removedotinnumber(item_length_text_box.Text);
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
        void fillstockscombobox()
        {
            stocks.Clear();
            loadallstocks();
            stocks_combo_box.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stocks_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }
        long check_if_specification_exists_or_not()
        {
            long check_result = 0;

            try
            {
                string query = "SELECT SH_ID FROM SH_SPECIFICATION_OF_RAW_MATERIAL ";
                query += "WHERE(SH_ITEM_LENGTH = @SH_ITEM_LENGTH) AND (SH_ITEM_WIDTH = @SH_ITEM_WIDTH) AND (SH_ITEM_THICKNESS = @SH_ITEM_THICKNESS) AND (SH_ITEM_TYPE = @SH_ITEM_TYPE) AND ";
                query += "(SH_ITEM_TEMPER = @SH_ITEM_TEMPER) AND (SH_ITEM_COATING = @SH_ITEM_COATING) AND (SH_ITEM_FINISH = @SH_ITEM_FINISH)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", double.Parse(item_width_text_box.Text));
                cmd.Parameters.AddWithValue("SH_ITEM_THICKNESS", double.Parse(item_thickness_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", item_temper_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_COATING", item_coating_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", item_finish_combo_box.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader["SH_ID"].ToString()))
                    {
                        check_result = 0;
                    }
                    else
                    {
                        check_result = long.Parse(reader["SH_ID"].ToString());
                    }
                }

                myconnection.closeConnection();

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE CHECKING EXISTANCE IN SPECIFICATION OF RAW MATERIAL ");
            }


            return check_result;
        }
        void update_specifiction_quanities(long sid)
        {
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_RAW_MATERIAL SET SH_ITEM_TOTAL_NUMBER_OF_SHEETS = SH_ITEM_TOTAL_NUMBER_OF_SHEETS + @SH_ITEM_TOTAL_NUMBER_OF_SHEETS";
                query += ", SH_TOTAL_NET_WEIGHT = SH_TOTAL_NET_WEIGHT + @SH_TOTAL_NET_WEIGHT, SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = SH_ITEM_TOTAL_NUMBER_OF_PACKAGES + @SH_ITEM_TOTAL_NUMBER_OF_PACKAGES ,";
                query += " SH_TOTAL_GROSS_WEIGHT = SH_TOTAL_GROSS_WEIGHT + @SH_TOTAL_GROSS_WEIGHT WHERE SH_ID = @SH_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", all_packages_no_sheets);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT", (((double.Parse(item_length_text_box.Text) * double.Parse(item_width_text_box.Text) * double.Parse(item_thickness_text_box.Text)) / 1000000) * double.Parse(item_intensity_text_box.Text)) * double.Parse(all_packages_no_sheets.ToString()));
                cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT" , all_packages_gross_weight);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES" , total_no_packges);
                cmd.Parameters.AddWithValue("@SH_ID" , sid);

                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR UPDATING QUANTITES IN SPECIFICATION TABLE"+ex.ToString());
            }
        }
        string removedotinnumber(string number)
        {
            string numerFDS = number.ToString();
            return numerFDS.Replace(".","");
        }
        private void addnewrowtinfd_Load(object sender, EventArgs e)
        {
            fillstockscombobox();
            item_total_number_of_packages.Text = total_no_packges.ToString();
            item_type_combo_box.SelectedIndex = 0;
            stocks_combo_box.SelectedIndex = 0;
            item_finish_combo_box.SelectedIndex = 0;
            item_intensity_text_box.Text = (7.85).ToString();
            item_sheet_weight_text_box.Text = (0).ToString();
            item_temper_combo_box.SelectedIndex = 0;
        }
        long savetofirstduration_rawtin()
        {   
            if (!((errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == "") && (errorProvider1.GetError(item_coating_text_box) == "")))
            {
                MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                //MessageBox.Show("hello");
                try
                {
                    string query = "INSERT INTO SH_SPECIFICATION_OF_RAW_MATERIAL";
                    query += "(SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_TYPE, ";
                    query += "SH_ITEM_NAME, SH_ITEM_CODE, SH_ITEM_TEMPER, SH_ITEM_FINISH, SH_ITEM_COATING,";
                    query += "SH_ITEM_INTENSITY,SH_ITEM_TOTAL_NUMBER_OF_PACKAGES, SH_CREATION_DATE , ";
                    query += "SH_ITEM_TOTAL_NUMBER_OF_SHEETS , SH_TOTAL_NET_WEIGHT , SH_TOTAL_GROSS_WEIGHT  ";
                    query += ", SH_DATA_ENTRY_USER_ID, SH_DATA_ENTRY_USER_NAME, SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_EMPLOYEE_NAME)";
                    query += " VALUES(@SH_ITEM_LENGTH ,@SH_ITEM_WIDTH,";
                    query += "@SH_ITEM_THICKNESS, @SH_ITEM_TYPE, @SH_ITEM_NAME, @SH_ITEM_CODE, @SH_ITEM_TEMPER , ";
                    query += "@SH_ITEM_FINISH,@SH_ITEM_COATING,@SH_ITEM_INTENSITY,@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES ";
                    query += ", @SH_CREATION_DATE";
                    query += ",@SH_ITEM_TOTAL_NUMBER_OF_SHEETS , @SH_TOTAL_NET_WEIGHT , @SH_TOTAL_GROSS_WEIGHT ";
                    query += ", @SH_DATA_ENTRY_USER_ID, @SH_DATA_ENTRY_USER_NAME, @SH_DATA_ENTRY_EMPLOYEE_ID, @SH_DATA_ENTRY_EMPLOYEE_NAME)";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", double.Parse(item_width_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", double.Parse(item_thickness_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE", item_code_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", item_temper_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", item_finish_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", item_coating_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY", double.Parse(item_intensity_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_CREATION_DATE", DateTime.Parse( addition_date_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES", total_no_packges);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", all_packages_no_sheets);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT",( ((double.Parse(item_length_text_box.Text)*double.Parse(item_width_text_box.Text)*double.Parse(item_thickness_text_box.Text))/1000000)*double.Parse(item_intensity_text_box.Text))*double.Parse(all_packages_no_sheets.ToString()));
                    cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT" , all_packages_gross_weight);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME ",mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mAccount.SH_EMP_NAME);
                   SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                     //   MessageBox.Show("GENERAL : "+ reader["myidentity"].ToString());
                        return long.Parse( reader["myidentity"].ToString());
                    }
                    
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed to save to SH_SPECIFICATION_OF_RAW_MATERIAL " + ex.ToString());
                }
                return 0;

            }
            return 0;
        }
        void save_raw_tin_quantites( long specification_id)
        {
            for (int i = 0; i < quantities.Count; i++)
            {
                try
                {
                    string query = "INSERT INTO SH_QUANTITY_OF_RAW_MATERIAL ";
                    query += "(SH_SPECIFICATION_OF_RAW_MATERIAL_ID, SH_ITEM_LENGTH, SH_ITEM_WIDTH,";
                    query += "SH_ITEM_THICKNESS, SH_ITEM_INTENSITY, SH_ITEM_TEMPER, SH_ITEM_FINISH, ";
                    query += "SH_ITEM_COATING, SH_ITEM_TYPE,SH_ITEM_NAME, ";
                    query += "SH_ITEM_CODE, SH_ITEM_SHEET_WEIGHT, SH_TOTAL_NUMBER_OF_PACKAGES, ";
                    query += "SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE, SH_NET_WEIGHT,";
                    query += " SH_STOCK_NAME, SH_ADDITION_DATE, SH_ITEM_GROSS_WEIGHT, ";
                    query += " SH_DATA_ENTRY_USER_ID, SH_DATA_ENTRY_USER_NAME, SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_EMPLOYEE_NAME";
                    query += ") VALUES(";
                    query += "@SH_SPECIFICATION_OF_RAW_MATERIAL_ID,@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS";
                    query += ",@SH_ITEM_INTENSITY,@SH_ITEM_TEMPER,@SH_ITEM_FINISH,@SH_ITEM_COATING,@SH_ITEM_TYPE";
                    query += ",@SH_ITEM_NAME,@SH_ITEM_CODE,@SH_ITEM_SHEET_WEIGHT,@SH_TOTAL_NUMBER_OF_PACKAGES,";
                    query += "@SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE,@SH_NET_WEIGHT,@SH_STOCK_NAME,@SH_ADDITION_DATE,";
                    query += "@SH_ITEM_GROSS_WEIGHT , ";
                    query += " @SH_DATA_ENTRY_USER_ID, @SH_DATA_ENTRY_USER_NAME, @SH_DATA_ENTRY_EMPLOYEE_ID, @SH_DATA_ENTRY_EMPLOYEE_NAME";
                    query += ") SELECT SCOPE_IDENTITY() AS myidentity";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", specification_id);
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", double.Parse(item_width_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", double.Parse(item_thickness_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY", double.Parse(item_intensity_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", item_temper_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", item_finish_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", item_coating_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE", item_code_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", double.Parse(item_sheet_weight_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PACKAGES", quantities[i].SH_TOTAL_NUMBER_OF_PACKAGES);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE" , quantities[i].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE);
                    cmd.Parameters.AddWithValue("@SH_NET_WEIGHT" , quantities[i].SH_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , quantities[i].SH_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE" ,DateTime.Parse(addition_date_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_GROSS_WEIGHT" , quantities[i].SH_ITEM_GROSS_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME ", mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mAccount.SH_EMP_NAME);


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //MessageBox.Show("Quantity : "+reader["myidentity"].ToString());
                        save_raw_tin_packages(specification_id, i, long.Parse(reader["myidentity"].ToString()) , quantities[i].SH_TOTAL_NUMBER_OF_PACKAGES);
                    }
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING IN SH_QUANTITY_OF_RAW_MATERIAL" + ex.ToString());
                }
            }
        }
        void save_raw_tin_packages(long specification_id ,int quanitityindex  , long quantity_id , long no_packages)
        {
            for (int i = 0; i < no_packages; i++)
            {

                int year = DateTime.Parse(addition_date_text_box.Text).Year;
                try
                {
                    string query = "INSERT INTO SH_RAW_MATERIAL_PARCEL ";
                    query += "(SH_SPECIFICATION_OF_RAW_MATERIAL_ID, SH_QUANTITY_OF_RAW_MATERIAL_ID, ";
                    query += "SH_PARCEL_NUMBER, SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS,";
                    query += "SH_ITEM_INTENSITY, SH_ITEM_TEMPER, SH_ITEM_CODE, SH_ITEM_FINISH, SH_ITEM_COATING, SH_ITEM_NAME,";
                    query += "SH_ITEM_TYPE, SH_ITEM_SHEET_WEIGHT, SH_ITEM_NUMBER_OF_SHEETS,";
                    query += "SH_ITEM_PARCEL_GROSS_WEIGHT, SH_ITEM_PARCEL_NET_WEIGHT, SH_STOCK_NAME, SH_ADDITION_DATE";
                    query += ", SH_DATA_ENTRY_USER_ID, SH_DATA_ENTRY_USER_NAME, SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_EMPLOYEE_NAME";
                    query += ")VALUES(@SH_SPECIFICATION_OF_RAW_MATERIAL_ID,@SH_QUANTITY_OF_RAW_MATERIAL_ID,@SH_PARCEL_NUMBER,";
                    query += "@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_INTENSITY,@SH_ITEM_TEMPER,@SH_ITEM_CODE";
                    query += ",@SH_ITEM_FINISH,@SH_ITEM_COATING,@SH_ITEM_NAME,@SH_ITEM_TYPE,@SH_ITEM_SHEET_WEIGHT";
                    query += ",@SH_ITEM_NUMBER_OF_SHEETS,@SH_ITEM_PARCEL_GROSS_WEIGHT,@SH_ITEM_PARCEL_NET_WEIGHT,@SH_STOCK_NAME,";
                    query += "@SH_ADDITION_DATE, @SH_DATA_ENTRY_USER_ID, @SH_DATA_ENTRY_USER_NAME, @SH_DATA_ENTRY_EMPLOYEE_ID, @SH_DATA_ENTRY_EMPLOYEE_NAME)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", specification_id);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_RAW_MATERIAL_ID" , quantity_id);
                    cmd.Parameters.AddWithValue("@SH_PARCEL_NUMBER" , year.ToString());
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text ));
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH" , double.Parse(item_width_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS" , double.Parse(item_thickness_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY" , double.Parse(item_intensity_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", item_temper_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE" , item_code_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", item_finish_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", item_coating_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME" ,"صفيح");
                    cmd.Parameters.AddWithValue("@SH_ITEM_TYPE" , item_type_combo_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT" ,double.Parse(item_sheet_weight_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ITEM_NUMBER_OF_SHEETS" , quantities[quanitityindex].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE);
                    cmd.Parameters.AddWithValue("@SH_ITEM_PARCEL_GROSS_WEIGHT" , quantities[quanitityindex].SH_ITEM_GROSS_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_ITEM_PARCEL_NET_WEIGHT", quantities[quanitityindex].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE* double.Parse(item_sheet_weight_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME", quantities[quanitityindex].SH_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Parse(addition_date_text_box.Text) );
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME ", mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mAccount.SH_EMP_NAME);

                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                catch (Exception EX)
                {
                    MessageBox.Show("FAILED TO SAVE IN SH_RAW_MATERIAL_PARCEL"+EX.ToString());
                }
            }
        }
        private void saverawtinfirstdurationbtn_Click(object sender, EventArgs e)
        {

           
                long id = check_if_specification_exists_or_not();
                if (id == 0)
                {
                    //error

                    long sid = savetofirstduration_rawtin();
                    if (sid == 0)
                    {
                        //error
                    }
                    else
                    {
                        save_raw_tin_quantites(sid);
                        MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }

                }
                else
                {
                    update_specifiction_quanities(id);
                    save_raw_tin_quantites(id);
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
           // }
        }
        void fillgridviewitems()
        {
            item_quantities_grid_view.Rows.Clear();
            
            for (int i = 0; i < quantities.Count; i++)
            {
                item_quantities_grid_view.Rows.Add(new string[] { (i + 1).ToString(), quantities[i].SH_TOTAL_NUMBER_OF_PACKAGES.ToString(), quantities[i].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE.ToString(), quantities[i].SH_TOTAL_NUMBER_OF_SHEETS().ToString(),quantities[i].SH_ITEM_GROSS_WEIGHT.ToString() , quantities[i].SH_NET_WEIGHT.ToString() });
            }
        }        
        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {

            }
            else if ((errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == ""))
            {
                item_code_text_box.Text = item_type_combo_box.Text+removedotinnumber(item_thickness_text_box.Text) + removedotinnumber(item_width_text_box.Text) + removedotinnumber(item_length_text_box.Text);
                item_sheet_weight_text_box.Text = ((double.Parse(item_length_text_box.Text) * double.Parse(item_width_text_box.Text) * double.Parse(item_thickness_text_box.Text) / 1000000) * double.Parse(item_intensity_text_box.Text)).ToString();
                
                if (string.IsNullOrWhiteSpace(no_packages_text_box.Text) || string.IsNullOrWhiteSpace(no_sheets_per_package_text_box.Text) || string.IsNullOrWhiteSpace(package_gross_weight_text_box.Text))
                {
                    MessageBox.Show("لا يمكن إضافة فراغات من الكمية  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (errorProvider1.GetError(no_packages_text_box) != "" || errorProvider1.GetError(no_sheets_per_package_text_box) != "" || errorProvider1.GetError(package_gross_weight_text_box) != "")
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    package_net_weight_text_box.Text = (long.Parse(no_packages_text_box.Text) * long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();

                    quantities.Add(new SH_QUANTITY_OF_RAW_MATERIAL { SH_ITEM_GROSS_WEIGHT = double.Parse(package_gross_weight_text_box.Text), SH_TOTAL_NUMBER_OF_PACKAGES = long.Parse(no_packages_text_box.Text), SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE = long.Parse(no_sheets_per_package_text_box.Text), SH_NET_WEIGHT = double.Parse(package_net_weight_text_box.Text) , SH_STOCK_NAME = stocks_combo_box.Text });
                    all_packages_no_sheets += (long.Parse(no_sheets_per_package_text_box.Text)* long.Parse(no_packages_text_box.Text));
                    total_no_packges += long.Parse(no_packages_text_box.Text);
                    all_packages_gross_weight += double.Parse(package_gross_weight_text_box.Text);
                    total_gross_weight.Text = all_packages_gross_weight.ToString();
                    total_net_weight.Text = (all_packages_no_sheets * double.Parse(item_sheet_weight_text_box.Text)).ToString();
                    item_total_number_of_packages.Text = total_no_packges.ToString();

                    //  item_total_cost += 0;
                    package_gross_weight_text_box.Text = "";
                    ton_price.Text = "";
                    no_packages_text_box.Text = "";
                    no_sheets_per_package_text_box.Text = "";
                    package_net_weight_text_box.Text = "";

                    fillgridviewitems();
                }
            }
        }
        private void no_packages_text_box_TextChanged(object sender, EventArgs e)
        {
            long mygross = 0;
            if (!long.TryParse(no_packages_text_box.Text, out mygross))
            {
                errorProvider1.SetError(no_packages_text_box, " 123 ادخل الوزن القائم بصورة ارقام");
            }
            else
            {
                errorProvider1.Clear();
            }
       

        }
        private void ton_price_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(ton_price.Text, out mygross))
            {
                errorProvider1.SetError(ton_price, " 12.012 ادخل السعر بصورة ارقام");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void package_gross_weight_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(package_gross_weight_text_box.Text, out mygross))
            {
                errorProvider1.SetError(package_gross_weight_text_box, "ادخل الوزن القائم بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void item_length_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_length_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_length_text_box, "ادخل الطول بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();


            }
        }
        private void item_width_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_width_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_width_text_box , "ادخل العرض بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();
            }
        }
        private void item_thickness_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_thickness_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_thickness_text_box, "ادخل السمك بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();
            }
        }
        private void no_sheets_per_package_text_box_TextChanged(object sender, EventArgs e)
        {
            long mygross = 0;
            if (!long.TryParse(no_sheets_per_package_text_box.Text, out mygross))
            {
                errorProvider1.SetError(no_sheets_per_package_text_box, " 123 ادخل عدد الشيتات  بصورة ارقام");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void addnewrowtinfd_Activated(object sender, EventArgs e)
        {

        }
        private void addnewrowtinfd_Enter(object sender, EventArgs e)
        {
           
        }
        private void addnewrowtinfd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {

            }
            else if ((errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == ""))
            {
                item_code_text_box.Text = item_type_combo_box.Text + removedotinnumber(item_thickness_text_box.Text) + removedotinnumber(item_width_text_box.Text) + removedotinnumber(item_length_text_box.Text);
                item_sheet_weight_text_box.Text = ((double.Parse(item_length_text_box.Text) * double.Parse(item_width_text_box.Text) * double.Parse(item_thickness_text_box.Text) / 1000000) * double.Parse(item_intensity_text_box.Text)).ToString();
            }

            if (string.IsNullOrWhiteSpace(no_packages_text_box.Text) || string.IsNullOrWhiteSpace(no_sheets_per_package_text_box.Text) || string.IsNullOrWhiteSpace(item_sheet_weight_text_box.Text))
            {

            }
            else if ((errorProvider1.GetError(no_packages_text_box) == "") && (errorProvider1.GetError(no_sheets_per_package_text_box) == "") && (errorProvider1.GetError(item_sheet_weight_text_box) == ""))
            {
                package_net_weight_text_box.Text = (long.Parse(no_packages_text_box.Text) * long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();
            }
            total_gross_weight.Text = all_packages_gross_weight.ToString();
            total_net_weight.Text = (all_packages_no_sheets * double.Parse(item_sheet_weight_text_box.Text)).ToString();
            item_total_number_of_packages.Text = total_no_packges.ToString();
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void add_new_raw_tn_info_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewrowtinfd myform = new addnewrowtinfd(mEmployee, mAccount, mPermission))
            {
                myform.ShowDialog();
            }
            this.Close();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void item_temper_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void total_gross_weight_TextChanged(object sender, EventArgs e)
        {

        }
        private void delete_quantity_info_btn_Click(object sender, EventArgs e)
        {
            if (item_quantities_grid_view.SelectedRows.Count > 0)
            {
                total_no_packges -= quantities[item_quantities_grid_view.SelectedRows[0].Index].SH_TOTAL_NUMBER_OF_PACKAGES;
                double MYWEIGHT = double.Parse(total_net_weight.Text);
                MYWEIGHT -= quantities[item_quantities_grid_view.SelectedRows[0].Index].SH_TOTAL_NUMBER_OF_PACKAGES;
                total_net_weight.Text = MYWEIGHT.ToString();

                quantities.Remove(quantities[item_quantities_grid_view.SelectedRows[0].Index]);

            }
            fillgridviewitems();
        }

        private void item_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_type_combo_box.Text))
            {

            }else
            {
                competecode();
            }
        }

        private void item_thickness_text_box_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {

            }
            else
            {
                double num = double.Parse(item_thickness_text_box.Text);
                item_thickness_text_box.Text = num.ToString();
            }
        }
    }
}
