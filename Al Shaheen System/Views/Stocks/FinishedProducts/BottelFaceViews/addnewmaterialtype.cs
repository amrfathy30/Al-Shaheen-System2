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
    public partial class addnewmaterialtype : Form
    {
        List<SH_MATERIAL_TYPES> material_types = new List<SH_MATERIAL_TYPES>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewmaterialtype()
        {
            InitializeComponent();
        }

        async Task savenewmaterialtype()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_MATERIAL_TYPE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_MATERIAL_TYPE_NAME", material_type_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING NEW MATERIAL TYPE "+ex.ToString());
            }
        }


        async Task getallmaterialtypes()
        {
            material_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_MATERIAL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    material_types.Add(new SH_MATERIAL_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MATERIAL_TYPE_NAME = reader["SH_MATERIAL_TYPE_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle ADDING NEW " + ex.ToString());
            }
        }

        async Task fillmaterialtypescombobox()
        {
            await getallmaterialtypes();
            material_types_grid_view.Rows.Clear();
            if (material_types.Count > 0)
            {
                for (int i = 0; i < material_types.Count; i++)
                {
                    material_types_grid_view.Rows.Add((i+1).ToString(),material_types[i].SH_MATERIAL_TYPE_NAME);
                }
            }
        }
        private async void addnewmaterialtype_Load(object sender, EventArgs e)
        {
            await fillmaterialtypescombobox();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(material_type_text_box.Text))
            {
                MessageBox.Show("لا يمكن الحفظ  الرجاء كتابة اسم الخامة", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                await savenewmaterialtype();
                await fillmaterialtypescombobox();
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            material_type_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
