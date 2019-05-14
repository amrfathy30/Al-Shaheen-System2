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

        public long back = 0;
        public clientreceivalpermissionnumberform(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            memployee = anyemp;
            maccount = anyaccount;
            mpermission = anyperm;
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
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('SH_RECEIVING_PERMISSION_INFORMATION') AS Current_Identity;", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                long current_id = 0;
                if (reader.Read())
                {
                    current_id = long.Parse(reader["Current_Identity"].ToString());
                }
                reader.Close();
                myconnection.closeConnection();

                string cur_string = "";
                long cur_size = current_id.ToString().Length;
                for (int i = 0; i < 4 - cur_size; i++)
                {
                    cur_string += "0";
                }
                cur_string += current_id;
                no_receiving_permission_number_text_box.Text = "SH_" + DateTime.Now.ToString("yy") + "-" + cur_string;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTInG RECEIT ORDER NUMBER " + ex.ToString());
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
                        dismissed_containers = myform.dismissed_containers;
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
                                dismissed_containers_grid_view.Rows.Add(new string[] {
                                    (i+1).ToString(),
                                    (no_receiving_permission_number_text_box.Text+cur_string),
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
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
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
                            long qu_id = await savenewreceitinformationitems(info_id , dismissed_containers[i], cur_string);
                            await savenewreceitinformationitemsfinishedcans(qu_id, dismissed_containers[i]);
                            long myid = await savenewdismissedfinishedcansquantity(dismissed_containers[i]);
                            await savenewdismissedpalletsoffinishedcans(myid, dismissed_containers[i]);
                            await updatefinishedcansspecifications(dismissed_containers[i]);
                            break;
                        }
                    case 1:
                        {
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                    case 7:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }



            Cursor.Current = Cursors.Default;
        }


        private async void save_and_print_btn_Click(object sender, EventArgs e)
        {
            await savereceitdata();
        }
    }
}
