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
    public partial class updateUserPermissionsFrm : Form
    {
        SH_USER_ACCOUNTS acc = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS userPerm = new SH_USER_PERMISIONS();
        List<SH_USER_PERMISIONS> userPermList = new List<SH_USER_PERMISIONS>();
        public updateUserPermissionsFrm( SH_USER_ACCOUNTS anyaccount )
        {
            InitializeComponent();
            acc = anyaccount;
        }

        private void buttonCacel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void loadUserPermisions()
        {
            string query = "select * from SH_USER_PERMISIONS";
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader red = comm.ExecuteReader();
                while (red.Read())
                {
                    userPermList.Add(new SH_USER_PERMISIONS { SH_ID=long.Parse(red["SH_ID"].ToString()), SH_ACCOUNT_ID=long.Parse(red["SH_ACCOUNT_ID"].ToString()), SH_ACCOUNT_NAME=red["SH_ACCOUNT_NAME"].ToString() });
                }
                red.Close();
                conn.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in loading User permisions from dataBase" + ex.Message);
            }
        }

        long checkUserPermionEmpID()
        {
            long spc_id = 0;
            if (userPermList.Count > 0)
            {
                for (int i = 0; i < userPermList.Count; i++)
                {
                    if ((string.Compare(userPermList[i].SH_ACCOUNT_NAME, acc.SH_EMP_USER_NAME) == 0))
                    {
                        spc_id = userPermList[i].SH_ACCOUNT_ID;
                        return spc_id;
                    }
                }
                

            }
            return 0;
        }
        void saveUserPermisions()
        {

            try
            {

               

                string query = " INSERT INTO SH_USER_PERMISIONS ";
                query += "(SH_ACCOUNT_ID, SH_ACCOUNT_NAME, SH_OPEN_CHANGE_PASSWORD, SH_OPEN_DASH_BOARD, SH_OPEN_GETALL_EMP, SH_OPEN_DISPLAY_ALLUSERS, SH_OPEN_MAKE_NEW_USER, SH_OPEN_REGIST_EMP,";
                query += " SH_OPEN_SELECT_USER_PERMISION, SH_ADD_NEW_CLIENT_COMPANY, SH_ADD_NEW_CLIENT_BRANCH, SH_SHOW_ALL_CLIENTS, SH_ADD_NEW_SUPPLIER, SH_ADD_NEW_SUPPLIER_BRANCH,";
                query += " SH_SHOW_ALL_SUPPLIERS, SH_MAIN_TIN_STOCK, SH_RAW_TIN_MATERIAL, SH_ADD_NEW_RAW_TIN_FIRST_DURATION, SH_ADD_NEW_RAW_TIN, SH_EXCHANGE_RAW_TIN_PARCEL_NO,";
                query += " SH_EXCHANGE_RAW_TIN_PROPERTIES, SH_ADD_NEW_MURAN_TIN, SH_EXCHANGE_MURAN_TIN, SH_ADD_NEW_PRINTED_TIN, SH_EXCHANGE_PRINTED_TIN, SH_ADD_NEW_SIZE, SH_ADD_NEW_CUT_RAW_TIN,";
                query += " SH_EXCHANGE_CUT_RAW_TIN, SH_ADD_NEW_CUT_PRINTED_TIN, SH_EXCHANGE_CUT_PRINTED_TIN, SH_ADD_NEW_CUT_MURAN_TIN, SH_EXCHANGE_CUT_MURAN_TIN, SH_SHOW_ALL_CUTTERS,";
                query += " SH_ADD_NEW_CUTTERS, SH_ADD_NEW_STOCK_PLACE, SH_SHOW_ALL_STOCKS, SH_DEPARTMENT_STOCKS, SH_DEPARTMENT_SALES, SH_DEPARTMENT_HR, SH_DEPARTMENT_PURCHASING,";
                query += " SH_DEPARTMENT_SECRETARY, SH_DEPARTMENT_ACCOUNTING, SH_DEPARTMENT_IT, SH_DEPARTMENT_PRODUCTION, SH_IT_SERVER_SETTINGS, SH_ADD_NEW_DEPARTMENT, SH_ADD_NEW_JOB,";
                query += " SH_ADD_NEW_PRODUCT_CLIENT, SH_ADD_NEW_COLOR, SH_ADD_PRODUCTION_REQUIRMENT, SH_EXCHANGE_PRODUCTION_REQUIRMENT, SH_ADD_CHANGE_BITS, SH_EXCHANGE_CHANGE_BITS,";
                query += " SH_ADD_EASY_OPEN, SH_EXCHANGE_EASY_OPEN, SH_ADD_TIN_CANS, SH_EXCHANGE_TIN_CANS, SH_ADD_NEW_RLT, SH_EXCHANGE_RLT, SH_ADD_NEW_BOTTOM, SH_EXCHANGE_BOTTOM)";
                query += " VALUES(@SH_ACCOUNT_ID, @SH_ACCOUNT_NAME, @SH_OPEN_CHANGE_PASSWORD, @SH_OPEN_DASH_BOARD, @SH_OPEN_GETALL_EMP, @SH_OPEN_DISPLAY_ALLUSERS, @SH_OPEN_MAKE_NEW_USER, @SH_OPEN_REGIST_EMP, ";
                query += " @SH_OPEN_SELECT_USER_PERMISION, @SH_ADD_NEW_CLIENT_COMPANY, @SH_ADD_NEW_CLIENT_BRANCH, @SH_SHOW_ALL_CLIENTS, @SH_ADD_NEW_SUPPLIER, @SH_ADD_NEW_SUPPLIER_BRANCH, ";
                query += " @SH_SHOW_ALL_SUPPLIERS, @SH_MAIN_TIN_STOCK, @SH_RAW_TIN_MATERIAL, @SH_ADD_NEW_RAW_TIN_FIRST_DURATION, @SH_ADD_NEW_RAW_TIN, @SH_EXCHANGE_RAW_TIN_PARCEL_NO, ";
                query += " @SH_EXCHANGE_RAW_TIN_PROPERTIES, @SH_ADD_NEW_MURAN_TIN, @SH_EXCHANGE_MURAN_TIN, @SH_ADD_NEW_PRINTED_TIN, @SH_EXCHANGE_PRINTED_TIN, @SH_ADD_NEW_SIZE, @SH_ADD_NEW_CUT_RAW_TIN, ";
                query += " @SH_EXCHANGE_CUT_RAW_TIN, @SH_ADD_NEW_CUT_PRINTED_TIN, @SH_EXCHANGE_CUT_PRINTED_TIN, @SH_ADD_NEW_CUT_MURAN_TIN, @SH_EXCHANGE_CUT_MURAN_TIN, @SH_SHOW_ALL_CUTTERS, ";
                query += " @SH_ADD_NEW_CUTTERS, @SH_ADD_NEW_STOCK_PLACE, @SH_SHOW_ALL_STOCKS, @SH_DEPARTMENT_STOCKS, @SH_DEPARTMENT_SALES, @SH_DEPARTMENT_HR, @SH_DEPARTMENT_PURCHASING, ";
                query += " @SH_DEPARTMENT_SECRETARY, @SH_DEPARTMENT_ACCOUNTING, @SH_DEPARTMENT_IT, @SH_DEPARTMENT_PRODUCTION, @SH_IT_SERVER_SETTINGS, @SH_ADD_NEW_DEPARTMENT, @SH_ADD_NEW_JOB, ";
                query += " @SH_ADD_NEW_PRODUCT_CLIENT, @SH_ADD_NEW_COLOR, @SH_ADD_PRODUCTION_REQUIRMENT, @SH_EXCHANGE_PRODUCTION_REQUIRMENT, @SH_ADD_CHANGE_BITS, @SH_EXCHANGE_CHANGE_BITS, ";
                query+=" @SH_ADD_EASY_OPEN, @SH_EXCHANGE_EASY_OPEN, @SH_ADD_TIN_CANS, @SH_EXCHANGE_TIN_CANS, @SH_ADD_NEW_RLT, @SH_EXCHANGE_RLT, @SH_ADD_NEW_BOTTOM, @SH_EXCHANGE_BOTTOM) ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ACCOUNT_ID", acc.SH_ID);
                cmd.Parameters.AddWithValue("@SH_ACCOUNT_NAME", acc.SH_EMP_USER_NAME);
                cmd.Parameters.AddWithValue("@SH_OPEN_CHANGE_PASSWORD" , userPerm.SH_OPEN_CHANGE_PASSWORD);
                cmd.Parameters.AddWithValue("@SH_OPEN_DASH_BOARD", userPerm.SH_OPEN_DASH_BOARD);
                cmd.Parameters.AddWithValue("@SH_OPEN_GETALL_EMP" , userPerm.SH_OPEN_GETALL_EMP);
                cmd.Parameters.AddWithValue("@SH_OPEN_DISPLAY_ALLUSERS", userPerm.SH_OPEN_DISPLAY_ALLUSERS);
                cmd.Parameters.AddWithValue("@SH_OPEN_MAKE_NEW_USER",userPerm.SH_OPEN_MAKE_NEW_USER);
                cmd.Parameters.AddWithValue("@SH_OPEN_REGIST_EMP" , userPerm.SH_OPEN_REGIST_EMP);
                cmd.Parameters.AddWithValue("@SH_OPEN_SELECT_USER_PERMISION", userPerm.SH_OPEN_SELECT_USER_PERMISION);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_CLIENT_COMPANY",userPerm.SH_ADD_NEW_CLIENT_COMPANY );
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_CLIENT_BRANCH", userPerm.SH_ADD_NEW_CLIENT_BRANCH);
                cmd.Parameters.AddWithValue("@SH_SHOW_ALL_CLIENTS", userPerm.SH_SHOW_ALL_CLIENTS);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_SUPPLIER",userPerm.SH_ADD_NEW_SUPPLIER);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_SUPPLIER_BRANCH" , userPerm.SH_ADD_NEW_SUPPLIER_BRANCH);
                cmd.Parameters.AddWithValue("@SH_SHOW_ALL_SUPPLIERS", userPerm.SH_SHOW_ALL_SUPPLIERS);
                cmd.Parameters.AddWithValue("@SH_MAIN_TIN_STOCK",userPerm.SH_MAIN_TIN_STOCK);
                cmd.Parameters.AddWithValue("@SH_RAW_TIN_MATERIAL", userPerm.SH_RAW_TIN_MATERIAL);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_RAW_TIN_FIRST_DURATION", userPerm.SH_ADD_NEW_RAW_TIN_FIRST_DURATION);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_RAW_TIN", userPerm.SH_ADD_NEW_RAW_TIN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_RAW_TIN_PARCEL_NO", userPerm.SH_EXCHANGE_RAW_TIN_PARCEL_NO);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_RAW_TIN_PROPERTIES", userPerm.SH_EXCHANGE_RAW_TIN_PROPERTIES);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_MURAN_TIN",userPerm.SH_ADD_NEW_MURAN_TIN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_MURAN_TIN", userPerm.SH_EXCHANGE_MURAN_TIN);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_PRINTED_TIN", userPerm.SH_ADD_NEW_PRINTED_TIN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PRINTED_TIN", userPerm.SH_EXCHANGE_PRINTED_TIN);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_SIZE", userPerm.SH_ADD_NEW_SIZE);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_CUT_RAW_TIN", userPerm.SH_ADD_NEW_CUT_RAW_TIN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_CUT_RAW_TIN", userPerm.SH_EXCHANGE_CUT_RAW_TIN);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_CUT_PRINTED_TIN",userPerm.SH_ADD_NEW_CUT_PRINTED_TIN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_CUT_PRINTED_TIN", userPerm.SH_EXCHANGE_CUT_PRINTED_TIN);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_CUT_MURAN_TIN", userPerm.SH_ADD_NEW_CUT_MURAN_TIN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_CUT_MURAN_TIN", userPerm.SH_EXCHANGE_CUT_MURAN_TIN);
                cmd.Parameters.AddWithValue("@SH_SHOW_ALL_CUTTERS", userPerm.SH_SHOW_ALL_CUTTERS);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_CUTTERS", userPerm.SH_ADD_NEW_CUTTERS);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_STOCK_PLACE", userPerm.SH_ADD_NEW_STOCK_PLACE);
                cmd.Parameters.AddWithValue("@SH_SHOW_ALL_STOCKS", userPerm.SH_SHOW_ALL_STOCKS);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_STOCKS", userPerm.SH_DEPARTMENT_STOCKS);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_SALES", userPerm.SH_DEPARTMENT_SALES);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_HR", userPerm.SH_DEPARTMENT_HR);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_PURCHASING", userPerm.SH_DEPARTMENT_PURCHASING);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_SECRETARY", userPerm.SH_DEPARTMENT_SECRETARY);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_ACCOUNTING", userPerm.SH_DEPARTMENT_ACCOUNTING);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_IT", userPerm.SH_DEPARTMENT_IT);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_PRODUCTION", userPerm.SH_DEPARTMENT_PRODUCTION);
                cmd.Parameters.AddWithValue("@SH_IT_SERVER_SETTINGS", userPerm.SH_IT_SERVER_SETTINGS);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_DEPARTMENT", userPerm.SH_ADD_NEW_DEPARTMENT);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_JOB", userPerm.SH_ADD_NEW_JOB);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_PRODUCT_CLIENT", userPerm.SH_ADD_NEW_PRODUCT_CLIENT);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_COLOR", userPerm.SH_ADD_NEW_COLOR);
                cmd.Parameters.AddWithValue("@SH_ADD_PRODUCTION_REQUIRMENT", userPerm.SH_ADD_PRODUCTION_REQUIRMENT);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PRODUCTION_REQUIRMENT", userPerm.SH_EXCHANGE_PRODUCTION_REQUIRMENT);
                cmd.Parameters.AddWithValue("@SH_ADD_CHANGE_BITS" , userPerm.SH_ADD_CHANGE_BITS);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_CHANGE_BITS",userPerm.SH_EXCHANGE_CHANGE_BITS);
                cmd.Parameters.AddWithValue("@SH_ADD_EASY_OPEN", userPerm.SH_ADD_EASY_OPEN);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_EASY_OPEN", userPerm.SH_EXCHANGE_EASY_OPEN);
                cmd.Parameters.AddWithValue("@SH_ADD_TIN_CANS", userPerm.SH_ADD_TIN_CANS);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_TIN_CANS", userPerm.SH_EXCHANGE_EASY_OPEN);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_RLT", userPerm.SH_ADD_NEW_RLT);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_RLT", userPerm.SH_EXCHANGE_RLT);
                cmd.Parameters.AddWithValue("@SH_ADD_NEW_BOTTOM", userPerm.SH_ADD_NEW_BOTTOM);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_BOTTOM", userPerm.SH_EXCHANGE_BOTTOM);
                cmd.Parameters.AddWithValue("@SH_DEPARTMENT_MAINTENANCE" , userPerm.SH_DEPARTMENT_MAINTENANCE);
                cmd.ExecuteNonQuery();
              
                MessageBox.Show("تم التسجيل بجاح");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in" + ex.Message);
            }

        }
        void deleteRedundantuserPermRow(long sp_id)
        {
            DatabaseConnection conn = new DatabaseConnection();
            try
            {

                string query = "delete from SH_USER_PERMISIONS where SH_EMP_ID=@id";
               
                conn.openConnection();
                SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                comm.Parameters.AddWithValue("@id", sp_id);
                comm.ExecuteNonQuery();
            
                conn.closeConnection();

            }

            catch (Exception ex)
            {
                MessageBox.Show("error in deletting row from userPermion table" + ex.ToString());
               
            }
        }
        private void save_btn_click(object sender, EventArgs e)
        {
            loadUserPermisions();
        long sp_id= checkUserPermionEmpID();

            if (sp_id == 0)
            {
               
                saveUserPermisions();
            }
            else
            {
                deleteRedundantuserPermRow(sp_id);
                saveUserPermisions();



            }


        }

        private void updateUserPermissionsFrm_Load(object sender, EventArgs e)
        {
            account_username_text_box.Text = acc.SH_EMP_USER_NAME;
        }

    

       
       

        private void checkBoxHr_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBoxIT_Click(object sender, EventArgs e)
        {
            
        }

     

        private void checkBoxSales_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBoxFinanials_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBoxSecratary_Click(object sender, EventArgs e)
        {
          
        }

        private void checkBoxStores_Click(object sender, EventArgs e)
        {
        
        }

        private void checkBoxProduction_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBoxAdmin_Click(object sender, EventArgs e)
        {
            //checkBoxHr.Visible = false;
            //checkBoxFinanials.Visible = false;
            //checkBoxIT.Visible = false;
            //checkBoxProduction.Visible = false;
            //checkBoxPurch.Visible = false;
            //checkBoxSales.Visible = false;
            //checkBoxSecratary.Visible = false;
            //checkBoxStores.Visible = false;
            //buttonStores.Visible = false;
            //buttonHR.Visible = false;
            //buttonIT.Visible = false;
            //buttonSales.Visible = false;
            //buttonSecr.Visible = false;
            //buttonPurshs.Visible = false;
            //buttonFinanials.Visible = false;
            //buttonProduction.Visible = false;

        }

       
        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAdmin.Checked)
            {
                checkBoxHr.Checked = true;
                checkBoxFinanials.Checked = true;
                checkBoxIT.Checked = true;
                checkBoxProduction.Checked = true;
                checkBoxPurch.Checked = true;
                checkBoxSales.Checked = true;
                checkBoxSecratary.Checked = true;
                checkBoxStores.Checked = true;
                work_shop_check_box.Checked = true;

                userPerm.SH_OPEN_CHANGE_PASSWORD = 1;
                userPerm.SH_OPEN_DASH_BOARD = 1;
                userPerm.SH_OPEN_DISPLAY_ALLUSERS = 1;
                userPerm.SH_OPEN_MAKE_NEW_USER = 1;            
                userPerm.SH_OPEN_SELECT_USER_PERMISION = 1;
              
                userPerm.SH_DEPARTMENT_STOCKS = 1;
                userPerm.SH_DEPARTMENT_SALES = 1;
                userPerm.SH_DEPARTMENT_HR = 1;
                userPerm.SH_DEPARTMENT_PURCHASING = 1;
                userPerm.SH_DEPARTMENT_SECRETARY = 1;
                userPerm.SH_DEPARTMENT_ACCOUNTING = 1;
                userPerm.SH_DEPARTMENT_IT = 1;
                userPerm.SH_DEPARTMENT_PRODUCTION = 1;
                userPerm.SH_DEPARTMENT_MAINTENANCE = 1;
                userPerm.SH_DEPARTMENT_MAINTENANCE = 1;






            }
            else
            {
                checkBoxHr.Checked = false;
                checkBoxFinanials.Checked = false;
                checkBoxIT.Checked = false;
                checkBoxProduction.Checked = false;
                checkBoxPurch.Checked = false;
                checkBoxSales.Checked = false;
                checkBoxSecratary.Checked = false;
                checkBoxStores.Checked = false;
                work_shop_check_box.Checked = false;

                userPerm.SH_OPEN_CHANGE_PASSWORD = 0;
                userPerm.SH_OPEN_DASH_BOARD = 0;
                userPerm.SH_OPEN_DISPLAY_ALLUSERS = 0;
                userPerm.SH_OPEN_MAKE_NEW_USER = 0;
                userPerm.SH_OPEN_SELECT_USER_PERMISION = 0;

                userPerm.SH_DEPARTMENT_STOCKS = 0;
                userPerm.SH_DEPARTMENT_SALES = 0;
                userPerm.SH_DEPARTMENT_HR = 0;
                userPerm.SH_DEPARTMENT_PURCHASING = 0;
                userPerm.SH_DEPARTMENT_MAINTENANCE = 0;
                userPerm.SH_DEPARTMENT_SECRETARY = 0;
                userPerm.SH_DEPARTMENT_ACCOUNTING = 0;
                userPerm.SH_DEPARTMENT_IT = 0;
                userPerm.SH_DEPARTMENT_PRODUCTION = 0;
                userPerm.SH_DEPARTMENT_MAINTENANCE = 0;



            }
        }





        private void checkBoxPurch_Click_1(object sender, EventArgs e)
        {
        }


        private void buttonIT_Click(object sender, EventArgs e)
        {
            checkBoxIT.Visible = false;
        }

        private void checkBoxIT_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIT.Checked)
            {

                Server_settings_checkBox.Checked = true;
                addNewAccounts_checkBox.Checked = true;
                ShowAllAccounts_checkBox.Checked = true;
                
                it_gbox.Enabled = false;
                userPerm.SH_DEPARTMENT_IT = 1;
                 
            }else
            {
                Server_settings_checkBox.Checked = false;
                addNewAccounts_checkBox.Checked = false;
                ShowAllAccounts_checkBox.Checked = false;
                it_gbox.Enabled = true;
                userPerm.SH_DEPARTMENT_IT = 0;
            }
        }

        private void checkBoxHr_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHr.Checked)
            {
                addnewemployee_check_box.Checked = true;
                addnew_department_check_box.Checked = true;
                addnew_function_check_box.Checked = true;
                show_all_employees_check_box.Checked = true;
                hr_gbox.Enabled = false;
                userPerm.SH_DEPARTMENT_HR = 1;

            }
            else
            {
                addnewemployee_check_box.Checked = false;
                addnew_department_check_box.Checked = false;
                addnew_function_check_box.Checked = false;
                show_all_employees_check_box.Checked = false;
                hr_gbox.Enabled = true;
                userPerm.SH_DEPARTMENT_HR = 0;
            }
        }

        private void checkBoxPurch_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPurch.Checked)
            {
                addnewsuppliers_check_box.Checked = true;
                addnewsuppliers_branches_check_box.Checked = true;
                show_all_suppliers_check_box.Checked = true;

                purchasing_gbox.Enabled = false;

                userPerm.SH_DEPARTMENT_PURCHASING = 1;
            }
            else
            {

                addnewsuppliers_check_box.Checked = false;
                addnewsuppliers_branches_check_box.Checked = false;
                show_all_suppliers_check_box.Checked = false;
                purchasing_gbox.Enabled = true;
                userPerm.SH_DEPARTMENT_PURCHASING = 0;
            }
        }

        private void checkBoxSales_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSales.Checked)
            {
                add_new_client_check_box.Checked = true;
                add_new_client_branches_check_box.Checked = true;
                add_client_products_check_box.Checked = true;
                add_new_size_check_box.Checked = true;
                addnew_colors_check_box.Checked = true;
                show_all_clients_check_box.Checked = true;
                sales_gbox.Enabled = false;
                userPerm.SH_DEPARTMENT_SALES = 1;
            }
            else
            {
                add_new_client_check_box.Checked = false;
                add_new_client_branches_check_box.Checked = false;
                add_client_products_check_box.Checked = false;
                add_new_size_check_box.Checked = false;
                addnew_colors_check_box.Checked = false;
                show_all_clients_check_box.Checked = false;
                sales_gbox.Enabled = true;
                userPerm.SH_DEPARTMENT_SALES = 0;
            }
        }

        private void checkBoxStores_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStores.Checked)
            {
                add_new_raw_material_check_box.Checked = true;
                addCansOfTin_checkBox.Checked = true;
                ExchangeTinMaterial_checkBox.Checked = true;
                exchangtincan_check_box.Checked = true;
                checkBoxAddProductionRequirment.Checked = true;
                add_new_stock.Checked = true;
                addNewMuranTin_checkBox.Checked = true;
                addEasyOpen_checkBox.Checked = true;
                exchange_muran_tin_check_box.Checked = true;
                exchange_easy_open_check_box.Checked = true;
                checkBoxExchangeProductionRequirment.Checked = true;
                show_all_stocks.Checked = true;
                addPrintedTin_checkBox.Checked = true;
                AddRLT_checkBox.Checked = true;
                exchange_printed_tin.Checked = true;
                exchange_rlt_check_box.Checked = true;
                checkBoxAddChangeBits.Checked = true;
                addCutTin_checkBox.Checked = true;
                addNewButtom_checkBox.Checked = true;
                exchange_cut_tin.Checked = true;
                exchange_bottom_check_box.Checked = true;
                checkBoxExchangeChangeBits.Checked = true;

                stocks_gbox.Enabled = false;
                userPerm.SH_DEPARTMENT_STOCKS = 1;
                userPerm.SH_MAIN_TIN_STOCK = 1;

            }
            else
            {

                add_new_raw_material_check_box.Checked = false;
                addCansOfTin_checkBox.Checked = false;
                ExchangeTinMaterial_checkBox.Checked = false;
                exchangtincan_check_box.Checked = false;
                checkBoxAddProductionRequirment.Checked = false;
                add_new_stock.Checked = false;
                addNewMuranTin_checkBox.Checked = false;
                addEasyOpen_checkBox.Checked = false;
                exchange_muran_tin_check_box.Checked = false;
                exchange_easy_open_check_box.Checked = false;
                checkBoxExchangeProductionRequirment.Checked = false;
                show_all_stocks.Checked = false;
                addPrintedTin_checkBox.Checked = false;
                AddRLT_checkBox.Checked = false;
                exchange_printed_tin.Checked = false;
                exchange_rlt_check_box.Checked = false;
                checkBoxAddChangeBits.Checked = false;
                addCutTin_checkBox.Checked = false;
                addNewButtom_checkBox.Checked = false;
                exchange_cut_tin.Checked = false;
                exchange_bottom_check_box.Checked = false;
                checkBoxExchangeChangeBits.Checked = false;


                stocks_gbox.Enabled = true;
                userPerm.SH_DEPARTMENT_STOCKS = 0;
                userPerm.SH_MAIN_TIN_STOCK = 0;
            }
        }

        private void checkBoxProduction_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxProduction.Checked)
            {

                add_new_cutter_check_box.Checked = true;
                show_all_cutters_check_box.Checked = true;




                production_gbox.Enabled = false;
                userPerm.SH_DEPARTMENT_PRODUCTION = 1;



            }
            else
            {

                add_new_cutter_check_box.Checked = false;
                show_all_cutters_check_box.Checked = false;


                production_gbox.Enabled = true;
                userPerm.SH_DEPARTMENT_PRODUCTION = 0;
            }
        }

        private void Server_settings_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (Server_settings_checkBox.Checked)
            {
                userPerm.SH_IT_SERVER_SETTINGS = 1;

            }else
            {
                userPerm.SH_IT_SERVER_SETTINGS = 0;
            }
        }

        private void addNewAccounts_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (addNewAccounts_checkBox.Checked)
            {
                userPerm.SH_OPEN_MAKE_NEW_USER = 1;
            }else
            {
                userPerm.SH_OPEN_MAKE_NEW_USER = 0;
            }
        }

        private void ShowAllAccounts_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowAllAccounts_checkBox.Checked)
            {
                userPerm.SH_OPEN_DISPLAY_ALLUSERS = 1;
            }else
            {
                userPerm.SH_OPEN_DISPLAY_ALLUSERS = 0;
            }
        }

        private void addnewemployee_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (addnewemployee_check_box.Checked)
            {
                userPerm.SH_OPEN_REGIST_EMP = 1;
            }else
            {
                userPerm.SH_OPEN_REGIST_EMP = 0;
            }
        }

        private void addnew_department_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (addnew_department_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_DEPARTMENT = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_DEPARTMENT = 0;
            }
        }

        private void addnew_function_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (addnew_function_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_JOB = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_JOB = 0;
            }
        }

        private void addnewsuppliers_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (addnewsuppliers_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_SUPPLIER = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_SUPPLIER = 0;
            }
        }

        private void addnewsuppliers_branches_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (addnewsuppliers_branches_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_SUPPLIER_BRANCH = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_SUPPLIER_BRANCH = 0;
            }
        }

        private void add_new_client_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (add_new_client_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_CLIENT_COMPANY = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_CLIENT_COMPANY = 0;
            }

        }

        private void add_new_client_branches_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (add_new_client_branches_check_box.Checked)
            {
              userPerm.SH_ADD_NEW_CLIENT_BRANCH = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_CLIENT_BRANCH = 0;
            }
        }

        private void add_client_products_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (add_client_products_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_PRODUCT_CLIENT = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_PRODUCT_CLIENT = 0;
            }
        }

        private void add_new_size_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (add_new_size_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_SIZE = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_SIZE = 0;
            }
        }

        private void addnew_colors_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (addnew_colors_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_COLOR = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_COLOR = 0;
            }
        }

        private void add_new_raw_material_check_box_CheckedChanged(object sender, EventArgs e)
        {
          

                  if (add_new_raw_material_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_RAW_TIN = 1;
                userPerm.SH_ADD_NEW_RAW_TIN_FIRST_DURATION = 1;
                userPerm.SH_RAW_TIN_MATERIAL = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_RAW_TIN = 0;
                userPerm.SH_ADD_NEW_RAW_TIN_FIRST_DURATION = 0;
                userPerm.SH_RAW_TIN_MATERIAL = 0;
            }
        }

        private void checkBoxAddProductionRequirment_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddProductionRequirment.Checked)
            {
                userPerm.SH_ADD_PRODUCTION_REQUIRMENT = 1;
            }
            else
            {
                userPerm.SH_ADD_PRODUCTION_REQUIRMENT = 0;
            }
        }

        private void checkBoxExchangeProductionRequirment_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxExchangeProductionRequirment.Checked)
            {
                userPerm.SH_EXCHANGE_PRODUCTION_REQUIRMENT = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_PRODUCTION_REQUIRMENT = 0;
            }
        }

        private void checkBoxAddChangeBits_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddChangeBits.Checked)
            {
                userPerm.SH_ADD_CHANGE_BITS = 1;
            }
            else
            {
                userPerm.SH_ADD_CHANGE_BITS = 0;
            }

        }

        private void checkBoxExchangeChangeBits_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxExchangeChangeBits.Checked)
            {
                userPerm.SH_EXCHANGE_CHANGE_BITS = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_CHANGE_BITS = 0;
            }
        }

        private void exchange_easy_open_check_box_CheckedChanged(object sender, EventArgs e)
        {
          

                 if (exchange_easy_open_check_box.Checked)
            {
                userPerm.SH_EXCHANGE_EASY_OPEN = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_EASY_OPEN = 0;
            }

        }

        private void addEasyOpen_checkBox_CheckedChanged(object sender, EventArgs e)
        {
           

                 if (addEasyOpen_checkBox.Checked)
            {
                userPerm.SH_ADD_EASY_OPEN = 1;
            }
            else
            {
                userPerm.SH_ADD_EASY_OPEN = 0;
            }
        }

        private void addCansOfTin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
          
          if (addCansOfTin_checkBox.Checked)
            {
                userPerm.SH_ADD_TIN_CANS = 1;
            }
            else
            {
                userPerm.SH_ADD_TIN_CANS = 0;
            }
        }

        private void exchangtincan_check_box_CheckedChanged(object sender, EventArgs e)
        {
           

                 if (exchangtincan_check_box.Checked)
            {
                userPerm.SH_EXCHANGE_TIN_CANS = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_TIN_CANS = 0;
            }
        }

        private void ExchangeTinMaterial_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            

                     if (ExchangeTinMaterial_checkBox.Checked)
            {
                userPerm.SH_EXCHANGE_RAW_TIN_PROPERTIES = 1;
                userPerm.SH_EXCHANGE_RAW_TIN_PARCEL_NO = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_RAW_TIN_PROPERTIES = 0;
                userPerm.SH_EXCHANGE_RAW_TIN_PARCEL_NO = 0;
            }
        }

        private void addNewMuranTin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (addNewMuranTin_checkBox.Checked)
            {
                userPerm.SH_ADD_NEW_MURAN_TIN = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_MURAN_TIN = 0;
            }
        }

        private void exchange_muran_tin_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (exchange_muran_tin_check_box.Checked)
            {
                userPerm.SH_EXCHANGE_MURAN_TIN = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_MURAN_TIN = 0;
            }
        }

        private void addPrintedTin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (addPrintedTin_checkBox.Checked)
            {
                userPerm.SH_ADD_NEW_PRINTED_TIN = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_PRINTED_TIN = 0;
            }
        }

        private void AddRLT_checkBox_CheckedChanged(object sender, EventArgs e)
        {
          


                 if (AddRLT_checkBox.Checked)
            {
                userPerm.SH_ADD_NEW_RLT = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_RLT = 0;
            }
        }

        private void exchange_printed_tin_CheckedChanged(object sender, EventArgs e)
        {
         
            if (exchange_printed_tin.Checked)
            {
                userPerm.SH_EXCHANGE_PRINTED_TIN = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_PRINTED_TIN = 0;
            }
        }

        private void exchange_rlt_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (exchange_rlt_check_box.Checked)
            {
                userPerm.SH_EXCHANGE_RLT = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_RLT = 0;
            }
        }

        private void addCutTin_checkBox_CheckedChanged(object sender, EventArgs e)
        {
           
                 if (addCutTin_checkBox.Checked)
            {
                userPerm.SH_ADD_NEW_CUT_RAW_TIN = 1;
                userPerm.SH_ADD_NEW_CUT_MURAN_TIN = 1;
                userPerm.SH_ADD_NEW_CUT_PRINTED_TIN = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_CUT_MURAN_TIN = 0;
                userPerm.SH_ADD_NEW_CUT_RAW_TIN = 0;
                userPerm.SH_ADD_NEW_CUT_PRINTED_TIN = 0;
            }
        }

        private void addNewButtom_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (addNewButtom_checkBox.Checked)
            {

                userPerm.SH_ADD_NEW_BOTTOM = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_BOTTOM = 0;
            }
        }

        private void exchange_cut_tin_CheckedChanged(object sender, EventArgs e)
        {
            if (exchange_cut_tin.Checked)
            {

                userPerm.SH_EXCHANGE_CUT_RAW_TIN = 1;
                userPerm.SH_EXCHANGE_CUT_MURAN_TIN = 1;
                userPerm.SH_EXCHANGE_CUT_PRINTED_TIN = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_BOTTOM = 0;
                userPerm.SH_EXCHANGE_CUT_MURAN_TIN = 0;
                userPerm.SH_EXCHANGE_CUT_PRINTED_TIN = 0;
            }
        }

        private void exchange_bottom_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (exchange_bottom_check_box.Checked)
            {
                userPerm.SH_EXCHANGE_BOTTOM = 1;
            }
            else
            {
                userPerm.SH_EXCHANGE_BOTTOM = 0;
            }
        }

        private void add_new_cutter_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (add_new_cutter_check_box.Checked)
            {
                userPerm.SH_ADD_NEW_CUTTERS = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_CUTTERS = 0;
            }
        }

        private void show_all_cutters_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_cutters_check_box.Checked)
            {
                userPerm.SH_SHOW_ALL_CUTTERS = 1;
            }
            else
            {
                userPerm.SH_SHOW_ALL_CUTTERS = 0;
            }
        }

        private void checkBoxSecratary_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_cutters_check_box.Checked)
            {
                userPerm.SH_SHOW_ALL_CUTTERS = 1;
            }
            else
            {
                userPerm.SH_SHOW_ALL_CUTTERS = 0;
            }
        }

        private void checkBoxFinanials_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxFinanials.Checked)
            {
                userPerm.SH_DEPARTMENT_ACCOUNTING = 1;
            }else
            {
                userPerm.SH_DEPARTMENT_ACCOUNTING = 0;
            }
        }

        private void add_new_stock_CheckedChanged(object sender, EventArgs e)
        {
            if (add_new_stock.Checked)
            {
                userPerm.SH_ADD_NEW_STOCK_PLACE = 1;
            }
            else
            {
                userPerm.SH_ADD_NEW_STOCK_PLACE = 0;
            }
        }

        private void show_all_stocks_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_stocks.Checked)
            {
                userPerm.SH_SHOW_ALL_STOCKS = 1;
            }
            else
            {
                userPerm.SH_SHOW_ALL_STOCKS = 0;
            }
        }

        private void show_all_clients_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_clients_check_box.Checked)
            {
                userPerm.SH_SHOW_ALL_CLIENTS = 1;
            }else
            {
                userPerm.SH_SHOW_ALL_CLIENTS = 0;

            }
        }

        private void show_all_employees_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_employees_check_box.Checked)
            {
                userPerm.SH_OPEN_GETALL_EMP = 1;
            }else
            {
                userPerm.SH_OPEN_GETALL_EMP = 0;
            }
        }

        private void stocks_gbox_Enter(object sender, EventArgs e)
        {

        }

        private void show_all_suppliers_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (show_all_suppliers_check_box.Checked)
            {
                userPerm.SH_SHOW_ALL_SUPPLIERS = 1;

            }else
            {
                userPerm.SH_SHOW_ALL_SUPPLIERS = 0;
            }
        }

        private void work_shop_check_box_CheckedChanged(object sender, EventArgs e)
        {
            if (work_shop_check_box.Checked)
            {
                userPerm.SH_DEPARTMENT_MAINTENANCE = 1;
            } else
            {
                userPerm.SH_DEPARTMENT_MAINTENANCE = 0;
            }
        }
    }
    }
    

