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
        long product_type_index = 0;
        List<SH_FACE_COLOR> FACES = new List<SH_FACE_COLOR>();
        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        List<SH_CLIENTS_PRODUCTS> mproduct = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ITEM_SIZE> mSizes = new List<SH_ITEM_SIZE>();
        List<string> item_types = new List<string>();
        List<SH_TWIST_OF_SIZE> twist_of_sizes = new List<SH_TWIST_OF_SIZE>();
        List<SH_TWIST_OF_TYPE> twist_of_types = new List<SH_TWIST_OF_TYPE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        public addnewclientproduct(SH_CLIENT_COMPANY anyclient)
        {
            InitializeComponent();
            mclient = anyclient;
        }

       
        void filltwistofsizescombobox()
        {
            twist_of_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_TWIST_OF_SIZE ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_sizes.Add(new SH_TWIST_OF_SIZE() {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_TWIST_OF_SIZE_VALUE = long.Parse(reader["SH_TWIST_OF_SIZE_VALUE"].ToString())


                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF SIZES"+ ex.ToString());
               
            }

            if (twist_of_sizes.Count > 0)
            {
                sizes_combo_box.Items.Clear();
                for (int i = 0; i < twist_of_sizes.Count; i++)
                {
                    sizes_combo_box.Items.Add(twist_of_sizes[i].SH_TWIST_OF_SIZE_VALUE.ToString());
                    
                }
            }
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
            }else if (twist_of_radio_btn.Checked)
            {
                murantype = twist_of_radio_btn.Text;
            }else if (easy_open_rado_btn.Checked)
            {
                murantype = easy_open_rado_btn.Text;
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
                    mproduct.Add(new SH_CLIENTS_PRODUCTS() {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString())
                        , SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString()
                        , SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString())
                        , SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()),
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString()
                        , SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString()
                        , SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString()
                        , SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString())
                        , SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString()

                            ,
                        SH_TWIST_SIZE_ID = reader["SH_TWIST_SIZE_ID"].ToString().Trim() == "" ? 0 : long.Parse(reader["SH_TWIST_SIZE_ID"].ToString())
                            ,
                        SH_TWIST_SIZE_NAME = reader["SH_TWIST_SIZE_NAME"].ToString().Trim() == "" ? "0" : reader["SH_TWIST_SIZE_NAME"].ToString(),
                        SH_TWIST_TYPE = reader["SH_TWIST_TYPE"].ToString().Trim() == "" ? "0" : reader["SH_TWIST_TYPE"].ToString(),
                        SH_TWIST_TYPE_ID = reader["SH_TWIST_TYPE_ID"].ToString().Trim() == "" ? 0 : long.Parse(reader["SH_TWIST_TYPE_ID"].ToString()),
                        SH_TWIST_TYPE_KIND = reader["SH_TWIST_TYPE_KIND"].ToString().Trim() == "" ? "0" : reader["SH_TWIST_TYPE_KIND"].ToString()
                    });
                }
                reader.Close();
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
            try
            {
            products_grid_view.Rows.Clear();
            SH_ITEM_SIZE anysize = new SH_ITEM_SIZE();
            
            loadaallsizes();
            if (mproduct.Count > 0)
            {
                
                for (int i = 0; i < mproduct.Count; i++)
                {
                        if (string.Compare(mproduct[i].SH_PRINTING_TYPE, "تويست أوف") == 0)
                        {
                            products_grid_view.Rows.Add(new string[]
                                {
                            mproduct[i].SH_ID.ToString(),
                            mproduct[i].SH_PRODUCT_NAME,
                            "دائري",
                            mproduct[i].SH_PRINTING_TYPE,
                            "القطر",
                            mproduct[i].SH_TWIST_SIZE_NAME.ToString(),
                            "نوع",
                            mproduct[i].SH_TWIST_TYPE_KIND.ToString(),
                            mproduct[i].SH_TWIST_TYPE,
                            mproduct[i].SH_BOTTLE_HEIGHT.ToString(),
                            mproduct[i].SH_SECOND_FACE_NAME
                                });
                        }
                        else
                        {
                            anysize = getsizeobjectbyid(mproduct[i].SH_SIZE_ID);
                        // MessageBox.Show(anysize.SH_SIZE_SHAPE_NAME);
                        if (anysize == null)
                        {

                        }
                        else
                        {
                            products_grid_view.Rows.Add(new string[]
                            {
                            mproduct[i].SH_ID.ToString(),
                            mproduct[i].SH_PRODUCT_NAME,
                            anysize.SH_SIZE_SHAPE_NAME,
                            mproduct[i].SH_PRINTING_TYPE,
                            anysize.SH_SIZE_FIRST_DIAMETER_NAME,
                            anysize.SH_SIZE_FIRST_DIAMETER.ToString(),
                            anysize.SH_SIZE_SECOND_DIAMETER_NAME,
                            anysize.SH_SIZE_SECOND_DIAMETER.ToString(),
                            anysize.SH_SIZE_SURROUNDING.ToString(),
                            mproduct[i].SH_BOTTLE_HEIGHT.ToString(),
                            mproduct[i].SH_SECOND_FACE_NAME });
                        }
                    }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHile SHOWiNG DATA iN DATA GRID VIEW "+ex.ToString());
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
            loadallfacecolors();
            if (FACES.Count <= 0)
            {
            }
            else
            {
                for (int i = 0; i < FACES.Count; i++)
                {
                    faces_combo_box.Items.Add(FACES[i].SH_FACE_COLOR_NAME);
                }
            }
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
            capacity_tect_box.Visible = false;
            capacity_label.Visible = false;
            height_text_box.DropDownStyle = ComboBoxStyle.Simple;
            capacity_tect_box.DropDownStyle = ComboBoxStyle.Simple;
            height_label.Text = "الإرتفاع";
            capacity_label.Text = "السعة";

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
                else if (!(body_radio_btn.Checked || bottom_radio_btn.Checked || head_radio_btn.Checked || twist_of_radio_btn.Checked || easy_open_rado_btn.Checked))
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
                    //else if (string.IsNullOrEmpty(capacity_tect_box.Text))
                    //{
                    //    MessageBox.Show("الرجاء إدخال السعة بالجرامات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    //    saveornot = false;
                    //}
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
                                    query += " SH_PRINTING_TYPE, SH_BOTTLE_CAPACITY, SH_BOTTLE_HEIGHT , ";
                                    query += " SH_SECOND_FACE_ID , SH_SECOND_FACE_NAME , SH_SIZE_ID ,";
                                    query += " SH_SIZE_NAME , SH_TWIST_SIZE_ID,SH_TWIST_SIZE_NAME, ";
                                    query += "SH_TWIST_TYPE,SH_TWIST_TYPE_ID,SH_TWIST_TYPE_KIND )";
                                    query += " VALUES(@SH_CLIENT_NAME,@SH_CLIENT_ID,@SH_PRODUCT_NAME,";
                                    query += " @SH_PRINTING_TYPE,@SH_BOTTLE_CAPACITY,@SH_BOTTLE_HEIGHT, ";
                                    query += " @SH_SECOND_FACE_ID , @SH_SECOND_FACE_NAME , @SH_SIZE_ID , ";
                                    query += " @SH_SIZE_NAME, @SH_TWIST_SIZE_ID,@SH_TWIST_SIZE_NAME ";
                                    query += ",@SH_TWIST_TYPE,@SH_TWIST_TYPE_ID,@SH_TWIST_TYPE_KIND )";
                                    DatabaseConnection myconnection = new DatabaseConnection();
                                    myconnection.openConnection();
                                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                                    cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", mclient.SH_CLIENT_COMPANY_NAME);
                                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                                    cmd.Parameters.AddWithValue("@SH_PRODUCT_NAME", product_name_text_box.Text);
                                    cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", getprintingtype());
                                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_NAME", faces_combo_box.Text);
                                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", FACES[faces_combo_box.SelectedIndex].SH_ID);
                                    if (twist_of_radio_btn.Checked)
                                    {
                                        cmd.Parameters.AddWithValue("@SH_BOTTLE_CAPACITY", 0);
                                        cmd.Parameters.AddWithValue("@SH_BOTTLE_HEIGHT",0);
                                        cmd.Parameters.AddWithValue("@SH_SIZE_ID", 0);
                                        cmd.Parameters.AddWithValue("@SH_SIZE_NAME", 0);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_SIZE_ID", twist_of_sizes[sizes_combo_box.SelectedIndex].SH_ID);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_SIZE_NAME", twist_of_sizes[sizes_combo_box.SelectedIndex].SH_TWIST_OF_SIZE_VALUE);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_TYPE", twist_of_types[capacity_tect_box.SelectedIndex].SH_SHORT_TITLE);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_TYPE_ID", twist_of_types[capacity_tect_box.SelectedIndex].SH_ID);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_TYPE_KIND", item_types[height_text_box.SelectedIndex]);

                                    }
                                    else
                                    {
                                        cmd.Parameters.AddWithValue("@SH_BOTTLE_CAPACITY", 0);
                                        cmd.Parameters.AddWithValue("@SH_BOTTLE_HEIGHT", double.Parse(height_text_box.Text));
                                        cmd.Parameters.AddWithValue("@SH_SIZE_ID", mSizes[sizes_combo_box.SelectedIndex].SH_ID);
                                        cmd.Parameters.AddWithValue("@SH_SIZE_NAME", mSizes[sizes_combo_box.SelectedIndex].SH_SIZE_NAME);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_SIZE_ID", 0);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_SIZE_NAME", 0);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_TYPE", 0);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_TYPE_ID", 0);
                                        cmd.Parameters.AddWithValue("@SH_TWIST_TYPE_KIND", 0);

                                    }
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

        private void body_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (body_radio_btn.Checked)
            {
                product_type_index = 1;
                capacity_tect_box.Visible = false;
                capacity_tect_box.Text = "";
                capacity_label.Visible = false;
                height_text_box.Text = "" ;
                height_text_box.DropDownStyle = ComboBoxStyle.Simple;
                capacity_label.Text = "السعة";
                height_label.Text = "الإرتفاع";
                capacity_label.Visible = false;
                capacity_tect_box.Visible = false;
                capacity_tect_box.DropDownStyle = ComboBoxStyle.Simple;
                fillsizescombobox();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void add_new_face_btn_Click(object sender, EventArgs e)
        {
            addnewfacecolorform myform = new addnewfacecolorform();
            myform.Show();
        }

        private void addnewclientproduct_Activated(object sender, EventArgs e)
        {
            client_name_text_box.Text = mclient.SH_CLIENT_COMPANY_NAME;
            fillfacescombobox();
            mproduct.Clear();
            getallclientproducts();
            productsgridview();
            fillsizescombobox();
        }

        private void add_new_size_btn_Click(object sender, EventArgs e)
        {
            if (twist_of_radio_btn.Checked)
            {
                addnewtwistofsize myform = new addnewtwistofsize();
                myform.Show();
            }else
            {
                addnewsizesform myfrom = new addnewsizesform();
                myfrom.Show();
            }
           
        }

        private void twist_of_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (twist_of_radio_btn.Checked)
            {
                product_type_index = 4;
                filltwistofsizescombobox();
                height_label.Text = "النوع";
                height_text_box.DropDownStyle = ComboBoxStyle.DropDown;
                filltwistoftypescombobox();
                capacity_label.Text = "نوع التويست";
                capacity_label.Visible = true;
                capacity_tect_box.Visible = true;
                capacity_tect_box.DropDownStyle = ComboBoxStyle.DropDown;
                // filltwistoftypeshortwords();
            }
        }

        private void filltwistoftypeshortwords()
        {
            twist_of_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_KIND", item_types[height_text_box.SelectedIndex]);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_types.Add(new SH_TWIST_OF_TYPE() { SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()), SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_LONG_TITLE = reader["SH_LONG_TITLE"].ToString(), SH_SHORT_TITLE = reader["SH_SHORT_TITLE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF TYPES DATA " + ex.ToString());
            }
            if (twist_of_types.Count>0)
            {
                capacity_tect_box.Items.Clear();
                for (int i = 0; i < twist_of_types.Count; i++)
                {
                    capacity_tect_box.Items.Add(twist_of_types[i].SH_SHORT_TITLE);
                }
            }
        }

        private void filltwistoftypescombobox()
        {
            try
            {
                item_types.Clear();

                string query = "SELECT DISTINCT SH_KIND FROM SH_TWIST_OF_TYPE";
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item_types.Add(reader["SH_KIND"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF TYPES KINDS " + ex.ToString());
            }
            
           
            if (item_types.Count > 0)
            {
                height_text_box.Items.Clear();
                for (int i = 0; i < item_types.Count; i++)
                {
                    height_text_box.Items.Add(item_types[i]);
                }
            }
        }

        private void capacity_tect_box_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void bottom_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (bottom_radio_btn.Checked)
            {
                product_type_index = 2;
                capacity_tect_box.Visible = false;
                capacity_tect_box.Text = "";
                capacity_label.Visible = false;
                height_text_box.Text = "";
                height_text_box.DropDownStyle = ComboBoxStyle.Simple;
                capacity_label.Text = "السعة";
                height_label.Text = "الإرتفاع";
                capacity_label.Visible = false;
                capacity_tect_box.Visible = false;
                capacity_tect_box.DropDownStyle = ComboBoxStyle.Simple;
                fillsizescombobox();
            }
        }

        private void head_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (head_radio_btn.Checked)
            {
                product_type_index = 3;
                capacity_tect_box.Visible = false;
                capacity_tect_box.Text = "";
                capacity_label.Visible = false;
                height_text_box.Text = "";
                height_text_box.DropDownStyle = ComboBoxStyle.Simple;
                capacity_label.Text = "السعة";
                height_label.Text = "الإرتفاع";
                capacity_label.Visible = false;
                capacity_tect_box.Visible = false;
                capacity_tect_box.DropDownStyle = ComboBoxStyle.Simple;
                fillsizescombobox();
            }
        }

        private void easy_open_rado_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (easy_open_rado_btn.Checked)
            {
                product_type_index = 5;
                capacity_tect_box.Visible = false;
                capacity_tect_box.Text = "";
                capacity_label.Visible = false;
                height_text_box.Text = "";
                height_text_box.DropDownStyle = ComboBoxStyle.Simple;
                capacity_label.Text = "السعة";
                height_label.Text = "الإرتفاع";
                capacity_label.Visible = false;
                capacity_tect_box.Visible = false;
                capacity_tect_box.DropDownStyle = ComboBoxStyle.Simple;
                fillsizescombobox(); 
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        async Task getalltwistoftypes()
        {
            twist_of_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_KIND", item_types[height_text_box.SelectedIndex]);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_types.Add(new SH_TWIST_OF_TYPE() { SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()), SH_DATA_ENTRY_EMPLOYEE_NAME = reader["SH_DATA_ENTRY_EMPLOYEE_NAME"].ToString(), SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()), SH_DATA_ENTRY_USER_NAME = reader["SH_DATA_ENTRY_USER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_LONG_TITLE = reader["SH_LONG_TITLE"].ToString(), SH_SHORT_TITLE = reader["SH_SHORT_TITLE"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TWIST OF TYPES DATA " + ex.ToString());
            }
        }
        async Task filltwisttypescombobox()
        {
            await getalltwistoftypes();
            capacity_tect_box.DropDownStyle = ComboBoxStyle.DropDown;
            capacity_tect_box.Items.Clear();
            // MessageBox.Show(twist_of_types.Count.ToString());
            if (twist_of_types.Count > 0)
            {
                for (int i = 0; i < twist_of_types.Count; i++)
                {
                    //this.Invoke((MethodInvoker)delegate()
                    //{
                    capacity_tect_box.Items.Add(twist_of_types[i].SH_SHORT_TITLE);
                    //});
                }
            }
        }
        private async void height_text_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            await filltwisttypescombobox();
        }
    }
        

     

      
    }

