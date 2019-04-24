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
    public partial class addnewtwistofsize : Form
    {

        List<SH_TWIST_OF_SIZE> sizes = new List<SH_TWIST_OF_SIZE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewtwistofsize()
        {
            InitializeComponent();
        }

        async Task<long> check_if_exists_or_not()
        {
            if (sizes.Count > 0)
            {
                for (int i = 0; i < sizes.Count; i++)
                {
                    if (sizes[i].SH_TWIST_OF_SIZE_VALUE == long.Parse(size_value_text_box.Text))
                    {
                        return sizes[i].SH_ID;
                    }
                }
            }
            return 0;
        }
        async Task getalltwistofsizes()
        {     
            try
            {
                sizes.Clear();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_TWIST_OF_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_TWIST_OF_SIZE_VALUE = long.Parse(reader["SH_TWIST_OF_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL TWIST OF SIZES DATA "+ex.ToString());
            }
        }

        async Task fillsizesgridviewdata()
        {
            twist_of_sizes_grid_view.Rows.Clear();
            await getalltwistofsizes();
            if (sizes.Count > 0)
            {
                for (int i = 0; i < sizes.Count; i++)
                {
                    twist_of_sizes_grid_view.Rows.Add(new string[] { (i+1).ToString() , sizes[i].SH_TWIST_OF_SIZE_VALUE.ToString() });
                }
            }
        }

        async Task savenewtwistofsize()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_TWIST_OF_SIZE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TWIST_OF_SIZE",long.Parse(size_value_text_box.Text));
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDiNG nEW TWIST of SIZE "+ex.ToString());
            }
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(size_value_text_box.Text))
            {
                MessageBox.Show("الرجاء كتابة المقاس بالمليمتر", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                size_value_text_box.Focus();
            }
            else
            {
                long testnumber = 0;
                if (long.TryParse(size_value_text_box.Text, out testnumber))
                {
                    if (await check_if_exists_or_not()==0)
                    {
                        await savenewtwistofsize();
                        await fillsizesgridviewdata();
                    }else
                    {
                        MessageBox.Show("يوجد المقاس من قبل", "تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                    }                   
                }
                else
                {
                    MessageBox.Show("الرجاء كتابة المقاس بالمليمتر", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    size_value_text_box.Focus();
                }
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            size_value_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addnewtwistofsize_Load(object sender, EventArgs e)
        {
            await fillsizesgridviewdata();
        }
    }
}
