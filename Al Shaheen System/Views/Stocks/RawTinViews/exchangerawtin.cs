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
    public partial class exchangerawtin : Form
    {
        List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<SH_TIN_PRINTER> printers = new List<SH_TIN_PRINTER>();
        long mtotal_no_sheets = 0;
        double mtotal_net_weight = 0;
        // private string exchange_reason = null;
        private string get_change_reason()

        {
            if (printering_radio_btn.Checked)
            {
                return "الطباعة";

            }
            else if (muraning_radio_btn.Checked)
            {
                return "الورنشة";
            }
            else if (production_radio_btn.Checked)
            {
                return "الانتاج";
            } else
            {
                return null;
            }

            

        }
           
         
        public exchangerawtin(long total_no_sheets , double total_net_weight)
        {
            InitializeComponent();
            mtotal_no_sheets = total_no_sheets;
            mtotal_net_weight = total_net_weight;

        }


        bool check_existance_of_parcel_id (long parcelid)
        {
            for (int i = 0; i < parcels.Count; i++)
            {
                if (parcelid == parcels[i].SH_ITEM_ID)
                {
                   
                    return true;
                }
            }
            return false;
        }
        void GETPARCELINFOBYID()
        {

            if (check_existance_of_parcel_id(long.Parse(item_id_text_box.Text)))
            {
                //donothing
            }
            else
            {
                int i = 0;
                try
                {
                    string query = "SELECT SH_RAW_MATERIAL_PARCEL.* FROM SH_RAW_MATERIAL_PARCEL WHERE(SH_ID = @sh_id)";

                    DatabaseConnection MyConnection = new DatabaseConnection();
                    MyConnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@sh_id", long.Parse(item_id_text_box.Text));
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        i++;
                        //MessageBox.Show("THERE IS DATA"); 
                        parcels.Add(new SH_RAW_MATERIAL_PARCEL { SH_ITEM_PARCEL_NET_WEIGHT = double.Parse(reader["SH_ITEM_PARCEL_NET_WEIGHT"].ToString()), SH_SPECIFICATION_OF_RAW_MATERIAL_ID = long.Parse(reader["SH_SPECIFICATION_OF_RAW_MATERIAL_ID"].ToString()) , SH_ITEM_ID = long.Parse(item_id_text_box.Text), SH_ITEM_PARCEL_GROSS_WEIGHT = double.Parse(reader["SH_ITEM_PARCEL_GROSS_WEIGHT"].ToString()), SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString(), SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString(), SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString(), SH_SUPPLIER_NAME = reader["SH_SUPPLIER_NAME"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString(), SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString(), SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString(), SH_ITEM_LENGTH = double.Parse(reader["SH_ITEM_LENGTH"].ToString()), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()), SH_ITEM_INTENSITY = double.Parse(reader["SH_ITEM_INTENSITY"].ToString()), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), SH_ITEM_NUMBER_OF_SHEETS = long.Parse(reader["SH_ITEM_NUMBER_OF_SHEETS"].ToString()) });
                        MessageBox.Show(reader["SH_ITEM_PARCEL_NET_WEIGHT"].ToString());
                    }
                    if (i == 0)
                    {
                        MessageBox.Show("رقم الطرد غير موجود");
                    }
                    MyConnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTING PARCEL INFO " + ex.ToString());
                }
            }
        }


        void updateitemtotalrecords()
        { 
            for (int i = 0; i < parcels.Count; i++)
            {
                MessageBox.Show(parcels[i].SH_ITEM_PARCEL_NET_WEIGHT.ToString());
                try
                {
                    string query = "UPDATE SH_SPECIFICATION_OF_RAW_MATERIAL ";
                    query += "  SET SH_ITEM_TOTAL_NUMBER_OF_PACKAGES = SH_ITEM_TOTAL_NUMBER_OF_PACKAGES - @SH_ITEM_TOTAL_NUMBER_OF_PACKAGES     ";
                    query += ", SH_ITEM_TOTAL_NUMBER_OF_SHEETS = SH_ITEM_TOTAL_NUMBER_OF_SHEETS - @SH_ITEM_TOTAL_NUMBER_OF_SHEETS  ";
                    query += ", SH_TOTAL_NET_WEIGHT = SH_TOTAL_NET_WEIGHT - @SH_TOTAL_NET_WEIGHT ";
                    query += ", SH_TOTAL_GROSS_WEIGHT = SH_TOTAL_GROSS_WEIGHT - @SH_TOTAL_GROSS_WEIGHT ";
                    query += "  WHERE(SH_ID = @SH_ID)";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_PACKAGES", 1);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NUMBER_OF_SHEETS", parcels[i].SH_ITEM_NUMBER_OF_SHEETS);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_NET_WEIGHT", parcels[i].SH_ITEM_PARCEL_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_GROSS_WEIGHT", parcels[i].SH_ITEM_GROSS_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_ID", parcels[i].SH_SPECIFICATION_OF_RAW_MATERIAL_ID);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE UPDATING SPECIFICATION " + ex.ToString());
                }
            }
        }


        void fillgridviewitems()
        {
            parcels_grid_view.Rows.Clear();
            for (int i = 0; i < parcels.Count; i++)
            {
                parcels_grid_view.Rows.Add(new string [] { parcels[i].SH_ID.ToString() , parcels[i].SH_ITEM_CODE.ToString() , parcels[i].SH_ITEM_NUMBER_OF_SHEETS.ToString() , parcels[i].SH_SUPPLIER_NAME.ToString() ,parcels[i].SH_ITEM_TYPE.ToString() , parcels[i].SH_ITEM_PARCEL_NET_WEIGHT.ToString() , parcels[i].SH_ITEM_TEMPER.ToString() , parcels[i].SH_ITEM_FINISH.ToString() });
            }
        }
        private void add_new_parcel_btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(work_number_text_box.Text))
            {
                errorProvider1.SetError(work_number_text_box, "ادخل رقم امر الشغل ");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (string.IsNullOrEmpty(exchange_permission_number.Text))
            {
                errorProvider1.SetError(exchange_permission_number, "ادخل رقم إذن الشغل ");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (string.IsNullOrEmpty(stock_man_text_box.Text))
            {
                errorProvider1.SetError(stock_man_text_box, "ادخل اسم امين المخزن  ");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (string.IsNullOrEmpty(confidential_man_text_box.Text))
            {
                errorProvider1.SetError(confidential_man_text_box, "ادخل اسم المعتمد  ");
            }
            else
            {
                errorProvider1.Clear();
            }

            if (string.IsNullOrEmpty(receival_man_text_box.Text))
            {
                errorProvider1.SetError(receival_man_text_box, "ادخل اسم المستلم  ");
            }
            else
            {
                errorProvider1.Clear();
            }


            if (!string.IsNullOrEmpty(item_id_text_box.Text))
            {
                
                if (errorProvider1.GetError(item_id_text_box)== "")
                {
                    GETPARCELINFOBYID();
                    fillgridviewitems();
                } else
                {
                    errorProvider1.SetError(item_id_text_box, "إدخل رقم الطرد ");
                }
                
            }
            else
            {
                if (errorProvider1.GetError(item_id_text_box)=="")
                {
                    MessageBox.Show("إدخل رقم الطرد" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
                }else
                {
                    errorProvider1.SetError(item_id_text_box, "إدخل رقم الطرد ");
                }
               
            }
        

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void stock_man_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(stock_man_text_box.Text))
            {
                errorProvider1.SetError(stock_man_text_box, "الرجاء اسم امين المخزن");
            }else
            {
                errorProvider1.Clear();
            }
        }

        private void work_number_text_box_TextChanged(object sender, EventArgs e)
        {
            long number = 0;
            if (long.TryParse(work_number_text_box.Text ,out number))
            {
                errorProvider1.Clear();  
            }else
            {
                errorProvider1.SetError( work_number_text_box ,"ادخل رقم امر الشغل بشكل صحيح");
            }
        }

        private void exchange_permission_number_TextChanged(object sender, EventArgs e)
        {
            long number = 0;
            if (long.TryParse(exchange_permission_number.Text, out number))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(exchange_permission_number, "ادخل رقم اذن الصرف بشكل صحيح");
            }
        }

        private void confidential_man_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(confidential_man_text_box.Text))
            {
                errorProvider1.SetError(confidential_man_text_box, "الرجاء اسم امين المخزن");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void receival_man_text_box_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(receival_man_text_box.Text))
            {
                errorProvider1.SetError(receival_man_text_box, "الرجاء اسم امين المخزن");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        void addexchangedparcels(long exchangerequest_id , long parcel_id)
        {
            try
            {
                string query = "INSERT INTO SH_PACKAGES_DISBURSED_RAW_MATERIAL ";
                query += "(SH_RAW_MATERIAL_PARCEL_ID, SH_EXCHANGE_OF_RAW_MATERIAL_ID, SH_EXCHANGE_DATE) ";
                query += " VALUES(@SH_EXCHANGE_OF_RAW_MATERIAL_ID,@SH_RAW_MATERIAL_PARCEL_ID,@SH_EXCHANGE_DATE)";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_OF_RAW_MATERIAL_ID", exchangerequest_id );
                cmd.Parameters.AddWithValue("@SH_RAW_MATERIAL_PARCEL_ID", parcel_id);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE ADDING TO ECHANGED PARCEL TABLE "+ex.ToString());
            }
        }


        


        long saveexchangerawtin()
        {
            
            try
            {
                string query = "INSERT INTO SH_EXCHANGE_OF_RAW_MATERIAL ";
                query += "(SH_STOCK_MAN_NAME, SH_STOCK_NAME, SH_RECIPICIENT_MAN_NAME, SH_CONFIDENTIEL_MAN_NAME, SH_WORK_NUMBER, SH_EXCHANGE_DATE, SH_EXCHANGE_PERMISSION_NUMBER , SH_REASON_OF_EXCHANGE, SH_PLACE_OF_EXCHANGE) ";
                query += "VALUES(@SH_STOCK_MAN_NAME,@SH_STOCK_NAME,@SH_RECIPICIENT_MAN_NAME,@SH_CONFIDENTIEL_MAN_NAME,@SH_WORK_NUMBER,@SH_EXCHANGE_DATE,@SH_EXCHANGE_PERMISSION_NUMBER , @SH_REASON_OF_EXCHANGE, @SH_PLACE_OF_EXCHANGE)";
                query += " SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand( query  , DatabaseConnection.mConnection);
               // cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER", exchange_permission_number.Text );
                cmd.Parameters.AddWithValue("@SH_STOCK_NAME" , stock_combo_box.Text);
                cmd.Parameters.AddWithValue("@SH_STOCK_MAN_NAME", stock_man_text_box.Text );
                cmd.Parameters.AddWithValue("@SH_RECIPICIENT_MAN_NAME" , receival_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_CONFIDENTIEL_MAN_NAME" , confidential_man_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_WORK_NUMBER" , work_number_text_box.Text);
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_DATE" , DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@SH_EXCHANGE_PERMISSION_NUMBER" , exchange_permission_number.Text);
                cmd.Parameters.AddWithValue("@SH_REASON_OF_EXCHANGE", get_change_reason());
                cmd.Parameters.AddWithValue("@SH_PLACE_OF_EXCHANGE" , p_text_box.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex )
            {
                MessageBox.Show("ERROR WHILE ADDING TO EXCHANGE TABLE IN DB "+ex.ToString());
            }
            return 0;
        }

        
        private void save_and_print__Click(object sender, EventArgs e)
        {

            if (parcels.Count != 0)
            {
                if ((errorProvider1.GetError(exchange_permission_number) == "") && (errorProvider1.GetError(work_number_text_box) == "") && (errorProvider1.GetError(stock_man_text_box) == "") && (errorProvider1.GetError(receival_man_text_box) == "") && (errorProvider1.GetError(confidential_man_text_box) == ""))
                {
                    long process_id = saveexchangerawtin();
                    if (process_id == 0)
                    {
                        //error not ssaved
                    }
                    else
                    {
                        for (int i = 0; i < parcels.Count; i++)
                        {
                            MessageBox.Show(process_id.ToString() + " ::: " + parcels[i].SH_ITEM_ID.ToString());

                            addexchangedparcels(process_id, parcels[i].SH_ITEM_ID);
                        }
                        updateitemtotalrecords();
                        MessageBox.Show("تم الحفظ ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                        using (print_exchange_request myform = new print_exchange_request(work_number_text_box.Text, exchange_permission_number.Text, stock_man_text_box.Text, confidential_man_text_box.Text, receival_man_text_box.Text, stock_combo_box.Text, parcels , get_change_reason()))
                        {
                            myform.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("لا يمكن حفظ البيانات  \n  الرجاء التاكد من كتابة البيانات بشكل صحيح ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            else
            {
                MessageBox.Show("الرجاء ادخال البيانات المراد حفظها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
            }
        }

        private void exchangerawtin_Load(object sender, EventArgs e)
        {
            stock_combo_box.SelectedIndex = 0;
            printering_radio_btn.Checked = true;
            total_net_weight_text_box.Text = mtotal_net_weight.ToString();
            item_total_no_sheets_text_box.Text = mtotal_no_sheets.ToString();
        }

        private void item_id_text_box_TextChanged(object sender, EventArgs e)
        {
            long number = 0;
            if (long.TryParse(item_id_text_box.Text, out number))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(item_id_text_box, "  ادخل رقم اذن الصرف بشكل صحيح فى صورة أرقام 123...");
            }
        }

        private void remove_parcel_btn_Click(object sender, EventArgs e)
        {
            if (parcels_grid_view.SelectedRows.Count > 0)
            {
                parcels.Remove(parcels[parcels_grid_view.SelectedRows[0].Index]);
            }
            fillgridviewitems();
        }
        void loadallprintersdata()
        {
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM SH_TIN_PRINTER", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    printers.Add(new SH_TIN_PRINTER() { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_PRINTER = reader["SH_PRINTER"].ToString(), SH_PRINTER_ADDRESS_TEXT = reader["SH_PRINTER_ADDRESS_TEXT"].ToString(), SH_PRINTER_ADDRESS_GPS = reader["SH_PRINTER_ADDRESS_GPS"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PRINTERS DATA " + ex.ToString());
            }
        }

        void fillprintersgridview()
        {
            loadallprintersdata();
            if (printers.Count <= 0)
            {

            }
            else
            {
                p_text_box.Items.Clear();
                for (int i = 0; i < printers.Count; i++)
                {
                    p_text_box.Items.Add(printers[i].SH_PRINTER);
                }

            }
        }
        private void printering_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "إسم المطبعة";
            fillprintersgridview();

        }

        private void muraning_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "إسم المطبعة";
            fillprintersgridview();
        }

        private void production_radio_btn_CheckedChanged(object sender, EventArgs e)
        {
            p_label.Text = "مرحلة الانتاج";
            p_text_box.DropDownStyle = ComboBoxStyle.Simple;
        }
    }
}
