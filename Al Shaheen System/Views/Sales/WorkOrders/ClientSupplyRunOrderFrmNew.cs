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
    public partial class ClientSupplyRunOrderFrmNew : Form
    {
        List<SH_CLIENTS_PRODUCTS> mproduct = new List<SH_CLIENTS_PRODUCTS>();
        List<SH_ITEMS> ItemList = new List<SH_ITEMS>();
        List<SH_CLIENTS_BRANCHES> branchList = new List<SH_CLIENTS_BRANCHES>();
        long id;
        List<SH_CLIENT_COMPANY> clients = new List<SH_CLIENT_COMPANY>();
        CLIENT_ORDER_WORK cw = new CLIENT_ORDER_WORK();
        List<CLIENT_ORDER_WORK> cwList = new List<CLIENT_ORDER_WORK>();
        List<SH_FACE_COLOR> faceList = new List<SH_FACE_COLOR>();
        List<SH_CLIENTS_BRANCHES> mclientBranches = new List<SH_CLIENTS_BRANCHES>();
        public ClientSupplyRunOrderFrmNew()
        {
            InitializeComponent();
        }

        void loadNewId()
        {
            try  //complete it after dataBase Creation
            {
                string query = "select top 1 * from CLIENT_ORDER_WORK  order by SH_ID desc";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cwList.Add(new CLIENT_ORDER_WORK { SH_ID = long.Parse(reader["SH_ID"].ToString()) });
                }
                for (int i = 0; i < cwList.Count; i++)
                {
                    long newId = cwList[i].SH_ID + 1;
                    textBoxOrderWorkClient.Text = "SH" + newId.ToString();
                }
               
              
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE ID FROM DB " + ex.ToString());
            }
        }
        void loadallClients()
        {
            try
            {
                string query = "SELECT * FROM SH_CLIENT_COMPANY";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clients.Add(new SH_CLIENT_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING clients DATA FROM DB " + ex.ToString());
            }
        }

        void fillClientscombobox()
        {
            clients.Clear();
            loadallClients();
            comboBoxClients.Items.Clear();
            if (clients.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    comboBoxClients.Items.Add(clients[i].SH_CLIENT_COMPANY_NAME);
                }
            }
        }

        void loadallFaces()
        {
            try
            {
                string query = "SELECT * FROM SH_FACE_COLORS";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    faceList.Add(new SH_FACE_COLOR { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_FACE_COLOR_NAME = reader["SH_FACE_COLOR_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING faces DATA FROM DB " + ex.ToString());
            }
        }

        void fillFaces()
        {
            faceList.Clear();
            loadallFaces();
            comboBoxInsideMuran.Items.Clear();
            comboBoxOutSideMuran.Items.Clear();
            if (faceList.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < faceList.Count; i++)
                {
                    comboBoxInsideMuran.Items.Add(faceList[i].SH_FACE_COLOR_NAME);
                    comboBoxOutSideMuran.Items.Add(faceList[i].SH_FACE_COLOR_NAME);
                }
            }
        }


        void loadComboBranches()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("select * from SH_CLIENTS_BRANCHES where SH_CLIENT_ID=@id", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@id", clients[comboBoxClients.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    branchList.Add(new SH_CLIENTS_BRANCHES { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(), SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SUPLLIERS items DATA" + ex.ToString());
            }
        }

        void fillComboBranches()
        {
            branchList.Clear();
            comboBoxClientsBranches.Items.Clear();
            loadComboBranches();
            if (branchList.Count > 0)
            {
                for (int i = 0; i < branchList.Count; i++)
                {
                    comboBoxClientsBranches.Items.Add(branchList[i].SH_CLIENT_BRANCH_ADDRESS_TEXT);

                }
            }
        }


        void getallclientproducts()
        {

            try
            {
                string query = "SELECT SH_CLIENTS_PRODUCTS.* FROM SH_CLIENTS_PRODUCTS ";
                query += " WHERE(SH_CLIENT_ID = @client_id)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@client_id", clients[comboBoxClients.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mproduct.Add(new SH_CLIENTS_PRODUCTS() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SECOND_FACE_ID = long.Parse(reader["SH_SECOND_FACE_ID"].ToString()), SH_SECOND_FACE_NAME = reader["SH_SECOND_FACE_NAME"].ToString(), SH_BOTTLE_CAPACITY = double.Parse(reader["SH_BOTTLE_CAPACITY"].ToString()), SH_BOTTLE_HEIGHT = double.Parse(reader["SH_BOTTLE_HEIGHT"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_PRINTING_TYPE = reader["SH_PRINTING_TYPE"].ToString(), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_SIZE_ID = long.Parse(reader["SH_SIZE_ID"].ToString()), SH_SIZE_NAME = reader["SH_SIZE_NAME"].ToString() });
                }
           

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT PRODUCTS " + ex.ToString());
            }
        }

        void fillClientProducts()
        {
            mproduct.Clear();
            comboBoxProducts.Items.Clear();
            getallclientproducts();
            for (int i = 0; i < mproduct.Count; i++)
            {
                comboBoxProducts.Items.Add(mproduct[i].SH_PRODUCT_NAME);
            }

        }




        void loadclientbranchesCombo()
        {

            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_CLIENTS_BRANCHES WHERE SH_CLIENT_ID = @SH_CLIENT_ID", DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[comboBoxClients.SelectedIndex].SH_ID);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mclientBranches.Add(new SH_CLIENTS_BRANCHES() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_BRANCH_ADDRESS_GPS_LINK = reader["SH_CLIENT_BRANCH_ADDRESS_GPS_LINK"].ToString(), SH_CLIENT_BRANCH_ADDRESS_TEXT = reader["SH_CLIENT_BRANCH_ADDRESS_TEXT"].ToString(), SH_CLIENT_BRANCH_NAME = reader["SH_CLIENT_BRANCH_NAME"].ToString(), SH_CLIENT_BRANCH_TYPE = reader["SH_CLIENT_BRANCH_TYPE"].ToString(), SH_CLIENT_COMPANY_NAME = reader["SH_CLIENT_COMPANY_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT BRANCH FROM DB " + ex.ToString());
            }



        }


        void fillBranchesCombo()
        {


            comboBoxClientsBranches.Items.Clear();
            mclientBranches.Clear();
            loadclientbranchesCombo();
            for (int i = 0; i < mclientBranches.Count; i++)
            {
                comboBoxClientsBranches.Items.Add(mclientBranches[i].SH_CLIENT_BRANCH_ADDRESS_TEXT);
            }



        }
        private void ClientSupplyRunOrderFrmNew_Load(object sender, EventArgs e)
        {
            fillClientscombobox();
            textBoxDateNow.Text = DateTime.Now.ToString();
            fillFaces();
            loadNewId();
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClientSupplyRunOrderFrmNew frm = new ClientSupplyRunOrderFrmNew();
            frm.ShowDialog();
        }

        private void textBoxWhenDelivered_TextChanged(object sender, EventArgs e)
        {
        
            calcualtettotalPriceNew();
        }
        void addOrderWorkClient()
        {
            if (checkBoxHasMold.Checked&& comboBoxItemType.SelectedIndex == 0 && radioButton3Pecies.Checked)
            {//علبه
                cw.SH_DIAMETR_TAPPA = long.Parse(comboBoxCanTabaDaimetr.Text);
                cw.SH_TABA_COLOR = comboBoxCanTabaColor.Text;
                cw.SH_TABA_TYPE = comboBoxCanTabaType.Text;
                cw.SH_NUMBER_OF_PEICES = 3;
            }
            if (comboBoxItemType.SelectedIndex == 0)
            {
                cw.SH_NUMBER_OF_COLORS_OF_CAN =long.Parse( comboBoxNumberOfColors.Text);
                if (checkBoxThick.Checked)
                {
                    cw.SH_THICKNESS_INCREASE_DECREASE_01 = 1;
                }else
                {
                    cw.SH_THICKNESS_INCREASE_DECREASE_01 = 0;
                }

                

            }

            if(comboBoxItemType.SelectedIndex == 0 && radioButtonRLTCover.Checked)
            {
                cw.SH_RLT_DAIAMETR =long.Parse( comboBoxRLTDaimetr.Text);
            }
            if (comboBoxItemType.SelectedIndex == 0 && radioButtonPeelOffCover.Checked)
            {
                cw.SH_PEELOFF_DAIMETR = long.Parse(comboBoxPeelOffDaimetr.Text);
            }

            if (comboBoxItemType.SelectedIndex==1)
            {//EOE
                cw.SH_EASY_OPEN_MATERIAL = comboBoxEOEMaterial.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(comboBoxDiametrEoE.Text);
                cw.SH_INSIDE_MURAN = comboBoxInsideMuran.Text;
                cw.SH_OUTSIDE_MURAN = comboBoxOutSideMuran.Text;
                cw.SH_OPEN_WAY = comboBoxOpenType.Text;


            }

            if (comboBoxItemType.SelectedIndex == 4)
            {//RLT
                cw.SH_RLT_DAIAMETR = long.Parse(comboBoxRLTDaimetr.Text);


            }
            if (comboBoxItemType.SelectedIndex ==5)
            {//غطاء ايزي اوبن لوحده بدون علبة
                cw.SH_EASY_OPEN_MATERIAL = comboBoxEOEMaterial.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(comboBoxDiametrEoE.Text);
                cw.SH_INSIDE_MURAN = comboBoxInsideMuran.Text;
                cw.SH_OUTSIDE_MURAN = comboBoxOutSideMuran.Text;
                cw.SH_OPEN_WAY = comboBoxOpenType.Text;


            }


            if (comboBoxItemType.SelectedIndex ==0&&(radioButtonEasyOpen.Checked|| radioButtonNormalEOE.Checked))
            { //غطاء ايزي اوبن للعلبة
                cw.SH_EASY_OPEN_MATERIAL = comboBoxEOEMaterial.Text;
                cw.SH_EASY_OPEN_DAIAMETR = long.Parse(comboBoxDiametrEoE.Text);
                cw.SH_INSIDE_MURAN = comboBoxInsideMuran.Text;
                cw.SH_OUTSIDE_MURAN = comboBoxOutSideMuran.Text;
                cw.SH_OPEN_WAY = comboBoxOpenType.Text;
            }
            if (comboBoxItemType.SelectedIndex == 7)
            {
                //طبه بلاستيك
                cw.SH_PLASTIC_TABA_DAIMETR = long.Parse(comboBoxPlasticTabaDaimetr.Text);
                cw.SH_PLASTIC_TABA_TYPE = comboBoxPlasticTabaType.Text;
            }


           
            if (comboBoxItemType.SelectedIndex ==6)
            {//غطاء
                cw.SH_PLASTIC_COVER_COLOR_ONLY = comboBoxCoverColor.Text;
                    cw.SH_PLASTIC_COVER_COVER_DAIMETR_ONLY = long.Parse(comboBoxDaimetrCover.Text);
                    
            }
            if (checkBoxHasAklasheh.Checked)
            {
                cw.SH_PLASTIC_COVER_HAS_AKLASHEH =1;
            }
            if (checkBoxHasAklasheh.Checked==false)
            {
                cw.SH_PLASTIC_COVER_HAS_AKLASHEH = 0;
            }
          
            

            if (comboBoxItemType.SelectedIndex == 2)
            {
               
                //تويست
                cw.SH_TWIST_SIZE =long.Parse( comboBoxTwistSize.Text);
                cw.SH_TWIST_TYPE = comboBoxTwistTypes.Text;
               cw.SH_TWIST_COLOR = comboBoxTwistColor.Text;
            }
            if (comboBoxPaymentWay1.SelectedIndex == 1)
            {
                cw.SH_DATE_OF_THE_CKECK_SUBMITTED =( dateTimePickerChek1.Text);
            }
            if (comboBoxPaymentWay2.SelectedIndex == 1)
            {
                cw.SH_DATE_OF_THE_CKECK_WHEN_DELIVERD =(dateTimePickerChek2.Text);
            }
            if (comboBoxPaymentWay3.SelectedIndex == 1)
            {
                cw.SH_DATE_OF_THE_CKECK_AFTER_RECIVING = (dateTimePickerChek3.Text);
            }
            if(radioButtonweld.Checked)
            {
                cw.SH_LEHAM = 1;

            }
            if (radioButtonAutomaticWeld.Checked)
            {
                cw.SH_LEHAM_AUTOMATIC = 1;
            }
            if (radioButtonManualWeld.Checked)
            {
                cw.SH_LEHAM_MANUAL= 1;
            }
            if (checkBoxOutMuran.Checked)
            {
                cw.SH_HAS_MURAN = 1;
            }
            if (radioButtonPowder.Checked)
            {
                cw.SH_HAS_POWDER = 1;
                cw.SH_POWER_COLOR = comboBoxPowderColor.Text;
            }
            if (checkBoxHasNeck.Checked)
            {
                cw.SH_HAS_NECK = 1;

            }
            if (checkBoxHasNeck.Checked==false)
            {
                cw.SH_HAS_NECK = 0;

            }
            if (radioButtonPeding.Checked)
            {
                cw.SH_HAS_PINDING = 1;
            }
            if (radioButtonNoPeding.Checked)
            {
                cw.SH_HAS_PINDING = 0;
            }
            if (radioButtonInsidBead.Checked)
            {
                cw.SH_INSIDE_BEAD = 1;
            }
            if (radioButtonOutSideBead.Checked)
            {
                cw.SH_OUT_BEAD = 1;
            }
            if (radioButtonTafleeg.Checked)
            {
                cw.SH_TAFLEEG = 1;

            }
            if (radioButtonInsidePuls.Checked)
            {
                cw.SH_INSIDE_PULS = 1;
            }
            if (radioButtonOutPuls.Checked)
            {
                cw.SH_OUTSIDE_PULS = 1;
            }
            if (radioButtonHaveCover.Checked)
            {
                cw.SH_HAS_CAN_COVER = 1;
            }
            if (radioButtonHaveCover.Checked==false)
            {
                cw.SH_HAS_CAN_COVER = 0;
            }
            if (radioButtonEasyOpen.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "EOE";
            }

            if (radioButtonTinCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "غطاء صفيح";
            }
            if (radioButtonNormalEOE.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "قاع";
            }


            if (radioButtonRLTCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "RLT";
            }
            if (radioButtonPeelOffCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "بيل اوف";
            }
            if (radioButtonFaceCover.Checked)
            {
                cw.SH_CAN_COVER_TYPE = "وش";
            }

            if (checkBoxHavePlasticCover.Checked)
            {
                cw.SH_HAS_PLASTIC_COVER_CAN = 1;
                cw.SH_PLASTIC_COVER_COLOR_CAN = comboBoxPlasticCoverColor.Text;
            }
            if (checkBoxPlasticCoverLogo.Checked)
            {
                cw.SH_HAS_PLASTIC_COVER_LOGO_CAN = 1;

            }
            if (checkBoxPlasticCoverLogo.Checked==false)
            {
                cw.SH_HAS_PLASTIC_COVER_LOGO_CAN = 0;

            }
            if (radioButtonFaceCover.Checked)
            {
                cw.SH_FACE_TYPE = comboBoxFaceType.Text;
            }
            if (comboBoxFaceType.SelectedIndex ==0)
            {
                cw.SH_BOYATE_FACE_TYPE = comboBoxBoyatFace.Text;
            }
            if (comboBoxFaceType.SelectedIndex == 1)
            {
                cw.SH_FACE_DAIMETR =long.Parse( comboBoxTabaDaiametr.Text);
            }
            if (radioButtonToTheClient.Checked)
            {
                cw.SH_DELIVERING_ADDRESS = comboBoxClientsBranches.Text;
            }
            if (radioButtonFromShaheen.Checked)
            {
                cw.SH_DELIVERING_ADDRESS = comboBoxourFactory.Text;
            }
            if (radioButtonLocal.Checked)
            {
                cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "محلى";
            }
            if (radioButtonImported.Checked)
            {
                cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "مستورد";
            }
            if (comboBoxItemType.SelectedIndex == 3)
            {
                cw.SH_PEELOFF_DAIMETR =long.Parse( comboBoxPeelOffDaimetr.Text);
            }
            if (comboBoxPaymentWay3.SelectedIndex==0)
            {
                cw.SH_DURATION_AFTER_RECIVING = comboBoxAfterReciving.Text;
            }
         
            try
                {
                
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
    
                SqlCommand cmd = new SqlCommand("addClientOrderWork", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SH_ID_STRING", textBoxOrderWorkClient.Text);

                cmd.Parameters.AddWithValue("@SH_CLIENT_NAME",clients[comboBoxClients.SelectedIndex].SH_CLIENT_COMPANY_NAME);
                cmd.Parameters.AddWithValue("@SH_CLIENT_ID", clients[comboBoxClients.SelectedIndex].SH_ID);
                cmd.Parameters.AddWithValue("@SH_TODAY_DATE",DateTime.Now);
                cmd.Parameters.AddWithValue("@SH_CLIENT_SUPPLY_ORDER_NUM", textBoxClientSuppNum.Text);
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME",mproduct[comboBoxProducts.SelectedIndex].SH_PRODUCT_NAME);
              
                     cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", comboBoxItemType.Text);
                cmd.Parameters.AddWithValue("@SH_QUANTITY",double.Parse(textBoxItemQnty.Text));
                cmd.Parameters.AddWithValue("@SH_UNIT_PRICE", double.Parse(textBoxItemPrice.Text));
                cmd.Parameters.AddWithValue("@SH_TOTAL_PRICE", double.Parse(textBoxTotalPrice.Text));
                cmd.Parameters.AddWithValue("@SH_CURRENCY_NAME",comboBoxCurrency.Text);
                cmd.Parameters.AddWithValue("@SH_TAX1", double.Parse(textBoxTax1.Text));
                cmd.Parameters.AddWithValue("@SH_TAX14", double.Parse(textBoxTax14.Text));
                cmd.Parameters.AddWithValue("@SH_TOTAL_COST_AFTER_TAXES", double.Parse(textBoxTotatalWithTax.Text));
                cmd.Parameters.AddWithValue("@SH_START_SUPPLY_DATE", DateTime.Parse(dateTimePickerStart.Text));
                cmd.Parameters.AddWithValue("@SH_END_SUPPLY_DATE", DateTime.Parse(dateTimePickerEnd.Text));
                cmd.Parameters.AddWithValue("@SH_NOWLON", comboBoxNolon.Text);


                cmd.Parameters.AddWithValue("@SH_DELIVERING_ADDRESS",cw.SH_DELIVERING_ADDRESS);
                cmd.Parameters.AddWithValue("@SH_SUBMITTED_MONEY", double.Parse(textBoxSubmitted.Text));
                cmd.Parameters.AddWithValue("@SH_PAYMENT_WAY_SUBMITTED", comboBoxPaymentWay1.Text);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_THE_CKECK_SUBMITTED", cw.SH_DATE_OF_THE_CKECK_SUBMITTED);
                cmd.Parameters.AddWithValue("@SH_MONEY_PAID_WHEN_DELIVERING", double.Parse(textBoxWhenDelivered.Text));

                cmd.Parameters.AddWithValue("@SH_PAYMENT_WAY_WHEN_DELIVERING", comboBoxPaymentWay2.Text);
                cmd.Parameters.AddWithValue("@SH_DATE_OF_THE_CKECK_WHEN_DELIVERD", cw.SH_DATE_OF_THE_CKECK_WHEN_DELIVERD);
                cmd.Parameters.AddWithValue("@SH_MONEY_AFTER_RECIVING", double.Parse(textBoxRemaining.Text));
                cmd.Parameters.AddWithValue("@SH_PAYMENT_WAY_AFTER_RECIVING", comboBoxPaymentWay3.Text);
                
                cmd.Parameters.AddWithValue("@SH_DATE_OF_THE_CKECK_AFTER_RECIVING", cw.SH_DATE_OF_THE_CKECK_AFTER_RECIVING);
                cmd.Parameters.AddWithValue("@SH_DURATION_AFTER_RECIVING",cw.SH_DURATION_AFTER_RECIVING);
                cmd.Parameters.AddWithValue("@SH_LEHAM", cw.SH_LEHAM);
                cmd.Parameters.AddWithValue("@SH_LEHAM_AUTOMATIC", cw.SH_LEHAM_AUTOMATIC);
                cmd.Parameters.AddWithValue("@SH_LEHAM_MANUAL", cw.SH_LEHAM_MANUAL);
                cmd.Parameters.AddWithValue("@SH_HAS_NECK", cw.SH_HAS_NECK);
                cmd.Parameters.AddWithValue("@SH_HAS_POWDER", cw.SH_HAS_POWDER);
                cmd.Parameters.AddWithValue("@SH_POWER_COLOR", cw.SH_POWER_COLOR);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_PEICES",cw.SH_NUMBER_OF_PEICES);
                cmd.Parameters.AddWithValue("@SH_THICKNESS_INCREASE_DECREASE_01",cw.SH_THICKNESS_INCREASE_DECREASE_01);
                cmd.Parameters.AddWithValue("@SH_NUMBER_OF_COLORS_OF_CAN",cw.SH_NUMBER_OF_COLORS_OF_CAN);



                cmd.Parameters.AddWithValue("@SH_HAS_MURAN", cw.SH_HAS_MURAN);
                cmd.Parameters.AddWithValue("@SH_HAS_PINDING", cw.SH_HAS_PINDING);
                cmd.Parameters.AddWithValue("@SH_INSIDE_BEAD", cw.SH_INSIDE_BEAD);
                cmd.Parameters.AddWithValue("@SH_OUT_BEAD", cw.SH_OUT_BEAD);
                cmd.Parameters.AddWithValue("@SH_TAFLEEG", cw.SH_TAFLEEG);
                cmd.Parameters.AddWithValue("@SH_INSIDE_PULS", cw.SH_INSIDE_PULS);

                cmd.Parameters.AddWithValue("@SH_OUTSIDE_PULS", cw.SH_OUTSIDE_PULS);
                cmd.Parameters.AddWithValue("@SH_HAS_CAN_COVER", cw.SH_HAS_CAN_COVER);
                cmd.Parameters.AddWithValue("@SH_CAN_COVER_TYPE", cw.SH_CAN_COVER_TYPE);

                cmd.Parameters.AddWithValue("@SH_DIAMETR_TAPPA", cw.SH_DIAMETR_TAPPA); 
                cmd.Parameters.AddWithValue("@SH_TABA_TYPE", cw.SH_TABA_TYPE);
                cmd.Parameters.AddWithValue("@SH_TABA_COLOR", cw.SH_TABA_COLOR);

                cmd.Parameters.AddWithValue("@SH_HAS_PLASTIC_COVER_CAN",cw.SH_HAS_PLASTIC_COVER_CAN);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COLOR_CAN",cw.SH_PLASTIC_COVER_COLOR_CAN);
                cmd.Parameters.AddWithValue("@SH_HAS_PLASTIC_COVER_LOGO_CAN",cw.SH_HAS_PLASTIC_COVER_LOGO_CAN);
                cmd.Parameters.AddWithValue("@SH_INSIDE_MURAN", cw.SH_INSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_OUTSIDE_MURAN", cw.SH_OUTSIDE_MURAN);
                cmd.Parameters.AddWithValue("@SH_EASY_OPEN_MATERIAL", cw.SH_EASY_OPEN_MATERIAL);
                cmd.Parameters.AddWithValue("@SH_OPEN_WAY", cw.SH_OPEN_WAY);

                cmd.Parameters.AddWithValue("@SH_EASY_OPEN_DAIAMETR", cw.SH_EASY_OPEN_DAIAMETR);
                cmd.Parameters.AddWithValue("@SH_RLT_DAIAMETR",cw.SH_RLT_DAIAMETR);
                cmd.Parameters.AddWithValue("@SH_TWIST_TYPE", cw.SH_TWIST_TYPE);
                cmd.Parameters.AddWithValue("@SH_TWIST_SIZE", cw.SH_TWIST_SIZE);
                cmd.Parameters.AddWithValue("@SH_TWIST_DEEP_NORMAL_MEDIUM", cw.SH_TWIST_DEEP_NORMAL_MEDIUM);
                cmd.Parameters.AddWithValue("@SH_TWIST_COLOR",cw.SH_TWIST_COLOR);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COLOR_ONLY",cw.SH_PLASTIC_COVER_COLOR_ONLY);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_COVER_DAIMETR_ONLY",cw.SH_PLASTIC_COVER_COVER_DAIMETR_ONLY);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_COVER_HAS_AKLASHEH",cw.SH_PLASTIC_COVER_HAS_AKLASHEH);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_TABA_TYPE", cw.SH_PLASTIC_TABA_TYPE);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_TABA_DAIMETR", cw.SH_PLASTIC_TABA_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_PLASTIC_TABA_LOCAL_OR_IMPORTED", cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED);
                cmd.Parameters.AddWithValue("@SH_FACE_TYPE", cw.SH_FACE_TYPE);
                cmd.Parameters.AddWithValue("@SH_BOYATE_FACE_TYPE", cw.SH_BOYATE_FACE_TYPE);
                cmd.Parameters.AddWithValue("@SH_FACE_DAIMETR",cw.SH_FACE_DAIMETR);
                cmd.Parameters.AddWithValue("@SH_PEELOFF_DAIMETR", cw.SH_PEELOFF_DAIMETR);

                cmd.ExecuteNonQuery();
                MessageBox.Show("  تم اضافة امر تشغيل التوريد بنجاح"+ " "+comboBoxItemType.Text);
                myconnection.closeConnection();

                buttonSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in insert in OrderWorkClient in DB" + ex.ToString());
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(comboBoxClients.Text))
            {
                MessageBox.Show("ادخل اسم العميل");
            }
            else if (string.IsNullOrEmpty(textBoxClientSuppNum.Text))
            {
                MessageBox.Show("رقم امر توريد العميل");
            }

            else if (string.IsNullOrEmpty(textBoxItemPrice.Text))
            {
                MessageBox.Show("ادخل سعر الوحده");
            }
            else if (string.IsNullOrEmpty(textBoxItemQnty.Text))
            {
                MessageBox.Show("ادخل الكميه المباعه");
            }
            else if (string.IsNullOrEmpty(textBoxSubmitted.Text))
            {
                MessageBox.Show("ادخل مقدم المبلغ");
            }
            else if (string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {
                MessageBox.Show(" ادخل قيمه المبلغ عند الاستلام");
            }
            else if (comboBoxPaymentWay3.SelectedIndex==0 &&  string.IsNullOrEmpty(comboBoxAfterReciving.Text))
            {
                MessageBox.Show(" اختر المده المتاحه للسداد بعد الاستلام");
            }
            
                    else if (string.IsNullOrEmpty(comboBoxProducts.Text))
            {
                MessageBox.Show(" اختر اسم الصنف للعميل");
            }
            else if (string.IsNullOrEmpty(comboBoxCurrency.Text))
            {
                MessageBox.Show("اختر اسم  العملة");
            }

            else if (string.IsNullOrEmpty(comboBoxNolon.Text))
            {
                MessageBox.Show("اختر النولون");
            }
            else if (string.IsNullOrEmpty(comboBoxClientsBranches.Text) && string.IsNullOrEmpty(comboBoxourFactory.Text))
            {
                MessageBox.Show(" اختر مكان التسليم");
            }

            else if (string.IsNullOrEmpty(comboBoxPaymentWay1.Text) || string.IsNullOrEmpty(comboBoxPaymentWay2.Text) || string.IsNullOrEmpty(comboBoxPaymentWay3.Text))
            {
                MessageBox.Show("ادخل طريقة الدفع نقدا ام شيك");
            }

            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && (radioButtonDakWasl.Checked == false && radioButtonweld.Checked == false))
            {
                MessageBox.Show("اختر هل العلبة لحام ام دق وصل");
            }
            else if (radioButton3Pecies.Checked&& comboBoxItemType.SelectedIndex == 0 && radioButtonweld.Checked && radioButtonAutomaticWeld.Checked == false && radioButtonManualWeld.Checked == false)
            {

                MessageBox.Show("اختر نوع اللحام مانول ام اوتوماتيك");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && radioButtonPowder.Checked == false && radioButtonNoPowder.Checked == false)
            {
                MessageBox.Show("اختر هل يوجد بودر ام لا");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0 && radioButtonPowder.Checked && string.IsNullOrEmpty(comboBoxPowderColor.Text))
            {
                MessageBox.Show("اختر لون البودر");

            }
            else if (comboBoxItemType.SelectedIndex ==0 && radioButton3Pecies.Checked && radioButtonPeding.Checked == false && radioButtonNoPeding.Checked == false && radioButtonOutSideBead.Checked == false && radioButtonInsidBead.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد بيدنج ام لا يوجد ام خرزه للداخل ام خرزه للخارج");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButton2Peices.Checked  && radioButtonOutSideBead.Checked == false && radioButtonInsidBead.Checked == false)
            {
                MessageBox.Show("حدد خرزه للداخل ام للخارج");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonTafleeg.Checked == false && radioButtonInsidePuls.Checked == false && radioButtonOutPuls.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد تفليج ام بلص للداخل ام بلص للخارج");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonHaveCover.Checked == false && radioButtonHaveNoCover.Checked == false)
            {
                MessageBox.Show("حدد هل يوجد غظاء للعلبة ام لا ");
            }


            else if (comboBoxItemType.SelectedIndex == 0 &&  radioButtonHaveCover.Checked &&  radioButtonEasyOpen.Checked == false && radioButtonFaceCover.Checked == false && radioButtonNormalEOE.Checked == false && radioButtonRLTCover.Checked == false && radioButtonPeelOffCover.Checked == false&& radioButtonTinCover.Checked==false)
            {
                MessageBox.Show("حدد نوع الغطاء ايزي ازبن ام قاع ام بييل اوف ام ار ال تي ام غطاء صفيح ");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && string.IsNullOrEmpty(comboBoxNumberOfColors.Text))
            {
                MessageBox.Show("اختر عدد الوان العلبة");
            }
            else if(comboBoxItemType.SelectedIndex == 0 && radioButton2Peices.Checked==false && radioButton3Pecies.Checked == false)
            {
                MessageBox.Show("اختر عدد قطع العلبة ");
            }
            else if (radioButton3Pecies.Checked && comboBoxItemType.SelectedIndex == 0&& checkBoxHasMold.Checked && (string.IsNullOrEmpty(comboBoxCanTabaColor.Text) || string.IsNullOrEmpty(comboBoxCanTabaType.Text) || string.IsNullOrEmpty(comboBoxCanTabaDaimetr.Text)))
            {
                MessageBox.Show("اكمل بيانات الطبة للعلبة القطر النوع اللون");
            }



            else if (comboBoxItemType.SelectedIndex == 2 && (string.IsNullOrEmpty(comboBoxTwistTypes.Text) || string.IsNullOrEmpty(comboBoxTwistSize.Text)))
            {
                MessageBox.Show("ادخل بيانات التوست بشكل صحيح النوع و المقاس");
            }



            else if (checkBoxHavePlasticCover.Checked && string.IsNullOrEmpty(comboBoxPlasticCoverColor.Text))
            {
                MessageBox.Show("ادخل لون الغطاء البلاستيك");
            }


            else if (comboBoxItemType.SelectedIndex == 1 && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxDiametrEoE.Text) || string.IsNullOrEmpty(comboBoxOpenType.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text)))
            {
                MessageBox.Show("اكمل بيانات الايزي اوبن بشكل صحيح الورنيش الداخلي و الخارجي و القطر و طريقة الفتح و الخامة");
            }
            else if (comboBoxItemType.SelectedIndex == 5 && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxDiametrEoE.Text) || string.IsNullOrEmpty(comboBoxOpenType.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text)))
            {
                MessageBox.Show("اكمل بيانات Normal End بشكل صحيح الورنيش الداخلي و الخارجي و القطر و طريقة الفتح و الخامة");
            }
            else if(comboBoxItemType.SelectedIndex ==7&&(string.IsNullOrEmpty(comboBoxPlasticTabaDaimetr.Text) || string.IsNullOrEmpty(comboBoxPlasticTabaType.Text)))
            {
                MessageBox.Show("اكمل بيانات الطبة البلاستيك  القطر و النوع و محلى ام مستورد");
            }
            //
            else if (comboBoxItemType.SelectedIndex == 7 && (radioButtonImported.Checked == false && radioButtonLocal.Checked == false))
            {
                MessageBox.Show("حدد الطبة البلاستيك محلى ام مستورد");
            }
            else if (comboBoxItemType.SelectedIndex == 4 && string.IsNullOrEmpty(comboBoxRLTDaimetr.Text))
            {
                MessageBox.Show("ادخل قطر ال ار ال تي");
            }
            else if (comboBoxItemType.SelectedIndex == 3&&string.IsNullOrEmpty(comboBoxPeelOffDaimetr.Text))
            {
                MessageBox.Show("اختر قطر ال بيل اوف");
            }

            else if (comboBoxItemType.SelectedIndex == 6&&(string.IsNullOrEmpty(comboBoxCoverColor.Text)||string.IsNullOrEmpty(comboBoxDaimetrCover.Text)))
            {
                MessageBox.Show("ادخل بيانات الغطاء البلاستيك القطر و اللون ");
            }
            else if (comboBoxItemType.SelectedIndex ==0&& radioButtonHaveCover.Checked&& radioButtonEasyOpen.Checked &&(string.IsNullOrEmpty(comboBoxOutSideMuran.Text)|| string.IsNullOrEmpty(comboBoxInsideMuran.Text)||string.IsNullOrEmpty(comboBoxEOEMaterial.Text)|| string.IsNullOrEmpty(comboBoxDiametrEoE.Text)|| string.IsNullOrEmpty(comboBoxOpenType.Text)))
            {
                MessageBox.Show("اكمل بيانات الغطاء الايزي اوبن القطر الخامه الورنيش لبداخلي والخارجي و طريقة الفتح ");
            }

            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonHaveCover.Checked && radioButtonNormalEOE.Checked && (string.IsNullOrEmpty(comboBoxOutSideMuran.Text) || string.IsNullOrEmpty(comboBoxInsideMuran.Text) || string.IsNullOrEmpty(comboBoxEOEMaterial.Text) || string.IsNullOrEmpty(comboBoxDiametrEoE.Text) || string.IsNullOrEmpty(comboBoxOpenType.Text)))
            {
                MessageBox.Show("اكمل بيانات الغطاء القاع اوبن القطر الخامه الورنيش الداخلي والخارجي و طريقة الفتح ");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonRLTCover.Checked&&string.IsNullOrEmpty(comboBoxRLTDaimetr.Text))
            {
                MessageBox.Show("ادخل قطر الغطاء للعلبة");
            }
            else if (comboBoxItemType.SelectedIndex == 0 && radioButtonPeelOffCover.Checked && string.IsNullOrEmpty(comboBoxPeelOffDaimetr.Text))
            {
                MessageBox.Show("ادخل قطر الغطاء للعلبة");
            }
            else
            {

                addOrderWorkClient();



            }
        }


        private void comboBoxItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxItemType.SelectedIndex)
            {
                case 1:
                    //easy open
                    panelUPlipe.Visible = false;
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = true;
                    panelFace.Visible = false;
                    panelPeeding.Visible = false;
                    checkBoxHasMold.Visible = false;
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelPecies.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    labelnum5.Visible = false;
                    break;


                case 4:
                    //rlt
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = false;
                    panelFace.Visible = false;
                    checkBoxHasMold.Visible = false;
             
                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = true;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                case 3:
                    //peel off
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = false;
                    panelFace.Visible = false;
                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = true;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                case 2:
                    //twist
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelFace.Visible = false;
                    panelEasyopen.Visible = false;
                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = true;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                case 6:
                    //غطاء بلاستيك
                    labelnum5.Visible = false;
                    groupBoxTaghleef.Visible = false;
                    panelCansDesc.Visible = false;
                    panelFace.Visible = false;
                    panelEasyopen.Visible = false;
                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = true;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                case 0:
                    //علبه
                    labelnum5.Visible = true;
                    panelFace.Visible = false;
                    panelCansDesc.Visible = true;
                    groupBoxTaghleef.Visible = true;
                    checkBoxHasMold.Visible = true;

                    panelHavePlasticCover.Visible = true;
                    panelCover.Visible = true;
                    panelTwistProp.Visible = false;
                    panelEasyopen.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = true;
                    panelUPlipe.Visible = true;
                    panelRLT.Visible = false;
                    panelPeelOFF.Visible = false;
                    panelPecies.Visible = true;
                    checkBoxOutMuran.Visible = true;

                    break;

                case 7:
                    //طبة بلاستيك
                    panelPlasticTaba.Visible = true;
                    panelEasyopen.Visible = false;
                    panelCansDesc.Visible = false;
                    panelFace.Visible = false;
                    panelPeeding.Visible = false;
                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelUPlipe.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                case 5:
                    //NormalEasyOpen
                    panelCansDesc.Visible = false;
                    panelEasyopen.Visible = true;
                    panelFace.Visible = false;
                    panelUPlipe.Visible = false;
                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelPlasticCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelPlasticTaba.Visible = false;
                    panelPeeding.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
                default:
                    panelPlasticCover.Visible = false;
                 
                    checkBoxHasMold.Visible = false;

                    panelTypeOFFace.Visible = false;
                    panelCover.Visible = false;
                    panelTwistProp.Visible = false;
                    panelEasyopen.Visible = false;
                    panelUPlipe.Visible = false;
                    panelPeeding.Visible = false;
                    panelRLT.Visible = false;
                    panelHavePlasticCover.Visible = false;
                    panelPeelOFF.Visible = false;
                    checkBoxOutMuran.Visible = false;
                    panelPecies.Visible = false;
                    break;
            }
        }

        private void radioButtonweld_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonweld.Checked)
            {
                panelWeldType.Visible = true;
            }
            else
            {
                panelWeldType.Visible = false;
            }
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {


            if (radioButtonPowder.Checked)
            {
                labelPowderColor.Visible = true;
                comboBoxPowderColor.Visible = true;
            }
            else
            {
                labelPowderColor.Visible = false;
                comboBoxPowderColor.Visible = false;
            }
        }

        private void radioButton17_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFaceCover.Checked)
            {
                panelFace.Visible = true;
                comboBoxTabaDaiametr.Visible = false;
                comboBoxTabaDaiametr.Visible = false;

                labelBoyatType.Visible = false;
                comboBoxBoyatFace.Visible = false;


            }
            else
            {
                panelFace.Visible = false;
            }
        }

        private void radioButtonEasyOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonEasyOpen.Checked)
            {
                panelEasyopen.Visible = true;
            }
            else
            {
                panelEasyopen.Visible = false;
            }
        }

        private void comboBoxBoyatFace_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFaceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxFaceType.SelectedIndex)
            {
                case 0:
                    labelBoyatType.Visible = true;
                    comboBoxBoyatFace.Visible = true;



                    break;

                case 1:

                    comboBoxTabaDaiametr.Visible = true;
                    labelBoyatType.Visible = true;
                    labelBoyatType.Text = "قطر الطبة";
                    comboBoxBoyatFace.Visible = false;
                    break;
                default:
                    labelBoyatType.Visible = false;
                    comboBoxBoyatFace.Visible = false;
                    comboBoxTabaDaiametr.Visible = false;
                    break;

            }
        }

        void calcualtettotalPrice()
        {
            if (string.IsNullOrEmpty(textBoxItemQnty.Text) || string.IsNullOrEmpty(textBoxItemPrice.Text))
            {

            }
            else
            {
                double testbox = 0;
                if (double.TryParse(textBoxItemQnty.Text, out testbox) && double.TryParse(textBoxItemPrice.Text, out testbox))
                {

                    textBoxTotalPrice.Clear();
                    textBoxTotatalWithTax.Clear();
                    textBoxTotalPrice.Text = (double.Parse(textBoxItemQnty.Text) * double.Parse(textBoxItemPrice.Text)).ToString();
                    textBoxTotatalWithTax.Text = (double.Parse(textBoxTotalPrice.Text) - double.Parse(textBoxTax1.Text) + double.Parse(textBoxTax14.Text)).ToString();
                }
            }
        }


        void calcualtettotalPriceNew()
        {
            if (string.IsNullOrEmpty(textBoxItemQnty.Text) || string.IsNullOrEmpty(textBoxItemPrice.Text) || string.IsNullOrEmpty(textBoxTax1.Text) || string.IsNullOrEmpty(textBoxTax14.Text)  || string.IsNullOrEmpty(textBoxSubmitted.Text) || string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {

            }

            else
            {
              
                double testbox = 0;
                if (double.TryParse(textBoxItemQnty.Text, out testbox) && double.TryParse(textBoxItemPrice.Text, out testbox)&&double.TryParse(textBoxTax1.Text, out testbox) && double.TryParse(textBoxTax14.Text, out testbox) && double.TryParse(textBoxSubmitted.Text, out testbox) && double.TryParse(textBoxWhenDelivered.Text, out testbox))
                {
                
                    textBoxTotalPrice.Clear();
                    textBoxTotatalWithTax.Clear();
                    textBoxTax1.Clear();
                    textBoxTax14.Clear();

                    textBoxRemaining.Clear();

                    textBoxTotalPrice.Text = (double.Parse(textBoxItemQnty.Text) * double.Parse(textBoxItemPrice.Text)).ToString();
                    if (checkBoxTax1.Checked)
                    {
                        textBoxTax1.Text = (double.Parse(textBoxTotalPrice.Text) * .01).ToString();

                    }else
                    {
                        textBoxTax1.Text = "0";
                    }
                    if (checkBox14.Checked)
                    {
                        textBoxTax14.Text = (double.Parse(textBoxTotalPrice.Text) * .14).ToString();

                    }
                    else
                    {
                        textBoxTax14.Text = "0";
                    }
                    textBoxTotatalWithTax.Text = (double.Parse(textBoxTotalPrice.Text) - double.Parse(textBoxTax1.Text) + double.Parse(textBoxTax14.Text)).ToString();
                    double paid = double.Parse(textBoxSubmitted.Text) + double.Parse(textBoxWhenDelivered.Text);
                    textBoxRemaining.Text = (double.Parse(textBoxTotatalWithTax.Text) - paid).ToString();

                }
            }
        }


        void calcualteRemaining()
        {
            if (string.IsNullOrEmpty(textBoxSubmitted.Text) || string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {

            }
            else
            {
                double testbox = 0;
                if (double.TryParse(textBoxSubmitted.Text, out testbox) && double.TryParse(textBoxWhenDelivered.Text, out testbox))
                {

                    textBoxRemaining.Clear();


                    double paid = double.Parse(textBoxSubmitted.Text) + double.Parse(textBoxWhenDelivered.Text);
                    textBoxRemaining.Text = (double.Parse(textBoxTotatalWithTax.Text) - paid).ToString();



                }
            }
        }



        private void textBoxItemQnty_TextChanged(object sender, EventArgs e)
        {  
            calcualtettotalPriceNew();
       

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            calcualtettotalPriceNew();
         
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            calcualtettotalPriceNew();
       
        }

        private void comboBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxProducts.Text = "";
            comboBoxClientsBranches.Text = "";
            fillClientProducts();
            fillBranchesCombo();

        }
        private void radioButtonFromShaheen_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonFromShaheen.Checked)
            {

                comboBoxourFactory.Visible = true;
            }
            else
            {
                comboBoxourFactory.Visible = false;
                comboBoxourFactory.Text = "";
            }

        }

        private void radioButtonToTheClient_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonToTheClient.Checked)
            {

                comboBoxClientsBranches.Visible = true;

            }
            else
            {
                comboBoxClientsBranches.Visible = false;
                comboBoxClientsBranches.Text = "";

            }
        }

        private void textBoxItemPrice_TextChanged(object sender, EventArgs e)
        {
            //calcualtettotalPrice();
            calcualtettotalPriceNew();
        }

        private void textBoxSubmitted_TextChanged(object sender, EventArgs e)
        {
            // calcualteRemaining();
            calcualtettotalPriceNew();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBoxCover_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBoxCover.Checked)
            //{
            //    panelTaba.Visible = false;
            //}
            //else
            //{
            //    panelTaba.Visible = true;
            //}
        }

        private void radioButtonHaveCover_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonHaveCover.Checked)
            {
                panelTypeOFFace.Visible = true;


            }
            else
            {
                panelTypeOFFace.Visible = false;
            }
        }

        private void radioButtonEasyOpen_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonEasyOpen.Checked)
            {
                panelEasyopen.Visible = true;
            }
            else
            {
                panelEasyopen.Visible = false;
            }
        }

        private void radioButton17_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonFaceCover.Checked)
            {
                panelFace.Visible = true;
            }
            else
            {
                panelFace.Visible = false;
            }
        }

        private void comboBoxFaceType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            switch (comboBoxFaceType.SelectedIndex)
            {

                case 0: //بويات
                    comboBoxTabaDaiametr.Text = "";
                    labelBoyatType.Text = "نوع الوش البويات";
                    comboBoxBoyatFace.Visible = true;
                    labelBoyatType.Visible = true;
                    comboBoxTabaDaiametr.Visible = false;
                    break;
                case 1:
                    //طبة
                    labelBoyatType.Visible = true;
                    labelBoyatType.Text = "قطر الطبة";
                    comboBoxBoyatFace.Visible = false;
                    comboBoxBoyatFace.Text = "";
                    comboBoxTabaDaiametr.Visible = true;
                    break;
                case 2:
                    //قلاوظ
                    comboBoxBoyatFace.Visible = true;
                    comboBoxTabaDaiametr.Visible = true;
                    labelBoyatType.Text = "قطر القلاوظ";
                    comboBoxBoyatFace.Visible = false;
                    break;
                default:
                    comboBoxBoyatFace.Visible = false;
                    comboBoxTabaDaiametr.Visible = false;
                    labelBoyatType.Visible = false;
                    break;
            }
        }

        private void comboBoxPaymentWay1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaymentWay1.SelectedIndex)
            {

                case 0:

                    labelDateOFSheck1.Visible = false;
                    dateTimePickerChek1.Visible = false;
                    break;
                case 1:
                    labelDateOFSheck1.Visible = true;
                    dateTimePickerChek1.Visible = true;
                    break;

                default:
                    labelDateOFSheck1.Visible = false;
                    dateTimePickerChek1.Visible = false;
                    break;
            }
        }

        private void comboBoxPaymentWay2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaymentWay2.SelectedIndex)
            {

                case 0:

                    labelDateOFSheck2.Visible = false;
                    dateTimePickerChek2.Visible = false;
                    break;
                case 1:
                    labelDateOFSheck2.Visible = true;
                    dateTimePickerChek2.Visible = true;
                    break;

                default:
                    labelDateOFSheck2.Visible = false;
                    dateTimePickerChek2.Visible = false;
                    break;
            }
        }

        private void textBoxItemPrice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxItemPrice.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxItemPrice.Text);
                textBoxItemPrice.Text = num.ToString();
            }
        }

        private void textBoxItemQnty_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxItemQnty.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxItemQnty.Text);
                textBoxItemQnty.Text = num.ToString();
            }
        }

        private void textBoxSubmitted_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSubmitted.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxSubmitted.Text);
                textBoxSubmitted.Text = num.ToString();
            }
        }

        private void textBoxWhenDelivered_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxWhenDelivered.Text))
            {

            }
            else
            {
                double num = double.Parse(textBoxWhenDelivered.Text);
                textBoxWhenDelivered.Text = num.ToString();
            }
        }

        private void radioButtonNormalEOE_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNormalEOE.Checked)
            {
                panelEasyopen.Visible = true;

            }
            else
            {
                panelEasyopen.Visible = false;
            }
        }

 
      

     
    

        private void checkBoxHavePlasticCover_CheckedChanged(object sender, EventArgs e)
        {
         
                if (checkBoxHavePlasticCover.Checked)
            {
                comboBoxPlasticCoverColor.Visible = true;
                checkBoxPlasticCoverLogo.Visible = true;

            }
            else
            {
                checkBoxPlasticCoverLogo.Visible = false;
                comboBoxPlasticCoverColor.Visible = false;
            }
        }

        private void comboBoxPaymentWay3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxPaymentWay3.SelectedIndex)
            {

                case 0:

                    labelDateOFSheck3.Visible = false;
                    dateTimePickerChek3.Visible = false;
                    labelAfterReciving.Visible = true;
                    comboBoxAfterReciving.Visible = true;

                    break;
                case 1:
                    labelDateOFSheck3.Visible = true;
                    dateTimePickerChek3.Visible = true;
                    labelAfterReciving.Visible = false;
                    comboBoxAfterReciving.Visible = false;
                    break;

                default:
                    labelDateOFSheck3.Visible = false;
                    dateTimePickerChek3.Visible = false;
                    break;
            }
        }

        private void radioButtonPowder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPowder.Checked)
            {
                comboBoxPowderColor.Visible = true;
            }
            else
            {
                comboBoxPowderColor.Visible = false;
            }
        }

        private void radioButtonImported_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonImported.Checked)
            //{
            //   cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED ="مستورد";
            //}
            //else
            //{
            //    cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "";
            //}
        }

        private void radioButtonLocal_CheckedChanged(object sender, EventArgs e)
        {
            //if (radioButtonLocal.Checked)
            //{
            //    cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "محلى";
            //}
            //else
            //{
            //    cw.SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "";
            //}
        }

        private void radioButtonNormalTwist_CheckedChanged_1(object sender, EventArgs e)
        {

            if (radioButtonNormalTwist.Checked)
            {
                comboBoxTwistTypes.Items.Clear();
                comboBoxTwistTypes.Items.Add("RTS");
                comboBoxTwistTypes.Items.Add("RSB");
                comboBoxTwistTypes.Items.Add("RTO");
                comboBoxTwistTypes.Items.Add("RTB");
                //comboBoxTwistTypes.Items.Add("");
                //comboBoxTwistTypes.Items.Add("");
                //comboBoxTwistTypes.Items.Add("");

            }
            else
            {

            }
        }

        private void radioButtonDeepTwist_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButtonDeepTwist.Checked)
            {
                comboBoxTwistTypes.Items.Clear();

                comboBoxTwistTypes.Items.Add("DTB");
                comboBoxTwistTypes.Items.Add("DTO");


            }
            else
            {

            }
        }

        private void radioButtonMediumTwist_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonMediumTwist.Checked)
            {
                comboBoxTwistTypes.Items.Clear();

                comboBoxTwistTypes.Items.Add("MTO");
                comboBoxTwistTypes.Items.Add("MTB");


            }
            else
            {

            }
        }

        private void radioButton2Peices_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2Peices.Checked)
            {
                panelTaba.Visible = false;
                panelHavePlasticCover.Visible = false;
                radioButtonPeding.Visible = false;
                radioButtonNoPeding.Visible = false;
                comboBoxCanTabaDaimetr.Text = "";
                comboBoxCanTabaType.Text = "";
                comboBoxCanTabaColor.Text = "";
            }
            else
            {
                panelTaba.Visible = true;
                panelHavePlasticCover.Visible = true;
                radioButtonPeding.Visible = true;
                radioButtonNoPeding.Visible = true;
            }
        }

        private void radioButtonHaveNoCover_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHaveNoCover.Checked)
            {
                panelFace.Visible = false;
            }
            
        }

        private void radioButton2Peices_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2Peices.Checked)
            {
                panelCansDesc.Visible = false;
                checkBoxOutMuran.Visible = false;
                labelnum5.Visible = false;
                radioButtonPeding.Visible = false;
                radioButtonNoPeding.Visible = false;
            }
            else
            {
                panelCansDesc.Visible = true;
                checkBoxOutMuran.Visible = true;
                labelnum5.Visible = true;
                radioButtonPeding.Visible = true;
                radioButtonNoPeding.Visible = true;

            }
        }

        private void radioButtonRLTCover_CheckedChanged(object sender, EventArgs e)
        {
            
                if (radioButtonRLTCover.Checked)
            {
                panelRLT.Visible = true;

            }else
            {
                panelRLT.Visible = false;
            }
        }

        private void radioButtonPeelOffCover_CheckedChanged(object sender, EventArgs e)
        {
            
                if (radioButtonPeelOffCover.Checked)
            {
                panelPeelOFF.Visible = true;

            }
            else
            {
                panelPeelOFF.Visible = false;
            }
        }



        private void checkBoxHasMold_CheckedChanged_1(object sender, EventArgs e)
        {
            if (comboBoxItemType.SelectedIndex == 0&&checkBoxHasMold.Checked  )
            {
                panelTaba.Visible = true;
            }
            else
            {
                panelTaba.Visible = false;
            }
        }
    }
    }

