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
    public partial class searchinmuranparcels : Form
    {
        SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();

        List<SH_ITEM_SIZE> sizes = new List<SH_ITEM_SIZE>();
        List<SH_FACE_COLOR> faces = new List<SH_FACE_COLOR>();
     //   List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        List<SH_MURAN_MATERIAL_PARCEL> parcels = new List<SH_MURAN_MATERIAL_PARCEL>();
        List<SH_MURAN_MATERIAL_PARCEL> ex_parcels = new List<SH_MURAN_MATERIAL_PARCEL>();


        public searchinmuranparcels( SH_USER_ACCOUNTS anyAccount)
        {
            InitializeComponent();
            Maccount = anyAccount;
        }
        void loadallfacecolors()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_FACE_COLORS", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    faces.Add(new SH_FACE_COLOR() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING FACES " + ex.ToString());
            }
        }

        void fillfacescombobox()
        {

            faces.Clear();
            first_face_combo_box.Items.Clear();
            second_face_combo_box.Items.Clear();
            loadallfacecolors();
            if (faces.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < faces.Count; i++)
                {
                    first_face_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                    second_face_combo_box.Items.Add(faces[i].SH_FACE_COLOR_NAME);
                }
            }
        }

        //void loadclientsdata()
        //{
        //    try
        //    {
        //        string query = "SELECT * FROM SH_CLIENT_COMPANY";
        //        DatabaseConnection myconnection = new DatabaseConnection();
        //        myconnection.openConnection();
        //        SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString(), SH_CLIENT_COMPANY_TYPE = reader["SH_CLIENT_COMPANY_TYPE"].ToString(), SH_CLIENT_COMPANY_MOBILE = reader["SH_CLIENT_COMPANY_MOBILE"].ToString(), SH_CLIENT_COMPANY_TELEPHONE = reader["SH_CLIENT_COMPANY_TELEPHONE"].ToString() });
        //        }
        //        myconnection.closeConnection();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ERROR WHILE GETTING CLIENTS DATA FROM DB" + ex.ToString());
        //    }
        //}    
        void loadaallsizes()
        {
            sizes.Clear();
            try
            {
                string query = "SELECT * FROM SH_ITEM_SIZE";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    sizes.Add(new SH_ITEM_SIZE() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SIZE_FIRST_DIAMETER = double.Parse(reader["SH_SIZE_FIRST_DIAMETER"].ToString()), SH_SIZE_FIRST_DIAMETER_NAME = reader["SH_SIZE_FIRST_DIAMETER_NAME"].ToString(), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString(), SH_SIZE_SECOND_DIAMETER = double.Parse(reader["SH_SIZE_SECOND_DIAMETER"].ToString()), SH_SIZE_SECOND_DIAMETER_NAME = reader["SH_SIZE_SECOND_DIAMETER_NAME"].ToString(), SH_SIZE_SHAPE_NAME = reader["SH_SIZE_SHAPE_NAME"].ToString(), SH_SIZE_SURROUNDING = double.Parse(reader["SH_SIZE_SURROUNDING"].ToString()) });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE LOADING DB" + ex.ToString());
            }
        }
        void fillsizescombobox()
        {
            loadaallsizes();
            sizes_combo_box.Items.Clear();
            if (sizes.Count > 0)
            {
                string sectext = "";
                for (int i = 0; i < sizes.Count; i++)
                {
                    if (string.Compare(sizes[i].SH_SIZE_SECOND_DIAMETER_NAME, "D2") == 0)
                    {
                        sectext = " ";
                    }
                    else
                    {
                        sectext = sizes[i].SH_SIZE_SECOND_DIAMETER_NAME;
                    }
                    sizes_combo_box.Items.Add(sizes[i].SH_SIZE_NAME);
                }
            }
        }
        string getmurantype()
        {
            string murantype = null;
            if (body_radio_btn.Checked)
            {
                murantype = body_radio_btn.Text;
            }
            else if (bottom_radio_btn.Checked)
            {
                murantype = bottom_radio_btn.Text;
            }

            return murantype;
        }
        private void searchinmuranparcels_Load(object sender, EventArgs e)
        {
            fillfacescombobox();
            fillsizescombobox();
        }
        void fillmuranparcelsgridview()
        {
            muran_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    muran_parcels_grid_view.Rows.Add(new string[] { (i + 1).ToString(), parcels[i].SH_ID.ToString(), parcels[i].SH_ITEM_CODE, parcels[i].SH_CLIENT_NAME, parcels[i].SH_ITEM_FIRST_FACE, parcels[i].SH_ITEM_SECOND_FACE, parcels[i].SH_SIZE_NAME, parcels[i].SH_MURAN_TYPE, parcels[i].SH_ITEM_NUMBER_OF_SHEETS.ToString(), parcels[i].SH_ITEM_PARCEL_GROSS_WEIGHT.ToString() });
                }
            }
        }
        private void search_btn_Click(object sender, EventArgs e)
        {
            parcels.Clear();
            bool length = false;
            bool width = false;
            bool thickness = false;
            bool code = false;
            bool temper = false;
            bool coating = false;
            bool finish = false;
            bool no_sheets = false;
            bool type = false;
            bool first_face = false;
            bool second_face = false;
            bool _size = false;
            bool muran_type = false;

            string mlength = " ";
            string mwidth = " ";
            string mthickness = " ";
            string mcode = " ";
            string mtemper = " ";
            string mcoating = " ";
            string mfinish = " ";
            string mtype = " ";
            string mno_sheets = " ";
            string mfirst_face = " ";
            string msecond_face = " ";
            string msize = " ";
            string mmuran_type = " ";

            double testnumber = 0;
            long testnum = 0;

            if (string.IsNullOrEmpty(first_face_combo_box.Text))
            {
                first_face = false;
            } else
            {
                first_face = true;
                mfirst_face = " AND (smmp.SH_ITEM_FIRST_FACE LIKE N'%@SH_ITEM_FIRST_FACE' OR smmp.SH_ITEM_FIRST_FACE LIKE N'%@SH_ITEM_FIRST_FACE%' OR smmp.SH_ITEM_FIRST_FACE LIKE N'@SH_ITEM_FIRST_FACE%' ) ";
            }

            if (string.IsNullOrEmpty(second_face_combo_box.Text))
            {
                second_face = false;
            } else
            {
                second_face = false;
                msecond_face = " AND ( smmp.SH_ITEM_SECOND_FACE LIKE  N'%@SH_ITEM_SECOND_FACE' OR smmp.SH_ITEM_SECOND_FACE LIKE  N'%@SH_ITEM_SECOND_FACE%' OR smmp.SH_ITEM_SECOND_FACE LIKE  N'@SH_ITEM_SECOND_FACE%' )";
            }

            if (string.IsNullOrEmpty(item_length_text_box.Text))
            {
                length = false;
            }
            else
            {
                if (double.TryParse(item_length_text_box.Text, out testnumber))
                {
                    length = true;
                    mlength = " AND smmp.SH_ITEM_LENGTH = @SH_ITEM_LENGTH ";
                    MessageBox.Show("test1");
                }
                else
                {
                    length = false;
                }
            }

            if (string.IsNullOrEmpty(item_width_text_box.Text))
            {
                width = false;
            }
            else
            {
                if (double.TryParse(item_width_text_box.Text, out testnumber))
                {
                    width = true;
                    mwidth = " AND smmp.SH_ITEM_WIDTH = @SH_ITEM_WIDTH ";
                }
                else
                {
                    width = false;
                }
            }

            if (string.IsNullOrEmpty(item_thickness_text_box.Text))
            {
                thickness = false;
            }
            else
            {
                if (double.TryParse(item_thickness_text_box.Text, out testnumber))
                {
                    thickness = true;
                    mthickness = " AND smmp.SH_ITEM_THICKNESS = @SH_ITEM_THICKNESS ";
                }
                else
                {
                    thickness = false;
                }
            }

            if (string.IsNullOrEmpty(item_finish_text_box.Text))
            {
                finish = false;
            }
            else
            {
                finish = true;
                mfinish = " AND smmp.SH_ITEM_FINISH LIKE N'%@SH_ITEM_FINISH' OR smmp.SH_ITEM_FINISH LIKE N'%@SH_ITEM_FINISH%' OR smmp.SH_ITEM_FINISH LIKE N'@SH_ITEM_FINISH%' ";
            }

            if (string.IsNullOrEmpty(item_coating_text_box.Text))
            {
                coating = false;
            }
            else
            {
                coating = true;
                mcoating = " AND smmp.SH_ITEM_COATING LIKE N'%@SH_ITEM_COATING' OR smmp.SH_ITEM_COATING LIKE N'%@SH_ITEM_COATING%' OR smmp.SH_ITEM_COATING LIKE N'@SH_ITEM_COATING%'  ";
            }

            if (string.IsNullOrEmpty(item_code_text_box.Text))
            {
                code = false;
            }
            else
            {
                code = true;
                mcode = " AND smmp.SH_ITEM_CODE LIKE N'%@SH_ITEM_CODE' OR smmp.SH_ITEM_CODE LIKE N'%@SH_ITEM_CODE%'  OR smmp.SH_ITEM_CODE LIKE N'@SH_ITEM_CODE%'  ";
            }

            if (string.IsNullOrEmpty(item_no_sheets_text_box.Text))
            {
                no_sheets = false;
            }
            else
            {
                if (long.TryParse(item_no_sheets_text_box.Text, out testnum))
                {
                    no_sheets = true;
                    mno_sheets = "AND smmp.SH_ITEM_NUMBER_OF_SHEETS = @SH_ITEM_NUMBER_OF_SHEETS ";
                }
                else
                {
                    no_sheets = false;
                }
            }

            if (body_radio_btn.Checked)
            {
                muran_type = true;
                mmuran_type = " AND smmp.SH_MURAN_TYPE LIKE N'%@SH_MURAN_TYPE'  OR smmp.SH_MURAN_TYPE LIKE N'%@SH_MURAN_TYPE%' OR smmp.SH_MURAN_TYPE LIKE N'@SH_MURAN_TYPE%'";
            }
            else if (bottom_radio_btn.Checked)
            {
                muran_type = true;
                mmuran_type = " AND smmp.SH_MURAN_TYPE LIKE N'%@SH_MURAN_TYPE' OR smmp.SH_MURAN_TYPE LIKE N'%@SH_MURAN_TYPE%' OR smmp.SH_MURAN_TYPE LIKE N'@SH_MURAN_TYPE%'";
            }
            else
            {
                muran_type = false;
            }

            if (string.IsNullOrEmpty(sizes_combo_box.Text))
            {
                _size = false;
            }
            else
            {
                _size = true;
                msize = "AND smmp.SH_SIZE_NAME LIKE N'%@SH_SIZE_NAME' OR smmp.SH_SIZE_NAME LIKE N'%@SH_SIZE_NAME%' OR smmp.SH_SIZE_NAME LIKE N'@SH_SIZE_NAME%'  ";
            }
            if (string.IsNullOrEmpty(item_type_text_box.Text))
            {
                type = false;
            }
            else
            {
                type = true;
                mtype = "AND smmp.SH_ITEM_TYPE LIKE N'%@SH_ITEM_TYPE' OR smmp.SH_ITEM_TYPE LIKE N'%@SH_ITEM_TYPE%' OR smmp.SH_ITEM_TYPE LIKE N'@SH_ITEM_TYPE%' ";
            }
            try
            {

                 string query = "SELECT smmp.* FROM SH_MURAN_MATERIAL_PARCEL smmp WHERE ( 1 = 1) "+mlength+mwidth+mthickness+mcoating+mcode+mtemper+msize+mtype+msecond_face+mfinish+mfirst_face+mmuran_type+mno_sheets+" AND NOT EXiSTS (SELECT * FROM SH_EXCHAGED_MURAN_PARCELS semp WHERE semp.SH_MURAN_PARCEL_ID = smmp.SH_ID)";
               // string query = "SELECT * FROM SH_MURAN_MATERIAL_PARCEL ";

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
            //    MessageBox.Show(query);
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (length)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text));
                    MessageBox.Show("test1");
                }
                if (width)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", double.Parse(item_width_text_box.Text));
                }
                if (thickness)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", double.Parse(item_thickness_text_box.Text));
                }
                if (code)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_CODE", item_code_text_box.Text);
                }
                if (temper)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", item_temper_text_box.Text);
                }
                if (coating)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", item_coating_text_box.Text);
                }
                if (finish)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", item_finish_text_box.Text);
                }
                if (_size)
                {
                    cmd.Parameters.AddWithValue("@SH_SIZE_NAME", sizes_combo_box.Text);
                }
                if (type)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_type_text_box.Text);
                }
                if (first_face)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_FIRST_FACE",faces[first_face_combo_box.SelectedIndex].SH_FACE_COLOR_NAME);
                }
                if (second_face)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_SECOND_FACE", second_face_combo_box.Text);
                }
                if (muran_type)
                {
                    cmd.Parameters.AddWithValue("@SH_MURAN_TYPE", getmurantype());
                }
                if (no_sheets)
                {

                    cmd.Parameters.AddWithValue("@SH_ITEM_NUMBER_OF_SHEETS", long.Parse(item_no_sheets_text_box.Text));
                }

                SqlDataReader rd = cmd.ExecuteReader();
               
                while (rd.Read())
                {
                    
                    parcels.Add(new SH_MURAN_MATERIAL_PARCEL() { SH_BOTTLE_CAPACITY = rd["SH_BOTTLE_CAPACITY"].ToString() , SH_ITEM_CODE = rd["SH_ITEM_CODE"].ToString() , SH_BOTTLE_HEIGHT = double.Parse(rd["SH_BOTTLE_HEIGHT"].ToString()) , SH_CLIENT_NAME = rd["SH_CLIENT_NAME"].ToString() , SH_ID = long.Parse(rd["SH_ID"].ToString())  , SH_ITEM_LENGTH = double.Parse(rd["SH_ITEM_LENGTH"].ToString()), SH_ITEM_NUMBER_OF_SHEETS = long.Parse(rd["SH_ITEM_NUMBER_OF_SHEETS"].ToString()), SH_ITEM_FIRST_FACE = rd["SH_ITEM_FIRST_FACE"].ToString(), SH_ITEM_THICKNESS = double.Parse(rd["SH_ITEM_THICKNESS"].ToString()) , SH_ITEM_SECOND_FACE = rd["SH_ITEM_SECOND_FACE"].ToString() , SH_SIZE_ID = long.Parse(rd["SH_SIZE_ID"].ToString()) , SH_SIZE_NAME = rd["SH_SIZE_NAME"].ToString() , SH_MURAN_TYPE = rd["SH_MURAN_TYPE"].ToString() , SH_ITEM_PARCEL_GROSS_WEIGHT = double.Parse(rd["SH_ITEM_PACKAGE_GROSS_WEIGHT"].ToString())});
                }
                myconnection.closeConnection();
                fillmuranparcelsgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING MURAN PARCELS : "  + ex.ToString());
            }
        }

        private void exchange_btn_Click(object sender, EventArgs e)
        {
            ex_parcels.Clear();
            if (muran_parcels_grid_view.SelectedRows.Count > 0)
            {
                for (int i = 0; i < muran_parcels_grid_view.SelectedRows.Count; i++)
                {
                    ex_parcels.Add(parcels[muran_parcels_grid_view.SelectedRows[i].Index]);
                }

                Exchangeofmurantinbasicinfo myform = new Exchangeofmurantinbasicinfo(ex_parcels,Maccount);
               
                    myform.Show();
                
            }
            else
            {
                MessageBox.Show("لابد من تحديد الطرد المراد صرفه");
            }
        }
    }
}
