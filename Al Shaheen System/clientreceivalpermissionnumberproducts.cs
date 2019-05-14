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
    public partial class clientreceivalpermissionnumberproducts : Form
    {

        List<receival_permission_order_items> items = new List<receival_permission_order_items>();


        long product_type_id = 0;
        string proct_type_name = "";

        List<sh_plastic_mold_finished_product_data> plastic_mold_sepecifications = new List<sh_plastic_mold_finished_product_data>();

        List<SH_CALCULATE_TOTAL_FINISHED_PRODUCT> client_products = new List<SH_CALCULATE_TOTAL_FINISHED_PRODUCT>();
        List<SH_ITEM_SIZE> item_sizes = new List<SH_ITEM_SIZE>();
        List<SH_MOLD_SIZE> mold_sizes = new List<SH_MOLD_SIZE>();
        List<SH_TWIST_OF_SIZE> twist_of_sizes = new List<SH_TWIST_OF_SIZE>();
        List<SH_SPECIFICATION_OF_RLT> rlt_specifications = new List<SH_SPECIFICATION_OF_RLT>();
        List<SH_SPECIFICATION_OF_BOTTOM> bottom_specifications = new List<SH_SPECIFICATION_OF_BOTTOM>();
        List<SH_SPECIFICATION_OF_EASY_OPEN> easy_open_specifications = new List<SH_SPECIFICATION_OF_EASY_OPEN>();
        List<SH_SPECIFICATION_OF_TWIST_OF> twist_of_specifications = new List<SH_SPECIFICATION_OF_TWIST_OF>();
        List<SH_SPECIFICATION_OF_PLASTIC_MOLD> plastic_mold_data = new List<SH_SPECIFICATION_OF_PLASTIC_MOLD>();
        List<SH_SPECIFICATION_OF_PEEL_OFF> peel_off_specifications = new List<SH_SPECIFICATION_OF_PEEL_OFF>();
        List<SH_COLOR_PILLOW> pillow_colors = new List<SH_COLOR_PILLOW>();
        List<SH_MOLD_TYPES> MOLD_TYPES = new List<SH_MOLD_TYPES>();
        List<string> containers = new List<string>();

        SH_CLIENT_COMPANY mclient = new SH_CLIENT_COMPANY();
        DatabaseConnection myconnection = new DatabaseConnection();

        public clientreceivalpermissionnumberproducts(SH_CLIENT_COMPANY anyclient)
        {
            InitializeComponent();
            mclient = anyclient;
        }


        async Task fillcontainersdata(string mycontainer)
        {
            if (containers.Count > 0)
            {
                bool here_or_not = false;
                for (int i = 0; i < containers.Count; i++)
                {
                    if (string.Compare(containers[i], mycontainer)==0)
                    {
                        here_or_not = true;
                    }
                }
                if (here_or_not)
                {
                    //  not impossible
                }else
                {
                    containers.Add(mycontainer);
                }
            }else
            {
                containers.Add(mycontainer);
            }
        }


        async Task getallclientproductsforclientandgeneral()
        {
            client_products.Clear();
            
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_CLIENT_AND_GENERAL_PRODUCTS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_products.Add(new SH_CALCULATE_TOTAL_FINISHED_PRODUCT() {
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString())
                        , SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString())
                        , SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TOTAL_NUMBER_OF_CANS = long.Parse(reader["SH_TOTAL_NUMBER_OF_CANS"].ToString())
                        , SH_TOTAL_NUMBER_OF_ENTERED_CANS = long.Parse(reader["SH_TOTAL_NUMBER_OF_ENTERED_CANS"].ToString()),
                        SH_TOTAL_NUMBER_OF_ENTERED_PALLETS = long.Parse(reader["SH_TOTAL_NUMBER_OF_ENTERED_PALLETS"].ToString()),
                        SH_TOTAL_NUMBER_OF_EXCHANGED_CANS = long.Parse(reader["SH_TOTAL_NUMBER_OF_EXCHANGED_CANS"].ToString()),
                        SH_TOTAL_NUMBER_OF_EXCHANGED_PALLETS = long.Parse(reader["SH_TOTAL_NUMBER_OF_EXCHANGED_PALLETS"].ToString()),
                        SH_TOTAL_NUMBER_OF_PALLET = long.Parse(reader["SH_TOTAL_NUMBER_OF_PALLET"].ToString()),
                        size_name = reader["SH_SIZE_NAME"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS "+ex.ToString());
            }

            if (client_products.Count > 0)
            {List<string> sizes = new List<string>();
                for (int i = 0; i < client_products.Count; i++)
                {
                    sizes.Add(client_products[i].SH_CLIENT_PRODUCT_NAME);
                }
                f1_combo_box.DataSource = sizes;

            }

        }


        async Task getallpeeloffspecifications()
        {
            try
            {
                peel_off_specifications.Clear();

                try
                {
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand("", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        peel_off_specifications.Add(new SH_SPECIFICATION_OF_PEEL_OFF()
                        {
                            SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                            SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                            SH_ID = long.Parse(reader["SH_ID"].ToString()),
                            SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                            SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                            SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                            SH_FIRST_FACE_ID = long.Parse(reader["SH_FIRST_FACE_ID"].ToString()),
                            SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString(),
                            SH_PRINTING_TYPE = long.Parse(reader["SH_PRINTING_TYPE"].ToString()),
                            SH_PRINTING_TYPE_NAME = reader["SH_PRINTING_TYPE_NAME"].ToString(),
                            SH_RAW_MATERIAL_TYPE = reader["SH_RAW_MATERIAL_TYPE"].ToString(),
                            SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()),
                            SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(),
                            SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(),
                            SH_USAGE = reader["SH_USAGE"].ToString(),
                            SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()),                       
                            SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                        });
                    }
                    reader.Close();
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTInG easy open Data " + ex.ToString());
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        async Task fillproductsgridview()
        {
            if (client_products.Count > 0)
            {
                DataTable mydata = new DataTable();
                mydata.Columns.Add("م");
                mydata.Columns.Add("إسم العميل");
                mydata.Columns.Add("إسم الصنف");
                mydata.Columns.Add("المقاس");            
                mydata.Columns.Add("التعبئة");
                mydata.Columns.Add("عدد التعبئة");
                mydata.Columns.Add("إجمالى العدد");
              
                for (int i = 0; i < client_products.Count; i++)
                {
                    string[] mytabeldata = new string[10];
                    mytabeldata[0] = (i+1).ToString();
                    mytabeldata[1] = client_products[i].SH_CLIENT_NAME;
                    mytabeldata[2] = client_products[i]. SH_CLIENT_PRODUCT_NAME;
                    mytabeldata[3] = client_products[i].size_name;           
                    mytabeldata[4] = "بالتة";
                    mytabeldata[5] = client_products[i].SH_TOTAL_NUMBER_OF_PALLET.ToString();
                    mytabeldata[6] = client_products[i].SH_TOTAL_NUMBER_OF_CANS.ToString();
                }
                finished_product_properties_grid_view.DataSource = mydata;
            }
        }

        async Task getgallplasticmolddata()
        {
            plastic_mold_sepecifications.Clear();
            //SH_GET_ALL_PLASTIC_MOLD_SPECIFICATIO_DATA 

            //HAVE TO EDITE IT 
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_PLASTIC_MOLD_SPECIFICATIO_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    plastic_mold_sepecifications.Add(new sh_plastic_mold_finished_product_data()
                    {
                        client_id = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        sh_id = long.Parse(reader["SH_ID"].ToString()),
                        SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),
                        SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()),
                        size_id = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        SH_MOLD_TYPE_ID = long.Parse(reader["SH_MOLD_TYPE_ID"].ToString()),
                        total_number_of_items = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()),
                        size_name = reader["SH_MOLD_SIZE_VALUE"].ToString()
                        , client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_PILLOW_COLOR_NAME = reader["SH_COLOR_NAME"].ToString(),
                        SH_MOLD_TYPE_NAME = reader["SH_MOLD_TYPE_NAME"].ToString()          
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG easy open Data " + ex.ToString());
            }

        }

        async Task getalltwistofspecifications()
        {
            twist_of_specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_specifications.Add(new SH_SPECIFICATION_OF_TWIST_OF()
                    {
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),


                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),

                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString()
                        , SH_TYPE = reader["SH_TYPE"].ToString(),
                        SH_FACE_COLOR_ID = long.Parse(reader["SH_FACE_COLOR_ID"].ToString()),
                        SH_FIRST_FACE_PILLOW_OR_NOT = long.Parse(reader["SH_FIRST_FACE_PILLOW_OR_NOT"].ToString()),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),
                        SH_PILLOW_COLOR_ID= long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()),
                        SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()) , 
                        SH_TOTAL_NO_TEMS = long.Parse(reader["SH_TOTAL_NO_TEMS"].ToString()),
                        SH_TWIST_OF_TYPE_ID = long.Parse(reader["SH_TWIST_OF_TYPE_ID"].ToString())
                        
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG easy open Data " + ex.ToString());
            }
        }

        async Task getalleasyopenspecifications()
        {
            easy_open_specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    easy_open_specifications.Add(new SH_SPECIFICATION_OF_EASY_OPEN()
                    {
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString()
                        ,
                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                        SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString()
                        ,
                        SH_FIRST_FACE_ID = long.Parse(reader["SH_FIRST_FACE_ID"].ToString()),
                        SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_PRINTING_TYPE = long.Parse(reader["SH_PRINTING_TYPE"].ToString())
                        ,
                        SH_PRINTING_TYPE_NAME = reader["SH_PRINTING_TYPE_NAME"].ToString(),
                        SH_RAW_MATERIAL_TYPE = reader["SH_RAW_MATERIAL_TYPE"].ToString(),
                        SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()),
                        SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(),
                        SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()),
                        SH_USAGE = reader["SH_USAGE"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG easy open Data " + ex.ToString());
            }
        }


        async Task getallbottomspecifications()
        {
            bottom_specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bottom_specifications.Add(new SH_SPECIFICATION_OF_BOTTOM()
                    {
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString()
                        ,
                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                        SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString()
                        ,
                        SH_FIRST_FACE_ID = long.Parse(reader["SH_FIRST_FACE_ID"].ToString()),
                        SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_PRINTING_TYPE = long.Parse(reader["SH_PRINTING_TYPE"].ToString())
                        ,
                        SH_PRINTING_TYPE_NAME = reader["SH_PRINTING_TYPE_NAME"].ToString(),
                        SH_RAW_MATERIAL_TYPE = reader["SH_RAW_MATERIAL_TYPE"].ToString(),
                        SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()),
                        SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(),
                        SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()),
                        SH_USAGE = reader["SH_USAGE"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG bottom Data " + ex.ToString());
            }
        }
        async Task getallrltspecificationsdata()
        {
            rlt_specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFICATION_OF_RLT", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rlt_specifications.Add(new SH_SPECIFICATION_OF_RLT() { SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString()
                        , SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()), SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString()
                        , SH_FIRST_FACE_ID = long.Parse(reader["SH_FIRST_FACE_ID"].ToString()), SH_FIRST_FACE_NAME = reader["SH_FIRST_FACE_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_PRINTING_TYPE = long.Parse(reader["SH_PRINTING_TYPE"].ToString())
                        , SH_PRINTING_TYPE_NAME = reader["SH_PRINTING_TYPE_NAME"].ToString(),
                        SH_RAW_MATERIAL_TYPE = reader["SH_RAW_MATERIAL_TYPE"].ToString(),
                        SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()),
                        SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(),
                        SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()),
                        SH_USAGE = reader["SH_USAGE"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG RLT Data "+ex.ToString());
            }
        }
       

        async Task fillrltgridview()
        {
            await getallrltspecificationsdata();
            if (rlt_specifications.Count > 0)
            {
                DataTable mydata = new DataTable();
                mydata.Columns.Add("م");
                mydata.Columns.Add("إسم العميل");              
                mydata.Columns.Add("الوجة الأول");
                mydata.Columns.Add("الوجة الثانى");
                mydata.Columns.Add("نوع الخام");
                mydata.Columns.Add("المقاس");
                mydata.Columns.Add("الإستخدام");
                mydata.Columns.Add("التعبئة");
                mydata.Columns.Add("إجمالى الكمية");

                for (int i = 0; i < rlt_specifications.Count; i++)
                {
                    string[] mytabeldata = new string[9];
                    mytabeldata[0] = (i + 1).ToString();
                    mytabeldata[1] = rlt_specifications[i].SH_CLIENT_NAME;
                    if (rlt_specifications[i].SH_PRINTING_TYPE == 0)
                    {
                        mytabeldata[2] = rlt_specifications[i].SH_CLIENT_PRODUCT_NAME;
                        mytabeldata[3] = rlt_specifications[i].SH_SECOND_FACE_NAME;
                    }else
                    {
                        mytabeldata[2] = rlt_specifications[i].SH_FIRST_FACE_NAME;
                        mytabeldata[3] = rlt_specifications[i].SH_SECOND_FACE_NAME;
                    }
                    mytabeldata[4] = rlt_specifications[i].SH_RAW_MATERIAL_TYPE;
                    mytabeldata[5] = rlt_specifications[i].SH_SIZE_NAME;
                    mytabeldata[6] = rlt_specifications[i].SH_USAGE;                   
                    mytabeldata[7] = rlt_specifications[i].SH_CONTAINER_NAME;
                    mytabeldata[8] = rlt_specifications[i].SH_TOTAL_NO_ITEMS.ToString();
                   
                }
                finished_product_properties_grid_view.DataSource = mydata;
            }


        }

        async Task fillplasticmoldgridview()
        {
        
            if (plastic_mold_data.Count > 0)
                    {
                        DataTable mydata = new DataTable();
                        mydata.Columns.Add("م");
                        mydata.Columns.Add("إسم العميل");
                        mydata.Columns.Add("الوجة الأول");
                        mydata.Columns.Add("الوجة الثانى");
                        mydata.Columns.Add("نوع الخام");
                        mydata.Columns.Add("المقاس");
                        mydata.Columns.Add("الإستخدام");
                        mydata.Columns.Add("التعبئة");
                        mydata.Columns.Add("إجمالى الكمية");

                        for (int i = 0; i < plastic_mold_data.Count; i++)
                        {
                            string[] mytabeldata = new string[9];
                            mytabeldata[0] = (i + 1).ToString();
                            mytabeldata[1] = rlt_specifications[i].SH_CLIENT_NAME;
                            if (rlt_specifications[i].SH_PRINTING_TYPE == 0)
                            {
                                mytabeldata[2] = rlt_specifications[i].SH_CLIENT_PRODUCT_NAME;
                                mytabeldata[3] = rlt_specifications[i].SH_SECOND_FACE_NAME;
                            }
                            else
                            {
                                mytabeldata[2] = rlt_specifications[i].SH_FIRST_FACE_NAME;
                                mytabeldata[3] = rlt_specifications[i].SH_SECOND_FACE_NAME;
                            }
                            mytabeldata[4] = rlt_specifications[i].SH_RAW_MATERIAL_TYPE;
                            mytabeldata[5] = rlt_specifications[i].SH_SIZE_NAME;
                            mytabeldata[6] = rlt_specifications[i].SH_USAGE;
                            mytabeldata[7] = rlt_specifications[i].SH_CONTAINER_NAME;
                            mytabeldata[8] = rlt_specifications[i].SH_TOTAL_NO_ITEMS.ToString();

                        }
                        finished_product_properties_grid_view.DataSource = mydata;
                    }
            
            
        }




        async Task loadallsizesDATA()
        {
            item_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_ITEM_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item_sizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()),

                        SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(),
                        SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(),
                        SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()),
                        SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(),
                        SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(),
                        SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING SIZES DATA "+ex.ToString());
            }

            if (item_sizes.Count>0)
            {
                List<string> sizes = new List<string>();
                for (int i = 0; i < item_sizes.Count; i++)
                {
                    sizes.Add(item_sizes[i].SH_SIZE_NAME);
                }
                f1_combo_box.DataSource = sizes;
            }

        }

        async Task loadmoldsizesdata()
        {
            mold_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_SPECIFIED_MOLD_SIZE", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mold_sizes.Add(new SH_MOLD_SIZE() {
                         SH_ID = long.Parse(reader["SH_ID"].ToString()),
                         SH_MOLD_SIZE_VALUE = long.Parse(reader["SH_MOLD_SIZE_VALUE"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING MOLD DIAMETERS DATA " + ex.ToString());
            }

            if (mold_sizes.Count > 0)
            {
                List<string> sizes = new List<string>();
                for (int i = 0; i < mold_sizes.Count; i++)
                {
                    sizes.Add(mold_sizes[i].SH_MOLD_SIZE_VALUE.ToString());
                }
                f1_combo_box.DataSource = sizes;
            }


        }

        async Task loadtwistofsizesdata()
        {
            twist_of_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
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
                MessageBox.Show("ERROR WHIlE GETTING TWIST OF DIAMETERS DATA " + ex.ToString());
            }

            if (twist_of_sizes.Count > 0)
            {
                List<string> sizes = new List<string>();
                for (int i = 0; i < twist_of_sizes.Count; i++)
                {
                    sizes.Add(twist_of_sizes[i].SH_TWIST_OF_SIZE_VALUE.ToString());
                }
                f1_combo_box.DataSource = sizes;
            }

        }


        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (product_type_combo_box.SelectedIndex == 0)
            {
                //cans
                //fill product items
                //await getallclientproductsforclientandgeneral();

                f1_combo_box.Text = "";
                f1_combo_box.Visible = false;
                f1_label.Text = "F1";
                f1_label.Visible = false;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;


            }
            else if (product_type_combo_box.SelectedIndex == 1)
            {
                //bottom 
                // sizes combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;

                await loadallsizesDATA();



            }
            else if (product_type_combo_box.SelectedIndex == 2)
            {
                //rlt 
                // sizes combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;

                await loadallsizesDATA();
            }
            else if (product_type_combo_box.SelectedIndex == 3)
            {
                //easyopen
                // sizes combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;


                await loadallsizesDATA();
            }
            else if (product_type_combo_box.SelectedIndex == 4)
            {
                //peeloff
                // sizes combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;


                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;

                await loadallsizesDATA();
            }
            else if (product_type_combo_box.SelectedIndex == 5)
            {
                //twistoff
                // twist of combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;


                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;

                await loadtwistofsizesdata();
            }
            else if (product_type_combo_box.SelectedIndex == 6)
            {
                //plastic cover
                // sizes combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;


                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;

                await loadallsizesDATA();
            }
            else if (product_type_combo_box.SelectedIndex == 7)
            {
                //plastic mold
                // mold size combo box
                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "F1";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = true;
                f2_label.Text = "F2";
                f2_label.Visible = true;


                f3_combo_box.Text = "";
                f3_combo_box.Visible = true;
                f3_label.Text = "F3";
                f3_label.Visible = true;

                await loadmoldsizesdata();
                await loadmoldpillowcolors();
                await loadmoldtypes();
            }
        }

        async Task loadmoldtypes()
        {
            MOLD_TYPES.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFIED_MOLD_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    MOLD_TYPES.Add(new SH_MOLD_TYPES()
                    {
                        SH_MOLD_TYPE_NAME = reader["SH_MOLD_TYPE_NAME"].ToString(),                   
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG PILLOW CoLORs DATA " + ex.ToString());
            }


            if (MOLD_TYPES.Count > 0)
            {
                List<string> MYTYPES = new List<string>();
                for (int i = 0; i < MOLD_TYPES.Count; i++)
                {
                    MYTYPES.Add(MOLD_TYPES[i].SH_MOLD_TYPE_NAME);
                }
                f3_combo_box.DataSource = MYTYPES;
            }
        }

        async Task loadmoldpillowcolors()
        {
            pillow_colors.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_SPECIFIED_PILLOW_COLORS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pillow_colors.Add(new SH_COLOR_PILLOW() {
                        SH_COLOR_CODE = reader["SH_COLOR_CODE"].ToString(),
                        SH_COLOR_NAME = reader["SH_COLOR_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG PILLOW CoLORs DATA "+ex.ToString());
            }


            if (pillow_colors.Count>0)
            {
                List<string> colors = new List<string>();
                for (int i = 0; i < pillow_colors.Count; i++)
                {
                    colors.Add(pillow_colors[i].SH_COLOR_NAME);
                }
                f2_combo_box.DataSource = colors;
            }
        }

        private void clientreceivalpermissionnumberproducts_Load(object sender, EventArgs e)
        {
            client_text_box.Text = mclient.SH_CLIENT_COMPANY_NAME;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void get_client_data_btn_Click(object sender, EventArgs e)
        {
            switch (product_type_combo_box.SelectedIndex)
            {
                case 7:
                    {
                        await fillplasticmoldgridview();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
