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
    public partial class addnewcoverplatesize : Form
    {
        List<SH_COVER_PLATE_SIZE> plate_sizes = new List<SH_COVER_PLATE_SIZE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewcoverplatesize()
        {
            InitializeComponent();
        }

        async Task getallcoverplatesizes()
        {
            plate_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_COVER_PALTE_SIZES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    plate_sizes.Add(new SH_COVER_PLATE_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_COVER_PLATE_SIZE_VALUE = reader["SH_COVER_PLATE_SIZE_VALUE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL COVER PLATE SIZES "+ex.ToString());
            }
        }
        async Task fillallsizesgridview()
        {
            await getallcoverplatesizes();
            plate_sizes_grid_view.Rows.Clear();
            if (plate_sizes.Count>0)
            {
                for (int i = 0; i < plate_sizes.Count; i++)
                {
                    plate_sizes_grid_view.Rows.Add(new string[] { (i+1).ToString() , plate_sizes[i].SH_COVER_PLATE_SIZE_VALUE });
                }
            }

        }

        async Task<long> check_if_size_exists_or_not()
        {
            if (plate_sizes.Count > 0)
            {
                for (int i = 0; i < plate_sizes.Count; i++)
                {
                    if (string.Compare(plate_sizes[i].SH_COVER_PLATE_SIZE_VALUE,size_value_text_box.Text)==0)
                    {
                        return plate_sizes[i].SH_ID;
                    }
                }
            }
            return 0;
        }


        async Task savenewcoverplatesize()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_COVER_PLATE_SIZE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_COVER_PLATE_SIZE_VALUE", size_value_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW PLATE COVER SIZE "+ex.ToString());
            }
        }
        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(size_value_text_box.Text))
            {

            }
            else
            {
                if (await check_if_size_exists_or_not()==0)
                {
                    await savenewcoverplatesize();
                    await fillallsizesgridview();
                }else
                {
                    MessageBox.Show("هذا المقاس موجود من قبل", "تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
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

        private async void addnewcoverplatesize_Load(object sender, EventArgs e)
        {
            await fillallsizesgridview();
        }
    }
}
