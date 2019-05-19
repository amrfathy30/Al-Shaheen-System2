using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Drawing;
using System.IO;

namespace Al_Shaheen_System
{
    public partial class RegistEmp : Form
    {
        List<SH_DEPARTEMENTS> deptList = new List<SH_DEPARTEMENTS>();
        SH_EMPLOYEES memployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS maccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mpermission = new SH_USER_PERMISIONS();

        List<SH_USER_ACCOUNTS> usersList_detail = new List<SH_USER_ACCOUNTS>();
        List<SH_EMPLOYEES> employeeslist = new List<SH_EMPLOYEES>();
        List<SH_FUNCTION> jobList = new List<SH_FUNCTION>();
        SH_DEPARTEMENTS dept = new SH_DEPARTEMENTS();
        SH_FUNCTION fn = new SH_FUNCTION();


        int ImageID = 0;
        String strFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;











        public RegistEmp(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            DefaultImage = pbxImage.Image;
            memployee = anyemp;
            maccount = anyaccount;
            mpermission = anyperm;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtEmpName.Clear();
            txtEmpAddress.Clear();
            txtEmpEmail.Clear();
            txtEmpMobile.Clear();
            txtEmpNationalID.Clear();
            radioFemale.Checked = false;
            radioMale.Checked = false;
            comboBoxDept.SelectedIndex = -1;
            comboBoxFn.SelectedIndex = -1;
            bttnSave.Enabled = true;


        }
        void Clear()
        {
            ImageID = 0;
            txtTitle.Clear();
            pbxImage.Image = DefaultImage;
            strFilePath = "";
         //   btnSave.Text = "Save";
        }

        void laodComboBxDept()
        {

            try
            {
                string query = "SELECT * FROM SH_DEPARTEMENTS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    deptList.Add(new SH_DEPARTEMENTS {  SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_DEPARTEMNT_NAME = reader["SH_DEPARTEMNT_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING departements Parts DATA FROM DB " + ex.ToString());
            }
        }

        void fillComboBxDept()
        {

            deptList.Clear();
            laodComboBxDept();
            comboBoxDept.Items.Clear();
            if (deptList.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < deptList.Count; i++)
                {
                    comboBoxDept.Items.Add(deptList[i].SH_DEPARTEMNT_NAME);
                }
            }
        }

       







        

    

        private void txtEmpEmail_Validating(object sender, CancelEventArgs e)
        {

            string UserEmail = txtEmpEmail.Text;
            if (IsValidEmailId(UserEmail) == false)
            {
                errorProviderEmail.SetError(txtEmpEmail, "ادخل الايميل بطريقة صحيحة");

            }
            else
            {
                errorProviderEmail.Clear();
            }

        }

