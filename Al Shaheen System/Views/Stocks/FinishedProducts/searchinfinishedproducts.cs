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
    public partial class searchinfinishedproducts : Form
    {
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_CLIENTS_PRODUCTS> products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT> cans_parcels = new List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT>();
        List<SH_CONTAINER_OF_BOTTOM> bottoms = new List<SH_CONTAINER_OF_BOTTOM>();
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
        long totalnumber = 0;
        string container = "";
        long totalnumberofcontainer = 0;
        DateTime addition_date = DateTime.Now;

        public searchinfinishedproducts()
        {
            InitializeComponent();
        }

        private void searchinfinishedproducts_Load(object sender, EventArgs e)
        {

        }


       void loadbottomscontainers(long printing_type_id , long t1 , long t2)
        {
            string query = null;
            try
            {
                if (printing_type_id == 0)
                {
                    query = "SELECT *FROM SH_CONTAINER_OF_BOTTOM WHERE SH_SPECIFICATION_OF_BOTTOM_ID IN (SELECT SH_ID FROM SH_SPECIFICATION_OF_BOTTOM WHERE SH_PRINTING_TYPE = @SH_PRINTING_TYPE AND SH_FIRST_FACE_ID = @SH_FIRST_FACE_ID AND SH_SECOND_FACE_ID = @SH_SECOND_FACE_ID)";

                }
                else
                {
                     query = "SELECT *FROM SH_CONTAINER_OF_BOTTOM WHERE SH_SPECIFICATION_OF_BOTTOM_ID IN (SELECT SH_ID FROM SH_SPECIFICATION_OF_BOTTOM WHERE SH_PRINTING_TYPE = @SH_PRINTING_TYPE AND SH_CLIENT_ID = @SH_CLIENT_ID AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID)";

                }
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", printing_type_id);
                if (printing_type_id==0)
                {
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_ID" , t1);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID" , t2);
                }else
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", t1);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", t2);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bottoms.Add(new SH_CONTAINER_OF_BOTTOM() { SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_QUANTITY_OF_BOTTOM_ID = long.Parse(reader["SH_QUANTITY_OF_BOTTOM_ID"].ToString()) , SH_SPECIFICATION_OF_BOTTOM_ID = long.Parse(reader["SH_SPECIFICATION_OF_BOTTOM_ID"].ToString())  , SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()) });

                    totalnumber += long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString());
                    totalnumberofcontainer++;
                    addition_date = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString());
                    container = reader["SH_CONTAINER_NAME"].ToString();
                }
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING BOTTOM CONTAINERS FROM DB "+ex.ToString());
            }

        }

        void loadeasyopenscontainers(long printing_type_id, long t1, long t2)
        {
            string query = null;
            try
            {
                if (printing_type_id == 0)
                {
                    query = "SELECT *FROM SH_CONTAINER_OF_EASY_OPEN WHERE SH_SPECIFICATION_OF_EASY_OPEN_ID IN (SELECT SH_ID FROM SH_SPECIFICATION_OF_EASY_OPEN WHERE SH_PRINTING_TYPE = @SH_PRINTING_TYPE AND SH_FIRST_FACE_ID = @SH_FIRST_FACE_ID AND SH_SECOND_FACE_ID = @SH_SECOND_FACE_ID)";

                }
                else
                {
                    query = "SELECT *FROM SH_CONTAINER_OF_EASY_OPEN WHERE SH_SPECIFICATION_OF_EASY_OPEN_ID IN (SELECT SH_ID FROM SH_SPECIFICATION_OF_EASY_OPEN WHERE SH_PRINTING_TYPE = @SH_PRINTING_TYPE AND SH_CLIENT_ID = @SH_CLIENT_ID AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID)";

                }
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE", printing_type_id);
                if (printing_type_id == 0)
                {
                    cmd.Parameters.AddWithValue("@SH_FIRST_FACE_ID", t1);
                    cmd.Parameters.AddWithValue("@SH_SECOND_FACE_ID", t2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_ID", t1);
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", t2);
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bottoms.Add(new SH_CONTAINER_OF_BOTTOM() { SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_QUANTITY_OF_BOTTOM_ID = long.Parse(reader["SH_QUANTITY_OF_BOTTOM_ID"].ToString()), SH_SPECIFICATION_OF_BOTTOM_ID = long.Parse(reader["SH_SPECIFICATION_OF_BOTTOM_ID"].ToString()), SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()) });

                    totalnumber += long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString());
                    totalnumberofcontainer++;
                    addition_date = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString());
                    container = reader["SH_CONTAINER_NAME"].ToString();
                }
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING BOTTOM CONTAINERS FROM DB " + ex.ToString());
            }

        }




        void loadcansparcels(long client_id , long  product_id)
        {
            totalnumber = 0;
             container = "";
            totalnumberofcontainer = 0;
            addition_date = DateTime.Now;
            try
            {
                string query = "SELECT * FROM SH_ADDED_PARCELS_OF_FINISHED_PRODUCT WHERE SH_CLIENT_ID = @SH_CLIENT_ID AND SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID" , client_id);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID" , product_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cans_parcels.Add(new SH_ADDED_PARCELS_OF_FINISHED_PRODUCT() { SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID = long.Parse(reader["SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID"].ToString()) , SH_ADDING_PERMISSION_NUMBER = reader["SH_ADDING_PERMISSION_NUMBER"].ToString() , SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString())  , SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID = long.Parse(reader["SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID"].ToString()) , SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()) , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString() , SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()) , SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_LAST_RECORD_NUMBER_OF_CANS = long.Parse(reader["SH_LAST_RECORD_NUMBER_OF_CANS"].ToString()) , SH_NUMBER_OF_CANS_HEIGHT = long.Parse(reader["SH_NUMBER_OF_CANS_HEIGHT"].ToString()) , SH_NUMBER_OF_CANS_LENGTH = long.Parse(reader["SH_NUMBER_OF_CANS_LENGTH"].ToString()) , SH_NUMBER_OF_CANS_WIDTH = long.Parse(reader["SH_NUMBER_OF_CANS_WIDTH"].ToString()) , SH_STOCK_ID = long.Parse(reader["SH_STOCK_ID"].ToString()) , SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() , SH_TOTAL_NUMBER_OF_CANS = long.Parse(reader["SH_TOTAL_NUMBER_OF_CANS"].ToString()) , SH_WORK_ORDER_NUMBER = reader["SH_WORK_ORDER_NUMBER"].ToString()} );
                    
                    totalnumber += long.Parse(reader["SH_TOTAL_NUMBER_OF_CANS"].ToString());
                    totalnumberofcontainer++;
                    addition_date = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString());
                }
                container = "بالتة";
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CANS PARCELS FORM DB "+ex.ToString());
            }
        }

        void loadclientsdata()
        {
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(),  SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
            }
        }

        //void fill_clients_combo_box()
        //{
        //    loadclientsdata();
        //    f1_combo_box.Items.Clear();
        //    if (clients.Count > 0)
        //    {
        //        for (int i = 0; i < clients.Count; i++)
        //        {
        //            f1_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
        //        }
        //    }
        //}
        //void loadallfacecolors()
        //{
        //    try
        //    {
        //        DatabaseConnection myconnection = new DatabaseConnection();
        //        myconnection.openConnection();
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM SH_FACE_COLORS", DatabaseConnection.mConnection);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            faces.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
        //        }
        //        myconnection.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR WHILE GETTING FACES " + ex.ToString());
        //    }
        //}


        //private void fillfacescombobox()
        //{
        //    faces.Clear();
        //    f1_combo_box.Items.Clear();
        //    f2_combo_box.Items.Clear();
        //    loadallfacecolors();
        //    if (faces.Count <= 0)
        //    {

        //    }
        //    else
        //    {
        //        for (int i = 0; i < faces.Count; i++)
        //        {
        //            f1_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
        //            f2_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
        //        }
        //    }
        //}
        //private void finished_product_types_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (finished_product_types_combo_box.SelectedIndex)
        //    {
        //        case 0: // cans
        //            {
        //                f1_label.Text = "إسم العميل";
        //                f2_label.Text = "إسم الصنف";
        //                container_name_text_box.Text = "بالتة";
        //                fill_clients_combo_box();
        //                t_combo_box.Visible = false;
        //                t_label.Visible = false;
        //                break;
        //            }
        //        case 1://bottom
        //            {
        //                t_label.Text = "نوع القاع";
        //                t_combo_box.Items.Clear();
                        
        //                t_combo_box.Items.Add("مورنش");
        //                t_combo_box.Items.Add("مطبوع");
        //                t_combo_box.Visible = true;
        //                t_label.Visible = true;

        //                break;
        //            }
        //        case 2://easy_open
        //            {
        //                t_label.Text = "نوع الايزى اوبن";
        //                t_combo_box.Items.Clear();

        //                t_combo_box.Items.Add("مورنش");
        //                t_combo_box.Items.Add("مطبوع");
        //                t_combo_box.Visible = true;
        //                t_label.Visible = true;
        //                break;
        //            }
        //        case 3://rlt
        //            {
        //                t_label.Text = "نوع ال RLT";
        //                t_combo_box.Items.Clear();

        //                t_combo_box.Items.Add("مورنش");
        //                t_combo_box.Items.Add("مطبوع");
        //                t_combo_box.Visible = true;
        //                t_label.Visible = true;
        //                break;
        //            }
        //        case 4://bill off
        //            {
        //                t_label.Text = " نوع ال بيل اوف";
        //                t_combo_box.Items.Clear();

        //                t_combo_box.Items.Add("مورنش");
        //                t_combo_box.Items.Add("مطبوع");
        //                t_combo_box.Visible = true;
        //                t_label.Visible = true;
        //                break;
        //            }
               
        //        default:
        //            break;
        //    }
        //}
        //void gettingproductsbyclientid()
        //{
        //    products.Clear();
        //    if (string.IsNullOrEmpty(f1_combo_box.Text))
        //    {

        //    }
        //    else
        //    {
        //        try
        //        {
        //            string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS WHERE(SH_CLIENT_ID = @CLIENT_ID)";
        //            DatabaseConnection myconnection = new DatabaseConnection();
        //            myconnection.openConnection();
        //            SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
        //            cmd.Parameters.AddWithValue("@CLIENT_ID", clients[f1_combo_box.SelectedIndex].SH_ID);
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                //getting products data
        //                products.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()) });
        //            }

        //            myconnection.closeConnection();
        //        }
        //        catch (Exception)
        //        {
        //            MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS");
        //        }
        //    }
        //}

        //void fillproductscombobox()
        //{
        //    f2_combo_box.Items.Clear();
        //    gettingproductsbyclientid();
        //    for (int i = 0; i < products.Count; i++)
        //    {
        //        f2_combo_box.Items.Add(products[i].SH_PRODUCT_NAME);
        //    }
        //}
        //private void f1_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    switch (finished_product_types_combo_box.SelectedIndex)
        //    {
        //        case 0: // cans
        //            {
        //                f2_label.Text = "إسم الصنف";
        //                fillproductscombobox();
        //                break;
        //            }
        //        case 1://bottom
        //            {
        //                if (t_combo_box.SelectedIndex==1)
        //                {
        //                    f2_label.Text = "إسم الصنف";
        //                    fillproductscombobox();
        //                }
        //                break;
        //            }
        //        case 2://easy_open
        //            {
        //                break;
        //            }
        //        case 3://rlt
        //            {
        //                break;
        //            }
        //        case 4://bill off
        //            {
        //                break;
        //            }

        //        default:
        //            break;
        //    }
        //}

        //private void search_btn_Click(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(f1_combo_box.Text) || string.IsNullOrWhiteSpace(f2_combo_box.Text))
        //    {
        //        MessageBox.Show("الرجاء أستكمال البيانات " , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
        //    }
        //    else
        //    {
        //        switch (finished_product_types_combo_box.SelectedIndex)
        //        {
        //            case 0: // cans
        //                {
        //                    //gettting all cans pallets
        //                    loadcansparcels(clients[f1_combo_box.SelectedIndex].SH_ID , products[f2_combo_box.SelectedIndex].SH_ID);
        //                    quantity_exists_label.Text = "يوجد عدد " + totalnumber + " علبة";
        //                    value_in_db_label.Text = "يوجد عدد "+ totalnumberofcontainer+ "  "+container;
        //                    break;
        //                }
        //            case 1://bottom
        //                {
        //                    //muran
        //                    if (t_combo_box.SelectedIndex == 0)
        //                    {
        //                        loadbottomscontainers(t_combo_box.SelectedIndex,faces[f1_combo_box.SelectedIndex].SH_ID , faces[f2_combo_box.SelectedIndex].SH_ID );

        //                    }else //printed
        //                    {
        //                        loadbottomscontainers(t_combo_box.SelectedIndex, clients[f1_combo_box.SelectedIndex].SH_ID, products[f2_combo_box.SelectedIndex].SH_ID);

        //                    }

        //                    break;
        //                }
        //            case 2://easy_open
        //                {
        //                    if (t_combo_box.SelectedIndex == 0)
        //                    {
        //                        loadeasyopenscontainers(t_combo_box.SelectedIndex, faces[f1_combo_box.SelectedIndex].SH_ID, faces[f2_combo_box.SelectedIndex].SH_ID);

        //                    }
        //                    else //printed
        //                    {
        //                        loadeasyopenscontainers(t_combo_box.SelectedIndex, clients[f1_combo_box.SelectedIndex].SH_ID, products[f2_combo_box.SelectedIndex].SH_ID);

        //                    }
        //                    break;
        //                }
        //            case 3://rlt
        //                {
        //                    break;
        //                }
        //            case 4://bill off
        //                {
        //                    break;
        //                }

        //            default:
        //                break;
        //        }
        //    }
        //}

        //private void t_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (t_combo_box.SelectedIndex==0)
        //    {
        //        f1_label.Text = "الوجة الأول";
        //        f2_label.Text = "الوجة الثانى";
        //        fillfacescombobox();
        //    }
        //    else
        //    {
        //        f1_label.Text = "إسم العميل ";
        //        f2_label.Text = "إسم الصنف";
        //        fill_clients_combo_box();
        //    }
        //}
    }
}
