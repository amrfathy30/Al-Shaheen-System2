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
        List<plastic_cover_container_data> plastic_cover_data = new List<plastic_cover_container_data>();
        List<finished_cans_model_data> finished_cans = new List<finished_cans_model_data>();

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
                f1_combo_box.Items.Clear();
                for (int i = 0; i < client_products.Count; i++)
                {
                    f1_combo_box.Items.Add(client_products[i].SH_PRODUCT_NAME);
                }
                

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
                    size_string = " AND SPPC.SH_SIZE_ID = @SH_SIZE_ID ";
                }

                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    pillow_color = false;
                }
                else
                {
                    pillow_color = true;
                    pillow_color_string = " AND SPPC.SH_PILLOW_COLOR_ID = @SH_PILLOW_COLOR_ID ";
                }

                string query = " SELECT SPPC.SH_CLIENT_ID ,";
                query += "(SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC ";
                query += "WHERE CC.SH_ID = SPPC.SH_CLIENT_ID) AS ";
                query += " SH_CLIENT_COMPANY_NAME ,";
                query += "(SELECT ITS.SH_SIZE_NAME FROM SH_ITEM_SIZE ITS WHERE ";
                query += " ITS.SH_ID = SPPC.SH_SIZE_ID ";
                query += " ) AS SH_SIZE_NAME ";
                query += " ,";
                query += "  (SELECT CP.SH_COLOR_NAME FROM SH_COLOR_PILLOW CP ";
                query += " WHERE CP.SH_ID = SPPC.SH_PILLOW_COLOR_ID ) AS SH_PILLOW_COLOR ";
                query += ",";
                query += " SPPC.SH_LOGO_OR_NOT ,";
                query += "SPPC.SH_PILLOW_COLOR_ID,";
                query += "SPPC.SH_SIZE_ID ,";
                query += "SUM(CPC.SH_NO_ITEMS) AS TOTAL_NO_ITEMS,";
                query += "CPC.SH_NO_ITEMS AS CONTAINER_NO_OF_ITEMS ,";
                query += " CPC.SH_CONTAINER_NAME , ";
                query += " count(CPC.SH_ID) AS NO_OF_CONTAINERS ";
                query += " FROM SH_CONTAINERS_OF_PLASTIC_COVER CPC ";
                query += " JOIN SH_QUANTITY_OF_PLASTIC_COVER QPC ON ";
                query += " QPC.SH_ID = CPC.SH_QUANTITY_OF_PLASTIC_COVER_ID ";
                query += " JOIN SH_SPECIFICATION_OF_PLASTIC_COVER SPPC ON ";
                query += " SPPC.SH_ID = QPC.SH_SPECIFICATION_OF_PLASTIC_COVER_ID ";
                query += " WHERE(SPPC.SH_CLIENT_ID = @SH_CLIENT_ID  OR ";
                query += " SPPC.SH_CLIENT_ID IN(SELECT CC.SH_ID FROM ";
                query += " SH_CLIENT_COMPANY CC WHERE CC.SH_CLIENT_COMPANY_NAME ";
                query += " LIKE N'%عام%')) AND CPC.SH_ID NOT IN ";
                query += "     (SELECT SDCPC.SH_ID FROM ";
                query += " SH_DISMISSAL_CONTAINERS_OF_PLASTIC_COVER SDCPC ";
                query += " WHERE SDCPC.SH_ID = CPC.SH_ID) AND SPPC.SH_LOGO_OR_NOT =  @SH_LOGO_OR_NOT ";
                query += size_string + pillow_color_string;
                query += " GROUP BY SPPC.SH_CLIENT_ID , SH_SIZE_ID, ";
                query += "    CPC.SH_CONTAINER_NAME, CPC.SH_NO_ITEMS , ";
                query += " SPPC.SH_PILLOW_COLOR_ID ,SPPC.SH_LOGO_OR_NOT ";
                query += " ORDER BY SPPC.SH_CLIENT_ID , SH_SIZE_ID, CPC.SH_CONTAINER_NAME, CPC.SH_NO_ITEMS , ";
                query += " SPPC.SH_PILLOW_COLOR_ID ,SPPC.SH_LOGO_OR_NOT";
               
                    
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
                    plastic_cover_data.Add(new plastic_cover_container_data()
                    {
                        client_id = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        container_name = reader["SH_CONTAINER_NAME"].ToString(),
                        logo_or_not = long.Parse(reader["SH_LOGO_OR_NOT"].ToString()),
                        no_of_containers = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        pillow_color_id = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()),
                        pillow_color_name = reader["SH_PILLOW_COLOR"].ToString(),
                        size_name = reader["SH_SIZE_NAME"].ToString(),
                        size_id = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        container_no_of_items = long.Parse(reader["CONTAINER_NO_OF_ITEMS"].ToString()),
                        total_no_items = long.Parse(reader["TOTAL_NO_ITEMS"].ToString())
                        
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
                mydata.Columns.Add("الكمية / التعبئة");
                mydata.Columns.Add("إجمالى الكمية");
                //MessageBox.Show(plastic_mold_sepecifications.Count.ToString());

                for (int i = 0; i < plastic_cover_data.Count; i++)
                {
                    string[] mytabeldata = new string[9];
                    mytabeldata[0] = (i + 1).ToString();
                    mytabeldata[1] = plastic_cover_data[i].client_name;
                    mytabeldata[2] = plastic_cover_data[i].size_name;
                    mytabeldata[3] = plastic_cover_data[i].pillow_color_name;
                    if (plastic_cover_data[i].logo_or_not == 0)
                    {
                        mytabeldata[4] = "لا يوجد";
                    }
                    else
                    {
                        mytabeldata[4] = " يوجد";
                    }
                    mytabeldata[5] = plastic_cover_data[i].container_name;
                    mytabeldata[6] = plastic_cover_data[i].no_of_containers.ToString();
                    mytabeldata[7] = plastic_cover_data[i].container_no_of_items.ToString();
                    mytabeldata[8] = plastic_cover_data[i].total_no_items.ToString();
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
                bool product = false;
                bool msize = false;
                string product_string = "";
                string size_string = "";

                if (string.IsNullOrEmpty(f1_combo_box.Text))
                {
                    product = false;
                }else
                {
                    product = true;
                    product_string = " AND CTFP.SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID";
                }

                if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                {
                    msize = false;
                }else
                {
                    size_string = " AND CP.SH_SIZE_ID = @SH_SIZE_ID";
                }


                myconnection.openConnection();

                string query = " SELECT COUNT(APFP.SH_ID)AS TOTAL_NO_PALLET, APFP.SH_TOTAL_NUMBER_OF_CANS AS PALLET_NO_OF_CANS, ";
                query += " SUM(APFP.SH_TOTAL_NUMBER_OF_CANS) AS QUANTITY_NUMBER_OF_CANS, ";
                query += " ITS.SH_SIZE_NAME, ";
                query += " ITS.SH_ID AS SH_SIZE_ID, ";
                query += " CTFP.SH_ID AS SPECIFICATION_ID,";
                query += " CC.SH_ID as SH_CLIENT_ID, ";
                query += " CC.SH_CLIENT_COMPANY_NAME, ";
                query += " CP.SH_ID AS CLIENT_PRODUCT_ID, ";
                query += " CP.SH_PRODUCT_NAME ";
                query += " FROM SH_ADDED_PARCELS_OF_FINISHED_PRODUCT APFP ";
                query += " LEFT JOIN SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS AQFP ON ";
                query += " AQFP.SH_ID = APFP.SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID ";
                query += " LEFT JOIN SH_CALCULATE_TOTAL_FINISHED_PRODUCT CTFP ON ";
                query += " CTFP.SH_ID = AQFP.SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID ";
                query += " LEFT JOIN SH_CLIENT_COMPANY CC ON ";
                query += " CC.SH_ID = CTFP.SH_CLIENT_ID ";
                query += " LEFT JOIN SH_CLIENTS_PRODUCTS CP ON ";
                query += " CP.SH_ID = CTFP.SH_CLIENT_PRODUCT_ID ";
                query += " LEFT JOIN SH_ITEM_SIZE ITS ON ";
                query += " CP.SH_SIZE_ID = ITS.SH_ID ";
                query += " LEFT  JOIN SH_DISMISSED_PALLETS_OF_FINISHED_CANS DPFP ON ";
                query += " DPFP.SH_ADDED_PARCELS_OF_FINISHED_PRODUCT_ID = APFP.SH_ID ";
                query += " WHERE DPFP.SH_ADDED_PARCELS_OF_FINISHED_PRODUCT_ID is null ";
                query += " AND (CTFP.SH_CLIENT_ID = @SH_CLIENT_ID OR CC.SH_CLIENT_COMPANY_NAME LIKE N'عام') ";
                query += size_string + product_string;

                //query += "GROUP BY CP.SH_ID,
                query += " GROUP BY APFP.SH_TOTAL_NUMBER_OF_CANS,CP.SH_PRODUCT_NAME, CP.SH_ID, CTFP.SH_ID,  CC.SH_ID, CC.SH_CLIENT_COMPANY_NAME, ITS.SH_SIZE_NAME,  ITS.SH_ID ";
                query += " ORDER BY APFP.SH_TOTAL_NUMBER_OF_CANS DESC ";

                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                if (product)
                {
                    cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", client_products[f1_combo_box.SelectedIndex].SH_ID);
                }
                if (msize)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f2_combo_box.SelectedIndex].SH_ID);

                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    finished_cans.Add(new finished_cans_model_data()
                    {
                        client_name = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        no_cans_per_pallet = long.Parse(reader["PALLET_NO_OF_CANS"].ToString()),
                        no_pallets = long.Parse(reader["TOTAL_NO_PALLET"].ToString()),
                        product_name = reader["SH_PRODUCT_NAME"].ToString(),
                        size_name = reader["SH_SIZE_NAME"].ToString(),
                        specification_id = long.Parse(reader["SPECIFICATION_ID"].ToString())
                        , total_no_cans = long.Parse(reader["QUANTITY_NUMBER_OF_CANS"].ToString())
                        , client_id = long.Parse(reader["SH_CLIENT_ID"].ToString())
                        , client_product_id = long.Parse(reader["CLIENT_PRODUCT_ID"].ToString())
                        ,size_id = long.Parse(reader["SH_SIZE_ID"].ToString())
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
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("عدد التعبئة");
                mydatatabel.Columns.Add("عدد العلب بالتعبئة");
                mydatatabel.Columns.Add("إجمالى عدد العلب");

                for (int i = 0; i < finished_cans.Count; i++)
                {
                    string[] mydata = new string[8];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = finished_cans[i].client_name;
                    mydata[2] = finished_cans[i].product_name;
                    mydata[3] = finished_cans[i].size_name;
                    mydata[4] = "بالتة";
                    mydata[5] = finished_cans[i].no_pallets.ToString();
                    mydata[6] = finished_cans[i].no_cans_per_pallet.ToString();
                    mydata[7] = finished_cans[i].total_no_cans.ToString();
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
                    MOLD_SIZE_STRING = " AND SPPM.SH_SIZE_ID = @SH_SIZE_ID";
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
                    PILLOW_COLOR_STRING = " AND SPPM.SH_PILLOW_COLOR_ID = @SH_PILLOW_COLOR_ID";
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
                    MOLD_TYPE_STRING = " AND SPPM.SH_MOLD_TYPE_ID = @SH_MOLD_TYPE_ID";
                }
            }
            string query = " SELECT ";
            query += " CPM.SH_CONTAINER_NAME , ";
            query += " COUNT(CPM.SH_ID) AS NO_OF_CONTAINERS, ";
            query += " SUM(CPM.SH_NO_ITEMS)AS TOTAL_NO_ITEMS, ";
            query += " SPPM.SH_CLIENT_ID, ";
            query += " (SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE ";
            query += " CC.SH_ID = SPPM.SH_CLIENT_ID ";
            query += ") AS SH_CLIENT_COMPANY_NAME, ";
            query += "CPM.SH_NO_ITEMS , ";
            query += "SPPM.SH_PILLOW_COLOR_ID, ";
            query += "(SELECT CP.SH_COLOR_NAME FROM SH_COLOR_PILLOW CP WHERE CP.SH_ID = ";
            query += "    SPPM.SH_PILLOW_COLOR_ID ) AS SH_COLOR_NAME,";
            query += "SPPM.SH_SIZE_ID, ";
            query += " (SELECT ITS.SH_MOLD_SIZE_VALUE FROM SH_MOLD_SIZE ITS WHERE ITS.SH_ID =SPPM.SH_SIZE_ID ) AS SH_SIZE_NAME,";
            query += "SPPM.SH_MOLD_TYPE_ID ,";
            query += "(SELECT MT.SH_MOLD_TYPE_NAME FROM SH_MOLD_TYPES MT ";
            query += " WHERE MT.SH_ID = SPPM.SH_MOLD_TYPE_ID )AS SH_MOLD_TYPE_NAME ";
            query += " FROM SH_CONTAINERS_OF_PLASTIC_MOLD CPM ";
            query += " JOIN SH_QUANTITY_OF_PLASTIC_MOLD QPM ON ";
            query += " QPM.SH_ID = CPM.SH_QUANTITY_OF_PLASTIC_MOLD_ID ";
            query += " JOIN SH_SPECIFICATION_OF_PLASTIC_MOLD SPPM ON ";
            query += " SPPM.SH_ID = QPM.SH_SPECIFICATION_OF_PLASTIC_MOLD_ID ";
            query += " WHERE(SPPM.SH_CLIENT_ID = @SH_CLIENT_ID OR ";
            query += " SPPM.SH_CLIENT_ID IN(SELECT CC.SH_ID FROM SH_CLIENT_COMPANY CC  ";
            query += " WHERE CC.SH_CLIENT_COMPANY_NAME LIKE N'%عام%')) ";
            query += MOLD_SIZE_STRING + MOLD_TYPE_STRING + PILLOW_COLOR_STRING;
            query += "  AND CPM.SH_ID NOT IN(SELECT DCPM.SH_ID FROM SH_DISMISSAL_CONTAINERS_OF_PLASTIC_MOLD DCPM WHERE DCPM.SH_CONTAINER_OF_PLASTIC_MOLD_ID = CPM.SH_ID)";
            query += " GROUP BY CPM.SH_CONTAINER_NAME ,SPPM.SH_MOLD_TYPE_ID , ";
            query += " SPPM.SH_PILLOW_COLOR_ID, ";
            query += " SPPM.SH_SIZE_ID, ";
            query += " CPM.SH_NO_ITEMS ,SPPM.SH_CLIENT_ID ";

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
                        SH_NO_OF_CONTAINERS = long.Parse(reader["NO_OF_CONTAINERS"].ToString()),
                        SH_PILLOW_COLOR_ID = long.Parse(reader["SH_PILLOW_COLOR_ID"].ToString()),
                        size_id = long.Parse(reader["SH_SIZE_ID"].ToString()),
                        SH_MOLD_TYPE_ID = long.Parse(reader["SH_MOLD_TYPE_ID"].ToString()),
                        total_number_of_items = long.Parse(reader["TOTAL_NO_ITEMS"].ToString()),
                        size_name = reader["SH_SIZE_NAME"].ToString(),
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
            await getalltwistofspecifications();
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
                query += " SPB.SH_PRINTING_TYPE_NAME ,SPB.SH_RAW_MATERIAL_TYPE, SPB.SH_SIZE_ID,(select ITS.SH_SIZE_NAME from SH_ITEM_SIZE ITS where ITS.SH_ID = SPB.SH_SIZE_ID ) as SIZE_NAME , SPB.SH_USAGE,";
                query += "COUNT(CB.SH_ID) AS NO_OF_CONTAINERS, SUM(CB.SH_TOTAL_NO_ITEMS)AS TOTAL_NUMBER_OF_ITEMS  FROM  SH_CONTAINER_OF_BOTTOM CB JOIN ";
                query += "SH_SPECIFICATION_OF_BOTTOM SPB ON SPB.SH_ID = CB.SH_SPECIFICATION_OF_BOTTOM_ID ";
                query += " WHERE  ((SPB.SH_CLIENT_ID = @SH_CLIENT_ID OR SPB.SH_CLIENT_ID IN (SELECT SH_ID  FROM SH_CLIENT_COMPANY WHERE SH_CLIENT_COMPANY_NAME LIKE N'عام')) OR SPB.SH_PRINTING_TYPE = 1 ) " + size_string + usage_string + material_type_string + printing_type_string + " AND CB.SH_ID NOT IN (SELECT DCB.SH_CONTAINER_OF_BOTTOM_ID FROM SH_DISMISSAL_CONTAINERS_OF_BOTTOM DCB WHERE DCB.SH_CONTAINER_OF_BOTTOM_ID = CB.SH_ID  )";
                query += " GROUP BY SPB.SH_CLIENT_ID , (CB.SH_CONTAINER_NAME), CB.SH_SUBCONTAINER_NAME, CB.SH_TOTAL_NO_ITEMS, CB.SH_TOTAL_NUMBER_OF_SUB_CONTAINERS, CB.SH_NO_ITEMS_PER_SUB_CONTAINER, CB.SH_NO_OF_SUB_CONTAINER_PER_CONTAINER ";
                query += ",SPB.SH_PRINTING_TYPE_NAME ,SPB.SH_RAW_MATERIAL_TYPE ,SPB.SH_SIZE_ID ,SPB.SH_USAGE";

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
                        , printing_type_name = reader["SH_PRINTING_TYPE_NAME"].ToString(),
                         raw_material_type = reader["SH_RAW_MATERIAL_TYPE"].ToString(),
                         size_id = long.Parse(reader["SH_SIZE_ID"].ToString()),
                          usage = reader["SH_USAGE"].ToString(),
                         
                          size_name = reader["SIZE_NAME"].ToString()
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
                mytabeldata.Columns.Add("حالة الطباعة");
                mytabeldata.Columns.Add("الإستخدام");
                mytabeldata.Columns.Add("نوع الخام");
                mytabeldata.Columns.Add("المقاس");
                mytabeldata.Columns.Add("إسم التعبئة");
                mytabeldata.Columns.Add("عدد التعبئة");
                mytabeldata.Columns.Add("الكمية / التعبئة");
                mytabeldata.Columns.Add("إسم المحتوى");
                mytabeldata.Columns.Add("عدد المحتوي بالتعبئة");
                mytabeldata.Columns.Add("الكمية / المحتوى");
                mytabeldata.Columns.Add("إجمالى الكمية");


                for (int i = 0; i < bottom_containers.Count; i++)
                {
                    string[] mydata = new string[13];
                    mydata[0] = (i + 1).ToString();
                    mydata[1] = bottom_containers[i].client_name;
                    mydata[2] = bottom_containers[i].printing_type_name;
                    mydata[3] = bottom_containers[i].usage;
                    mydata[4] = bottom_containers[i].raw_material_type;
                    mydata[5] = bottom_containers[i].size_name;
                   

                    mydata[6] = bottom_containers[i].container_name;
                    mydata[7] = bottom_containers[i].number_of_containers.ToString();
                    mydata[8] = bottom_containers[i].container_no_of_items.ToString();

                    mydata[9] = bottom_containers[i].subcontainer_name.ToString();
                    mydata[10] = bottom_containers[i].no_of_sub_container_per_container.ToString();
                    mydata[11] = bottom_containers[i].no_items_per_sub_container.ToString();
                    mydata[12] = bottom_containers[i].total_number_of_items.ToString();
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
                query += "AND CB.SH_ID NOT IN (SELECT DCR.SH_CONTAINER_OF_RLT_ID FROM SH_DISMISSAL_CONTAINERS_OF_RLT DCR WHERE DCR.SH_CONTAINER_OF_RLT_ID= CB.SH_ID)";
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


                for (int i = 0; i < rlt_containetrs.Count; i++)
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


                for (int i = 0; i < peel_off_containers.Count; i++)
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
                mydata.Columns.Add("الكمية / التعبئة");
                mydata.Columns.Add("إجمالى الكمية");
                //MessageBox.Show(plastic_mold_sepecifications.Count.ToString());

                for (int i = 0; i < plastic_mold_sepecifications.Count; i++)
                {
                    string[] mytabeldata = new string[9];
                    mytabeldata[0] = (i + 1).ToString();
                    mytabeldata[1] = plastic_mold_sepecifications[i].client_name;
                    mytabeldata[2] = plastic_mold_sepecifications[i].size_name;
                    mytabeldata[3] = plastic_mold_sepecifications[i].SH_PILLOW_COLOR_NAME;
                    mytabeldata[4] = plastic_mold_sepecifications[i].SH_MOLD_TYPE_NAME;
                    mytabeldata[5] = plastic_mold_sepecifications[i].container_name;
                    mytabeldata[6] = plastic_mold_sepecifications[i].SH_NO_OF_CONTAINERS.ToString();
                    mytabeldata[7] = (plastic_mold_sepecifications[i].total_number_of_items / plastic_mold_sepecifications[i].SH_NO_OF_CONTAINERS).ToString();
                    mytabeldata[8] = plastic_mold_sepecifications[i].total_number_of_items.ToString();

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
                        //plastic MOLD
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
                            no_items_per_container_text_box.Text = finished_cans[finished_product_properties_grid_view.SelectedRows[0].Index].no_cans_per_pallet.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 1:
                        {
                            //bottom
                            container_name_text_box.Text = bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 2:
                        {
                            //rlt
                            container_name_text_box.Text = rlt_containetrs[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = rlt_containetrs[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 3:
                        {
                            //easy open
                            container_name_text_box.Text = easy_open_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = easy_open_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 4:
                        {
                            //peel off
                            container_name_text_box.Text = peel_off_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = peel_off_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 5:
                        {
                            // twist off
                            container_name_text_box.Text = twist_of_containers[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = twist_of_containers[finished_product_properties_grid_view.SelectedRows[0].Index].no_items_per_container.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 6:
                        {
                            //plastic cover
                            container_name_text_box.Text = plastic_cover_data[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = plastic_cover_data[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    case 7:
                        {
                            //plastic mold
                            container_name_text_box.Text = plastic_mold_sepecifications[finished_product_properties_grid_view.SelectedRows[0].Index].container_name;
                            no_items_per_container_text_box.Text = plastic_mold_sepecifications[finished_product_properties_grid_view.SelectedRows[0].Index].total_number_of_items.ToString();
                            no_of_selected_containers_text_box.Text = "";
                            break;
                        }
                    default:
                        break;
                }
            }


        }

        async Task getselectedfinishedproductparcels(finished_cans_model_data mydata)
        {
            try
            {

                myconnection.openConnection();
                string query = " SELECT TOP(" + long.Parse(no_of_selected_containers_text_box.Text) + ") ";
                query += " ADPFP.*  FROM ";
                query += " SH_ADDED_PARCELS_OF_FINISHED_PRODUCT ADPFP ";
                query += " LEFT JOIN SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS AQFP ";
                query += " ON AQFP.SH_ID = ADPFP.SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID ";
                query += " LEFT JOIN SH_CALCULATE_TOTAL_FINISHED_PRODUCT CTFP ON ";
                query += " CTFP.SH_ID = AQFP.SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID ";
                query += " LEFT JOIN SH_CLIENT_COMPANY CC ON ";
                query += " CC.SH_ID = CTFP.SH_CLIENT_ID ";
                query += " LEFT JOIN SH_CLIENTS_PRODUCTS CP ON ";
                query += " CP.SH_ID = CTFP.SH_CLIENT_PRODUCT_ID ";
                query += " LEFT JOIN SH_ITEM_SIZE ITS ON ";
                query += " ITS.SH_ID = CP.SH_SIZE_ID ";
                query += " LEFT JOIN SH_DISMISSED_PALLETS_OF_FINISHED_CANS DPFP ON ";
                query += " DPFP.SH_ADDED_PARCELS_OF_FINISHED_PRODUCT_ID = ADPFP.SH_ID ";
                query += " WHERE DPFP.SH_ADDED_PARCELS_OF_FINISHED_PRODUCT_ID IS NULL ";
                query += " AND CTFP.SH_CLIENT_ID = @SH_CLIENT_ID ";
                query += " AND ADPFP.SH_TOTAL_NUMBER_OF_CANS = @NO_CANS ";
                query += " AND ADPFP.SH_CLIENT_PRODUCT_ID = @SH_CLIENT_PRODUCT_ID ";
                query += " AND ITS.SH_ID = @SH_ITEM_SIZE_ID ";
                query += " AND CTFP.SH_ID = @SH_SPECIFICATION_ID ";
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                //MessageBox.Show(mydata.no_cans_per_pallet.ToString());
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mydata.client_id);
                cmd.Parameters.AddWithValue("@SH_CLIENT_PRODUCT_ID", mydata.client_product_id);
                cmd.Parameters.AddWithValue("@NO_CANS", mydata.no_cans_per_pallet);
               // cmd.Parameters.AddWithValue("@NO_PALLETS", );
                cmd.Parameters.AddWithValue("@SH_ITEM_SIZE_ID" , mydata.size_id);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_ID" ,mydata.specification_id );

                SqlDataReader reader = cmd.ExecuteReader();
                List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT> anycanspallets = new List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT>();
                long counter = 0;
                while (reader.Read())
                {
                    //MessageBox.Show("HERE #1");
                    counter++;
                    anycanspallets.Add(new SH_ADDED_PARCELS_OF_FINISHED_PRODUCT()
                    {
                        SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID = long.Parse(reader["SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS_ID"].ToString()),
                        SH_ADDING_PERMISSION_NUMBER = reader["SH_ADDING_PERMISSION_NUMBER"].ToString(),
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID = long.Parse(reader["SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID"].ToString()),
                        SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()),
                        SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(),
                        SH_CLIENT_PRODUCT_ID = long.Parse(reader["SH_CLIENT_PRODUCT_ID"].ToString()),
                        SH_CLIENT_PRODUCT_NAME = reader["SH_CLIENT_PRODUCT_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_LAST_RECORD_NUMBER_OF_CANS = long.Parse(reader["SH_LAST_RECORD_NUMBER_OF_CANS"].ToString()),
                        SH_NUMBER_OF_CANS_HEIGHT = long.Parse(reader["SH_NUMBER_OF_CANS_HEIGHT"].ToString()),
                        SH_NUMBER_OF_CANS_LENGTH = long.Parse(reader["SH_NUMBER_OF_CANS_LENGTH"].ToString()),
                        SH_NUMBER_OF_CANS_WIDTH = long.Parse(reader["SH_NUMBER_OF_CANS_WIDTH"].ToString()),
                        SH_STOCK_ID = long.Parse(reader["SH_STOCK_ID"].ToString()),
                        SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(),
                        SH_TOTAL_NUMBER_OF_CANS = long.Parse(reader["SH_TOTAL_NUMBER_OF_CANS"].ToString()),
                        SH_WORK_ORDER_NUMBER = reader["SH_WORK_ORDER_NUMBER"].ToString()
                        ,SH_PALLET_SIZE_LENGTH = long.Parse(reader["SH_PALLET_SIZE_LENGTH"].ToString()),
                        SH_PALLET_SIZE_TEXT = reader["SH_PALLET_SIZE_TEXT"].ToString(),
                        SH_PALLET_SIZE_WIDTH = long.Parse(reader["SH_PALLET_SIZE_WIDTH"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
                MessageBox.Show(counter.ToString());
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
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].size_id);
                cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].raw_material_type);
                cmd.Parameters.AddWithValue("@SH_USAGE", bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].usage);
                cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].printing_type_name);
                cmd.Parameters.AddWithValue("@NO_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", long.Parse(no_items_per_container_text_box.Text));
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
                        ,
                        first_face_name = reader["SH_FIRST_FACE_COLOR"].ToString(),
                        printing_type_index = long.Parse(reader["SH_PRINTING_TYPE"].ToString()),
                        product_second_face = reader["SH_PRODUCT_SECOND_FACE"].ToString(),
                        second_face_name = reader["SH_SECOND_FACE_COLOR"].ToString(),
                        size_name = reader["SH_BOTTOM_SIZE_NAME"].ToString(),
                        client_product_name = reader["PRODUCT_NAME"].ToString()
                    });
                   // MessageBox.Show("hhh", "hhh", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

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

        async Task getallselectedcontainersofrlt()
        {
            try { 
            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SH_GET_RLT_CONTAINERS_SPECIFIED", DatabaseConnection.mConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
            cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
            cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", f2_combo_box.Text);
            cmd.Parameters.AddWithValue("@SH_USAGE", f3_combo_box.Text);
            cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", f4_combo_box.Text);
            cmd.Parameters.AddWithValue("@NO_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));

            SqlDataReader reader = cmd.ExecuteReader();
            List<SH_CONTAINER_OF_RLT> anyrlt_containers = new List<SH_CONTAINER_OF_RLT>();
            while (reader.Read())
            {
                   // MessageBox.Show(" HERE ");
                anyrlt_containers.Add(new SH_CONTAINER_OF_RLT()
                {
                    SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                    SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                    SH_ID = long.Parse(reader["SH_ID"].ToString()),
                    SH_QUANTITY_OF_RLT_ID = long.Parse(reader["SH_QUANTITY_OF_RLT_ID"].ToString()),
                    SH_SPECIFICATION_OF_RLT_ID = long.Parse(reader["SH_SPECIFICATION_OF_RLT_ID"].ToString()),
                    SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                });

            }
            reader.Close();
            myconnection.closeConnection();
              //  MessageBox.Show(anyrlt_containers.Count.ToString());
            dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA()
            {
                total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                rlt_containers = anyrlt_containers,
                product_type = product_type_combo_box.SelectedIndex,
                product_name = product_type_combo_box.Text,
                no_of_selected_containers = anyrlt_containers.Count
            });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GeTTING BOTTOM CONTAINERS DATA " + ex.ToString());
            }
}

       async Task getallselectedcontainersofeasyopen()
        {
            try
            {

               

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_EASY_OPEN_CONTAINERS_SPECIFIED", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@NO_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));
              //  MessageBox.Show("HERE #1");
                SqlDataReader reader = cmd.ExecuteReader();
                List<SH_CONTAINER_OF_EASY_OPEN> anyeasyopen_containers = new List<SH_CONTAINER_OF_EASY_OPEN>();
                while (reader.Read())
                {
                   // MessageBox.Show("HERE #2");
                    anyeasyopen_containers.Add(new SH_CONTAINER_OF_EASY_OPEN()
                    {
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_QUANTITY_OF_EASY_OPEN_ID = long.Parse(reader["SH_QUANTITY_OF_EASY_OPEN_ID"].ToString()),
                        SH_SPECIFICATION_OF_EASY_OPEN_ID = long.Parse(reader["SH_SPECIFICATION_OF_EASY_OPEN_ID"].ToString()),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });

                }
                reader.Close();
                myconnection.closeConnection();
                dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA()
                {
                    total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                    easy_open_containers = anyeasyopen_containers,
                    product_type = product_type_combo_box.SelectedIndex,
                    product_name = product_type_combo_box.Text,
                    no_of_selected_containers = anyeasyopen_containers.Count
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GeTTING BOTTOM CONTAINERS DATA " + ex.ToString());
            }
        }

        async Task getallselectedcontainersofpeeloff()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_PEEL_OFF_CONTAINERS_SPECIFIED", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_TYPE", f2_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_USAGE", f3_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_PRINTING_TYPE_NAME", f4_combo_box.Text);
                cmd.Parameters.AddWithValue("@NO_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));

                SqlDataReader reader = cmd.ExecuteReader();
                List<SH_CONTAINER_OF_BILL_OFF> anypeeloff_containers = new List<SH_CONTAINER_OF_BILL_OFF>();
                while (reader.Read())
                {
                    anypeeloff_containers.Add(new SH_CONTAINER_OF_BILL_OFF()
                    {
                        SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_QUANTITY_OF_BILL_OFF_ID = long.Parse(reader["SH_QUANTITY_OF_PEEL_OFF_ID"].ToString()),
                        SH_SPECIFICATION_OF_BILL_OFF_ID = long.Parse(reader["SH_SPECIFICATION_OF_PEEL_OFF_ID"].ToString()),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });

                }
                reader.Close();
                myconnection.closeConnection();
                dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA()
                {
                    total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                    peel_off_containers = anypeeloff_containers,
                    product_type = product_type_combo_box.SelectedIndex,
                    product_name = product_type_combo_box.Text,
                    no_of_selected_containers = anypeeloff_containers.Count
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GeTTING peel off CONTAINERS DATA " + ex.ToString());
            }
        }


        async Task getallselectedcontainersoftwistof()
        {
            try
            {
                myconnection.openConnection();
                string query = " SELECT TOP("+long.Parse(no_of_selected_containers_text_box.Text) +") COTF.* ,";
                query += "  (SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE CC.SH_ID = SPTWOF.SH_CLIENT_ID) AS SH_CLIENT_COMPANY_NAME";
                query += "  ,SPTWOF.SH_ID AS SPECIFICATIONS_ID , (SELECT CP.SH_COLOR_NAME FROM  SH_COLOR_PILLOW CP WHERE CP.SH_ID = SPTWOF.SH_PILLOW_COLOR_ID) AS SH_COLOR_NAME ";
                query += "   , (SELECT CPR.SH_PRODUCT_NAME FROM SH_CLIENTS_PRODUCTS CPR WHERE CPR.SH_ID = SPTWOF.SH_CLIENT_PRODUCT_ID) AS SH_PRODUCT_NAME,";
                query += "  (SELECT TWS.SH_TWIST_OF_SIZE_VALUE  FROM SH_TWIST_OF_SIZE TWS WHERE TWS.SH_ID = SPTWOF.SH_SIZE_ID ) AS SH_TWIST_OF_SIZE_VALUE,";
                query += "    (SELECT TWT.SH_SHORT_TITLE FROM SH_TWIST_OF_TYPE TWT WHERE TWT.SH_ID = SPTWOF.SH_TWIST_OF_TYPE_ID) AS SH_TWIST_OF_TYPE_NAME ";
                query += "  , SPTWOF.SH_FIRST_FACE_PILLOW_OR_NOT";
                query += "  FROM  SH_CONTAINER_OF_TWIST_OF COTF  " ;
                query += "  JOIN SH_QUANTITY_OF_TWIST_OF QTWF ON COTF.SH_QUANTITY_OF_TWIST_OF_ID = QTWF.SH_ID";
                query += "  JOIN SH_SPECIFICATION_OF_TWIST_OF SPTWOF ON  QTWF.SH_SPECIFICATION_OF_TWIST_OF_ID = SPTWOF.SH_ID";
                query += "  WHERE (SPTWOF.SH_CLIENT_ID = @SH_CLIENT_ID OR SPTWOF.SH_CLIENT_ID IN (SELECT CC.SH_ID  FROM SH_CLIENT_COMPANY CC WHERE CC.SH_CLIENT_COMPANY_NAME = 'عام')) "; 
                query += "    AND COTF.SH_ID NOT IN ";
                query += "  (SELECT DCTWOF.SH_ID FROM SH_DISMISSAL_CONTAINERS_OF_TWIST_OF DCTWOF WHERE DCTWOF.SH_ID = COTF.SH_ID) ";
                SqlCommand cmd = new SqlCommand(query,DatabaseConnection.mConnection);
                //cmd.Parameters.AddWithValue("@NO_OF_SELECTED_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                List<SH_CONTAINER_OF_TWIST_OF> anytwist_of_containers = new List<SH_CONTAINER_OF_TWIST_OF>();
                while (reader.Read())
                {
                    anytwist_of_containers.Add(new SH_CONTAINER_OF_TWIST_OF() {
                        SH_ADDITION_PERMISSION_NUMBER = reader["SH_ADDITION_PERMISSION_NUMBER"].ToString(),
                        SH_ADDTION_DATE = DateTime.Parse(reader["SH_ADDTION_DATE"].ToString()),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_NO_ITEMS= long.Parse(reader["SH_NO_ITEMS"].ToString()),
                        SH_QUANTITY_OF_TWIST_OF_ID = long.Parse(reader["SH_QUANTITY_OF_TWIST_OF_ID"].ToString()),
                        SPECIFICATIONS_ID = long.Parse(reader["SPECIFICATIONS_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
                if (anytwist_of_containers.Count>0)
                {
                    dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA() {
                        no_of_selected_containers = long.Parse(no_of_selected_containers_text_box.Text)
                        , product_type = product_type_combo_box.SelectedIndex,
                        product_name = product_type_combo_box.Text,
                        total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text)
                        , twist_of_containers = anytwist_of_containers

                    });
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("ERROR WHILE GETTING SPECIFIED CONTAINERS OF TWIST OF "+ex.ToString());
            }

            


        }

        async Task getallselectedcontainersofplasticcover()
        {
            if (plastic_cover_data.Count > 0)
            {
               
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
                            size_string = " AND SPPC.SH_SIZE_ID = @SH_SIZE_ID ";
                        }

                        if (string.IsNullOrWhiteSpace(f2_combo_box.Text))
                        {
                            pillow_color = false;
                        }
                        else
                        {
                            pillow_color = true;
                            pillow_color_string = " AND SPPC.SH_PILLOW_COLOR_ID = @SH_PILLOW_COLOR_ID ";
                        }

                        string query = "SELECT TOP(@NO_OF_SELECTED_CONTAINERS) SPPC.SH_CLIENT_ID ,CPC.* ,";
                        query += "(SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC ";
                        query += "WHERE CC.SH_ID = SPPC.SH_CLIENT_ID) AS ";
                        query += " SH_CLIENT_NAME,";
                        query += "(SELECT ITS.SH_SIZE_NAME FROM SH_ITEM_SIZE ITS WHERE ";
                        query += " ITS.SH_ID = SPPC.SH_SIZE_ID ";
                        query += " ) AS SH_SIZE_NAME ";
                        query += " ,";
                        query += "  (SELECT CP.SH_COLOR_NAME FROM SH_COLOR_PILLOW CP ";
                        query += " WHERE CP.SH_ID = SPPC.SH_PILLOW_COLOR_ID ) AS SH_PILLOW_COLOR ";
                        query += ",";
                        query += " SPPC.SH_LOGO_OR_NOT ,";
                        query += "SPPC.SH_PILLOW_COLOR_ID,";
                        query += "SPPC.SH_SIZE_ID ,";
                        query += " SPPC.SH_ID AS SH_SPECIFICATION_OF_PLASTIC_COVER_ID ";
                        query += " FROM SH_CONTAINERS_OF_PLASTIC_COVER CPC ";
                        query += " JOIN SH_QUANTITY_OF_PLASTIC_COVER QPC ON ";
                        query += " QPC.SH_ID = CPC.SH_QUANTITY_OF_PLASTIC_COVER_ID ";
                        query += " JOIN SH_SPECIFICATION_OF_PLASTIC_COVER SPPC ON ";
                        query += " SPPC.SH_ID = QPC.SH_SPECIFICATION_OF_PLASTIC_COVER_ID ";
                        query += " WHERE(SPPC.SH_CLIENT_ID = @SH_CLIENT_ID  OR ";
                        query += " SPPC.SH_CLIENT_ID IN(SELECT CC.SH_ID FROM ";
                        query += " SH_CLIENT_COMPANY CC WHERE CC.SH_CLIENT_COMPANY_NAME ";
                        query += " LIKE N'عام')) AND CPC.SH_ID NOT IN ";
                        query += "     (SELECT SDCPC.SH_ID FROM ";
                        query += " SH_DISMISSAL_CONTAINERS_OF_PLASTIC_COVER SDCPC ";
                        query += " WHERE SDCPC.SH_ID = CPC.SH_ID) AND SPPC.SH_LOGO_OR_NOT =  @SH_LOGO_OR_NOT ";
                        query += size_string + pillow_color_string ;
                         query += " AND  CPC.SH_NO_ITEMS = @SH_NO_ITEMS ";

                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                        cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_LOGO_OR_NOT", logo_or_not);
                        cmd.Parameters.AddWithValue("@NO_OF_SELECTED_CONTAINERS", long.Parse(no_of_selected_containers_text_box.Text));
                        if (size)
                        {
                            cmd.Parameters.AddWithValue("@SH_SIZE_ID", item_sizes[f1_combo_box.SelectedIndex].SH_ID);
                        }

                        if (pillow_color)
                        {
                            cmd.Parameters.AddWithValue("@SH_PILLOW_COLOR_ID", pillow_colors[f2_combo_box.SelectedIndex].SH_ID);
                        }

                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS", plastic_cover_data[finished_product_properties_grid_view.SelectedRows[0].Index].container_no_of_items);
                        SqlDataReader reader = cmd.ExecuteReader();
                        List<SH_CONTAINERS_OF_PLASTIC_COVER> plastic_cover_container = new List<SH_CONTAINERS_OF_PLASTIC_COVER>();
                        while (reader.Read())
                        {
                        plastic_cover_container.Add(new SH_CONTAINERS_OF_PLASTIC_COVER() {
                            SH_ADDITION_PERMISSION_NUMBER = reader["SH_ADDITION_PERMISSION_NUMBER"].ToString()
                            ,SH_ADDTION_DATE = DateTime.Parse(reader["SH_ADDTION_DATE"].ToString()),
                            SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                            SH_ID = long.Parse(reader["SH_ID"].ToString()),
                            SH_NO_ITEMS = long.Parse(reader["SH_NO_ITEMS"].ToString()),
                            SH_QUANTITY_OF_PLASTIC_COVER_ID = long.Parse(reader["SH_QUANTITY_OF_PLASTIC_COVER_ID"].ToString()),
                            SH_SPECIFICATION_OF_PLASTIC_COVER_ID = long.Parse(reader["SH_SPECIFICATION_OF_PLASTIC_COVER_ID"].ToString())
                            
                        });
                        
                    }
                    
                        reader.Close();
                        myconnection.openConnection();
                    if (plastic_cover_container.Count > 0)
                    {
                        dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA()
                        {
                            no_of_selected_containers = plastic_cover_container.Count,
                            product_type = product_type_combo_box.SelectedIndex,
                            product_name = product_type_combo_box.Text,
                            total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                            plastic_cover_containers = plastic_cover_container

                        });
                    }

                }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE GeTTING PLASTic COVER CONTAINERS " + ex.ToString());
                    }
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
                                if (dismissed_containers[i].cans_parcels.Count>0)
                                {
                                    dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    dismissed_containers[i].cans_parcels[0].SH_CLIENT_NAME,
                                    dismissed_containers[i].cans_parcels[0].SH_CLIENT_PRODUCT_NAME,
                                    "بالتة",
                                    dismissed_containers[i].no_of_selected_containers.ToString(),
                                    dismissed_containers[i].cans_parcels[0].SH_TOTAL_NUMBER_OF_CANS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                }
                               
                                break;
                            }
                        case 1:
                            {
                                //bottom data
                                if (dismissed_containers[i].bottom_containers.Count>0)
                                {
                                    if (dismissed_containers[i].bottom_containers[0].printing_type_index == 0)
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "قاع" +"  "+dismissed_containers[i].bottom_containers[0].size_name+" "+dismissed_containers[i].bottom_containers[0].client_product_name+" "+dismissed_containers[i].bottom_containers[0].first_face_name+" / "+dismissed_containers[i].bottom_containers[0].product_second_face+" "+dismissed_containers[i].bottom_containers[0].second_face_name,

                                     dismissed_containers[i].bottom_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].bottom_containers.Count.ToString(),
                                    dismissed_containers[i].bottom_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                    else
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                     mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "قاع" +"  "+dismissed_containers[i].bottom_containers[0].size_name+" "+dismissed_containers[i].bottom_containers[0].first_face_name+" / "+dismissed_containers[i].bottom_containers[0].second_face_name,

                                     dismissed_containers[i].bottom_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].bottom_containers.Count.ToString(),
                                    dismissed_containers[i].bottom_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                }
                               
                                break;
                            }
                        case 2:
                            {
                                //rlt data
                                if (dismissed_containers[i].rlt_containers.Count>0)
                                {
                                    try
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "RLT",
                                    dismissed_containers[i].rlt_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].rlt_containers.Count.ToString(),
                                    dismissed_containers[i].rlt_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("ERRO WILE fill rlt DaTA TO diSmissEd GRiD vIEW " + ex.ToString());
                                    }
                                }
                                

                                break;
                            }
                        case 3:
                            {
                                //easy open data 
                                if (dismissed_containers[i].easy_open_containers.Count>0)
                                {
                                    dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "إيزى أوبن ",
                                     dismissed_containers[i].easy_open_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].easy_open_containers.Count.ToString(),
                                    dismissed_containers[i].easy_open_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                }
                                

                                break;
                            }
                        case 4:
                            {
                                //peel off

                                if (dismissed_containers[i].peel_off_containers.Count > 0)
                                {
                                    dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "إيزى أوبن",
                                    dismissed_containers[i].peel_off_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].peel_off_containers.Count.ToString(),
                                    dismissed_containers[i].peel_off_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                }


                                break;
                            }
                        case 5:
                            {
                                //twist of

                                if (dismissed_containers[i].twist_of_containers.Count > 0)
                                {
                                    dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "تويست أوف",
                                    dismissed_containers[i].twist_of_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].twist_of_containers.Count.ToString(),
                                    dismissed_containers[i].twist_of_containers[0].SH_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                }

                                break;
                            }
                        case 6:
                            {
                                //plastic cover 
                                if (dismissed_containers[i].plastic_cover_containers.Count > 0)
                                {
                                    dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "غطاء بلاستيك",
                                    dismissed_containers[i].plastic_cover_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].plastic_cover_containers.Count.ToString(),
                                    dismissed_containers[i].plastic_cover_containers[0].SH_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                }
                                break;
                            }
                        case 7:
                            {
                                //plastic mold 
                                if (dismissed_containers[i].plastic_mold_containers.Count > 0)
                                {
                                    dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    mclient.SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "طبة بلاستيك",
                                    dismissed_containers[i].plastic_mold_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].plastic_mold_containers.Count.ToString(),
                                    dismissed_containers[i].plastic_mold_containers[0].SH_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });
                                }
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

                            await getselectedfinishedproductparcels(finished_cans[finished_product_properties_grid_view.SelectedRows[0].Index]);
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
                            await getallselectedcontainersofrlt();
                            await filldismissedcontainersgridview();


                            break;
                        }
                    case 3:
                        {
                            //easy open
                            await getallselectedcontainersofeasyopen();
                            await filldismissedcontainersgridview();
                            break;
                        }
                    case 4:
                        {
                            //peel off
                            await getallselectedcontainersofpeeloff();
                            await filldismissedcontainersgridview();
                            break;
                        }
                    case 5:
                        {
                            //twist of
                            await getallselectedcontainersoftwistof();
                            await filldismissedcontainersgridview();
                            break;
                        }
                    case 6:
                        {
                            //plastic cover
                            await getallselectedcontainersofplasticcover();
                            await filldismissedcontainersgridview();
                            break;
                        }
                    case 7:
                        {
                            //plastic mold
                            await getallselectedcontainersofplasticmold();
                            await filldismissedcontainersgridview();
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        async Task getallselectedcontainersofplasticmold()
        {
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
                    MOLD_SIZE_STRING = " AND SPPM.SH_SIZE_ID = @SH_SIZE_ID";
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
                    PILLOW_COLOR_STRING = " AND SPPM.SH_PILLOW_COLOR_ID = @SH_PILLOW_COLOR_ID";
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
                    MOLD_TYPE_STRING = " AND SPPM.SH_MOLD_TYPE_ID = @SH_MOLD_TYPE_ID";
                }
            }
            string query = " SELECT TOP(@NO_OF_SELECTED_CONTAINERS) CPM.*,";
            query += " CPM.SH_CONTAINER_NAME , ";
            query += "SPPM.SH_ID AS SH_SPCIFICATION_OF_PLASTIC_MOLD_ID ,";
            query += " SPPM.SH_CLIENT_ID, ";
            query += " (SELECT CC.SH_CLIENT_COMPANY_NAME FROM SH_CLIENT_COMPANY CC WHERE ";
            query += " CC.SH_ID = SPPM.SH_CLIENT_ID ";
            query += ") AS SH_CLIENT_COMPANY_NAME, ";
            query += "CPM.SH_NO_ITEMS , ";
            query += "SPPM.SH_PILLOW_COLOR_ID, ";
            query += "(SELECT CP.SH_COLOR_NAME FROM SH_COLOR_PILLOW CP WHERE CP.SH_ID = ";
            query += "    SPPM.SH_PILLOW_COLOR_ID ) AS SH_COLOR_NAME,";
            query += "SPPM.SH_SIZE_ID, ";
            query += " (SELECT ITS.SH_MOLD_SIZE_VALUE FROM SH_MOLD_SIZE ITS WHERE ITS.SH_ID =SPPM.SH_SIZE_ID ) AS SH_SIZE_NAME,";
            query += "SPPM.SH_MOLD_TYPE_ID ,";
            query += "(SELECT MT.SH_MOLD_TYPE_NAME FROM SH_MOLD_TYPES MT ";
            query += " WHERE MT.SH_ID = SPPM.SH_MOLD_TYPE_ID )AS SH_MOLD_TYPE_NAME ";
            query += " FROM SH_CONTAINERS_OF_PLASTIC_MOLD CPM ";
            query += " JOIN SH_QUANTITY_OF_PLASTIC_MOLD QPM ON ";
            query += " QPM.SH_ID = CPM.SH_QUANTITY_OF_PLASTIC_MOLD_ID ";
            query += " JOIN SH_SPECIFICATION_OF_PLASTIC_MOLD SPPM ON ";
            query += " SPPM.SH_ID = QPM.SH_SPECIFICATION_OF_PLASTIC_MOLD_ID ";
            query += " WHERE(SPPM.SH_CLIENT_ID = @SH_CLIENT_ID OR ";
            query += " SPPM.SH_CLIENT_ID IN(SELECT CC.SH_ID FROM SH_CLIENT_COMPANY CC  ";
            query += " WHERE CC.SH_CLIENT_COMPANY_NAME LIKE N'عام')) ";
            query += MOLD_SIZE_STRING + MOLD_TYPE_STRING + PILLOW_COLOR_STRING;
            query += " AND CPM.SH_ID NOT IN (SELECT DCPM.SH_ID FROM SH_DISMISSAL_CONTAINERS_OF_PLASTIC_MOLD DCPM WHERE DCPM.SH_CONTAINER_OF_PLASTIC_MOLD_ID = CPM.SH_ID )";


            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", mclient.SH_ID);
                cmd.Parameters.AddWithValue("@NO_OF_SELECTED_CONTAINERS",long.Parse(no_of_selected_containers_text_box.Text));
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
                List<SH_CONTAINERS_OF_PLASTIC_MOLD> platic_mold_containers = new List<SH_CONTAINERS_OF_PLASTIC_MOLD>();
                while (reader.Read())
                {
                    platic_mold_containers.Add(new SH_CONTAINERS_OF_PLASTIC_MOLD()
                    {
                        SH_ADDITION_PERMISSION_NUMBER = reader["SH_ADDITION_PERMISSION_NUMBER"].ToString(),
                        SH_ADDTION_DATE = DateTime.Parse(reader["SH_ADDTION_DATE"].ToString()),
                        SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_NO_ITEMS = long.Parse(reader["SH_NO_ITEMS"].ToString()),
                        SH_QUANTITY_OF_PLASTIC_MOLD_ID = long.Parse(reader["SH_QUANTITY_OF_PLASTIC_MOLD_ID"].ToString()),
                        SH_SPCIFICATION_OF_PLASTIC_MOLD_ID = long.Parse(reader["SH_SPCIFICATION_OF_PLASTIC_MOLD_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
                if (platic_mold_containers.Count>0)
                {
                    dismissed_containers.Add(new SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA() {
                        plastic_mold_containers = platic_mold_containers,
                        no_of_selected_containers = platic_mold_containers.Count,
                        product_name = product_type_combo_box.Text,
                        total_no_of_items_of_selected_containers = long.Parse(total_number_of_items_of_selected_containers.Text),
                        product_type = product_type_combo_box.SelectedIndex

                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PLASTIC MOLD DATA " + ex.ToString());
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
                                if (finished_cans[finished_product_properties_grid_view.SelectedRows[0].Index].no_pallets < long.Parse(no_of_selected_containers_text_box.Text))
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

                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (bottom_containers[finished_product_properties_grid_view.SelectedRows[0].Index].number_of_containers < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }

                            break;
                        }
                    case 2:
                        {

                            //rlt
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (rlt_containetrs[finished_product_properties_grid_view.SelectedRows[0].Index].number_of_containers < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }
                            break;
                        }
                    case 3:
                        {

                            //easy open
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (easy_open_containers[finished_product_properties_grid_view.SelectedRows[0].Index].number_of_containers < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }
                            break;
                        }
                    case 4:
                        {
                            //peel off
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (peel_off_containers[finished_product_properties_grid_view.SelectedRows[0].Index].number_of_containers < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }
                            break;
                        }
                    case 5:
                        {
                            //twist of
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (twist_of_containers[finished_product_properties_grid_view.SelectedRows[0].Index].number_of_containers < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }
                            break;
                        }
                    case 6:
                        {
                            //plastic cover
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (plastic_cover_data[finished_product_properties_grid_view.SelectedRows[0].Index].no_of_containers < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }
                            break;
                        }
                    case 7:
                        {
                            //plastic mold
                            long testnumber = 0;
                            if (long.TryParse(no_of_selected_containers_text_box.Text, out testnumber))
                            {
                                if (plastic_mold_sepecifications[finished_product_properties_grid_view.SelectedRows[0].Index].SH_NO_OF_CONTAINERS < long.Parse(no_of_selected_containers_text_box.Text))
                                {
                                    MessageBox.Show("الكمية غير موجودة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                                    no_of_selected_containers_text_box.Text = "";
                                }
                            }

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

