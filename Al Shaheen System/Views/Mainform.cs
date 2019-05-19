using Al_Shaheen_System.Views.Purchasing.SupplierViews;
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
    public partial class Mainform : Form
    {
        List<SH_EXCHANGE_REQUEST_FROM_SALES> requestList = new List<SH_EXCHANGE_REQUEST_FROM_SALES>();
        SH_EMPLOYEES mEmployee = new SH_EMPLOYEES();
        SH_USER_ACCOUNTS mAccount = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS mPermission = new SH_USER_PERMISIONS();
        public Mainform(SH_EMPLOYEES anyEmployee, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyEmployee;
            mAccount = anyaccount;
            mPermission = anypermission;

        }

        private void إضافةرصيدأولالمدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewrowtinfd myform = new addnewrowtinfd(mEmployee, mAccount, mPermission);


                myform.Show();
            
        }

        private void إضافةصفيحخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewrawtin myform = new addnewrawtin();

            myform.Show();
            
        }

        private void صرفالصفيحالخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (exchangerawtin myform = new exchangerawtin())
            //{
            //    myform.ShowDialog();
            //}
            searchinrawmaterialform myform = new searchinrawmaterialform();

            myform.Show();
            
        }

        private void إضافةرصيدأولالمدةToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void إعداداتقواعدالبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseConnectionSettingForm myform = new DatabaseConnectionSettingForm();

            myform.Show();
            
        }

        private void الأرصدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raw_tin_all_spcifications myform = new raw_tin_all_spcifications();

            myform.Show();
            
        }

        private void إضافةCoilsالصفيحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raw_material_second_form_coils myform = new raw_material_second_form_coils();

            myform.Show();
            
        }

        private void إضافةعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_new_client_company_btn myform = new add_new_client_company_btn(null);

            myform.Show();
            
        }

        private void إضافةموردجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_new_supply_company_form myform = new add_new_supply_company_form();

            myform.Show();
            
        }

        private void easyOpenايزيأوبنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Easyopenaddingform myform = new Easyopenaddingform();

            myform.Show();
            
        }

        private void بياناتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_SHOW_ALL_CLIENTS == 1)
            {
                all_clients_data myform = new all_clients_data();

                myform.Show();
                
            }
          
        }

        private void إضافةمخزنجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Addnewstockform myform = new Addnewstockform())
            {
                myform.ShowDialog();
            }
        }

        private void جميعالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (allstocksform myfom = new allstocksform())
            {
                myfom.ShowDialog();
            }
        }

        private void إضافةلونجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_ADD_NEW_COLOR == 1)
            {
                using (addnewfacecolorform myform = new addnewfacecolorform())
                {
                    myform.ShowDialog();
                }
            }
        }

        private void جميعالألوانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (allfacecolors myform = new allfacecolors())
            {
                myform.Show();
            }

           


        }

        private void إToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewprinterform myform = new addnewprinterform())
            {
                myform.ShowDialog();
            }
        }

        private void جميعالمطابعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (allprintersform myform = new allprintersform())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةطولجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إضافةرصيدأولالمدةToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void إضافةصفيحمورنشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewmuranmaterialfd myform = new addnewmuranmaterialfd())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةالصفيحالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewprintingmaterialfd myform = new addnewprintingmaterialfd())
            {
                myform.ShowDialog();
            }
        }

        private void علبالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewfinishedcan myform= new addnewfinishedcan())
            {
                myform.ShowDialog();
            }
        }

        private void جميعالموريدينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (all_suppliers_data myform = new all_suppliers_data())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةالصفيحالمقصوصالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewcutprintedmaterial myform = new addnewcutprintedmaterial())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةمقصجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewcutterform myform = new addnewcutterform())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةالصفيحالمقصوصالمورنشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewcutmuranmaterial myform = new addnewcutmuranmaterial())
            {
                myform.ShowDialog();
            }
        }


        private void إضافةمقاسجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewsizesform myform = new addnewsizesform())
            {
                myform.ShowDialog();
            }
        }

        private void صرفالصفيحالمورنشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchinmuranparcels myform = new searchinmuranparcels(mAccount))
            {
                myform.ShowDialog();
            }
        }

        private void إضافةموظفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_OPEN_REGIST_EMP == 1)
            {
                using (RegistEmp myform = new RegistEmp(mEmployee , mAccount , mPermission))
                {
                    myform.ShowDialog();
                }
            }
          

        }

        private void جميعالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (getAllEmployeesFrm myform = new getAllEmployeesFrm(mEmployee , mAccount , mPermission))
            {
                myform.ShowDialog();
            }
        }

        private void جميعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Display_allUsers myform = new Display_allUsers(mEmployee, mAccount, mPermission))
            {
                myform.ShowDialog();
            }
        }

        private void البحثفىالاستلاماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchreceivedrawtinbytwodates myform = new searchreceivedrawtinbytwodates())
            {
                myform.ShowDialog();
            }
        }

        private void البحثفىالمصروفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchwexchangedrawtinbetweentwodates myform = new searchwexchangedrawtinbetweentwodates())
            {
                myform.ShowDialog();
            }
        }

        private void صرفالصفيحالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchinprintedparcels myform = new searchinprintedparcels(mAccount))
            {
                myform.ShowDialog();
            }
        }

        private void صرفالصفيحالمقصوصالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchincutprintedmaterial myform = new searchincutprintedmaterial(mAccount))
            {
                myform.ShowDialog();
            }
        }

        private void قاعاووشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewBottom myform = new addnewBottom())
            {
                myform.ShowDialog();
            }
        }

        private void pennyLeverRLTبيلأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewrlt myform = new addnewrlt();

            myform.Show();

        }

        private void بيلأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewpeeloff myform = new addnewpeeloff())
            {
                myform.ShowDialog();
            }
        }

        private void صرفالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchinfinishedproducts myform = new searchinfinishedproducts())
            {
                myform.ShowDialog();
            }
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            logged_user_name_label.Text = mAccount.SH_EMP_USER_NAME;
            loadAllClientOrdersFromSales();

            if (mPermission.SH_IT_SERVER_SETTINGS == 1)
            {
                إعداداتقواعدالبياناتToolStripMenuItem.Visible = true;
            } else
            {
                إعداداتقواعدالبياناتToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_STOCKS == 1)
            {
                المخازنToolStripMenuItem.Visible = true;
            } else
            {

                المخازنToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_SALES == 1)
            {
                المبيعاتToolStripMenuItem.Visible = true;
            } else
            {
                المبيعاتToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_PURCHASING == 1)
            {
                المشترياتToolStripMenuItem.Visible = true;
            } else
            {
                المشترياتToolStripMenuItem.Visible = false;
            }
            if (mPermission.SH_DEPARTMENT_ACCOUNTING == 1)
            {
                الحساباتToolStripMenuItem.Visible = true;
            } else
            {
                الحساباتToolStripMenuItem.Visible = false;
            }
            if (mPermission.SH_DEPARTMENT_MAINTENANCE == 1)
            {
                الصيانةToolStripMenuItem.Visible = true;
            } else
            {
                الصيانةToolStripMenuItem.Visible = false;
            }
            if (mPermission.SH_DEPARTMENT_PRODUCTION == 1)
            {
                أللإنتاجToolStripMenuItem.Visible = true;
            } else
            {
                أللإنتاجToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_HR == 1)
            {
                المواردالبشريةToolStripMenuItem.Visible = true;
            } else
            {
                المواردالبشريةToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_OPEN_DASH_BOARD == 1)
            {
                dashboardToolStripMenuItem.Visible = true;
            } else
            {
                dashboardToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_MAINTENANCE == 1)
            {
                الورشةToolStripMenuItem.Visible = true;
            } else
            {
                الورشةToolStripMenuItem.Visible = false;
            }

        }

        private void الصفيحالخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_RAW_TIN_MATERIAL == 1)
            {
                // الصفيحالخامToolStripMenuItem.ShowShortcutKeys = true;
                الصفيحالخامToolStripMenuItem.ShowDropDown();
            }
            else
            {
                // الصفيحالخامToolStripMenuItem.ShowShortcutKeys = false;
                الصفيحالخامToolStripMenuItem.HideDropDown();
            }
        }

        private void مخزنالصفيحToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إضافةقسمجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_ADD_NEW_DEPARTMENT==1)
            {
                using (AddNewDepartment myform = new AddNewDepartment(mEmployee, mAccount, mPermission))
                {
                    myform.ShowDialog();
                }
            }
        }

        private void إضافةأوامرشغلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (maintenanceworkorders myform  = new maintenanceworkorders(mEmployee, mAccount, mPermission))
            {
                myform.ShowDialog();
            }
        }

        private void إضافةلونجديدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (addnewcolorpillow myform = new addnewcolorpillow(mEmployee, mAccount, mPermission))
            {
                myform.ShowDialog();
            }
        }

        private void إضافةنوعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewtwistoftype myform = new addnewtwistoftype(mEmployee, mAccount, mPermission))
            {
                myform.ShowDialog();
            }
        }

        private void تويستأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewtwistofform myform = new addnewtwistofform())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةمقاسجديدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (addnewtwistofsize myform = new addnewtwistofsize())
            {
                myform.ShowDialog();
            }
        }

        private void غطاءبلاستيكللعبواتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewplasticcoverform myform = new addnewplasticcoverform())
            {
                myform.ShowDialog();
            }
        }

     

        private void إضافةنوعطبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addplasticmoldtype myform = new addplasticmoldtype())
            {
                myform.ShowDialog();
            }
        }

        private void طبةبلاستيكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewplasticmoldform myform = new addnewplasticmoldform())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةمقاسجديدToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            using (addnewmoldsize myform = new addnewmoldsize())
            {
                myform.ShowDialog();
            }

        }
      
        private void إضافةإستخدامجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addneweasyopenusage myform = new addneweasyopenusage())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةنوعخامةجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewmaterialtype myform = new addnewmaterialtype())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةنوعبوياتالوشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewbottelfacepaintingcolortype myform = new addnewbottelfacepaintingcolortype())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةنوعالوشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewbottlefacetype myform = new addnewbottlefacetype())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةمقاسلليدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewhandsize myform = new addnewhandsize())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةنوعيدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewhandtype myform = new addnewhandtype())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةمقاسغطاءصفيحةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewcoverplatesize myform = new addnewcoverplatesize())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةقطرقلاووظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewscrewsize myform  = new addnewscrewsize())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةإستخدامالقلاووظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewscrewusage myform = new addnewscrewusage())
            {
                myform.ShowDialog();
            }
        }

        private void وشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewfaceproduct myform = new addnewfaceproduct(mEmployee))
            {
                myform.ShowDialog();
            }
        }

        private void إضافةمقاسأيروسولجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewaerosolsize myform = new addnewaerosolsize())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةنوعأيروسولجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewaerosoltype myform = new addnewaerosoltype())
            {
                myform.ShowDialog();
            }
        }

        private void إغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void إضافةحسابجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewacccounttreeitem myform = new addnewacccounttreeitem())
            {
                myform.ShowDialog();
            }
        }

        private void عرضالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void أرصدةالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (allfinishedproductsdata myform = new allfinishedproductsdata())
            {
                myform.ShowDialog();
            }
        }

        private void جميعالأصنافالمضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (allitemsform myform = new allitemsform())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةأمرتوريدجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ClientSupplyRunOrderFrmNew myform = new ClientSupplyRunOrderFrmNew(mEmployee))
            {
                myform.ShowDialog();
            }
        }
        void loadAllClientOrdersFromSales()
        {
            requestList.Clear();

            try
            {
                string query = "select * from SH_EXCHANGE_REQUEST_FROM_SALES where SH_STATUS=0 order by SH_CLIENT_NAME";
                DatabaseConnection myconnection = new DatabaseConnection();
                myconnection.openConnection();
                SqlCommand cmd = new SqlCommand(query, DatabaseConnection.mConnection);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    requestList.Add(new SH_EXCHANGE_REQUEST_FROM_SALES() { SH_CLIENT_NAME = reader["SH_CLIENT_NAME"].ToString(), SH_CLIENT_SUPPLY_ORDER_NUM = reader["SH_CLIENT_SUPPLY_ORDER_NUM"].ToString(), SH_DATA_ENTERED_BY = reader["SH_DATA_ENTERED_BY"].ToString(), SH_ORDER_SUPPLY_WORK = reader["SH_ORDER_SUPPLY_WORK"].ToString(), SH_ID = long.Parse(reader["SH_ID"].ToString()), SH_CLIENT_ID = long.Parse(reader["SH_CLIENT_ID"].ToString()), SH_PRODUCT_NAME = reader["SH_PRODUCT_NAME"].ToString(), SH_QUANTITIY_REQUIRED = long.Parse(reader["SH_QUANTITIY_REQUIRED"].ToString()), SH_REGISTERED_DATE = DateTime.Parse(reader["SH_REGISTERED_DATE"].ToString()), SH_TOTAL_QUANTITY_IN_STOCKS = long.Parse(reader["SH_TOTAL_QUANTITY_IN_STOCKS"].ToString()), SH_STATUS = long.Parse(reader["SH_STATUS"].ToString()), SH_PRODUCT_TYPE = reader["SH_PRODUCT_TYPE"].ToString(), SH_PRODUCT_ID_SPECIFICATION = long.Parse(reader["SH_PRODUCT_ID_SPECIFICATION"].ToString()), SH_NORMAL_END_INSIDE_MURAN = reader["SH_NORMAL_END_INSIDE_MURAN"].ToString()});

                    labelNumOFReq.Text = " " + requestList.Count;

                }


                myconnection.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR WHILE GETTING CLIENT orders FROM DB " + ex.ToString());
            }

        }



        private void أوامرالتوريدلمتنفذToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (NewWorkOrdersFRm myform = new NewWorkOrdersFRm())
            {
                myform.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AllRequestOfPerfectProductFromSales frm = new AllRequestOfPerfectProductFromSales(mAccount,mEmployee);
            frm.ShowDialog();

        }

  

        private void Mainform_Activated(object sender, EventArgs e)
        {
            loadAllClientOrdersFromSales();
          labelNumOFReq.Text = " " + requestList.Count;
        }

        private void أللإنتاجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductionFrm frm = new ProductionFrm(mAccount);
            frm.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void إضافةسائقToolStripMenuItem_Click (object sender, EventArgs e)
        {
            
        }

        private void علبمنتجتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewfinishedcan myform = new addnewfinishedcan();
            myform.Show();
        }

        private void قــــــاعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewBottom myform = new addnewBottom();
            myform.Show();
        }

        private void وشToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addnewfaceproduct myform = new addnewfaceproduct(mEmployee);
            myform.Show();
        }

        private void rLTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewrlt myform = new addnewrlt();
            myform.Show();
        }

        private void إيزىأوبنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Easyopenaddingform myform = new Easyopenaddingform();
            myform.Show();
        }

        private void بيلأوفToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addnewpeeloff myform = new addnewpeeloff();
            myform.Show();
        }

        private void غطاءبلاستيكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewplasticcoverform myform = new addnewplasticcoverform();
            myform.Show();
        }

        private void طبةبلاستيكToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            addnewplasticmoldform myform = new addnewplasticmoldform();
            myform.Show();
        }

        private void إذنالإستلامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientreceivalpermissionnumberform myform = new clientreceivalpermissionnumberform(mEmployee, mAccount,mPermission);
            myform.Show();
        }

        private void إرصدةالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allfinishedproductsdata myform = new allfinishedproductsdata();
            myform.Show();
        }

        private void حسابصنفالعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientmaterialbalanceform myform = new clientmaterialbalanceform();
            myform.Show();
        }
    }
}
