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
    public partial class makenewuser : Form
    {
        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS maccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mpermission = new SH_USER_PERMISIONS();


        SH_EMPLOYEES myEmployee = new SH_EMPLOYEES();

        public makenewuser(SH_EMPLOYEES selectedemployee,SH_EMPLOYEES anyone, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mEmployee = anyone;
            maccount = anyaccount;
            mpermission = anyperm;
            myEmployee = selectedemployee;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MAKENEWUSER_Load(object sender, EventArgs e)
        {
            txtEmpName.Text = myEmployee.SH_EMPLOYEE_NAME;
              
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand comm = new SqlCommand("ADDNEWUSER", DatabaseConnection.mConnection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@EMP_ID", myEmployee.SH_ID);
                comm.Parameters.AddWithValue("@EMP_NAME", myEmployee.SH_EMPLOYEE_NAME);
                comm.Parameters.AddWithValue("@EMP_USER_NAME", txtEmpUserName.Text);
                comm.Parameters.AddWithValue("@EMP_PASSWORD", txtEmpPassword.Text);
                comm.Parameters.AddWithValue("@CREATIONDATE", DateTime.Now);
                comm.ExecuteNonQuery();
                MessageBox.Show("تم تسجيل الموظف كمستخدم بنجاح");
                bttnSave.Enabled = false;
                myconnection.closeConnection();

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            }

        private void bttnNewUser_Click(object sender, EventArgs e)
        {
  
            getAllEmployeesFrm allemp = new getAllEmployeesFrm(mEmployee,maccount,mpermission);
         
            allemp.ShowDialog();
        }
    }
}
