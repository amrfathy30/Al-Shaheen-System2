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
    public partial class raw_material_second_form_coils : Form
    {
        List<SH_SPECIFICATION_OF_RAW_MATERIAL_COILS> all_raw_coils_sp = new List<SH_SPECIFICATION_OF_RAW_MATERIAL_COILS>();
        List<SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS> coils_quantites = new List<SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS>();
        List<SH_COILS_RAW_MATERIAL> raw_coils = new List<SH_COILS_RAW_MATERIAL>();
        List<SH_SUPPLY_COMPANY> suppliers = new List<SH_SUPPLY_COMPANY>();

        long number_of_coils = 0;
        double total_window_net_weight=0;
        double total_window_gross_weight=0;
        double quantity_net_weight=0;
        double quantity_gross_weight=0;
        long total_windows_number_of_coils=0;
        long quantity_total_number_of_coils=0;
   //     bool new_quantity = true;
        public raw_material_second_form_coils()
        {
            InitializeComponent();
        }

        void fillsupplierscombobox()
        {
            suppliers.Clear();
            loadsuppliersdata();
            supplier_text_box.Items.Clear();
            for (int i = 0; i < suppliers.Count; i++)
            {
                supplier_text_box.Items.Add(suppliers[i].SH_SUPPLY_COMAPNY_NAME);
            }
        }



        void loadsuppliersdata()
        {
            string query = "SELECT * FROM SH_SUPPLY_COMPANY";
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    suppliers.Add(new SH_SUPPLY_COMPANY { SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_SUPPLY_COMAPNY_NAME = reader["SH_SUPPLY_COMAPNY_NAME"].ToString(), SH_SUPPLY_COMPANY_MOBILE = reader["SH_SUPPLY_COMPANY_MOBILE"].ToString(), SH_SUPPLY_COMPANY_TELEPHONE = reader["SH_SUPPLY_COMPANY_TELEPHONE"].ToString(), SH_SUPPLY_COMPANY_TYPE = reader["SH_SUPPLY_COMPANY_TYPE"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE LOADING SUPLLIERS DATA");
            }
        }


        long check_raw_material_existance_sp(SH_COILS_RAW_MATERIAL anycoil)
        {
            List<SH_SPECIFICATION_OF_RAW_MATERIAL_COILS> all_sp = new List<SH_SPECIFICATION_OF_RAW_MATERIAL_COILS>();
            if (string.IsNullOrEmpty(item_width_text_box.Text) && string.IsNullOrEmpty(item_thickness_text_box.Text) && string.IsNullOrEmpty(item_temper_combo_box.Text) && string.IsNullOrEmpty(item_type_combo_box.Text) && string.IsNullOrEmpty(item_finish_combo_box.Text))
            {

            }
            else
            {
                double mynum;
                long mydidnum;
                if ((!string.IsNullOrEmpty(supplier_text_box.Text))&&double.TryParse(item_width_text_box.Text, out mynum) && long.TryParse(adding_request_number_text_box.Text, out mydidnum) && double.TryParse(item_thickness_text_box.Text, out mynum))
                {
                    try
                    {
                        DatabaseConnection myconnection = new DatabaseConnection();
                        myconnection.openConnection();
                        SqlCommand cmd = new SqlCommand("SELECT * FROM SH_SPECIFICATION_OF_RAW_MATERIAL_COILS ", DatabaseConnection.mConnection);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            all_sp.Add(new SH_SPECIFICATION_OF_RAW_MATERIAL_COILS {SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString(), SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString(), SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString(), SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()), SH_ITEM_WIDTH = double.Parse(reader["SH_ITEM_WIDTH"].ToString()) });
                            
                        }
                        myconnection.closeConnection();
                        for (int i = 0; i < all_sp.Count; i++)
                        {
                            if ((string.Compare(all_sp[i].SH_ITEM_FINISH , anycoil.SH_ITEM_FINISH)==0) && (string.Compare(all_sp[i].SH_ITEM_COATING , anycoil.SH_ITEM_COATING)==0  ) && (string.Compare(all_sp[i].SH_ITEM_TEMPER , anycoil.SH_ITEM_TEMPER)==0) && (all_sp[i].SH_ITEM_WIDTH== anycoil.SH_ITEM_WIDTH) && (all_sp[i].SH_ITEM_THICKNESS == anycoil.SH_ITEM_THICKNESS) )
                            {
                                return all_sp[i].SH_ID;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR WHILE CHECKING RAW MATERIAL EXISTANCE" + ex.ToString());
                    }
                } else
                {
                    MessageBox.Show("الرجاء إدخال المعلومات بشكل صحيح" , "خطأ"  , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
                }
            }
            return 0;
        }
        long savenewcoilspacification(SH_COILS_RAW_MATERIAL any_sample_coil)
        {
            try
            {
                string query = "INSERT INTO SH_SPECIFICATION_OF_RAW_MATERIAL_COILS ";
                query += "(SH_ITEM_WIDTH, SH_ITEM_THICKNESS, SH_ITEM_NAME, SH_ITEM_TYPE, SH_ITEM_FINISH, SH_ITEM_COATING, SH_ITEM_TEMPER, SH_ITEM_TOTAL_NET_WEIGHT, SH_ITEM_TOTAL_GROSS_WEIGHT) ";
                query += "VALUES(@SH_ITEM_WIDTH,@SH_ITEM_THICKNESS,@SH_ITEM_NAME,@SH_ITEM_TYPE,@SH_ITEM_FINISH,@SH_ITEM_COATING,@SH_ITEM_TEMPER,@SH_ITEM_TOTAL_NET_WEIGHT,@SH_ITEM_TOTAL_GROSS_WEIGHT)";
                query += "SELECT SCOPE_IDENTITY() AS myidentity";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand( query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", any_sample_coil.SH_ITEM_WIDTH);
                cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS" , any_sample_coil.SH_ITEM_THICKNESS);
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME", "صفيح");
                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE" , any_sample_coil.SH_ITEM_TYPE);
                cmd.Parameters.AddWithValue("@SH_ITEM_FINISH" , any_sample_coil.SH_ITEM_FINISH);
                cmd.Parameters.AddWithValue("@SH_ITEM_COATING" , any_sample_coil.SH_ITEM_COATING);
                cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", any_sample_coil.SH_ITEM_TEMPER);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NET_WEIGHT", any_sample_coil.SH_ITEM_TOTAL_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_GROSS_WEIGHT" , any_sample_coil.SH_ITEM_TOTAL_GROSS_WEIGHT);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR WHILE SAVING COIL SPACIFICATION");
            }
            return 0;
        }
        long saverawmaterialquantites(long sp_id , SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS myquantity)
        {
           // MessageBox.Show(sp_id.ToString());
            string query = "INSERT INTO SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS ";
            query += "(SH_ITEM_WIDTH, SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID, SH_ITEM_THICKNESS, SH_ITEM_TEMPER, SH_ITEM_COATING, SH_ITEM_FINISH, SH_ITEM_NAME, SH_ITEM_TYPE, ";
            query += " SH_SUPPLIER_NAME, SH_ITEM_TOTAL_NO_COILS, SH_ITEM_TOTAL_NET_WEIGHT, SH_ITEM_TOTAL_GROSS_WEIGHT, SH_ITEM_TON_PRICE, ";
            query += " SH_ITEM_TOTAL_QUANTITY_COST, SH_ITEM_STOCK_NAME, SH_ADDITION_DATE, SH_ADDING_PERMISSION_NUMBER) ";
            query += " VALUES(@SH_ITEM_WIDTH,@SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID ,@SH_ITEM_THICKNESS,";
            query += "@SH_ITEM_TEMPER,@SH_ITEM_COATING,@SH_ITEM_FINISH,@SH_ITEM_NAME,@SH_ITEM_TYPE,@SH_SUPPLIER_NAME,";
            query += "@SH_ITEM_TOTAL_NO_COILS,@SH_ITEM_TOTAL_NET_WEIGHT,@SH_ITEM_TOTAL_GROSS_WEIGHT,@SH_ITEM_TON_PRICE";
            query += ",@SH_ITEM_TOTAL_QUANTITY_COST,@SH_ITEM_STOCK_NAME,@SH_ADDITION_DATE,@SH_ADDING_PERMISSION_NUMBER)";
            query += "SELECT SCOPE_IDENTITY() AS myidentity";
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH", myquantity.QuantityCoils[0].SH_ITEM_WIDTH);
                cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID" , sp_id);
                cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS" , myquantity.QuantityCoils[0].SH_ITEM_THICKNESS);
                cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER" , myquantity.QuantityCoils[0].SH_ITEM_TEMPER);
                cmd.Parameters.AddWithValue("@SH_ITEM_COATING" , myquantity.QuantityCoils[0].SH_ITEM_COATING);
                cmd.Parameters.AddWithValue("@SH_ITEM_FINISH" , myquantity.QuantityCoils[0].SH_ITEM_FINISH);
                cmd.Parameters.AddWithValue("@SH_ITEM_NAME" , "صفيح");
                cmd.Parameters.AddWithValue("@SH_ITEM_TYPE" , myquantity.QuantityCoils[0].SH_ITEM_TYPE);
                cmd.Parameters.AddWithValue("@SH_SUPPLIER_NAME" , supplier_text_box.Text);
            //  cmd.Parameters.AddWithValue("@SH_DATE_OF_SUPPLY" , "");
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NO_COILS" , myquantity.SH_ITEM_TOTAL_NO_COILS);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NET_WEIGHT" , myquantity.SH_ITEM_TOTAL_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_GROSS_WEIGHT" , myquantity.SH_ITEM_TOTAL_GROSS_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TON_PRICE" , 00);
               // cmd.Parameters.AddWithValue("@SH_ITEM_SUPPLY_TYPE" , null);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_QUANTITY_COST", 00);
                cmd.Parameters.AddWithValue("@SH_ITEM_STOCK_NAME" , myquantity.QuantityCoils[0].SH_ITEM_STOCK_NAME);
                cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Parse(addition_date_text_box.Text));
                cmd.Parameters.AddWithValue("@SH_ADDING_PERMISSION_NUMBER" , adding_request_number_text_box.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return long.Parse(reader["myidentity"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex )
            {
                MessageBox.Show("ERROR WHILE SAVING MATERIAL QUANTITIES"+ex.ToString());
            }
            return 0;
        }
        void saverawmaterialcoils(long sp_id ,long quantity_id, List<SH_COILS_RAW_MATERIAL> mycoils)
        {
         //   MessageBox.Show("S : "+sp_id.ToString() + " Q : "+quantity_id.ToString() );
            string query = "INSERT INTO SH_COILS_RAW_MATERIAL ";
            query += "(SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID, SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS_ID, SH_ITEM_WIDTH, SH_ITEM_NAME, SH_ITEM_THICKNESS, SH_ITEM_TYPE, SH_ITEM_FINISH, ";
            query += " SH_ITEM_TEMPER, SH_ITEM_COATING, SH_ITEM_NET_WEIGHT, SH_ITEM_GROSS_WEIGHT, SH_ITEM_STOCK_NAME, SH_SUPPLIER_NAME, SH_TON_PRICE, SH_TOTAL_PRICE, SH_ADDITION_DATE";
            query += " , SH_ADDITION_PERMISSION_NUMBER  )";
            query += "VALUES(@SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID,@SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS_ID,@SH_ITEM_WIDTH,@SH_ITEM_NAME,@SH_ITEM_THICKNESS";
            query += ",@SH_ITEM_TYPE,@SH_ITEM_FINISH,@SH_ITEM_TEMPER,@SH_ITEM_COATING,@SH_ITEM_NET_WEIGHT,@SH_ITEM_GROSS_WEIGHT,@SH_ITEM_STOCK_NAME,@SH_SUPPLIER_NAME,@SH_TON_PRICE,@SH_TOTAL_PRICE,@SH_ADDITION_DATE , @SH_ADDITION_PERMISSION_NUMBER)";
            query += "SELECT SCOPE_IDENTITY() AS my_identity";

            for (int i = 0; i < mycoils.Count; i++)
            { 
                try
                {
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID", sp_id);
                    cmd.Parameters.AddWithValue("@SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS_ID" , quantity_id);
                    cmd.Parameters.AddWithValue("@SH_ITEM_WIDTH" , mycoils[i].SH_ITEM_WIDTH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME" ,"صفيح" );
                    cmd.Parameters.AddWithValue("@SH_ITEM_THICKNESS", mycoils[i].SH_ITEM_THICKNESS);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TYPE" , mycoils[i].SH_ITEM_TYPE );
                    cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", mycoils[i].SH_ITEM_FINISH);
                    cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", mycoils[i].SH_ITEM_TEMPER);
                    cmd.Parameters.AddWithValue("@SH_ITEM_COATING", mycoils[i].SH_ITEM_COATING);
                    cmd.Parameters.AddWithValue("@SH_ITEM_NET_WEIGHT", mycoils[i].SH_ITEM_TOTAL_NET_WEIGHT);
                    cmd.Parameters.AddWithValue("@SH_ITEM_GROSS_WEIGHT", mycoils[i].SH_ITEM_TOTAL_GROSS_WEIGHT );
                    cmd.Parameters.AddWithValue("@SH_ITEM_STOCK_NAME", mycoils[i].SH_ITEM_STOCK_NAME);
                    cmd.Parameters.AddWithValue("@SH_SUPPLIER_NAME" ,supplier_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_TON_PRICE", 00);
                    cmd.Parameters.AddWithValue("@SH_TOTAL_PRICE" ,00);
                    cmd.Parameters.AddWithValue("@SH_ADDITION_DATE", DateTime.Parse(addition_date_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_ADDITION_PERMISSION_NUMBER" , adding_request_number_text_box.Text);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       //get item reader["myidentity"].tostring()
                    }
                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING COIL DATA " +ex.ToString());
                }
            }
        }
        void update_sp_raw_coils_info(long sp_id , SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS myquantity)
        {
            string query = "UPDATE SH_SPECIFICATION_OF_RAW_MATERIAL_COILS ";
            query += "SET SH_ITEM_TOTAL_NET_WEIGHT = SH_ITEM_TOTAL_NET_WEIGHT + @SH_ITEM_TOTAL_NET_WEIGHT, SH_ITEM_TOTAL_GROSS_WEIGHT = SH_ITEM_TOTAL_GROSS_WEIGHT + @SH_ITEM_TOTAL_GROSS_WEIGHT ";
            query += "WHERE(SH_ID = @SH_ID)";
            try
            {
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_NET_WEIGHT", myquantity.SH_ITEM_TOTAL_NET_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ITEM_TOTAL_GROSS_WEIGHT", myquantity.SH_ITEM_TOTAL_GROSS_WEIGHT);
                cmd.Parameters.AddWithValue("@SH_ID" , sp_id);
                cmd.ExecuteNonQuery();
                myconnection.closeConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR EHILE UPDATING SPECIFICATION TABLE VALUE");
            }
        }
        void saverawmaterailspaceisifications()
        {
            long sp_id = 0 , q_id = 0;
            for (int i = 0; i < coils_quantites.Count; i++)
            {
                sp_id = 0;
                   sp_id = check_raw_material_existance_sp(coils_quantites[i].QuantityCoils[0]);
                if (sp_id ==0)
                {
                    try
                    {
                        sp_id = savenewcoilspacification(coils_quantites[i].QuantityCoils[0]);
                    q_id = saverawmaterialquantites(sp_id, coils_quantites[i]);
                    saverawmaterialcoils(sp_id,q_id, coils_quantites[i].QuantityCoils);
                    MessageBox.Show("تم الحفظ بنجاح" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
                    }
                    catch (Exception )
                    {
                        MessageBox.Show("لم يتم الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                }
                else
                {
                    try
                    {
                        update_sp_raw_coils_info(sp_id, coils_quantites[i]);
                        q_id = saverawmaterialquantites(sp_id, coils_quantites[i]);
                        saverawmaterialcoils(sp_id, q_id, coils_quantites[i].QuantityCoils);
                        MessageBox.Show("تم الحفظ بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }catch(Exception )
                    {
                        MessageBox.Show("لم يتم الحفظ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                }
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void item_width_text_box_TextChanged(object sender, EventArgs e)
        {
            double testnumber = 0;
            if (!double.TryParse(item_width_text_box.Text ,out testnumber ) )
            {
                errorProvider1.SetError(item_width_text_box , "إملأ عرض الصنف بالبيانات الصحيحة مثال 12.0012");      
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void coil_net_weight_text_box_TextChanged(object sender, EventArgs e)
        {
            double testnumber = 0;
            if (!double.TryParse(coil_net_weight_text_box.Text, out testnumber))
            {
                errorProvider1.SetError(coil_net_weight_text_box, "إملأ وزن البكرة بالبيانات الصحيحة مثال 12.0012");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void coil_gross_weight_text_box_TextChanged(object sender, EventArgs e)
        {
            double testnumber = 0;
            if (!double.TryParse(coil_gross_weight_text_box.Text, out testnumber))
            {
                errorProvider1.SetError(coil_gross_weight_text_box, "إملأ وزن البكرة بالبيانات الصحيحة مثال 12.0012");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void item_coating_text_box_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(item_coating_text_box.Text))
            {
                errorProvider1.SetError(item_coating_text_box, "إملاء الCoating  بالبيانات ");
                
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void item_thickness_text_box_TextChanged(object sender, EventArgs e)
        {
            double testnumber = 0;
            if (!double.TryParse(item_thickness_text_box.Text, out testnumber))
            {
                errorProvider1.SetError(item_thickness_text_box, "إملأ سمك البكرة بالبيانات الصحيحة مثال 12.0012");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
        private void no_coils_text_box_TextChanged(object sender, EventArgs e)
        {
            long test_number = 0;
            if (!long.TryParse(no_coils_text_box.Text , out test_number))
            {
                errorProvider1.SetError(no_coils_text_box , "إملاء عدد الCoils  بالشكل صحيح مثال 123");    
            }else
            {
                errorProvider1.Clear();
            }
        }
        bool check_if_there_is_coils_with_the_same_gross_and_net(SH_COILS_RAW_MATERIAL anycoil)
        {
            if (raw_coils.Count > 0)
            {
                for (int i = 0; i < raw_coils.Count; i++)
                {
                    if ((raw_coils[i].SH_ITEM_TOTAL_NET_WEIGHT == anycoil.SH_ITEM_TOTAL_NET_WEIGHT) && (raw_coils[i].SH_ITEM_TOTAL_GROSS_WEIGHT == anycoil.SH_ITEM_TOTAL_GROSS_WEIGHT))
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        private void add_new_coil_btn_Click(object sender, EventArgs e)
        {
            double test_number;
            long testintnumber;
          //  MessageBox.Show("here");
            if ( string.IsNullOrEmpty(supplier_text_box.Text)  && string.IsNullOrEmpty(item_width_text_box.Text) && string.IsNullOrEmpty(item_thickness_text_box.Text) && string.IsNullOrEmpty(item_type_combo_box.Text) && string.IsNullOrEmpty(item_type_combo_box.Text) && string.IsNullOrEmpty(item_temper_combo_box.Text) && string.IsNullOrEmpty(item_finish_combo_box.Text) && string.IsNullOrEmpty(stocks_combo_box.Text) && string.IsNullOrEmpty(no_coils_text_box.Text) && string.IsNullOrEmpty(coil_gross_weight_text_box.Text) && string.IsNullOrEmpty(coil_net_weight_text_box.Text))
            {
                MessageBox.Show("لايمكن إضافة Coil  بسبب البيانات غير صحيحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
            else
            {
                if ((double.TryParse(item_width_text_box.Text, out test_number)) && (double.TryParse(item_thickness_text_box.Text, out test_number)) && (double.TryParse(coil_gross_weight_text_box.Text, out test_number)) && (double.TryParse(coil_net_weight_text_box.Text, out test_number)) && (long.TryParse(no_coils_text_box.Text, out testintnumber)))
                {
                    if ((errorProvider1.GetError(item_width_text_box) != "") || (errorProvider1.GetError(item_thickness_text_box) != "") || (errorProvider1.GetError(coil_gross_weight_text_box) != "") || (errorProvider1.GetError(no_coils_text_box) != "") || (errorProvider1.GetError(coil_net_weight_text_box) != ""))
                    {


                        MessageBox.Show("لايمكن إضافة Coil  بسبب البيانات غير صحيحة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                    }
                    else
                    {
                        //MessageBox.Show("here");
                        raw_coils.Add(new SH_COILS_RAW_MATERIAL() { SH_ADDITION_DATE = DateTime.Parse(addition_date_text_box.Text), SH_ITEM_COATING = item_coating_text_box.Text, SH_ITEM_FINISH = item_finish_combo_box.Text, SH_ITEM_TEMPER = item_temper_combo_box.Text, SH_ITEM_STOCK_NAME = stocks_combo_box.Text, SH_ITEM_THICKNESS = double.Parse(item_thickness_text_box.Text), SH_ITEM_WIDTH = double.Parse(item_width_text_box.Text), SH_SUPPLIER_NAME = supplier_text_box.Text, SH_ITEM_TOTAL_NET_WEIGHT = double.Parse(coil_net_weight_text_box.Text), SH_ITEM_TOTAL_GROSS_WEIGHT = double.Parse(coil_gross_weight_text_box.Text), SH_ITEM_TYPE = item_type_combo_box.Text });

                        number_of_coils++;
                        quantity_total_number_of_coils++;
                        total_windows_number_of_coils++;
                        quantity_gross_weight += double.Parse(coil_gross_weight_text_box.Text);
                        quantity_net_weight += double.Parse(coil_net_weight_text_box.Text);
                        total_window_gross_weight += double.Parse(coil_gross_weight_text_box.Text);
                        total_window_net_weight += double.Parse(coil_net_weight_text_box.Text);
                        general_coils_no_text_box.Text = total_windows_number_of_coils.ToString();
                        fillcoilsgridview();
                        //new_quantity = false;
                    }
                }
                else
                {
                    MessageBox.Show("إكتب البيانات بشكل صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
        }
        void fillcoilsgridview()
        {
            raw_coils_grid_view.Rows.Clear();
            if (raw_coils.Count >0)
            {
                for (int i = 0; i < raw_coils.Count; i++)
                {
                    raw_coils_grid_view.Rows.Add(new string[] { (i+1).ToString() ,raw_coils[i].SH_ITEM_FINISH , raw_coils[i].SH_ITEM_TEMPER , raw_coils[i].SH_ITEM_COATING , raw_coils[i].SH_ITEM_TOTAL_NET_WEIGHT.ToString() , raw_coils[i].SH_ITEM_TOTAL_GROSS_WEIGHT.ToString() });
                }
            }
            total_gross_weight_text_box.Text = total_window_gross_weight.ToString();
            total_net_weight_text_box.Text = total_window_net_weight.ToString();
        }
        private void raw_material_second_form_coils_Load(object sender, EventArgs e)
        {
            stocks_combo_box.SelectedIndex = 0;
            item_finish_combo_box.SelectedIndex = 0;
            item_temper_combo_box.SelectedIndex = 0;
            item_type_combo_box.SelectedIndex = 0;
            fillsupplierscombobox();


        }
        private void delete_coil_from_grid_view_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (raw_coils_grid_view.SelectedRows.Count > 0)
                {
                    total_window_gross_weight -= raw_coils[raw_coils_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_GROSS_WEIGHT;
                    total_window_net_weight -= raw_coils[raw_coils_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_NET_WEIGHT;
                    quantity_gross_weight -= raw_coils[raw_coils_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_GROSS_WEIGHT;
                    quantity_net_weight -= raw_coils[raw_coils_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_NET_WEIGHT;
                    raw_coils.Remove(raw_coils[raw_coils_grid_view.SelectedRows[0].Index]);

                    quantity_total_number_of_coils--;
                    total_windows_number_of_coils--;

                    general_coils_no_text_box.Text = total_windows_number_of_coils.ToString();
                    fillcoilsgridview();
                }
                else
                {
                    MessageBox.Show("لابد من تحديد العنصر المراد حذفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("لابد من تحديد العنصر المراد حذفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }
        private void add_new_quantity_btn_Click(object sender, EventArgs e)
        {
            if (raw_coils.Count > 0)
            {


                coils_quantites.Add(new SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS
                {
                    SH_ADDITION_DATE = DateTime.Parse(addition_date_text_box.Text),
                    SH_ITEM_TOTAL_GROSS_WEIGHT = quantity_gross_weight,
                    SH_ITEM_TOTAL_NO_COILS = quantity_total_number_of_coils,
                    SH_ITEM_TOTAL_NET_WEIGHT = quantity_net_weight,
                    QuantityCoils = raw_coils
                });
                raw_coils = new List<SH_COILS_RAW_MATERIAL>();
                quantity_net_weight = 0;
                quantity_gross_weight = 0;
                quantity_total_number_of_coils = 0;
                fillcoilsgridview();
                fillcoilsquantity();
            }else
            {
                MessageBox.Show("إدخل الCoils  المرد إضافتها فى الكمية", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }
        void fillcoilsquantity()
        {
            coil_quantities_grid_view.Rows.Clear();
            if (coils_quantites.Count >0)
            {
                for (int i = 0; i < coils_quantites.Count; i++)
                {
                    coil_quantities_grid_view.Rows.Add(new string[] { (i+1).ToString(), coils_quantites[i].QuantityCoils[0].SH_ITEM_THICKNESS.ToString() , coils_quantites[i].QuantityCoils[0].SH_ITEM_WIDTH.ToString(), coils_quantites[i].QuantityCoils[0].SH_ITEM_FINISH , coils_quantites[i].QuantityCoils[0].SH_ITEM_COATING , coils_quantites[i].QuantityCoils[0].SH_ITEM_TEMPER , coils_quantites[i].SH_ITEM_TOTAL_NO_COILS.ToString() , coils_quantites[i].SH_ITEM_TOTAL_GROSS_WEIGHT.ToString() , coils_quantites[i].SH_ITEM_TOTAL_NET_WEIGHT.ToString() });
                }
            }
            total_gross_weight_text_box.Text = total_window_gross_weight.ToString();
            total_net_weight_text_box.Text = total_window_net_weight.ToString();
        }
        private void delete_quantites_from_grid_view_Click(object sender, EventArgs e)
        {
            try
            {
            if (coil_quantities_grid_view.SelectedRows.Count > 0)
            {
                    if (coils_quantites.Count > 0)
                    {
                        total_window_gross_weight -= coils_quantites[coil_quantities_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_GROSS_WEIGHT;
                        total_window_net_weight -= coils_quantites[coil_quantities_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_NET_WEIGHT;
                        total_windows_number_of_coils -= coils_quantites[coil_quantities_grid_view.SelectedRows[0].Index].SH_ITEM_TOTAL_NO_COILS;
                        general_coils_no_text_box.Text = total_windows_number_of_coils.ToString();
                        coils_quantites.Remove(coils_quantites[coil_quantities_grid_view.SelectedRows[0].Index]);
                        
                        fillcoilsquantity();
                    }
                    else
                    {
                        MessageBox.Show("لا يوجد لديك كميات للCoils", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    }
                }
            else
            {
                MessageBox.Show("لابد من تحديد الكمية المراد حذفها" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            }
            catch (Exception)
            {
                MessageBox.Show("لابد من تحديد الكمية المراد حذفها", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            }
        }
        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void add_new_raw_tn_info_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (raw_material_second_form_coils myform = new raw_material_second_form_coils())
            { 
                myform.ShowDialog();
            }
            this.Close();
        }
        private void save_coils_specifications_Click(object sender, EventArgs e)
        {
            if (DateTime.Parse(addition_date_text_box.Text) == null)
            {
                MessageBox.Show("Can't Save ");
            }
            else
            {
                saverawmaterailspaceisifications();
            }
           
        }
    }
}
