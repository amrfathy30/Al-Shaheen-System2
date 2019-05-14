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
    public partial class printedcaredsforrawmaterial : Form
    {
        private List<raw_material_card_info> raw_material_cards = new List<raw_material_card_info>();
        public printedcaredsforrawmaterial()
        {
            InitializeComponent();
        }
        public printedcaredsforrawmaterial(List<raw_material_card_info> mycards)
        {
            InitializeComponent();
            raw_material_cards = mycards;
        }

        private void printedcaredsforrawmaterial_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
