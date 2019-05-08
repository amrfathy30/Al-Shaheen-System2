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
    public partial class addnewhandtype : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_COLOR_PILLOW> color_pillows = new List<SH_COLOR_PILLOW>();
        List<SH_HAND_SIZE> hand_sizes = new List<SH_HAND_SIZE>();
        List<SH_HAND_TYPES> hand_types = new List<SH_HAND_TYPES>();
        public addnewhandtype()
        {
            InitializeComponent();
        }

        async Task getallhandtypes()
        {
            hand_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SH_HAND_TYPES ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hand_types.Add(new SH_HAND_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_TYPE_HAND_SIZE_ID = long.Parse(reader["SH_TYPE_HAND_SIZE_ID"].ToString()) , SH_TYPE_HAND_SIZE_NAME = reader["SH_TYPE_HAND_SIZE_NAME"].ToString() , SH_TYPE_MATERIAL_TYPE = reader["SH_TYPE_MATERIAL_TYPE"].ToString(), SH_TYPE_NAME = reader["SH_TYPE_NAME"].ToString() , SH_TYPE_PILLOW_COLOR_ID = long.Parse(reader["SH_TYPE_PILLOW_COLOR_ID"].ToString()), SH_TYPE_PILLOW_COLOR_NAME = reader["SH_TYPE_PILLOW_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING All hAnd TYPES "+ex.ToString());
            }
        }

        async Task<long> check_if_hand_types_exists_or_not()
        {
            if (hand_types.Count>0)
            {
                for (int i = 0; i < hand_types.Count; i++)
                {
                    if (hand_types[i].SH_TYPE_HAND_SIZE_ID == hand_sizes[hand_sizes_combo_box.SelectedIndex].SH_ID && string.Compare(hand_types[i].SH_TYPE_MATERIAL_TYPE ,material_type_text_box.Text)==0 && hand_types[i].SH_TYPE_PILLOW_COLOR_ID == color_pillows[pillow_colors_combo_box.SelectedIndex].SH_ID&& string.Compare(hand_types[i].SH_TYPE_NAME,type_name_text_box.Text)==0)
                    {
                        return hand_types[i].SH_ID;
                    }
                }
            }
            return 0;
        }
        async Task fillhandtypesgridview()
        {
            await getallhandtypes();
            hand_types_data_grid_view.Rows.Clear();
            if (hand_types.Count>0)
            {
                for (int i = 0; i < hand_types.Count; i++)
                {
                    hand_types_data_grid_view.Rows.Add(new string[] { (i+1).ToString() , hand_types[i].SH_TYPE_NAME ,hand_types[i].SH_TYPE_MATERIAL_TYPE , hand_types[i].SH_TYPE_PILLOW_COLOR_NAME , hand_types[i].SH_TYPE_HAND_SIZE_NAME });
                }
            }
        }
        async Task gettwistofcolorspillow()
        {
            color_pillows.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_COLORS_PILLOW", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    color_pillows.Add(new SH_COLOR_PILLOW() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_COLOR_CODE = reader["SH_COLOR_CODE"].ToString(), SH_COLOR_NAME = reader["SH_COLOR_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING COLOR PILLOW FROM DB " + ex.ToString());
            }

        }
        async Task fillwistofcolorpillowcombobox()
        {
            await gettwistofcolorspillow();
            pillow_colors_combo_box.Items.Clear();
         
            if (color_pillows.Count > 0)
            {
                for (int i = 0; i < color_pillows.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        pillow_colors_combo_box.Items.Add(color_pillows[i].SH_COLOR_NAME);
                    });
                }

            }
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
                    hand_sizes.Add(new SH_HAND_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_HAND_SIZE_VALUE = long.Parse(reader["SH_HAND_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING HaND SIZES " + ex.ToString());
            }
        }

        async Task fillhandsizescombobox()
        {
            await getallhandsizes();
            hand_sizes_combo_box.Items.Clear();
            if (hand_sizes.Count>0)
            {
                for (int i = 0; i < hand_sizes.Count; i++)
                {
                    hand_sizes_combo_box.Items.Add(hand_sizes[i].SH_HAND_SIZE_VALUE.ToString());
                }
            }
        }

        private async void addnewhandtype_Load(object sender, EventArgs e)
        {
            await fillwistofcolorpillowcombobox();
            await fillhandsizescombobox();
            await fillhandtypesgridview();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewhandtype myform = new addnewhandtype())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(type_name_text_box.Text))
            {

            }
            else if (string.IsNullOrWhiteSpace(material_type_text_box.Text))
            {

            }
            else if (string.IsNullOrWhiteSpace(hand_sizes_combo_box.Text))
            {

            }
            else if (string.IsNullOrWhiteSpace(pillow_colors_combo_box.Text))
            {

            }
            else
            {
                if (await check_if_hand_types_exists_or_not() == 0)
                {
                    await savenewhandtype();
                    await fillhandtypesgridview();
                }
                else
                {
                    MessageBox.Show("هذه المواصفات تم إضافتها مسبفا", "تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
            }
        }


        async Task savenewhandtype()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_HAND_TYPE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TYPE_NAME", type_name_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_TYPE_MATERIAL_TYPE", material_type_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_TYPE_HAND_SIZE_ID", hand_sizes[hand_sizes_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_TYPE_HAND_SIZE_NAME", hand_sizes[hand_sizes_combo_box.SelectedIndex].SH_HAND_SIZE_VALUE);
                cmd.Parameters.AddWithValue("@SH_TYPE_PILLOW_COLOR_NAME", color_pillows[pillow_colors_combo_box.SelectedIndex].SH_COLOR_NAME);
                cmd.Parameters.AddWithValue("@SH_TYPE_PILLOW_COLOR_ID", color_pillows[pillow_colors_combo_box.SelectedIndex].SH_ID);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW HAND TYPE " + ex.ToString());
            }
        }





    }
}
