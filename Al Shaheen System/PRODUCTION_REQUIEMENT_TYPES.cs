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
    public partial class PRODUCTION_REQUIEMENT_TYPES : Form
    {
        public PRODUCTION_REQUIEMENT_TYPES()
        {
            InitializeComponent();
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttnNew_Click(object sender, EventArgs e)
        {
            textBoxDescribtion.Clear();
            textBoxName.Clear();
            textBoxStoreMan.Clear();
            textBoxQntity.Clear();
            textBox_NumberOFPerm.Clear();
            textBoxUnit.Clear();

            buttn_Save.Enabled = true;
        }

        private void buttn_Save_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(textBox_NumberOFPerm.Text))
            {

                textBox_NumberOFPerm.Focus();
                errorProviderNumPerm.SetError(textBox_NumberOFPerm, "ادخل رقم اذن الصرف");
            }

            if (string.IsNullOrEmpty(textBoxName.Text))
            {

                textBox_NumberOFPerm.Focus();
                errorProviderName.SetError(textBoxName, "ادخل الاسم");
            }

            if (string.IsNullOrEmpty(textBoxUnit.Text))
            {

                textBox_NumberOFPerm.Focus();
                errorProviderUnit.SetError(textBoxUnit, "ادخل الوحدة");
            }
            if (string.IsNullOrEmpty(textBoxQntity.Text))
            {
                textBoxQntity.Focus();
                errorProviderquntity.SetError(textBoxQntity, "ادخل الكمية");
            }
            if (string.IsNullOrEmpty(textBoxDescribtion.Text))
            {
                textBoxDescribtion.Focus();
                errorProviderquntity.SetError(textBoxDescribtion, "ادخل الوصف");
            }


            if (string.IsNullOrEmpty(textBoxStoreMan.Text))
            {
                textBoxStoreMan.Focus();
                errorProviderquntity.SetError(textBoxStoreMan, "ادخل اسم امين المخزن");
            }
            if (string.IsNullOrEmpty(comboBoxSupplier.Text))
            {
                comboBoxSupplier.Focus();
                MessageBox.Show("اختر اسم المورد");
                return;
            }

            else
            {

                try
                {
                    SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=SH_MASTER_DB;Integrated Security=true");
                    conn.Open();

                    SqlCommand comm = new SqlCommand("", conn);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.AddWithValue("@item_name", textBoxName.Text);
                    comm.Parameters.AddWithValue("@item_properties", textBoxDescribtion.Text);
                    comm.Parameters.AddWithValue("@item_unit", textBoxUnit.Text);
                    comm.Parameters.AddWithValue("@no_items", long.Parse(textBoxQntity.Text));
                    comm.Parameters.AddWithValue("@stock_manName", textBoxStoreMan.Text);
                    comm.Parameters.AddWithValue("@addPermNum", long.Parse(textBox_NumberOFPerm.Text));
                    comm.Parameters.AddWithValue("@supplierName", comboBoxSupplier.Text);
                    comm.Parameters.AddWithValue("@supplier_id", long.Parse(comboBoxSupplier.SelectedValue.ToString()));
                    comm.Parameters.AddWithValue("@addionDate", DateTime.Parse(dateTimePicker1.Text));

                    comm.ExecuteNonQuery();

                    MessageBox.Show("نم اضافه مستلزمات الانتاج بنجاح ");
                    buttn_Save.Enabled = false;
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("error" + ex.Message);

                    Application.Exit();
                }
            }










        }
    }
}
