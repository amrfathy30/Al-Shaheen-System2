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
    public partial class addnewsizesform : Form
    {
        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();
        public addnewsizesform()
        {
            InitializeComponent();
        }
        string getshapetype()
        {
            string shapetype = null;
            if (shape_circle_radio_btn.Checked)
            {
                shapetype = shape_circle_radio_btn.Text;
            }
            else if (square_radio_btn.Checked)
            {
                shapetype = square_radio_btn.Text;
            }
            else if (triangle_radio_btn.Checked)
            {
                shapetype = triangle_radio_btn.Text;
            }
            return shapetype;
        }
        void loadaallsizes()
        {
            sizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE"; 
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString() , SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString() , SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }

        void fillsizesgridview()
        {
            loadaallsizes();
            sizesgridview.Rows.Clear();
            if (sizes.Count > 0)
            {
                string sectext = "";
                for (int i = 0; i < sizes.Count; i++)
                {
                    if (string.Compare(sizes[i].SH_SIZE_SECOND_DIAMETER_NAME , "D2")==0)
                    {
                        sectext = " ";
                    }
                    else
                    {
                        sectext = sizes[i].SH_SIZE_SECOND_DIAMETER_NAME;
                    }
                    sizesgridview.Rows.Add(new string[] { sizes[i].SH_ID.ToString() , sizes[i].SH_SIZE_NAME , sizes[i].SH_SIZE_SHAPE_NAME , sizes[i].SH_SIZE_FIRST_DIAMETER_NAME , sizes[i].SH_SIZE_FIRST_DIAMETER.ToString() , sectext , sizes[i].SH_SIZE_SECOND_DIAMETER.ToString() ,sizes[i].SH_SIZE_SURROUNDING.ToString()  });
                }
            }
        }

        void savenewsizetoDB(string sizename , string shapename , double fd , string fdname , double sd , string sdname , double sur)
        {
            try
            {
                string query = "INSERT INTO SH_ITEM_SIZE ";
                query += "(SH_SIZE_NAME, SH_SIZE_SHAPE_NAME, SH_SIZE_FIRST_DIAMETER, SH_SIZE_FIRST_DIAMETER_NAME, SH_SIZE_SECOND_DIAMETER, SH_SIZE_SECOND_DIAMETER_NAME, SH_SIZE_SURROUNDING) ";
                query += " VALUES(@SH_SIZE_NAME,@SH_SIZE_SHAPE_NAME,@SH_SIZE_FIRST_DIAMETER,@SH_SIZE_FIRST_DIAMETER_NAME,@SH_SIZE_SECOND_DIAMETER,@SH_SIZE_SECOND_DIAMETER_NAME,@SH_SIZE_SURROUNDING)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SIZE_NAME", sizename);
                cmd.Parameters.AddWithValue("@SH_SIZE_SHAPE_NAME", shapename);
                cmd.Parameters.AddWithValue("@SH_SIZE_FIRST_DIAMETER" , fd);
                cmd.Parameters.AddWithValue("@SH_SIZE_FIRST_DIAMETER_NAME" , fdname);
                cmd.Parameters.AddWithValue("@SH_SIZE_SECOND_DIAMETER" , sd );
                cmd.Parameters.AddWithValue("@SH_SIZE_SECOND_DIAMETER_NAME" , sdname);
                cmd.Parameters.AddWithValue("@SH_SIZE_SURROUNDING" , sur);

                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ " , "معلومات ",  MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING TO DB "+ex.ToString());
            }
        }
        private void shape_circle_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            d1_label.Visible = true;
            d1_text_box.Visible = true;
            d1_label.Text = "القطر";
            d2_label.Visible = false;
            d2_text_box.Visible = false;

        }

        private void square_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            d1_label.Visible = true;
            d1_text_box.Visible = true;
            d1_label.Text = "الضلع";
            d2_label.Visible = false;
            d2_text_box.Visible = false;

        }

        private void triangle_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            d1_label.Visible = true;
            d1_text_box.Visible = true;
            d1_label.Text = "الطول";
            d2_label.Visible = true;
            d2_label.Text = "العرض";
            d2_text_box.Visible = true;

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            bool addornot = true;
            double testnumber = 0;
            if (string.IsNullOrEmpty(size_name_text_box.Text))
            {
                addornot = false;
            }
            else if (string.IsNullOrEmpty(surrounding_text_box.Text))
            {
                addornot = false;
            }else if (!double.TryParse(surrounding_text_box.Text , out testnumber))
            {
                addornot = false;
            }
            else
            if (shape_circle_radio_btn.Checked)
            {
                if (string.IsNullOrEmpty(d1_text_box.Text))
                {
                    addornot = false;
                }else if (!double.TryParse(d1_text_box.Text , out testnumber))
                {
                    addornot = false;
                }
            }
            else if (square_radio_btn.Checked)
            {
                if (string.IsNullOrEmpty(d1_text_box.Text))
                {
                    addornot = false;
                }
                else if (!double.TryParse(d1_text_box.Text, out testnumber))
                {
                    addornot = false;
                }
            }
            else if (triangle_radio_btn.Checked)
            {
                if (string.IsNullOrEmpty(d1_text_box.Text) && string.IsNullOrEmpty(d2_text_box.Text))
                {
                    addornot = false;
                }
                else if (!double.TryParse(d1_text_box.Text, out testnumber) && (!double.TryParse(d2_text_box.Text, out testnumber)))
                {
                    addornot = false;
                }
            }

            if (addornot)
            {
              //  MessageBox.Show("Success");
                string d1text = "";
                double d1value = 0;
                string d2text = "";
                double d2value = 0;

                if (shape_circle_radio_btn.Checked)
                {
                    d1text = d1_label.Text;
                    d1value = double.Parse(d1_text_box.Text);
                    d2text = "D2";
                    d2value = 0;
                   
                }
                else if (square_radio_btn.Checked)
                {
                    d1text = d1_label.Text;
                    d1value = double.Parse(d1_text_box.Text);
                    d2text = "D2";
                    d2value = 0;
                    

                }
                else if (triangle_radio_btn.Checked)
                {
                    d1text = d1_label.Text;
                    d1value = double.Parse(d1_text_box.Text);
                    d2text = d2_label.Text;
                    d2value = double.Parse(d2_text_box.Text);                  
                }


                savenewsizetoDB(size_name_text_box.Text, getshapetype(), d1value, d1text, d2value, d2text, double.Parse(surrounding_text_box.Text));
                fillsizesgridview();



            }
            else
            {
                MessageBox.Show(" الرجاء التأكد من كتابة المعلومات بشكل صحيح " , "خطأ"  , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            using (addnewsizesform myform = new addnewsizesform())
            {
                myform.ShowDialog();
            }
        }

        private void addnewsizesform_Load(object sender, EventArgs e)
        {
            fillsizesgridview();
        }
    }
}
