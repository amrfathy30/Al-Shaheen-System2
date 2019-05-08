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
    public partial class getalldepartments : Form
    {
        List<SH_DEPARTEMENTS> departments = new List<SH_DEPARTEMENTS>();
        public getalldepartments()
        {
            InitializeComponent();
        }
        public void getAllDept()
        {
            // SH_DEPARTEMENTS dpt = new SH_DEPARTEMENTS();
            departments.Clear();
            try
            {
                DatabaseConnection myconn = new DatabaseConnection();
                myconn.openConnection();
                SqlCommand comm = new SqlCommand("select * from SH_DEPARTEMENTS", DatabaseConnection.mConnection);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {

                    departments.Add(new SH_DEPARTEMENTS() { SH_ID = long.Parse(rd["SH_ID"].ToString()), SH_DEPARTEMNT_NAME = (rd["SH_DEPARTEMNT_NAME"].ToString()) });
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
            if (departments.Count > 0)
            {
                for (int i = 0; i < departments.Count; i++)
                {
                    dataGridView1.Rows.Add(new string[] { (i + 1).ToString(), departments[i].SH_DEPARTEMNT_NAME });

                }
            }
        }
        private void getalldepartments_Load(object sender, EventArgs e)
        {
            fillDeptGridView();
        }
    }
}
