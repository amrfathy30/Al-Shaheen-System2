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
    public partial class allproductionrequirementsforms : Form
    {
        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        public allproductionrequirementsforms(SH_EMPLOYEES anyemp,SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPerm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPerm;
        }

        private void allproductionrequirementsforms_Load(object sender, EventArgs e)
        {
            //production_requirements_icons.ImageSize
            listView1.Items.Clear();
           // listView1.HeaderStyle = ColumnHeaderStyle.None;
            
           
            ColumnHeader h2 = new ColumnHeader();
            h2.Text = "إسم الصنف";
            h2.Width = 100;
            ColumnHeader h3 = new ColumnHeader();
            h3.Text = "رصيد الشركة";
            h3.Width = 150;
            ColumnHeader h4 = new ColumnHeader();
            h4.Text = "رصيد لدى العملاء";
            h4.Width = 150;
            listView1.Columns.AddRange(new ColumnHeader[]
            {h2,h3,h4 });
            ListViewItem anyitem = new ListViewItem(new string[]
            {
                "بالتات" ,
            "الرصيد فى الشركة : "+"250",
            "الرصيد لدى العملاء : " + "1120"}, 0);
            
            
            ListViewItem anyitem2 = new ListViewItem(new string[]
          {"كرتون",
            "الرصيد فى الشركة : " + "1526",
            "الرصيد لدى العملاء : " +"0" }, 1);
            ListViewItem anyitem3 = new ListViewItem(new string[]
        {"سلك لحام",
            "الرصيد فى الشركة : " + "1526",
            "الرصيد لدى العملاء : " +"0" }, 2);
            ListViewItem anyitem4 = new ListViewItem(new string[]
       {"إستريتش",
            "الرصيد فى الشركة : " + "1526",
            "الرصيد لدى العملاء : " +"0" }, 3);
            ListViewItem anyitem5 = new ListViewItem(new string[]
        {"فواصل كرتون",
            "الرصيد فى الشركة : " + "1526",
            "الرصيد لدى العملاء : " +"0" }, 4);
            ListViewItem anyitem6 = new ListViewItem(new string[]
        {"الوش الخشب",
            "الرصيد فى الشركة : " + "1526",
            "الرصيد لدى العملاء : " +"0" }, 5);
            listView1.Items.Add(anyitem);
            listView1.Items.Add(anyitem2);
            listView1.Items.Add(anyitem3);
            listView1.Items.Add(anyitem4);
            listView1.Items.Add(anyitem5);
            listView1.Items.Add(anyitem6);
            //int res = listView1.TopItem.Bounds.Top;
            //int res = listView1.Items[0].Bounds.Top;
        }

        private void listView1_Click(object sender, EventArgs e)
        {

            var firstSelectedItem = listView1.SelectedItems[0];
            switch (firstSelectedItem.Index)
            {
                case 0:
                    {
                        pallets_portal_form myform = new pallets_portal_form(mEmployee,mAccount,mPermission);
                        myform.Show();
                        break;
                    }
                case 4:
                    {
                        cartondividersportalform myform = new cartondividersportalform(mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                case 5:
                    {
                        woodenfacepotalform myform = new woodenfacepotalform(mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                default:
                    break;
            }

        } 
    }
}
