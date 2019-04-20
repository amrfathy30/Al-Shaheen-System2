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
    public partial class Addnewstockform : Form
    {
        public Addnewstockform()
        {
            InitializeComponent();
        }

        private void new_stock_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Addnewstockform myform = new Addnewstockform())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void save_stock_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(stock_name_text_box.Text) || string.IsNullOrEmpty(stock_address_text_box.Text) || string.IsNullOrEmpty(stock_address_gps_link.Text))
            {
                MessageBox.Show("لا يمكن الحفظ لعدم وجود البيانات صحيحة " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else
            {

                try
                {
                    string query = "INSERT INTO SH_SHAHEEN_STOCKS ";
                    query += "(SH_STOCK_ADDRESS_GPS, SH_STOCK_ADDRESS_TEXT, SH_STOCK_NAME) ";
                    query += " VALUES(@SH_STOCK_ADDRESS_GPS,@SH_STOCK_ADDRESS_TEXT,@SH_STOCK_NAME)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_STOCK_NAME", stock_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_STOCK_ADDRESS_TEXT" , stock_address_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_STOCK_ADDRESS_GPS" , stock_address_gps_link.Text);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ بنجاح ", "معلومات "  , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE SAVING STOCK IN DB");
                }

            }
        }
    }
}
