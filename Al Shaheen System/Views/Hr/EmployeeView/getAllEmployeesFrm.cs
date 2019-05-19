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
using System.IO;

namespace Al_Shaheen_System
{
    public partial class getAllEmployeesFrm : Form
    {
        SH_EMPLOYEES memployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS maccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mpermission = new SH_USER_PERMISIONS();

        List<SH_EMPLOYEES> employeeslist = new List<SH_EMPLOYEES>();
        List<SH_USER_ACCOUNTS> usersList_detail = new List<SH_USER_ACCOUNTS>();

        Byte[] ImageByteArray;
        public getAllEmployeesFrm(SH_EMPLOYEES anyEmployee, SH_USER_ACCOUNTS anyAccount, SH_USER_PERMISIONS anyPermission)
        {
            InitializeComponent();
            memployee = anyEmployee;
            maccount = anyAccount;
            mpermission = anyPermission;
        }

     public void getallemployeesdata()
        {
            employeeslist.Clear();
           try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT SH_EMPLOYEES.* FROM SH_EMPLOYEES ", DatabaseConnection.mConnection);            
                SqlDataReader reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] ImageArray;
                    if ( reader["SH_EMPLOYEE_IMAGE"].ToString().Trim() =="" || reader["SH_EMPLOYEE_IMAGE"].ToString().Trim() ==null)
                    {
                        ImageArray = null;
                        employeeslist.Add(new SH_EMPLOYEES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString(), SH_EMPLOYEE_NATIONAL_ID = reader["SH_EMPLOYEE_NATIONAL_ID"].ToString(), SH_EMPLOYEE_ADDRESS = reader["SH_EMPLOYEE_ADDRESS"].ToString(), SH_EMPLOYEMENT_DATE = DateTime.Parse(reader["SH_EMPLOYEMENT_DATE"].ToString()), SH_EMPLOYEE_EMAIL = reader["SH_EMPLOYEE_EMAIL"].ToString(), SH_EMPLOYEE_FUNCTION_ID = long.Parse(reader["SH_EMPLOYEE_FUNCTION_ID"].ToString()), SH_EMPLOYEE_FUNCTION_NAME = reader["SH_EMPLOYEE_FUNCTION_NAME"].ToString(), SH_EMPLOYEE_GENDER = reader["SH_EMPLOYEE_GENDER"].ToString(), SH_EMPLOYEE_MOBILE = reader["SH_EMPLOYEE_MOBILE"].ToString(), SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()), SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString(), SH_DEPARTMENT_ID = long.Parse(reader["SH_DEPARTMENT_ID"].ToString()), SH_DEPARTMENT_NAME = reader["SH_DEPARTMENT_NAME"].ToString(), SH_EMPLOYEE_IMAGE = null });

                    }
                    else
                    {
                        ImageArray = (byte[])reader["SH_EMPLOYEE_IMAGE"];
                        if (ImageArray.Length != 0)
                        {
                            ImageByteArray = ImageArray;
                            employeeslist.Add(new SH_EMPLOYEES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_EMPLOYEE_NAME = reader["SH_EMPLOYEE_NAME"].ToString(), SH_EMPLOYEE_NATIONAL_ID = reader["SH_EMPLOYEE_NATIONAL_ID"].ToString(), SH_EMPLOYEE_ADDRESS = reader["SH_EMPLOYEE_ADDRESS"].ToString(), SH_EMPLOYEMENT_DATE = DateTime.Parse(reader["SH_EMPLOYEMENT_DATE"].ToString()), SH_EMPLOYEE_EMAIL = reader["SH_EMPLOYEE_EMAIL"].ToString(), SH_EMPLOYEE_FUNCTION_ID = long.Parse(reader["SH_EMPLOYEE_FUNCTION_ID"].ToString()), SH_EMPLOYEE_FUNCTION_NAME = reader["SH_EMPLOYEE_FUNCTION_NAME"].ToString(), SH_EMPLOYEE_GENDER = reader["SH_EMPLOYEE_GENDER"].ToString(), SH_EMPLOYEE_MOBILE = reader["SH_EMPLOYEE_MOBILE"].ToString(), SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()), SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString(), SH_DEPARTMENT_ID = long.Parse(reader["SH_DEPARTMENT_ID"].ToString()), SH_DEPARTMENT_NAME = reader["SH_DEPARTMENT_NAME"].ToString(), SH_EMPLOYEE_IMAGE = Image.FromStream(new MemoryStream(ImageArray)) });


                        }
                    }
                   
                       }
                myconnection.closeConnection();    
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GeTTING EMPLOYEES DATA " +ex.ToString());
            }
        }
        void fillemployeesgridview()
        {
            employees_grid_view.Rows.Clear();
            getallemployeesdata();
            if (employeeslist.Count > 0)
            {
                for (int i = 0; i < employeeslist.Count; i++)
                {
                    employees_grid_view.Rows.Add(new string[] { (i+1).ToString() , employeeslist[i].SH_ID.ToString(), employeeslist[i].SH_EMPLOYEE_NAME , employeeslist[i].SH_EMPLOYEE_NATIONAL_ID,employeeslist[i].SH_EMPLOYEE_ADDRESS , employeeslist[i].SH_DATA_ENTRY_EMPLOYEE_NAME });
                }
            }
        }

       
        public SH_USER_ACCOUNTS getAllUsersData()
        {

            SH_USER_ACCOUNTS account = new SH_USER_ACCOUNTS();
            try
            {
                DatabaseConnection conn = new DatabaseConnection();
                conn.openConnection();
                SqlCommand cmd = new SqlCommand("select * from SH_USER_ACCOUNTS",DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())



                {

                    usersList_detail.Add(new SH_USER_ACCOUNTS() {SH_ID=long.Parse( reader["SH_ID"].ToString()), SH_EMP_ID = long.Parse(reader["SH_EMP_ID"].ToString()), SH_EMP_NAME = (reader["SH_EMP_NAME"].ToString()), SH_EMP_USER_NAME = reader["SH_EMP_USER_NAME"].ToString(),SH_EMP_PASSWORD=reader["SH_EMP_PASSWORD"].ToString(),SH_CREATION_DATE=DateTime.Parse( reader["SH_CREATION_DATE"].ToString()) });
                }

                conn.closeConnection();
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public SH_USER_PERMISIONS getUserPermission(SH_USER_ACCOUNTS acc)
        {
            SH_USER_PERMISIONS perm = new SH_USER_PERMISIONS();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand("select * from SH_USER_PERMISIONS", DatabaseConnection.mConnection);
              //  cmd.cmdandType = cmdandType.StoreaderProcedure;
                
               // cmd.Parameters.AddWithValue("@empid", acc.SH_EMP_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    perm.SH_ID = long.Parse(reader["SH_ID"].ToString());
                    
                    perm.SH_ACCOUNT_ID = long.Parse(reader["SH_ACCOUNT_ID"].ToString());
                    perm.SH_ACCOUNT_NAME = reader["SH_ACCOUNT_NAME"].ToString();


                }
                myconnection.closeConnection();
                return perm;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIE GETTING USER PERMISSION " + ex.ToString());
            }
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (employees_grid_view.SelectedRows.Count > 0)
            {
                makenewuser anyuser = new makenewuser(employeeslist[employees_grid_view.SelectedRows[0].Index], memployee, maccount, mpermission);
            
                    anyuser.Show();
                        
            }else
            {
                MessageBox.Show("الرجاء تحديد الموظف أولا");
            }
            
        }

        private void getAllEmployeesFrm_Load(object sender, EventArgs e)
        {
         
            fillemployeesgridview();

            if (mpermission.SH_OPEN_MAKE_NEW_USER == 1)
            {
                bttnNewUser.Visible = true;
            }else
            {
                bttnNewUser.Visible = false;
            }


        }

        private void employees_grid_view_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            employee_portal myform = new employee_portal(employeeslist[e.RowIndex]);
         
                myform.Show();
         
        }

       
    }
}
