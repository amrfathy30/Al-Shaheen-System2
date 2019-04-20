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
    public partial class waitingform : Form
    {
        public Action Worker { set; get; }

        public waitingform(Action worker)
        {
           
            InitializeComponent();
            if (worker == null)
            {
                throw new ArgumentNullException();
            }
            this.Worker = worker;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
