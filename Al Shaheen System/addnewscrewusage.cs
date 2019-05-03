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
    public partial class addnewscrewusage : Form
    {
        List<SH_SCREW_USAGE> screw_usages = new List<SH_SCREW_USAGE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewscrewusage()
        {
            InitializeComponent();
        }

        async Task savenewscrewusage()
        {
            try
            {

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_SCREW_USAGE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SCREW_USAGE_NAME",usage_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح","معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle ADDING NEW SCREW USAGE "+ex.ToString());
            }
        }


        async Task get_all_usages()
        {
            screw_usages.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_USAGES" , DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_usages.Add(new SH_SCREW_USAGE() { SH_ID= long.Parse(reader["SH_ID"].ToString()) , SH_SCREW_USAGE_NAME = reader["SH_SCREW_USAGE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING USAGES DATA "+ex.ToString());
            }
        }

        async Task<long> check_if_exists_or_not()
        {

            if (screw_usages.Count > 0)
            {
                for (int i = 0; i < screw_usages.Count; i++)
                {
                    if (string.Compare(screw_usages[i].SH_SCREW_USAGE_NAME, usage_text_box.Text) == 0)
                    {
                        return screw_usages[i].SH_ID;
                    }
                }
               
            }
            return 0;
        }

        async Task fillusagesgridview()
        {
            await get_all_usages();
            usages_grid_view.Rows.Clear();
            if (screw_usages.Count > 0)
            {
                for (int i = 0; i < screw_usages.Count; i++)
                {
                    usages_grid_view.Rows.Add(new string[] { (i+1).ToString() , screw_usages[i].SH_SCREW_USAGE_NAME});   
                }
            }
        }


        private void new_btn_Click(object sender, EventArgs e)
        {
            usage_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addnewscrewusage_Load(object sender, EventArgs e)
        {
            await fillusagesgridview();
        }

        private async void saev_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usage_text_box.Text))
            {
                MessageBox.Show("الرجاء كتابة نوع الإستخدام وعدم ترك صندوق النص فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            else
            {
                if (await check_if_exists_or_not() == 0)
                {
                    await savenewscrewusage();
                    await fillusagesgridview();
                }
                else
                {
                    MessageBox.Show("هذا الإستخدام موجود من قبل","تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }
        }
    }
}
