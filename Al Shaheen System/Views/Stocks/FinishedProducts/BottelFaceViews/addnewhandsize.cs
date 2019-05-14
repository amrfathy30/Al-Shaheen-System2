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
    public partial class addnewhandsize : Form
    {
        List<SH_HAND_SIZE> hand_sizes = new List<SH_HAND_SIZE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewhandsize()
        {
            InitializeComponent();
        }


        async Task<long> check_if_hand_size_exists_or_not()
        {
            if (hand_sizes.Count>0)
            {
                for (int i = 0; i < hand_sizes.Count; i++)
                {
                    if (hand_sizes[i].SH_HAND_SIZE_VALUE == long.Parse(hand_size_text_box.Text))
                    {
                        return hand_sizes[i].SH_ID;
                    }
                }
            }
            return 0;
        }


        async Task getallhandsizes()
        {
            hand_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_HAND_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hand_sizes.Add(new SH_HAND_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_HAND_SIZE_VALUE = long.Parse(reader["SH_HAND_SIZE_VALUE"].ToString())});
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING HaND SIZES "+ex.ToString());
            }
        }

        async Task fillhandsizesgridview()
        {
            hand_size_grid_view.Rows.Clear();
            await getallhandsizes();
            if (hand_sizes.Count>0)
            {
                for (int i = 0; i < hand_sizes.Count; i++)
                {
                    hand_size_grid_view.Rows.Add(new string[] { (i+1).ToString() , hand_sizes[i].SH_HAND_SIZE_VALUE.ToString()});
                }
            }
        }

        private async void addnewhandsize_Load(object sender, EventArgs e)
        {
            await fillhandsizesgridview();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            hand_size_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(hand_size_text_box.Text))
            {
                MessageBox.Show("لا يمكن ترك المقاس فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (!long.TryParse(hand_size_text_box.Text, out testnumber))
            {
                MessageBox.Show("الرجاء كتابة المقاس ارقام صحيحة بالمليمترات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                if (await check_if_hand_size_exists_or_not() == 0)
                {


                    try
                    {
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_HAND_SIZE_DATA", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_HAND_SIZE_VALUE", long.Parse(hand_size_text_box.Text));
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                        MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        await fillhandsizesgridview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE ADDING NEW HAND SIZE DATA " + ex.ToString());
                    }
                }else
                {
                    MessageBox.Show("هذا المقاس موجود", "تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }

            }
        }
    }
}
