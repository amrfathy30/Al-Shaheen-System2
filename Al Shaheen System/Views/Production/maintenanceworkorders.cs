using DGVPrinterHelper;
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
    public partial class maintenanceworkorders : Form
    {

        List<SH_WORK_SHOP_WORK_ORDERS> work_shop_orders = new List<SH_WORK_SHOP_WORK_ORDERS>();

        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();
        public maintenanceworkorders(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anypermission;
        }

        void loadallshoporders()
        {
            work_shop_orders.Clear();
            try
            {
                string query = "SELECT * FROM SH_WORK_SHOP_WORK_ORDERS ";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    work_shop_orders.Add(new SH_WORK_SHOP_WORK_ORDERS() { SH_ASKED_MAN_NAME=reader["SH_ASKED_MAN_NAME"].ToString(), SH_ID=long.Parse(reader["SH_ID"].ToString()), SH_ITEM_NAME=reader["SH_ITEM_NAME"].ToString(), SH_ITEM_QUANTITY=long.Parse(reader["SH_ITEM_QUANTITY"].ToString()), SH_NOTES=reader["SH_NOTES"].ToString(), SH_START_WORK_DATE= DateTime.Parse(reader["SH_START_WORK_DATE"].ToString()), SH_WORKING_MACHINE=reader["SH_WORKING_MACHINE"].ToString(), SH_WORKING_TOTAL_HOURS=long.Parse(reader["SH_WORKING_TOTAL_HOURS"].ToString()), SH_FINISH_DATE= DateTime.Parse(reader["SH_FINISH_DATE"].ToString()), SH_WORK_STAT=long.Parse(reader["SH_WORK_STAT"].ToString()), SH_WORK_STAT_NAME=reader["SH_WORK_STAT_NAME"].ToString() });
                }
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING WORKSHOP ORDERS "+ex.ToString());
            }
        }

        void fillitemsgridview()
        {
            workshop_orders_grid_view.Rows.Clear();

            loadallshoporders();

            if (work_shop_orders.Count > 0 )
            {
                for (int i = 0; i < work_shop_orders.Count; i++)
                {
                    workshop_orders_grid_view.Rows.Add(new string[] { (i+1).ToString() , work_shop_orders[i].SH_ITEM_NAME , work_shop_orders[i].SH_ITEM_QUANTITY.ToString() , work_shop_orders[i].SH_START_WORK_DATE.ToString() , work_shop_orders[i].SH_WORKING_MACHINE , work_shop_orders[i].SH_WORKING_TOTAL_HOURS.ToString()  , work_shop_orders[i].SH_NOTES , work_shop_orders[i].SH_WORK_STAT_NAME  });
                }
               
            }




        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            long testnumber = 0;
            if (string.IsNullOrWhiteSpace(item_name_text_box.Text) || string.IsNullOrWhiteSpace(quantity_text_box.Text) || !long.TryParse(quantity_text_box.Text, out testnumber) || string.IsNullOrWhiteSpace(machinenametextbox.Text) || string.IsNullOrWhiteSpace(requested_man_name_text_box.Text) || string.IsNullOrWhiteSpace(requested_man_name_text_box.Text))
            {
                MessageBox.Show("أكمل البيانات الناقصة " ,"تحذير", MessageBoxButtons.OK , MessageBoxIcon.Warning , MessageBoxDefaultButton.Button1 , MessageBoxOptions.RtlReading);
            }
            else
            {
                try
                {
                    string query = "INSERT INTO SH_WORK_SHOP_WORK_ORDERS ";
                    query += "(SH_DATA_ENTRY_EMPLOYEE_NAME,SH_DATA_ENTRY_EMPLOYEE_ID,SH_DATA_ENTRY_USER_NAME,SH_DATA_ENTRY_USER_ID, SH_ITEM_NAME, SH_ITEM_QUANTITY, SH_WORKING_MACHINE, SH_NOTES, SH_ASKED_MAN_NAME, SH_START_WORK_DATE, SH_WORKING_TOTAL_HOURS, SH_FINISH_DATE, SH_WORK_STAT, SH_WORK_STAT_NAME)";
                    query += " VALUES(@SH_DATA_ENTRY_EMPLOYEE_NAME,@SH_DATA_ENTRY_EMPLOYEE_ID,@SH_DATA_ENTRY_USER_NAME,@SH_DATA_ENTRY_USER_ID,@SH_ITEM_NAME,@SH_ITEM_QUANTITY,@SH_WORKING_MACHINE,@SH_NOTES,@SH_ASKED_MAN_NAME,@SH_START_WORK_DATE,@SH_WORKING_TOTAL_HOURS,@SH_FINISH_DATE,@SH_WORK_STAT,@SH_WORK_STAT_NAME) ";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);

                    cmd.Parameters.AddWithValue("@SH_ITEM_NAME", item_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ITEM_QUANTITY", long.Parse(quantity_text_box.Text));
                    cmd.Parameters.AddWithValue("@SH_WORKING_MACHINE", machinenametextbox.Text);
                    cmd.Parameters.AddWithValue("@SH_NOTES", notes_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_ASKED_MAN_NAME", requested_man_name_text_box.Text);
                    cmd.Parameters.AddWithValue("@SH_START_WORK_DATE", DateTime.Parse(requesting_date_time_picker.Text));
                    cmd.Parameters.AddWithValue("@SH_WORKING_TOTAL_HOURS", 0);
                    cmd.Parameters.AddWithValue("@SH_FINISH_DATE", DateTime.Now);
                    cmd.Parameters.AddWithValue("@SH_WORK_STAT", 0);
                    cmd.Parameters.AddWithValue("@SH_WORK_STAT_NAME", "لم يتم ");
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_ID", mAccount.SH_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_USER_NAME", mAccount.SH_EMP_USER_NAME);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_ID", mAccount.SH_EMP_ID);
                    cmd.Parameters.AddWithValue("@SH_DATA_ENTRY_EMPLOYEE_NAME", mAccount.SH_EMP_NAME);
                    cmd.ExecuteNonQuery();
                    myconnection.closeConnection();
                    MessageBox.Show("تم الحفظ" , "معلومات" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                    fillitemsgridview();
                    
                }

                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE SAVING NEW WORK ORDER NUMBERS " + ex.ToString());
                }
            }
        }

        private void job_Completed_button_Click(object sender, EventArgs e)
        {
            if (workshop_orders_grid_view.SelectedRows.Count > 0)
            {
                long work_order_id = work_shop_orders[workshop_orders_grid_view.SelectedRows[0].Index].SH_ID;

                try
                {
                    var hours = (DateTime.Now - work_shop_orders[workshop_orders_grid_view.SelectedRows[0].Index].SH_START_WORK_DATE).TotalHours;
                    string query = "UPDATE SH_WORK_SHOP_WORK_ORDERS SET SH_WORK_STAT = @SH_WORK_STAT , SH_WORK_STAT_NAME = @SH_WORK_STAT_NAME , SH_FINISH_DATE = @SH_FINISH_DATE ,SH_WORKING_TOTAL_HOURS = @SH_WORKING_TOTAL_HOURS  ";
                    DatabaseConnection myconnection = new DatabaseConnection();
                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);
                    cmd.Parameters.AddWithValue("@SH_WORK_STAT" , 1);
                    cmd.Parameters.AddWithValue("@SH_WORK_STAT_NAME" , "تم");
                    cmd.Parameters.AddWithValue("@SH_FINISH_DATE" , DateTime.Now);//DATEDIFF(hh, @date1, @date2) as Hours_Difference
                    cmd.Parameters.AddWithValue("@SH_WORKING_TOTAL_HOURS" , hours);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم التعديل", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    myconnection.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE UPDATING WORK_SHOP ORDER STATUS "+ex.ToString());
                }

                fillitemsgridview();
            }
        }

        private void maintenanceworkorders_Load(object sender, EventArgs e)
        {
            fillitemsgridview();
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();

            printer.Title = "مصنع ال شاهين للتجارة والصناعة";

            printer.SubTitle = "تقرير عام لأوامر الشغل الخاس بالورشة ";

            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit |

                StringFormatFlags.NoClip;

            printer.PageNumbers = true;

            printer.PageNumberInHeader = false;

            printer.PorportionalColumns = true;

            printer.HeaderCellAlignment = StringAlignment.Near;

            printer.Footer = "    ال شاهين للتجارة والصناعة     "  + " إسم طالب التقرير :    " +mAccount.SH_EMP_NAME;

            printer.FooterSpacing = 15;
            printer.PrintNoDisplay(workshop_orders_grid_view);
        }
    }
}
