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
        SH_EMPLOYEES mstockman = new SH_EMPLOYEES();
        List<SH_GENERAL_SPECIFICATION_BOTTEL_FACE> general_info = new List<SH_GENERAL_SPECIFICATION_BOTTEL_FACE>();

        Byte[] ImageByteArray;

        int face_product_type = 0;

        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public addnewfaceproduct(SH_EMPLOYEES anyemp ,SH_USER_ACCOUNTS anyAccount, SH_USER_PERMISIONS anyPermission)
        {
            InitializeComponent();
            mstockman = anyemp;
            mAccount = anyAccount;
            mPermission = anyPermission;
        }
        async Task autogenerateadditionpermisionnumber()
        {
            long mycount = 0;
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT (MAX(SH_ID)+1) AS lastedid FROM SH_ADDITION_PERMISSION_NUMBER_OF_FACE_PRODUCT  ", DatabaseConnection.mConnection);
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
                permissionnumber += "TOP-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = 1.ToString();
                for (int i = 0; i < 5 - 1; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += 1.ToString();
                addition_permission_number_text_box.Text = permissionnumber;
            }
            else
            {
                string permissionnumber = "SH_";
                permissionnumber += "TOP-";
                permissionnumber += DateTime.Now.ToString("yy");
                string currentr = mycount.ToString();
                for (int i = 0; i < 5 - currentr.Length; i++)
                {
                    permissionnumber += "0";
                }
                permissionnumber += mycount.ToString();
                addition_permission_number_text_box.Text = permissionnumber;
            }
        }







        private void savenewpermssionnumber()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO SH_ADDITION_PERMISSION_NUMBER_OF_FACE_PRODUCT (SH_NUMBER) VALUES(@SH_NUMBER) ", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_NUMBER", 1.ToString());
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }






        //save specifications 
        //mold bottel face 
        async Task getallmoldbottelface()
        {
            mold_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_MOLD_BOTTEL_FACE_SPECIFICATIONS", DatabaseConnection.mConnection);
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

        async Task<long> savemoldtypespecification(SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_NEW_MOLD_BOTTEL_FACE_SPECIFICATION", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_MOLD_SIZE_ID", mydata.mold_size.SH_ID);
                cmd.Parameters.AddWithValue("@SH_MOLD_SIZE_VALUE", mydata.mold_size.SH_MOLD_SIZE_VALUE);
                cmd.Parameters.AddWithValue("@SH_MOLD_TYPE_ID", mydata.mold_type_id);
               // cmd.Parameters.AddWithValue("@SH_MOLD_TYPE_IMAGE", 0);
                cmd.Parameters.AddWithValue("@SH_HAS_HAND_OR_NOT", mydata.hand_or_not);
                if (mydata.hand_or_not==0)
                {
                    cmd.Parameters.AddWithValue("@SH_HAND_TYPE_ID",0);
                    cmd.Parameters.AddWithValue("@SH_HAND_TYPE_NAME", 0);

                }
                else
                {
                    cmd.Parameters.AddWithValue("@SH_HAND_TYPE_ID", mydata.hand_type.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_HAND_TYPE_NAME",mydata.hand_type.SH_TYPE_NAME );
                }
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق");
               
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINER", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);

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
                MessageBox.Show("ERROR WHILE SAVING MOLd TYPE SPECIFICATION "+ex.ToString());
            }
            return 0; 
        }

        //printing bottel face specifications 
        async Task getallprintingbottelfacespecifications()
        {
            printing_types.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_PRINTING_BOTTEL_FACE_SPECIFICATIONS", DatabaseConnection.mConnection);
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

        async Task<long> savenewprintingbottelfacespecification(SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_SPECIFICATION_OF_PRINTING_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_PAINTING_SHAPE_TYPE_ID", mydata.printing_type.SH_ID);
                cmd.Parameters.AddWithValue("@SH_PAINTING_SHAPE_TYPE_NAME", mydata.printing_type.SH_TYPE_SHAPE_NAME);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق");
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINER", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", mydata.no_items_per_box);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
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
                MessageBox.Show("ERROR WHILE ADDING NEW PRINTING FACE SPECIFICATION "+ex.ToString());
            }
            return 0;
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
                reader.Close();
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

        async Task<long> savenewaerosolbottelfacespecifications(SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_SPECIFICATION_AEROSOL_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق");
                cmd.Parameters.AddWithValue("@SH_AEROSOL_TYPE_NAME", mydata.aerosol_type.SH_AEROSOL_TYPE_NAME);
                cmd.Parameters.AddWithValue("@SH_AEROSOL_SIZE_ID", mydata.aerosol_size.SH_ID);
                cmd.Parameters.AddWithValue("@SH_AEROSOL_SIZE_NAME", mydata.aerosol_size.SH_AEROSOL_SIZE_VALUE.ToString());
                cmd.Parameters.AddWithValue("@SH_AEROSOL_TYPE_ID", mydata.aerosol_type.SH_ID);
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
                MessageBox.Show("ERROR WHILE ADDING NEW AEROSOL BOTTEL FACE SPCIFICATIONS "+ex.ToString());
            }
            return 0;
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


        async Task <long > savenewscrewbottelfacespecification(SH_BOTTEL_FACE_DATA mydata) 
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_SPECIFICATION_OF_SCREW_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_SCREW_SIZE_NAME", mydata.screw_size.SH_SCREW_SIZE_VALUE.ToString());
                cmd.Parameters.AddWithValue("@SH_SCREW_SIZE_ID", mydata.screw_size.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SCREW_USAGE_TYPE_ID", mydata.screw_usage.SH_ID);
                cmd.Parameters.AddWithValue("@SH_SCREW_USAGE_TYPE_NAME", mydata.screw_usage.SH_SCREW_USAGE_NAME);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق");
                cmd.Parameters.AddWithValue("@SH_NO_OF_CONTAINERS",mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", mydata.no_items_per_box);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
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
                MessageBox.Show("ERROR WHILE ADDING NEW SCREW BOTTEL FACE SPECIFICATIONS "+ex.ToString());
            }
            return 0;
        }

        //general specification

        async Task getallgeneralspecifications()
        {
            general_info.Clear();
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_GENERAL_SPECIFICATION_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    general_info.Add(new SH_GENERAL_SPECIFICATION_BOTTEL_FACE() { SH_BOTTEL_FACE_TYPE_ID = long.Parse(reader["SH_BOTTEL_FACE_TYPE_ID"].ToString()), SH_BOTTEL_FACE_TYPE_NAME = reader["SH_BOTTEL_FACE_TYPE_NAME"].ToString(), SH_CONTAINER_NAME = reader["SH_CONTAINER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_NO_CONTAINERS = long.Parse(reader["SH_NO_CONTAINERS"].ToString()), SH_SPECIFICATION_AEROSOL_BOTTEL_FACE_ID = long.Parse(reader["SH_SPECIFICATION_AEROSOL_BOTTEL_FACE_ID"].ToString())
                        , SH_SPECIFICATION_MOLD_BOTTEL_FACE_ID = long.Parse(reader["SH_SPECIFICATION_MOLD_BOTTEL_FACE_ID"].ToString()),
                        SH_SPECIFICATION_OF_COVER_PLATE_BOTTEL_FACE_ID = long.Parse(reader["SH_SPECIFICATION_OF_COVER_PLATE_BOTTEL_FACE_ID"].ToString()),
                        SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE_ID = long.Parse(reader["SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE_ID"].ToString()),
                        SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE_ID = long.Parse(reader["SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE_ID"].ToString()),
                        SH_TOTAL_NO_ITEMS = long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString())
                    });
                }
                reader.Read();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ALL BOTTEL FACE GENERAL INFO "+ex.ToString());
            }
        }
                  
        
        async Task<long> getgeneralspecification_id(long a, long s, long c , long p , long m )
        {
            await getallgeneralspecifications();
            if (general_info.Count >0)
            {
                for (int i = 0; i < general_info.Count; i++)
                {
                    if (general_info[i].SH_SPECIFICATION_AEROSOL_BOTTEL_FACE_ID == a && general_info[i].SH_SPECIFICATION_MOLD_BOTTEL_FACE_ID ==m && general_info[i].SH_SPECIFICATION_OF_COVER_PLATE_BOTTEL_FACE_ID == c && general_info[i].SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE_ID == p && general_info[i].SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE_ID == s)
                    {
                        return general_info[i].SH_ID;
                    }
                }          
            }
            return 0;
        }

        


        async Task<long> savenewgeneralspecification(long m , long p , long a , long s ,long c ,SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_GENERAL_SPECIFICATION_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE_ID", p);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق");
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE_ID ", s);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_COVER_PLATE_BOTTEL_FACE_ID", c);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_MOLD_BOTTEL_FACE_ID", m);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_AEROSOL_BOTTEL_FACE_ID", a);
                cmd.Parameters.AddWithValue("@SH_BOTTEL_FACE_TYPE_NAME", mydata.bottle_face_type.SH_BOTTLE_TYPE_NAME);
                cmd.Parameters.AddWithValue("@SH_BOTTEL_FACE_TYPE_ID", mydata.bottle_face_type.SH_ID);
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

        async Task<long> update_general_bottel_face_specification(long m ,long a , long c , long s , long p , SH_BOTTEL_FACE_DATA mydata)
        {

            long g_sp_id = await getgeneralspecification_id(a,s,c,p,m);
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_UPDATE_BOTTEL_FACE_GENERAL_SPECIFICATION", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@SH_ID", g_sp_id);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_boxes);
                cmd.ExecuteNonQuery();
                //SqlDataReader reader = cmd.ExecuteReader();
                //long myid = 0;
                //if (reader.Read())
                //{
                //    myid = long.Parse(reader["myidentity"].ToString());
                //}
                //reader.Close();
                myconnection.closeConnection();
                return g_sp_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIlE UPDATING BOTTEL FACE GENERAL INFO "+ex.ToString());
            }
            return 0;
        }


        // savequntities
        async Task<long> savenewfacequantity(long sp_id , SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_QUANTITY_OF_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_GENERAL_SPECIFICATION_BOTTEL_FACE_ID", sp_id);
                cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER", mydata.addition_permission_number);
                cmd.Parameters.AddWithValue("@SH_WORK_ORDER_NUMBER", mydata.work_order_number);
                cmd.Parameters.AddWithValue("@SH_ADDTION_DATE", mydata.addition_date);
                cmd.Parameters.AddWithValue("@SH_STOCK_ID", mydata.stock.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME", mydata.stock.SH_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", mydata.stock_man.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME",mydata.stock_man.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق");
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS", mydata.no_of_boxes);
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", mydata.no_items_per_box);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", mydata.total_no_items);
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

        async Task savenewfaceocntainers(long q_id , SH_BOTTEL_FACE_DATA mydata)
        {
            try
            {
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_ADD_NEW_CONTAINER_OF_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_QUANTITY_OF_BOTTEL_FACE_ID", q_id);
                cmd.Parameters.AddWithValue("@SH_CONTAINER_NAME", "صندوق" );
                cmd.Parameters.AddWithValue("@SH_NO_ITEMS_PER_CONTAINER", mydata.no_items_per_box);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", mydata.addition_date);
                cmd.Parameters.AddWithValue("@SH_NO_CONTAINERS" , mydata.no_of_boxes);
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
                    stocks.Add(new SH_SHAHEEN_STOCK() {
                        SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_STOCK_ADDRESS_GPS = reader["SH_STOCK_ADDRESS_GPS"].ToString(), SH_STOCK_ADDRESS_TEXT = reader["SH_STOCK_ADDRESS_TEXT"].ToString(), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() });
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
            Cursor.Current = Cursors.WaitCursor;
            await autogenerateadditionpermisionnumber();
            mold_panel.Visible = false;
            qlawooz_panel.Visible = false;
            printing_panel.Visible = false;
            panel1.Visible = false;    
            panel3.Visible = true;
            hand_type_combo_box.Enabled = false;
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
            stock_man_text_box.Text = mstockman.SH_EMPLOYEE_NAME;
            Cursor.Current = Cursors.Default;
        }

        private void printing_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void bottel_face_type_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (form_data.Count > 0)
            {
                DialogResult result = MessageBox.Show("هل انت متاكد من تغيير نوع الوش  \n  جميع البيانات النوع الحالى سوف يتم حذفها", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                if (result == DialogResult.OK)
                {
                    form_data.Clear();

                    await fillfacegridview();

                    if (bottel_face_type_combo_box.SelectedIndex == 0)
                    {
                        
                        mold_panel.Visible = true;
                        qlawooz_panel.Visible = false;
                        printing_panel.Visible = false;
                        panel1.Visible = false;
                        panel3.Visible = false;
                        face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    }
                    else if (bottel_face_type_combo_box.SelectedIndex == 1)
                    {
                        mold_panel.Visible = false;
                        qlawooz_panel.Visible = false;
                        printing_panel.Visible = true;
                        panel1.Visible = false;
                        panel3.Visible = false;
                        face_product_type = bottel_face_type_combo_box.SelectedIndex;

                    }
                    else if (bottel_face_type_combo_box.SelectedIndex == 2)
                    {
                        mold_panel.Visible = false;
                        panel1.Visible = false;
                        panel3.Visible = false;
                        printing_panel.Visible = false;
                        qlawooz_panel.Visible = true;
                        face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    }
                    else if (bottel_face_type_combo_box.SelectedIndex == 3)
                    {
                        panel1.Show();
                        panel1.Visible = true;
                        mold_panel.Visible = false;
                        qlawooz_panel.Visible = false;
                        printing_panel.Visible = false;
                        panel3.Visible = false;
                        face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    }
                    else if (bottel_face_type_combo_box.SelectedIndex == 4)
                    {
                        mold_panel.Visible = false;
                        qlawooz_panel.Visible = false;
                        printing_panel.Visible = false;
                        panel1.Visible = false;
                        panel3.Visible = false;
                        face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    bottel_face_type_combo_box.SelectedIndex = face_product_type;
                }
            }else
            {
                if (bottel_face_type_combo_box.SelectedIndex == 0)
                {
                    face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    mold_panel.Visible = true;
                    qlawooz_panel.Visible = false;
                    printing_panel.Visible = false;
                    panel1.Visible = false;

                    panel3.Visible = false;

                }
                else if (bottel_face_type_combo_box.SelectedIndex == 1)
                {
                    face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    mold_panel.Visible = false;
                    qlawooz_panel.Visible = false;
                    printing_panel.Visible = true;
                    panel1.Visible = false;

                    panel3.Visible = false;
                }
                else if (bottel_face_type_combo_box.SelectedIndex == 2)
                {
                    face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    mold_panel.Visible = false;
                    panel1.Visible = false;

                    panel3.Visible = false;
                    printing_panel.Visible = false;
                    qlawooz_panel.Visible = true;


                }
                else if (bottel_face_type_combo_box.SelectedIndex == 3)
                {
                    face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    panel1.Show();
                    panel1.Visible = true;
                    mold_panel.Visible = false;
                    qlawooz_panel.Visible = false;
                    printing_panel.Visible = false;

                    panel3.Visible = false;
                }
                else if (bottel_face_type_combo_box.SelectedIndex == 4)
                {
                    face_product_type = bottel_face_type_combo_box.SelectedIndex;
                    mold_panel.Visible = false;
                    qlawooz_panel.Visible = false;
                    printing_panel.Visible = false;
                    panel1.Visible = false;

                    panel3.Visible = false;
                }
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

            if (bottel_face_type_combo_box.SelectedIndex == 0)
            {
                if (string.IsNullOrWhiteSpace(mold_sizes_combo_box.Text))
                {
                    MessageBox.Show("إدخل مقاس الطبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }
                else if (!(falt_type_radio_btn.Checked || maslop_type_radio_btn.Checked))
                {
                    MessageBox.Show("الرجاء إختيار نوع الطبة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }else if (hand_or_not_combo_box.Checked)
                {
                    if (string.IsNullOrWhiteSpace(hand_type_combo_box.Text))
                    {
                        MessageBox.Show("الرجاء إختيار نوع اليد", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        cansave = false;
                    }
                }
            }
            else if (bottel_face_type_combo_box.SelectedIndex == 1)
            {
                if (string.IsNullOrWhiteSpace(printing_shape_type_combo_box.Text))
                {
                    MessageBox.Show("الرجاء إختيار شكل البويات", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }
            }
            else if (bottel_face_type_combo_box.SelectedIndex == 2)
            {
                if (string.IsNullOrWhiteSpace(Screw_size_combo_box.Text))
                {
                    MessageBox.Show("الرجاء إختيار مقاس القلاووظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }else if (string.IsNullOrWhiteSpace(Screw_usage_combo_box.Text))
                {
                    MessageBox.Show("الرجاء إختيار إستخدام القلاووظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }
            }
            else if (bottel_face_type_combo_box.SelectedIndex == 3)
            {
                if (string.IsNullOrWhiteSpace(aerosol_size_text_box.Text))
                {
                    MessageBox.Show("الرجاء إختيار مقاس وش الأيروسول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }else if (string.IsNullOrWhiteSpace(aerosol_type_text_box.Text))
                {
                    MessageBox.Show("الرجاء إختيار نوع الأيروسول", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    cansave = false;
                }
            }else
            {
                //error 
            }






            if (cansave)
            {

                if (bottel_face_type_combo_box.SelectedIndex==0)
                {
                    string mold_type = "";
                    long mold_type_id = 0;
                    if (falt_type_radio_btn.Checked)
                    {
                        mold_type_id = 0;
                        mold_type = falt_type_radio_btn.Text;

                    }else if (maslop_type_radio_btn.Checked)
                    {
                        mold_type_id = 1;
                        mold_type = maslop_type_radio_btn.Text;
                    }
                      long hand_or_not = 0;
                        if (hand_or_not_combo_box.Checked)
                        {
                            hand_or_not = 1;
                            
                            form_data.Add(new SH_BOTTEL_FACE_DATA() {  addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, no_of_boxes = long.Parse(no_of_boxes_text_box.Text), sizes = msizes[sizes_combo_box.SelectedIndex], no_items_per_box = long.Parse(no_items_per_box_text_box.Text), work_order_number = work_order_number_text_box.Text, total_no_items = long.Parse(total_no_of_items_text_box.Text), hand_or_not = hand_or_not, mold_type_id = mold_type_id, mold_type = mold_type, mold_size = sizes[mold_sizes_combo_box.SelectedIndex], hand_type = hand_types[hand_type_combo_box.SelectedIndex] , stock = stocks[stocks_combo_box.SelectedIndex] , stock_man = mstockman , bottle_face_type = general_types[bottel_face_type_combo_box.SelectedIndex]  });
                        }
                        else
                        {
                            hand_or_not = 0;
                            form_data.Add(new SH_BOTTEL_FACE_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, no_of_boxes = long.Parse(no_of_boxes_text_box.Text), sizes = msizes[sizes_combo_box.SelectedIndex], no_items_per_box = long.Parse(no_items_per_box_text_box.Text), work_order_number = work_order_number_text_box.Text, total_no_items = long.Parse(total_no_of_items_text_box.Text), hand_or_not = hand_or_not, mold_type_id = mold_type_id, mold_type = mold_type, mold_size = sizes[mold_sizes_combo_box.SelectedIndex], stock = stocks[stocks_combo_box.SelectedIndex], stock_man = mstockman, bottle_face_type = general_types[bottel_face_type_combo_box.SelectedIndex] });

                        }                
                }
                else if (bottel_face_type_combo_box.SelectedIndex == 1)
                {

                    form_data.Add(new SH_BOTTEL_FACE_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, no_of_boxes = long.Parse(no_of_boxes_text_box.Text), sizes = msizes[sizes_combo_box.SelectedIndex], no_items_per_box = long.Parse(no_items_per_box_text_box.Text), work_order_number = work_order_number_text_box.Text, total_no_items = long.Parse(total_no_of_items_text_box.Text) , printing_type = face_painting_types[printing_shape_type_combo_box.SelectedIndex], stock = stocks[stocks_combo_box.SelectedIndex], stock_man = mstockman, bottle_face_type = general_types[bottel_face_type_combo_box.SelectedIndex] });

                }
                else if (bottel_face_type_combo_box.SelectedIndex == 2)
                {
                    form_data.Add(new SH_BOTTEL_FACE_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, no_of_boxes = long.Parse(no_of_boxes_text_box.Text), sizes = msizes[sizes_combo_box.SelectedIndex], no_items_per_box = long.Parse(no_items_per_box_text_box.Text), work_order_number = work_order_number_text_box.Text, total_no_items = long.Parse(total_no_of_items_text_box.Text) , screw_size = screw_sizes[Screw_size_combo_box.SelectedIndex] , screw_usage = screw_usages[Screw_usage_combo_box.SelectedIndex], stock = stocks[stocks_combo_box.SelectedIndex], stock_man = mstockman, bottle_face_type = general_types[bottel_face_type_combo_box.SelectedIndex] });

                }
                else if (bottel_face_type_combo_box.SelectedIndex == 3)
                {
                    form_data.Add(new SH_BOTTEL_FACE_DATA() { addition_date = DateTime.Now, addition_permission_number = addition_permission_number_text_box.Text, no_of_boxes = long.Parse(no_of_boxes_text_box.Text), sizes = msizes[sizes_combo_box.SelectedIndex], no_items_per_box = long.Parse(no_items_per_box_text_box.Text), work_order_number = work_order_number_text_box.Text, total_no_items = long.Parse(total_no_of_items_text_box.Text) , aerosol_size = aerosol_sizes[aerosol_size_text_box.SelectedIndex] , aerosol_type = aerosol_types[aerosol_type_text_box.SelectedIndex], stock = stocks[stocks_combo_box.SelectedIndex], stock_man = mstockman, bottle_face_type = general_types[bottel_face_type_combo_box.SelectedIndex] });

                }else
                {
                    //error as any type will be added
                }
                fillfacegridview();
            }


        }




        async Task fillfacegridview()
        {
            try
            {
                form_data_grid_view.DataSource = typeof(DataTable);
                
            if (bottel_face_type_combo_box.SelectedIndex==0)
            {
                DataTable mytabel = new DataTable();
                mytabel.Columns.Add("م");
                mytabel.Columns.Add("رقم أمر الشغل");
                mytabel.Columns.Add("إسم المخزن");
                mytabel.Columns.Add("إسم امين المخزن");
                mytabel.Columns.Add("المقاس");
                mytabel.Columns.Add("مقاس الطبة");
                mytabel.Columns.Add("نوع الطبة");
                mytabel.Columns.Add(" اليد");
                mytabel.Columns.Add("الكمية بالصندوق");
                mytabel.Columns.Add("عدد الصناديق");
                mytabel.Columns.Add("إجمالى الكمية");
                if (form_data.Count>0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        string[] mydata = new string[11];
                        mydata[0] = (i+1).ToString();
                        mydata[1] = form_data[i].work_order_number;
                        mydata[2] = form_data[i].stock.SH_STOCK_NAME;
                        mydata[3] = form_data[i].stock_man.SH_EMPLOYEE_NAME;
                        mydata[4] = form_data[i].sizes.SH_SIZE_NAME;
                        mydata[5] = form_data[i].mold_size.SH_MOLD_SIZE_VALUE.ToString();
                        mydata[6] = form_data[i].mold_type;
                        if (form_data[i].hand_or_not==0)
                        {
                            mydata[7] = "لايوجد";
                        }else
                        {
                            mydata[7] = form_data[i].hand_type.SH_TYPE_NAME;
                        }
                        mydata[8] = form_data[i].no_items_per_box.ToString();
                        mydata[9] = form_data[i].no_of_boxes.ToString();
                        mydata[10] = form_data[i].total_no_items.ToString();
                        mytabel.Rows.Add(mydata);
                    }
                }

                form_data_grid_view.DataSource = mytabel;
            }
            else if (bottel_face_type_combo_box.SelectedIndex == 1)
            {
                DataTable mytabel = new DataTable();
                mytabel.Columns.Add("م");
                mytabel.Columns.Add("رقم أمر الشغل");
                mytabel.Columns.Add("إسم المخزن");
                mytabel.Columns.Add("إسم امين المخزن");
                mytabel.Columns.Add("المقاس");
                mytabel.Columns.Add("نوع وش البويات");
                mytabel.Columns.Add("الكمية بالصندوق");
                mytabel.Columns.Add("عدد الصناديق");
                mytabel.Columns.Add("إجمالى الكمية");
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        string[] mydata = new string[9];
                        mydata[0] = (i + 1).ToString();
                        mydata[1] = form_data[i].work_order_number;
                        mydata[2] = form_data[i].stock.SH_STOCK_NAME;
                        mydata[3] = form_data[i].stock_man.SH_EMPLOYEE_NAME;
                        mydata[4] = form_data[i].sizes.SH_SIZE_NAME;
                        mydata[5] = form_data[i].printing_type.SH_BOTTEL_FACE_PAINTINGS_TYPE_NAME;
                        mydata[6] = form_data[i].no_items_per_box.ToString();
                        mydata[7] = form_data[i].no_of_boxes.ToString();
                        mydata[8] = form_data[i].total_no_items.ToString();
                        mytabel.Rows.Add(mydata);
                    }
                }
                form_data_grid_view.DataSource = mytabel;
            }
            else if (bottel_face_type_combo_box.SelectedIndex == 2)
            {
                DataTable mytabel = new DataTable();
                mytabel.Columns.Add("م");
                mytabel.Columns.Add("رقم أمر الشغل");
                mytabel.Columns.Add("إسم المخزن");
                mytabel.Columns.Add("إسم امين المخزن");
                mytabel.Columns.Add("المقاس");
                mytabel.Columns.Add("مقاس وش القلاووظ");
                mytabel.Columns.Add("إستخدام وش القلاووظ");
                mytabel.Columns.Add("الكمية بالصندوق");
                mytabel.Columns.Add("عدد الصناديق");
                mytabel.Columns.Add("إجمالى الكمية");
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        string[] mydata = new string[10];
                        mydata[0] = (i + 1).ToString();
                        mydata[1] = form_data[i].work_order_number;
                        mydata[2] = form_data[i].stock.SH_STOCK_NAME;
                        mydata[3] = form_data[i].stock_man.SH_EMPLOYEE_NAME;
                        mydata[4] = form_data[i].sizes.SH_SIZE_NAME;
                        mydata[5] = form_data[i].screw_size.SH_SCREW_SIZE_VALUE.ToString();
                        mydata[6] = form_data[i].screw_usage.SH_SCREW_USAGE_NAME;
                        mydata[7] = form_data[i].no_items_per_box.ToString();
                        mydata[8] = form_data[i].no_of_boxes.ToString();
                        mydata[9] = form_data[i].total_no_items.ToString();
                        mytabel.Rows.Add(mydata);
                    }
                }
                form_data_grid_view.DataSource = mytabel;
            }
            else if (bottel_face_type_combo_box.SelectedIndex == 3)
            {
                DataTable mytabel = new DataTable();
                mytabel.Columns.Add("م");
                mytabel.Columns.Add("رقم أمر الشغل");
                mytabel.Columns.Add("إسم المخزن");
                mytabel.Columns.Add("إسم امين المخزن");
                mytabel.Columns.Add("المقاس");
                mytabel.Columns.Add("مقاس وش الأيروسول");
                mytabel.Columns.Add("نوع وش الأيروسول");
                mytabel.Columns.Add("الكمية بالصندوق");
                mytabel.Columns.Add("عدد الصناديق");
                mytabel.Columns.Add("إجمالى الكمية");
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        string[] mydata = new string[10];
                        mydata[0] = (i + 1).ToString();
                        mydata[1] = form_data[i].work_order_number;
                        mydata[2] = form_data[i].stock.SH_STOCK_NAME;
                        mydata[3] = form_data[i].stock_man.SH_EMPLOYEE_NAME;
                        mydata[4] = form_data[i].sizes.SH_SIZE_NAME;
                        mydata[5] = form_data[i].aerosol_size.SH_AEROSOL_SIZE_VALUE.ToString();
                        mydata[6] = form_data[i].aerosol_type.SH_AEROSOL_TYPE_NAME;
                        mydata[7] = form_data[i].no_items_per_box.ToString();
                        mydata[8] = form_data[i].no_of_boxes.ToString();
                        mydata[9] = form_data[i].total_no_items.ToString();
                        mytabel.Rows.Add(mydata);
                    }
                }
                form_data_grid_view.DataSource = mytabel;
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ فى تحميل البيانات"+ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (addnewfaceproduct myform = new addnewfaceproduct(mstockman, mAccount,mPermission))
            {
                myform.ShowDialog();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void save_easy_open_btn_Click(object sender, EventArgs e)
        {
            if (face_product_type == 0)
            {
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        long sp_id = await check_if_mold_bottel_face_exists_or_not(form_data[i]);
                        if (sp_id==0)
                        {
                            //sp_id = mol
                            savenewpermssionnumber();
                            sp_id =  await savemoldtypespecification(form_data[i]);
                            sp_id = await savenewgeneralspecification(sp_id, 0, 0, 0, 0, form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);
                        }
                        else
                        {
                            savenewpermssionnumber();
                            await updatemoldbottelfacesspecifications(sp_id , form_data[i]);
                            sp_id = await update_general_bottel_face_specification(sp_id , 0,0,0,0,form_data[i]);
                            long q_id = await savenewfacequantity(sp_id  , form_data[i]);
                            await savenewfaceocntainers(q_id , form_data[i]);
                        }
                    }
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات",  MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                    this.Hide();
                    using (addnewfaceproduct myform = new addnewfaceproduct(mstockman, mAccount, mPermission))
                    {
                        myform.ShowDialog();
                    }
                    this.Close();
                }
            }
            else if (face_product_type == 1)
            {
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {
                        
                        long sp_id = await check_if_priting_bottel_face_exists_or_not(form_data[i]);
                        if (sp_id == 0)
                        {
                            //sp_id = mol
                            sp_id = await savenewprintingbottelfacespecification(form_data[i]);
                            sp_id = await savenewgeneralspecification(0,sp_id ,0,0,0,form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);
                        }
                        else
                        {
                            await updateprintingbottelfacespecification(sp_id, form_data[i]);
                            sp_id = await update_general_bottel_face_specification(0, 0, 0, 0, sp_id, form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);
                        }
                    }
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            else if (face_product_type == 2)
            {
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {

                        long sp_id = await check_if_screw_specification_exists_or_not(form_data[i]);
                        if (sp_id == 0)
                        {
                            //sp_id = mol
                            sp_id = await savenewscrewbottelfacespecification(form_data[i]);
                            sp_id = await savenewgeneralspecification(0, 0, 0, sp_id, 0, form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);
                        }
                        else
                        {
                            await update_screw_bottel_face_specifications(sp_id, form_data[i]);
                            sp_id = await update_general_bottel_face_specification(0, 0, 0, sp_id, 0, form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);
                        }
                    }
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            else if (face_product_type == 3)
            {
                if (form_data.Count > 0)
                {
                    for (int i = 0; i < form_data.Count; i++)
                    {

                        long sp_id = await check_if_aerosol_specification_exists_or_not(form_data[i]);
                        if (sp_id == 0)
                        {
                            //sp_id = mol
                            sp_id = await savenewaerosolbottelfacespecifications(form_data[i]);
                            sp_id = await savenewgeneralspecification(0, 0, sp_id, 0, 0, form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);

                        }
                        else
                        {
                            await updateaersolbottlefacespecification(sp_id, form_data[i]);
                            sp_id = await update_general_bottel_face_specification(0, sp_id, 0, 0, 0, form_data[i]);
                            long q_id = await savenewfacequantity(sp_id, form_data[i]);
                            await savenewfaceocntainers(q_id, form_data[i]);
                        }
                    }
                    MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }

        private void hand_or_not_combo_box_CheckedChanged(object sender, EventArgs e)
        {
            if (hand_or_not_combo_box.Checked)
            {
                hand_type_combo_box.Enabled = true;
            } else
            {
                hand_type_combo_box.Enabled = false;
            }
        }
    }
}
