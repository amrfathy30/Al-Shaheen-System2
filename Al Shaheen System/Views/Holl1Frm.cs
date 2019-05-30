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
    public partial class Holl1Frm : Form
    {
        SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();
        public Holl1Frm(SH_USER_ACCOUNTS anyaccount)
        {
            InitializeComponent();
            Maccount = anyaccount;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newCutterFrm frm = new newCutterFrm(Maccount);
            frm.Show();
           

        }
    }
}
