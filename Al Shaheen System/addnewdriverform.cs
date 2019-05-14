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
    public partial class addnewdriverform : Form
    {
        List<SH_DRIVERS> drivers = new List<SH_DRIVERS>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewdriverform()
        {
            InitializeComponent();
        }

        long search_or_not = 0;
        async Task getalldriversdata()
        {
            drivers.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_DRIVERS_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new SH_DRIVERS() { SH_DRIVER_CAR_NUMBER = reader["SH_DRIVER_CAR_NUMBER"].ToString() ,SH_DRIVER_DRIVING_LICENSE_NUMBER = reader["SH_DRIVER_DRIVING_LICENSE_NUMBER"].ToString() , SH_DRIVER_NAME = reader["SH_DRIVER_NAME"].ToString() ,SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_DRIVER_TELEPHONE_NUMBER = reader["SH_DRIVER_TELEPHONE_NUMBER"].ToString()});
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING ALL DRIVERS DATA "+ex.ToString());
            }   
        }

        async Task savenewdriver()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_DRIVER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_DRIVER_TELEPHONE_NUMBER", driver_telephone_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_DRIVING_LICENSE_NUMBER", driving_lisence_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_NAME", driver_name_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_CAR_NUMBER", driver_car_number_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DRIVER INFORMATION "+ex.ToString());
            }
        }

        async Task filldriversgridview()
        {
            drivers_data_grid_view.Rows.Clear();
            if (search_or_not==0)
            {
                getalldriversdata();
            }else
            {
                getalldriverwithdrivertext();
            }
            
            try
            {
                if (drivers.Count>0)
                {
                    for (int i = 0; i < drivers.Count; i++)
                    {
                        drivers_data_grid_view.Rows.Add(new string[] {
                            (i+1).ToString() ,
                            drivers[i].SH_DRIVER_NAME,
                            drivers[i].SH_DRIVER_CAR_NUMBER,
                            drivers[i].SH_DRIVER_DRIVING_LICENSE_NUMBER,
                            drivers[i].SH_DRIVER_TELEPHONE_NUMBER
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE Filling DRIVERS GRid ViEW "+ex.ToString());
            }
        }

        async Task getalldriverwithdrivertext()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_DRIVERS_DATA_WITH_DRIVER_NAME", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_DRIVER_NAME", search_driver_name_text_box.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    drivers.Add(new SH_DRIVERS() { SH_DRIVER_CAR_NUMBER = reader["SH_DRIVER_CAR_NUMBER"].ToString(), SH_DRIVER_DRIVING_LICENSE_NUMBER = reader["SH_DRIVER_DRIVING_LICENSE_NUMBER"].ToString(), SH_DRIVER_NAME = reader["SH_DRIVER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_DRIVER_TELEPHONE_NUMBER = reader["SH_DRIVER_TELEPHONE_NUMBER"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING DRiVERs DATA WITH TEXT "+ex.ToString());
            }
        }

        private async void search_btn_Click(object sender, EventArgs e)
        {
            search_or_not = 1;
            await filldriversgridview();
        }

        async Task<long> checkifdriverexistsornot()
        {
            for (int i = 0; i < drivers.Count; i++)
            {
                if ((string.Compare(drivers[i].SH_DRIVER_NAME,driver_name_text_box.Text)==0)&& (string.Compare(drivers[i].SH_DRIVER_CAR_NUMBER,driver_car_number_text_box.Text) == 0)&& (string.Compare(drivers[i].SH_DRIVER_DRIVING_LICENSE_NUMBER,driving_lisence_number_text_box.Text) == 0)&&(string.Compare(drivers[i].SH_DRIVER_TELEPHONE_NUMBER,driver_telephone_number_text_box.Text)==0))
                {
                    return drivers[i].SH_ID;
                }
            }
            return 0;
        }


        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(driver_name_text_box.Text))
            {
                MessageBox.Show("إسم السائق فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrWhiteSpace(driver_car_number_text_box.Text))
            {
                MessageBox.Show(" رقم السيارة فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrWhiteSpace(driving_lisence_number_text_box.Text))
            {
                MessageBox.Show(" رقم رخصة القيادة فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            else if (string.IsNullOrWhiteSpace(driver_telephone_number_text_box.Text))
            {
                MessageBox.Show(" رقم تليفون السائق فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            else

            {
                if (await checkifdriverexistsornot() == 0)
                {
                    await savenewdriver();
                    await filldriversgridview();
                }else
                {
                    MessageBox.Show("هذا السائق موجود", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
            }
        }

        private async void cancel_search_btn_Click(object sender, EventArgs e)
        {
            search_or_not = 0;
            await filldriversgridview();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void addnewdriverform_Load(object sender, EventArgs e)
        {
            await filldriversgridview();
        }
    }
}
