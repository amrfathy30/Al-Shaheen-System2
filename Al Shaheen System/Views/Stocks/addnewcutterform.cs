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
    public partial class addnewcutterform : Form
    {
        List<SH_SHAHEEN_CUTTERS> cutters = new List<SH_SHAHEEN_CUTTERS>();
        public addnewcutterform()
        {
            InitializeComponent();
        }

        void loadcuuttersdata()
        {
            cutters.Clear();
            try
            {
                string query = "SELECT * FROM SH_SHAHEEN_CUTTERS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cutters.Add(new SH_SHAHEEN_CUTTERS() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_CUTTER_NAME = reader["SH_CUTTER_NAME"].ToString() , SH_CUTTER_LOCATION_TEXT = reader["SH_CUTTER_LOCATION_TEXT"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW CUTTER" + ex.ToString());
            }
        }

        bool check_if_cutter_exists_or_not()
        {

            if (cutters.Count > 0)
            {
                for (int i = 0; i < cutters.Count; i++)
                {
                    if (string.Compare(cutters[i].SH_CUTTER_NAME , cutter_name_text_box.Text)==0 && string.Compare(cutters[i].SH_CUTTER_LOCATION_TEXT , cutter_location_text_box.Text)==0)
                    {
                        return true;
                    }
                }
            }

            return false;

        }



        void fillcuttersgridview()
        {
            cutters_grid_view.Rows.Clear();
            loadcuuttersdata();
            if (cutters.Count > 0)
            {
                for (int i = 0; i < cutters.Count; i++)
                {
                    cutters_grid_view.Rows.Add(new string[] { cutters[i].SH_ID.ToString() , cutters[i].SH_CUTTER_NAME , cutters[i].SH_CUTTER_LOCATION_TEXT });
                }
            }
        }

        private void addnewcutterform_Load(object sender, EventArgs e)
        {
            fillcuttersgridview();
        }

        private void save_cutter_btn_Click(object sender, EventArgs e)
        {
            if (((string.IsNullOrEmpty(cutter_name_text_box.Text)) ||(string.IsNullOrEmpty(cutter_location_text_box.Text))))
            {
                MessageBox.Show("الرجاء كتابة البيانات كاملة بشكل صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {

                if (check_if_cutter_exists_or_not())
                {
                    MessageBox.Show("هذا المقص موجود بالفعل" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
                }
                else
                {

                    try
                    {
                        string query = "INSERT INTO SH_SHAHEEN_CUTTERS (SH_CUTTER_NAME , SH_CUTTER_LOCATION_TEXT ) VALUES (@SH_CUTTER_NAME ,@SH_CUTTER_LOCATION_TEXT ) ";
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_NAME", cutter_name_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_CUTTER_LOCATION_TEXT", cutter_location_text_box.Text);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                        MessageBox.Show("تم الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING NEW CUTTER" + ex.ToString());
                    }
                    fillcuttersgridview();
                }
            }
        }

        private void new_cutter_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewcutterform myform = new addnewcutterform())
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
