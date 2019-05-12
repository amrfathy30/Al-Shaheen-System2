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
    public partial class ProductDetailsForExchangeFrm : Form
    {
        SH_EMPLOYEES Memployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS acc = new SH_USER_ACCOUNTS();
        SH_EXCHANGE_REQUEST_FROM_SALES requet = new SH_EXCHANGE_REQUEST_FROM_SALES();
        public ProductDetailsForExchangeFrm(SH_EXCHANGE_REQUEST_FROM_SALES anyrequet, SH_USER_ACCOUNTS anyaccount,SH_EMPLOYEES anyEmp)
        {
            InitializeComponent();
            requet = anyrequet;
            acc = anyaccount;
            Memployee = anyEmp;
        }

        private void ProductDetailsForExchangeFrm_Load(object sender, EventArgs e)
        {
            labeQnty.Text = requet.SH_QUANTITIY_REQUIRED.ToString();
            labelClientName.Text =requet.SH_CLIENT_NAME;
            labelProductName.Text = requet.SH_PRODUCT_NAME;
            labelType.Text = requet.SH_PRODUCT_TYPE;
            if (requet.SH_PRODUCT_TYPE == "تويست")
            {
                paneltWIST.Visible = true;
            }
            if (requet.SH_PRODUCT_TYPE == "EOE"|| requet.SH_PRODUCT_TYPE == "Normal end")
            {
                panelEOE.Visible = true;
            }
            if (requet.SH_PRODUCT_TYPE == "RLT" || requet.SH_PRODUCT_TYPE =="بيل اوف" )
            {
                panelpeelRLT.Visible = true;

            }
            labelInSideMuranEOE .Text= requet.SH_NORMAL_END_INSIDE_MURAN;
            labelOutSideMuranEOE.Text = requet.SH_NORMAL_END_OUTSIDE_MURAN;
            labelMaterialEoE.Text = requet.SH_NORMAL_END_MATERIAL;
            labelOpenWayEOE.Text = requet.SH_NORMAL_END_OPENWAY;
            labelEOEDaimetr.Text = requet.SH_NORMAL_END_DAIMETR.ToString();
            labelPeelAndRLTDaimetr.Text = requet.SH_RLT_DAIMETR.ToString();
            labelTwistType.Text = requet.SH_TWIST_TYPE;
            labelTwistSize.Text = requet.SH_TWIST_SIZE.ToString();
            labelTwistColor.Text = requet.SH_TWIST_COLOR;
            
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void updateEOESpecification()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updateEOEQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();
         


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update Specification" + ex.ToString());
            }
        }
        void insertEOEQuantity()
        {
            



            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("ADDEOEQuntityExchanged", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", 1);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);
                cmd.Parameters.AddWithValue("@SH_DAIMETR", requet.SH_RLT_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_MATERIAL", requet.SH_NORMAL_END_MATERIAL);
                cmd.Parameters.AddWithValue("@SH_INSIDE_MURAN", requet.SH_NORMAL_END_INSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_OUTSIDE_MURAN", requet.SH_NORMAL_END_OUTSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_OPEN_WAY", requet.SH_NORMAL_END_OPENWAY);

                


                cmd.ExecuteNonQuery();
             



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in EOE Qunatity" + ex.ToString());
            }
        }
        void updateRltSpecification()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updateRltQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الصرف");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update Specification" + ex.ToString());
            }
        }
        void updatePeelOffSpecification()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updatePeelOffQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();
                MessageBox.Show("تم الصرف");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update Specification" + ex.ToString());
            }
        }

        void insertInRLTExchangeQntitity()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("ExchangeRLTBySupplyOrderWork", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", Memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);
                cmd.Parameters.AddWithValue("@SH_RLT_DAIMETR", requet.SH_RLT_DAIMETR);




                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in RLT Qunatity" + ex.ToString());
            }
        }
        void insertPeelOFFExchangeQntitity()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("ExchangePeelOFFBySupplyOrderWork", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);

                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);

                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", Memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME); 
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);
                cmd.Parameters.AddWithValue("@SH_PEELOFF_DAIMETR", requet.SH_RLT_DAIMETR);




                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in peelOff Qunatity" + ex.ToString());
            }

        }

        void insertTwistQuantityExchanged()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("ADDTWISTQuntityExchanged", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", Memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);
                cmd.Parameters.AddWithValue("@SH_TWIST_COLOR",requet.SH_TWIST_COLOR);
                cmd.Parameters.AddWithValue("@SH_TWIST_TYPE",requet.SH_TWIST_TYPE);
                cmd.Parameters.AddWithValue("@SH_TWIST_SIZE",requet.SH_TWIST_SIZE);
                
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in Twist Exchange Qunatity" + ex.ToString());
            }
        }
        void updateTwistSpecification()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updateTwistQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
              
                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_TEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();
            


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update Twist Specification" + ex.ToString());
            }
        }
        void updateState()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("update SH_EXCHANGE_REQUEST_FROM_SALES set SH_STATUS=1 where SH_ID=@id", DatabaseConnection.mConnection);

               
                cmd.Parameters.AddWithValue("@id", requet.SH_ID);

                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update status of requests from Sales" + ex.ToString());
            }


        }


        void insertPlasticCoverQuantityExchanged()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("add_PlasticCoverQuantityExchanged", DatabaseConnection.mConnection);
                cmd.CommandType =CommandType.StoredProcedure;


               
                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", Memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COLOR", requet.SH_PLASTIC_COVER_COLOR);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_DAIMETR", requet.SH_PLASTIC_COVER_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_HAS_AKLASHEH", requet.SH_PLASTIC_COVER_HAS_AKLASHEH);
           
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in PlasticCover Exchange Qunatity" + ex.ToString());
            }
        }

        void updatePlasticCoverSpecification()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updatePlasticCoverQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
             
                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update PlaticCover Specification" + ex.ToString());
            }
        }
        void insertNormalEndQuantity()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("ADDNormalEndQuntityExchanged", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", Memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);
                cmd.Parameters.AddWithValue("@SH_DAIMETR", requet.SH_RLT_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_MATERIAL", requet.SH_NORMAL_END_MATERIAL);
                cmd.Parameters.AddWithValue("@SH_INSIDE_MURAN", requet.SH_NORMAL_END_INSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_OUTSIDE_MURAN", requet.SH_NORMAL_END_OUTSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_OPEN_WAY", requet.SH_NORMAL_END_OPENWAY);




                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in EOE Qunatity" + ex.ToString());
            }
        }
        void updateNormalEndSpecification()
        {

            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updateNormalEndQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update NormalEnd Specification" + ex.ToString());
            }
        }



       void insertPlasticTabbaQuntityExchanged()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("add_PlasticMoldQuantityExchanged", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME", requet.SH_CLIENT_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", requet.SH_CLIENT_ID);
                cmd.Parameters.AddWithValue("@SH_QUNTITY_OF_CLIENT", requet.SH_QUANTITIY_REQUIRED);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_EXCHANGE", DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ORDER_SUPPLAY_WORK", requet.SH_ORDER_SUPPLY_WORK);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLAY_NUM", requet.SH_CLIENT_SUPPLY_ORDER_NUM);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_ID", Memployee.SH_ID);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", Memployee.SH_EMPLOYEE_NAME);
                cmd.Parameters.AddWithValue("@SH_SALES_RESPOSIBLE_NAME", requet.SH_DATA_ENTERED_BY);

                cmd.Parameters.AddWithValue("@SH_MOLD_TYPE",requet.SH_PLASTIC_MOLD_TYPE );
                cmd.Parameters.AddWithValue("@SH_MOLD_DAIMETR",requet.SH_PLASTIC_MOLD_DAIMETR );
                cmd.Parameters.AddWithValue("@SH_IMPORTED_OR_LOCAL",requet.SH_PLASTIC_MOLD_IMPORTEDOR_LOCAL );





                cmd.ExecuteNonQuery();




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in Plastic mold Qunatity" + ex.ToString());
            }
        }
        void updatePlasticTabbaSpecification()
        {
            try
            {

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("updatePlasticTabbaQntyspecific", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", requet.SH_PRODUCT_ID_SPECIFICATION);
                cmd.Parameters.AddWithValue("@SH_TOTAL_NO_ITEMS", requet.SH_QUANTITIY_REQUIRED);
                cmd.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in update Plastic Mold Specification" + ex.ToString());
            }
        }
        private void buttonExchange_Click(object sender, EventArgs e)
        {
            if (requet.SH_PRODUCT_TYPE == "RLT")
            {
                insertInRLTExchangeQntitity();
                updateState();
                updateRltSpecification();

                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }

           else  if (requet.SH_PRODUCT_TYPE == "بييل اوف")
            {
                insertPeelOFFExchangeQntitity();
                updateState();
                updatePeelOffSpecification();

                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }

            else if (requet.SH_PRODUCT_TYPE =="EOE")
            {
                insertEOEQuantity();
                updateEOESpecification();
                updateState();

                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }

            else if (requet.SH_PRODUCT_TYPE =="Normal end")
            {
             
               insertNormalEndQuantity();
               updateNormalEndSpecification();
               updateState();

                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }
            else  if (requet.SH_PRODUCT_TYPE == "تويست")
            {
                MessageBox.Show("TWIST");
                updateState();
                insertTwistQuantityExchanged();
                updateTwistSpecification();

                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }

            else if (requet.SH_PRODUCT_TYPE == "غطاء بلاستيك")
            {
              
                updateState();
                insertPlasticCoverQuantityExchanged();
                updatePlasticCoverSpecification();
                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }
            else if (requet.SH_PRODUCT_TYPE =="طبة")
            {
                insertPlasticTabbaQuntityExchanged();
                updatePlasticTabbaSpecification();
                updateState();
                MessageBox.Show("تم الصرف");
                buttonExchange.Enabled = false;
            }

            else
            {
                MessageBox.Show("لم يكتمل");
            }




        }
    }
}
