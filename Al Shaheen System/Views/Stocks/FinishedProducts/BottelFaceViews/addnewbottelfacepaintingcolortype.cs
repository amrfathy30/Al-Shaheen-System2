using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class addnewbottelfacepaintingcolortype : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_BOTTLE_FACE_PAINTINGS_TYPES> face_painting_types = new List<SH_BOTTLE_FACE_PAINTINGS_TYPES>();
        
        int ImageID = 0;
        string strFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;


        public addnewbottelfacepaintingcolortype()
        {
            InitializeComponent();
            DefaultImage = pbxImage.Image;
        }

        async Task getallbottelfacepaintingtypes()
        {
            face_painting_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_BOTTLE_FACE_PAINTINGS_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();           
                while (reader.Read())
                {
                    //MessageBox.Show(reader["SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME"].ToString());
                    //MessageBox.Show(reader["SH_TYPE_IMAGE"].ToString().Trim());
                    byte[] ImageArray = null;
                    if (reader["SH_TYPE_IMAGE"].ToString().Trim() == "" || reader["SH_TYPE_IMAGE"].ToString().Trim() == null)
                    {
                       // MessageBox.Show("1");
                        ImageArray = null;
                        face_painting_types.Add(new SH_BOTTLE_FACE_PAINTINGS_TYPES() { SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME = reader["SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TYPE_IMAGE = null, SH_TYPE_SHAPE_NAME = reader["SH_TYPE_SHAPE_NAME"].ToString() });
                        
                    }
                    else
                    {
                        ImageArray = (byte[])reader["SH_TYPE_IMAGE"];
                        if (ImageArray.Length != 0)
                        {
                            ImageByteArray = ImageArray;
                            face_painting_types.Add(new SH_BOTTLE_FACE_PAINTINGS_TYPES() { SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME = reader["SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TYPE_IMAGE = Image.FromStream(new MemoryStream(ImageArray)), SH_TYPE_SHAPE_NAME = reader["SH_TYPE_SHAPE_NAME"].ToString() });
                          //  MessageBox.Show("2");
                        }
                    }
                }
                reader.Close();
                myconnection.closeConnection();
             //   MessageBox.Show(face_painting_types.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTInG BOTTEL FACE TYPES FROM DB " + ex.ToString());
            }
        }


        async Task fillfacepaintingtypesgridview()
        {
            await getallbottelfacepaintingtypes();
            face_painting_types_grid_view.Rows.Clear();
            if (face_painting_types.Count > 0)
            {
                for (int i = 0; i < face_painting_types.Count; i++)
                {
                    face_painting_types_grid_view.Rows.Add(new string[] { (i+1).ToString()  , face_painting_types[i].SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME, face_painting_types[i].SH_TYPE_SHAPE_NAME  });
                }
            }
        }





        private async void addnewbottelfacepaintingcolortype_Load(object sender, EventArgs e)
        {
            await fillfacepaintingtypesgridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                pbxImage.Image = new Bitmap(strFilePath);
                if (txtTitle.Text.Trim().Length == 0)//Auto-Fill title if is empty
                    txtTitle.Text = System.IO.Path.GetFileName(strFilePath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ImageID = 0;
            txtTitle.Clear();
            pbxImage.Image = DefaultImage;
            strFilePath = "";

        }

        private void pbxImage_Click(object sender, EventArgs e)
        {

        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(type_name_txt_box.Text))
            {

            }
            else if (string.IsNullOrWhiteSpace(type_kind_text_box.Text))
            {

            }
            else
            {
                if (txtTitle.Text.Trim() != "")
                {
                    if (strFilePath == "")
                    {

                        if (ImageByteArray == null || ImageByteArray.Length != 0)
                            ImageByteArray = new byte[] { };
                    }
                    else
                    {
                        Image temp = new Bitmap(strFilePath);
                        MemoryStream strm = new MemoryStream();
                        temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                        ImageByteArray = strm.ToArray();
                    }

                    try
                    {
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_BOTTEL_FACE_PAINTING_TYPE", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME", type_name_txt_box.Text);
                        cmd.Parameters.AddWithValue("@SH_TYPE_SHAPE_NAME", type_kind_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_TYPE_IMAGE", ImageByteArray);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                        MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        await fillfacepaintingtypesgridview();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING BOTTEL FACE PAINTING TYPE " + ex.ToString());
                    }

                }else
                {
                    MessageBox.Show("الرجاء إختيار الصورة المراد حفها أولا", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                }
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            type_kind_text_box.Text = "";
            type_name_txt_box.Text = "";
            pbxImage.Image = DefaultImage;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
