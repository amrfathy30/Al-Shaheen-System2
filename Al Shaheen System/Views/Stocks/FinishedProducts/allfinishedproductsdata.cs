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
    public partial class allfinishedproductsdata : Form
    {
        List<SH_SPECIFICATION_OF_PLASTIC_MOLD> mold_specifications = new List<SH_SPECIFICATION_OF_PLASTIC_MOLD>();
        DatabaseConnection myconnection = new DatabaseConnection();

        string productname = "";

        long m = 0;

        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;

        public allfinishedproductsdata(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount , SH_USER_PERMISIONS anyperm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyaccount;
            mPermission = anyperm;
        }
      

        async Task fillmoldspecificationsgridview()
        {
            productname = "الطبة البلاستيك ";
            //await loadallplasticmoldspecifications();
            try
            { 
            DataTable myformdata = new DataTable();
            myformdata.Columns.Add("م");
            myformdata.Columns.Add("إسم العميل");
            myformdata.Columns.Add("اللون");
            myformdata.Columns.Add("المقاس");
            myformdata.Columns.Add("نوع الطبة");
            myformdata.Columns.Add("إسم التعبئة");
            myformdata.Columns.Add("إجمالى الكمية");

            myconnection.openConnection();
            SqlCommand cmd = new SqlCommand("SH_Get_ALL_PLATIC_MOLD_FULL_SPECIFICATIONS", DatabaseConnection.mConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();
            long no_rows = 0;
            while (reader.Read())
            {
                string[] mydata = new string[7];
                mydata[0] = (no_rows + 1).ToString();
                mydata[1] = (reader["SH_CLIENT_COMPANY_NAME"].ToString());
                mydata[2] = reader["SH_PILLOW_COLORS"].ToString();
                mydata[3] = reader["SH_MOLD_SIZE_VALUE"].ToString();
                mydata[4] = reader["SH_MOLD_TYPE_NAME"].ToString();
                mydata[5] = reader["SH_CONTAINER_NAME"].ToString();
                mydata[6] = String.Format("{0:0,0.0}", long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()));
                    myformdata.Rows.Add(mydata);
            }
            reader.Close();
            myconnection.closeConnection();
            finished_products_grid_view.DataSource = myformdata;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GETTING MOLD SPECIFICATIONS FROM DB "+ex.ToString());
            }

            }

        async Task fillfinishedcanspecificationsgridview()
        {
            productname = "علب المنتج التام ";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add(" العميل");
                mydatatabel.Columns.Add("الصنف");
                //size
                mydatatabel.Columns.Add("المقاس");
               
                //no_cans_per_pallet
                mydatatabel.Columns.Add("إجمالى عدد البالتات");
                mydatatabel.Columns.Add("عدد العلب بالبالتة");
                mydatatabel.Columns.Add("إجمالى عدد العلب");
             

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_FINISHED_CANS", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[7];
                    mydata[0] = (counter).ToString();
                    mydata[1] = reader["SH_CLIENT_COMPANY_NAME"].ToString();
                    mydata[2] = reader["SH_PRODUCT_NAME"].ToString();
                    mydata[3] = reader["product_size"].ToString();
                    mydata[4] = reader["NUMBER_OF_PALLETS"].ToString();
                    mydata[5] = (long.Parse(reader["TOTAL_NO_CANS"].ToString()) / long.Parse(reader["NUMBER_OF_PALLETS"].ToString())).ToString();
                    mydata[6] = reader["TOTAL_NO_CANS"].ToString();
                    mydatatabel.Rows.Add(mydata);
                   
                }
                
                reader.Close();
                myconnection.closeConnection();
                finished_products_grid_view.DataSource = mydatatabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETIING FINISHED CANS "+ex.ToString());
            }
        }

        async Task filltwistoffspecificationsgridview()
        {
            productname = " التويست أوف";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("العميل");
                mydatatabel.Columns.Add("الوجة الخارجي");
                mydatatabel.Columns.Add("الوجة الداخلى");
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("نوع التويست");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_TWIST_OFF_SPECIFICATIONS_DATA" , DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[]  mydata = new string[8];
                    mydata[0] = (counter.ToString());
                    mydata[1] = reader["SH_CLIENT_COMPANY_NAME"].ToString();
                    if (long.Parse(reader["SH_FIRST_FACE_PILLOW_OR_NOT"].ToString())==0)
                    {
                        mydata[2] = reader["SH_CLIENT_PRODUCT_NAME"].ToString();
                    } else
                    {
                        mydata[2] = reader["SH_PILLOW_COLORS"].ToString();
                    }
                    mydata[3] = reader["SH_FACE_COLOR"].ToString();
                    mydata[4] = reader["SH_TWIST_SIZE"].ToString();
                    mydata[5] = reader["SH_TWIST_TYPE"].ToString();
                    mydata[6] = reader["SH_CONTAINER_NAME"].ToString();
                    mydata[7] = reader["SH_TOTAL_NO_TEMS"].ToString();
                    mydatatabel.Rows.Add(mydata);
                }
                reader.Close();
                myconnection.closeConnection();
                finished_products_grid_view.DataSource = mydatatabel;
            }
            catch (Exception EX)
            {

                MessageBox.Show("ERROR WHILE GETTING TWIST OFF DATA "+EX.ToString());
            }
        }

        async Task fillRltspecificationgridview()
        {
            productname = "RLT ";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("نوع الخام");
                mydatatabel.Columns.Add("الاستخدام");
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("حالة الطباعة");
                mydatatabel.Columns.Add("الوجة الأول");
                mydatatabel.Columns.Add("الوجة الثانى");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFICATION_OF_RLT", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[9];
                    mydata[0] = (counter).ToString();
                    mydata[1] = reader["SH_RAW_MATERIAL_TYPE"].ToString();
                    mydata[2] = reader["SH_USAGE"].ToString();
                    mydata[3] = reader["SIZE_NAME"].ToString();
                    mydata[4] = reader["SH_PRINTING_TYPE_NAME"].ToString();
                    if (long.Parse(reader["SH_PRINTING_TYPE"].ToString()) == 0)
                    {
                        mydata[5] = reader["CLIENT_PRODUCT_NAME"].ToString();
                        mydata[6] = reader["PRODUCT_SECOND_FACE"].ToString();
                    }
                    else
                    {
                        mydata[5] = reader["FIRST_FACE"].ToString();
                        mydata[6] = reader["SECOND_FACE"].ToString();
                    }

                    mydata[7] = reader["SH_CONTAINER_NAME"].ToString();
                    mydata[8] = String.Format("{0:0,0.0}", long.Parse(reader["NO_ITEMS"].ToString()));
                    mydatatabel.Rows.Add(mydata);
                }


                reader.Close();
                myconnection.closeConnection();
                finished_products_grid_view.DataSource = mydatatabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING rlt SPECIFICATIONS " + ex.ToString());
            }

        }

        async Task fillPeelOffspecificationsgridview()
        {
            productname = "بيل أوف ";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("نوع الخام");
                mydatatabel.Columns.Add("الاستخدام");
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("حالة الطباعة");
                mydatatabel.Columns.Add("الوجة الأول");
                mydatatabel.Columns.Add("الوجة الثانى");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SH_SPECIFICATION_OF_PEEL_OFF", DatabaseConnection.mConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[9];
                    mydata[0] = (counter).ToString();
                    mydata[1] = reader["SH_RAW_MATERIAL_TYPE"].ToString();
                    mydata[2] = reader["SH_USAGE"].ToString();
                    mydata[3] = reader["SIZE_NAME"].ToString();
                    mydata[4] = reader["SH_PRINTING_TYPE_NAME"].ToString();
                    if (long.Parse(reader["SH_PRINTING_TYPE"].ToString()) == 0)
                    {
                        mydata[5] = reader["CLIENT_PRODUCT_NAME"].ToString();
                        mydata[6] = reader["PRODUCT_SECOND_FACE"].ToString();
                    }
                    else
                    {
                        mydata[5] = reader["FIRST_FACE"].ToString();
                        mydata[6] = reader["SECOND_FACE"].ToString();
                    }

                    mydata[7] = reader["SH_CONTAINER_NAME"].ToString();
                    mydata[8] = String.Format("{0:0,0.0}", long.Parse(reader["NO_ITEMS"].ToString()));
                    mydatatabel.Rows.Add(mydata);
                }


                reader.Close();
                myconnection.closeConnection();
                finished_products_grid_view.DataSource = mydatatabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING PEEL OFF SPECIFICATIONS " + ex.ToString());
            }

        }

        async Task fillbottomspecifications()
        {
            productname = "القاع ";
            try
                {
                    DataTable mydatatabel = new DataTable();
                    mydatatabel.Columns.Add("م");
                    mydatatabel.Columns.Add("نوع الخام");
                    mydatatabel.Columns.Add("الاستخدام");
                    mydatatabel.Columns.Add("المقاس");
                    mydatatabel.Columns.Add("حالة الطباعة");
                    mydatatabel.Columns.Add("الوجة الأول");
                    mydatatabel.Columns.Add("الوجة الثانى");
                    mydatatabel.Columns.Add("التعبئة");
                    mydatatabel.Columns.Add("إجمالى الكمية");

                    myconnection.openConnection();
                    SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFICATION_OF_BOTTOM", DatabaseConnection.mConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    long counter = 0;
                    while (reader.Read())
                    {
                        counter++;
                        string[] mydata = new string[9];
                        mydata[0] = (counter).ToString();
                        mydata[1] = reader["SH_RAW_MATERIAL_TYPE"].ToString();
                        mydata[2] = reader["SH_USAGE"].ToString();
                        mydata[3] = reader["SIZE_NAME"].ToString();
                        mydata[4] = reader["SH_PRINTING_TYPE_NAME"].ToString();
                        if (long.Parse(reader["SH_PRINTING_TYPE"].ToString()) == 0)
                        {
                            mydata[5] = reader["CLIENT_PRODUCT_NAME"].ToString();
                            mydata[6] = reader["PRODUCT_SECOND_FACE"].ToString();
                        }
                        else
                        {
                            mydata[5] = reader["FIRST_FACE"].ToString();
                            mydata[6] = reader["SECOND_FACE"].ToString();
                        }

                        mydata[7] = reader["SH_CONTAINER_NAME"].ToString();
                       mydata[8] = String.Format("{0:0,0.0}", long.Parse(reader["NO_ITEMS"].ToString()));
                        mydatatabel.Rows.Add(mydata);
                    }


                    reader.Close();
                    myconnection.closeConnection();
                    finished_products_grid_view.DataSource = mydatatabel;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR WHILE GETTING PEEL OFF SPECIFICATIONS " + ex.ToString());
                }
            
        }
       
        
        async Task filleasyopenspecifications()
        {
            productname = "الإيزى أوبن ";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("نوع الخام");
                mydatatabel.Columns.Add("الاستخدام");
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("حالة الطباعة");
                mydatatabel.Columns.Add("الوجة الأول");
                mydatatabel.Columns.Add("الوجة الثانى");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");

                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SPECIFICATION_OF_EASY_OPEN", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[9];
                    mydata[0] = (counter).ToString();
                    mydata[1] = reader["SH_RAW_MATERIAL_TYPE"].ToString();
                    mydata[2] = reader["SH_USAGE"].ToString();
                    mydata[3] = reader["SIZE_NAME"].ToString();
                    mydata[4] = reader["SH_PRINTING_TYPE_NAME"].ToString();
                    if (long.Parse(reader["SH_PRINTING_TYPE"].ToString()) == 0)
                    {
                        mydata[5] = reader["CLIENT_PRODUCT_NAME"].ToString();
                        mydata[6] = reader["PRODUCT_SECOND_FACE"].ToString();
                    }
                    else
                    {
                        mydata[5] = reader["FIRST_FACE"].ToString();
                        mydata[6] = reader["SECOND_FACE"].ToString();
                    }

                    mydata[7] = reader["SH_CONTAINER_NAME"].ToString();
                    mydata[8] = String.Format("{0:0,0.0}", long.Parse(reader["NO_ITEMS"].ToString()));
                    mydatatabel.Rows.Add(mydata);
                }


                reader.Close();
                myconnection.closeConnection();
                finished_products_grid_view.DataSource = mydatatabel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING EASY OPEN SPECIFICATIONS " + ex.ToString());
            }
        }


        async Task getallgeneral_face_properties()
        {
            productname = "الوش ";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("نوع الصنف");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("إجمالى عدد التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_GENERAL_SPECIFICATION_BOTTEL_FACE", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[5];
                    mydata[0] = (counter).ToString();
                    mydata[1] =  reader["SH_BOTTEL_FACE_TYPE_NAME"].ToString();
                    mydata[2] =  reader["SH_CONTAINER_NAME"].ToString();
                    mydata[3] = reader["SH_NO_CONTAINERS"].ToString();
                    mydata[4] = String.Format("{0:0,0.0}", long.Parse(reader["SH_TOTAL_NO_ITEMS"].ToString()));
                    mydatatabel.Rows.Add(mydata);
                }
                finished_products_grid_view.DataSource = mydatatabel;
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GettInG BOTTEL FACE GENERAL INFORMATION "+ex.ToString());
            }
        }

        async Task getallplasticcoverspecifications()
        {
            productname = "الغطاء البلاستيك ";
            try
            {
                DataTable mydatatabel = new DataTable();
                mydatatabel.Columns.Add("م");
                mydatatabel.Columns.Add("إسم العميل");
                mydatatabel.Columns.Add("المقاس");
                mydatatabel.Columns.Add("اللون");
                mydatatabel.Columns.Add("التعبئة");
                mydatatabel.Columns.Add("إجمالى عدد التعبئة");
                mydatatabel.Columns.Add("إجمالى الكمية");
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand("SH_GET_ALL_SH_SPECIFICATION_OF_PLASTIC_COVER", DatabaseConnection.mConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                long counter = 0;
                while (reader.Read())
                {
                    counter++;
                    string[] mydata = new string[7];
                    mydata[0] = (counter).ToString();
                    mydata[1] = reader["CLIENT_NAME"].ToString();
                    mydata[2] = reader["SIZE_NAME"].ToString();
                    mydata[3] = reader["PILLOW_COLOR_NAME"].ToString();
                    mydata[4] = reader["SH_CONTAINER_NAME"].ToString();
                    mydata[5] = reader["NO_ITEMS"].ToString();
                    mydata[6] = String.Format("{0:0,0.0}", long.Parse(reader["TOTAL_NO_ITEMS"].ToString()));
          
                    mydatatabel.Rows.Add(mydata);
                }
                finished_products_grid_view.DataSource = mydatatabel;
                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHIle GettInG BOTTEL FACE GENERAL INFORMATION " + ex.ToString());
            }


        }

        private async void finished_can_btn_Click(object sender, EventArgs e)
        {
            m = 0;
            await fillfinishedcanspecificationsgridview();
        }

        private async void mold_btn_Click(object sender, EventArgs e)
        {
            m = -1;
            await fillmoldspecificationsgridview();
        }

        private async void rlt_btn_Click(object sender, EventArgs e)
        {
            m = 3;
            await fillRltspecificationgridview();
        }

        private async void twist_of_btn_Click(object sender, EventArgs e)
        {
            m = -1;
            await filltwistoffspecificationsgridview();
        }

        private async void peel_off_btn_Click(object sender, EventArgs e)
        {
            m = 4;
            await fillPeelOffspecificationsgridview();
        }

        private async void bottom_btn_Click(object sender, EventArgs e)
        {
            m = 1;
            await fillbottomspecifications();
        }

        private async void easy_open_btn_Click(object sender, EventArgs e)
        {
            m = 2;
            await filleasyopenspecifications();
        }

        private async void general_face_properties_Click(object sender, EventArgs e)
        {
            m = -1;
            await getallgeneral_face_properties();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            switch (m)
            {
                case 0:
                    {
                        //finishedcans
                        printfinishedcanstotalbalanceform myform = new printfinishedcanstotalbalanceform(mEmployee,mAccount,mPermission);
                        myform.Show();
                        break;
                    }
                case 1:
                    {
                        //bottom
                        printbottomtotalbalanceform myform = new printbottomtotalbalanceform(mEmployee,mAccount,mPermission);
                        myform.Show();
                        break;
                    }
                case 2:
                    {
                        //easy open 
                        printeasyopentotalbalanceform myform = new printeasyopentotalbalanceform(mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                case 3:
                    {
                        //rlt
                        printrlttotalbalanceform myform = new printrlttotalbalanceform(mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                case 4:
                    {
                        //peel off 
                        printpeelofftotalbalanceform myform = new printpeelofftotalbalanceform(mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                case 5:
                    {
                        //plastic cover
                        printplasticcovertotalbalanceform myform = new printplasticcovertotalbalanceform(mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                default:
                    break;
            }

        }

        private async void plastic_cover_btn_Click(object sender, EventArgs e)
        {
            m = 5;
            await getallplasticcoverspecifications();
        }
    }
}
