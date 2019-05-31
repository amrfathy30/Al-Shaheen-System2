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
    public partial class getallclientproductfilms : Form
    {
        List<SH_CLIENT_COMPANY> mclients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> mproducts = new List<SH_CLIENTS_PRODUCTS>();




        List<SH_CLIENT_PRODUCT_FILM> films = new List<SH_CLIENT_PRODUCT_FILM>();
        List<SH_FILM_CLIENTS_AND_PRODUCTS> film_products = new List<SH_FILM_CLIENTS_AND_PRODUCTS>();
        DatabaseConnection myconnection = new DatabaseConnection();

        int list_index = 0;
        int total_number_of_items = 0;
        Byte[] ImageByteArray;
        public getallclientproductfilms()
        {
            InitializeComponent();
        }

        void getallclientproductfilmsdata()
        {
            films.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENT_PRODUCT_FILM ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] ImageArray;
                    if (reader["SH_FILM_IMAGE"].ToString().Trim() == "" || reader["SH_FILM_IMAGE"].ToString().Trim() == null)
                    {
                        ImageArray = null;
                        films.Add(new SH_CLIENT_PRODUCT_FILM()
                        {
                            SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                            SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                            SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                            SH_FILM_CODE = reader["SH_FILM_CODE"].ToString(),
                            SH_FILM_IMAGE = Image.FromStream(new MemoryStream(ImageArray)),
                            SH_FILM_LENGTH = double.Parse(reader["SH_FILM_LENGTH"].ToString()),
                            SH_FILM_WIDTH = double.Parse(reader["SH_FILM_WIDTH"].ToString()) ,
                            SH_ID = long.Parse(reader["SH_ID"].ToString())
                        });
                    }
                    else
                    {
                        ImageArray = (byte[])reader["SH_FILM_IMAGE"];
                        if (ImageArray.Length != 0)
                        {
                            ImageByteArray = ImageArray;
                            films.Add(new SH_CLIENT_PRODUCT_FILM()
                            {
                                SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                                SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                                SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                                SH_FILM_CODE = reader["SH_FILM_CODE"].ToString(),
                                SH_FILM_IMAGE = Image.FromStream(new MemoryStream(ImageArray)),
                                SH_FILM_LENGTH = double.Parse(reader["SH_FILM_LENGTH"].ToString()),
                                SH_FILM_WIDTH = double.Parse(reader["SH_FILM_WIDTH"].ToString()),
                                SH_ID = long.Parse(reader["SH_ID"].ToString())
                            });
                        }
                    }
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCT FILMS DATA"+ex.ToString());
            }
        }

        void getfilmclientsandproducts(long film_id)
        {
            film_products.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * , (select SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY WHERE SH_ID = SH_CLIENT_ID) AS client_name  , (select SH_PRODUCT_NAME from SH_CLIENTS_PRODUCTS where SH_ID = SH_CLIENT_PRODUCT_ID) AS product_name FROM SH_FILM_CLIENTS_AND_PRODUCTS WHERE SH_CLIENT_PRODUCT_FILM_ID = @SH_CLIENT_PRODUCT_FILM_ID order by SH_CLIENT_ID", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_FILM_ID", film_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    film_products.Add(new SH_FILM_CLIENTS_AND_PRODUCTS() {
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_PRODUCT_FILM_ID = long.Parse(reader["SH_CLIENT_PRODUCT_FILM_ID"].ToString()),
                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                        SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                        SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_NO_BOTTELS_PER_SHEET = long.Parse(reader["SH_NO_BOTTELS_PER_SHEET"].ToString())
                       ,client_name = reader["client_name"].ToString(),
                         product_name = reader["product_name"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING fILM CLIENTS AND PRODUCTS "+ex.ToString());
            }
        }


        void formuicontrol()
        {
            if (films.Count > 0)
            {
                total_number_of_items = films.Count;
                current_counter_label.Text = (total_number_of_items).ToString() + " | " + (list_index + 1).ToString();
                film_code_label.Text = films[list_index].SH_FILM_CODE;
                film_length_label.Text = films[list_index].SH_FILM_LENGTH.ToString();
                film_image_picture_box.Image = films[list_index].SH_FILM_IMAGE;
                film_width_label.Text = films[list_index].SH_FILM_WIDTH.ToString();
                //tableLayoutPanel1.Height = int.Parse(films[list_index].SH_FILM_LENGTH.ToString());
               // tableLayoutPanel1.Width = int.Parse(films[list_index].SH_FILM_WIDTH.ToString());
                getfilmclientsandproducts(films[list_index].SH_ID);
                long client_id = 0;
                for (int i = 0; i < film_products.Count; i++)
                {
                    if (film_products[i].SH_CLIENT_ID != client_id)
                    {
                        ListViewItem myitem = new ListViewItem();
                        myitem.Text = film_products[i].client_name.ToString();
                        myitem.ImageIndex = 0;
                        myitem.IndentCount = 0;
                        client_id = film_products[i].SH_CLIENT_ID;
                        i--;
                        listView1.Items.Add(myitem);

                    }
                    else
                    {
                        ListViewItem myitem = new ListViewItem();
                        myitem.Text = film_products[i].product_name.ToString();
                        myitem.ImageIndex = 1;
                        myitem.IndentCount = 1;
                        //   client_id = film_products[i].SH_CLIENT_PRODUCT_ID;
                        listView1.Items.Add(myitem);
                    }

                }



            }
            else
            {
                film_code_label.Text = "";
                film_length_label.Text = "";
                film_width_label.Text = "";
                film_image_picture_box.Image = null;
                current_counter_label.Text = total_number_of_items.ToString() + " | " + (list_index).ToString();
                result_count_label.Text = "عدد الأفلام الحالية : " + 0.ToString();
            }
        }



        private void getallclientproductfilms_Load(object sender, EventArgs e)
        {
            fillclientscomboboxitems();
            listView1.Items.Clear();
            getallclientproductfilmsdata();
            result_count_label.Text = "عدد الأفلام الحالية : " + films.Count.ToString();
            formuicontrol();


        }
        void fillclientscomboboxitems()
        {
            mclients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENT_COMPANY ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mclients.Add(new SH_CLIENT_COMPANY()
                    {
                        SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString(),
                        SH_CLIENT_COMPANY_MOBILE = reader["SH_CLIENT_COMPANY_MOBILE"].ToString(),
                        SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString(),
                        SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS COMBO DATA " + ex.ToString());
            }

            if (mclients.Count > 0)
            {
                for (int i = 0; i < mclients.Count; i++)
                {
                    clients_combo_box.Items.Add(mclients[i].SH_CLIENT_COMPANY_NAME);
                }
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            if ( list_index == 0 )
            {
                //button3.Enabled = false;
            }else
            {
                //button3.Enabled = true;
                list_index--;
                listView1.Items.Clear();
                formuicontrol();
            }
        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            films.Clear();
            list_index = 0;
            total_number_of_items = 0;
            bool client = false;
            string client_string = "";
            bool product = false;
            string product_string = "";
            bool code = false;
            string code_string = "";
            if (string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                client = false;
            }else
            {
                client = true;
                client_string = " AND SH_CLIENT_ID = @SH_CLIENT_ID ";
            }

            if (string.IsNullOrWhiteSpace(client_products_combo_box.Text))
            {
                product = false;
            }
            else
            {
                product = true;
                product_string = " AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID ";
            }

            if (string.IsNullOrWhiteSpace(code_text_box.Text))
            {
                code = false;
            }else
            {
                code = true;
                code_string = " AND SH_FILM_CODE = @SH_FILM_CODE";
            }
            try
            {
                myconnection.openConnection();
                string query = "select ";
                query += " CPF.* , CPF.* ";
                query += " from SH_CLIENT_PRODUCT_FILM CPF ";
                query += " left ";
                query += " join SH_FILM_CLIENTS_AND_PRODUCTS FCP ";
                query += " ON CPF.SH_ID = FCP.SH_CLIENT_PRODUCT_FILM_ID ";
                query += " WHERE ";
                query += " 1 = 1";
                query += code_string + client_string + product_string;
                query += " ORDER BY FCP.SH_CLIENT_ID";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (code)
                {
                    cmd.Parameters.AddWithValue("@SH_FILM_CODE", code_text_box.Text);
                }
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", mproducts[client_products_combo_box.SelectedIndex].SH_ID);
                }

                if (client)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclients[clients_combo_box.SelectedIndex].SH_ID);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    byte[] ImageArray;
                    if (reader["SH_FILM_IMAGE"].ToString().Trim() == "" || reader["SH_FILM_IMAGE"].ToString().Trim() == null)
                    {
                        ImageArray = null;
                        films.Add(new SH_CLIENT_PRODUCT_FILM()
                        {
                            SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                            SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                            SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                            SH_FILM_CODE = reader["SH_FILM_CODE"].ToString(),
                            SH_FILM_IMAGE = Image.FromStream(new MemoryStream(ImageArray)),
                            SH_FILM_LENGTH = double.Parse(reader["SH_FILM_LENGTH"].ToString()),
                            SH_FILM_WIDTH = double.Parse(reader["SH_FILM_WIDTH"].ToString()),
                            SH_ID = long.Parse(reader["SH_ID"].ToString())
                        });
                    }
                    else
                    {
                        ImageArray = (byte[])reader["SH_FILM_IMAGE"];
                        if (ImageArray.Length != 0)
                        {
                            ImageByteArray = ImageArray;
                            films.Add(new SH_CLIENT_PRODUCT_FILM()
                            {
                                SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                                SH_DATA_ENTRY_EMPLOYEE_ID = long.Parse(reader["SH_DATA_ENTRY_EMPLOYEE_ID"].ToString()),
                                SH_DATA_ENTRY_USER_ID = long.Parse(reader["SH_DATA_ENTRY_USER_ID"].ToString()),
                                SH_FILM_CODE = reader["SH_FILM_CODE"].ToString(),
                                SH_FILM_IMAGE = Image.FromStream(new MemoryStream(ImageArray)),
                                SH_FILM_LENGTH = double.Parse(reader["SH_FILM_LENGTH"].ToString()),
                                SH_FILM_WIDTH = double.Parse(reader["SH_FILM_WIDTH"].ToString()),
                                SH_ID = long.Parse(reader["SH_ID"].ToString())
                            });
                        }
                    }
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR WHILE GETTING FILMS SEARCH RESULT DATA "+ex.ToString());
            }

            result_count_label.Text = "عدد الأفلام الحالية : " + films.Count.ToString();
            listView1.Items.Clear();           
            formuicontrol();



        }
        void fillclientproductscombobox()
        {
            mproducts.Clear();
            try
            {
                myconnection.openConnection();
                string query = "SELECT* FROM SH_CLIENTS_PRODUCTS WHERE SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN(SELECT        SH_ID ";
                query += " FROM SH_CLIENT_COMPANY ";
                query += " WHERE(SH_CLIENT_COMPANY_NAME = 'عام'))  ORDER BY SH_PRODUCT_NAME ASC ";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclients[clients_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mproducts.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString() });

                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS PRODUCTS " + ex.ToString());
            }
            if (mproducts.Count > 0)
            {
                client_products_combo_box.Items.Clear();
                for (int i = 0; i < mproducts.Count; i++)
                {
                    client_products_combo_box.Items.Add(mproducts[i].SH_PRODUCT_NAME);
                }
            }
        }
        private void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                fillclientproductscombobox();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list_index = films.Count - 1;
            listView1.Items.Clear();
            formuicontrol();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((list_index +1 ) > films.Count)
            {
                //button2.Enabled = false;
            }else
            {
                //button2.Enabled = true;
                list_index++;
                listView1.Items.Clear();
                formuicontrol();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            list_index = 0;
            listView1.Items.Clear();
            formuicontrol();
        }
    }
}
