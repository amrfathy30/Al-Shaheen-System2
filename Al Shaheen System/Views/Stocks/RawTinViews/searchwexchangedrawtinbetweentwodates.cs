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
    public partial class searchwexchangedrawtinbetweentwodates : Form
    {
        List<SH_EXCHANGE_OF_RAW_MATERIAL> quantities = new List<SH_EXCHANGE_OF_RAW_MATERIAL>();
        public searchwexchangedrawtinbetweentwodates()
        {
            InitializeComponent();
        }

        void filllistdata()
        {
            quantities.Clear();

            try
            {
                string query = " SELECT *  FROM SH_EXCHANGE_OF_RAW_MATERIAL WHERE CAST(SH_EXCHANGE_DATE AS DATETIME) BETWEEN @firstdate AND @seconddate";

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@firstdate" ,DateTime.Parse( first_date_date_picker.Text));
                cmd.Parameters.AddWithValue("@seconddate" , DateTime.Parse(second_date_picker.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    quantities.Add(new SH_EXCHANGE_OF_RAW_MATERIAL() { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }

                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING EXCHANGED" + ex.ToString());
            }


        }



        private void search_btn_Click(object sender, EventArgs e)
        {
            filllistdata();
            if (quantities.Count > 0)
            {
                using (rawmaterialexchangedquantities myform = new rawmaterialexchangedquantities(quantities))
                {
                    myform.ShowDialog();
                }
            }else
            {
                MessageBox.Show("لا يوجد بيانات" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
           

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
