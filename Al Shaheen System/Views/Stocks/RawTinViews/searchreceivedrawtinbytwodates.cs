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
    public partial class searchreceivedrawtinbytwodates : Form
    {

        List<SH_QUANTITY_OF_RAW_MATERIAL> myquantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();

        public searchreceivedrawtinbytwodates()
        {
            InitializeComponent();
        }




        void fillquantitesdata()
        {
            myquantities.Clear();
            try
            {
                string query = " SELECT *  FROM SH_QUANTITY_OF_RAW_MATERIAL WHERE CAST(SH_ADDITION_DATE AS DATETIME) BETWEEN @firstdate AND @seconddate";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);

                cmd.Parameters.AddWithValue("@firstdate",DateTime.Parse(first_date_time_picker.Text));
                cmd.Parameters.AddWithValue("@seconddate", DateTime.Parse(second_date_time_picker.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    myquantities.Add(new SH_QUANTITY_OF_RAW_MATERIAL() { SH_ID = long.Parse(reader["SH_ID"].ToString()) });

                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SEARCHIONG IN DB "+ex.ToString());
            }



        }






        private void search_btn_Click(object sender, EventArgs e)
        {
            fillquantitesdata();
            if (myquantities.Count > 0)
            {
                using (show_tin_general_infos myform = new show_tin_general_infos(myquantities))
                {
                    myform.ShowDialog();
                }
            }else
            {

            }


        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
