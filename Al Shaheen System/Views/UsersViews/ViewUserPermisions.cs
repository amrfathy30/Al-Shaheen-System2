using System;

using System.Windows.Forms;


namespace Al_Shaheen_System
{
    public partial class ViewUserPermisions : Form
    {
        SH_USER_ACCOUNTS acc = new SH_USER_ACCOUNTS();
        SH_USER_PERMISIONS perm = new SH_USER_PERMISIONS();
        SH_EMPLOYEES emp = new SH_EMPLOYEES();
   

      

        public ViewUserPermisions(SH_EMPLOYEES Memp,SH_USER_PERMISIONS anyper, SH_USER_ACCOUNTS accnt)
        {
            InitializeComponent();
            acc = accnt;
            emp = Memp;
            perm = anyper;


        }

    
       
    
        private void ViewUserPermisions_Load(object sender, EventArgs e)
        {
          
            
            lbluserName.Text = acc.SH_EMP_USER_NAME;
           

            if (perm.SH_OPEN_CHANGE_PASSWORD == 0)
            {
                lblfrm2.Visible = false;
            }
            if (perm.SH_OPEN_DASH_BOARD == 0)
            {
                lblfrm2.Visible = false;
            }
            if (perm.SH_OPEN_DISPLAY_ALLUSERS == 0)
            {
                lblfrm2.Visible = false;
            }
            if (perm.SH_OPEN_GETALL_EMP == 0)
            {
                lblfrm2.Visible = false;
            }
            if (perm.SH_OPEN_MAKE_NEW_USER == 0)
            {
                lblfrm2.Visible = false;
            }
            if (perm.SH_OPEN_REGIST_EMP == 0)
            {
                lblfrm2.Visible = false;
            }
            if (perm.SH_OPEN_SELECT_USER_PERMISION == 0)
            {
                lblfrm2.Visible = false;
            }

        }

        private void bttnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
