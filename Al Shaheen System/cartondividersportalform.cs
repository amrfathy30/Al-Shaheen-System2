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
    public partial class cartondividersportalform : Form
    {
        SH_EMPLOYEES mEmployee;
        SH_USER_ACCOUNTS mAccount;
        SH_USER_PERMISIONS mPermission;
        public cartondividersportalform(SH_EMPLOYEES anyemp , SH_USER_ACCOUNTS anyAccount , SH_USER_PERMISIONS anyPerm)
        {
            InitializeComponent();
            mEmployee = anyemp;
            mAccount = anyAccount;
            mPermission = anyPerm;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pallets_portal_form_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            // listView1.HeaderStyle = ColumnHeaderStyle.None;


            ColumnHeader h2 = new ColumnHeader();
            h2.Text = "إسم الصنف";
            h2.Width = 100;
            ColumnHeader h3 = new ColumnHeader();
            h3.Text = "المقاس";
            h3.Width = 150;
            ColumnHeader h4 = new ColumnHeader();
            h4.Text = "الرصيد فى المخزن";
            h4.Width = 150;
            listView1.Columns.AddRange(new ColumnHeader[]
            {h2,h3,h4 });
            ListViewItem anyitem = new ListViewItem(new string[]
            {
                "فواصل كرتون" ,
            "المقاس : "+"110*120",
            "الرصيد فى المخزن : " + "0"}, 0);


            ListViewItem anyitem2 = new ListViewItem(new string[]
          {"فواصل كرتون",
             "المقاس : "+"110*130",
            "الرصيد فى المخزن : " + "0"}, 0);
            ListViewItem anyitem3 = new ListViewItem(new string[]
        { "فواصل كرتون",
            "المقاس : "+"90*135",
            "الرصيد فى المخزن : " + "0"}, 0);
            ListViewItem anyitem4 = new ListViewItem(new string[]
        { "فواصل كرتون" ,
            "المقاس : "+"80*100",
            "الرصيد فى المخزن : " + "0"}, 0);


            listView1.Items.Add(anyitem);
            listView1.Items.Add(anyitem2);
            listView1.Items.Add(anyitem3);
            listView1.Items.Add(anyitem4);

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            var currentitem = listView1.SelectedItems[0];
            switch (currentitem.Index)
            {
                case 0:
                    {
                        carton_data_profile myform = new carton_data_profile("110*120",120,110,mEmployee,mAccount,mPermission);
                        myform.Show();
                        break;
                    }
                case 1:
                    {
                        carton_data_profile myform = new carton_data_profile("110*130",130,110, mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                case 2:
                    {
                        carton_data_profile myform = new carton_data_profile("90*135", 135, 90, mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                case 3:
                    {
                        carton_data_profile myform = new carton_data_profile("80*100", 100, 80, mEmployee, mAccount, mPermission);
                        myform.Show();
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
