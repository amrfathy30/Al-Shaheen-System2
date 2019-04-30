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
    public partial class addnewmoldsize : Form
    {
        List<SH_MOLD_SIZE> sizes = new List<SH_MOLD_SIZE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewmoldsize()
        {
            InitializeComponent();
        }

        async Task getallsizesdata()
        {
            sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_MOLD_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_MOLD_SIZE_VALUE = double.Parse(reader["SH_MOLD_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL MOLD SIZEs FORM DB "+ex.ToString());
            }
        }
        async Task savenewmoldsize()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_MOLD_SIZE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_MOLD_SIZE" , double.Parse(size_title_text_box.Text));
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show(" تم الحفظ" ,"معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                await fillsizesgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILe ADDING NEW MOLD SIZE "+ex.ToString());
            }
        }
        async Task fillsizesgridview()
        {
            await getallsizesdata();
            try
            {
                if (sizes.Count > 0)
                {
                    for (int i = 0; i < sizes.Count; i++)
                    {
                        sizes_grid_view.Rows.Add((i+1).ToString() , Math.Round(sizes[i].SH_MOLD_SIZE_VALUE,1).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE FILLING DATA GRiD VIEW "+ex.ToString());
            }
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            double testnumber = 0;
            if (string.IsNullOrWhiteSpace(size_title_text_box.Text))
            {
                MessageBox.Show("الرجاء كتابة المقاس ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (double.TryParse(size_title_text_box.Text, out testnumber))
            {
                await savenewmoldsize();
            }
            else
            {
                MessageBox.Show(" الرجاء كتابة أرقام فى صندوق الكتابة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }

        }
    }
}
