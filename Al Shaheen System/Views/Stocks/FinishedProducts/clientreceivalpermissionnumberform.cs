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
    public partial class clientreceivalpermissionnumberform : Form
    {
        List<SH_CLIENTS_BRANCHES> client_branches = new List<SH_CLIENTS_BRANCHES>();
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        public List<SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA> dismissed_containers = new List<SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA>();

        SH_EMPLOYEES memployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS maccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mpermission = new SH_USER_PERMISIONS();
        long dividers = 0;
        long pallets = 0;

        public long back = 0;
        public clientreceivalpermissionnumberform(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            memployee = anyemp;
            maccount = anyaccount;
            mpermission = anyperm;
        }


        void getallcartondividersandpallets(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            if (anydata.product_type ==0)
            {     
                for (int i = 0; i < anydata.cans_parcels.Count; i++)
                {
                    dividers += anydata.cans_parcels[i].SH_NUMBER_OF_CANS_HEIGHT + 1;
                }
                pallets += anydata.cans_parcels.Count;
            }
            no_carton_dividers_text_box.Text = dividers.ToString();
            
        }






        async Task getallstocksdata()
        {
            stocks.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SHAHEEN_STOCKS ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK()
                    {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()),
                        SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString(),
                        SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(),
                        SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString()
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILe GETTING ALL STOCKS DATA "+ex.ToString());
            }
        }

        async Task fillstockscombobox()
        {
            await getallstocksdata();
            stocks_combo_box.Items.Clear();
            if (stocks.Count >0)
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stocks_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }

        async Task getreceit_order_number()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+684) AS lastedid FROM SH_RECEIVING_PERMISSION_INFORMATION  ", DatabaseConnection.mConnection);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error while getting new permission number " + ex.ToString());
            }


            if (mycount == 0)
            {
                //there is the first rows in the db
                string permissionnumber = "SH_";
                
                permissionnumber += DateTime.Now.ToString("yy");
                permissionnumber += "-";
                string currentr = 684.ToString();
                for (int i = 0; i < 4 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                no_receiving_permission_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                
                permissionnumber += DateTime.Now.ToString("yy");
                permissionnumber += "-";
                string currentr = mycount.ToString();
                for (int i = 0; i < 4 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                no_receiving_permission_number_text_box.Text = permissionnumber;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                using (clientreceivalpermissionnumberproducts myform = new clientreceivalpermissionnumberproducts(clients[clients_combo_box.SelectedIndex]))
                {
                    myform.ShowDialog();
                    if (myform.back == 1)
                    {
                      
                        if (myform.dismissed_containers.Count>0)
                        {
                            for (int i = 0; i < myform.dismissed_containers.Count; i++)
                            {
                                dismissed_containers.Add(myform.dismissed_containers[i]);
                                getallcartondividersandpallets(myform.dismissed_containers[i]);
                            }
                            no_pallets_text_box.Text = pallets.ToString();
                            no_wooden_face_text_box.Text = pallets.ToString();
                        }
                        await filldismissedcontainersgridview();
                    }
                }
            }

        }

        public async Task filldismissedcontainersgridview()
        {
            dismissed_containers_grid_view.Rows.Clear();
            if (dismissed_containers.Count > 0)
            {

                for (int i = 0; i < dismissed_containers.Count; i++)
                {
                    string cur_string = "";
                    long cur_size = (i + 1).ToString().Length;
                    for (int k = 0; k < 3 - cur_size; k++)
                    {
                        cur_string += "0";
                    }
                    cur_string += (i + 1);
                    switch (dismissed_containers[i].product_type)
                    {
                        case 0:
                            {
                                //cans
                                if (dismissed_containers[i].cans_parcels.Count > 0)
                                {
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
                                }

                                break;
                            }
                        case 1:
                            {
                                //bottom data
                                if (dismissed_containers[i].bottom_containers.Count > 0)
                                {
                                    if (dismissed_containers[i].bottom_containers[0].printing_type_index == 0)
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
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
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
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
                                //RLT data
                                if (dismissed_containers[i].rlt_containers.Count > 0)
                                {
                                    if (dismissed_containers[i].rlt_containers[0].printing_type_index == 0)
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "RLT" +"  "+dismissed_containers[i].rlt_containers[0].size_name+" "+dismissed_containers[i].rlt_containers[0].client_product_name+" "+dismissed_containers[i].rlt_containers[0].first_face_name+" / "+dismissed_containers[i].rlt_containers[0].product_second_face+" "+dismissed_containers[i].rlt_containers[0].second_face_name,

                                     dismissed_containers[i].rlt_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].rlt_containers.Count.ToString(),
                                    dismissed_containers[i].rlt_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                    else
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "RLT" +"  "+dismissed_containers[i].rlt_containers[0].size_name+" "+dismissed_containers[i].rlt_containers[0].first_face_name+" / "+dismissed_containers[i].rlt_containers[0].second_face_name,

                                     dismissed_containers[i].rlt_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].rlt_containers.Count.ToString(),
                                    dismissed_containers[i].rlt_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                }


                                break;
                            }
                        case 3:
                            {
                                //EASY OPEN  data
                                if (dismissed_containers[i].easy_open_containers.Count > 0)
                                {
                                    if (dismissed_containers[i].easy_open_containers[0].printing_type_index == 0)
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "إيزى أوبن" +"  "+dismissed_containers[i].easy_open_containers[0].size_name+" "+dismissed_containers[i].easy_open_containers[0].client_product_name+" "+dismissed_containers[i].easy_open_containers[0].first_face_name+" / "+dismissed_containers[i].easy_open_containers[0].product_second_face+" "+dismissed_containers[i].easy_open_containers[0].second_face_name,

                                     dismissed_containers[i].easy_open_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].easy_open_containers.Count.ToString(),
                                    dismissed_containers[i].easy_open_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                    else
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "إيزى أوبن" +"  "+dismissed_containers[i].easy_open_containers[0].size_name+" "+dismissed_containers[i].easy_open_containers[0].first_face_name+" / "+dismissed_containers[i].easy_open_containers[0].second_face_name,

                                     dismissed_containers[i].easy_open_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].easy_open_containers.Count.ToString(),
                                    dismissed_containers[i].easy_open_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                }


                                break;
                            }
                        case 4:
                            {

                                //PEEL OFF   data
                                if (dismissed_containers[i].peel_off_containers.Count > 0)
                                {
                                    if (dismissed_containers[i].peel_off_containers[0].printing_type_index == 0)
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "بيل أوف" +"  "+dismissed_containers[i].peel_off_containers[0].size_name+" "+dismissed_containers[i].peel_off_containers[0].client_product_name+" "+dismissed_containers[i].peel_off_containers[0].first_face_name+" / "+dismissed_containers[i].peel_off_containers[0].product_second_face+" "+dismissed_containers[i].peel_off_containers[0].second_face_name,

                                     dismissed_containers[i].peel_off_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].peel_off_containers.Count.ToString(),
                                    dismissed_containers[i].peel_off_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
                                    else
                                    {
                                        dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    dismissed_containers[i].product_name,
                                    clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                    "بيل أوف" +"  "+dismissed_containers[i].peel_off_containers[0].size_name+" "+dismissed_containers[i].peel_off_containers[0].first_face_name+" / "+dismissed_containers[i].peel_off_containers[0].second_face_name,

                                     dismissed_containers[i].peel_off_containers[0].SH_CONTAINER_NAME,
                                    dismissed_containers[i].peel_off_containers.Count.ToString(),
                                    dismissed_containers[i].peel_off_containers[0].SH_TOTAL_NO_ITEMS.ToString(),
                                    dismissed_containers[i].total_no_of_items_of_selected_containers.ToString()
                                });

                                    }
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
                                     clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                        "تويست أوف" + " - " +dismissed_containers[i].twist_of_containers[0].twist_of_size_name+" - "+dismissed_containers[i].twist_of_containers[0].client_product_name +" "+dismissed_containers[i].twist_of_containers[0].pillow_color_name +" - "+dismissed_containers[i].twist_of_containers[0].type_kind+" "+dismissed_containers[i].twist_of_containers[0].twist_of_type,
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
                                     clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
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
                                     clients[clients_combo_box.SelectedIndex].SH_CLIENT_COMPANY_NAME,
                                    //dismissed_containers[i].bottom_containers[0].,
                                     "غطاء بلاستيك",
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




                async Task getallclientsdata()
        {
            clients.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENTS_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY() { SH_CLIENT_COMPANY_FAX_NUMBER = reader["SH_CLIENT_COMPANY_FAX_NUMBER"].ToString()
                      , SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString()
                      , SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString()
                      , SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString()
                      , SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTInG ALL CLIENTS DATA ");
            }
        }
        async Task fillclientscombobox()
        {
            await getallclientsdata();
            clients_combo_box.Items.Clear();
            if (clients.Count > 0)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    clients_combo_box.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }

        async Task getallclientbranchdata()
        {
            client_branches.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_CLIENT_BRANCHES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    client_branches.Add(new SH_CLIENTS_BRANCHES() {
                        SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString(),
                        SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(),
                        SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(),
                        SH_CLIENT_BRANCH_TYPE = reader["SH_CLIENT_BRANCH_TYPE"].ToString(),
                        SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(),
                        SH_ID = long.Parse(reader["SH_ID"].ToString())
                    });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH DATA " + ex.ToString());
            }
        }
        async Task fillclientbranchescombobox()
        {
            await getallclientbranchdata();
            client_branches_combo_box.Items.Clear();
            if (client_branches.Count > 0)
            {
                for (int i = 0; i < client_branches.Count; i++)
                {
                    client_branches_combo_box.Items.Add(client_branches[i].SH_CLIENT_BRANCH_NAME);
                }
            }
        }

        private async void clientreceivalpermissionnumberform_Load(object sender, EventArgs e)
        {


            stock_man_text_box.Text = memployee.SH_EMPLOYEE_NAME;
            await fillstockscombobox();
            await getreceit_order_number();
            await fillclientscombobox();
        }

        private async void clients_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(clients_combo_box.Text))
            {
                await fillclientbranchescombobox();
            }

        }

        private void current_date_timer_Tick(object sender, EventArgs e)
        {
            current_date_label.Text = DateTime.Now.ToShortDateString();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //save recevial permission information 
        async Task<long> savenewreceitinformation()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_INFORMATION", DatabaseConnection.mConnection);
                cmd.CommandType=CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[clients_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID",memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID );
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DRIVER_NAME", driver_name_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_TELEPHONE_NUMBER", driver_telephone_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_LICENSE_NUMBER", lisence_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_ORDER_NUMBER", no_of_order_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DRIVER_CAR_NUMBER", car_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CLIENT_BRANCH_ID",client_branches[client_branches_combo_box.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_NO_PALLETS",long.Parse(no_pallets_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_NO_WOOD_WINCHES",long.Parse(no_wooden_face_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_CARDBOARD_DIVIDERS", long.Parse(no_carton_dividers_text_box.Text));
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
             
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW INFORMATION "+ex.ToString());
            }
            return 0;
        }

        //save receial permission quantity inforamtion
        async Task<long>  savenewreceitinformationitems(long rec_id , SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata , string item_code)
        {       
               switch (anydata.product_type)
                {
                    case 0:
                        {
                            //finished cans 
                            try
                            {
                                myconnection.openConnection();
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                                cmd.Parameters.AddWithValue("@SH_ITEM_NAME", anydata.cans_parcels[0].SH_CLIENT_PRODUCT_NAME);
                              //  cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER_SIZE", anydata.cans_parcels[0].SH_PALLET_SIZE_TEXT);
                                cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", "بالتة");
                                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.cans_parcels[0].SH_TOTAL_NUMBER_OF_CANS);
                                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.cans_parcels.Count);
                                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                SqlDataReader reader = cmd.ExecuteReader();
                                long myid = 0;
                                if (reader.Read())
                                {
                                    myid = long.Parse(reader["myidentity"].ToString());
                                }
                                reader.Close();
                                myconnection.closeConnection();
                                return myid;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ERROR WHIlE SAVING NEW RECEiT INFORMATIoN ITEMS " + ex.ToString());
                            }
                            return 0;
                            break;
                        }
                    case 1:
                        {
                        //bottom
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "قاع" + "  " + anydata.bottom_containers[0].size_name + " " + anydata.bottom_containers[0].client_product_name + " " + anydata.bottom_containers[0].first_face_name + " / " + anydata.bottom_containers[0].product_second_face + " " + anydata.bottom_containers[0].second_face_name);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.bottom_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.bottom_containers[0].SH_TOTAL_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.bottom_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    case 2:
                        {
                        //rlt
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "RLT" + "  " + anydata.rlt_containers[0].size_name + " " + anydata.rlt_containers[0].client_product_name + " " + anydata.bottom_containers[0].first_face_name + " / " + anydata.bottom_containers[0].product_second_face + " " + anydata.bottom_containers[0].second_face_name);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.rlt_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.rlt_containers[0].SH_TOTAL_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.rlt_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    case 3:
                        {
                        //easy open
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "إيزى أوبن"+ "  " + anydata.easy_open_containers[0].size_name + " " + anydata.easy_open_containers[0].client_product_name + " " + anydata.easy_open_containers[0].first_face_name + " / " + anydata.easy_open_containers[0].product_second_face + " " + anydata.easy_open_containers[0].second_face_name);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.easy_open_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.easy_open_containers[0].SH_TOTAL_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.easy_open_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    case 4:
                        {
                        //peel off
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "بيل أوف" + "  " + anydata.peel_off_containers[0].size_name + " " + anydata.peel_off_containers[0].client_product_name + " " + anydata.peel_off_containers[0].first_face_name + " / " + anydata.peel_off_containers[0].product_second_face + " " + anydata.peel_off_containers[0].second_face_name);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.peel_off_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.peel_off_containers[0].SH_TOTAL_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.peel_off_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    case 5:
                        {
                        //twist of
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "تويست أوف" + " - " + anydata.twist_of_containers[0].twist_of_size_name + " - " + anydata.twist_of_containers[0].client_product_name + " " + anydata.twist_of_containers[0].pillow_color_name + " - " + anydata.twist_of_containers[0].type_kind + " " + anydata.twist_of_containers[0].twist_of_type);
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.twist_of_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.twist_of_containers[0].SH_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.twist_of_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    case 6:
                        {
                        //plastic cover
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "غطاء بلاستيك");
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.plastic_cover_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.plastic_cover_containers[0].SH_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.plastic_cover_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    case 7:
                        {
                        //plastic mold
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_ITEM_RECEIT_NUMBER", no_receiving_permission_number_text_box.Text + item_code);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_INFORMATION_ID", rec_id);
                        cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "طبة بلاستيك");
                        cmd.Parameters.AddWithValue("@SH_ITEM_CONTAINER", anydata.plastic_mold_containers[0].SH_CONTAINER_NAME);
                        cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", anydata.plastic_mold_containers[0].SH_NO_ITEMS);
                        cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", anydata.plastic_mold_containers.Count);
                        cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.total_no_of_items_of_selected_containers);
                        cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                        cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                        SqlDataReader reader = cmd.ExecuteReader();
                        long myid = 0;
                        if (reader.Read())
                        {
                            myid = long.Parse(reader["myidentity"].ToString());
                        }
                        reader.Close();
                        myconnection.closeConnection();
                        return myid;
                        break;
                        }
                    default:
                        break;
                }
                     
            
            return 0;
        }
        //save receival permission quantitiy items information of finihed cans
        async Task<long> savenewreceitinformationitemsfinishedcans(long qu_id, SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            switch (anydata.product_type)
            {
                case 0:
                    {
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.cans_parcels.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.cans_parcels[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        
                        break;
                    }
                case 1:
                    {
                        //bottom
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.bottom_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.bottom_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                case 2:
                    {
                        //rlt
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.rlt_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.rlt_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                case 3:
                    {
                        //easy open
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.easy_open_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.easy_open_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                case 4:
                    {
                        //peel off
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.peel_off_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.peel_off_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                case 5:
                    {
                        //twist of
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.twist_of_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.twist_of_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                case 6:
                    {
                        //plastic cover 
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.plastic_cover_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.plastic_cover_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                case 7:
                    {
                        //plastic mold
                        try
                        {
                            myconnection.openConnection();
                            for (int i = 0; i < anydata.plastic_mold_containers.Count; i++)
                            {
                                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_RECEIVING_PERMISSION_ITEMS_INFORMATION", DatabaseConnection.mConnection);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_ITEM_ID", anydata.plastic_mold_containers[i].SH_ID);
                                cmd.Parameters.AddWithValue("@SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION_ID", qu_id);
                                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE_NAME", anydata.product_name);
                                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE SAVING RECEIT INFORMATION ITEMS " + ex.ToString());
                        }
                        break;
                    }
                default:
                    break;
            }
            return 0;

        }



        async Task<long> savenewreceitinformationquantitiesoffinishedcans(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_DISMISSED_QUANTITY_OF_FINISHED_CANS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CANS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_NO_PALLETS", anydata.no_of_selected_containers.ToString());
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID", anydata.cans_parcels[0].SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID);

                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW QUANTITIEs INFORMATION QUANTITIES OF FINISHED CANS " + ex.ToString());
            }
            return 0;
        }


        //save new dissmissed rlt quantity
        async Task <long> savenewdismissedrltquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_RLT_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RLT_ID", anydata.rlt_containers[0].SH_SPECIFICATION_OF_RLT_ID);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.bottom_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DISMISSED BOTTOM QUANTITIES " + ex.ToString());
            }
            return 0;
        }
        //save new dissmissed rlt containers 
        async Task savenewdismissedrltcontainers(long qu_id,SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
                try
                {
                    myconnection.openConnection();
                    for (int i = 0; i < anydata.bottom_containers.Count; i++)
                    {
                        SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_BOTTOM_DATA", DatabaseConnection.mConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_BOTTOM_ID", anydata.bottom_containers[i].SH_ID);
                        cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                        cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                        cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                        cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_BOTTOM_ID", qu_id);
                        cmd.ExecuteNonQuery();
                    }
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING BOTTOM CONTAINERS " + ex.ToString());
                }
            
        }
        // update rlt specifications 
        async Task updaterltpecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_RLT_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.rlt_containers[0].SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.rlt_containers[0].SH_ID);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING BOTTOM SPCEIFICATIONS " + ex.ToString());
            }
        }


        // SAVE NEW DISMISSED EASY OPEN QUANTITY
        async Task <long> savenewdismissedeasyopenquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_EASY_OPEN_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_EASY_OPEN_ID", anydata.easy_open_containers[0].SH_SPECIFICATION_OF_EASY_OPEN_ID);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.easy_open_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DISMISSED BOTTOM QUANTITIES " + ex.ToString());
            }
            return 0;
        }
        // SAVE NEW DISMISSED CONTAINERS OF EASY OPEN 
        async Task savenewdismissedeastyopencontainers(long qu_id , SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_EASY_OPEN_DATA", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_EASY_OPEN_ID", anydata.easy_open_containers[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_BOTTOM_ID", qu_id);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING EASY OPEN CONTAINERS " + ex.ToString());
            }
        }
       //UPDATE EASY OPEN SPECIFICATIONS 
        async Task updateeasyopenspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_EASY_OPEN_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.easy_open_containers[0].SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.easy_open_containers[0].SH_ID);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING EASY OPEN SPEciFIcaTIONS " + ex.ToString());
            }

        }


        //save new dismissed peel off quantity
        async Task<long> savenewdismissedpeeloffquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_PEEL_OFF_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PEEL_OFF_ID", anydata.peel_off_containers[0].SH_SPECIFICATION_OF_BILL_OFF_ID);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.bottom_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DISMISSED BOTTOM QUANTITIES " + ex.ToString());
            }
            return 0;
        }
        //save new dimissed containers of peel off 
        async Task savenewdismissedpeeloffcontainers(long qu_id,SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_PEEL_OFF_DATA", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_PEEL_OFF_ID", anydata.peel_off_containers[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_PEEL_OFF_ID", qu_id);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING PEEL OFF CONTAINERS " + ex.ToString());
            }
        }
        //UPDATE PEEL OFF SPECIFICATIONS
        async Task updatepeeloffspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_PEEL_OFF_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.peel_off_containers[0].SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.peel_off_containers[0].SH_ID);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING PEEL OFF SPECIFICATIONS " + ex.ToString());
            }
        }


        //save new dissmissed quantities of bottom
        async Task <long> savenewdismissedbottomquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_BOTTOM_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_BOTTOM_ID", anydata.bottom_containers[0].SH_SPECIFICATION_OF_BOTTOM_ID);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.bottom_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DISMISSED BOTTOM QUANTITIES "+ex.ToString());
            }
            return 0;
        }
        //save new dismissed containers of bottom
        async Task savenewdismissedbottomcontainers(long qu_id ,SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_BOTTOM_DATA", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_BOTTOM_ID", anydata.bottom_containers[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE",DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID",maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_BOTTOM_ID", qu_id);
                    cmd.ExecuteNonQuery();
                }      
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING BOTTOM CONTAINERS "+ex.ToString());
            }
        }
        //update bottom specifications 
        async Task updatebottomspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.bottom_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_BOTTOM_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.bottom_containers[0].SH_TOTAL_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.bottom_containers[0].SH_SPECIFICATION_OF_BOTTOM_ID);
                    cmd.ExecuteNonQuery();
                }           
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING BOTTOM SPEciFIcaTIONS "+ex.ToString());
            }
        }


        //save new dismissed twist of  quantities
        async Task <long> savenewdismissedtwistofquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_TWIST_OF_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_TWIST_OF_ID", 0);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE",DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.twist_of_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID",memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);

                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING TWIST OF QUANTITEs "+ex.ToString());
            }
            return 0;
        }
        //save new dismissed twist of containers 
        async Task savenewdismissedtwistofcontainers(long qu_id,SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.twist_of_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_TWIST_OF_DATA", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_TWIST_OF_ID", anydata.twist_of_containers[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_TWIST_OF_ID", qu_id);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DiSMISSED TWIST OF CONTAINERS "+ex.ToString());
            }
        }
        //update twist of specifications 
        async Task updatetwistofspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.twist_of_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_TWIST_OF_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.twist_of_containers[i].SPECIFICATIONS_ID);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_TEMS", anydata.twist_of_containers[i].SH_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", 1);

                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING TWIST OF SPECIFICATIONS "+ex.ToString());
            }
        }


        
        //save new dismissed plastic cover quanttites
        async Task<long> savenewdismissedplasticcoverqunatity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_PLASTIC_COVER_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PLASTIC_COVER_ID", 0);//sp_id
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.plastic_cover_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING PLASTIC COVER QUANTITY"+ex.ToString());
            }
            return 0;
        }
        //save new dismissed plastic cover containers
        async Task savenewdismissedplasticcovercontainers(long qu_id, SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.plastic_cover_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_PLASTIC_COVER_DATA", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_PLASTIC_COVER_ID", anydata.plastic_cover_containers[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_PLASTIC_COVER_ID", qu_id);
                    cmd.ExecuteNonQuery();

                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle saVING PLASTIC COVER COnTAINERS "+ex.ToString());
            }
        }
        //update plastic cover specifications 
        async Task updateplasticcoverspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.plastic_cover_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_PLASTIC_COVER_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.plastic_cover_containers[i].SH_SPECIFICATION_OF_PLASTIC_COVER_ID); //sp_id
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", anydata.plastic_cover_containers[i].SH_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", 1);
                    cmd.ExecuteNonQuery();
                }               
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("UPDATE PLASTIC COVER SPEcIFIcATIONS "+ex.ToString());
            }
        }


        //save new dismissed plastic mold quantities
        async Task<long> savenewdismissedplasticmoldquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_QUANTITY_OF_PLASTIC_MOLD_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PLASTIC_MOLD_ID", 0); //sp_id
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CONTAINERS", anydata.plastic_mold_containers.Count);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_DIMISSAL_ITEMS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID ", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", stocks[stocks_combo_box.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE SAVING NEW DISmiSSED PLASTiC MOLD QUANTITY "+ex.ToString());
            }
            return 0;
        }
        //save new dismissed plastic mold containers
        async Task savenewdismissedplasticmoldcontainers(long qu_id , SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.plastic_mold_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_INSERT_NEW_SH_DISMISSAL_CONTAINERS_OF_PLASTIC_MOLD_DATA", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_CONTAINER_OF_PLASTIC_MOLD_ID", anydata.plastic_mold_containers[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_QUANTITY_OF_PLASTIC_MOLD_ID", qu_id);
                    cmd.ExecuteNonQuery();

                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE saVING PLASTic MOLD CONTAINERS "+ex.ToString());
            }
        }
        //update plastic mold specifications 
        async Task updatedismissedplasticmoldspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.plastic_mold_containers.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_SPECIFICATION_OF_PLASTIC_MOLD_PROCEDURE_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.plastic_mold_containers[i].SH_SPCIFICATION_OF_PLASTIC_MOLD_ID);//sp_id
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS ", anydata.plastic_mold_containers[i].SH_NO_ITEMS);
                    cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", 1);
                    cmd.ExecuteNonQuery();
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING PLASTIC MOLD SPECIFICATIONS "+ex.ToString());
            }
        }

        

        //save new dismissed quantities of finished cans 
        async Task <long> savenewdismissedfinishedcansquantity(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_DISMISSED_QUANTITY_OF_FINISHED_CANS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CANS", anydata.total_no_of_items_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_NO_PALLETS", anydata.no_of_selected_containers);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID" , anydata.cans_parcels[0].SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                long myid = 0;
                if (reader.Read())
                {
                    myid = long.Parse(reader["myidentity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();
                return myid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle ADDING NEW DiSMISSEd QUANTiTITIEs OF FINISHEd cANS "+ex.ToString());
            }
            return 0;
        }
        // save new dismissed pallets of finished cans 
        async Task  savenewdismissedpalletsoffinishedcans(long qu_id ,  SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.cans_parcels.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_SAVE_NEW_DISMISSED_PALLETS_OF_FINISHED_CANS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_ADDED_PARCELS_OF_FINISHED_PRODUCT_ID", anydata.cans_parcels[i].SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSAL_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER", no_receiving_permission_number_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", maccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", memployee.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DISMISSED_QUANTITY_OF_FINISHED_CANS_ID", qu_id);
                    cmd.ExecuteNonQuery();
                }             
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE ADDING NEW DISMISSED PALLETs OF FINISHED CANS "+ex.ToString());
            }
        }
        //update finished cans specifications
        async Task updatefinishedcansspecifications(SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA anydata)
        {
            try
            {
                myconnection.openConnection();
                for (int i = 0; i < anydata.cans_parcels.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SH_UPDATE_FINISHED_CANS_SPECIFICATIONS_MINUS", DatabaseConnection.mConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_PALLET", 1);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NUMBER_OF_CANS", anydata.cans_parcels[i].SH_TOTAL_NUMBER_OF_CANS);
                    cmd.Parameters.AddWithValue("@SH_ID", anydata.cans_parcels[i].SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID);
                    cmd.ExecuteNonQuery();
                }
                
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle UPDATING FINISHED CANS SPECIFICATIONS "+ex.ToString());
            }
        }

        async Task savereceitdata()
        {
            Cursor.Current = Cursors.WaitCursor;
            //save_receival_order_information_

            long info_id = await savenewreceitinformation();


            for (int i = 0; i < dismissed_containers.Count; i++)
            {
                string cur_string = "";
                long cur_size = (i + 1).ToString().Length;
                for (int k = 0; k < 3 - cur_size; k++)
                {
                    cur_string += "0";
                }
                cur_string += (i + 1);


                switch (dismissed_containers[i].product_type)
                {
                    case 0:
                        {
                            //finished cans
                            //save receive information
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedfinishedcansquantity(dismissed_containers[i]);
                            await savenewdismissedpalletsoffinishedcans(myid, dismissed_containers[i]);
                            await updatefinishedcansspecifications(dismissed_containers[i]);
                            //  MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                            break;
                        }
                    case 1:
                        {
                            //bottom
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedbottomquantity(dismissed_containers[i]);
                            await savenewdismissedbottomcontainers(myid, dismissed_containers[i]);
                            await updatebottomspecifications(dismissed_containers[i]);
                            break;
                        }
                    case 2:
                        {
                            //rlt
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedrltquantity(dismissed_containers[i]);
                            await savenewdismissedrltcontainers(myid, dismissed_containers[i]);
                            await updaterltpecifications(dismissed_containers[i]);
                            break;
                        }
                    case 3:
                        {
                            //easy open
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedeasyopenquantity(dismissed_containers[i]);
                            await savenewdismissedeastyopencontainers(myid, dismissed_containers[i]);
                            await updateeasyopenspecifications(dismissed_containers[i]);
                            break;
                        }
                    case 4:
                        {
                            //peel off
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedpeeloffquantity(dismissed_containers[i]);
                            await savenewdismissedpeeloffcontainers(myid, dismissed_containers[i]);
                            await updatepeeloffspecifications(dismissed_containers[i]);
                            break;
                        }
                    case 5:
                        {
                            //twist of
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedtwistofquantity(dismissed_containers[i]);
                            await savenewdismissedtwistofcontainers(myid, dismissed_containers[i]);
                            await updatetwistofspecifications(dismissed_containers[i]);
                            break;
                        }
                    case 6:
                        {
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedplasticcoverqunatity(dismissed_containers[i]);
                            await savenewdismissedplasticcovercontainers(myid, dismissed_containers[i]);
                            await updateplasticcoverspecifications(dismissed_containers[i]);
                            //plastic cover
                            break;
                        }
                    case 7:
                        {
                            long qu_id = await savenewreceitinformationitems(info_id, dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedplasticmoldquantity(dismissed_containers[i]);
                            await savenewdismissedplasticmoldcontainers(myid, dismissed_containers[i]);
                            await updatedismissedplasticmoldspecifications(dismissed_containers[i]);
                            //plastic mold
                            break;
                        }
                    default:
                        break;
                }
            }

            MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            printreceivalpermission myform = new printreceivalpermission(no_receiving_permission_number_text_box.Text);
            //printreceivalpermission myform = new printreceivalpermission("SH_19-0012");
            myform.Show();
            Cursor.Current = Cursors.Default;
            this.Hide();
            clientreceivalpermissionnumberform newform = new clientreceivalpermissionnumberform(memployee, maccount, mpermission);
            newform.Show();
            this.Close();
        }


        private async void save_and_print_btn_Click(object sender, EventArgs e)
        {
            bool msave = true;
            if (string.IsNullOrWhiteSpace(no_of_order_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل رقم أمر التوريد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            else
            if (string.IsNullOrWhiteSpace(client_branches_combo_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل مكان التسليم", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }else if (string.IsNullOrWhiteSpace(stocks_combo_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل إسم المخزن", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }else if (string.IsNullOrWhiteSpace(driver_name_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل إسم السائق", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }else if (string.IsNullOrWhiteSpace(car_number_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل رقم السيارة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }else if (string.IsNullOrWhiteSpace(no_pallets_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل عدد البالتات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }else if (string.IsNullOrWhiteSpace(no_wooden_face_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل عدد الوش الخشب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }else if (string.IsNullOrWhiteSpace(no_carton_dividers_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل عدد الفاصل الكرتون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }else if (string.IsNullOrWhiteSpace(no_carton_corners_text_box.Text))
            {
                msave = false;
                MessageBox.Show("إدخل عدد الزوايا الكرتون", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
            if (msave)
            {
                await savereceitdata();
            }else
            {
                MessageBox.Show("لم يتم الحفظ ", "خطأ", MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }

        private void driver_name_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(driver_name_text_box.Text))
            {
                driver_name_error_provider.SetError(driver_name_text_box, "إسم السائق لا يمكن أن يكون فارغ");
            }else
            {
                driver_name_error_provider.Clear();
            }
        }

        private void car_number_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(car_number_text_box.Text))
            {
                driver_car_number_error_provider.SetError(car_number_text_box, "رقم السيارة لا يمكن أن يكون فارغ");
            }
            else
            {
                driver_car_number_error_provider.Clear();
            }
        }

        private void lisence_number_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(lisence_number_text_box.Text))
            {
                driver_lisence_number_error_provider.SetError(lisence_number_text_box,"رقم رخصة القيادة لا يمكن أن يكون فارغ");
            }else 
            {
                long testnumber = 0;
                if (long.TryParse(lisence_number_text_box.Text,out testnumber))
                {
                    driver_lisence_number_error_provider.Clear();
                }else
                {
                    driver_lisence_number_error_provider.SetError(lisence_number_text_box, "رقم رخصة القيادة عبارة عن أرقام صحيحة");

                }

            }
        }

        private void driver_telephone_text_box_TextChanged(object sender, EventArgs e)
        {
            if (driver_telephone_text_box.Text.Length != 11)
            {
                driver_telephone_number_error_provider.SetError(driver_telephone_text_box, "راجع رقم الموبايل");
            }
            else
            {
                driver_telephone_number_error_provider.Clear();
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(driver_telephone_text_box.Text, "[^0-9]"))
            {
                driver_telephone_number_error_provider.SetError(driver_telephone_text_box, "ادخل ارقام فقط");
                driver_telephone_text_box.Text = driver_telephone_text_box.Text.Remove(driver_telephone_text_box.Text.Length - 1);

            }
            else
            {
                driver_telephone_number_error_provider.Clear();
            }
        }

        private void no_pallets_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(no_pallets_text_box.Text))
            {
                no_of_pallets_error_provider.SetError(no_pallets_text_box,"عدد البالتات لايمكن ان يكون فارغ");
            }else
            {
                long testnumber = 0;
                if (long.TryParse(no_pallets_text_box.Text , out testnumber))
                {
                    //calculate total form pallets
                    //if (true)
                    //{

                    //}
                    //if (long.Parse(no_pallets_text_box.Text) < )
                    //{

                    //}
                    no_of_pallets_error_provider.Clear();
                }else
                {
                    no_of_pallets_error_provider.SetError(no_pallets_text_box, "عدد البالتات عبارة عن أرقام صحيحة");
                }
            }
        }

        private void no_wooden_face_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(no_wooden_face_text_box.Text))
            {
                no_wooden_face_error_provider.SetError(no_wooden_face_text_box, "عدد الوش الخشب لايمكن ان يكون فارغ");
            }
            else
            {
                long testnumber = 0;
                if (long.TryParse(no_wooden_face_text_box.Text, out testnumber))
                {
                    no_wooden_face_error_provider.Clear();
                }
                else
                {
                    no_wooden_face_error_provider.SetError(no_wooden_face_text_box, "عدد الوش الخشب عبارة عن أرقام صحيحة");
                }
            }
        }

        private void no_carton_dividers_text_box_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void no_carton_corners_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(no_carton_corners_text_box.Text))
            {
                carton_corners_error_provider.SetError(no_carton_corners_text_box, "عدد الزوايا الكرتون لايمكن ان يكون فارغة");
            }
            else
            {
                long testnumber = 0;
                if (long.TryParse(no_carton_corners_text_box.Text, out testnumber))
                {
                    carton_corners_error_provider.Clear();
                }
                else
                {
                    carton_corners_error_provider.SetError(no_carton_corners_text_box, "عدد الزوايا الكرتون عبارة عن أرقام صحيحة");
                }
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            clientreceivalpermissionnumberform myform = new clientreceivalpermissionnumberform(memployee,maccount,mpermission);
            myform.Show();
            this.Close();
        }
    }
}
