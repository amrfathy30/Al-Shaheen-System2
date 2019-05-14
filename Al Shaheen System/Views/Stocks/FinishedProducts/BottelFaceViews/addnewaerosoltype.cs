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
    public partial class addnewaerosoltype : Form
    {
        List<SH_AEROSOL_TYPE> aerosol_types = new List<SH_AEROSOL_TYPE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewaerosoltype()
        {
            InitializeComponent();
        }


        async Task savenewaerosoltype()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_AEROSOL_TYPE_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_AEROSOL_TYPE_NAME", aerosol_type_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات",MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE ADDING NEW AEROSOL TYPE "+ex.ToString());
            }
        }

        async Task<long> check_if_aerosol_exists()
        {
            if (aerosol_types.Count > 0)
            {
                for (int i = 0; i < aerosol_types.Count; i++)
                {
                    if (string.Compare(aerosol_types[i].SH_AEROSOL_TYPE_NAME , aerosol_type_text_box.Text)==0)
                    {
                        return aerosol_types[i].SH_ID;
                    }
                }
            }
            return 0;
        }


        async Task getallaerosoltypes()
        {
            aerosol_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_AEROSOL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aerosol_types.Add(new SH_AEROSOL_TYPE() { SH_ID= long.Parse(reader["SH_ID"].ToString()), SH_AEROSOL_TYPE_NAME = reader["SH_AEROSOL_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING AEROSOL TYPES "+ex.ToString());
            }
        }

        async Task fillaerosoltypesgridview()
        {
            await getallaerosoltypes();
            aerosol_types_grid_view.Rows.Clear();
            if (aerosol_types.Count > 0)
            {
                for (int i = 0; i < aerosol_types.Count; i++)
                {
                    aerosol_types_grid_view.Rows.Add(new string[] { (i+1).ToString() , aerosol_types[i].SH_AEROSOL_TYPE_NAME });
                }
            }
        }

        private async void addnewaerosoltype_Load(object sender, EventArgs e)
        {
            await fillaerosoltypesgridview();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(aerosol_type_text_box.Text))
            {
                MessageBox.Show("لا يمكن ان يكون نوع الأيروسول فارغ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                if (await check_if_aerosol_exists() == 0)
                {
                    await savenewaerosoltype();
                    await fillaerosoltypesgridview();
                }
                else
                {
                    MessageBox.Show("هذا النوع موجود مسبقا", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
            }
        }
    }
}
