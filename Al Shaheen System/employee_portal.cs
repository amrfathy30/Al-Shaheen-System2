using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class employee_portal : Form
    {

        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        Image DefaultImage;
        public employee_portal(SH_EMPLOYEES anyemployee)
        {
            InitializeComponent();
            mEmployee = anyemployee;
            DefaultImage = pbxImage.Image;
        }

        private void employee_portal_Load(object sender, EventArgs e)
        {
            employee_address_text_box.Text = mEmployee.SH_EMPLOYEE_ADDRESS;
            employee_department_text_box.Text = mEmployee.SH_DEPARTMENT_NAME;
            employee_email_text_box.Text = mEmployee.SH_EMPLOYEE_EMAIL;
            employee_employment_date_text_box.Text = mEmployee.SH_EMPLOYEMENT_DATE.ToString();
            employee_function_text_box.Text = mEmployee.SH_EMPLOYEE_FUNCTION_NAME;
            employee_gender_text_box.Text = mEmployee.SH_EMPLOYEE_GENDER;
            employee_mobile_text_box.Text = mEmployee.SH_EMPLOYEE_MOBILE;
            employee_name_label.Text = mEmployee.SH_EMPLOYEE_NAME;
            employee_national_id_text_box.Text = mEmployee.SH_EMPLOYEE_NATIONAL_ID;
            if (mEmployee.SH_EMPLOYEE_IMAGE==null)
            {
                pbxImage.Image = DefaultImage;
            }else

            {
                pbxImage.Image = mEmployee.SH_EMPLOYEE_IMAGE;
            }
           


        }
    }
}
