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
    public partial class addnewcolorpillow : Form
    {
        List<SH_COLOR_PILLOW> pillow_colors = new List<SH_COLOR_PILLOW>();
        DatabaseConnection myconnection = new DatabaseConnection();

        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();


        public addnewcolorpillow(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;
        }

        async Task<long> check_color_if_exists_or_not()
        {
            long myid = 0;
            if (pillow_colors.Count>0)
            {
                for (int i = 0; i < pillow_colors.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        if (string.Compare(pillow_colors[i].SH_COLOR_NAME, color_name_text_box.Text) == 0 && string.Compare(pillow_colors[i].SH_COLOR_CODE, color_code_text_box.Text) == 0)
                        {
                            myid = pillow_colors[i].SH_ID;
                        }
                    });
                }
                return myid;
            }
            return 0;
        }

        async Task getallcolorspillow()
        {
            pillow_colors.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_COLORS_PILLOW", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pillow_colors.Add(new SH_COLOR_PILLOW() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_COLOR_CODE = reader["SH_COLOR_CODE"].ToString() , SH_COLOR_NAME = reader["SH_COLOR_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR GETTING ALL COLORS PILLOW "+ex.ToString());
            }



        }


        async Task fillgridview()
        {
            if (pillow_colors.Count>0)
            {
                colors_pillow_grid_view.Rows.Clear();
                for (int i = 0; i < pillow_colors.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        colors_pillow_grid_view.Rows.Add(new string[] { (i + 1).ToString(), pillow_colors[i].SH_COLOR_NAME, pillow_colors[i].SH_COLOR_CODE });
                    });
                    }

            }
        }

        async Task savenewcolorpillow()
        {
            if (string.IsNullOrWhiteSpace(color_name_text_box.Text ))
            {
                color_name_text_box.Focus();
                MessageBox.Show("الرجاء كتابة إسم اللون" , "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else if (string.IsNullOrWhiteSpace(color_code_text_box.Text))
            {
                color_code_text_box.Focus();
                MessageBox.Show("الرجاء كتابة كود اللون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            if (await check_color_if_exists_or_not () ==0)
            {
                try
                {
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_PILLOW_COLOR", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_COLOR_NAME", color_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_COLOR_CODE", color_code_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME" , mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mAccount.SH_EMP_NAME);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING NEW COLOR PILLOW " + ex.ToString());
                }
            }else
            {
                MessageBox.Show("اللون موجود مسبقا" , "تحذير" , MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
           
        }

        private void addnewcolorpillow_Load(object sender, EventArgs e)
        {
            Task t = new Task(async () =>
            {
                
                await getallcolorspillow();
                await fillgridview();


            });
            t.Start();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            Task t = new Task(async () =>
            {
                await savenewcolorpillow();
                await getallcolorspillow();
                this.Invoke((MethodInvoker)async delegate ()
                {
                    await fillgridview();
                });

            });
            t.Start();
            
        }
    }
}
