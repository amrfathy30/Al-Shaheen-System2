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
    public partial class addnewfaceproduct : Form
    {
        List<SH_SCREW_USAGE> screw_usages = new List<SH_SCREW_USAGE>();
        List<SH_SCREW_SIZE> screw_sizes = new List<SH_SCREW_SIZE>();
        List<SH_BOTTLE_FACE_TYPES> general_types = new List<SH_BOTTLE_FACE_TYPES>();
        List<SH_MOLD_SIZE> sizes = new List<SH_MOLD_SIZE>();
        List<SH_HAND_TYPES> hand_types = new List<SH_HAND_TYPES>();
        List<SH_BOTTLE_FACE_PAINTINGS_TYPES> face_painting_types = new List<SH_BOTTLE_FACE_PAINTINGS_TYPES>();
        List<SH_AEROSOL_SIZE> aerosol_sizes = new List<SH_AEROSOL_SIZE>();
        List<SH_AEROSOL_TYPE> aerosol_types = new List<SH_AEROSOL_TYPE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        Byte[] ImageByteArray;

        int face_product_type = 0;


        public addnewfaceproduct()
        {
            InitializeComponent();
        }

        async Task getallhandsizes()
        {
            aerosol_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_AEROSOL_SIZES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aerosol_sizes.Add(new SH_AEROSOL_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_AEROSOL_SIZE_VALUE = long.Parse(reader["SH_AEROSOL_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING HaND SIZES " + ex.ToString());
            }
        }

        async Task fillhandsizesgridview()
        {
            aerosol_size_text_box.Items.Clear();
            await getallhandsizes();
            if (aerosol_sizes.Count > 0)
            {
                for (int i = 0; i < aerosol_sizes.Count; i++)
                {
                    aerosol_size_text_box.Items.Add(aerosol_sizes[i].SH_AEROSOL_SIZE_VALUE.ToString());
                }
            }
        }


        async Task getallscrew_sizes()
        {
            screw_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SCREW_SIZES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_sizes.Add(new SH_SCREW_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SCREW_SIZE_VALUE = long.Parse(reader["SH_SCREW_SIZE_VALUE"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING " + ex.ToString());
            }
        }
        async Task fillscrewsizesgridview()
        {
            await getallscrew_sizes();
            Screw_size_combo_box.Items.Clear();
            if (screw_sizes.Count > 0)
            {
                for (int i = 0; i < screw_sizes.Count; i++)
                {
                    Screw_size_combo_box.Items.Add(screw_sizes[i].SH_SCREW_SIZE_VALUE.ToString());
                }
            }
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
            printing_shape_type_combo_box.Items.Clear();
            if (face_painting_types.Count > 0)
            {
                for (int i = 0; i < face_painting_types.Count; i++)
                {
                    printing_shape_type_combo_box.Items.Add(face_painting_types[i].SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME);
                }
            }
        }


        async Task getallhandtypes()
        {
            hand_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SH_HAND_TYPES ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hand_types.Add(new SH_HAND_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TYPE_HAND_SIZE_ID = long.Parse(reader["SH_TYPE_HAND_SIZE_ID"].ToString()), SH_TYPE_HAND_SIZE_NAME = reader["SH_TYPE_HAND_SIZE_NAME"].ToString(), SH_TYPE_MATERIAL_TYPE = reader["SH_TYPE_MATERIAL_TYPE"].ToString(), SH_TYPE_NAME = reader["SH_TYPE_NAME"].ToString(), SH_TYPE_PILLOW_COLOR_ID = long.Parse(reader["SH_TYPE_PILLOW_COLOR_ID"].ToString()), SH_TYPE_PILLOW_COLOR_NAME = reader["SH_TYPE_PILLOW_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING All hAnd TYPES " + ex.ToString());
            }
        }
        async Task fillhandtypesgridview()
        {
            await getallhandtypes();
            hand_type_combo_box.Items.Clear();
            if (hand_types.Count > 0)
            {
                for (int i = 0; i < hand_types.Count; i++)
                {
                    hand_type_combo_box.Items.Add(hand_types[i].SH_TYPE_NAME);
                }
            }
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
                    sizes.Add(new SH_MOLD_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MOLD_SIZE_VALUE = double.Parse(reader["SH_MOLD_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL MOLD SIZES FORM DB " + ex.ToString());
            }
        }
        async Task fillsizesgridview()
        {
            await getallsizesdata();
            mold_sizes_combo_box.Items.Clear();
            try
            {
                if (sizes.Count > 0)
                {
                    for (int i = 0; i < sizes.Count; i++)
                    {
                        mold_sizes_combo_box.Items.Add(Math.Round(sizes[i].SH_MOLD_SIZE_VALUE, 1).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE FILLING DATA GRiD VIEW " + ex.ToString());
            }
        }

        async Task getallbottelfacetypes()
        {
            general_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_BOTTEL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    general_types.Add(new SH_BOTTLE_FACE_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_BOTTLE_TYPE_NAME = reader["SH_BOTTLE_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACE TYPES FROM DB " + ex.ToString());
            }
        }

        async Task fillfacetypesgridview()
        {
            bottel_face_type_combo_box.Items.Clear();
            await getallbottelfacetypes();
            if (general_types.Count > 0)
            {
                for (int i = 0; i < general_types.Count; i++)
                {
                    bottel_face_type_combo_box.Items.Add(general_types[i].SH_BOTTLE_TYPE_NAME);
                }
            }
        }
        async Task get_all_usages()
        {
            screw_usages.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_USAGES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_usages.Add(new SH_SCREW_USAGE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SCREW_USAGE_NAME = reader["SH_SCREW_USAGE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING USAGES DATA " + ex.ToString());
            }
        }
        async Task fillusagesgridview()
        {
            await get_all_usages();
            Screw_usage_combo_box.Items.Clear();
            if (screw_usages.Count > 0)
            {
                for (int i = 0; i < screw_usages.Count; i++)
                {
                    Screw_usage_combo_box.Items.Add(screw_usages[i].SH_SCREW_USAGE_NAME);
                }
            }
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
                    aerosol_types.Add(new SH_AEROSOL_TYPE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_AEROSOL_TYPE_NAME = reader["SH_AEROSOL_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING AEROSOL TYPES " + ex.ToString());
            }
        }

        async Task fillaerosoltypesgridview()
        {
            await getallaerosoltypes();
            aerosol_type_text_box.Items.Clear();
            if (aerosol_types.Count > 0)
            {
                for (int i = 0; i < aerosol_types.Count; i++)
                {
                    aerosol_type_text_box.Items.Add(aerosol_types[i].SH_AEROSOL_TYPE_NAME);
                }
            }
        }
        private async void addnewfaceproduct_Load(object sender, EventArgs e)
        {
            //  Cursor 
            mold_panel.Visible = false;
            qlawooz_panel.Visible = false;
            printing_panel.Visible = false;
            panel1.Visible = false;
       
            panel3.Visible = true;

            await fillfacetypesgridview();
            await fillsizesgridview();
            await fillhandtypesgridview();
            await fillfacepaintingtypesgridview();
            await fillscrewsizesgridview();
            await fillusagesgridview();
            await fillhandsizesgridview();
            await fillaerosoltypesgridview();
        }

        private void printing_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bottel_face_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            face_product_type = bottel_face_type_combo_box.SelectedIndex;
            if (face_product_type==0)
            {
                mold_panel.Visible = true;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = false;
                panel1.Visible = false;
               
                panel3.Visible = false;

            }else if (face_product_type == 1)
            {
                mold_panel.Visible = false;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = true;
                panel1.Visible = false;
               
                panel3.Visible = false;
            }else if (face_product_type == 2)
            {
                mold_panel.Visible = false;
                panel1.Visible = false;

                panel3.Visible = false;
                printing_panel.Visible = false;
                qlawooz_panel.Visible = true;
               
                
            }else if (face_product_type == 3)
            {
                panel1.Show();
                panel1.Visible = true;
                mold_panel.Visible = false;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = false;
                
                panel3.Visible = false;  
            }
            else if(face_product_type == 4)
            {
                mold_panel.Visible = false;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = false;
                panel1.Visible = false;
                
                panel3.Visible = false;
            }
        }

        private void printing_shape_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            printing_image_box.Image = face_painting_types[printing_shape_type_combo_box.SelectedIndex].SH_TYPE_IMAGE;
        }
    }
}
