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
    public partial class raw_tin_all_spcifications : Form
    {
        List<SH_SPECIFICATION_OF_RAW_MATERIAL> all_raw_tin = new List<SH_SPECIFICATION_OF_RAW_MATERIAL>();
        List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();

        

        public raw_tin_all_spcifications()
        {
            InitializeComponent();
        }
        
        void loadallrawmaterialparcels()
        {
            try
            {
                string query = "SELECT * FROM SH_RAW_MATERIAL_PARCEL"; 
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parcels.Add(new SH_RAW_MATERIAL_PARCEL() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()) , SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString() , SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString() , SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString() });
                }
                myconnection.closeConnection();
         //       MessageBox.Show("GET ALL DATA");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING PARCELS DATA"+ ex.ToString());
            }

        }
        string removedotinnumber(double number)
        {
            string numerFDS = number.ToString();
            return numerFDS.Replace(".", "");
        }
        void updateitremscode()
        {
            loadallrawmaterialparcels();
            if (parcels.Count <= 0)
            {
              
            }
            else
            {
                string anyitemcode = "";
                for (int i = 0; i < parcels.Count; i++)
                {
                    anyitemcode = parcels[i].SH_ITEM_TYPE + removedotinnumber(parcels[i].SH_ITEM_THICKNESS) + removedotinnumber(parcels[i].SH_ITEM_WIDTH) + removedotinnumber(parcels[i].SH_ITEM_LENGTH);

                  //  MessageBox.Show(anyitemcode);
                    if (string.Compare(anyitemcode, parcels[i].SH_ITEM_CODE) != 0)
                    {
                        try
                        {
                            string query = "UPDATE SH_RAW_MATERIAL_PARCEL SET SH_ITEM_CODE = @SH_ITEM_CODE WHERE SH_ID = @SH_ID ";
                            DatabaseConnection myconnection = new DatabaseConnection();
                            myconnection.openConnection();
                            SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                            cmd.Parameters.AddWithValue("@SH_ITEM_CODE", anyitemcode);
                            cmd.Parameters.AddWithValue("@SH_ID", parcels[i].SH_ID);
                            cmd.ExecuteNonQuery();
                            //SUCCESSFULLY UPDATE CODE FOR ANY ITEM
                            myconnection.closeConnection();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE UPDATING PRCEL CODE "+ex.ToString() );
                        }
                    }
                }
            }
        }












        void updatequantitysp_id(long sp_old_id , long sp_new_id)
        {
            List<SH_QUANTITY_OF_RAW_MATERIAL> quantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_QUANTITY_OF_RAW_MATERIAL  WHERE SH_SPECIFICATION_OF_RAW_MATERIAL_ID = @SH_SPECIFICATION_OF_RAW_MATERIAL_ID", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID" , sp_old_id);
                SqlDataReader reader =  cmd.ExecuteReader();
                while(reader.Read())
                {
                    quantities.Add(new SH_QUANTITY_OF_RAW_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL QUANTITY IDs"+ex.ToString());
            }
            //updatingwithnew sp_new_id


            for (int i = 0; i < quantities.Count; i++)
            {
                try
                {
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();

                    SqlCommand cmd = new SqlCommand("UPDATE SH_QUANTITY_OF_RAW_MATERIAL SET SH_SPECIFICATION_OF_RAW_MATERIAL_ID = @SH_SPECIFICATION_OF_RAW_MATERIAL_ID WHERE SH_ID = @SH_ID ", DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID" , sp_new_id);
                    cmd.Parameters.AddWithValue("@SH_ID" , quantities[i].SH_ID);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE UPDATING QUANTITIES SP_ID");
                }
            }

           List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();
            //getting all old parcels that have the infection ;
            try
            {
                DatabaseConnection MYCONNECTION = new DatabaseConnection();
                MYCONNECTION.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_RAW_MATERIAL_PARCEL WHERE SH_SPECIFICATION_OF_RAW_MATERIAL_ID  = @SH_SPECIFICATION_OF_RAW_MATERIAL_ID", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", sp_old_id);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    parcels.Add(new SH_RAW_MATERIAL_PARCEL { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                MYCONNECTION.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GEETING INFECTED PARCELS WHITH old SP_OLD_ID"+ex.ToString());
            }

            //Correction of infected parcels

            for (int i = 0; i < parcels.Count; i++)
            {
                try
                {
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();

                    SqlCommand cmd = new SqlCommand("UPDATE SH_RAW_MATERIAL_PARCEL SET SH_SPECIFICATION_OF_RAW_MATERIAL_ID = @SH_SPECIFICATION_OF_RAW_MATERIAL_ID WHERE SH_ID = @SH_ID ", DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_ID", sp_new_id);
                    cmd.Parameters.AddWithValue("@SH_ID", parcels[i].SH_ID);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                catch (Exception)
                {
                    MessageBox.Show("ERROR WHILE UPDATING QUANTITIES SP_ID");
                }
            }
        }
        void updateraqwmaterialrecords()
        {
            for (int i = 0; i < all_raw_tin.Count; i++)
            {
                for (int k = 0; k < all_raw_tin.Count; k++)
                {
                    if(k==i)
                    {
                        continue;
                    }
                    if ((string.Compare(all_raw_tin[i].SH_ITEM_COATING , all_raw_tin[k].SH_ITEM_COATING)==0)&&  (string.Compare(all_raw_tin[i].SH_ITEM_CODE, all_raw_tin[k].SH_ITEM_CODE) == 0) && (string.Compare(all_raw_tin[i].SH_ITEM_TYPE, all_raw_tin[k].SH_ITEM_TYPE) == 0) && (all_raw_tin[i].SH_ITEM_LENGTH == all_raw_tin[k].SH_ITEM_LENGTH) && (all_raw_tin[i].SH_ITEM_WIDTH == all_raw_tin[k].SH_ITEM_WIDTH) && (all_raw_tin[i].SH_ITEM_THICKNESS == all_raw_tin[k].SH_ITEM_THICKNESS) && (string.Compare(all_raw_tin[i].SH_ITEM_FINISH , all_raw_tin[k].SH_ITEM_FINISH)==0) && (string.Compare(all_raw_tin[i].SH_ITEM_TEMPER , all_raw_tin[i].SH_ITEM_TEMPER)==0))
                    {
                        //makes some changes   
                        long old_id = all_raw_tin[i].SH_ID;
                        long new_id = all_raw_tin[k].SH_ID;
                        SH_SPECIFICATION_OF_RAW_MATERIAL anysp = new SH_SPECIFICATION_OF_RAW_MATERIAL();
                        anysp.SH_ITEM_TOTAL_GROSS_WEIGHT = all_raw_tin[k].SH_ITEM_TOTAL_GROSS_WEIGHT + all_raw_tin[i].SH_ITEM_TOTAL_GROSS_WEIGHT;
                        anysp.SH_ITEM_TOTAL_NET_WEIGHT = all_raw_tin[k].SH_ITEM_TOTAL_NET_WEIGHT + all_raw_tin[i].SH_ITEM_TOTAL_NET_WEIGHT;
                        anysp.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = all_raw_tin[k].SH_ITEM_TOTAL_NUMBER_OF_PACKAGES + all_raw_tin[i].SH_ITEM_TOTAL_NUMBER_OF_PACKAGES;
                        anysp.SH_ITEM_TOTAL_NUMBER_OF_SHEETS = all_raw_tin[k].SH_ITEM_TOTAL_NUMBER_OF_SHEETS + all_raw_tin[i].SH_ITEM_TOTAL_NUMBER_OF_SHEETS;
                        

                        try
                        {
                            DatabaseConnection myconnection = new DatabaseConnection();
                            myconnection.openConnection();
                            SqlCommand cmd = new SqlCommand("UPDATE SH_SPECIFICATION_OF_RAW_MATERIAL SET SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = @SH_ITEM_TOTAL_NUMBER_OF_PACKAGES , SH_ITEM_TOTAL_NUMBER_OF_SHEETS = @SH_ITEM_TOTAL_NUMBER_OF_SHEETS , SH_TOTAL_NET_WEIGHT = @SH_TOTAL_NET_WEIGHT, SH_TOTAL_GROSS_WEIGHT = @SH_TOTAL_GROSS_WEIGHT WHERE(SH_ID = @sh_id)", DatabaseConnection.mConnection);
                            cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES" , anysp.SH_ITEM_TOTAL_NUMBER_OF_PACKAGES);
                            cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS" , anysp.SH_ITEM_TOTAL_NUMBER_OF_SHEETS);
                            cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT", anysp.SH_ITEM_TOTAL_GROSS_WEIGHT);
                            cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT" , anysp.SH_ITEM_TOTAL_NET_WEIGHT);
                            cmd.Parameters.AddWithValue("@sh_id" , new_id);
                            cmd.ExecuteNonQuery();
                            myconnection.closeConnection();
                            updatequantitysp_id(new_id , old_id);
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("ERROR WHILE UPDATING RECORDS" + ex.ToString()); 
                        }

                        try
                        {
                            DatabaseConnection myconn = new DatabaseConnection();
                            myconn.openConnection();
                            SqlCommand cmd = new SqlCommand("DELETE FROM SH_SPECIFICATION_OF_RAW_MATERIAL WHERE(SH_ID = @sh_id)" , DatabaseConnection.mConnection);
                            cmd.Parameters.AddWithValue("@sh_id" , old_id);
                            cmd.ExecuteNonQuery();
                            myconn.closeConnection();
                            all_raw_tin.Remove(all_raw_tin[k]);
                        }
                        catch (Exception)
                        {

                            throw;
                        }


                    }
                }
            }
        }







        void LOADALLRAWTININFOS()
        {
            all_raw_tin.Clear();
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("Select * FROM SH_SPECIFICATION_OF_RAW_MATERIAL ", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    all_raw_tin.Add(new SH_SPECIFICATION_OF_RAW_MATERIAL { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()) , SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()) , SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()) , SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString() , SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString() , SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString() , SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString() , SH_ITEM_INTENSITY = double.Parse(reader["SH_ITEM_INTENSITY"].ToString()) , SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString() , SH_ITEM_NAME = reader["SH_ITEM_NAME"].ToString() , SH_CREATION_DATE = DateTime.Parse(reader["SH_CREATION_DATE"].ToString()), SH_ITEM_TOTAL_GROSS_WEIGHT =double.Parse(reader["SH_TOTAL_GROSS_WEIGHT"].ToString()) , SH_ITEM_TOTAL_NET_WEIGHT = double.Parse(reader["SH_TOTAL_NET_WEIGHT"].ToString()) , SH_ITEM_TOTAL_NUMBER_OF_PACKAGES= long.Parse(reader["SH_ITEM_TOTAL_NUMBER_OF_PACKAGES"].ToString()) , SH_ITEM_TOTAL_NUMBER_OF_SHEETS = long.Parse(reader["SH_ITEM_TOTAL_NUMBER_OF_SHEETS"].ToString()) });

                }


                myconnection.closeConnection();
            }
            catch (Exception)
            {

                MessageBox.Show("خطأ فى تحميل البيانات " , "خطأ" , MessageBoxButtons.OK  , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
        }


        private void fillgridviewitems()
        {
            updateraqwmaterialrecords();
            LOADALLRAWTININFOS();
            for (int i = 0; i < all_raw_tin.Count; i++)
            {
                sh_main_grid_view.Rows.Add(new string[] { all_raw_tin[i].SH_ID.ToString(), all_raw_tin[i].SH_ITEM_LENGTH.ToString(), all_raw_tin[i].SH_ITEM_WIDTH.ToString(), all_raw_tin[i].SH_ITEM_THICKNESS.ToString(), all_raw_tin[i].SH_ITEM_TYPE.ToString(), all_raw_tin[i].SH_ITEM_NAME, all_raw_tin[i].SH_ITEM_CODE ,all_raw_tin[0].SH_ITEM_TEMPER ,all_raw_tin[i].SH_ITEM_COATING ,all_raw_tin[i].SH_ITEM_FINISH,all_raw_tin[i].SH_ITEM_TOTAL_NUMBER_OF_PACKAGES.ToString() , all_raw_tin[i].SH_ITEM_TOTAL_NUMBER_OF_SHEETS.ToString() , all_raw_tin[i].SH_ITEM_TOTAL_NET_WEIGHT.ToString() , all_raw_tin[i].SH_ITEM_TOTAL_GROSS_WEIGHT.ToString() });
            }
        }

        private void raw_tin_all_spcifications_Load(object sender, EventArgs e)
        {
            updateitremscode();
            LOADALLRAWTININFOS();
            fillgridviewitems();
        }

        private void sh_main_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void sh_sp_quantites_btn_Click(object sender, EventArgs e)
        {
            int currentrowsindex = -1;
            if (sh_main_grid_view.SelectedRows.Count > 0)
            {
                currentrowsindex = sh_main_grid_view.SelectedRows[0].Index;
                if (currentrowsindex != -1)
                {
                    using (quantities_of_selected_sp_raw_tin myform = new quantities_of_selected_sp_raw_tin(all_raw_tin[currentrowsindex].SH_ID))
                    {
                        myform.ShowDialog();
                    }
                }  
            }
        }
    }
}
