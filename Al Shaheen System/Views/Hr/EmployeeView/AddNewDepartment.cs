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
    public partial class AddNewDepartment : Form
    {
        List<SH_DEPARTEMENTS> nwDeptList =new  List<SH_DEPARTEMENTS>();
        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();
        public AddNewDepartment(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;
        }


        public void getAllDept()
        {
            // SH_DEPARTEMENTS dpt = new SH_DEPARTEMENTS();
            nwDeptList.Clear();
            try
            {
                DatabaseConnection myconn = new DatabaseConnection();
                myconn.openConnection();
                SqlCommand comm = new SqlCommand("select * from SH_DEPARTEMENTS", DatabaseConnection.mConnection);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {

                    nwDeptList.Add(new SH_DEPARTEMENTS() { SH_ID = long.Parse(rd["SH_ID"].ToString()), SH_DEPARTEMNT_NAME = (rd["SH_DEPARTEMNT_NAME"].ToString()) });
                }

                myconn.closeConnection();
              
            }
            catch (Exception ex)
            {

                MessageBox.Show("error" + ex.ToString());
            }
        }

        void fillDeptGridView()
        {
           dataGridView1.Rows.Clear();
            getAllDept();
            if (nwDeptList.Count > 0)
            {
                for (int i = 0; i < nwDeptList.Count; i++)
                {
                    dataGridView1.Rows.Add(new string[] { (i + 1).ToString(),nwDeptList[i].SH_DEPARTEMNT_NAME });
                  
                }
            }
        }

        
        private void bttn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttn_Save_Click(object sender, EventArgs e)
        {
            try
            {


                DatabaseConnection myconn = new DatabaseConnection();
                myconn.openConnection();


                SqlCommand comm = new SqlCommand("addDepartement", DatabaseConnection.mConnection);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@deptName", textBox1.Text);
                comm.ExecuteNonQuery();
                MessageBox.Show("تم تسجيل القسم بنجاح");
                bttn_Save.Enabled = false;
                myconn.closeConnection();
                fillDeptGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in"+ex.Message);
            }
        }

        private void bttn_new_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void AddNewDepartment_Load(object sender, EventArgs e)
        {
            fillDeptGridView();
        }

        private void bttnNewJobINDept_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                using (addNewFunctionFrm frm = new addNewFunctionFrm(nwDeptList[dataGridView1.SelectedRows[0].Index] , mEmployee , mAccount , mPermission))
                {
                    frm.ShowDialog();
                }

            }
            else
            {
                MessageBox.Show("الرجاء تحديد القسم  أولا");
            }

        }
    }
}
