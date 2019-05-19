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
        public Mainform(SH_EMPLOYEES anyemp, SH_USER_ACCOUNTS anyaccount, SH_USER_PERMISIONS anypermission)
        {
            InitializeComponent();
            mEmployee = anyemp;
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
            // exchangerawtin myform = new exchangerawtin())
            //{
            //    myform.Show();
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
            Addnewstockform myform = new Addnewstockform();

            myform.Show();

        }

        private void جميعالمخازنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allstocksform myfom = new allstocksform();

            myfom.Show();

        }

        private void إضافةلونجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_ADD_NEW_COLOR == 1)
            {
                addnewfacecolorform myform = new addnewfacecolorform();

                myform.Show();

            }
        }

        private void جميعالألوانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allfacecolors myform = new allfacecolors();

            myform.Show();


        }

        private void إToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewprinterform myform = new addnewprinterform();

            myform.Show();

        }

        private void جميعالمطابعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allprintersform myform = new allprintersform();

            myform.Show();

        }

        private void إضافةطولجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void إضافةرصيدأولالمدةToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void إضافةصفيحمورنشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewmuranmaterialfd myform = new addnewmuranmaterialfd();

            myform.Show();

        }

        private void إضافةالصفيحالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewprintingmaterialfd myform = new addnewprintingmaterialfd();

            myform.Show();

        }

        private void علبالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewfinishedcan myform = new addnewfinishedcan();

            myform.Show();

        }

        private void جميعالموريدينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            all_suppliers_data myform = new all_suppliers_data();

            myform.Show();

        }

        private void إضافةالصفيحالمقصوصالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewcutprintedmaterial myform = new addnewcutprintedmaterial();

            myform.Show();

        }

        private void إضافةمقصجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewcutterform myform = new addnewcutterform();

            myform.Show();

        }

        private void إضافةالصفيحالمقصوصالمورنشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewcutmuranmaterial myform = new addnewcutmuranmaterial();

            myform.Show();

        }


        private void إضافةمقاسجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewsizesform myform = new addnewsizesform();

            myform.Show();

        }

        private void صرفالصفيحالمورنشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchinmuranparcels myform = new searchinmuranparcels();

            myform.Show();

        }

        private void إضافةموظفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_OPEN_REGIST_EMP == 1)
            {
                RegistEmp myform = new RegistEmp(mEmployee, mAccount, mPermission);

                myform.Show();

            }


        }

        private void جميعالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getAllEmployeesFrm myform = new getAllEmployeesFrm(mEmployee, mAccount, mPermission);

            myform.Show();

        }

        private void جميعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Display_allUsers myform = new Display_allUsers(mEmployee, mAccount, mPermission);

            myform.Show();

        }

        private void البحثفىالاستلاماتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchreceivedrawtinbytwodates myform = new searchreceivedrawtinbytwodates();

            myform.Show();

        }

        private void البحثفىالمصروفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchwexchangedrawtinbetweentwodates myform = new searchwexchangedrawtinbetweentwodates();

            myform.Show();

        }

        private void صرفالصفيحالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchinprintedparcels myform = new searchinprintedparcels();

            myform.Show();

        }

        private void صرفالصفيحالمقصوصالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchincutprintedmaterial myform = new searchincutprintedmaterial();

            myform.Show();

        }

        private void قاعاووشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewBottom myform = new addnewBottom();

            myform.Show();

        }

        private void pennyLeverRLTبيلأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewrlt myform = new addnewrlt();

            myform.Show();

        }

        private void بيلأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewpeeloff myform = new addnewpeeloff();

            myform.Show();

        }

        private void صرفالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (clientreceivalpermissionnumberform myform = new clientreceivalpermissionnumberform())
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
            if (mPermission.SH_ADD_NEW_DEPARTMENT == 1)
            {
                AddNewDepartment myform = new AddNewDepartment(mEmployee, mAccount, mPermission);

                myform.Show();

            }
        }

        private void إضافةأوامرشغلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            maintenanceworkorders myform = new maintenanceworkorders(mEmployee, mAccount, mPermission);

            myform.Show();

        }

        private void إضافةلونجديدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addnewcolorpillow myform = new addnewcolorpillow(mEmployee, mAccount, mPermission);

            myform.Show();

        }

        private void إضافةنوعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewtwistoftype myform = new addnewtwistoftype(mEmployee, mAccount, mPermission);

            myform.Show();

        }

        private void تويستأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewtwistofform myform = new addnewtwistofform();

            myform.Show();

        }

        private void إضافةمقاسجديدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            addnewtwistofsize myform = new addnewtwistofsize();

            myform.Show();

        }

        private void غطاءبلاستيكللعبواتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewplasticcoverform myform = new addnewplasticcoverform();

            myform.Show();

        }

     

        private void إضافةنوعطبةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addplasticmoldtype myform = new addplasticmoldtype();

            myform.Show();

        }

        private void طبةبلاستيكToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewplasticmoldform myform = new addnewplasticmoldform();

            myform.Show();

        }

        private void إضافةمقاسجديدToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            addnewmoldsize myform = new addnewmoldsize();

            myform.Show();


        }
      
        private void إضافةإستخدامجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addneweasyopenusage myform = new addneweasyopenusage();

            myform.Show();

        }

        private void إضافةنوعخامةجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewmaterialtype myform = new addnewmaterialtype();

            myform.Show();

        }

        private void إضافةنوعبوياتالوشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewbottelfacepaintingcolortype myform = new addnewbottelfacepaintingcolortype();

            myform.Show();

        }

        private void إضافةنوعالوشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewbottlefacetype myform = new addnewbottlefacetype();
            
                myform.Show();
        
    }

        private void إضافةمقاسلليدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewhandsize myform = new addnewhandsize();
            
                myform.Show();
            
        }

        private void إضافةنوعيدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewhandtype myform = new addnewhandtype();
            {
                myform.Show();
            }
        }

        private void إضافةمقاسغطاءصفيحةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewcoverplatesize myform = new addnewcoverplatesize();
            
                myform.Show();
            
        }

        private void إضافةقطرقلاووظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewscrewsize myform = new addnewscrewsize();
            
                myform.Show();
            
        }

        private void إضافةإستخدامالقلاووظToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewscrewusage myform = new addnewscrewusage();
            
                myform.Show();
            
        }

        private void وشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewfaceproduct myform = new addnewfaceproduct(mEmployee); 
            myform.Show();   
        }

        private void إضافةمقاسأيروسولجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewaerosolsize myform = new addnewaerosolsize();
            myform.Show();
        }

        private void إضافةنوعأيروسولجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewaerosoltype myform = new addnewaerosoltype();
            myform.Show(); 
        }

        private void إغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void إضافةحسابجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addnewacccounttreeitem myform = new addnewacccounttreeitem();  
            myform.Show();  
        }

        private void عرضالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void أرصدةالمنتجالتامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allfinishedproductsdata myform = new allfinishedproductsdata();       
            myform.Show(); 
        }

        private void جميعالأصنافالمضافةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allitemsform myform = new allitemsform();      
            myform.Show();     
        }

        private void إضافةأمرتوريدجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ClientSupplyRunOrderFrmNew myform = new ClientSupplyRunOrderFrmNew())
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
            NewWorkOrdersFRm myform = new NewWorkOrdersFRm();    
            myform.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (clientmaterialbalanceform myform = new clientmaterialbalanceform())
            {
                myform.ShowDialog();

            }
        }
    }
}
