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
        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_PERMISIONS mPermission= new SH_USER_PERMISIONS();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();

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
           com.Parameters.AddWithValue("@empID", mAccount.SH_EMP_ID);
            SqlDataReader rd1 = com.ExecuteReader();
            if (rd1.Read())
            {
              mEmployee.SH_EMPLOYEE_ADDRESS = rd1["SH_EMPLOYEE_ADDRESS"].ToString();
                mEmployee.SH_EMPLOYEMENT_DATE = DateTime.Parse(rd1["SH_EMPLOYEMENT_DATE"].ToString());
                mEmployee.SH_EMPLOYEE_EMAIL = rd1["SH_EMPLOYEE_EMAIL"].ToString();
                mEmployee.SH_EMPLOYEE_GENDER = rd1["SH_EMPLOYEE_GENDER"].ToString();
                mEmployee.SH_ID = long.Parse(rd1["SH_ID"].ToString());
                mEmployee.SH_EMPLOYEE_NAME = rd1["SH_EMPLOYEE_NAME"].ToString();
                mEmployee.SH_EMPLOYEE_NATIONAL_ID = rd1["SH_EMPLOYEE_NATIONAL_ID"].ToString();     
            }
            rd1.Close();
            myconnection.closeConnection();

        }

        public void getUserPermission()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                 SqlCommand cmd = new SqlCommand("getpermissionOneEmp", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
           
                 cmd.Parameters.AddWithValue("@empid", mAccount.SH_ID);
                SqlDataReader red = cmd.ExecuteReader();
                if (red.Read())
                {
                    mPermission.SH_ID = long.Parse(red["SH_ID"].ToString());
                    mPermission.SH_ADD_NEW_COLOR = long.Parse(red["SH_ADD_NEW_COLOR"].ToString());
                    mPermission.SH_OPEN_CHANGE_PASSWORD = long.Parse(red["SH_OPEN_CHANGE_PASSWORD"].ToString());
                    mPermission.SH_OPEN_GETALL_EMP = long.Parse(red["SH_OPEN_REGIST_EMP"].ToString());
                    mPermission.SH_OPEN_MAKE_NEW_USER = long.Parse(red["SH_OPEN_MAKE_NEW_USER"].ToString());
                    mPermission.SH_OPEN_DISPLAY_ALLUSERS = long.Parse(red["SH_OPEN_DISPLAY_ALLUSERS"].ToString());
                    mPermission.SH_OPEN_SELECT_USER_PERMISION = long.Parse(red["SH_OPEN_SELECT_USER_PERMISION"].ToString());
                    mPermission.SH_RAW_TIN_MATERIAL = long.Parse(red["SH_RAW_TIN_MATERIAL"].ToString());
                    mPermission.SH_ACCOUNT_ID = long.Parse(red["SH_ACCOUNT_ID"].ToString());
                    mPermission.SH_ACCOUNT_NAME = red["SH_ACCOUNT_NAME"].ToString();
                    mPermission.SH_SHOW_ALL_CLIENTS = long.Parse(red["SH_SHOW_ALL_CLIENTS"].ToString());
                    mPermission.SH_OPEN_DASH_BOARD = long.Parse(red["SH_OPEN_DASH_BOARD"].ToString());
                    mPermission.SH_OPEN_REGIST_EMP = long.Parse(red["SH_OPEN_REGIST_EMP"].ToString());
                    mPermission.SH_ADD_NEW_CLIENT_COMPANY = long.Parse(red["SH_ADD_NEW_CLIENT_COMPANY"].ToString());
                    mPermission.SH_ADD_NEW_CLIENT_BRANCH = long.Parse(red["SH_ADD_NEW_CLIENT_BRANCH"].ToString());
                    mPermission.SH_ADD_NEW_SUPPLIER = long.Parse(red["SH_ADD_NEW_SUPPLIER"].ToString());
                    mPermission.SH_ADD_NEW_SUPPLIER_BRANCH = long.Parse(red["SH_ADD_NEW_SUPPLIER_BRANCH"].ToString());
                    mPermission.SH_SHOW_ALL_SUPPLIERS = long.Parse(red["SH_SHOW_ALL_SUPPLIERS"].ToString());
                    mPermission.SH_MAIN_TIN_STOCK = long.Parse(red["SH_MAIN_TIN_STOCK"].ToString());
                    mPermission.SH_ADD_NEW_RAW_TIN_FIRST_DURATION = long.Parse(red["SH_ADD_NEW_RAW_TIN_FIRST_DURATION"].ToString());
                    mPermission.SH_ADD_NEW_RAW_TIN = long.Parse(red["SH_ADD_NEW_RAW_TIN"].ToString());
                    mPermission.SH_EXCHANGE_RAW_TIN_PARCEL_NO = long.Parse(red["SH_EXCHANGE_RAW_TIN_PARCEL_NO"].ToString());
                    mPermission.SH_EXCHANGE_RAW_TIN_PROPERTIES = long.Parse(red["SH_EXCHANGE_RAW_TIN_PROPERTIES"].ToString());
                    mPermission.SH_EXCHANGE_MURAN_TIN = long.Parse(red["SH_EXCHANGE_MURAN_TIN"].ToString());
                    mPermission.SH_ADD_NEW_MURAN_TIN = long.Parse(red["SH_ADD_NEW_MURAN_TIN"].ToString());
                    mPermission.SH_ADD_NEW_PRINTED_TIN = long.Parse(red["SH_ADD_NEW_PRINTED_TIN"].ToString());
                    mPermission.SH_EXCHANGE_PRINTED_TIN = long.Parse(red["SH_EXCHANGE_PRINTED_TIN"].ToString());
                    mPermission.SH_ADD_NEW_SIZE = long.Parse(red["SH_ADD_NEW_SIZE"].ToString());
                    mPermission.SH_ADD_NEW_CUT_RAW_TIN = long.Parse(red["SH_ADD_NEW_CUT_RAW_TIN"].ToString());
                    mPermission.SH_EXCHANGE_CUT_RAW_TIN = long.Parse(red["SH_EXCHANGE_CUT_RAW_TIN"].ToString());
                    mPermission.SH_ADD_NEW_CUT_MURAN_TIN = long.Parse(red["SH_ADD_NEW_CUT_MURAN_TIN"].ToString());
                    mPermission.SH_EXCHANGE_CUT_MURAN_TIN = long.Parse(red["SH_EXCHANGE_CUT_MURAN_TIN"].ToString());
                    mPermission.SH_ADD_NEW_CUTTERS = long.Parse(red["SH_ADD_NEW_CUTTERS"].ToString());
                    mPermission.SH_SHOW_ALL_CUTTERS = long.Parse(red["SH_SHOW_ALL_CUTTERS"].ToString());
                    mPermission.SH_DEPARTMENT_PRODUCTION = long.Parse(red["SH_DEPARTMENT_PRODUCTION"].ToString());
                    mPermission.SH_ADD_NEW_STOCK_PLACE = long.Parse(red["SH_ADD_NEW_STOCK_PLACE"].ToString());
                    mPermission.SH_SHOW_ALL_STOCKS = long.Parse(red["SH_SHOW_ALL_STOCKS"].ToString());
                    mPermission.SH_DEPARTMENT_STOCKS = long.Parse(red["SH_DEPARTMENT_STOCKS"].ToString());
                    mPermission.SH_DEPARTMENT_SALES = long.Parse(red["SH_DEPARTMENT_SALES"].ToString());
                    mPermission.SH_DEPARTMENT_HR = long.Parse(red["SH_DEPARTMENT_HR"].ToString());
                    mPermission.SH_DEPARTMENT_PURCHASING = long.Parse(red["SH_DEPARTMENT_PURCHASING"].ToString());
                    mPermission.SH_DEPARTMENT_SECRETARY = long.Parse(red["SH_DEPARTMENT_SECRETARY"].ToString());
                    mPermission.SH_DEPARTMENT_ACCOUNTING = long.Parse(red["SH_DEPARTMENT_ACCOUNTING"].ToString());
                    mPermission.SH_DEPARTMENT_IT = long.Parse(red["SH_DEPARTMENT_IT"].ToString());
                    mPermission.SH_IT_SERVER_SETTINGS = long.Parse(red["SH_IT_SERVER_SETTINGS"].ToString());
                    mPermission.SH_EXCHANGE_CHANGE_BITS = long.Parse(red["SH_EXCHANGE_CHANGE_BITS"].ToString());
                    mPermission.SH_ADD_NEW_DEPARTMENT = long.Parse(red["SH_ADD_NEW_DEPARTMENT"].ToString());
                    mPermission.SH_ADD_NEW_JOB = long.Parse(red["SH_ADD_NEW_JOB"].ToString());
                    mPermission.SH_ADD_NEW_PRODUCT_CLIENT = long.Parse(red["SH_ADD_NEW_PRODUCT_CLIENT"].ToString());
                    mPermission.SH_ADD_PRODUCTION_REQUIRMENT = long.Parse(red["SH_ADD_PRODUCTION_REQUIRMENT"].ToString());
                    mPermission.SH_EXCHANGE_PRODUCTION_REQUIRMENT = long.Parse(red["SH_EXCHANGE_PRODUCTION_REQUIRMENT"].ToString());
                    mPermission.SH_ADD_CHANGE_BITS = long.Parse(red["SH_ADD_CHANGE_BITS"].ToString());
                    mPermission.SH_ADD_EASY_OPEN = long.Parse(red["SH_ADD_EASY_OPEN"].ToString());
                    mPermission.SH_EXCHANGE_EASY_OPEN = long.Parse(red["SH_EXCHANGE_EASY_OPEN"].ToString());
                    mPermission.SH_ADD_TIN_CANS = long.Parse(red["SH_ADD_TIN_CANS"].ToString());
                    mPermission.SH_EXCHANGE_TIN_CANS = long.Parse(red["SH_EXCHANGE_TIN_CANS"].ToString());
                    mPermission.SH_ADD_NEW_RLT = long.Parse(red["SH_ADD_NEW_RLT"].ToString());
                    mPermission.SH_EXCHANGE_RLT = long.Parse(red["SH_EXCHANGE_RLT"].ToString());
                    mPermission.SH_ADD_NEW_CUT_RAW_TIN = long.Parse(red["SH_ADD_NEW_CUT_RAW_TIN"].ToString());
                    mPermission.SH_ADD_NEW_CUT_PRINTED_TIN = long.Parse(red["SH_ADD_NEW_CUT_PRINTED_TIN"].ToString());
                    mPermission.SH_EXCHANGE_CUT_PRINTED_TIN = long.Parse(red["SH_EXCHANGE_CUT_PRINTED_TIN"].ToString());
                    mPermission.SH_ADD_NEW_BOTTOM = long.Parse(red["SH_ADD_NEW_BOTTOM"].ToString());
                    mPermission.SH_EXCHANGE_BOTTOM = long.Parse(red["SH_EXCHANGE_BOTTOM"].ToString());
                    mPermission.SH_DEPARTMENT_MAINTENANCE = long.Parse(red["SH_DEPARTMENT_MAINTENANCE"].ToString());
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
                            mAccount.SH_EMP_ID = long.Parse(rd["SH_EMP_ID"].ToString());
                        mAccount.SH_EMP_NAME = rd["SH_EMP_NAME"].ToString();
                        mAccount.SH_ID = long.Parse(rd["SH_ID"].ToString());
                        mAccount.SH_EMP_PASSWORD = rd["SH_EMP_PASSWORD"].ToString();
                        mAccount.SH_CREATION_DATE = DateTime.Parse(rd["SH_CREATION_DATE"].ToString());
                        mAccount.SH_EMP_USER_NAME = rd["SH_EMP_USER_NAME"].ToString();
                        }
                        myconnection.closeConnection();

                        if (f_data)
                        {
                            getEmployeeData();
                            getUserPermission();
                     
                             this.Hide();

                            Mainform forms = new Mainform(mEmployee, mAccount, mPermission);

                            forms.ShowDialog();
                        this.Close();
                        }
                        else
                        {
                            MessageBox.Show("خطأ في كلمه السر او اسم المستخدم");
                        }

            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }
     
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

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

  

        private void bttnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
           
                checkforloginning();
            }
        }
    }
}
