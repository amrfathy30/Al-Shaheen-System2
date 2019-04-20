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
    public partial class addnewclientproduct : Form
    {
        List<SH_FACE_COLOR> FACES = new List<SH_FACE_COLOR>();
        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        List<SH_CLIENTS_PRODUCTS> mproduct = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ITEM_SIZE> mSizes = new List<SH_ITEM_SIZE>();
        public addnewclientproduct(SH_CLIENT_COMPANY anyclient)
        {
            InitializeComponent();
            mclient = anyclient;
        }

        long check_if_product_exists_or_not()
        {

            mproduct.Clear();
            getallclientproducts();

            if (mproduct.Count > 0)
            {
                for (int i = 0; i < mproduct.Count; i++)
                {
                    if ((string.Compare(mproduct[i].SH_CLIENT_NAME, mclient.SH_CLIENT_COMPANY_NAME) == 0) && (string.Compare(mproduct[i].SH_PRINTING_TYPE, getprintingtype()) == 0)&& (string.Compare(mproduct[i].SH_PRODUCT_NAME , product_name_text_box.Text)==0) &&(mproduct[i].SH_BOTTLE_CAPACITY == double.Parse(capacity_tect_box.Text))&&(mproduct[i].SH_BOTTLE_HEIGHT == double.Parse(height_text_box.Text)) && (mproduct[i].SH_SECOND_FACE_ID == FACES[faces_combo_box.SelectedIndex].SH_ID) && (string.Compare(mproduct[i].SH_SECOND_FACE_NAME  , faces_combo_box.Text)==0) && (mproduct[i].SH_SIZE_ID == mSizes[sizes_combo_box.SelectedIndex].SH_ID))
                    {
                        return 1;
                    }
                }
            }
            return 0;

        }


        void loadaallsizes()
        {
            mSizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mSizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(), SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(), SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }
        void fillsizescombobox()
        {
            loadaallsizes();
            sizes_combo_box.Items.Clear();
            if (mSizes.Count > 0)
            {
                string sectext = "";
                for (int i = 0; i < mSizes.Count; i++)
                {
                    if (string.Compare(mSizes[i].SH_SIZE_SECOND_DIAMETER_NAME, "D2") == 0)
                    {
                        sectext = " ";
                    }
                    else
                    {
                        sectext = mSizes[i].SH_SIZE_SECOND_DIAMETER_NAME;
                    }
                    sizes_combo_box.Items.Add(mSizes[i].SH_SIZE_NAME);
                }
            }
        }


        string getprintingtype()
        {
            string murantype = null;
            if (body_radio_btn.Checked)
            {
                murantype = body_radio_btn.Text;
            }
            else if (bottom_radio_btn.Checked)
            {
                murantype = bottom_radio_btn.Text;
            } else if (head_radio_btn.Checked)
            {
                murantype = head_radio_btn.Text;
            }

            return murantype;
        }

        void getallclientproducts()
        {
            
            try
            {
                string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS ";
                      query += " WHERE(SH_CLIENT_ID = @client_id)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@client_id" , mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mproduct.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()) , SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString() , SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString()  , SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString() , SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString() , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS "+ex.ToString());
            }
        }

        SH_ITEM_SIZE getsizeobjectbyid(long s_id)
        {
            if (mSizes.Count > 0)
            {
                for (int i = 0; i < mSizes.Count; i++)
                {
                    if (mSizes[i].SH_ID == s_id)
                    {
                        return mSizes[i];
                    }
                }
            }
            return null;
        }

        void productsgridview()
        {
            //string d1text = "";
            //string d2text = "";
            products_grid_view.Rows.Clear();
            SH_ITEM_SIZE anysize = new SH_ITEM_SIZE();
            loadaallsizes();
            if (mproduct.Count > 0)
            {
                for (int i = 0; i < mproduct.Count; i++)
                {
                    anysize = getsizeobjectbyid(mproduct[i].SH_SIZE_ID);
                   // MessageBox.Show(anysize.SH_SIZE_SHAPE_NAME);
                    if (anysize == null)
                    {

                    }
                    else
                    {
                        products_grid_view.Rows.Add(new string[] { mproduct[i].SH_ID.ToString(), mproduct[i].SH_PRODUCT_NAME, anysize.SH_SIZE_SHAPE_NAME, mproduct[i].SH_PRINTING_TYPE, anysize.SH_SIZE_FIRST_DIAMETER_NAME, anysize.SH_SIZE_FIRST_DIAMETER.ToString(), anysize.SH_SIZE_SECOND_DIAMETER_NAME, anysize.SH_SIZE_SECOND_DIAMETER.ToString(), anysize.SH_SIZE_SURROUNDING.ToString(), mproduct[i].SH_BOTTLE_HEIGHT.ToString(), mproduct[i].SH_SECOND_FACE_NAME });
                    }
                }
            }
        }
        void loadallfacecolors()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_FACE_COLORS", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    FACES.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACES " + ex.ToString());
            }
        }
        void fillfacescombobox()
        {

            FACES.Clear();
            faces_combo_box.Items.Clear();
        //    second_face_combo_box.Items.Clear();
            loadallfacecolors();
            if (FACES.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < FACES.Count; i++)
                {
                    faces_combo_box.Items.Add(FACES[i].SH_FACE_COLOR_NAME);
                   // second_face_combo_box.Items.Add(FACES[i].SH_FACE_COLOR_NAME);
                }
            }
        }
        private void height_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void capacity_tect_box_TextChanged(object sender, EventArgs e)
        {

        }

        private void addnewclientproduct_Load(object sender, EventArgs e)
        {
            client_name_text_box.Text = mclient.SH_CLIENT_COMPANY_NAME;
            fillfacescombobox();
            mproduct.Clear();
            getallclientproducts();
            productsgridview();
            fillsizescombobox();
            //mproduct.SH_BOTTLE_CAPACITY = 400;
            //mproduct.SH_BOTTLE_HEIGHT = 100;
            //mproduct.SH_BOTTLE_SURROUNDING = 123;
            //mproduct.SH_FIRST_DIAMETER = 12.5;
            //mproduct.SH_FIRST_DIAMETER_NAME = "الضلع";
            //mproduct.SH_PRODUCT_SHAPE_TYPE = "المربع";
            //mproduct.SH_PRINTING_TYPE = "بدن";


        }

   
            private void save_new_client_product_btn_Click(object sender, EventArgs e)
        {
            bool saveornot = true;
            if (string.IsNullOrEmpty(product_name_text_box.Text))
            {
                MessageBox.Show(" الرجاء ادخال إسم الصنف ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                saveornot = false;
            }
            else
            {
                if (string.IsNullOrEmpty(faces_combo_box.Text))
                {

                    MessageBox.Show("الرجاء إختيار الوجة الثانى ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    saveornot = false;
                }
                else if (!(body_radio_btn.Checked || bottom_radio_btn.Checked || head_radio_btn.Checked))
                {
                    MessageBox.Show("الرجاء إختيار نوع الطباعة ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    saveornot = false;
                }
                else
                {




                    if (string.IsNullOrEmpty(height_text_box.Text))
                    {
                        if (body_radio_btn.Checked)
                        {
                            MessageBox.Show("الرجاء إدخال إرتقاع العلبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            saveornot = false;
                        }
                        else
                        {
                            height_text_box.Text = 0.ToString();
                        }
                    }
                    else if (string.IsNullOrEmpty(capacity_tect_box.Text))
                    {
                        MessageBox.Show("الرجاء إدخال السعة بالجرامات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        saveornot = false;
                    }
                    else if (string.IsNullOrEmpty(sizes_combo_box.Text))
                    {
                        MessageBox.Show("الرجاء إختيار المقاس", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                        saveornot = false;
                    }
                    else
                    {

                        if (saveornot)
                        {



                            if (check_if_product_exists_or_not() == 1)
                            {
                                MessageBox.Show("هذا الصنف موجود", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                            }
                            else
                                try
                                {
                                    string query = "INSERT INTO SH_CLIENTS_PRODUCTS ";
                                    query += "(SH_CLIENT_NAME, SH_CLIENT_ID, SH_PRODUCT_NAME, ";
                                    query += " SH_PRINTING_TYPE, SH_BOTTLE_CAPACITY, SH_BOTTLE_HEIGHT , SH_SECOND_FACE_ID , SH_SECOND_FACE_NAME , SH_SIZE_ID ,SH_SIZE_NAME)";
                                    query += " VALUES(@SH_CLIENT_NAME,@SH_CLIENT_ID,@SH_PRODUCT_NAME,";
                                    query += " @SH_PRINTING_TYPE,@SH_BOTTLE_CAPACITY,@SH_BOTTLE_HEIGHT,@SH_SECOND_FACE_ID , @SH_SECOND_FACE_NAME , @SH_SIZE_ID , @SH_SIZE_NAME)";
                                    DatabaseConnection myconnection = new DatabaseConnection();
                                    myconnection.openConnection();
                                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                                    cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", mclient.SH_CLIENT_COMPANY_NAME);
                                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                                    cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", product_name_text_box.Text);
                                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", getprintingtype());
                                    cmd.Parameters.AddWithValue("@SH_BOTTLE_CAPACITY", double.Parse(capacity_tect_box.Text));
                                    cmd.Parameters.AddWithValue("@SH_BOTTLE_HEIGHT", double.Parse(height_text_box.Text));
                                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_NAME", faces_combo_box.Text);
                                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", FACES[faces_combo_box.SelectedIndex].SH_ID);
                                    cmd.Parameters.AddWithValue("@SH_SIZE_ID" , mSizes[sizes_combo_box.SelectedIndex].SH_ID);
                                    cmd.Parameters.AddWithValue("@SH_SIZE_NAME" , mSizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME);
                                    cmd.ExecuteNonQuery();
                                    myconnection.closeConnection();
                                    mproduct.Clear();
                                    getallclientproducts();
                                    productsgridview();

                                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("ERROR WHILE SAVING PRODUCT FOR A CLIENT " + ex.ToString());
                                }
                        }
                    }
                }
            }



                    
                }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
        

     

      
    }

