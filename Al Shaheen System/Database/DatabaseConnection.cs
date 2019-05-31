using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Al_Shaheen_System
{
    public class DatabaseConnection
    {
        public static SqlConnection mConnection ;
        public DatabaseConnection()
        {
            try
            {
                string mode = Properties.Settings.Default.SH_AUTH_TYPE;
                if (mode == "SQL")
                {
                  //  Properties.Settings.Default.SH_SERVER = "SH_PC02";
                  // mConnection = new SqlConnection(@"Server = " + Properties.Settings.Default.SH_SERVER + ";Database = " + Properties.Settings.Default.SH_DATABASE_NAME + "; Integrated Security = false ; User ID =  " + Properties.Settings.Default.SH_USER_NAME + " ; Password=  " + Properties.Settings.Default.SH_PASSWORD + " ;Connection Timeout=100 ; ");
                  mConnection = new SqlConnection(@"Server = " + "sh_pc02" + ";Database = " + "SH_PRIMARY_TEST_DB" + "; Integrated Security = false ; User ID =  " + Properties.Settings.Default.SH_USER_NAME + " ; Password=  " + Properties.Settings.Default.SH_PASSWORD + " ;Connection Timeout=100 ; ");

                }
                else
                {
                   // Properties.Settings.Default.SH_SERVER = "SH_PC02";
                    mConnection = new SqlConnection(@"Server = " + Properties.Settings.Default.SH_SERVER + ";Database = " + Properties.Settings.Default.SH_DATABASE_NAME + "; Integrated Security = true ;Connection Timeout=100 ;");
                }
               // MessageBox.Show(mConnection.State.ToString());
            }
            catch (SqlException ex)
            {
                MessageBox.Show("failed to connect to database" + ex.ToString());
            }
            //Properties.Settings.Default.SH_MASTER_DBConnectionString = mConnection.ToString();
            //Connection to database
            //  mConnection = new SqlConnection("Server =sh_pc201; Database =sh_master_db; Trusted_Connection = true"); 
        }

        public void openConnection()
        {

            if (mConnection.State != System.Data.ConnectionState.Open)
            {
                mConnection.Open();

            }
        }

        public void closeConnection()
        {
            if (mConnection.State != System.Data.ConnectionState.Closed)
            {
                mConnection.Close();

            }
        }
    }
}
