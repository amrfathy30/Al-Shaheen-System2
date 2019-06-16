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
    public partial class add_new_supply_company_form : Form
    {
        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        public add_new_supply_company_form(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyAccount, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mPermission = anyperm;
            mAccount = anyAccount;
            mPermission = anyperm;
            mEmployee = anyemp;

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void add_new_company_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (add_new_supply_company_form myform = new add_new_supply_company_form(mEmployee,mAccount,mPermission))
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void save_company_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(company_telephone_text_box.Text) || string.IsNullOrEmpty(company_mobile_text_box.Text) || string.IsNullOrEmpty(company_telephone_text_box.Text))
            {
                MessageBox.Show("إملاء البيانات من فضلك", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                if ((errorProvider1.GetError(company_telephone_text_box) == "") && (errorProvider1.GetError(company_telephone_text_box) == "") && (errorProvider1.GetError(company_mobile_text_box) == ""))
                {


                    string company_type_text_box = "";
            if (national_client_radio_btn.Checked)
            {
                company_type_text_box = "محلى";
            }
            else
            {
                company_type_text_box = "دولى";
            }

            string query = "INSERT INTO SH_SUPPLY_COMPANY ";
            query += "(SH_SUPPLY_COMAPNY_NAME, SH_SUPPLY_COMPANY_TYPE, SH_SUPPLY_COMPANY_MOBILE, ";
            query += " SH_SUPPLY_COMPANY_TELEPHONE  ,SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_USER_ID, SH_ADDITION_DATE ) VALUES( @SH_SUPPLY_COMAPNY_NAME,@SH_SUPPLY_COMPANY_TYPE,@SH_SUPPLY_COMPANY_MOBILE,@SH_SUPPLY_COMPANY_TELEPHONE,@SH_DATA_ENTRY_EMPLOYEE_ID,@SH_DATA_ENTRY_USER_ID,@SH_ADDITION_DATE)";

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMAPNY_NAME", company_name_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_TYPE", company_type_text_box);
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_MOBILE" , company_mobile_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_SUPPLY_COMPANY_TELEPHONE" , company_telephone_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mEmployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID",mAccount.SH_ID );
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE SAVING SUPPLY COMPANY ");
            }
        }else
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
}
        }

        private void add_new_supply_company_form_Load(object sender, EventArgs e)
        {
            national_client_radio_btn.Checked = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void company_name_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(company_name_text_box.Text))
            {
                errorProvider1.SetError(company_name_text_box, "إملاء بيانات الشركة");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void company_mobile_text_box_TextChanged(object sender, EventArgs e)
        {
            long mytele = 0;
            if (!long.TryParse(company_telephone_text_box.Text, out mytele))
            {
                errorProvider1.SetError(company_telephone_text_box, "إملاء رقم المحمول بالشكل الصحيح 01012312312");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void company_telephone_text_box_TextChanged(object sender, EventArgs e)
        {
            long mytele = 0;
            if (!long.TryParse(company_telephone_text_box.Text, out mytele))
            {
                errorProvider1.SetError(company_telephone_text_box, "إملاء رقم التليفون بالشكل الصحيح 01012312312");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
