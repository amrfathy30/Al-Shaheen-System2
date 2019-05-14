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
    public partial class addnewprinterform : Form
    {
        public addnewprinterform()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void new_printer_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewprinterform myform = new addnewprinterform())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void addnewprinterform_Load(object sender, EventArgs e)
        {

        }

        private void save_printer_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(printer_name_text_box.Text) || string.IsNullOrEmpty(printer_address_text_box.Text) || string.IsNullOrEmpty(printer_address_gps_text_box.Text))
            {
                MessageBox.Show("لا يمكن الحفظ لعدم وجود البيانات صحيحة ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                try
                {
                    string query = "INSERT INTO SH_TIN_PRINTER (SH_PRINTER, SH_PRINTER_ADDRESS_TEXT, SH_PRINTER_ADDRESS_GPS) VALUES(@SH_PRINTER,@SH_PRINTER_ADDRESS_TEXT,@SH_PRINTER_ADDRESS_GPS)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_PRINTER", printer_name_text_box.Text );
                    cmd.Parameters.AddWithValue("@SH_PRINTER_ADDRESS_TEXT", printer_address_text_box.Text );
                    cmd.Parameters.AddWithValue("@SH_PRINTER_ADDRESS_GPS" , printer_address_gps_text_box.Text);
                    cmd.ExecuteNonQuery();  
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE ADDING NEW PRINTER"+ex.ToString());
                }
            }
        }
    }
}
