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
    public partial class addnewtwistoftype : Form
    {
        List<SH_TWIST_OF_TYPE> twist_of_types = new List<SH_TWIST_OF_TYPE>();
        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();
        public addnewtwistoftype(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;
        }

        async Task<long> check_if_twist_type_exist()
        {
            
            if (twist_of_types.Count>0)
            {
                for (int i = 0; i < twist_of_types.Count; i++)
                {
                     if (string.Compare(twist_of_types[i].SH_SHORT_TITLE , item_short_name_text_box.Text)==0 && string.Compare(twist_of_types[i].SH_LONG_TITLE, item_definition_text_box.Text)==0 && string.Compare(twist_of_types[i].SH_KIND , type_kind_text_box.Text)==0)
                        {
                            return  twist_of_types[i].SH_ID;
                        }
                    
                    
                }
            }
            return 0;
        }

        async Task filltwist_of_grid_view()
        {

            this.Invoke((MethodInvoker)delegate ()
            {
                twist_of_types_grid_view.Rows.Clear();
            });
            if (twist_of_types.Count > 0)
            {
                for (int i = 0; i < twist_of_types.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        twist_of_types_grid_view.Rows.Add(new string[] { (i + 1).ToString(), twist_of_types[i].SH_SHORT_TITLE, twist_of_types[i].SH_LONG_TITLE , twist_of_types[i].SH_KIND });
                    });
                    }
            }
        }
        async Task getalltwist_of_types()
        {
            twist_of_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_TWIST_OF_TYPES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                    
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_types.Add(new SH_TWIST_OF_TYPE() { SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()) , SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString() , SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()) , SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_LONG_TITLE = reader["SH_LONG_TITLE"].ToString() , SH_SHORT_TITLE = reader["SH_SHORT_TITLE"].ToString() , SH_KIND = reader["SH_KIND"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OFF TYPES DATA "+ex.ToString());
            }
        }

        async Task savenewtwidt_of_type()
        {
            if (string.IsNullOrWhiteSpace(item_short_name_text_box.Text))
            {
                item_short_name_text_box.Focus();
                MessageBox.Show("لابد من كتابة الأختصار ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else if (string.IsNullOrWhiteSpace(item_definition_text_box.Text))
            {
                item_definition_text_box.Focus();
                MessageBox.Show("لابد من كتابة وصف الإختصار   ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }else
            {
                if (await check_if_twist_type_exist()==0)
                {
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_TWIST_OF_TYPE", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_SHORT_TITLE", item_short_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_LONG_TITLE", item_definition_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME", mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mAccount.SH_EMP_NAME);
                    cmd.Parameters.AddWithValue("@SH_KIND" , type_kind_text_box.Text);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }else
                {
                    MessageBox.Show("النوع موجود سابقا", "تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }

        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            //Task t = new Task(async () =>
            //{
            await savenewtwidt_of_type();
            await getalltwist_of_types();
            await filltwist_of_grid_view();
            //});
            //t.Start();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addnewtwistoftype_Load(object sender, EventArgs e)
        {
            await getalltwist_of_types();
            await filltwist_of_grid_view();
        }
    }
}
