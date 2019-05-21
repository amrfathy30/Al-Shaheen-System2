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
using DGVPrinterHelper;

namespace Al_Shaheen_System
{
    public partial class searchinrawmaterialform : Form
    {
        List<SH_RAW_MATERIAL_PARCEL> parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        List<SH_RAW_MATERIAL_PARCEL> exch_parcels = new List<SH_RAW_MATERIAL_PARCEL>();
        List<SH_SHAHEEN_STOCK> stocks = new List<SH_SHAHEEN_STOCK>();
        List<string> item_types = new List<string>();
        List<string> item_coating = new List<string>();
        List<string> item_finish = new List<string>();
        List<string> item_temper = new List<string>();

        long exchange_total_no_sheets = 0;
        double exchange_total_net_weight = 0;


        long mtotal_number_of_parcels = 0;
        long mtotal_number_of_sheets = 0;
        double mtotoal_net_weight = 0;
        public searchinrawmaterialform()
        {
            InitializeComponent();
        }

        void loadallstocks()
        {
            try
            {
                string query = "SELECT DISTINCT SH_STOCK_NAME FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID NOT IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL) ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    stocks.Add(new SH_SHAHEEN_STOCK { SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString()});
                }

                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO WHILE GETTING STOCKS DATA FROM DB " + ex.ToString());
            }
        }

        void fillstockscombobox()
        {
            stocks.Clear();
            loadallstocks();
            stocks_combo_box.Items.Clear();
            if (stocks.Count <= 0)
            {

            }
            else
            {
                for (int i = 0; i < stocks.Count; i++)
                {
                    stocks_combo_box.Items.Add(stocks[i].SH_STOCK_NAME);
                }
            }
        }



