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
        public ProductionFrm()
        {
            InitializeComponent();
        }

        private void buttonHoll1_Click(object sender, EventArgs e)
        {
            Holl1Frm frm = new Holl1Frm();
            frm.ShowDialog();
        }
    }
}
