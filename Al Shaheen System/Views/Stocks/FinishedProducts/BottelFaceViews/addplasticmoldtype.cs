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
    public partial class addplasticmoldtype : Form
    {
        List<SH_MOLD_TYPES> mold_types = new List<SH_MOLD_TYPES>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addplasticmoldtype()
        {
            InitializeComponent();
        }

        async Task getallmoldtypes()
        {
            mold_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_MOLD_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mold_types.Add(new SH_MOLD_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_MOLD_TYPE_NAME = reader["SH_MOLD_TYPE_NAME"].ToString() });
                }
                reader.Close();        
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL MOLD TYPES "+ex.ToString());
            }
        }

        async void fillallmoldtypesgridview()
        {
            await getallmoldtypes();
            mold_grid_view.Rows.Clear();
            if (mold_types.Count>0)
            {
                for (int i = 0; i < mold_types.Count; i++)
                {
                    mold_grid_view.Rows.Add(new string[] { (i+1).ToString() , mold_types[i].SH_MOLD_TYPE_NAME });
                }

            }
        }

        async Task<long> check_if_mold_type_exists_or_not(string anytext)
        {
            for (int i = 0; i < mold_types.Count; i++)
            {
                if (string.Compare(mold_types[i].SH_MOLD_TYPE_NAME , anytext)==0)
                {
                    return mold_types[i].SH_ID;
                }
            }
            return 0; 
        }


        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(mold_type_text_box.Text))
            {
                MessageBox.Show("لايمكن ان يكون الاسم فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                //savenewmoldtype
                if (await check_if_mold_type_exists_or_not(mold_type_text_box.Text) == 0)
                {
                    try
                    {
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_MOLD_TYPE", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_MOLD_TYPE_NAME", mold_type_text_box.Text);
                        cmd.ExecuteReader();
                        myconnection.closeConnection();
                        MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        fillallmoldtypesgridview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHilE ADDING NEW MOLD TYPE TO DB " + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("النوع موجود ","تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);

                }
            }
        }

        private void addplasticmoldtype_Load(object sender, EventArgs e)
        {
            fillallmoldtypesgridview();
        }
    }
}
