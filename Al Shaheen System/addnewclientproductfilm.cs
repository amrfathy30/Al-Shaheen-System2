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
    public partial class addnewclientproductfilm : Form
    {
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_CLIENT_COMPANY> suggested_clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_PRODUCT_OF_CLIENTS_PARCELS> myproducts = new List<SH_PRODUCT_OF_CLIENTS_PARCELS>();

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public addnewclientproductfilm(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS anyperm )
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anyperm;
        }
        int ImageID = 0;
        String strFilePath = "";
        Image DefaultImage;
        Byte[] ImageByteArray;
        string filenametextbox = "";
        void autosuggestclientnames()
        {
            suggested_clients.Clear();
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
            try
            {
                string query = "";
                myconnection.openConnection();
                if (string.IsNullOrWhiteSpace(client_combo_box.Text))
                {
                   query = "SELECT * FROM SH_CLIENT_COMPANY order by  SH_CLIENT_COMPANY_NAME asc ";

                }else
                {
                   query = "SELECT * FROM SH_CLIENT_COMPANY where SH_CLIENT_COMPANY_NAME like N'%"+client_combo_box.Text+"%' order by  SH_CLIENT_COMPANY_NAME asc  ";

                }
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suggested_clients.Add(new SH_CLIENT_COMPANY()
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
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS INFO "+ex.ToString());
            }
            if (suggested_clients.Count>0)
            {
                for (int i = 0; i < suggested_clients.Count; i++)
                {
                    coll.Add(suggested_clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }

            client_combo_box.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            client_combo_box.AutoCompleteSource = AutoCompleteSource.CustomSource;
            client_combo_box.AutoCompleteCustomSource = coll;


        }
        void fillclientscomboboxitems()
        {
            clients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENT_COMPANY ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY()
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

            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    client_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }


        }

        void fillclientproductscombobox()
        {
            client_products.Clear();
            try
            {
                myconnection.openConnection();
                string query = "SELECT* FROM SH_CLIENTS_PRODUCTS WHERE SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN(SELECT        SH_ID ";
                query += " FROM SH_CLIENT_COMPANY ";
                query += " WHERE(SH_CLIENT_COMPANY_NAME = 'عام'))  ORDER BY SH_PRODUCT_NAME ASC " ;
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[client_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString() });

                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS PRODUCTS "+ex.ToString());
            }
            if (client_products.Count > 0)
            {
                client_product_combo_box.Items.Clear();
                for (int i = 0; i < client_products.Count; i++)
                {
                    client_product_combo_box.Items.Add(client_products[i].SH_PRODUCT_NAME);
                }
            }
        }
        async Task autogeneratebottomaddtion_permission_number()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_PRODUCT_FILM_CODE  ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    if (string.IsNullOrWhiteSpace(reader["lastedid"].ToString()))
                    {
                        reader.Close();
                    }
                    else
                    {
                        mycount = long.Parse(reader["lastedid"].ToString());
                    }
                }

                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                mycount = 0;
                //MessageBox.Show("Error while getting new permission number " + ex.ToString());
            }


            if (mycount == 0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                permissionnumber += "PRODUCT_FILM-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                film_code_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber += "PRODUCT_FILM-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                film_code_text_box.Text = permissionnumber;
            }
        }


        private void savenewpermssionnumber()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_PRODUCT_FILM_CODE (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER", 1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        private async void addnewclientproductfilm_Load(object sender, EventArgs e)
        {
            await autogeneratebottomaddtion_permission_number();
            fillclientscomboboxitems();
        }

        private void client_combo_box_TextChanged(object sender, EventArgs e)
        {
            // fillclientscomboboxitems();
           // autosuggestclientnames();
        }

        private void client_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(client_combo_box.Text))
            {
                fillclientproductscombobox();
            }          
        }

        void fillclientprpductslisyview()
        {
            dataGridView1.Rows.Clear();
            if (myproducts.Count > 0)
            {
                for (int i = 0; i < myproducts.Count; i++)
                {
                    
                    dataGridView1.Rows.Add(new string[] {
                        (i + 1).ToString(),
                        myproducts[i].SH_CLIENT_NAME,
                        myproducts[i].SH_CLIENT_PRODUCT_NAME,
                        myproducts[i].SH_NO_BOTTLES_PER_SHEET.ToString(),
                    });
                }
            }
        }

        long savefilmdataheader()
        {
            try
            {
                if (strFilePath == "")
                {
                    if (ImageByteArray.Length != 0)
                        ImageByteArray = new byte[] { };
                }
                else
                {
                    Image temp = new Bitmap(strFilePath);
                    MemoryStream strm = new MemoryStream();
                    temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ImageByteArray = strm.ToArray();
                }
                myconnection.openConnection();
                string query = "INSERT INTO SH_CLIENT_PRODUCT_FILM ";
                query += "(SH_FILM_CODE, SH_FILM_LENGTH, SH_FILM_WIDTH, SH_FILM_IMAGE, SH_ADDITION_DATE, SH_DATA_ENTRY_USER_ID, SH_DATA_ENTRY_EMPLOYEE_ID) ";
                query += "VALUES(@SH_FILM_CODE,@SH_FILM_LENGTH,@SH_FILM_WIDTH,@SH_FILM_IMAGE,@SH_ADDITION_DATE,@SH_DATA_ENTRY_USER_ID,@SH_DATA_ENTRY_EMPLOYEE_ID)";
                query += " SELECT SCOPE_IDENTITY() AS myidentity";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_FILM_CODE",film_code_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_FILM_LENGTH",double.Parse(film_length_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_FILM_WIDTH", double.Parse(film_width_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_FILM_IMAGE", ImageByteArray);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);

                SqlDataReader reader = cmd.ExecuteReader();
                long row_id = 0;
                if (reader.Read())
                {
                    row_id = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return row_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING FILE DATA HEADER "+ex.ToString());
            }
            return 0;
        }
        void savefileclientfilmproducts(long film_id)
        {

            if (myproducts.Count > 0)
            {
                    
                for (int i = 0; i < myproducts.Count; i++)
                {
                    try
                    {
                        myconnection.openConnection();
                        string query = "INSERT INTO SH_FILM_CLIENTS_AND_PRODUCTS ";
                        query += "( SH_DATA_ENTRY_EMPLOYEE_ID, SH_DATA_ENTRY_USER_ID, SH_NO_BOTTELS_PER_SHEET, SH_CLIENT_PRODUCT_ID, SH_CLIENT_ID, SH_ADDITION_DATE, SH_CLIENT_PRODUCT_FILM_ID) ";
                        query += " VALUES( @SH_DATA_ENTRY_EMPLOYEE_ID, @SH_DATA_ENTRY_USER_ID, @SH_NO_BOTTELS_PER_SHEET, @SH_CLIENT_PRODUCT_ID, @SH_CLIENT_ID, @SH_ADDITION_DATE, @SH_CLIENT_PRODUCT_FILM_ID) ";
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                        cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_NO_BOTTELS_PER_SHEET", myproducts[i].SH_NO_BOTTLES_PER_SHEET);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", myproducts[i].SH_CLIENT_PRODUCT_ID);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID", myproducts[i].SH_CLIENT_ID);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_FILM_ID", film_id);
                        cmd.ExecuteNonQuery();
                        myconnection.closeConnection();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE SAVING PRODUCTS DATA "+ex.ToString());
                    }
                }
               
            }
           


        }


        private void addnewclientproductbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(client_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم العميل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrEmpty(client_product_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم الصنف", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else if (string.IsNullOrEmpty(no_of_products_per_sheet_text_box.Text))
            {
                MessageBox.Show("الرجاء إدخال قيمة عدد العلب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            {
                
               
                    myproducts.Add(new SH_PRODUCT_OF_CLIENTS_PARCELS() {
                        SH_CLIENT_ID = clients[client_combo_box.SelectedIndex].SH_ID,
                        SH_CLIENT_NAME = clients[client_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                        SH_NO_BOTTLES_PER_SHEET = long.Parse(no_of_products_per_sheet_text_box.Text),
                        SH_CLIENT_PRODUCT_ID = client_products[client_product_combo_box.SelectedIndex].SH_ID,
                        SH_CLIENT_PRODUCT_NAME = client_products[client_product_combo_box.SelectedIndex].SH_PRODUCT_NAME
                    });

                fillclientprpductslisyview();
            }
        }

        private void browse_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                strFilePath = ofd.FileName;
                film_picture_box.Image = resizeImage(new Bitmap(strFilePath), new Size(843, 612));
                if (filenametextbox.Trim().Length == 0)//Auto-Fill title if is empty
                    filenametextbox = System.IO.Path.GetFileName(strFilePath);
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void removefromlistbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >0)
            {
                myproducts.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            fillclientprpductslisyview();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            bool can_save_or_not = true;
            double testnumber = 0;
            if (string.IsNullOrWhiteSpace(filenametextbox))
            {
                can_save_or_not = false;
            }
            else if (string.IsNullOrWhiteSpace(film_length_text_box.Text))
            {
                can_save_or_not = false;
            } else if (string.IsNullOrWhiteSpace(film_width_text_box.Text))
            {
                can_save_or_not = false;
            } else if (myproducts.Count == 0)
            {
                can_save_or_not = false;
            } else if (!double.TryParse(film_length_text_box.Text,out testnumber))
            {
                can_save_or_not = false;
            }
            else if (!double.TryParse(film_width_text_box.Text, out testnumber))
            {
                can_save_or_not = false;
            }

            if (can_save_or_not)
            {
                //can save 
                savenewpermssionnumber();
                long mydata = savefilmdataheader();
                savefileclientfilmproducts(mydata);
                MessageBox.Show("تم الحفظ", "معلومات", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                this.Hide();
                addnewclientproductfilm myform = new addnewclientproductfilm(mEmployee, mAccount, mPermission);
                myform.Show();
                this.Close();
            } else
            {
                MessageBox.Show("لا يمكن الحفظ لعدم إكتمال البيانات ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            addnewclientproductfilm myform = new addnewclientproductfilm(mEmployee,mAccount,mPermission);
            myform.Show();
            this.Close();
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
