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
    public partial class sh_Add_ChangeBits : Form
    {
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();
        public sh_Add_ChangeBits()
        {
            InitializeComponent();
        }

      void loadsuppliersdata()
        {
            string query ="SELECT * FROM SH_SUPPLY_COMPANY";
            try
            {



                SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=SH_MASTER_DB;Integrated Security=true");
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString() });
                }
                //myconnection.closeConnection();
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE LOADING SUPLLIERS DATA");
            }
        }
        void fillsupplierscombobox()
        {
            for (int i = 0; i < suppliers.Count; i++)
            {
                comboBoxSupplier.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
            }
        }
        private void buttn_Save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_NumberOFPerm.Text))
            {
                MessageBox.Show("ادخل رقم اذن الصرف ");
                textBox_NumberOFPerm.Focus();
                return;
            }
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("ادخل الاسم ");
                textBoxName.Focus();
                return;
            }
            if (String.IsNullOrEmpty(textBoxUnit.Text))
            {
                MessageBox.Show("ادخل اسم الوحده ");
                textBoxUnit.Focus();
                return;
            }
            if (String.IsNullOrEmpty(textBoxQntity.Text))
            {
                MessageBox.Show("ادخل  الكميه ");
                textBoxQntity.Focus();
                return;
            }

            if (String.IsNullOrEmpty(textBoxDescribtion.Text))
            {
                MessageBox.Show("ادخل الوصف ");
                textBoxDescribtion.Focus();
                return;
            }
            if (String.IsNullOrEmpty(textBoxStoreMan.Text))
            {
                MessageBox.Show("ادخل اسم امين المخزن ");
                textBoxStoreMan.Focus();
                return;
            }
            if (String.IsNullOrEmpty(comboBoxType.Text))
            {
                MessageBox.Show("ادخل نوع قطع الغيار ");
                comboBoxType.Focus();
                return;
            }
            if (String.IsNullOrEmpty(comboBoxSupplier.Text))
            {
                MessageBox.Show("ادخل المورد ");
                comboBoxSupplier.Focus();
                return;
            }
            try
            {
                SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=SH_MASTER_DB;Integrated Security=true");
                conn.Open();
                //this add in  SH_QUANTITIES_COMPUTER_PARTS (table)
                SqlCommand comm = new SqlCommand("addQUANTITIESChangeBits", conn);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.AddWithValue("@itemName", textBoxName.Text);
                comm.Parameters.AddWithValue("@itemProperties", textBoxDescribtion.Text);
                comm.Parameters.AddWithValue("@itemUnit", textBoxUnit.Text);
                comm.Parameters.AddWithValue("@noOfItems", long.Parse(textBoxQntity.Text));
                comm.Parameters.AddWithValue("@stockManName", textBoxStoreMan.Text);
                comm.Parameters.AddWithValue("@permisionNumber", long.Parse(textBox_NumberOFPerm.Text));
                comm.Parameters.AddWithValue("@supplierName", comboBoxSupplier.SelectedText);
                comm.Parameters.AddWithValue("@supplierID", long.Parse(comboBoxSupplier.SelectedValue.ToString()));
                comm.Parameters.AddWithValue("@AddionDate", DateTime.Parse(dateTimePicker1.Text));
                comm.Parameters.AddWithValue("@type", comboBoxType.SelectedText);
                comm.ExecuteNonQuery();
                
       MessageBox.Show("نم اضافه قطع الغيار  بنجاح ");
                buttn_Save.Enabled = false;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error" + ex.Message);

                Application.Exit();
            }





        }

        private void buttnNew_Click(object sender, EventArgs e)
        {
            textBoxName.Clear();
            textBoxDescribtion.Clear();
            textBoxQntity.Clear();
            textBoxStoreMan.Clear();
            textBoxUnit.Clear();
            textBox_NumberOFPerm.Clear();


        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sh_Add_ChangeBits_Load(object sender, EventArgs e)
        {
            loadsuppliersdata();
           fillsupplierscombobox();
        comboBoxSupplier.SelectedIndex =0;
        }
    }
}
