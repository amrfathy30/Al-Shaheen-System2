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
    public partial class DatabaseConnectionSettingForm : Form
    {
        public DatabaseConnectionSettingForm()
        {
            InitializeComponent();
        }

        private void save_server_info_btn_Click(object sender, EventArgs e)
        {
            if (windowsradiobtn.Checked)
            {
                Properties.Settings.Default.SH_SERVER = servertxtbox.Text;
                Properties.Settings.Default.SH_DATABASE_NAME = dbtxtbox.Text;
                Properties.Settings.Default.SH_AUTH_TYPE = "Windows";
            }
            else
            {
                Properties.Settings.Default.SH_AUTH_TYPE = servertxtbox.Text;
                Properties.Settings.Default.SH_DATABASE_NAME = dbtxtbox.Text;
                Properties.Settings.Default.SH_USER_NAME = usernametxtbox.Text;
                Properties.Settings.Default.SH_PASSWORD = passwordtxtbox.Text;
                Properties.Settings.Default.SH_AUTH_TYPE = "SQL";
            }
            Properties.Settings.Default.Save();
            MessageBox.Show("Saved");
        }

        private void windowsradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if (windowsradiobtn.Checked)
            {
                groupBox1.Enabled = false;
            }
            else if (SqlServerradiobtn.Checked)
            {
                groupBox1.Enabled = true;
            }
        }

        private void SqlServerradiobtn_CheckedChanged(object sender, EventArgs e)
        {
            if (windowsradiobtn.Checked)
            {
                groupBox1.Enabled = false;
            }
            else if (SqlServerradiobtn.Checked)
            {
                groupBox1.Enabled = true;
            }
        }

        private void DatabaseConnectionSettingForm_Load(object sender, EventArgs e)
        {
            string Mode = Properties.Settings.Default.SH_AUTH_TYPE;
            servertxtbox.Text = Properties.Settings.Default.SH_SERVER;
            dbtxtbox.Text = Properties.Settings.Default.SH_DATABASE_NAME;

            if (Mode == "SQL")
            {
                SqlServerradiobtn.Checked = true;
                groupBox1.Enabled = true;
                usernametxtbox.Text = Properties.Settings.Default.SH_USER_NAME;
                passwordtxtbox.Text = Properties.Settings.Default.SH_PASSWORD;
            }
            else
            {
                windowsradiobtn.Checked = true;
                groupBox1.Enabled = false;
            }
        }
        public void testconnection()
        {
            SqlConnection mDatabaseConnection;
            try
            {
                string mode = windowsradiobtn.Checked ? "windows" : "SQL";
                if (mode == "SQL")
                {
                    mDatabaseConnection = new SqlConnection(@"Server = " + servertxtbox.Text + ";Database = " + dbtxtbox.Text + "; Integrated Security = false ; User ID =  " + usernametxtbox.Text + " ; Password=  " + passwordtxtbox.Text + "");
                }
                else
                {
                    mDatabaseConnection = new SqlConnection(@"Server = " + servertxtbox.Text + ";Database = " + dbtxtbox.Text + "; Integrated Security = true ");
                }
                mDatabaseConnection.Open();
                mDatabaseConnection.Close();
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("Connectionfailed");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (waitingform myform = new waitingform(testconnection))
            {
                myform.ShowDialog(this);
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
