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
    public partial class ProductionFrm : Form
    {
        SH_USER_ACCOUNTS Maccount = new SH_USER_ACCOUNTS();
        public ProductionFrm(SH_USER_ACCOUNTS anyaccount)
        {
            InitializeComponent();
            Maccount = anyaccount;
        }

        private void buttonHoll1_Click(object sender, EventArgs e)
        {
            Holl1Frm frm = new Holl1Frm(Maccount);
            frm.Show();
        }
    }
}
