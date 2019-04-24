using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Al_Shaheen_System
{
    public partial class LoginFrm : Form
    {
        SH_EMPLOYEES shemp = new SH_EMPLOYEES();
        SH_USER_PERMISIONS shuserPerm = new SH_USER_PERMISIONS();
        SH_USER_ACCOUNTS account = new SH_USER_ACCOUNTS();

        public LoginFrm()
        {
            InitializeComponent();
       

        }

        public void getEmployeeData()
        {
            DatabaseConnection myconnection = new DatabaseConnection();
            myconnection.openConnection();
             SqlCommand com = new SqlCommand("getoneEmp", DatabaseConnection.mConnection);
           com.CommandType = CommandType.StoredProcedure;
           com.Parameters.AddWithValue("@empID", account.SH_EMP_ID);
            SqlDataReader rd1 = com.ExecuteReader();
            if (rd1.Read())
            {
                shemp.SH_EMPLOYEE_ADDRESS = rd1["SH_EMPLOYEE_ADDRESS"].ToString();
                shemp.SH_EMPLOYEMENT_DATE = DateTime.Parse(rd1["SH_EMPLOYEMENT_DATE"].ToString());
                shemp.SH_EMPLOYEE_EMAIL = rd1["SH_EMPLOYEE_EMAIL"].ToString();
                shemp.SH_EMPLOYEE_GENDER = rd1["SH_EMPLOYEE_GENDER"].ToString();
                shemp.SH_ID = long.Parse(rd1["SH_ID"].ToString());
                shemp.SH_EMPLOYEE_NAME = rd1["SH_EMPLOYEE_NAME"].ToString();
                shemp.SH_EMPLOYEE_NATIONAL_ID = rd1["SH_EMPLOYEE_NATIONAL_ID"].ToString();     
            }
            myconnection.closeConnection();

        }

        public void getUserPermission()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                 SqlCommand com2 = new SqlCommand("getpermissionOneEmp", DatabaseConnection.mConnection);
                com2.CommandType = CommandType.StoredProcedure;
               // problem
                 com2.Parameters.AddWithValue("@empid", shemp.SH_ID);
                SqlDataReader red = com2.ExecuteReader();
                if (red.Read())
                {
                    shuserPerm.SH_ID = long.Parse(red["SH_ID"].ToString());
                    shuserPerm.SH_ADD_NEW_COLOR = long.Parse(red["SH_ADD_NEW_COLOR"].ToString());
                    shuserPerm.SH_OPEN_CHANGE_PASSWORD = long.Parse(red["SH_OPEN_CHANGE_PASSWORD"].ToString());
                    shuserPerm.SH_OPEN_GETALL_EMP = long.Parse(red["SH_OPEN_REGIST_EMP"].ToString());
                    shuserPerm.SH_OPEN_MAKE_NEW_USER = long.Parse(red["SH_OPEN_MAKE_NEW_USER"].ToString());
                    shuserPerm.SH_OPEN_DISPLAY_ALLUSERS = long.Parse(red["SH_OPEN_DISPLAY_ALLUSERS"].ToString());
                    shuserPerm.SH_OPEN_SELECT_USER_PERMISION = long.Parse(red["SH_OPEN_SELECT_USER_PERMISION"].ToString());
                    shuserPerm.SH_RAW_TIN_MATERIAL = long.Parse(red["SH_RAW_TIN_MATERIAL"].ToString());
                    shuserPerm.SH_EMP_ID = long.Parse(red["SH_EMP_ID"].ToString());
                    shuserPerm.SH_EMP_NAME = red["SH_EMP_NAME"].ToString();
                    shuserPerm.SH_SHOW_ALL_CLIENTS = long.Parse(red["SH_SHOW_ALL_CLIENTS"].ToString());
                    shuserPerm.SH_OPEN_DASH_BOARD = long.Parse(red["SH_OPEN_DASH_BOARD"].ToString());
                    shuserPerm.SH_OPEN_REGIST_EMP = long.Parse(red["SH_OPEN_REGIST_EMP"].ToString());
                    shuserPerm.SH_ADD_NEW_CLIENT_COMPANY = long.Parse(red["SH_ADD_NEW_CLIENT_COMPANY"].ToString());
                    shuserPerm.SH_ADD_NEW_CLIENT_BRANCH = long.Parse(red["SH_ADD_NEW_CLIENT_BRANCH"].ToString());
                    shuserPerm.SH_ADD_NEW_SUPPLIER = long.Parse(red["SH_ADD_NEW_SUPPLIER"].ToString());
                    shuserPerm.SH_ADD_NEW_SUPPLIER_BRANCH = long.Parse(red["SH_ADD_NEW_SUPPLIER_BRANCH"].ToString());
                    shuserPerm.SH_SHOW_ALL_SUPPLIERS = long.Parse(red["SH_SHOW_ALL_SUPPLIERS"].ToString());
                    shuserPerm.SH_MAIN_TIN_STOCK = long.Parse(red["SH_MAIN_TIN_STOCK"].ToString());
                    shuserPerm.SH_ADD_NEW_RAW_TIN_FIRST_DURATION = long.Parse(red["SH_ADD_NEW_RAW_TIN_FIRST_DURATION"].ToString());
                    shuserPerm.SH_ADD_NEW_RAW_TIN = long.Parse(red["SH_ADD_NEW_RAW_TIN"].ToString());
                    shuserPerm.SH_EXCHANGE_RAW_TIN_PARCEL_NO = long.Parse(red["SH_EXCHANGE_RAW_TIN_PARCEL_NO"].ToString());
                    shuserPerm.SH_EXCHANGE_RAW_TIN_PROPERTIES = long.Parse(red["SH_EXCHANGE_RAW_TIN_PROPERTIES"].ToString());
                    shuserPerm.SH_EXCHANGE_MURAN_TIN = long.Parse(red["SH_EXCHANGE_MURAN_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_MURAN_TIN = long.Parse(red["SH_ADD_NEW_MURAN_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_PRINTED_TIN = long.Parse(red["SH_ADD_NEW_PRINTED_TIN"].ToString());
                    shuserPerm.SH_EXCHANGE_PRINTED_TIN = long.Parse(red["SH_EXCHANGE_PRINTED_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_SIZE = long.Parse(red["SH_ADD_NEW_SIZE"].ToString());
                    shuserPerm.SH_ADD_NEW_CUT_RAW_TIN = long.Parse(red["SH_ADD_NEW_CUT_RAW_TIN"].ToString());
                    shuserPerm.SH_EXCHANGE_CUT_RAW_TIN = long.Parse(red["SH_EXCHANGE_CUT_RAW_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_CUT_MURAN_TIN = long.Parse(red["SH_ADD_NEW_CUT_MURAN_TIN"].ToString());
                    shuserPerm.SH_EXCHANGE_CUT_MURAN_TIN = long.Parse(red["SH_EXCHANGE_CUT_MURAN_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_CUTTERS = long.Parse(red["SH_ADD_NEW_CUTTERS"].ToString());
                    shuserPerm.SH_SHOW_ALL_CUTTERS = long.Parse(red["SH_SHOW_ALL_CUTTERS"].ToString());
                    shuserPerm.SH_DEPARTMENT_PRODUCTION = long.Parse(red["SH_DEPARTMENT_PRODUCTION"].ToString());
                    shuserPerm.SH_ADD_NEW_STOCK_PLACE = long.Parse(red["SH_ADD_NEW_STOCK_PLACE"].ToString());
                    shuserPerm.SH_SHOW_ALL_STOCKS = long.Parse(red["SH_SHOW_ALL_STOCKS"].ToString());
                    shuserPerm.SH_DEPARTMENT_STOCKS = long.Parse(red["SH_DEPARTMENT_STOCKS"].ToString());
                    shuserPerm.SH_DEPARTMENT_SALES = long.Parse(red["SH_DEPARTMENT_SALES"].ToString());
                    shuserPerm.SH_DEPARTMENT_HR = long.Parse(red["SH_DEPARTMENT_HR"].ToString());
                    shuserPerm.SH_DEPARTMENT_PURCHASING = long.Parse(red["SH_DEPARTMENT_PURCHASING"].ToString());
                    shuserPerm.SH_DEPARTMENT_SECRETARY = long.Parse(red["SH_DEPARTMENT_SECRETARY"].ToString());
                    shuserPerm.SH_DEPARTMENT_ACCOUNTING = long.Parse(red["SH_DEPARTMENT_ACCOUNTING"].ToString());
                    shuserPerm.SH_DEPARTMENT_IT = long.Parse(red["SH_DEPARTMENT_IT"].ToString());
                    shuserPerm.SH_IT_SERVER_SETTINGS = long.Parse(red["SH_IT_SERVER_SETTINGS"].ToString());
                    shuserPerm.SH_EXCHANGE_CHANGE_BITS = long.Parse(red["SH_EXCHANGE_CHANGE_BITS"].ToString());
                    shuserPerm.SH_ADD_NEW_DEPARTMENT = long.Parse(red["SH_ADD_NEW_DEPARTMENT"].ToString());
                    shuserPerm.SH_ADD_NEW_JOB = long.Parse(red["SH_ADD_NEW_JOB"].ToString());
                    shuserPerm.SH_ADD_NEW_PRODUCT_CLIENT = long.Parse(red["SH_ADD_NEW_PRODUCT_CLIENT"].ToString());
                    shuserPerm.SH_ADD_PRODUCTION_REQUIRMENT = long.Parse(red["SH_ADD_PRODUCTION_REQUIRMENT"].ToString());
                    shuserPerm.SH_EXCHANGE_PRODUCTION_REQUIRMENT = long.Parse(red["SH_EXCHANGE_PRODUCTION_REQUIRMENT"].ToString());
                    shuserPerm.SH_ADD_CHANGE_BITS = long.Parse(red["SH_ADD_CHANGE_BITS"].ToString());
                    shuserPerm.SH_ADD_EASY_OPEN = long.Parse(red["SH_ADD_EASY_OPEN"].ToString());
                    shuserPerm.SH_EXCHANGE_EASY_OPEN = long.Parse(red["SH_EXCHANGE_EASY_OPEN"].ToString());
                    shuserPerm.SH_ADD_TIN_CANS = long.Parse(red["SH_ADD_TIN_CANS"].ToString());
                    shuserPerm.SH_EXCHANGE_TIN_CANS = long.Parse(red["SH_EXCHANGE_TIN_CANS"].ToString());
                    shuserPerm.SH_ADD_NEW_RLT = long.Parse(red["SH_ADD_NEW_RLT"].ToString());
                    shuserPerm.SH_EXCHANGE_RLT = long.Parse(red["SH_EXCHANGE_RLT"].ToString());
                    shuserPerm.SH_ADD_NEW_CUT_RAW_TIN = long.Parse(red["SH_ADD_NEW_CUT_RAW_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_CUT_PRINTED_TIN = long.Parse(red["SH_ADD_NEW_CUT_PRINTED_TIN"].ToString());
                    shuserPerm.SH_EXCHANGE_CUT_PRINTED_TIN = long.Parse(red["SH_EXCHANGE_CUT_PRINTED_TIN"].ToString());
                    shuserPerm.SH_ADD_NEW_BOTTOM = long.Parse(red["SH_ADD_NEW_BOTTOM"].ToString());
                    shuserPerm.SH_EXCHANGE_BOTTOM = long.Parse(red["SH_EXCHANGE_BOTTOM"].ToString());
                    shuserPerm.SH_DEPARTMENT_MAINTENANCE = long.Parse(red["SH_DEPARTMENT_MAINTENANCE"].ToString());
                }
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIE GETTING USER PERMISSION " + ex.ToString());
            }

        }

        void checkforloginning()
        {
            if (string.IsNullOrEmpty(txtUserName.Text ) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("خطأ في كلمه السر او اسم المستخدم" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                //if (string.Compare(txtUserName.Text, "admin") == 0 && string.Compare(txtPassword.Text, "admin123456") == 0)
                //{
                //    this.Hide();
                //    Mainform forms = new Mainform(shemp, account, shuserPerm);
                //    forms.ShowDialog();
                //    this.Close();
                //}
                //else
                //{

                    try
                    {

                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand comm = new SqlCommand("loginfrm", DatabaseConnection.mConnection);
                        comm.CommandType = CommandType.StoredProcedure;

                        comm.Parameters.AddWithValue("@user_name", txtUserName.Text);
                        comm.Parameters.AddWithValue("@user_pass", txtPassword.Text);
                        SqlDataReader rd = comm.ExecuteReader();
                        bool f_data = false;
                        while (rd.Read())
                        {
                            f_data = true;
                            account.SH_EMP_ID = long.Parse(rd["SH_EMP_ID"].ToString());
                            account.SH_EMP_NAME = rd["SH_EMP_NAME"].ToString();
                            account.SH_ID = long.Parse(rd["SH_ID"].ToString());
                            account.SH_EMP_PASSWORD = rd["SH_EMP_PASSWORD"].ToString();
                            account.SH_CREATION_DATE = DateTime.Parse(rd["SH_CREATION_DATE"].ToString());
                            account.SH_EMP_USER_NAME = rd["SH_EMP_USER_NAME"].ToString();
                        }
                        myconnection.closeConnection();

                        if (f_data)
                        {
                            getEmployeeData();
                            getUserPermission();
                          //  MessageBox.Show("logged");
                             this.Hide();
                        //    MessageBox.Show(shemp.SH_EMPLOYEE_NAME);
                            Mainform forms = new Mainform(shemp, account, shuserPerm);

                            forms.ShowDialog();
                        this.Close();
                        }
                        else
                        {
                            MessageBox.Show("خطأ في كلمه السر او اسم المستخدم");
                        }

                   // myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
       // }
        }


        private void bttnLogin_Click(object sender, EventArgs e)
        {
            checkforloginning();
           
        }
       
   

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void server_configuration_btn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (DatabaseConnectionSettingForm myform = new DatabaseConnectionSettingForm())
            {
                myform.ShowDialog();
            }
        }
    }
}
