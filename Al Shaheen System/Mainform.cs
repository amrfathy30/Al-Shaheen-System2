using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public partial class Mainform : Form
    {
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
            using (addnewrowtinfd myform = new addnewrowtinfd(mEmployee , mAccount , mPermission))
            {
                myform.ShowDialog();
            }
        }

        private void إضافةصفيحخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (addnewrawtin myform = new addnewrawtin())
            {
                myform.ShowDialog();
            }
        }

        private void صرفالصفيحالخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //using (exchangerawtin myform = new exchangerawtin())
            //{
            //    myform.ShowDialog();
            //}
            using (searchinrawmaterialform myform = new searchinrawmaterialform())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةرصيدأولالمدةToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void إعداداتقواعدالبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DatabaseConnectionSettingForm myform = new DatabaseConnectionSettingForm())
            {
                myform.ShowDialog();
            }
        }

        private void الأرصدةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (raw_tin_all_spcifications myform = new raw_tin_all_spcifications())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةCoilsالصفيحToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (raw_material_second_form_coils myform = new raw_material_second_form_coils())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةعميلجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (add_new_client_company_btn myform = new add_new_client_company_btn(null))
            {
                myform.ShowDialog();
            }
        }

        private void إضافةموردجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (add_new_supply_company_form myform = new add_new_supply_company_form())
            {
                myform.ShowDialog();
            }
        }

        private void easyOpenايزيأوبنToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Easyopenaddingform myform = new Easyopenaddingform())
            {
                myform.ShowDialog();
            }
        }

        private void بياناتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_SHOW_ALL_CLIENTS==1)
            {
                using (all_clients_data myform = new all_clients_data())
                {
                    myform.ShowDialog();
                }
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
                myform.ShowDialog();
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
            using (searchinmuranparcels myform = new searchinmuranparcels())
            {
                myform.ShowDialog();
            }
        }

        private void إضافةموظفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_OPEN_REGIST_EMP==1)
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
            using (searchinprintedparcels myform = new searchinprintedparcels())
            {
                myform.ShowDialog();
            }
        }

        private void صرفالصفيحالمقصوصالمطبوعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (searchincutprintedmaterial myform = new searchincutprintedmaterial())
            {
                myform.ShowDialog();
            }
        }

        private void قاعاووشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Bottomaddingform myform = new Bottomaddingform())
            {
                myform.ShowDialog();
            }
        }

        private void pennyLeverRLTبيلأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RLTaddingform myform = new RLTaddingform())
            {
                myform.ShowDialog();
            }
        }

        private void بيلأوفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BillOffaddingform myform = new BillOffaddingform())
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

            if (mPermission.SH_IT_SERVER_SETTINGS == 1)
            {
                إعداداتقواعدالبياناتToolStripMenuItem.Visible = true;
            }else
            {
                إعداداتقواعدالبياناتToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_STOCKS == 1)
            {
                المخازنToolStripMenuItem.Visible = true;
            }else
            {

                المخازنToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_SALES == 1)
            {
                المبيعاتToolStripMenuItem.Visible = true;
            }else
            {
                المبيعاتToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_PURCHASING==1)
            {
                المشترياتToolStripMenuItem.Visible = true;
            }else
            {
                المشترياتToolStripMenuItem.Visible = false;
            }
            if (mPermission.SH_DEPARTMENT_ACCOUNTING==1)
            {
                الحساباتToolStripMenuItem.Visible = true;
            }else
            {
                الحساباتToolStripMenuItem.Visible = false;
            }
            if (mPermission.SH_DEPARTMENT_MAINTENANCE ==1)
            {
                الصيانةToolStripMenuItem.Visible = true;
            }else
            {
                الصيانةToolStripMenuItem.Visible = false;
            }
            if (mPermission.SH_DEPARTMENT_PRODUCTION==1)
            {
                أللإنتاجToolStripMenuItem.Visible = true;
            }else
            {
                أللإنتاجToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_HR==1)
            {
                المواردالبشريةToolStripMenuItem.Visible = true;
            }else
            {
                المواردالبشريةToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_OPEN_DASH_BOARD==1)
            {
                dashboardToolStripMenuItem.Visible = true;
            }else
            {
                dashboardToolStripMenuItem.Visible = false;
            }

            if (mPermission.SH_DEPARTMENT_MAINTENANCE==1)
            {
                الورشةToolStripMenuItem.Visible = true;
            }else
            {
                الورشةToolStripMenuItem.Visible = false ;
            }

        }

        private void الصفيحالخامToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mPermission.SH_RAW_TIN_MATERIAL ==1)
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

        private void الموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
