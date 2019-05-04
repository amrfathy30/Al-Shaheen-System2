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
    public partial class addnewfaceproduct : Form
    {
        List<SH_BOTTEL_FACE_DATA> form_data = new List<SH_BOTTEL_FACE_DATA>();
        List<SH_SPECIFICATION_MOLD_BOTTEL_FACE> mold_types = new List<SH_SPECIFICATION_MOLD_BOTTEL_FACE>();
        List<SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE> printing_types = new List<SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE>();
        List<SH_SPECIFICATION_AEROSOL_BOTTEL_FACE> aerosol_specifications = new List<SH_SPECIFICATION_AEROSOL_BOTTEL_FACE>();
        List<SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE> screw_bottel_faces = new List<SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE>();
        List<SH_ITEM_SIZE> msizes = new List<SH_ITEM_SIZE>();
        List<SH_SCREW_USAGE> screw_usages = new List<SH_SCREW_USAGE>();
        List<SH_SCREW_SIZE> screw_sizes = new List<SH_SCREW_SIZE>();
        List<SH_BOTTLE_FACE_TYPES> general_types = new List<SH_BOTTLE_FACE_TYPES>();
        List<SH_MOLD_SIZE> sizes = new List<SH_MOLD_SIZE>();
        List<SH_HAND_TYPES> hand_types = new List<SH_HAND_TYPES>();
        List<SH_BOTTLE_FACE_PAINTINGS_TYPES> face_painting_types = new List<SH_BOTTLE_FACE_PAINTINGS_TYPES>();
        List<SH_AEROSOL_SIZE> aerosol_sizes = new List<SH_AEROSOL_SIZE>();
        List<SH_AEROSOL_TYPE> aerosol_types = new List<SH_AEROSOL_TYPE>();
        DatabaseConnection myconnection = new DatabaseConnection();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        Byte[] ImageByteArray;

        int face_product_type = 0;


        public addnewfaceproduct()
        {
            InitializeComponent();
        }
        //save specifications 
        //mold bottel face 
        async Task getallmoldbottelface()
        {
            mold_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_PLASTIC_MOLD_SPECIFICATIONS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mold_types.Add(new SH_SPECIFICATION_MOLD_BOTTEL_FACE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MOLD_SIZE_ID = long.Parse(reader["SH_MOLD_SIZE_ID"].ToString()), SH_MOLD_SIZE_VALUE = long.Parse(reader["SH_MOLD_SIZE_VALUE"].ToString()), SH_MOLD_TYPE_ID = long.Parse(reader["SH_MOLD_TYPE_ID"].ToString()) , SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString() , SH_HAND_TYPE_ID = long.Parse(reader["SH_HAND_TYPE_ID"].ToString()) , SH_HAND_TYPE_NAME = reader["SH_HAND_TYPE_NAME"].ToString() , SH_HAS_HAND_OR_NOT = long.Parse(reader["SH_HAS_HAND_OR_NOT"].ToString()) , SH_NO_OF_CONTAINER= long.Parse(reader["SH_NO_OF_CONTAINER"].ToString()) , SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING MOLD BOTTEL TYPES INFORMaTION " + ex.ToString());
            }
        }
        async Task<long> check_if_mold_bottel_face_exists_or_not(SH_BOTTEL_FACE_DATA mydata)
        {
            await getallmoldbottelface();
            if (mold_types.Count > 0)
            {
                for (int i = 0; i < mold_types.Count; i++)
                {
                    if (mold_types[i].SH_MOLD_SIZE_ID == mydata.mold_size.SH_ID && mold_types[i].SH_MOLD_TYPE_ID == mydata.mold_type_id  )
                    {
                        if (mold_types[i].SH_HAS_HAND_OR_NOT== mydata.hand_or_not )
                        {
                            if (mold_types[i].SH_HAS_HAND_OR_NOT==1)
                            {
                                if (mold_types[i].SH_HAND_TYPE_ID == mydata.hand_type.SH_ID)
                                {
                                    return mold_types[i].SH_ID;
                                }
                            }else
                            {
                                return mold_types[i].SH_ID;
                            }
                            
                        }
                    }
                }
            }
            return 0;
        }

        async Task updatemoldbottelfacesspecifications(long sp_id,SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_MOLD_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINER",mydata.no_of_boxes);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING MOLD BOTTEL FACES "+ex.ToString());
            }
        }


        //printing bottel face specifications 
        async Task getallprintingbottelfacespecifications()
        {
            printing_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    printing_types.Add(new SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE() { SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_NO_CONTAINER = long.Parse(reader["SH_NO_CONTAINER"].ToString()) , SH_NO_ITEMS_PER_CONTAINER = long.Parse(reader["SH_NO_ITEMS_PER_CONTAINER"].ToString()) , SH_PAINTING_SHAPE_TYPE_ID = long.Parse(reader["SH_PAINTING_SHAPE_TYPE_ID"].ToString()) , SH_PAINTING_SHAPE_TYPE_NAME = reader["SH_PAINTING_SHAPE_TYPE_NAME"].ToString() , SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTING BOTTEL FACE SPECIFICATION " + ex.ToString());
            }
        }
        async Task<long> check_if_priting_bottel_face_exists_or_not(SH_BOTTEL_FACE_DATA mydata)
        {
            await getallprintingbottelfacespecifications();
            if (printing_types.Count>0)
            {
                for (int i = 0; i < printing_types.Count; i++)
                {
                    if (printing_types[i].SH_PAINTING_SHAPE_TYPE_ID == mydata.printing_type.SH_ID )
                    {
                        return printing_types[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        async Task updateprintingbottelfacespecification(long sp_id, SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_PRINTING_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINER", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);              
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING BOTTEL FACE SPECIFICATION "+ex.ToString());
            }
        }


        //aerosol specifications 
        async Task getallaerosolsepecifications()
        {
            aerosol_specifications.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SPECIFICATIONS_AEROSOL_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aerosol_specifications.Add(new SH_SPECIFICATION_AEROSOL_BOTTEL_FACE() { SH_AEROSOL_SIZE_ID = long.Parse(reader["SH_AEROSOL_SIZE_ID"].ToString()) , SH_AEROSOL_SIZE_NAME = reader["SH_AEROSOL_SIZE_NAME"].ToString() , SH_AEROSOL_TYPE_ID = long.Parse(reader["SH_AEROSOL_TYPE_ID"].ToString()) , SH_AEROSOL_TYPE_NAME = reader["SH_AEROSOL_TYPE_NAME"].ToString() , SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString() , SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_NO_CONTAINERS = long.Parse(reader["SH_NO_CONTAINERS"].ToString()) , SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())});
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL AEROSOL SPECIFICATIONS "+ex.ToString());
            }
        }

        async Task<long> check_if_aerosol_specification_exists_or_not(SH_BOTTEL_FACE_DATA mydata)
        {
            await getallaerosolsepecifications();
            if (aerosol_specifications.Count > 0)
            {
                for (int i = 0; i < aerosol_specifications.Count; i++)
                {
                    if (aerosol_specifications[i].SH_AEROSOL_SIZE_ID == mydata.aerosol_size.SH_ID && aerosol_specifications[i].SH_AEROSOL_TYPE_ID == mydata.aerosol_type.SH_ID)
                    {
                        return aerosol_specifications[i].SH_ID;
                    }
                }
            }
            return 0;
        }

        async Task updateaersolbottlefacespecification(long sp_id , SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_AEROSOL_BOTTEL_FACE_SPECIFICATIONS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILe UPDATING AEROSOL BOTTEL FACE SPECIFICATION "+ex.ToString());
            }
        }


        // screw bottel face specifications 
        async Task getallscrewspecifications()
        {
            screw_bottel_faces.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFICATIONS_OF_SCREW_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_bottel_faces.Add(new SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE() { SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_NO_ITEMS_PER_CONTAINER = long.Parse(reader["SH_NO_ITEMS_PER_CONTAINER"].ToString()), SH_NO_OF_CONTAINERS = long.Parse(reader["SH_NO_OF_CONTAINERS"].ToString()), SH_SCREW_SIZE_ID = long.Parse(reader["SH_SCREW_SIZE_ID"].ToString()), SH_SCREW_SIZE_NAME = reader["SH_SCREW_SIZE_NAME"].ToString(), SH_SCREW_USAGE_TYPE_ID = long.Parse(reader["SH_SCREW_USAGE_TYPE_ID"].ToString()), SH_SCREW_USAGE_TYPE_NAME = reader["SH_SCREW_USAGE_TYPE_NAME"].ToString(), SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())});
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SCREW SPECIFICATIONS "+ex.ToString());
            }
        }
         async Task<long> check_if_screw_specification_exists_or_not(SH_BOTTEL_FACE_DATA mydata)
        {
            await getallscrewspecifications();
            if (screw_bottel_faces.Count >0)
            {
                for (int i = 0; i < screw_bottel_faces.Count; i++)
                {
                    if (screw_bottel_faces[i].SH_SCREW_SIZE_ID == mydata.screw_size.SH_ID && screw_bottel_faces[i].SH_SCREW_USAGE_TYPE_ID == mydata.screw_usage.SH_ID)
                    {
                        return screw_bottel_faces[i].SH_ID;
                    }
                }
            }
            return 0;
        }
        
        async Task update_screw_bottel_face_specifications(long SP_ID , SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_SCREW_BOTTEL_FACE_SPECIFICATION", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_ID", SP_ID);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE UPDATING SCREW BOTTEL FaCES "+ex.ToString());
            }
        }

        //general specification
        async Task<long> savenewgeneralspecification()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_GENERAL_SPECIFICATION_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", "");
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", "");
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE_ID", "");
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "");
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE_ID ", "");
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_COVER_PLATE_BOTTEL_FACE_ID", "");
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_MOLD_BOTTEL_FACE_ID", "");
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_AEROSOL_BOTTEL_FACE_ID", "");
                cmd.Parameters.AddWithValue("@SH_BOTTEL_FACE_TYPE_NAME", "");
                cmd.Parameters.AddWithValue("@SH_BOTTEL_FACE_TYPE_ID", "");
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
                MessageBox.Show("ERROR WHIle ADDING NEW GENERAL SPECIFIcaTION " + ex.ToString());
            }
            return 0;
        }

        async Task update_general_bottel_face_specification(long sp_id , SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_BOTTEL_FACE_GENERAL_SPECIFICATION", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_ID", sp_id);         
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE UPDATING BOTTEL FACE GENERAL INFO "+ex.ToString());
            }
        }


        // savequntities
        async Task<long> savenewfacequantity()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_QUANTITY_OF_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_GENERAL_SPECIFICATION_BOTTEL_FACE_ID", "");
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", "");
                cmd.Parameters.AddWithValue("@SH_WORK_ORDER_NUMBER", "");
                cmd.Parameters.AddWithValue("@SH_ADDTION_DATE", "");
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", "");
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME", "");
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", "");
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", "");
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "");
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", "");
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", "");
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", "");
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
                MessageBox.Show("ERROR WHILe ADDING NEW FACE QUANTITIY " + ex.ToString());
            }
            return 0;
        }


        //savecontainers

        async Task savenewfaceocntainers()
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_CONTAINER_OF_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_BOTTEL_FACE_ID", "");
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "");
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", "");
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", "");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING FACE CONTAINERS " + ex.ToString());
            }
        }

        async Task getallstocks()
        {
            stocks.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_STOCKS ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString(), SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING STOCKS INFORMATION " + ex.ToString());
            }
        }
        async Task fillstockscombobox()
        {
            await getallstocks();
            this.Invoke((MethodInvoker)delegate ()
            {
                stocks_combo_box.Items.Clear();
            });
            if (stocks.Count > 0)
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        stocks_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                    });
                }
            }
        }

        async Task  loadaallsizes()
        {
            msizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    msizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(), SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(), SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }
        async Task fillsizescombobox()
        {
            await loadaallsizes();
            sizes_combo_box.Items.Clear();
            if (msizes.Count > 0)
            {
                string sectext = "";
                for (int i = 0; i < msizes.Count; i++)
                {
                    if (string.Compare(msizes[i].SH_SIZE_SECOND_DIAMETER_NAME, "D2") == 0)
                    {
                        sectext = " ";
                    }
                    else
                    {
                        sectext = msizes[i].SH_SIZE_SECOND_DIAMETER_NAME;
                    }
                    sizes_combo_box.Items.Add(msizes[i].SH_SIZE_NAME);
                }
            }
        }
        async Task getallhandsizes()
        {
            aerosol_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_AEROSOL_SIZES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aerosol_sizes.Add(new SH_AEROSOL_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_AEROSOL_SIZE_VALUE = long.Parse(reader["SH_AEROSOL_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTING HaND SIZES " + ex.ToString());
            }
        }

        async Task fillhandsizesgridview()
        {
            aerosol_size_text_box.Items.Clear();
            await getallhandsizes();
            if (aerosol_sizes.Count > 0)
            {
                for (int i = 0; i < aerosol_sizes.Count; i++)
                {
                    aerosol_size_text_box.Items.Add(aerosol_sizes[i].SH_AEROSOL_SIZE_VALUE.ToString());
                }
            }
        }


        async Task getallscrew_sizes()
        {
            screw_sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SCREW_SIZES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_sizes.Add(new SH_SCREW_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SCREW_SIZE_VALUE = long.Parse(reader["SH_SCREW_SIZE_VALUE"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING " + ex.ToString());
            }
        }
        async Task fillscrewsizesgridview()
        {
            await getallscrew_sizes();
            Screw_size_combo_box.Items.Clear();
            if (screw_sizes.Count > 0)
            {
                for (int i = 0; i < screw_sizes.Count; i++)
                {
                    Screw_size_combo_box.Items.Add(screw_sizes[i].SH_SCREW_SIZE_VALUE.ToString());
                }
            }
        }


        async Task getallbottelfacepaintingtypes()
        {
            face_painting_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_BOTTLE_FACE_PAINTINGS_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //MessageBox.Show(reader["SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME"].ToString());
                    //MessageBox.Show(reader["SH_TYPE_IMAGE"].ToString().Trim());
                    byte[] ImageArray = null;
                    if (reader["SH_TYPE_IMAGE"].ToString().Trim() == "" || reader["SH_TYPE_IMAGE"].ToString().Trim() == null)
                    {
                        // MessageBox.Show("1");
                        ImageArray = null;
                        face_painting_types.Add(new SH_BOTTLE_FACE_PAINTINGS_TYPES() { SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME = reader["SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TYPE_IMAGE = null, SH_TYPE_SHAPE_NAME = reader["SH_TYPE_SHAPE_NAME"].ToString() });

                    }
                    else
                    {
                        ImageArray = (byte[])reader["SH_TYPE_IMAGE"];
                        if (ImageArray.Length != 0)
                        {
                            ImageByteArray = ImageArray;
                            face_painting_types.Add(new SH_BOTTLE_FACE_PAINTINGS_TYPES() { SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME = reader["SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TYPE_IMAGE = Image.FromStream(new MemoryStream(ImageArray)), SH_TYPE_SHAPE_NAME = reader["SH_TYPE_SHAPE_NAME"].ToString() });
                            //  MessageBox.Show("2");
                        }
                    }
                }
                reader.Close();
                myconnection.closeConnection();
                //   MessageBox.Show(face_painting_types.Count.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE GETTInG BOTTEL FACE TYPES FROM DB " + ex.ToString());
            }
        }

        async Task fillfacepaintingtypesgridview()
        {
            await getallbottelfacepaintingtypes();
            printing_shape_type_combo_box.Items.Clear();
            if (face_painting_types.Count > 0)
            {
                for (int i = 0; i < face_painting_types.Count; i++)
                {
                    printing_shape_type_combo_box.Items.Add(face_painting_types[i].SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME);
                }
            }
        }


        async Task getallhandtypes()
        {
            hand_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SH_HAND_TYPES ", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    hand_types.Add(new SH_HAND_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_TYPE_HAND_SIZE_ID = long.Parse(reader["SH_TYPE_HAND_SIZE_ID"].ToString()), SH_TYPE_HAND_SIZE_NAME = reader["SH_TYPE_HAND_SIZE_NAME"].ToString(), SH_TYPE_MATERIAL_TYPE = reader["SH_TYPE_MATERIAL_TYPE"].ToString(), SH_TYPE_NAME = reader["SH_TYPE_NAME"].ToString(), SH_TYPE_PILLOW_COLOR_ID = long.Parse(reader["SH_TYPE_PILLOW_COLOR_ID"].ToString()), SH_TYPE_PILLOW_COLOR_NAME = reader["SH_TYPE_PILLOW_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING All hAnd TYPES " + ex.ToString());
            }
        }
        async Task fillhandtypesgridview()
        {
            await getallhandtypes();
            hand_type_combo_box.Items.Clear();
            if (hand_types.Count > 0)
            {
                for (int i = 0; i < hand_types.Count; i++)
                {
                    hand_type_combo_box.Items.Add(hand_types[i].SH_TYPE_NAME);
                }
            }
        }
        async Task getallsizesdata()
        {
            sizes.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SIZES_DATA", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_MOLD_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_MOLD_SIZE_VALUE = double.Parse(reader["SH_MOLD_SIZE_VALUE"].ToString()) });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL MOLD SIZES FORM DB " + ex.ToString());
            }
        }
        async Task fillsizesgridview()
        {
            await getallsizesdata();
            mold_sizes_combo_box.Items.Clear();
            try
            {
                if (sizes.Count > 0)
                {
                    for (int i = 0; i < sizes.Count; i++)
                    {
                        mold_sizes_combo_box.Items.Add(Math.Round(sizes[i].SH_MOLD_SIZE_VALUE, 1).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE FILLING DATA GRiD VIEW " + ex.ToString());
            }
        }

        async Task getallbottelfacetypes()
        {
            general_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_BOTTEL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    general_types.Add(new SH_BOTTLE_FACE_TYPES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_BOTTLE_TYPE_NAME = reader["SH_BOTTLE_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACE TYPES FROM DB " + ex.ToString());
            }
        }

        async Task fillfacetypesgridview()
        {
            bottel_face_type_combo_box.Items.Clear();
            await getallbottelfacetypes();
            if (general_types.Count > 0)
            {
                for (int i = 0; i < general_types.Count; i++)
                {
                    bottel_face_type_combo_box.Items.Add(general_types[i].SH_BOTTLE_TYPE_NAME);
                }
            }
        }
        async Task get_all_usages()
        {
            screw_usages.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_USAGES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    screw_usages.Add(new SH_SCREW_USAGE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SCREW_USAGE_NAME = reader["SH_SCREW_USAGE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING USAGES DATA " + ex.ToString());
            }
        }
        async Task fillusagesgridview()
        {
            await get_all_usages();
            Screw_usage_combo_box.Items.Clear();
            if (screw_usages.Count > 0)
            {
                for (int i = 0; i < screw_usages.Count; i++)
                {
                    Screw_usage_combo_box.Items.Add(screw_usages[i].SH_SCREW_USAGE_NAME);
                }
            }
        }
        async Task getallaerosoltypes()
        {
            aerosol_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_AEROSOL_TYPES", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    aerosol_types.Add(new SH_AEROSOL_TYPE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_AEROSOL_TYPE_NAME = reader["SH_AEROSOL_TYPE_NAME"].ToString() });
                }
                reader.Close();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING AEROSOL TYPES " + ex.ToString());
            }
        }

        async Task fillaerosoltypesgridview()
        {
            await getallaerosoltypes();
            aerosol_type_text_box.Items.Clear();
            if (aerosol_types.Count > 0)
            {
                for (int i = 0; i < aerosol_types.Count; i++)
                {
                    aerosol_type_text_box.Items.Add(aerosol_types[i].SH_AEROSOL_TYPE_NAME);
                }
            }
        }
        private async void addnewfaceproduct_Load(object sender, EventArgs e)
        {
            //  Cursor 
            mold_panel.Visible = false;
            qlawooz_panel.Visible = false;
            printing_panel.Visible = false;
            panel1.Visible = false;
       
            panel3.Visible = true;
            await fillsizescombobox();
            await fillfacetypesgridview();
            await fillsizesgridview();
            await fillhandtypesgridview();
            await fillfacepaintingtypesgridview();
            await fillscrewsizesgridview();
            await fillusagesgridview();
            await fillhandsizesgridview();
            await fillaerosoltypesgridview();
            await fillstockscombobox();
        }

        private void printing_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bottel_face_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            face_product_type = bottel_face_type_combo_box.SelectedIndex;
            if (face_product_type==0)
            {
                mold_panel.Visible = true;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = false;
                panel1.Visible = false;
               
                panel3.Visible = false;

            }else if (face_product_type == 1)
            {
                mold_panel.Visible = false;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = true;
                panel1.Visible = false;
               
                panel3.Visible = false;
            }else if (face_product_type == 2)
            {
                mold_panel.Visible = false;
                panel1.Visible = false;

                panel3.Visible = false;
                printing_panel.Visible = false;
                qlawooz_panel.Visible = true;
               
                
            }else if (face_product_type == 3)
            {
                panel1.Show();
                panel1.Visible = true;
                mold_panel.Visible = false;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = false;
                
                panel3.Visible = false;  
            }
            else if(face_product_type == 4)
            {
                mold_panel.Visible = false;
                qlawooz_panel.Visible = false;
                printing_panel.Visible = false;
                panel1.Visible = false;
                
                panel3.Visible = false;
            }
        }

        private void printing_shape_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            printing_image_box.Image = face_painting_types[printing_shape_type_combo_box.SelectedIndex].SH_TYPE_IMAGE;
        }
        void calculatetotalnoitems()
        {
            if (string.IsNullOrWhiteSpace(no_items_per_box_text_box.Text) || string.IsNullOrWhiteSpace(no_of_boxes_text_box.Text))
            {

            }else 
            {
                long testnumber = 0;
                if (long.TryParse(no_items_per_box_text_box.Text , out testnumber) && long.TryParse(no_of_boxes_text_box.Text, out testnumber))
                {
                    total_no_of_items_text_box.Text = (long.Parse(no_of_boxes_text_box.Text)*long.Parse(no_items_per_box_text_box.Text)).ToString();
                }
            }


        }
        private void no_of_boxes_text_box_TextChanged(object sender, EventArgs e)
        {
            calculatetotalnoitems();
        }

        private void no_items_per_box_text_box_TextChanged(object sender, EventArgs e)
        {
            calculatetotalnoitems();
        }

        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            bool cansave = true;
            if (string.IsNullOrWhiteSpace(addition_permission_number_text_box.Text))
            {
                MessageBox.Show("لايمكن ان يكون رقم إذن الإضافة فارغ","خطأ", MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(work_order_number_text_box.Text))
            {
                MessageBox.Show("رقم أمر الشغل فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(stocks_combo_box.Text))
            {
                MessageBox.Show("إسم المخزن فارغ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(stock_man_text_box.Text))
            {
                cansave = false;
            }
            else if (string.IsNullOrWhiteSpace(sizes_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار إسم المقاس", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(bottel_face_type_combo_box.Text))
            {
                MessageBox.Show("الرجاء إختيار نوع الوش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(no_items_per_box_text_box.Text))
            {
                MessageBox.Show("إكتب الكمية بالصندوق", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                cansave = false;
            } else if (string.IsNullOrWhiteSpace(no_of_boxes_text_box.Text))
            {
                MessageBox.Show("إدخل عدد الصناديق", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                cansave = false;
            }
            if (cansave)
            {

                form_data.Add(new SH_BOTTEL_FACE_DATA() { addition_date = DateTime.Now , addition_permission_number = addition_permission_number_text_box.Text , no_of_boxes = long.Parse(no_of_boxes_text_box.Text) , sizes = msizes[sizes_combo_box.SelectedIndex] ,no_items_per_box = long.Parse(no_items_per_box_text_box.Text) , work_order_number = work_order_number_text_box.Text , total_no_items = long.Parse(total_no_of_items_text_box.Text)});
                if (bottel_face_type_combo_box.SelectedIndex==0)
                {
                    form_data.Add(new SH_BOTTEL_FACE_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, no_of_boxes = long.Parse(no_of_boxes_text_box.Text), sizes = msizes[sizes_combo_box.SelectedIndex], no_items_per_box = long.Parse(no_items_per_box_text_box.Text), work_order_number = work_order_number_text_box.Text, total_no_items = long.Parse(total_no_of_items_text_box.Text) });

                }else if (bottel_face_type_combo_box.SelectedIndex == 0)
                {
                   
                }else if (bottel_face_type_combo_box.SelectedIndex == 0)
                {

                }

            }


        }
    }
}
