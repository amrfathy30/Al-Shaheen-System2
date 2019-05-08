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
    public partial class addnewbottlefacetype : Form
    {
        List<SH_BOTTLE_FACE_TYPES> face_types = new List<SH_BOTTLE_FACE_TYPES>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewbottlefacetype()
        {
            InitializeComponent();
        }


        async Task getallbottelfacetypes()
        {
            face_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_BOTTEL_TYPES" , DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    face_types.Add(new SH_BOTTLE_FACE_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_BOTTLE_TYPE_NAME = reader["SH_BOTTLE_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACE TYPES FROM DB "+ex.ToString());
            }      
        }

        async Task<long> checkifexistsornot()
        {
            if (face_types.Count >0)
            {
                for (int i = 0; i < face_types.Count; i++)
                {
                    if (string.Compare(face_types[i].SH_BOTTLE_TYPE_NAME,bottel_face_type_text_box.Text)==0)
                    {
                        return face_types[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        async Task fillfacetypesgridview()
        {
            face_types_grid_view.Rows.Clear();
            await getallbottelfacetypes();
            if (face_types.Count >0)
            {
                for (int i = 0; i < face_types.Count; i++)
                {
                    face_types_grid_view.Rows.Add(new string[] { (i+1).ToString() , face_types[i].SH_BOTTLE_TYPE_NAME });
                }
            }
        }


        async Task savenewfacetype()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_FACE_TYPE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_BOTTLE_TYPE_NAME", bottel_face_type_text_box.Text);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
                MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILe ADDING NEW FACE TYPE " + ex.ToString());
            }
        }



        private void new_btn_Click(object sender, EventArgs e)
        {
            bottel_face_type_text_box.Text = "";
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bottel_face_type_text_box.Text))
            {
                MessageBox.Show("الرجاء كتابة نوع الوش ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                if (await checkifexistsornot() == 0)
                {
                    await savenewfacetype();
                    await fillfacetypesgridview();
                }
                else
                {
                    MessageBox.Show("هذا النوع موجود من قبل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private async void addnewbottlefacetype_Load(object sender, EventArgs e)
        {
            await fillfacetypesgridview();
        }
    }
}
