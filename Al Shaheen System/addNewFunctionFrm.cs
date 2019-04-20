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
    public partial class addNewFunctionFrm : Form
    {

        SH_DEPARTEMENTS mdept = new SH_DEPARTEMENTS();
        List<SH_FUNCTION> functions = new List<SH_FUNCTION>();

        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();

        public addNewFunctionFrm( SH_DEPARTEMENTS dept , SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mdept = dept;

            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;


        }
        void addnewdepartment()
        {
            try
            {
                string query = "INSERT INTO SH_FUNCTION ";
                query += "(SH_DEPARTEMENT_ID, SH_DEPARTEMENT_NAME, SH_FUNCTION_NAME, SH_DATA_ENTRY_USER_ID, SH_DATA_ENTRY_USER_NAME, SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_EMPLOYEE_NAME)";
                query += "VALUES(@SH_DEPARTEMENT_ID,@SH_DEPARTEMENT_NAME,@SH_FUNCTION_NAME,@SH_DATA_ENTRY_USER_ID,@SH_DATA_ENTRY_USER_NAME,@SH_DATA_ENTRY_EMPLOYEE_ID,@SH_DATA_ENTRY_EMPLOYEE_NAME)";
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_DEPARTEMENT_ID", mdept.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DEPARTEMENT_NAME", mdept.SH_DEPARTEMNT_NAME);
                cmd.Parameters.AddWithValue("@SH_FUNCTION_NAME", textBoxFnName.Text);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID",mAccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME",mAccount.SH_EMP_USER_NAME);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mEmployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME",mEmployee.SH_EMPLOYEE_NAME);
                cmd.ExecuteNonQuery();

                MessageBox.Show("تم تسجيل الوظيفه بنجاح");           
                conn.closeConnection();
                fillfunctionsgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW DEPARTMENT FUNCTION" + ex.Message);
            }
        }
        void checkifcunctionnameexistornot()
        {
            long result = 0;
            try
            {
                string query = "SELECT  COUNT(SH_ID) AS mycounter FROM SH_FUNCTION WHERE SH_DEPARTEMENT_ID = @SH_DEPARTEMENT_ID AND SH_FUNCTION_NAME LIKE N'%"+mdept.SH_DEPARTEMNT_NAME+"%'";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_DEPARTEMENT_ID" , mdept.SH_ID);
                   
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = long.Parse(reader["mycounter"].ToString());
                }
                myconnection.closeConnection();
                if (result==0)
                {
                    addnewdepartment();
                }else
                {
                    MessageBox.Show("هذه الوظيفة تم إضافتها مسبقا" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE CHECKING EXISTANCE OF DEPARTMENT FUNCTION "+ex.ToString());
            }
        }
        void loadallfunctionsdatabydepartmentid()
        {
            functions.Clear();
            try
            {
                string query = "SELECT * FROM SH_FUNCTION WHERE SH_DEPARTEMENT_ID = @SH_DEPARTEMENT_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_DEPARTEMENT_ID" , mdept.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    functions.Add(new SH_FUNCTION() {  SH_DEPARTEMENT_ID = long.Parse(reader["SH_DEPARTEMENT_ID"].ToString()) , SH_DEPARTEMENT_NAME = reader["SH_DEPARTEMENT_NAME"].ToString() , SH_FUNCTION_NAME = reader["SH_FUNCTION_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING DEPARTMENT FUNCTIONS DATA "+ex.ToString());
            }

        }
        void fillfunctionsgridview()
        {
            loadallfunctionsdatabydepartmentid();
            functions_grid_view.Rows.Clear();
            if (functions.Count > 0)
            {
                for (int i = 0; i < functions.Count; i++)
                {
                    functions_grid_view.Rows.Add(new string[] { (i+1).ToString() , functions[i].SH_FUNCTION_NAME });
                }

            }
            
        }
        private void addNewFunctionFrm_Load(object sender, EventArgs e)
        {
            textBoxDeptName.Text = mdept.SH_DEPARTEMNT_NAME;
            fillfunctionsgridview();
        }
        private void bttnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            checkifcunctionnameexistornot();
        }
        private void buttonNew_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
