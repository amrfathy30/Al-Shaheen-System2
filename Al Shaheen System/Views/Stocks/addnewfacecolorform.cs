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
    public partial class addnewfacecolorform : Form
    {
        public addnewfacecolorform()
        {
            InitializeComponent();
        }

        private void new_color_btn_Click(object sender, EventArgs e)
        {
            using (addnewfacecolorform myform = new addnewfacecolorform())
            {
                myform.ShowDialog();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addnewfacecolorform_Load(object sender, EventArgs e)
        {

        }

        private void save_new_color_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(color_name_text_box.Text))
            {
                MessageBox.Show("إملاء البيانات الفارغة" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else
            {
                try
                {
                    string query = "INSERT INTO SH_FACE_COLORS (SH_FACE_COLOR_NAME) VALUES(@SH_FACE_COLOR_NAME)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_FACE_COLOR_NAME", color_name_text_box.Text);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING COLOR NAME "+ex.ToString());
                }


            }
        }
    }
}
