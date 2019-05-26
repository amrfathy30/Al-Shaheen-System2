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
    public partial class addnewrawtin : Form
    {

        DateTime addition_date = DateTime.Now;
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        List<SH_SPECIFICATION_OF_RAW_MATERIAL> all_specifications = new List<SH_SPECIFICATION_OF_RAW_MATERIAL>();
        List<SH_RAW_MATERIAL_PARCEL> every_quantity_parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        List<SH_QUANTITY_OF_RAW_MATERIAL> quantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
        List<raw_material_card_info> last_inserted_packages_ids = new List<raw_material_card_info>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        //bool savedate = true;
        long total_no_packges = 0;
        long all_packages_no_sheets = 0;
        double all_packages_gross_weight = 0;
        double adding_request_net_weight = 0;
        double adding_request_gross_weight = 0;
        //double item_total_cost = 0;

        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public addnewrawtin(SH_EMPLOYEES anyemp ,SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS mPerm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = mPerm;

        }

        async Task autogenerateadditionpermisionnumber()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_ADDITION_PERMISSION_NUMBER_OF_RAW_TIN  ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (string.IsNullOrWhiteSpace(reader["lastedid"].ToString()))
                    {
                        reader.Close();
                    }
                    else
                    {
                        mycount = long.Parse(reader["lastedid"].ToString());
                    }
                }

                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting new permission number " + ex.ToString());
            }


            if (mycount == 0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                permissionnumber += "RAW_TIN-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                adding_request_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber += "RAW_TIN-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                adding_request_number_text_box.Text = permissionnumber;
            }
        }





        private void savenewpermssionnumber()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_ADDITION_PERMISSION_NUMBER_OF_RAW_TIN (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER", 1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }



        void loadallspecifications()
        {
            all_specifications.Clear();
            try
            {
                string query = "SELECT * FROM SH_SPECIFICATION_OF_RAW_MATERIAL";
               
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    all_specifications.Add(new SH_SPECIFICATION_OF_RAW_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString() , SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString() , SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString() , SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString() , SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString()  });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING SPECIFICATION DATA"+ex.ToString());
            }
        }

        void loadallstocks ()
        {
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_STOCKS";           
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK { SH_STOCK_NAME  = reader["SH_STOCK_NAME"].ToString() , SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString() , SH_STOCK_ADDRESS_GPS  = reader["SH_STOCK_ADDRESS_GPS"].ToString() });
                }
                reader.Close();               
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING STOCKS DATA FROM DB "+ ex.ToString());
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
        
        async Task <bool> check_existance_of_adding_permission_number(string anynumber)
        {
            List<string> adding_permission_numbers = new List<string>();
            //get all adding permission numbers
            try
            {        
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT SH_ADDING_NUMBER FROM SH_QUANTITY_OF_RAW_MATERIAL " , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    adding_permission_numbers.Add(reader["SH_ADDING_NUMBER"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ADDING PERMISSION NUMBERS" + ex.ToString() );
            }
            //search in the list
            for (int i = 0; i < adding_permission_numbers.Count; i++)
            {
                if (string.Compare(adding_permission_numbers[i] , anynumber)==0)
                {
                    return true;
                }
            }
            return false;
        }


        void loadsuppliersdata()
        {
            //string query = "SELECT * FROM SH_SUPPLY_COMPANY";
            try
            {
                
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SUPPLIERS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE LOADING SUPLLIERS DATA");
            }
        }
       long check_if_specification_exists_or_not(SH_QUANTITY_OF_RAW_MATERIAL anyquantity)
        {
            loadallspecifications();
            long check_result = 0;

            for (int i = 0; i < all_specifications.Count; i++)
            {
                if ((string.Compare(all_specifications[i].SH_ITEM_TEMPER, anyquantity.SH_ITEM_TEMPER)==0) && (string.Compare(all_specifications[i].SH_ITEM_CODE , anyquantity.SH_ITEM_CODE)==0) && (string.Compare(all_specifications[i].SH_ITEM_COATING , anyquantity.SH_ITEM_COATING)==0) &&(string.Compare(all_specifications[i].SH_ITEM_FINISH, anyquantity.SH_ITEM_FINISH)==0) && (string.Compare(all_specifications[i].SH_ITEM_TYPE , anyquantity.SH_ITEM_TYPE)==0))
                {
                    return all_specifications[i].SH_ID;
                }
            }
               
            return check_result;
        }
        async Task  update_specifiction_quanities(long sid , SH_QUANTITY_OF_RAW_MATERIAL anyquantity)
        {         
            try
            {
                string query = "UPDATE SH_SPECIFICATION_OF_RAW_MATERIAL SET SH_ITEM_TOTAL_NUMBER_OF_SHEETS = SH_ITEM_TOTAL_NUMBER_OF_SHEETS + @SH_ITEM_TOTAL_NUMBER_OF_SHEETS";
                query += ", SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = SH_ITEM_TOTAL_NUMBER_OF_PACKAGES + @SH_ITEM_TOTAL_NUMBER_OF_PACKAGES";
                query += ", SH_TOTAL_NET_WEIGHT = SH_TOTAL_NET_WEIGHT + @SH_TOTAL_NET_WEIGHT, ";
                query += " SH_TOTAL_GROSS_WEIGHT = SH_TOTAL_GROSS_WEIGHT + @SH_TOTAL_GROSS_WEIGHT WHERE SH_ID = @SH_ID";
                
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", anyquantity.SH_TOTAL_NUMBER_OF_SHEETS());
                cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT", anyquantity.SH_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT", anyquantity.SH_ITEM_GROSS_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES", anyquantity.SH_TOTAL_NUMBER_OF_PACKAGES);
                cmd.Parameters.AddWithValue("@SH_ID", sid);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR UPDATING QUANTITES IN SPECIFICATION TABLE" + ex.ToString());
            }
        }
        async Task<long> savetofirstduration_rawtin( SH_QUANTITY_OF_RAW_MATERIAL myquantity)
        {
            if (!((errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == "") && (errorProvider1.GetError(item_coating_text_box) == "")))
            {
                MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                try
                {
                    string query = "INSERT INTO SH_SPECIFICATION_OF_RAW_MATERIAL";
                    query += "(SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_TYPE, ";
                    query += "SH_ITEM_NAME, SH_ITEM_CODE, SH_ITEM_TEMPER, SH_ITEM_FINISH, SH_ITEM_COATING,";
                    query += "SH_ITEM_INTENSITY,SH_ITEM_TOTAL_NUMBER_OF_PACKAGES, SH_CREATION_DATE , ";
                    query += "SH_ITEM_TOTAL_NUMBER_OF_SHEETS , SH_TOTAL_NET_WEIGHT , SH_TOTAL_GROSS_WEIGHT ) ";
                    query += " VALUES(@SH_ITEM_LENGTH ,@SH_ITEM_WIDTH,";
                    query += "@SH_ITEM_THICKNESS, @SH_ITEM_TYPE, @SH_ITEM_NAME, @SH_ITEM_CODE, @SH_ITEM_TEMPER , ";
                    query += "@SH_ITEM_FINISH,@SH_ITEM_COATING,@SH_ITEM_INTENSITY,@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES ";
                    query += ", @SH_CREATION_DATE";
                    query += ",@SH_ITEM_TOTAL_NUMBER_OF_SHEETS , @SH_TOTAL_NET_WEIGHT , @SH_TOTAL_GROSS_WEIGHT) ";
                    query += "SELECT SCOPE_IDENTITY() AS myidentity";
                    
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", myquantity.SH_ITEM_LENGTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", myquantity.SH_ITEM_WIDTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", myquantity.SH_ITEM_THICKNESS);
                     this.Invoke((MethodInvoker)delegate ()
                    {
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", myquantity.SH_ITEM_TYPE);
                    });
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE",myquantity.SH_ITEM_CODE);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", myquantity.SH_ITEM_TEMPER);
                    });
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", myquantity.SH_ITEM_FINISH);
                    });
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", myquantity.SH_ITEM_COATING);
                    cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY", myquantity.SH_ITEM_INTENSITY);
                    cmd.Parameters.AddWithValue("@SH_CREATION_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES",myquantity.SH_TOTAL_NUMBER_OF_PACKAGES);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS",myquantity.SH_TOTAL_NUMBER_OF_SHEETS());
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT",  myquantity.SH_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT", myquantity.SH_ITEM_GROSS_WEIGHT);
                    SqlDataReader reader = cmd.ExecuteReader();
                    long id = 0;
                    if (reader.Read())
                    {
                        //MessageBox.Show("GENERAL : " + reader["myidentity"].ToString());
                        id= long.Parse(reader["myidentity"].ToString());
                    }
                    reader.Close();

                    myconnection.closeConnection();
                    return id;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed to save to SH_SPECIFICATION_OF_RAW_MATERIAL " + ex.ToString());
                }
                return 0;

            }
            return 0;
        }
        async Task  save_raw_tin_quantites(long specification_id ,SH_QUANTITY_OF_RAW_MATERIAL myquantity )
        {

            long current_quantity_id = 0;
           
                try
                {
                    string query = "INSERT INTO SH_QUANTITY_OF_RAW_MATERIAL ";
                    query += "( SH_SPECIFICATION_OF_RAW_MATERIAL_ID,SH_ADDING_PERMISSION_DATE, SH_ITEM_LENGTH, SH_ITEM_WIDTH,";
                    query += " SH_ITEM_THICKNESS, SH_ITEM_INTENSITY, SH_ITEM_TEMPER, SH_ITEM_FINISH, ";
                    query += " SH_ITEM_COATING,SH_SUPPLIER_NAME, SH_ITEM_TYPE,SH_ITEM_NAME, ";
                    query += " SH_ITEM_CODE,SH_ADDING_NUMBER, SH_ITEM_SHEET_WEIGHT, SH_TOTAL_NUMBER_OF_PACKAGES, ";
                    query += " SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE, SH_NET_WEIGHT,";
                    query += " SH_STOCK_NAME, SH_ADDITION_DATE, SH_ITEM_GROSS_WEIGHT ";
                    query += " ,SH_DATA_ENTRY_USER_ID,SH_DATA_ENTRY_USER_NAME, ";
                    query += " SH_DATA_ENTRY_EMPLOYEE_ID,SH_DATA_ENTRY_EMPLOYEE_NAME)VALUES( ";
                    query += " @SH_SPECIFICATION_OF_RAW_MATERIAL_ID,@SH_ADDING_PERMISSION_DATE,@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS";
                    query += " , @SH_ITEM_INTENSITY,@SH_ITEM_TEMPER,@SH_ITEM_FINISH,@SH_ITEM_COATING,@SH_SUPPLIER_NAME,@SH_ITEM_TYPE";
                    query += " , @SH_ITEM_NAME,@SH_ITEM_CODE,@SH_ADDING_NUMBER,@SH_ITEM_SHEET_WEIGHT,@SH_TOTAL_NUMBER_OF_PACKAGES,";
                    query += " @SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE,@SH_NET_WEIGHT,@SH_STOCK_NAME,@SH_ADDITION_DATE,";
                    query += " @SH_ITEM_GROSS_WEIGHT ";
                    query += " , @SH_DATA_ENTRY_USER_ID,@SH_DATA_ENTRY_USER_NAME, ";
                    query += " @SH_DATA_ENTRY_EMPLOYEE_ID,@SH_DATA_ENTRY_EMPLOYEE_NAME";
                    query += ") SELECT SCOPE_IDENTITY() AS myidentity";
                    
                    
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);

                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", specification_id);
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", myquantity.SH_ITEM_LENGTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", myquantity.SH_ITEM_WIDTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", myquantity.SH_ITEM_THICKNESS);
                    cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY", myquantity.SH_ITEM_INTENSITY);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", myquantity.SH_ITEM_TEMPER);
                    cmd.Parameters.AddWithValue("@SH_ADDING_PERMISSION_DATE" , DateTime.Parse(adding_permission_date_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ADDING_NUMBER" , adding_request_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", myquantity.SH_ITEM_FINISH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", myquantity.SH_ITEM_COATING);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_NAME", myquantity.SH_SUPPLIER_NAME);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", myquantity.SH_ITEM_TYPE);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE", myquantity.SH_ITEM_CODE);
                    cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", myquantity.SH_ITEM_PARCEL_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PACKAGES", myquantity.SH_TOTAL_NUMBER_OF_PACKAGES);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE", myquantity.SH_TOTAL_NUMBER_OF_SHEETS());
                    cmd.Parameters.AddWithValue("@SH_NET_WEIGHT", myquantity.SH_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME", myquantity.SH_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", addition_date);
                    cmd.Parameters.AddWithValue("@SH_ITEM_GROSS_WEIGHT", myquantity.SH_ITEM_GROSS_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID",mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME" , mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID" ,mEmployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME" ,mEmployee.SH_EMPLOYEE_NAME);

                SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        //MessageBox.Show("Quantity : "+reader["myidentity"].ToString());
                        current_quantity_id = long.Parse(reader["myidentity"].ToString());
                    }

                    reader.Close();
                    long ex_or=0;
                    myconnection.closeConnection();
                    this.Invoke((MethodInvoker)async delegate ()
                    {
                        ex_or = await saveexamination_order(specification_id, current_quantity_id, myquantity);
                    });

                    this.Invoke((MethodInvoker)async delegate ()
                    {
                        await save_raw_tin_packages(specification_id, current_quantity_id, myquantity.SH_TOTAL_NUMBER_OF_PACKAGES, ex_or, myquantity.SH_QUANTITY_PARCELS, myquantity);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING IN SH_QUANTITY_OF_RAW_MATERIAL" + ex.ToString());
                }
            
        }

        async Task  save_raw_tin_packages(long specification_id,  long quantity_id, long no_packages, long examination_order_id, List<SH_RAW_MATERIAL_PARCEL> myparcels, SH_QUANTITY_OF_RAW_MATERIAL myquantity)
        {
            long current_parcel = 0;
            for (int i = 0; i < myparcels.Count; i++)
            {

                int year = addition_date.Year;
                try
                {
                    string query = "INSERT INTO SH_RAW_MATERIAL_PARCEL ";
                    query += "(SH_SPECIFICATION_OF_RAW_MATERIAL_ID, SH_QUANTITY_OF_RAW_MATERIAL_ID, ";
                    query += "SH_PARCEL_NUMBER,SH_ADDING_PERMISSION_NUMBER,SH_ADDING_PERMISSION_DATE, SH_ITEM_LENGTH, SH_ITEM_WIDTH, SH_ITEM_THICKNESS,";
                    query += "SH_ITEM_INTENSITY, SH_ITEM_TEMPER, SH_ITEM_CODE, SH_ITEM_FINISH,SH_SUPPLIER_NAME, SH_ITEM_COATING, SH_ITEM_NAME,";
                    query += "SH_ITEM_TYPE, SH_ITEM_SHEET_WEIGHT, SH_ITEM_NUMBER_OF_SHEETS,";
                    query += "SH_ITEM_PARCEL_GROSS_WEIGHT, SH_ITEM_PARCEL_NET_WEIGHT, SH_STOCK_NAME, SH_ADDITION_DATE)";
                    query += "VALUES(@SH_SPECIFICATION_OF_RAW_MATERIAL_ID,@SH_QUANTITY_OF_RAW_MATERIAL_ID,@SH_PARCEL_NUMBER,@SH_ADDING_PERMISSION_NUMBER,@SH_ADDING_PERMISSION_DATE,";
                    query += "@SH_ITEM_LENGTH,@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_INTENSITY,@SH_ITEM_TEMPER,@SH_ITEM_CODE";
                    query += ",@SH_ITEM_FINISH,@SH_SUPPLIER_NAME,@SH_ITEM_COATING,@SH_ITEM_NAME,@SH_ITEM_TYPE,@SH_ITEM_SHEET_WEIGHT";
                    query += ",@SH_ITEM_NUMBER_OF_SHEETS,@SH_ITEM_PARCEL_GROSS_WEIGHT,@SH_ITEM_PARCEL_NET_WEIGHT,@SH_STOCK_NAME,";
                    query += "@SH_ADDITION_DATE) SELECT SCOPE_IDENTITY() AS myidentity";
                   
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", specification_id);
                    cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_RAW_MATERIAL_ID", quantity_id);
                    cmd.Parameters.AddWithValue("@SH_PARCEL_NUMBER", year.ToString());
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", myparcels[i].SH_ITEM_LENGTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", myparcels[i].SH_ITEM_WIDTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", myparcels[i].SH_ITEM_THICKNESS);
                    cmd.Parameters.AddWithValue("@SH_ITEM_INTENSITY", myparcels[i].SH_ITEM_INTENSITY);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", myparcels[i].SH_ITEM_TEMPER);
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE", myparcels[i].SH_ITEM_CODE);
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", myparcels[i].SH_ITEM_FINISH);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_NAME", myparcels[i].SH_SUPPLIER_NAME);
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", myparcels[i].SH_ITEM_COATING);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_combo_box.Text);
                    });
                    cmd.Parameters.AddWithValue("@SH_ITEM_SHEET_WEIGHT", myparcels[i].SH_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NUMBER_OF_SHEETS", myparcels[i].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE);
                    cmd.Parameters.AddWithValue("@SH_ITEM_PARCEL_GROSS_WEIGHT", myparcels[i].SH_ITEM_GROSS_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_ITEM_PARCEL_NET_WEIGHT", myparcels[i].SH_ITEM_PARCEL_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME", myquantity.SH_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", addition_date);
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        cmd.Parameters.AddWithValue("@SH_ADDING_PERMISSION_NUMBER", adding_request_number_text_box.Text);
                    });
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        cmd.Parameters.AddWithValue("@SH_ADDING_PERMISSION_DATE", DateTime.Parse(adding_permission_date_text_box.Text));
                    });
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        current_parcel = long.Parse(reader["myidentity"].ToString());
                    }
                    reader.Close();
                    myconnection.closeConnection();
                    last_inserted_packages_ids.Add(new raw_material_card_info { item_number = current_parcel, item_code = item_code_text_box.Text, item_name = "صفيح خام ", item_type = item_type_combo_box.Text, stock_name = myquantity.SH_STOCK_NAME, no_sheets = myquantity.SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE });
                    this.Invoke((MethodInvoker)async delegate ()
                    {
                        await saveexamination_order_packages(examination_order_id, current_parcel);
                    });


                    //   MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                catch (Exception EX)
                {
                    MessageBox.Show("FAILED TO SAVE IN SH_RAW_MATERIAL_PARCEL" + EX.ToString());
                }
            }
        }

        async Task <long >saveexamination_order(long SPECIFICATION_ID , long QUANTITY_ID , SH_QUANTITY_OF_RAW_MATERIAL anyquantity)
        {

            try
            {
                string query = "INSERT INTO SH_EXAMINATION_OF_RAW_MATERIAL ";
                query += "(SH_EXAMINATION_ORDER_NUMBER , SH_SPECIFICATION_OF_RAW_MATERIAL_ID, SH_QUANTITY_OF_RAW_MATERIAL_ID,";
                query += "SH_DATE_EXAMINATION, SH_STOCK_MAN_NAME, SH_TOTAL_NO_PARCELS, SH_STOCK_NAME, ";
                query += "SH_TOTAL_NO_SHEETS, SH_GROSS_WEIGHT, SH_NET_WEIGHT, SH_TECHNICAL_MAN,";
                query += "SH_EXAMINATION_RESULT, SH_ADDITION_DATE,SH_ITEM_STAT) VALUES(@SH_EXAMINATION_ORDER_NUMBER, @SH_SPECIFICATION_OF_RAW_MATERIAL_ID ";
                query += ",@SH_QUANTITY_OF_RAW_MATERIAL_ID,@SH_DATE_EXAMINATION,@SH_STOCK_MAN_NAME,@SH_TOTAL_NO_PARCELS,";
                query += "@SH_STOCK_NAME,@SH_TOTAL_NO_SHEETS,@SH_GROSS_WEIGHT,@SH_NET_WEIGHT,@SH_TECHNICAL_MAN";
                query += ",@SH_EXAMINATION_RESULT,@SH_ADDITION_DATE,@SH_ITEM_STAT) SELECT SCOPE_IDENTITY() AS myidentity";
               
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_EXAMINATION_ORDER_NUMBER" , long.Parse(examination_number_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", SPECIFICATION_ID );
                cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_RAW_MATERIAL_ID" , QUANTITY_ID);
                this.Invoke((MethodInvoker)delegate ()
                {
                    cmd.Parameters.AddWithValue("@SH_DATE_EXAMINATION", DateTime.Parse(adding_permission_date_text_box.Text));
                });
                this.Invoke((MethodInvoker)delegate ()
                {
                    cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", stock_man_text_box.Text);
                });
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_PARCELS", total_no_packges);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , anyquantity.SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_SHEETS", all_packages_no_sheets);
                cmd.Parameters.AddWithValue("@SH_GROSS_WEIGHT" , adding_request_gross_weight);
                cmd.Parameters.AddWithValue("@SH_NET_WEIGHT" , adding_request_net_weight);
                this.Invoke((MethodInvoker)delegate ()
                {
                    cmd.Parameters.AddWithValue("@SH_TECHNICAL_MAN", technical_text_box.Text);
                });
                    cmd.Parameters.AddWithValue("@SH_EXAMINATION_RESULT", "NONE");
                cmd.Parameters.AddWithValue("@SH_ITEM_STAT" , "ACCEPTED");
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE" , DateTime.Now);

                SqlDataReader reader = cmd.ExecuteReader();
                long id =0;
                if (reader.Read())
                {

                    id=  long.Parse(reader["myidentity"].ToString()); 
                }
                reader.Close();
                myconnection.closeConnection();
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING EXAMINATION ORDER INFORMATION "+ex.ToString());
               
            }
            return 0;
        }


        async Task  saveexamination_order_packages(long exmination_id , long package_id)
        {
            try
            {
                string query = "INSERT INTO SH_MINUTES_PACKAGES_EXAMINED_RAW_MATERIAL";
                query += "(SH_EXAMINATION_OF_RAW_MATERIAL_ID, SH_ITEM_PRACEL_ID) VALUES( ";
                query += "@SH_EXAMINATION_OF_RAW_MATERIAL_ID,@SH_ITEM_PRACEL_ID)";
               
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_EXAMINATION_OF_RAW_MATERIAL_ID", exmination_id);
                cmd.Parameters.AddWithValue("@SH_ITEM_PRACEL_ID", package_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING EXAMIATION ORDER PACKAGES "+ex.ToString());

            }
        }


        void competecode()
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text)|| string.IsNullOrWhiteSpace(item_thickness_text_box.Text) || string.IsNullOrWhiteSpace(item_type_combo_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text))
            {

            }else
            {
                item_code_text_box.Text = item_type_combo_box.Text + removedotinnumber(double.Parse(item_thickness_text_box.Text)) + removedotinnumber(double.Parse(item_width_text_box.Text)) + removedotinnumber(double.Parse(item_length_text_box.Text));
            }
        }


        string removedotinnumber(double number)
        {
           
            string numerFDS = number.ToString();
            //if there is dot and no azero    >>> auto complete zero

            return numerFDS.Replace(".", "");
        }


        void calculateprcelnetweight()
        {
            if (string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text)|| string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {
            }else
            {
                double testnumber = 0;
                if (double.TryParse(item_length_text_box.Text,out testnumber)&& double.TryParse(item_width_text_box.Text,out testnumber)&& double.TryParse(item_thickness_text_box.Text,out testnumber))
                {
                    item_sheet_weight_text_box.Text = ((double.Parse(item_length_text_box.Text) * double.Parse(item_width_text_box.Text)* double.Parse(item_thickness_text_box.Text)*7.85)/1000000).ToString();
                }
            }
        }



        void fillgridviewitems()
        {
            item_quantities_grid_view.Rows.Clear();

            for (int i = 0; i < quantities.Count; i++)
            {
                item_quantities_grid_view.Rows.Add(new string[] { (i + 1).ToString(), quantities[i].SH_TOTAL_NUMBER_OF_PACKAGES.ToString(), quantities[i].SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE.ToString(), quantities[i].SH_TOTAL_NUMBER_OF_SHEETS().ToString(), quantities[i].SH_NET_WEIGHT.ToString(), quantities[i].SH_ITEM_GROSS_WEIGHT.ToString() });
            }
        }
        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            long testnumber = 0;
            if (!long.TryParse(examination_number_text_box.Text, out testnumber) || string.IsNullOrEmpty(item_type_combo_box.Text) || string.IsNullOrWhiteSpace(item_length_text_box.Text) || string.IsNullOrWhiteSpace(item_width_text_box.Text) || string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {
                //DO NOTHING
                MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);


            }
            else if ((errorProvider1.GetError(item_type_combo_box) == "")&&(errorProvider1.GetError(item_length_text_box) == "") && (errorProvider1.GetError(item_width_text_box) == "") && (errorProvider1.GetError(item_thickness_text_box) == ""))
            {
                item_code_text_box.Text = item_type_combo_box.Text+removedotinnumber(double.Parse(item_thickness_text_box.Text)) + removedotinnumber(double.Parse(item_width_text_box.Text)) + removedotinnumber(double.Parse(item_length_text_box.Text));
                item_sheet_weight_text_box.Text = ((double.Parse(item_width_text_box.Text) * double.Parse(item_length_text_box.Text) * double.Parse(item_thickness_text_box.Text) / 1000000) * double.Parse(item_intensity_text_box.Text)).ToString();

                if (string.IsNullOrWhiteSpace(no_packages_text_box.Text) || string.IsNullOrWhiteSpace(no_sheets_per_package_text_box.Text) || string.IsNullOrWhiteSpace(parcel_gross_weight.Text))
                {
                    MessageBox.Show("لا يمكن إضافة فراغات من الكمية  ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else if (errorProvider1.GetError(no_packages_text_box) != "" || errorProvider1.GetError(no_sheets_per_package_text_box) != "" || errorProvider1.GetError(parcel_gross_weight) != "")
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    parcel_net_weight.Text = (long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(item_sheet_weight_text_box.Text)).ToString();
                    //MessageBox.Show(parcel_net_weight.Text);
                    package_net_weight_text_box.Text = (double.Parse(parcel_net_weight.Text)*double.Parse(no_packages_text_box.Text)).ToString();
                    package_gross_weight_text_box.Text = (double.Parse(parcel_gross_weight.Text) * long.Parse(no_packages_text_box.Text)).ToString();
                    long quantity_number_of_parcels = long.Parse(no_packages_text_box.Text);

                    adding_request_gross_weight += double.Parse(package_gross_weight_text_box.Text);
                    adding_request_net_weight += double.Parse(package_net_weight_text_box.Text);

                    for (int i = 0; i < quantity_number_of_parcels; i++)
                    {
                       every_quantity_parcels.Add(new SH_RAW_MATERIAL_PARCEL{ SH_ITEM_COATING = item_coating_text_box.Text , SH_ITEM_TEMPER = item_temper_combo_box.Text, SH_ITEM_GROSS_WEIGHT = double.Parse(parcel_gross_weight.Text), SH_ITEM_PARCEL_NET_WEIGHT = double.Parse(parcel_net_weight.Text) , SH_ITEM_PARCEL_GROSS_WEIGHT = double.Parse(parcel_gross_weight.Text) , SH_ITEM_CODE = item_code_text_box.Text , SH_ITEM_FINISH = item_finish_combo_box.Text , SH_ITEM_INTENSITY = double.Parse(item_intensity_text_box.Text) ,  SH_ITEM_TYPE = item_type_combo_box.Text , SH_ITEM_LENGTH = double.Parse(item_length_text_box.Text)  , SH_ITEM_WIDTH = double.Parse(item_width_text_box.Text) , SH_ITEM_NUMBER_OF_SHEETS = long.Parse(no_sheets_per_package_text_box.Text) , SH_STOCK_NAME = stocks_combo_box.Text , SH_ITEM_THICKNESS = double.Parse(item_thickness_text_box.Text) , SH_NET_WEIGHT = double.Parse(item_sheet_weight_text_box.Text) , SH_SUPPLIER_NAME = suppliers_combo_box.Text , SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE= long.Parse(no_sheets_per_package_text_box.Text)});
                    }


                  
                    quantities.Add(new SH_QUANTITY_OF_RAW_MATERIAL {SH_ITEM_COATING = item_coating_text_box.Text, SH_ITEM_PARCEL_NET_WEIGHT= double.Parse(parcel_net_weight.Text), SH_ITEM_GROSS_WEIGHT =  double.Parse(package_gross_weight_text_box.Text) , SH_ITEM_FINISH = item_finish_combo_box.Text , SH_ITEM_TYPE = item_type_combo_box.Text , SH_SUPPLIER_NAME = suppliers_combo_box.Text, SH_ITEM_CODE = item_code_text_box.Text , SH_ITEM_TEMPER = item_temper_combo_box.Text, SH_TOTAL_NUMBER_OF_PACKAGES = long.Parse(no_packages_text_box.Text), SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE = long.Parse(no_sheets_per_package_text_box.Text), SH_NET_WEIGHT = double.Parse(package_net_weight_text_box.Text), SH_STOCK_NAME = stocks_combo_box.Text , SH_QUANTITY_PARCELS = every_quantity_parcels , SH_ITEM_INTENSITY= double.Parse(item_intensity_text_box.Text), SH_ITEM_LENGTH=double.Parse(item_length_text_box.Text), SH_ITEM_THICKNESS= double.Parse(item_thickness_text_box.Text) , SH_ITEM_WIDTH= double.Parse(item_width_text_box.Text) });

                    every_quantity_parcels = new List<SH_RAW_MATERIAL_PARCEL>();
                    all_packages_no_sheets += (long.Parse(no_sheets_per_package_text_box.Text)* long.Parse(no_packages_text_box.Text) );
                    total_no_packges += long.Parse(no_packages_text_box.Text);
                  //  parcel_net_weight.Text = (long.Parse(no_sheets_per_package_text_box.Text) * double.Parse(parcel_net_weight.Text)).ToString();
                    all_packages_gross_weight += double.Parse(package_gross_weight_text_box.Text);
                   
                    total_gross_weight.Text = all_packages_gross_weight.ToString();
                    total_net_weight.Text = adding_request_net_weight.ToString();
                    item_total_number_of_packages.Text = total_no_packges.ToString();

                    //  item_total_cost += 0;
                    parcel_gross_weight.Text = "";
                    package_gross_weight_text_box.Text = "";
                    no_packages_text_box.Text = "";
                    no_sheets_per_package_text_box.Text = "";
                    package_net_weight_text_box.Text = "";

                    fillgridviewitems();
                }
            }
        }

        void fillsupplierscombobox()
        {
            for (int i = 0; i < suppliers.Count; i++)
            {
                suppliers_combo_box.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
            }
        }

        private async void addnewrawtin_Load(object sender, EventArgs e)
        {
            await autogenerateadditionpermisionnumber();
            stock_man_text_box.Text = mEmployee.SH_EMPLOYEE_NAME;
            fillstockscombobox();
            loadsuppliersdata();
            fillsupplierscombobox();
            if (suppliers.Count > 0)
            {
                suppliers_combo_box.SelectedIndex = 0;
            }
            item_total_number_of_packages.Text = total_no_packges.ToString();
            //  item_type_combo_box.SelectedIndex = 0;
            stocks_combo_box.SelectedIndex = 0;
            item_finish_combo_box.SelectedIndex = 0;
            item_intensity_text_box.Text = (7.85).ToString();
            item_sheet_weight_text_box.Text = (0).ToString();
            item_temper_combo_box.SelectedIndex = 0;
        }



        private void adding_request_number_text_box_TextChanged(object sender, EventArgs e)
        {
            //long testnumber; 
            //if (!long.TryParse(adding_request_number_text_box.Text , out testnumber))
            //{ 
            //    errorProvider1.SetError(adding_request_number_text_box, "إكتب أرقام فقط 123...");
            //}else
            //{
            //    errorProvider1.Clear();
            //}
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
            calculateprcelnetweight();
        }

        private void item_width_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(item_width_text_box.Text, out mygross))
            {
                errorProvider1.SetError(item_width_text_box, "ادخل العرض بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
                competecode();
            }
            calculateprcelnetweight();
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
            calculateprcelnetweight();
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
                if (!string.IsNullOrEmpty(no_sheets_per_package_text_box.Text))
                {
                    parcel_net_weight.Text = (double.Parse(item_sheet_weight_text_box.Text) * long.Parse(no_sheets_per_package_text_box.Text)).ToString();
                }
            }
        }

        private void package_gross_weight_text_box_TextChanged(object sender, EventArgs e)
        {
            double mygross = 0;
            if (!double.TryParse(parcel_gross_weight.Text, out mygross))
            {
                errorProvider1.SetError(parcel_gross_weight, "ادخل الوزن القائم بصورة ارقام 12.012");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void ton_price_TextChanged(object sender, EventArgs e)
        {
            //double mygross = 0;
            //if (!double.TryParse(ton_price.Text, out mygross))
            //{
            //    errorProvider1.SetError(ton_price, " 12.012 ادخل السعر بصورة ارقام");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newaddingrequest_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewrawtin myform = new addnewrawtin(mEmployee,mAccount,mPermission))
            {
                myform.ShowDialog();
            }
            this.Close();
        }



        public  async Task saverawtindata()
        {

            if (string.IsNullOrEmpty(adding_request_number_text_box.Text))
            {
                MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء إدخال رقم إذن الإضافة ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            {
                if ( await check_existance_of_adding_permission_number(adding_request_number_text_box.Text))
                {
                    MessageBox.Show(" رقم إذن الإضافة قد تم إضافته من قبل الرجاء إدخال رقم جديد  ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
                else
                {
                    
                    for (int i = 0; i < quantities.Count; i++)
                    {
                        long id =  check_if_specification_exists_or_not(quantities[i]);
                        if (id == 0)
                        {
                            //error
                            savenewpermssionnumber();
                            long sid = await savetofirstduration_rawtin(quantities[i]);
                            if (sid == 0)
                            {
                                //error
                            }
                            else
                            {
                               await save_raw_tin_quantites(sid , quantities[i]);
                            }
                        }
                        else
                        {
                            savenewpermssionnumber();
                            await update_specifiction_quanities(id, quantities[i]);
                            await save_raw_tin_quantites(id, quantities[i]);

                        }

                        //using (printrawmaterialaddingrequest myform = new printrawmaterialaddingrequest(adding_request_number_text_box.Text, DateTime.Now.ToString(), stocks_combo_box.Text, stock_man_text_box.Text, quantities))
                        //{
                        //    myform.ShowDialog();
                        //}
                    }
                }
                //if (last_inserted_packages_ids.Count > 1)
                //{
                //    //using (printedcaredsforrawmaterial myform = new printedcaredsforrawmaterial(this.last_inserted_packages_ids))
                //    //{ 
                //    //    myform.ShowDialog();
                //    //}
                //}

                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                rawtinaddingprinterdata mydata = new rawtinaddingprinterdata();
                mydata.addition_permission_number = adding_request_number_text_box.Text;
                mydata.additiondate = DateTime.Now;
                mydata.stock = stocks[stocks_combo_box.SelectedIndex];
                mydata.stock_man_name = mEmployee;
                mydata.quantities = quantities;
                printrawtinaddedquantities myf = new printrawtinaddedquantities(mydata);
                myf.Show();
                this.Hide();
                using (addnewrawtin myform = new addnewrawtin(mEmployee, mAccount, mPermission))
                {
                    myform.ShowDialog();
                }
                this.Close();

            }






        }



        private async void savenewrawtinaddingrequest_Click(object sender, EventArgs e)
        {
            //Task task = Task.Run((Action) MyFunction);
            Cursor.Current = Cursors.WaitCursor;
            //Task t = new Task(async () =>
            //{
            await saverawtindata();
            //});
            //t.Start();
            Cursor.Current = Cursors.Default;
            //  MessageBox.Show("");

        }
        

        private void delete_quantity_columne_Click(object sender, EventArgs e)
        {

            if (item_quantities_grid_view.SelectedRows.Count > 0)
            {

                all_packages_no_sheets -= quantities[item_quantities_grid_view.SelectedRows[0].Index].SH_TOTAL_NUMBER_OF_SHEETS();
                adding_request_net_weight -= quantities[item_quantities_grid_view.SelectedRows[0].Index].SH_NET_WEIGHT;
                adding_request_gross_weight -= quantities[item_quantities_grid_view.SelectedRows[0].Index].SH_ITEM_GROSS_WEIGHT;
                quantities.Remove(quantities[item_quantities_grid_view.SelectedRows[0].Index]);
            }
            fillgridviewitems();
            item_total_number_of_packages.Text = all_packages_no_sheets.ToString();
            total_gross_weight.Text = adding_request_gross_weight.ToString();
            total_net_weight.Text = adding_request_net_weight.ToString();
        }

        private void item_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(item_type_combo_box.Text))
            {
                errorProvider1.SetError(item_type_combo_box,"لا يمكن ان يكون نوع الصنف فارغ");
            }else
            {
                errorProvider1.Clear();
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

        private async void addnewrawtin_Enter(object sender, EventArgs e)
        {
            await autogenerateadditionpermisionnumber();
        }

        private async void addnewrawtin_Activated(object sender, EventArgs e)
        {
            await autogenerateadditionpermisionnumber();
        }
    }
    
}
