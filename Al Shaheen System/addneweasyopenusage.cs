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
    public partial class addneweasyopenusage : Form
    {
        List<SH_EASY_OPEN_USAGE> usages = new List<SH_EASY_OPEN_USAGE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addneweasyopenusage()
        {
            InitializeComponent();
        }



        async Task getalleasyopenusage()
        {
            usages.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_USAGE_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usages.Add(new SH_EASY_OPEN_USAGE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_USAGE_TYPE= reader["SH_USAGE_TYPE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL EASYOPEN USAGE TYPES" +ex.ToString());
            }
        }
        async void fillsuagesgridview()
        {
            await getalleasyopenusage();
            easy_open_usages_grid_view.Rows.Clear();
            if (usages.Count>0)
            {
                for (int i = 0; i < usages.Count; i++)
                {
                    easy_open_usages_grid_view.Rows.Add(new string[] { (i+1).ToString() , usages[i].SH_USAGE_TYPE });
                }
            }
        }

        async Task addnewEasyopenusage()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_EASY_OPEN_USAGE ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_USAGE_TYPE", usage_type_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle ADDING NEW EASY OPEN "+ex.ToString());
            }
        }
        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usage_type_text_box.Text))
            {
                MessageBox.Show("لا يمكن ترك نوع الإستخدام فارغ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Warning);
            }
            else
            {
                await addnewEasyopenusage();
                 fillsuagesgridview();
            }

        }

        private void addneweasyopenusage_Load(object sender, EventArgs e)
        {
            fillsuagesgridview(); 
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            usage_type_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
