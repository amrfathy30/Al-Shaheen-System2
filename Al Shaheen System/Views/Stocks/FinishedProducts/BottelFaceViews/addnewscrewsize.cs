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
    public partial class addnewscrewsize : Form
    {
        List<SH_SCREW_SIZE> screw_sizes = new List<SH_SCREW_SIZE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewscrewsize()
        {
            InitializeComponent();
        }

        async Task savenewscrewsize()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_SCREW_SIZE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SCREW_SIZE_VALUE" , long.Parse(size_value_text_box.Text));
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح ", "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW SCREW SIZE "+ex.ToString());
            }
        }


        async Task getallscrew_sizes()
        {
            screw_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SCREW_SIZES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_sizes.Add(new SH_SCREW_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_SCREW_SIZE_VALUE = long.Parse(reader["SH_SCREW_SIZE_VALUE"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING "+ex.ToString());
            }
        }
        async Task fillscrewsizesgridview()
        {
           await getallscrew_sizes();
            screw_sizes_grid_view.Rows.Clear();
            if (screw_sizes.Count>0)
            {
                for (int i = 0; i < screw_sizes.Count; i++)
                {
                    screw_sizes_grid_view.Rows.Add(new string[] { (i+1).ToString() ,screw_sizes[i].SH_SCREW_SIZE_VALUE.ToString() });
                }
            }
        }

        async Task<long> check_if_screw_value_exits_or_not()
        {
            if (screw_sizes.Count>0)
            {
                for (int i = 0; i < screw_sizes.Count; i++)
                {
                    if (screw_sizes[i].SH_SCREW_SIZE_VALUE == long.Parse(size_value_text_box.Text))
                    {
                        return screw_sizes[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            size_value_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void addnewscrewsize_Load(object sender, EventArgs e)
        {
            await fillscrewsizesgridview();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(size_value_text_box.Text))
            {
                MessageBox.Show("لايمكن ترك المقاس فارغ");
            }
            else
            {
                long testnumber = 0;
                if (long.TryParse(size_value_text_box.Text, out testnumber))
                {
                    if (await check_if_screw_value_exits_or_not()==0)
                    {
                        await savenewscrewsize();
                        await fillscrewsizesgridview();
                    }else
                    {
                        MessageBox.Show("هذا المقاس موجود مسبقا", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
                else
                {
                    MessageBox.Show("قيمة المقاس لابد ان تكون قيمة صحيحة للتعبير عن المليمترات", "تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }
        }
    }
}
