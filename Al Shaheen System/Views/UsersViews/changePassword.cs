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
    public partial class changePassword : Form
    {
        SH_USER_ACCOUNTS accnt=new SH_USER_ACCOUNTS();
        SH_EMPLOYEES emp = new SH_EMPLOYEES();
        SH_USER_PERMISIONS SH_Perm = new SH_USER_PERMISIONS();
        List<SH_USER_ACCOUNTS> usersList_detail=new List<SH_USER_ACCOUNTS>();


        public changePassword(SH_USER_ACCOUNTS acc, SH_EMPLOYEES mEmp, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            accnt = acc;
            emp = mEmp;
            SH_Perm = anyperm;
        }

        private void changePassword_Load(object sender, EventArgs e)
        {
            txtLastUserName.Text = accnt.SH_EMP_USER_NAME;
            txtUserName.Text = accnt.SH_EMP_USER_NAME;
            txtPassword.Text = accnt.SH_EMP_PASSWORD;
        }

      
        private void bttnOk_Click(object sender, EventArgs e)
        {
            try
            {

                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand cmd = new SqlCommand("changePassWord", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                //problem
                cmd.Parameters.AddWithValue("@user", txtUserName.Text);
                cmd.Parameters.AddWithValue("@pass ", txtConfirmPass.Text);
                cmd.Parameters.AddWithValue("@SH_ID", accnt.SH_ID);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم تغير كلمه السر بنجاح");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttnClose_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