        private void txtEmpMobile_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmpMobile.Text.Length != 11)
            {
                errorProviderMobile.SetError(txtEmpMobile, "راجع رقم الموبايل");
            }
            else
            {
                errorProviderMobile.Clear();
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEmpMobile.Text, "[^0-9]"))
            {
                errorProviderMobile.SetError(txtEmpMobile, "ادخل ارقام فقط");
                txtEmpMobile.Text = txtEmpMobile.Text.Remove(txtEmpMobile.Text.Length - 1);

            }
            else
            {
                errorProviderMobile.Clear();
            }
        }


        private void txtEmpNationalID_Validating(object sender, CancelEventArgs e)
        {


            if (System.Text.RegularExpressions.Regex.IsMatch(txtEmpNationalID.Text, "[^0-9]"))
            {
                errorProviderNationalID.SetError(txtEmpNationalID, "ادخل ارقام فقط");
                txtEmpNationalID.Text = txtEmpNationalID.Text.Remove(txtEmpNationalID.Text.Length - 1);
            }
            else
            {
                errorProviderNationalID.Clear();
            }
            
            if (txtEmpNationalID.Text.Length != 14)
            {
                errorProviderNationalID.SetError(txtEmpNationalID,"راجع الرقم القومي");
            }
            else
            {
                errorProviderNationalID.Clear();
            }
        }
        private bool WithErrors()
        {
            if (txtEmpNationalID.Text.Trim() == String.Empty || txtEmpNationalID.Text.Length > 14)
                return true;
            if (txtEmpMobile.Text.Trim() == String.Empty)
                return true;

            if (txtEmpAddress.Text.Trim() == String.Empty)
                return true;
            if (txtEmpEmail.Text.Trim() == String.Empty)
                return true;

            return false;
        }
        public static bool IsValidEmailId(string InputEmail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(InputEmail);
            if (match.Success)
                return true;
            else
                return false;
        }
        private void bttnSave_Click(object sender, EventArgs e)
        {

            if (WithErrors() == true)
            {
                MessageBox.Show("من فضلك اكمل باقى المعلومات");

            }


            else
            {
                if (txtTitle.Text.Trim() != "")
                {

                    if (strFilePath == "")
                    {
                        if (ImageByteArray.Length != 0)
                            ImageByteArray = new byte[] { };
                    }
                    else
                    {
                        Image temp = new Bitmap(strFilePath);
                        MemoryStream strm = new MemoryStream();
                        temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ImageByteArray = strm.ToArray();
                    }
                    try
                    {
                        string query = "INSERT INTO SH_EMPLOYEES ";
                        query += "(SH_EMPLOYEE_NAME, SH_EMPLOYEE_NATIONAL_ID, SH_EMPLOYEE_ADDRESS, SH_EMPLOYEE_MOBILE, SH_EMPLOYEE_GENDER, SH_EMPLOYEE_EMAIL, SH_EMPLOYEMENT_DATE, SH_EMPLOYEE_FUNCTION_ID,";
                        query += " SH_EMPLOYEE_FUNCTION_NAME, SH_DATA_ENTRY_USER_ID,SH_DATA_ENTRY_USER_NAME, SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_EMPLOYEE_NAME ,SH_DEPARTMENT_ID ,SH_DEPARTMENT_NAME ,SH_EMPLOYEE_IMAGE)";
                        query += " VALUES(@SH_EMPLOYEE_NAME,@SH_EMPLOYEE_NATIONAL_ID,@SH_EMPLOYEE_ADDRESS,@SH_EMPLOYEE_MOBILE,@SH_EMPLOYEE_GENDER,@SH_EMPLOYEE_EMAIL,@SH_EMPLOYEMENT_DATE,@SH_EMPLOYEE_FUNCTION_ID,";
                        query += "@SH_EMPLOYEE_FUNCTION_NAME,@SH_DATA_ENTRY_USER_ID,@SH_DATA_ENTRY_USER_NAME,@SH_DATA_ENTRY_EMPLOYEE_ID,@SH_DATA_ENTRY_EMPLOYEE_NAME , @SH_DEPARTMENT_ID , @SH_DEPARTMENT_NAME , @SH_EMPLOYEE_IMAGE)";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand comm = new SqlCommand(query, DatabaseConnection.mConnection);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_NAME", txtEmpName.Text);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_NATIONAL_ID", txtEmpNationalID.Text);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_ADDRESS", txtEmpAddress.Text);
                        if (radioFemale.Checked == true)
                        {
                            comm.Parameters.AddWithValue("@SH_EMPLOYEE_GENDER", radioFemale.Text);
                        }
                        else
                        if (radioMale.Checked == true)
                        {
                            comm.Parameters.AddWithValue("@SH_EMPLOYEE_GENDER", radioMale.Text);
                        }
                        else
                        {
                            MessageBox.Show("ادخل نوع الموظف");
                        }

                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_MOBILE", txtEmpMobile.Text);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_EMAIL", txtEmpEmail.Text);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEMENT_DATE", Convert.ToDateTime(dateTimePicker1.Text));
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_FUNCTION_ID", jobList[comboBoxFn.SelectedIndex].SH_ID);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_FUNCTION_NAME", jobList[comboBoxFn.SelectedIndex].SH_FUNCTION_NAME);
                        comm.Parameters.AddWithValue("@SH_DEPARTMENT_ID", deptList[comboBoxDept.SelectedIndex].SH_ID);
                        comm.Parameters.AddWithValue("@SH_DEPARTMENT_NAME", deptList[comboBoxDept.SelectedIndex].SH_DEPARTEMNT_NAME);
                        comm.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                        comm.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME", maccount.SH_EMP_NAME);
                        comm.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                        comm.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", memployee.SH_EMPLOYEE_NAME);
                        comm.Parameters.AddWithValue("@SH_EMPLOYEE_IMAGE", ImageByteArray);
                        comm.ExecuteNonQuery();
                        myconnection.closeConnection();
                        MessageBox.Show(" تم تسجيل الموظف بنجاح");
                        // bttnSave.Enabled = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE ADDING NEW EMPLOYEES " + ex.Message);
                    }
                } }
        }
        void getDeptID()
        {
            try
            {
                string query = "select * from SH_FUNCTION where SH_DEPARTEMENT_ID=@id";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", deptList[comboBoxDept.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    jobList.Add(new SH_FUNCTION() { SH_ID=long.Parse(reader["SH_ID"].ToString()),SH_DEPARTEMENT_NAME=reader["SH_DEPARTEMENT_NAME"].ToString(),SH_DEPARTEMENT_ID=long.Parse(reader["SH_DEPARTEMENT_ID"].ToString()),SH_FUNCTION_NAME=reader["SH_FUNCTION_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error in getting deptID" + ex.ToString());
            }
        }
        void fillJobCombobox()
        {
            jobList.Clear();
            comboBoxFn.Items.Clear();
            getDeptID();
            if (jobList.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < jobList.Count; i++)
                {
                    comboBoxFn.Items.Add(jobList[i].SH_FUNCTION_NAME);
                }
            }
        }
        private void RegistEmp_Load(object sender, EventArgs e)
        {
            fillComboBxDept(); 
            textBoxUserName.Text = maccount.SH_EMP_NAME;

          
            //try
            //{
            //    SqlConnection conn1 = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=SH_MASTER_DB;Integrated Security=true");
            //    conn1.Open();
            //    SqlCommand comm = new SqlCommand("select * from SH_DEPARTEMENTS", conn1);
            //    SqlDataReader rd = comm.ExecuteReader();
            //    while (rd.Read())
            //    {

            //        comboBoxDept.Items.Add(rd["SH_DEPT_NAME"].ToString());
            //        comboBoxDept.ValueMember = rd["SH_DEPT_ID"].ToString();
            //        //long param=long.Parse( rd["SH_DEPT_ID"].ToString());
            //        comboBoxDept.DisplayMember = rd["SH_DEPT_NAME"].ToString();

            //    }
            //    conn1.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("error", ex.Message);
            //}
           
        }

        private void comboBoxDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          fillJobCombobox();
        }

     

        private void txtEmpName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtEmpName.Text))
            {

                
                errorProvider_Name.SetError(txtEmpName, "بجب ادخال اسم الموظف");
            }
            else
            {

                errorProvider_Name.SetError(txtEmpName, "");
            }
            if (!Regex.IsMatch(txtEmpName.Text, @"[a-zA-Z\s\'-]*"))
            {
                errorProvider_Name.SetError(txtEmpName, "اسخدم حروف فقط");
            }


            string context = this.txtEmpName.Text;

            bool isnum = false;

            for (int i = 0; i < context.Length; i++)

            {

                if (char.IsNumber(context[i]))

                {

                    isnum = true;

                    break;

                }

            }

            if (isnum)

            {

                errorProvider_Name.SetError(txtEmpName, "لا تدخل ارقام");

            }
        }

        private void txtEmpName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmpNationalID_TextChanged(object sender, EventArgs e)
        {

        }

        private void browse_image_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pbxImage.Image = new Bitmap(strFilePath);
                if (txtTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
                    txtTitle.Text = System.IO.Path.GetFileName(strFilePath);
            }
        }

        private void set_default_image_Click(object sender, EventArgs e)
        {
            ImageID = 0;
            txtTitle.Clear();
            pbxImage.Image = DefaultImage;
            strFilePath = "";
            
        }

        private void txtEmpMobile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
            
    
    

        
    

