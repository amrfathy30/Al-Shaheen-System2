using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Al_Shaheen_System
{
    public partial class Display_allUsers : Form
    {
        List<SH_USER_ACCOUNTS> usersList_detail = new List<SH_USER_ACCOUNTS>();
        List<SH_EMPLOYEES> employeeslist = new List<SH_EMPLOYEES>();
        SH_EMPLOYEES SH_emp = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS SH_acc = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS SH_perm = new SH_USER_PERMISIONS();
        public Display_allUsers(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyacount,SH_USER_PERMISIONS anyPerm)
        {
            InitializeComponent();
            SH_emp = anyemp;
            SH_acc = anyacount;
            SH_perm = anyPerm;
        }
        
        public void getAllUsersData()
        {

            usersList_detail.Clear();
            //SH_USER_ACCOUNTS account = new SH_USER_ACCOUNTS();
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand comm = new SqlCommand("select * from SH_USER_ACCOUNTS", DatabaseConnection.mConnection);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())

                {

                    usersList_detail.Add(new SH_USER_ACCOUNTS() { SH_EMP_ID = long.Parse(rd["SH_EMP_ID"].ToString()), SH_EMP_NAME = (rd["SH_EMP_NAME"].ToString()), SH_EMP_USER_NAME = rd["SH_EMP_USER_NAME"].ToString(), SH_EMP_PASSWORD = rd["SH_EMP_PASSWORD"].ToString(), SH_CREATION_DATE = DateTime.Parse(rd["SH_CREATION_DATE"].ToString()) , SH_ID = long.Parse(rd["SH_ID"].ToString()) });
                }

                conn.openConnection();
             //   return account;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("ERROR WHILE GETTING USERS DATA " + ex.ToString());
            }
            //return null;
        }
        //don't Touch
            void fillemployeesgridview()
        {
               gridViewAllUsers.Rows.Clear();
               getAllUsersData();
                if (usersList_detail.Count > 0)
                {
                    for (int i = 0; i < usersList_detail.Count; i++)
                    {
                    gridViewAllUsers.Rows.Add(new string[] { (i + 1).ToString(), usersList_detail[i].SH_EMP_NAME.ToString(), usersList_detail[i].SH_EMP_USER_NAME,usersList_detail[i].SH_EMP_PASSWORD,usersList_detail[i].SH_CREATION_DATE.ToString() });
                    }
                }
                else
            {
                MessageBox.Show("لا يوجد بيانات " , "معلومات " , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            }
        public SH_USER_PERMISIONS getUserPermission(SH_USER_ACCOUNTS acc)
        {
            SH_USER_PERMISIONS perm = new SH_USER_PERMISIONS();
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand com2 = new SqlCommand("getpermissionOneEmp", DatabaseConnection.mConnection);
                com2.CommandType = CommandType.StoredProcedure;
                //problem
                com2.Parameters.AddWithValue("@empid", acc.SH_ID);
                SqlDataReader red = com2.ExecuteReader();
                while (red.Read())
                {
                    perm.SH_ID = long.Parse(red["SH_ID"].ToString());

                    perm.SH_ACCOUNT_ID = long.Parse(red["SH_ACCOUNT_ID"].ToString());
                    perm.SH_ACCOUNT_NAME = red["SH_ACCOUNT_NAME"].ToString();


                }
                conn.closeConnection();
                return perm;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIE GETTING USER PERMISSION " + ex.ToString());
            }
            return null;
        }

        public SH_EMPLOYEES getEmployeeData(SH_USER_ACCOUNTS acc)
        {
            SH_EMPLOYEES emp = new SH_EMPLOYEES();
            DatabaseConnection myconnection = new DatabaseConnection();
            myconnection.openConnection();
            SqlCommand com = new SqlCommand("getoneEmp", DatabaseConnection.mConnection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@empID", acc.SH_EMP_ID);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                emp.SH_EMPLOYEE_ADDRESS = reader["SH_EMPLOYEE_ADDRESS"].ToString();
                emp.SH_EMPLOYEMENT_DATE = DateTime.Parse(reader["SH_EMPLOYEMENT_DATE"].ToString());
                emp.SH_EMPLOYEE_EMAIL = reader["SH_EMPLOYEE_EMAIL"].ToString();
                emp.SH_EMPLOYEE_GENDER = reader["SH_EMPLOYEE_GENDER"].ToString();
                emp.SH_ID = long.Parse(reader["SH_ID"].ToString());
                emp.SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString();
                emp.SH_EMPLOYEE_NATIONAL_ID = reader["SH_EMPLOYEE_NATIONAL_ID"].ToString();
            }
            myconnection.closeConnection();
            return emp;
        }

        private void Display_allUsers_Load(object sender, EventArgs e)
        {

            fillemployeesgridview();

        }

        private void bttnDisplayAllUserData_Click(object sender, EventArgs e)
        {

            //if (gridViewAllUsers.SelectedRows.Count > 0)     
            //{
            //    using (UsersDetails anyuser = new UsersDetails(SH_acc, SH_perm, SH_emp))
            //    {
            //        anyuser.ShowDialog();
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("الرجاء تحديد المستخدم أولا");
            //}

        }

       


        private void button2_Click(object sender, EventArgs e)
        {
            if (gridViewAllUsers.SelectedRows.Count > 0)
            {

                changePassword anyuser = new changePassword(SH_acc, getEmployeeData(usersList_detail[gridViewAllUsers.SelectedRows[0].Index]), getUserPermission(usersList_detail[gridViewAllUsers.SelectedRows[0].Index]));
               
                    anyuser.Show();
               

            }
            else
            {
                MessageBox.Show("الرجاء تحديد المستخدم أولا");
            }
        }

        private void setuserpermissionsform_Click(object sender, EventArgs e)
        {
            if (gridViewAllUsers.SelectedRows.Count>0)
            {
                using (updateUserPermissionsFrm myform = new updateUserPermissionsFrm(usersList_detail[gridViewAllUsers.SelectedRows[0].Index]))
                {
                    myform.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("الرجاء تحديد المستخدم أولا");
            }
        }
    }
    
    
}
