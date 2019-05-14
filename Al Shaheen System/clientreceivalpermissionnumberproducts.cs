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
       public List<SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA> dismissed_containers = new List<SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA>();

        long product_type_id = 0;
        string proct_type_name = "";

        List<sh_plastic_mold_finished_product_data> plastic_mold_sepecifications = new List<sh_plastic_mold_finished_product_data>();

        List<SH_CLIENTS_PRODUCTS> client_products = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ITEM_SIZE> item_sizes = new List<SH_ITEM_SIZE>();
        List<SH_MOLD_SIZE> mold_sizes = new List<SH_MOLD_SIZE>();
        List<SH_TWIST_OF_SIZE> twist_of_sizes = new List<SH_TWIST_OF_SIZE>();
        List<SH_MATERIAL_TYPES> material_types = new List<SH_MATERIAL_TYPES>();
        List<bottom_containers_data> bottom_containers = new List<bottom_containers_data>();
        List<rlt_container_data> rlt_containetrs = new List<rlt_container_data>();
        List<peel_off_container_data> peel_off_containers = new List<peel_off_container_data>();
        List<twist_of_container_data> twist_of_containers = new List<twist_of_container_data>();
        List<easy_open_container_data> easy_open_containers = new List<easy_open_container_data>();
        List<SH_SPECIFICATION_OF_PLASTIC_COVER> plastic_cover_data = new List<SH_SPECIFICATION_OF_PLASTIC_COVER>();
        List<SH_CALCULATE_TOTAL_FINISHED_PRODUCT> finished_cans = new List<SH_CALCULATE_TOTAL_FINISHED_PRODUCT>();

        List<SH_COLOR_PILLOW> pillow_colors = new List<SH_COLOR_PILLOW>();
        List<SH_MOLD_TYPES> MOLD_TYPES = new List<SH_MOLD_TYPES>();
        List<string> containers = new List<string>();

        public long back = 0;

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
                    if (string.Compare(containers[i], mycontainer) == 0)
                    {
                        here_or_not = true;
                    }
                }
                if (here_or_not)
                {
                    //  not impossible
                }
                else
                {
                    containers.Add(mycontainer);
                }
            }
            else
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
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_products.Add(
                        new SH_CLIENTS_PRODUCTS()
                        {
                            SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()),
                            SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()),
                            SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                            SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                            SH_ID = long.Parse(reader["SH_ID"].ToString()),
                            SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(),
                            SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(),
                            SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()),
                            SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(),
                            SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()),
                            SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString()
                        }
                        );
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS " + ex.ToString());
            }

            if (client_products.Count > 0)
            {
                List<string> sizes = new List<string>();
                for (int i = 0; i < client_products.Count; i++)
                {
                    sizes.Add(client_products[i].SH_PRODUCT_NAME);
                }
                f1_combo_box.DataSource = sizes;

            }

        }


        async Task getallplasticcoverspecifications()
        {
            plastic_cover_data.Clear();
            try
            {


                bool size = false;
                bool pillow_color = false;
                string size_string = "";
                string pillow_color_string = "";
                long logo_or_not = 0;
                if (c_box_1.Checked)
                {
                    logo_or_not = 1;
                }
                else
                {
                    logo_or_not = 0;
                }

                if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
                {
                    size = false;
                }
                else
                {
                    size = true;
                    size_string = " AND SPC.SH_SIZE_ID = @SH_SIZE_ID ";
                }

                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    pillow_color = false;
                }
                else
                {
                    pillow_color = true;
                    pillow_color_string = " AND SPC.SH_PILLOW_COLOR_ID = @SH_PILLOW_COLOR_ID ";
                }

                string query = " SELECT SPC.* , (SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID=SPC.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME , (SELECT ITS.SH_SIZE_NAME FROM SH_ITEM_SIZE ITS WHERE ITS.SH_ID = SPC.SH_SIZE_ID ) AS SH_SIZE_NAME , (SELECT PC.SH_COLOR_NAME FROM SH_COLOR_PILLOW PC WHERE PC.SH_ID= SPC.SH_PILLOW_COLOR_ID) AS SH_COLOR_NAME  FROM SH_SPECIFICATION_OF_PLASTIC_COVER SPC WHERE SPC.SH_CLIENT_ID= @SH_CLIENT_ID OR SPC.SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')  AND SPC.SH_LOGO_OR_NOT = @SH_LOGO_OR_NOT " + size_string + pillow_color_string;
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@SH_LOGO_OR_NOT", logo_or_not);
                if (size)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                }

                if (pillow_color)
                {
                    cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", pillow_colors[f2_combo_box.SelectedIndex].SH_ID);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    plastic_cover_data.Add(new SH_SPECIFICATION_OF_PLASTIC_COVER()
                    {
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        clientname = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_LOGO_OR_NOT = long.Parse(reader["SH_LOGO_OR_NOT"].ToString()),
                        SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()),
                        SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()),
                        pillowcolorname = reader["SH_COLOR_NAME"].ToString(),
                        sizename = reader["SH_SIZE_NAME"].ToString(),
                        SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Close();
                myconnection.openConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GeTTING PLASTic COVER DATA " + ex.ToString());
            }
        }

        async Task fillplasticcovergridview()
        {
            await getallplasticcoverspecifications();
            if (plastic_cover_data.Count > 0)
            {
                DataTable mydata = new DataTable();
                mydata.Columns.Add("م");
                mydata.Columns.Add("إسم العميل");
                mydata.Columns.Add("المقاس");
                mydata.Columns.Add("اللون");
                mydata.Columns.Add("يوجد لوجو أو لا ");
                mydata.Columns.Add("التعبئة");
                mydata.Columns.Add("عدد التعبئة");
                mydata.Columns.Add("إجمالى الكمية");
                //MessageBox.Show(plastic_mold_sepecifications.Count.ToString());

                for (int i = 0; i < plastic_cover_data.Count; i++)
                {
                    string[] mytabeldata = new string[8];
                    mytabeldata[0] = (i + 1).ToString();
                    mytabeldata[1] = plastic_cover_data[i].clientname;
                    mytabeldata[2] = plastic_cover_data[i].sizename;
                    mytabeldata[3] = plastic_cover_data[i].pillowcolorname;
                    if (plastic_cover_data[i].SH_LOGO_OR_NOT == 0)
                    {
                        mytabeldata[4] = "لا يوجد";
                    }
                    else
                    {
                        mytabeldata[4] = " يوجد";
                    }

                    mytabeldata[5] = plastic_cover_data[i].SH_CONTAINER_NAME;
                    mytabeldata[6] = plastic_cover_data[i].SH_NO_OF_CONTAINERS.ToString();
                    mytabeldata[7] = plastic_cover_data[i].SH_TOTAL_NO_ITEMS.ToString();

                    mydata.Rows.Add(mytabeldata);

                }
                finished_product_properties_grid_view.DataSource = mydata;
            }


        }


        async Task getallpeeloffspecifications()
        {
            peel_off_containers.Clear();
            try
            {
                bool material_type = false;
                bool size = false;
                bool usage = false;
                bool printing_typ = false;
                string material_type_string = "";
                string size_string = "";
                string usage_string = "";
                string printing_type_string = "";

                //size condition
                if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
                {
                    size = false;
                }
                else
                {
                    size = true;
                    size_string = "AND SPB.SH_SIZE_ID = @SH_SIZE_ID ";
                }
                // material type condition 
                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    material_type = false;
                }
                else
                {
                    material_type = true;
                    material_type_string = " AND SPB.SH_RAW_MATERIAL_TYPE LIKE N'%" + f2_combo_box.Text + "%' ";
                }
                // usage type condition 
                if (string.IsNullOrWhiteSpace(f3_combo_box.Text))
                {
                    usage = false;
                }
                else
                {
                    usage = true;
                    usage_string = " AND SPB.SH_USAGE LIKE N'%" + f3_combo_box.Text + "%'";
                }

                if (string.IsNullOrWhiteSpace(f4_combo_box.Text))
                {
                    printing_typ = false;
                }
                else
                {
                    printing_typ = true;
                    printing_type_string = " AND SPB.SH_PRINTING_TYPE_NAME LIKE N'%" + f4_combo_box.Text + "%'";
                }

                myconnection.openConnection();


                string query = " ";
                query += "SELECT(CB.SH_CONTAINER_NAME) , ";
                query += "SPB.SH_CLIENT_ID , (SELECT  CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID = SPB.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME , ";
                query += "CB.SH_SUBCONTAINER_NAME , CB.SH_TOTAL_NO_ITEMS as SH_CONTAINER_NUMBER_OF_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS , CB.SH_NO_ITEMS_PER_SUB_CONTAINER,CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER, ";
                query += "COUNT(CB.SH_ID) AS NO_OF_CONTAINERS, SUM(CB.SH_TOTAL_NO_ITEMS)AS TOTAL_NUMBER_OF_ITEMS  FROM  SH_CONTAINER_OF_PEEL_OFF CB JOIN ";
                query += "SH_SPECIFICATION_OF_PEEL_OFF SPB ON SPB.SH_ID = CB.SH_SPECIFICATION_OF_PEEL_OFF_ID ";
                query += " WHERE  SPB.SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام') " + size_string + usage_string + material_type_string + printing_type_string;
                query += " GROUP BY SPB.SH_CLIENT_ID , (CB.SH_CONTAINER_NAME), CB.SH_SUBCONTAINER_NAME, CB.SH_TOTAL_NO_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS, CB.SH_NO_ITEMS_PER_SUB_CONTAINER, CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER ";


                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                if (size)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    peel_off_containers.Add(new peel_off_container_data()
                    {
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        container_no_of_items = long.Parse(reader["SH_CONTAINER_NUMBER_OF_ITEMS"].ToString()),
                        no_items_per_sub_container = long.Parse(reader["SH_NO_ITEMS_PER_SUB_CONTAINER"].ToString()),
                        no_of_sub_container_per_container = long.Parse(reader["SH_NO_OF_SUB_CONTAINER_PER_CONTAINER"].ToString()),
                        number_of_containers = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        subcontainer_name = reader["SH_SUBCONTAINER_NAME"].ToString(),
                        total_number_of_items = long.Parse(reader["TOTAL_NUMBER_OF_ITEMS"].ToString()),
                        total_number_of_sub_container = long.Parse(reader["SH_TOTAL_NUMBER_OF_SUB_CONTAINERS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG rlt Data " + ex.ToString());
            }
        }

        async Task getclientproductfinishedcansdata()
        {
            finished_cans.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_FINISHED_CANS_DATA ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[f1_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    finished_cans.Add(new SH_CALCULATE_TOTAL_FINISHED_PRODUCT()
                    {
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                        //SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                        SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                        //SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_PARCEL_NO_OF_CANS = long.Parse(reader["TOTAL_NUMBER_OF_CANS"].ToString()) / long.Parse(reader["TOTAL_NUMBER_OF_PARCELS"].ToString()),
                        SH_TOTAL_NUMBER_OF_CANS = long.Parse(reader["TOTAL_NUMBER_OF_CANS"].ToString()),
                        SH_TOTAL_NUMBER_OF_PALLET = long.Parse(reader["TOTAL_NUMBER_OF_PARCELS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR WHILE GETTING Finished cans data " + ex.ToString());
            }



        }

        async Task fillfinishedcansgridview()
        {
            await getclientproductfinishedcansdata();
            if (finished_cans.Count > 0)
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("العميل");
                mydatatabel.Columns.Add("الصنف");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("عدد التعبئة");
                mydatatabel.Columns.Add("عدد العلب بالتعبئة");
                mydatatabel.Columns.Add("إجمالى عدد العلب");

                for (int i = 0; i < finished_cans.Count; i++)
                {
                    string[] mydata = new string[7];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = finished_cans[i].SH_CLIENT_NAME;
                    mydata[2] = finished_cans[i].SH_CLIENT_PRODUCT_NAME;
                    mydata[3] = "بالتة";
                    mydata[4] = finished_cans[i].SH_TOTAL_NUMBER_OF_PALLET.ToString();
                    mydata[5] = finished_cans[i].SH_PARCEL_NO_OF_CANS.ToString();
                    mydata[6] = finished_cans[i].SH_TOTAL_NUMBER_OF_CANS.ToString();
                    mydatatabel.Rows.Add(mydata);
                }
                finished_product_properties_grid_view.DataSource = mydatatabel;
            }
        }

        async Task getgallplasticmolddata()
        {
            plastic_mold_sepecifications.Clear();
            //SH_GET_ALL_PLASTIC_MOLD_SPECIFICATIO_DATA 

            //HAVE TO EDITE IT 

            bool MOLD_SIZE = false;
            bool MOLD_TYPE = false;
            bool PILLOW_COLOR = false;
            string MOLD_SIZE_STRING = "";
            string MOLD_TYPE_STRING = "";
            string PILLOW_COLOR_STRING = "";


            if (f1_combo_box.Visible)
            {
                if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
                {
                    MOLD_SIZE = false;
                }
                else
                {
                    MOLD_SIZE = true;
                    MOLD_SIZE_STRING = " AND PMS.SH_SIZE_ID = @SH_SIZE_ID";
                }

            }

            if (f2_combo_box.Visible)
            {
                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    PILLOW_COLOR = false;
                }
                else
                {
                    PILLOW_COLOR = true;
                    PILLOW_COLOR_STRING = " AND PMS.SH_PILLOW_COLOR_ID = @SH_PILLOW_COLOR_ID";
                }

            }

            if (f3_combo_box.Visible)
            {
                if (string.IsNullOrWhiteSpace(f3_combo_box.Text))
                {
                    MOLD_TYPE = false;
                }
                else
                {
                    MOLD_TYPE = true;
                    MOLD_TYPE_STRING = " AND PMS.SH_MOLD_TYPE_ID = @SH_MOLD_TYPE_ID";
                }
            }
            string query = "SELECT PMS.*  , (SELECT MS.SH_MOLD_SIZE_VALUE FROM SH_MOLD_SIZE MS WHERE PMS.SH_SIZE_ID = MS.SH_ID ) AS SH_MOLD_SIZE_VALUE , (SELECT MT.SH_MOLD_TYPE_NAME FROM SH_MOLD_TYPES MT WHERE PMS.SH_MOLD_TYPE_ID = MT.SH_ID ) AS SH_MOLD_TYPE_NAME , (SELECT PC.SH_COLOR_NAME FROM SH_COLOR_PILLOW PC WHERE PC.SH_ID = PMS.SH_PILLOW_COLOR_ID  )AS SH_COLOR_NAME , (SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID = PMS.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME   FROM SH_SPECIFICATION_OF_PLASTIC_MOLD  PMS WHERE PMS.SH_CLIENT_ID = @SH_CLIENT_ID  " + MOLD_SIZE_STRING + MOLD_TYPE_STRING + PILLOW_COLOR_STRING;


            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                if (MOLD_TYPE)
                {
                    cmd.Parameters.AddWithValue("@SH_MOLD_TYPE_ID", MOLD_TYPES[f3_combo_box.SelectedIndex].SH_ID);
                }

                if (MOLD_SIZE)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", mold_sizes[f1_combo_box.SelectedIndex].SH_ID);
                }

                if (PILLOW_COLOR)
                {
                    cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", pillow_colors[f2_combo_box.SelectedIndex].SH_ID);
                }




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
                        ,
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_PILLOW_COLOR_NAME = reader["SH_COLOR_NAME"].ToString(),
                        SH_MOLD_TYPE_NAME = reader["SH_MOLD_TYPE_NAME"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PLASTIC MOLD DATA " + ex.ToString());
            }

        }

        async Task getalltwistofspecifications()
        {
            twist_of_containers.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OF_SPECIFIED_CONTAINER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    twist_of_containers.Add(new twist_of_container_data()
                    {
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        client_product_name = reader["SH_PRODUCT_NAME"].ToString(),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        number_of_containers = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        pillow_color_name = reader["SH_COLOR_NAME"].ToString(),
                        pillow_or_not = long.Parse(reader["SH_FIRST_FACE_PILLOW_OR_NOT"].ToString()),
                        twist_of_type_name = reader["SH_TWIST_OF_TYPE_NAME"].ToString(),
                        size_name = reader["SH_TWIST_OF_SIZE_VALUE"].ToString(),
                        total_number_of_items = long.Parse(reader["TOTAL_NUMBER_OF_ITEMS"].ToString()),
                        no_items_per_container = long.Parse(reader["SH_NO_ITEMS"].ToString())

                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GETTInG TWIST OF CONTAINERS DATa" + ex.ToString());
            }
        }

        async Task filltwistofgridview()
        {
            getalltwistofspecifications();
            if (twist_of_containers.Count > 0)
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("إسم العميل");
                mydatatabel.Columns.Add("الوجة الخارجي");
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("عدد التعبئة");
                mydatatabel.Columns.Add("الكمية / التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");

                for (int i = 0; i < twist_of_containers.Count; i++)
                {
                    string[] mydata = new string[8];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = twist_of_containers[i].client_name;
                    if (twist_of_containers[i].pillow_or_not == 0)
                    {
                        mydata[2] = twist_of_containers[i].client_product_name;
                    }
                    else
                    {
                        mydata[2] = twist_of_containers[i].pillow_color_name;
                    }

                    mydata[3] = twist_of_containers[i].size_name;
                    mydata[4] = twist_of_containers[i].container_name;
                    mydata[5] = twist_of_containers[i].number_of_containers.ToString();
                    mydata[6] = twist_of_containers[i].no_items_per_container.ToString();
                    mydata[7] = twist_of_containers[i].total_number_of_items.ToString();

                    mydatatabel.Rows.Add(mydata);
                }
                finished_product_properties_grid_view.DataSource = mydatatabel;
            }
        }



        async Task getalleasyopenspecifications()
        {
            easy_open_containers.Clear();
            try
            {
                bool material_type = false;
                bool size = false;
                bool usage = false;
                bool printing_typ = false;
                string material_type_string = "";
                string size_string = "";
                string usage_string = "";
                string printing_type_string = "";

                //size condition
                if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
                {
                    size = false;
                }
                else
                {
                    size = true;
                    size_string = "AND SPB.SH_SIZE_ID = @SH_SIZE_ID ";
                }
                // material type condition 
                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    material_type = false;
                }
                else
                {
                    material_type = true;
                    material_type_string = " AND SPB.SH_RAW_MATERIAL_TYPE LIKE N'%" + f2_combo_box.Text + "%' ";
                }
                // usage type condition 
                if (string.IsNullOrWhiteSpace(f3_combo_box.Text))
                {
                    usage = false;
                }
                else
                {
                    usage = true;
                    usage_string = " AND SPB.SH_USAGE LIKE N'%" + f3_combo_box.Text + "%'";
                }

                if (string.IsNullOrWhiteSpace(f4_combo_box.Text))
                {
                    printing_typ = false;
                }
                else
                {
                    printing_typ = true;
                    printing_type_string = " AND SPB.SH_PRINTING_TYPE_NAME LIKE N'%" + f4_combo_box.Text + "%'";
                }

                myconnection.openConnection();


                string query = " ";
                query += "SELECT(CB.SH_CONTAINER_NAME) , ";
                query += "SPB.SH_CLIENT_ID , (SELECT  CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID = SPB.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME , ";
                query += "CB.SH_SUBCONTAINER_NAME , CB.SH_TOTAL_NO_ITEMS as SH_CONTAINER_NUMBER_OF_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS , CB.SH_NO_ITEMS_PER_SUB_CONTAINER,CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER, ";
                query += "COUNT(CB.SH_ID) AS NO_OF_CONTAINERS, SUM(CB.SH_TOTAL_NO_ITEMS)AS TOTAL_NUMBER_OF_ITEMS  FROM  SH_CONTAINER_OF_EASY_OPEN CB JOIN ";
                query += "SH_SPECIFICATION_OF_EASY_OPEN SPB ON SPB.SH_ID = CB.SH_SPECIFICATION_OF_EASY_OPEN_ID ";
                query += " WHERE  SPB.SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام') " + size_string + usage_string + material_type_string + printing_type_string;
                query += " GROUP BY SPB.SH_CLIENT_ID , (CB.SH_CONTAINER_NAME), CB.SH_SUBCONTAINER_NAME, CB.SH_TOTAL_NO_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS, CB.SH_NO_ITEMS_PER_SUB_CONTAINER, CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER ";


                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                if (size)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    easy_open_containers.Add(new easy_open_container_data()
                    {
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        container_no_of_items = long.Parse(reader["SH_CONTAINER_NUMBER_OF_ITEMS"].ToString()),
                        no_items_per_sub_container = long.Parse(reader["SH_NO_ITEMS_PER_SUB_CONTAINER"].ToString()),
                        no_of_sub_container_per_container = long.Parse(reader["SH_NO_OF_SUB_CONTAINER_PER_CONTAINER"].ToString()),
                        number_of_containers = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        subcontainer_name = reader["SH_SUBCONTAINER_NAME"].ToString(),
                        total_number_of_items = long.Parse(reader["TOTAL_NUMBER_OF_ITEMS"].ToString()),
                        total_number_of_sub_container = long.Parse(reader["SH_TOTAL_NUMBER_OF_SUB_CONTAINERS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG rlt Data " + ex.ToString());
            }
        }

        async Task filleasyopengridview()
        {
            await getalleasyopenspecifications();
            if (easy_open_containers.Count > 0)
            {
                DataTable mytabeldata = new DataTable();
                mytabeldata.Columns.Add("م");
                mytabeldata.Columns.Add("إسم العميل");

                mytabeldata.Columns.Add("إسم التعبئة");
                mytabeldata.Columns.Add("عدد التعبئة");
                mytabeldata.Columns.Add("الكمية / التعبئة");

                mytabeldata.Columns.Add("إسم المحتوى");
                mytabeldata.Columns.Add("عدد المحتوي بالتعبئة");
                mytabeldata.Columns.Add("الكمية / المحتوى");
                mytabeldata.Columns.Add("إجمالى الكمية");


                for (int i = 0; i < easy_open_containers.Count; i++)
                {
                    string[] mydata = new string[9];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = easy_open_containers[i].client_name;
                    mydata[2] = easy_open_containers[i].container_name;
                    mydata[3] = easy_open_containers[i].number_of_containers.ToString();
                    mydata[4] = easy_open_containers[i].container_no_of_items.ToString();

                    mydata[5] = easy_open_containers[i].subcontainer_name.ToString();
                    mydata[6] = easy_open_containers[i].no_of_sub_container_per_container.ToString();
                    mydata[7] = easy_open_containers[i].no_items_per_sub_container.ToString();
                    mydata[8] = easy_open_containers[i].total_number_of_items.ToString();
                    mytabeldata.Rows.Add(mydata);
                }
                finished_product_properties_grid_view.DataSource = mytabeldata;
            }

        }

        async Task getallbottomspecifications()
        {
            bottom_containers.Clear();
            try
            {
                bool material_type = false;
                bool size = false;
                bool usage = false;
                bool printing_typ = false;
                string material_type_string = "";
                string size_string = "";
                string usage_string = "";
                string printing_type_string = "";

                //size condition
                if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
                {
                    size = false;
                }
                else
                {
                    size = true;
                    size_string = "AND SPB.SH_SIZE_ID = @SH_SIZE_ID ";
                }
                // material type condition 
                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    material_type = false;
                }
                else
                {
                    material_type = true;
                    material_type_string = " AND SPB.SH_RAW_MATERIAL_TYPE LIKE N'%" + f2_combo_box.Text + "%' ";
                }
                // usage type condition 
                if (string.IsNullOrWhiteSpace(f3_combo_box.Text))
                {
                    usage = false;
                }
                else
                {
                    usage = true;
                    usage_string = " AND SPB.SH_USAGE LIKE N'%" + f3_combo_box.Text + "%'";
                }


                if (string.IsNullOrWhiteSpace(f4_combo_box.Text))
                {
                    printing_typ = false;
                }
                else
                {
                    printing_typ = true;
                    printing_type_string = " AND SPB.SH_PRINTING_TYPE_NAME LIKE N'%" + f4_combo_box.Text + "%'";
                }

                myconnection.openConnection();


                string query = " ";
                query += "SELECT(CB.SH_CONTAINER_NAME) , ";
                query += "SPB.SH_CLIENT_ID , (SELECT  CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID = SPB.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME , ";
                query += "CB.SH_SUBCONTAINER_NAME , CB.SH_TOTAL_NO_ITEMS as SH_CONTAINER_NUMBER_OF_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS , CB.SH_NO_ITEMS_PER_SUB_CONTAINER,CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER, ";
                query += "COUNT(CB.SH_ID) AS NO_OF_CONTAINERS, SUM(CB.SH_TOTAL_NO_ITEMS)AS TOTAL_NUMBER_OF_ITEMS  FROM  SH_CONTAINER_OF_BOTTOM CB JOIN ";
                query += "SH_SPECIFICATION_OF_BOTTOM SPB ON SPB.SH_ID = CB.SH_SPECIFICATION_OF_BOTTOM_ID ";
                query += " WHERE  (SPB.SH_CLIENT_ID = @SH_CLIENT_ID OR SPB.SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')) " + size_string + usage_string + material_type_string + printing_type_string;
                query += " GROUP BY SPB.SH_CLIENT_ID , (CB.SH_CONTAINER_NAME), CB.SH_SUBCONTAINER_NAME, CB.SH_TOTAL_NO_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS, CB.SH_NO_ITEMS_PER_SUB_CONTAINER, CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER ";


                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                if (size)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bottom_containers.Add(new bottom_containers_data()
                    {
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        container_no_of_items = long.Parse(reader["SH_CONTAINER_NUMBER_OF_ITEMS"].ToString()),
                        no_items_per_sub_container = long.Parse(reader["SH_NO_ITEMS_PER_SUB_CONTAINER"].ToString()),
                        no_of_sub_container_per_container = long.Parse(reader["SH_NO_OF_SUB_CONTAINER_PER_CONTAINER"].ToString()),
                        number_of_containers = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        subcontainer_name = reader["SH_SUBCONTAINER_NAME"].ToString(),
                        total_number_of_items = long.Parse(reader["TOTAL_NUMBER_OF_ITEMS"].ToString()),
                        total_number_of_sub_container = long.Parse(reader["SH_TOTAL_NUMBER_OF_SUB_CONTAINERS"].ToString())
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

        async Task fillbottomdatagridview()
        {
            await getallbottomspecifications();
            if (bottom_containers.Count > 0)
            {
                DataTable mytabeldata = new DataTable();
                mytabeldata.Columns.Add("م");
                mytabeldata.Columns.Add("إسم العميل");

                mytabeldata.Columns.Add("إسم التعبئة");
                mytabeldata.Columns.Add("عدد التعبئة");
                mytabeldata.Columns.Add("الكمية / التعبئة");

                mytabeldata.Columns.Add("إسم المحتوى");
                mytabeldata.Columns.Add("عدد المحتوي بالتعبئة");
                mytabeldata.Columns.Add("الكمية / المحتوى");
                mytabeldata.Columns.Add("إجمالى الكمية");


                for (int i = 0; i < bottom_containers.Count; i++)
                {
                    string[] mydata = new string[9];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = bottom_containers[i].client_name;
                    mydata[2] = bottom_containers[i].container_name;
                    mydata[3] = bottom_containers[i].number_of_containers.ToString();
                    mydata[4] = bottom_containers[i].container_no_of_items.ToString();

                    mydata[5] = bottom_containers[i].subcontainer_name.ToString();
                    mydata[6] = bottom_containers[i].no_of_sub_container_per_container.ToString();
                    mydata[7] = bottom_containers[i].no_items_per_sub_container.ToString();
                    mydata[8] = bottom_containers[i].total_number_of_items.ToString();
                    mytabeldata.Rows.Add(mydata);
                }
                finished_product_properties_grid_view.DataSource = mytabeldata;
            }
        }


        async Task getallrltspecifications()
        {
            rlt_containetrs.Clear();
            try
            {
                bool material_type = false;
                bool size = false;
                bool usage = false;
                bool printing_typ = false;
                string material_type_string = "";
                string size_string = "";
                string usage_string = "";
                string printing_type_string = "";

                //size condition
                if (string.IsNullOrWhiteSpace(f1_combo_box.Text))
                {
                    size = false;
                }
                else
                {
                    size = true;
                    size_string = "AND SPB.SH_SIZE_ID = @SH_SIZE_ID ";
                }
                // material type condition 
                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    material_type = false;
                }
                else
                {
                    material_type = true;
                    material_type_string = " AND SPB.SH_RAW_MATERIAL_TYPE LIKE N'%" + f2_combo_box.Text + "%' ";
                }
                // usage type condition 
                if (string.IsNullOrWhiteSpace(f3_combo_box.Text))
                {
                    usage = false;
                }
                else
                {
                    usage = true;
                    usage_string = " AND SPB.SH_USAGE LIKE N'%" + f3_combo_box.Text + "%'";
                }

                if (string.IsNullOrWhiteSpace(f4_combo_box.Text))
                {
                    printing_typ = false;
                }
                else
                {
                    printing_typ = true;
                    printing_type_string = " AND SPB.SH_PRINTING_TYPE_NAME LIKE N'%" + f4_combo_box.Text + "%'";
                }

                myconnection.openConnection();


                string query = " ";
                query += "SELECT(CB.SH_CONTAINER_NAME) , ";
                query += "SPB.SH_CLIENT_ID , (SELECT  CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID = SPB.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME , ";
                query += "CB.SH_SUBCONTAINER_NAME , CB.SH_TOTAL_NO_ITEMS as SH_CONTAINER_NUMBER_OF_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS , CB.SH_NO_ITEMS_PER_SUB_CONTAINER,CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER, ";
                query += "COUNT(CB.SH_ID) AS NO_OF_CONTAINERS, SUM(CB.SH_TOTAL_NO_ITEMS)AS TOTAL_NUMBER_OF_ITEMS  FROM  SH_CONTAINER_OF_RLT CB JOIN ";
                query += "SH_SPECIFICATION_OF_RLT SPB ON SPB.SH_ID = CB.SH_SPECIFICATION_OF_RLT_ID ";
                query += " WHERE  SPB.SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام') " + size_string + usage_string + material_type_string + printing_type_string;
                query += " GROUP BY SPB.SH_CLIENT_ID , (CB.SH_CONTAINER_NAME), CB.SH_SUBCONTAINER_NAME, CB.SH_TOTAL_NO_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS, CB.SH_NO_ITEMS_PER_SUB_CONTAINER, CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER ";


                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                if (size)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                }
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    rlt_containetrs.Add(new rlt_container_data()
                    {
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        container_no_of_items = long.Parse(reader["SH_CONTAINER_NUMBER_OF_ITEMS"].ToString()),
                        no_items_per_sub_container = long.Parse(reader["SH_NO_ITEMS_PER_SUB_CONTAINER"].ToString()),
                        no_of_sub_container_per_container = long.Parse(reader["SH_NO_OF_SUB_CONTAINER_PER_CONTAINER"].ToString()),
                        number_of_containers = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        subcontainer_name = reader["SH_SUBCONTAINER_NAME"].ToString(),
                        total_number_of_items = long.Parse(reader["TOTAL_NUMBER_OF_ITEMS"].ToString()),
                        total_number_of_sub_container = long.Parse(reader["SH_TOTAL_NUMBER_OF_SUB_CONTAINERS"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG rlt Data " + ex.ToString());
            }
        }

        async Task fillrltgridview()
        {
            await getallrltspecifications();
            if (rlt_containetrs.Count > 0)
            {
                DataTable mytabeldata = new DataTable();
                mytabeldata.Columns.Add("م");
                mytabeldata.Columns.Add("إسم العميل");

                mytabeldata.Columns.Add("إسم التعبئة");
                mytabeldata.Columns.Add("عدد التعبئة");
                mytabeldata.Columns.Add("الكمية / التعبئة");

                mytabeldata.Columns.Add("إسم المحتوى");
                mytabeldata.Columns.Add("عدد المحتوي بالتعبئة");
                mytabeldata.Columns.Add("الكمية / المحتوى");
                mytabeldata.Columns.Add("إجمالى الكمية");


                for (int i = 0; i < bottom_containers.Count; i++)
                {
                    string[] mydata = new string[9];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = rlt_containetrs[i].client_name;
                    mydata[2] = rlt_containetrs[i].container_name;
                    mydata[3] = rlt_containetrs[i].number_of_containers.ToString();
                    mydata[4] = rlt_containetrs[i].container_no_of_items.ToString();

                    mydata[5] = rlt_containetrs[i].subcontainer_name.ToString();
                    mydata[6] = rlt_containetrs[i].no_of_sub_container_per_container.ToString();
                    mydata[7] = rlt_containetrs[i].no_items_per_sub_container.ToString();
                    mydata[8] = rlt_containetrs[i].total_number_of_items.ToString();
                    mytabeldata.Rows.Add(mydata);
                }
                finished_product_properties_grid_view.DataSource = mytabeldata;
            }
        }



        async Task fillpelloffgridview()
        {
            await getallpeeloffspecifications();
            if (peel_off_containers.Count > 0)
            {
                DataTable mytabeldata = new DataTable();
                mytabeldata.Columns.Add("م");
                mytabeldata.Columns.Add("إسم العميل");

                mytabeldata.Columns.Add("إسم التعبئة");
                mytabeldata.Columns.Add("عدد التعبئة");
                mytabeldata.Columns.Add("الكمية / التعبئة");

                mytabeldata.Columns.Add("إسم المحتوى");
                mytabeldata.Columns.Add("عدد المحتوي بالتعبئة");
                mytabeldata.Columns.Add("الكمية / المحتوى");
                mytabeldata.Columns.Add("إجمالى الكمية");


                for (int i = 0; i < bottom_containers.Count; i++)
                {
                    string[] mydata = new string[9];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = peel_off_containers[i].client_name;
                    mydata[2] = peel_off_containers[i].container_name;
                    mydata[3] = peel_off_containers[i].number_of_containers.ToString();
                    mydata[4] = peel_off_containers[i].container_no_of_items.ToString();

                    mydata[5] = peel_off_containers[i].subcontainer_name.ToString();
                    mydata[6] = peel_off_containers[i].no_of_sub_container_per_container.ToString();
                    mydata[7] = peel_off_containers[i].no_items_per_sub_container.ToString();
                    mydata[8] = peel_off_containers[i].total_number_of_items.ToString();
                    mytabeldata.Rows.Add(mydata);
                }
                finished_product_properties_grid_view.DataSource = mytabeldata;
            }
        }



        async Task fillplasticmoldgridview()
        {
            await getgallplasticmolddata();
            if (plastic_mold_sepecifications.Count > 0)
            {
                DataTable mydata = new DataTable();
                mydata.Columns.Add("م");
                mydata.Columns.Add("إسم العميل");
                mydata.Columns.Add("مقاس الطبة");
                mydata.Columns.Add("لون الطبة");
                mydata.Columns.Add("نوع الطبة");
                mydata.Columns.Add("التعبئة");
                mydata.Columns.Add("عدد التعبئة");
                mydata.Columns.Add("إجمالى الكمية");
                //MessageBox.Show(plastic_mold_sepecifications.Count.ToString());

                for (int i = 0; i < plastic_mold_sepecifications.Count; i++)
                {
                    string[] mytabeldata = new string[8];
                    mytabeldata[0] = (i + 1).ToString();
                    mytabeldata[1] = plastic_mold_sepecifications[i].client_name;
                    mytabeldata[2] = plastic_mold_sepecifications[i].size_name;
                    mytabeldata[3] = plastic_mold_sepecifications[i].SH_PILLOW_COLOR_NAME;
                    mytabeldata[4] = plastic_mold_sepecifications[i].SH_MOLD_TYPE_NAME;
                    mytabeldata[5] = plastic_mold_sepecifications[i].container_name;
                    mytabeldata[6] = plastic_mold_sepecifications[i].SH_NO_OF_CONTAINERS.ToString();
                    mytabeldata[7] = plastic_mold_sepecifications[i].total_number_of_items.ToString();

                    mydata.Rows.Add(mytabeldata);

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
                    item_sizes.Add(new SH_ITEM_SIZE()
                    {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()),

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
                MessageBox.Show("ERROR WHIlE GETTING SIZES DATA " + ex.ToString());
            }

            if (item_sizes.Count > 0)
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
                    mold_sizes.Add(new SH_MOLD_SIZE()
                    {
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
                    twist_of_sizes.Add(new SH_TWIST_OF_SIZE()
                    {
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
                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "إسم الصنف";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;

                f4_label.Text = "F4";
                f4_label.Visible = false;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = false;

                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;

                await getallclientproductsforclientandgeneral();


            }
            else if (product_type_combo_box.SelectedIndex == 1)
            {
                //bottom 
                // sizes combo box
                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "المقاس";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = true;

                f2_label.Text = "نوع الخام";
                f2_label.Visible = true;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = true;
                f3_label.Text = "الإستخدام";
                f3_label.Visible = true;

                f4_label.Text = "حالة الطباعة";
                f4_label.Visible = true;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = true;

                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;

                await fillprintingtypecombobox();
                await fillitemusagecombobox();
                await fillitemmaterialtypescombobox();
                await loadallsizesDATA();



            }
            else if (product_type_combo_box.SelectedIndex == 2)
            {
                //rlt 
                // sizes combo box

                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "المقاس";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = true;

                f2_label.Text = "نوع الخام";
                f2_label.Visible = true;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = true;
                f3_label.Text = "الإستخدام";
                f3_label.Visible = true;

                f4_label.Text = "حالة الطباعة";
                f4_label.Visible = true;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = true;

                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;

                await fillrltprintingtypecombobox();
                await fillrltitemusagecombobox();
                await fillitemmaterialtypescombobox();
                await loadallsizesDATA();
            }
            else if (product_type_combo_box.SelectedIndex == 3)
            {
                //easyopen
                // sizes combo box
                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "المقاس";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = false;
                f2_label.Text = "F2";
                f2_label.Visible = false;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;



                f4_label.Text = "F4";
                f4_label.Visible = false;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = false;


                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;

                await filleasyopenprintingtypecombobox();
                await filleasyopenitemusagecombobox();
                await fillitemmaterialtypescombobox();
                await loadallsizesDATA();
            }
            else if (product_type_combo_box.SelectedIndex == 4)
            {
                //peeloff
                // sizes combo box

                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "المقاس";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = true;

                f2_label.Text = "نوع الخام";
                f2_label.Visible = true;

                f3_combo_box.Text = "";
                f3_combo_box.Visible = true;
                f3_label.Text = "الإستخدام";
                f3_label.Visible = true;

                f4_label.Text = "حالة الطباعة";
                f4_label.Visible = true;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = true;

                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;


                await loadallsizesDATA();
                await fillpeeloffprintingtypecombobox();
                await fillpeeloffitemusagecombobox();
                await fillitemmaterialtypescombobox();
            }
            else if (product_type_combo_box.SelectedIndex == 5)
            {
                //twistoff
                // twist of combo box

                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

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


                f4_label.Text = "F4";
                f4_label.Visible = false;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = false;

                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;


                //   await loadtwistofsizesdata();
            }
            else if (product_type_combo_box.SelectedIndex == 6)
            {
                //plastic cover
                // sizes combo box

                finished_product_properties_grid_view.DataSource = null;
                f2_combo_box.DataSource = null;
                f1_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "المقاس";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = true;
                f2_label.Text = "اللون";
                f2_label.Visible = true;


                f3_combo_box.Text = "";
                f3_combo_box.Visible = false;
                f3_label.Text = "F3";
                f3_label.Visible = false;


                f4_label.Text = "F4";
                f4_label.Visible = false;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = false;

                c_box_1.Text = "لوجو";
                c_box_1.Visible = true;


                await loadallsizesDATA();
                await loadplasticcoverpillowcolors();
            }
            else if (product_type_combo_box.SelectedIndex == 7)
            {
                //plastic mold
                // mold size combo box

                finished_product_properties_grid_view.DataSource = null;
                f1_combo_box.DataSource = null;
                f2_combo_box.DataSource = null;
                f3_combo_box.DataSource = null;
                f4_combo_box.DataSource = null;

                f1_combo_box.Text = "";
                f1_combo_box.Visible = true;
                f1_label.Text = "مقاس الطبة";
                f1_label.Visible = true;

                f2_combo_box.Text = "";
                f2_combo_box.Visible = true;
                f2_label.Text = "لون الطبة";
                f2_label.Visible = true;


                f3_combo_box.Text = "";
                f3_combo_box.Visible = true;
                f3_label.Text = "نوع الطبة";
                f3_label.Visible = true;


                f4_label.Text = "F4";
                f4_label.Visible = false;
                f4_combo_box.Text = "";
                f4_combo_box.Visible = false;

                c_box_1.Text = "chBoX1";
                c_box_1.Visible = false;

                await loadmoldsizesdata();
                await loadmoldpillowcolors();
                await loadmoldtypes();
            }
        }

        async Task fillprintingtypecombobox()
        {
            List<string> mydata = new List<string>();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SH_PRINTING_TYPE_NAME FROM SH_SPECIFICATION_OF_BOTTOM WHERE SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mydata.Add(reader["SH_PRINTING_TYPE_NAME"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GETTING PRINTING TYPES " + ex.ToString());
            }

            f4_combo_box.DataSource = null;
            f4_combo_box.Items.Clear();
            for (int i = 0; i < mydata.Count; i++)
            {
                f4_combo_box.Items.Add(mydata[i]);
            }
        }

        async Task fillrltprintingtypecombobox()
        {
            f4_combo_box.DataSource = null;
            f4_combo_box.Items.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SH_PRINTING_TYPE_NAME FROM SH_SPECIFICATION_OF_RLT WHERE SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')  ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f4_combo_box.Items.Add(reader["SH_PRINTING_TYPE_NAME"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GETTING PRINTING TYPES " + ex.ToString());
            }

        }
        async Task fillpeeloffprintingtypecombobox()
        {
            f4_combo_box.DataSource = null;
            f4_combo_box.Items.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SH_PRINTING_TYPE_NAME FROM SH_SPECIFICATION_OF_PEEL_OFF WHERE SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')  ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f4_combo_box.Items.Add(reader["SH_PRINTING_TYPE_NAME"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GETTING PRINTING TYPES " + ex.ToString());
            }
        }

        async Task filleasyopenprintingtypecombobox()
        {
            f4_combo_box.DataSource = null;
            f4_combo_box.Items.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT SH_PRINTING_TYPE_NAME FROM SH_SPECIFICATION_OF_EASY_OPEN WHERE SH_CLIENT_ID = @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')  ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f4_combo_box.Items.Add(reader["SH_PRINTING_TYPE_NAME"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GETTING PRINTING TYPES " + ex.ToString());
            }
        }

        async Task fillitemusagecombobox()
        {

            f4_combo_box.DataSource = null;
            List<string> mydata = new List<string>();

            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT  SH_USAGE FROM  SH_SPECIFICATION_OF_BOTTOM  WHERE SH_CLIENT_ID =  @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')", DatabaseConnection.mConnection);
            cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                mydata.Add(reader["SH_USAGE"].ToString());
            }
            reader.Close();
            myconnection.closeConnection();
            f3_combo_box.DataSource = mydata;

        }

        async Task fillrltitemusagecombobox()
        {

            f4_combo_box.DataSource = null;
            List<string> mydata = new List<string>();

            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT  SH_USAGE FROM  SH_SPECIFICATION_OF_RLT  WHERE SH_CLIENT_ID =  @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')", DatabaseConnection.mConnection);
            cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                mydata.Add(reader["SH_USAGE"].ToString());
            }
            reader.Close();
            myconnection.closeConnection();
            f3_combo_box.DataSource = mydata;

        }

        async Task filleasyopenitemusagecombobox()
        {

            f4_combo_box.DataSource = null;
            List<string> mydata = new List<string>();

            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT  SH_USAGE FROM  SH_SPECIFICATION_OF_EASY_OPEN  WHERE SH_CLIENT_ID =  @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')", DatabaseConnection.mConnection);
            cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                mydata.Add(reader["SH_USAGE"].ToString());
            }
            reader.Close();
            myconnection.closeConnection();
            f3_combo_box.DataSource = mydata;

        }

        async Task fillpeeloffitemusagecombobox()
        {

            f4_combo_box.DataSource = null;
            List<string> mydata = new List<string>();

            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT  SH_USAGE FROM  SH_SPECIFICATION_OF_PEEL_OFF  WHERE SH_CLIENT_ID =  @SH_CLIENT_ID OR SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')", DatabaseConnection.mConnection);
            cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                mydata.Add(reader["SH_USAGE"].ToString());
            }
            reader.Close();
            myconnection.closeConnection();
            f3_combo_box.DataSource = mydata;

        }


        async Task fillitemmaterialtypescombobox()
        {
            material_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_MATERIAL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    material_types.Add(new SH_MATERIAL_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MATERIAL_TYPE_NAME = reader["SH_MATERIAL_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETIIGN MATERIAL TYPES DATA " + ex.ToString());
            }

            if (material_types.Count > 0)
            {
                //f2_combo_box.Items.Clear();
                List<string> types = new List<string>();
                for (int i = 0; i < material_types.Count; i++)
                {
                    types.Add(material_types[i].SH_MATERIAL_TYPE_NAME);
                }
                f2_combo_box.DataSource = types;
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

        async Task loadplasticcoverpillowcolors()
        {


            pillow_colors.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_SPECIFIED_PILLOW_COLORS_PLASTIC_COVER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pillow_colors.Add(new SH_COLOR_PILLOW()
                    {
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
                MessageBox.Show("ERROR WHILE GETTInG PILLOW CoLORs DATA " + ex.ToString());
            }


            if (pillow_colors.Count > 0)
            {
                List<string> colors = new List<string>();
                for (int i = 0; i < pillow_colors.Count; i++)
                {
                    colors.Add(pillow_colors[i].SH_COLOR_NAME);
                }
                f2_combo_box.DataSource = colors;
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
                    pillow_colors.Add(new SH_COLOR_PILLOW()
                    {
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
                MessageBox.Show("ERROR WHILE GETTInG PILLOW CoLORs DATA " + ex.ToString());
            }


            if (pillow_colors.Count > 0)
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

            f4_label.Text = "F4";
            f4_label.Visible = false;
            f4_combo_box.Text = "";
            f4_combo_box.Visible = false;

            c_box_1.Text = "chBoX1";
            c_box_1.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            back = 0;
            this.Close();
        }

        private async void get_client_data_btn_Click(object sender, EventArgs e)
        {
            finished_product_properties_grid_view.DataSource = null;
            switch (product_type_combo_box.SelectedIndex)
            {
                case 0:
                    {
                        // finished cans 
                        await fillfinishedcansgridview();
                        break;
                    }
                case 1:
                    {
                        //bottom 
                        await fillbottomdatagridview();
                        break;
                    }
                case 2:
                    {
                        //rlt
                        await fillrltgridview();
                        break;
                    }
                case 3:
                    {
                        //easy open
                        await filleasyopengridview();
                        break;
                    }
                case 4:
                    {
                        //peel off
                        await fillpelloffgridview();
                        break;
                    }
                case 5:
                    {
                        //twist of
                        await filltwistofgridview();
                        break;
                    }
                case 6:
                    {
                        //plastic cover

                        await fillplasticcovergridview();
                        break;
                    }
                case 7:
                    {
                        await fillplasticmoldgridview();
                        break;
                    }
                default:
                    break;
            }
        }

        private void finished_product_properties_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void finished_product_properties_grid_view_SelectionChanged(object sender, EventArgs e)
        {
            if (finished_product_properties_grid_view.SelectedRows.Count > 0)
            {
                switch (product_type_combo_box.SelectedIndex)
                {
                    case 0:
                        {
                            //cans
                            //container_name_text_box.Text = finished_cans[finished_product_properties_grid_view.SelectedRows[0].Index].
                            container_name_text_box.Text = "بالتة";
                            no_items_per_container_text_box.Text = finished_cans[finished_product_properties_grid_view.SelectedRows[0].Index].SH_PARCEL_NO_OF_CANS.ToString();
                            break;
                        }
                    case 1:
                        {
                            //bottom
                            container_name_text_box.Text = bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();
                            break;
                        }
                    case 2:
                        {
                            //rlt
                            container_name_text_box.Text = rlt_containetrs[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = rlt_containetrs[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();

                            break;
                        }
                    case 3:
                        {
                            //easy open
                            container_name_text_box.Text = easy_open_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = easy_open_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();

                            break;
                        }
                    case 4:
                        {
                            //peel off
                            container_name_text_box.Text = peel_off_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = peel_off_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();

                            break;
                        }
                    case 5:
                        {
                            // twist off
                            container_name_text_box.Text = twist_of_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = twist_of_containers[finished_product_properties_grid_view.SelectedRows[0].Index].no_items_per_container.ToString();
                            break;
                        }
                    case 6:
                        {
                            //plastic cover
                            container_name_text_box.Text = plastic_cover_data[finished_product_properties_grid_view.SelectedRows[0].Index].SH_CONTAINER_NAME;
                            no_items_per_container_text_box.Text = plastic_cover_data[finished_product_properties_grid_view.SelectedRows[0].Index].SH_TOTAL_NO_ITEMS.ToString();

                            break;
                        }
                    case 7:
                        {
                            //plastic mold
                            container_name_text_box.Text = plastic_mold_sepecifications[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = plastic_mold_sepecifications[finished_product_properties_grid_view.SelectedRows[0].Index].total_number_of_items.ToString();

                            break;
                        }
                    default:
                        break;
                }
            }


        }

        async Task getselectedfinishedproductparcels()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_PALLETS_WITH_SPECIFICED_NO_OF_CANS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[f1_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CANS", long.Parse(no_items_per_container_text_box.Text));
                cmd.Parameters.AddWithValue("@NO_PALLETS", long.Parse(no_of_selected_containers_text_box.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT> anycanspallets = new List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT>();
                while (reader.Read())
                {
                    anycanspallets.Add(new SH_ADDED_PARCELS_OF_FINISHED_PRODUCT()
                    {
                        SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID = long.Parse(reader["SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID"].ToString())
                        ,
                        SH_ADDING_PERMISSION_NUMBER = reader["SH_ADDING_PERMISSION_NUMBER"].ToString(),
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID = long.Parse(reader["SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID"].ToString())
                        ,
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                        SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_LAST_RECORD_NUMBER_OF_CANS = long.Parse(reader["SH_LAST_RECORD_NUMBER_OF_CANS"].ToString())
                         ,
                        SH_NUMBER_OF_CANS_HEIGHT = long.Parse(reader["SH_NUMBER_OF_CANS_HEIGHT"].ToString()),
                        SH_NUMBER_OF_CANS_LENGTH = long.Parse(reader["SH_NUMBER_OF_CANS_LENGTH"].ToString()),
                        SH_NUMBER_OF_CANS_WIDTH = long.Parse(reader["SH_NUMBER_OF_CANS_WIDTH"].ToString()),
                        SH_STOCK_ID = long.Parse(reader["SH_STOCK_ID"].ToString()),
                        SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(),
                        SH_TOTAL_NUMBER_OF_CANS = long.Parse(reader["SH_TOTAL_NUMBER_OF_CANS"].ToString()),
                        SH_WORK_ORDER_NUMBER = reader["SH_WORK_ORDER_NUMBER"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();

                dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA()
                {
                    total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                    cans_parcels = anycanspallets,
                    product_type = product_type_combo_box.SelectedIndex,
                    product_name = product_type_combo_box.Text,
                    no_of_selected_containers = anycanspallets.Count
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FINISHED PRODUCT PARCELS " + ex.ToString());
            }
        }
        async Task getselectedcontainersofbottom()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_BOTTOM_CONTAINERS_SPECIFIED", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", f2_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_USAGE", f3_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", f4_combo_box.Text);
                cmd.Parameters.AddWithValue("@NO_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                List<SH_CONTAINER_OF_BOTTOM> anybottom_containers = new List<SH_CONTAINER_OF_BOTTOM>();
                while (reader.Read())
                {
                    anybottom_containers.Add(new SH_CONTAINER_OF_BOTTOM() {
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_QUANTITY_OF_BOTTOM_ID = long.Parse(reader["SH_QUANTITY_OF_BOTTOM_ID"].ToString()),
                         SH_SPECIFICATION_OF_BOTTOM_ID = long.Parse(reader["SH_SPECIFICATION_OF_BOTTOM_ID"].ToString()),
                         SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });

                }
                reader.Close();
                myconnection.closeConnection();
                dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA()
                {
                    total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                    bottom_containers = anybottom_containers,
                    product_type = product_type_combo_box.SelectedIndex,
                    product_name = product_type_combo_box.Text,
                    no_of_selected_containers = anybottom_containers.Count
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GeTTING BOTTOM CONTAINERS DATA " + ex.ToString());
            }
        }
        async Task filldismissedcontainersgridview()
        {
            dismissed_containers_grid_view.Rows.Clear();
            if (dismissed_containers.Count > 0)
            {
                for (int i = 0; i < dismissed_containers.Count; i++)
                {
                    switch (dismissed_containers[i].product_type)
                    {
                        case 0:
                            {
                                //cans
                                dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    dismissed_containers[i].cans_parcels[0].SH_CLIENT_NAME,
                                    dismissed_containers[i].cans_parcels[0].SH_CLIENT_PRODUCT_NAME,
                                    "بالتة",
                                    dismissed_containers[i].cans_parcels.Count.ToString(),
                                    dismissed_containers[i].cans_parcels[0].SH_TOTAL_NUMBER_OF_CANS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                break;
                            }
                        case 1:
                            {
                                //bottom data

                                dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "",
                                     dismissed_containers[i].bottom_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].bottom_containers.Count.ToString(),
                                    dismissed_containers[i].bottom_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });


                                break;
                            }

                        default:
                            break;
                    }
                }

            }

        }


        private async void add_new_product_with_quantity_btn_Click(object sender, EventArgs e)
        {
            if (finished_product_properties_grid_view.SelectedRows.Count > 0)
            {
                switch (product_type_combo_box.SelectedIndex)
                {
                    case 0:
                        {
                            //cans
                            //get top no_of_containers_pallets_of_product_specifications

                            await getselectedfinishedproductparcels();
                            await filldismissedcontainersgridview();


                            break;
                        }
                    case 1:
                        {
                            //bottom

                            await getselectedcontainersofbottom();
                            await filldismissedcontainersgridview();


                            break;
                        }
                    case 2:
                        {

                            //rlt
                            break;
                        }
                    case 3:
                        {
                            //easy open
                            break;
                        }
                    case 4:
                        {
                            //peel off
                            break;
                        }
                    case 5:
                        {
                            //twist of
                            break;
                        }
                    case 6:
                        {
                            //plastic cover
                            break;
                        }
                    case 7:
                        {
                            //plastic mold
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void client_text_box_TextChanged(object sender, EventArgs e)
        {

        }

        async Task calculatetotalno_items()
        {
            if (string.IsNullOrWhiteSpace(no_of_selected_containers_text_box.Text) || string.IsNullOrWhiteSpace(no_items_per_container_text_box.Text))
            {

            }
            else
            {
                long testnumber = 0;
                if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber) && long.TryParse(no_items_per_container_text_box.Text, out testnumber))
                {
                    total_number_of_items_of_selected_containers.Text = (long.Parse(no_of_selected_containers_text_box.Text) * long.Parse(no_items_per_container_text_box.Text)).ToString();
                }
            }
        }
        private async void no_of_selected_containers_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(no_of_selected_containers_text_box.Text))
            {

            }
            else
            {
                switch (product_type_combo_box.SelectedIndex)
                {
                    case 0:
                        {
                            //cans
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (finished_cans[finished_product_properties_grid_view.SelectedRows[0].Index].SH_TOTAL_NUMBER_OF_PALLET < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            //bottom
                            break;
                        }
                    case 2:
                        {

                            //rlt
                            break;
                        }
                    case 3:
                        {
                            //easy open
                            break;
                        }
                    case 4:
                        {
                            //peel off
                            break;
                        }
                    case 5:
                        {
                            //twist of
                            break;
                        }
                    case 6:
                        {
                            //plastic cover
                            break;
                        }
                    case 7:
                        {
                            //plastic mold
                            break;
                        }
                    default:
                        break;
                }


                await calculatetotalno_items();
            }
        }

        private async void no_items_per_container_text_box_TextChanged(object sender, EventArgs e)
        {
            await calculatetotalno_items();
        }

        private void return_to_opened_recival_permission_order_btn_Click(object sender, EventArgs e)
        {
            back = 1;
            this.Close();
        }
    }
}

