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
    public partial class exhangeofrawmaterilbyproperties : Form
    {
        List<SH_RAW_MATERIAL_PARCEL> resultparcels = new List<SH_RAW_MATERIAL_PARCEL>();
        public exhangeofrawmaterilbyproperties()
        {
            InitializeComponent();
        }

        private void search_properties_Click(object sender, EventArgs e)
        {
            double testnumber = 0;
            bool length = false;
            bool width = false ;
            bool thickness = false;
            bool temper = false;
            bool coating = false;
            bool code = false;
            bool finish = false;
            bool type = false;
            string mlength = "";
            string mwidth = "";
            string mthickness = "";
            string mtemper = "";
            string caoting = "";
            string mcode = "";
            string mfinish = "";
            string mtype = "";

            if (string.IsNullOrEmpty(item_length_text_box.Text))
            {
                mlength = "";
            }
            else if (double.TryParse(item_length_text_box.Text , out  testnumber))
            {
                length = true;
                mlength = " AND (srm.SH_ITEM_LENGTH = @SH_ITEM_LENGTH) ";
            }else
            {
                mlength = "";
            }

            if (string.IsNullOrEmpty(item_width_text_box.Text))
            {
                mwidth = "";
            }
            else if (double.TryParse(item_width_text_box.Text, out testnumber))
            {
                width = true;
                mwidth = " AND (srm.SH_ITEM_WIDTH = @SH_ITEM_WIDTH) ";
            }
            else
            {
                mwidth = "";
            }
            if (string.IsNullOrEmpty(item_thickness_text_box.Text))
            {
                mthickness = "";
            }
            else if (double.TryParse(item_thickness_text_box.Text, out testnumber))
            {
                thickness = true;
                mthickness = "AND (srm.SH_ITEM_THICKNESS = @SH_ITEM_THICKNESS)";
            }
            else
            {
                mthickness = "";
            }


            if (string.IsNullOrEmpty(item_temper_text_box.Text))
            {
                mtemper = "";
            }
            else
            {
                temper = true;
                    
                mtemper = " AND (srm.SH_ITEM_TEMPER LIKE N'%@SH_ITEM_TEMPER' || srm.SH_ITEM_TEMPER LIKE N'%@SH_ITEM_TEMPER%' || srm.SH_ITEM_TEMPER LIKE N'@SH_ITEM_TEMPER%' )";
            }

            if (string.IsNullOrEmpty(item_code_text_box.Text))
            {
                mcode = "";
            }
            else
            {
                code = true;
                mcode = " AND (srm.SH_ITEM_CODE  LIKE N'%@SH_ITEM_CODE' ||srm.SH_ITEM_CODE  LIKE N'%@SH_ITEM_CODE%' || srm.SH_ITEM_CODE  LIKE N'@SH_ITEM_CODE%' )";
            }

            if (string.IsNullOrEmpty(item_finish_text_box.Text))
            {

                mfinish = "";
            }
            else
            {
                finish = true;
                mfinish = "AND (srm.SH_ITEM_FINISH LIKE N'%@SH_ITEM_FINISH' ||srm.SH_ITEM_FINISH LIKE N'%@SH_ITEM_FINISH%' ||srm.SH_ITEM_FINISH LIKE N'@SH_ITEM_FINISH%')";
            }

            if (string.IsNullOrEmpty(item_type_text_box.Text))
            {
                mtype = "";
            }else
            {
                type = true;
                mtype = "AND (srm.SH_ITEM_TYPE LIKE N'%@SH_ITEM_TYPE' || srm.SH_ITEM_TYPE LIKE N'%@SH_ITEM_TYPE%' || srm.SH_ITEM_TYPE LIKE N'@SH_ITEM_TYPE%'   )";
            }


            try
            {
                string query = "SELECT * FROM SH_RAW_MATERIAL_PARCEL srm WHERE ( TRUE "+mlength+mwidth+mthickness+mcode+mfinish+mtemper+mtype+"     ) AND NOT EXISTS (SELECT * FROM SH_MINUTES_PACKAGES_EXAMINED_RAW_MATERIAL mperm where  mperm.SH_ITEM_PRACEL_ID = srm.SH_ID) ";

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                if (length)
                {
                    cmd.Parameters.AddWithValue(""  , "");
                } 


                myconnection.closeConnection();
            }
            catch (Exception)
            {

                throw;
            }









        }

        private void printering_radio_btn_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void production_radio_btn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
