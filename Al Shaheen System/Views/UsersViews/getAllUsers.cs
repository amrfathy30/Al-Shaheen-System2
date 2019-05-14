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
    public partial class getAllUsers : Form
    {
        List<SH_USER_PERMISIONS> USERS = new List<SH_USER_PERMISIONS>();
        public getAllUsers()
        {
            InitializeComponent();
        }



        public void getallUsersdata()
        {
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand comm = new SqlCommand("select SH_EMP_ID,SH_EMP_NAME FROM SH_USER_ACCOUNTS", DatabaseConnection.mConnection);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {

                    USERS.Add(new SH_USER_PERMISIONS() { SH_ACCOUNT_ID = long.Parse(rd["SH_ACCOUNT_ID"].ToString()), SH_ACCOUNT_NAME = (rd["SH_ACCOUNT_NAME"].ToString()) });
                }

                conn.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }


        }

        void fillUsersgridview()
        {
            gridViewGetAllUsers.Rows.Clear();
            getallUsersdata();
            if (USERS.Count > 0)
            {
                for (int i = 0; i < USERS.Count; i++)
                {
                    gridViewGetAllUsers.Rows.Add(new string[] { (i + 1).ToString(), USERS[i].SH_ACCOUNT_ID.ToString(), USERS[i].SH_ACCOUNT_NAME });
                }
            }
        }

        private void getAllUsers_Load(object sender, EventArgs e)
        {
             fillUsersgridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (gridViewGetAllUsers.SelectedRows.Count > 0)
            //{
            //    using (SelectUserPermisions anyuser = new SelectUserPermisions(USERS[gridViewGetAllUsers.SelectedRows[0].Index]))
            //    {
            //        anyuser.ShowDialog();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("الرجاء تحديد الموظف أولا");
            //}



        }
    }
}