        void fillitemtypescombobox()
        {
            item_types.Clear();

            try
            {
                string query = "SELECT DISTINCT SH_ITEM_TYPE FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID NOT IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL )";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item_types.Add(reader["SH_ITEM_TYPE"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ITEM TYPES COMBO BOX "+ex.ToString());
            }

            if (item_types.Count > 0)
            {
                item_types_combo_box.Items.Clear();
                for (int i = 0; i < item_types.Count; i++)
                {
                    item_types_combo_box.Items.Add(item_types[i]);
                }
            }


        }

        void fillitemcoatingcombobox()
        {
            item_coating.Clear();
            try
            {
                string query = "SELECT DISTINCT SH_ITEM_COATING FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID NOT IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL )";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item_coating.Add(reader["SH_ITEM_COATING"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ITEM COATINGS "+ex.ToString());
            }

            if (item_coating.Count > 0)
            {
                coating_text_box.Items.Clear();
                for (int i = 0; i < item_coating.Count; i++)
                {
                    coating_text_box.Items.Add(item_coating[i]);
                }
            }


        }

        void fillitemfinishcombobox()
        {
            item_finish.Clear();
            try
            {
                string query = "SELECT DISTINCT SH_ITEM_FINISH FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID NOT IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL )";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item_finish.Add(reader["SH_ITEM_FINISH"].ToString());
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING ITEM FINISH COMBO BOX "+ex.ToString());
            }

            if (item_finish.Count>0)
            {
                finish_combo_box.Items.Clear();
                for (int i = 0; i < item_finish.Count; i++)
                {
                    finish_combo_box.Items.Add(item_finish[i]);
                }
            }
           

        }

        void fillitemtempercombobox()
        {
            item_temper.Clear();
            try
            {
                string query = "SELECT DISTINCT SH_ITEM_TEMPER FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID NOT IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL )";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    item_temper.Add(reader["SH_ITEM_TEMPER"].ToString());
                }
                myconnection.closeConnection();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING TEMPER DATA FROM DB "+ex.ToString());
            }

            if (item_temper.Count > 0)
            {
                tempet_combo_box.Items.Clear();
                for (int i = 0; i < item_temper.Count; i++)
                {
                    tempet_combo_box.Items.Add(item_temper[i]);
                }
            }
           

        }



        void fillparcelsgridview()
        {
            raw_parcels_grid_view.Rows.Clear();
            if (parcels.Count > 0)
            {
                for (int i = 0; i < parcels.Count; i++)
                {
                    raw_parcels_grid_view.Rows.Add(new string[] { (i+1).ToString() , parcels[i].SH_ID.ToString() , parcels[i].SH_ITEM_LENGTH.ToString() , parcels[i].SH_ITEM_WIDTH.ToString() , parcels[i].SH_ITEM_THICKNESS.ToString() , parcels[i].SH_ITEM_CODE , parcels[i].SH_ITEM_TEMPER , parcels[i].SH_ITEM_COATING , parcels[i].SH_ITEM_TYPE , parcels[i].SH_STOCK_NAME, parcels[i].SH_ITEM_SHEET_WEIGHT.ToString(), parcels[i].SH_ITEM_NUMBER_OF_SHEETS.ToString() ,  parcels[i].SH_ITEM_PARCEL_NET_WEIGHT.ToString() , parcels[i].SH_ITEM_PARCEL_GROSS_WEIGHT.ToString()   });
                }
            }else
            {
                MessageBox.Show("لا يوجد بيانات " , "معلومات " , MessageBoxButtons.OK , MessageBoxIcon.Information , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading );
            }
        }


        private void search_btn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            parcels.Clear();
            mtotal_number_of_parcels = 0;
            mtotal_number_of_sheets = 0;
            mtotoal_net_weight = 0;
            total_number_of_sheets.Text = 0.ToString();
            total_number_of_packages.Text = 0.ToString();
            total_net_weight_text_box.Text = 0.ToString();
            double testnumber = 0;
            bool length = false;
            bool width = false;
            bool thickness = false;
            bool temper = false;
            bool coating = false;
            bool code = false;
            bool finish = false;
            bool type = false;
            bool stock = false;
            string mlength = "";
            string mwidth = "";
            string mthickness = "";
            string mtemper = "";
            string mcaoting = "";
            string mcode = "";
            string mfinish = "";
            string mtype = "";
            string mStock ="" ;




            if (string.IsNullOrEmpty(item_length_text_box.Text))
            {
                mlength = " ";
            }
            else if (double.TryParse(item_length_text_box.Text, out testnumber))
            {
                length = true;
                mlength = " AND ( SH_ITEM_LENGTH = @SH_ITEM_LENGTH) ";
            }
            else
            {
                mlength = " ";
            }

            if (string.IsNullOrEmpty(item_width_text_box.Text))
            {
                mwidth = " ";
            }
            else if (double.TryParse(item_width_text_box.Text, out testnumber))
            {
                width = true;
                mwidth = " AND ( SH_ITEM_WIDTH = @SH_ITEM_WIDTH ) ";
            }
            else
            {
                mwidth = " ";
            }
            if (string.IsNullOrEmpty(item_thickness_text_box.Text))
            {
                mthickness = " ";
            }
            else if (double.TryParse(item_thickness_text_box.Text, out testnumber))
            {
                thickness = true;
                mthickness = " AND ( SH_ITEM_THICKNESS = @SH_ITEM_THICKNESS )";
            }
            else
            {
                mthickness = " ";
            }

            if (string.IsNullOrEmpty(stocks_combo_box.Text))
            {
                mStock = " ";
            }else
            {
                stock = true;
                mStock = " AND ( SH_STOCK_NAME LIKE N'%" + stocks[stocks_combo_box.SelectedIndex].SH_STOCK_NAME + "%')";
            }


            if (string.IsNullOrEmpty(tempet_combo_box.Text))
            {
                mtemper = " ";
            }
            else
            {
                temper = true;

                mtemper = " AND ( SH_ITEM_TEMPER LIKE N'%"+item_temper[tempet_combo_box.SelectedIndex]+"%')";
            }

            if (string.IsNullOrEmpty(item_code_text_box.Text))
            {
                mcode = " ";
            }
            else
            {
                code = true;
                mcode = " AND ( SH_ITEM_CODE  LIKE N'%"+item_code_text_box.Text+"%')";
            }

            if (string.IsNullOrEmpty(finish_combo_box.Text))
            {

                mfinish = " ";
            }
            else
            {
                finish = true;
                mfinish = "AND (  SH_ITEM_FINISH LIKE N'%" + item_finish[finish_combo_box.SelectedIndex]+"%')";
            }

            if (string.IsNullOrEmpty(item_types_combo_box.Text))
            {
                mtype = " ";
                type = false;
            }
            else
            {    
                type = true;
                //OR  SH_ITEM_TYPE LIKE N'% @SH_ITEM_TYPE %' OR  SH_ITEM_TYPE LIKE N' @SH_ITEM_TYPE %'
                mtype = " AND ( SH_ITEM_TYPE LIKE N'%"+ item_types[item_types_combo_box.SelectedIndex]+ "%' )";
            }
            if (string.IsNullOrEmpty(coating_text_box.Text))
            {
                mcaoting = " ";
            }
            else
            {
                coating = true;
                mcaoting = "  AND ( SH_ITEM_COATING LIKE N'%"+item_coating[coating_text_box.SelectedIndex]+"%')";
            }

            //+mlength + mwidth + mthickness + mcode + mfinish + mtemper + mtype + mcaoting +
            try
            {
             //   string query = "SELECT * FROM  SH_RAW_MATERIAL_PARCEL WHERE  (SH_ID NOT IN (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL) )" + mlength + mwidth + mthickness + mcode + mfinish + mtemper + mtype + mcaoting ;
                string query = "SELECT * FROM SH_RAW_MATERIAL_PARCEL WHERE SH_ID not in (SELECT SH_RAW_MATERIAL_PARCEL_ID FROM SH_PACKAGES_DISBURSED_RAW_MATERIAL )" + mlength + mwidth + mthickness + mcode + mfinish + mtemper + mtype + mcaoting+ mStock;

                

                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                if (length)
                {
                    cmd.Parameters.AddWithValue("@SH_ITEM_LENGTH", double.Parse(item_length_text_box.Text));
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
                   // cmd.Parameters.AddWithValue("@SH_ITEM_CODE", item_code_text_box.Text);
                }
                if (temper)
                {
                   // cmd.Parameters.AddWithValue("@SH_ITEM_TEMPER", item_temper[tempet_combo_box.SelectedIndex]);
                }
                if (coating)
                {
                   // cmd.Parameters.AddWithValue("@SH_ITEM_COATING",item_coating[coating_text_box.SelectedIndex]);
                }
                if (finish)
                {
                   // cmd.Parameters.AddWithValue("@SH_ITEM_FINISH", item_finish[finish_combo_box.SelectedIndex]);
                }
                if (type)
                {
                    //MessageBox.Show(cmd.CommandText);
                  //  cmd.Parameters.AddWithValue("@SH_ITEM_TYPE", item_types[item_types_combo_box.SelectedIndex]);
                }
              //  MessageBox.Show(cmd.Parameters.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mtotal_number_of_parcels += 1;
                    mtotal_number_of_sheets += long.Parse(reader["SH_ITEM_NUMBER_OF_SHEETS"].ToString());
                    parcels.Add(new SH_RAW_MATERIAL_PARCEL() { SH_ID = long.Parse(reader["SH_ID"].ToString()) , SH_ADDITION_DATE = DateTime.Parse(reader["SH_ADDITION_DATE"].ToString()) ,  SH_ITEM_COATING = reader["SH_ITEM_COATING"].ToString() , SH_ITEM_CODE = reader["SH_ITEM_CODE"].ToString() , SH_ITEM_FINISH = reader["SH_ITEM_FINISH"].ToString() , SH_ITEM_GROSS_WEIGHT = Math.Round(double.Parse(reader["SH_ITEM_PARCEL_GROSS_WEIGHT"].ToString()),1) , SH_ITEM_LENGTH = Math.Round(double.Parse(reader["SH_ITEM_LENGTH"].ToString()),1) , SH_ITEM_NUMBER_OF_SHEETS = long.Parse(reader["SH_ITEM_NUMBER_OF_SHEETS"].ToString()) , SH_ITEM_PARCEL_GROSS_WEIGHT = Math.Round(double.Parse(reader["SH_ITEM_PARCEL_GROSS_WEIGHT"].ToString()),1) , SH_ITEM_PARCEL_NET_WEIGHT = Math.Round(double.Parse(reader["SH_ITEM_PARCEL_NET_WEIGHT"].ToString()),1) , SH_ITEM_SHEET_WEIGHT = Math.Round(double.Parse(reader["SH_ITEM_SHEET_WEIGHT"].ToString()),1) , SH_ITEM_TEMPER = reader["SH_ITEM_TEMPER"].ToString() , SH_ITEM_TYPE = reader["SH_ITEM_TYPE"].ToString() , SH_ITEM_THICKNESS = double.Parse(reader["SH_ITEM_THICKNESS"].ToString()) , SH_ITEM_WIDTH = Math.Round(double.Parse(reader["SH_ITEM_WIDTH"].ToString()),1) , SH_STOCK_NAME = reader["SH_STOCK_NAME"].ToString() , SH_SUPPLIER_NAME = reader["SH_SUPPLIER_NAME"].ToString()  });
                    mtotoal_net_weight += double.Parse(reader["SH_ITEM_PARCEL_NET_WEIGHT"].ToString());
                }

                total_number_of_sheets.Text = mtotal_number_of_sheets.ToString();
                total_number_of_packages.Text = mtotal_number_of_parcels.ToString();
                total_net_weight_text_box.Text = String.Format("{0:0,0.0}", mtotoal_net_weight);
                myconnection.closeConnection();
                fillparcelsgridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING SEARCH RESULT FORM  "+ex.ToString());
            }
            finally
            {
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        private void exchange_btn_Click(object sender, EventArgs e)
        {
            exchange_total_no_sheets = 0;
            exchange_total_net_weight = 0;
            exch_parcels.Clear();
            if (raw_parcels_grid_view.SelectedRows.Count > 0)
            {
                for (int i = 0; i < raw_parcels_grid_view.SelectedRows.Count; i++)
                {
                    exchange_total_no_sheets += parcels[raw_parcels_grid_view.SelectedRows[i].Index].SH_ITEM_NUMBER_OF_SHEETS;
                    exchange_total_net_weight += Math.Round(parcels[raw_parcels_grid_view.SelectedRows[i].Index].SH_ITEM_PARCEL_NET_WEIGHT,2);
                    exch_parcels.Add(parcels[raw_parcels_grid_view.SelectedRows[i].Index]);
                }
                using (Exchangerawtinbasicinfo myform = new Exchangerawtinbasicinfo(exch_parcels , exchange_total_no_sheets , exchange_total_net_weight))
                {
                    myform.ShowDialog();
                }
            }else
            {
                MessageBox.Show("الرجاء تحديد الطرود المراد صرفها" , "خطأ" , MessageBoxButtons.OK , MessageBoxIcon.Error , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            } 
        }

        private void searchinrawmaterialform_Load(object sender, EventArgs e)
        {
            fillitemtypescombobox();
            fillitemcoatingcombobox();
            fillitemfinishcombobox();
            fillitemtempercombobox();
            fillstockscombobox();
            Message_label.Text = "";
        }

        private void raw_parcels_grid_view_SelectionChanged(object sender, EventArgs e)
        {
            long no_sheets = 0;
            double net_weight = 0;
            if (raw_parcels_grid_view.SelectedRows.Count>0)
            {
                for (int i = 0; i < raw_parcels_grid_view.SelectedRows.Count; i++)
                {
                    no_sheets += parcels[raw_parcels_grid_view.SelectedRows[i].Index].SH_ITEM_NUMBER_OF_SHEETS;
                    net_weight += Math.Round(parcels[raw_parcels_grid_view.SelectedRows[i].Index].SH_ITEM_PARCEL_NET_WEIGHT,2);
                }
                Message_label.Text = "عدد الطرود :  ("+ raw_parcels_grid_view.SelectedRows.Count +" ) "+ "عدد الافرخ : " + no_sheets.ToString() + " "+" الوزن الصافى : "+ String.Format("{0:0,0.0}", net_weight)+" كجم";
            }
        }

        private void item_thickness_text_box_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(item_thickness_text_box.Text))
            {

            }else
            {
                double num = double.Parse(item_thickness_text_box.Text);
                item_thickness_text_box.Text = num.ToString();
            }
        }

        Bitmap bmp;
        private void print_grid_view_btn_Click(object sender, EventArgs e)
        {
            //int height = raw_parcels_grid_view.Height;
            //raw_parcels_grid_view.Height = raw_parcels_grid_view.RowCount * raw_parcels_grid_view.RowTemplate.Height * 2;
            //bmp = new Bitmap(raw_parcels_grid_view.Width , raw_parcels_grid_view.Height);
            //raw_parcels_grid_view.DrawToBitmap(bmp, new Rectangle(0, 0, raw_parcels_grid_view.Width, raw_parcels_grid_view.Height));
            //raw_parcels_grid_view.Height = height;
            //printDialog1.ShowDialog();

            DGVPrinter printer = new DGVPrinter();

            printer.Title = "مصنع ال شاهين للتجارة والصناعة";

            printer.SubTitle = "تقرير عام لطرود الصفيح الخام ";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "ال شاهين للتجارة والصناعة";

            printer.FooterSpacing = 15;



            //// use saved settings

            //if (null != myprintsettings)

            //    printer.PrintDocument.PrinterSettings = myprintsettings;

            //if (null != mypagesettings)

            //    printer.PrintDocument.DefaultPageSettings = mypagesettings;



            //if (DialogResult.OK == printer.DisplayPrintDialog())  // replace DisplayPrintDialog() 

            //// with your own print dialog

            //{

            //    // save users' settings 

            //    myprintsettings = printer.PrinterSettings;

            //    mypagesettings = printer.PageSettings;



            //    // print without displaying the printdialog

                printer.PrintNoDisplay(raw_parcels_grid_view);

            }

        private void raw_parcels_grid_view_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawImage(bmp , 0,0);
        //}

        //private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        //{
           
        //}
    }

