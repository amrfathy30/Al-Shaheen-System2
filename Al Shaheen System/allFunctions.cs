using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ShaheenSystem
{
    class allFunctions
    {

        List<SH_QUNTITIES_MECHNICAL_PARTS> QuntMecPartList = new List<SH_QUNTITIES_MECHNICAL_PARTS>();
        List<SH_QUANTITIES_ELECTRICAL_PARTS> QuntElectricPartList = new List<SH_QUANTITIES_ELECTRICAL_PARTS>();
        List<SH_QUANTITIES_COMPUTER_PARTS> QuntComputerPartList = new List<SH_QUANTITIES_COMPUTER_PARTS>();
        List<SH_QUANTITIES_PRODUCTION_REQUIREMENTS> QuntProRequirmentList = new List<SH_QUANTITIES_PRODUCTION_REQUIREMENTS>();
        public void getQuantitiesMecanicalParts()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=sh_test_db;Integrated Security=true");
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from SH_QUNTITIES_MECHNICAL_PARTS", conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    QuntMecPartList.Add(new SH_QUNTITIES_MECHNICAL_PARTS { SH_ID = long.Parse(rd["SH_ID"].ToString()), SH_ITEM_NAME = rd["SH_ITEM_NAME"].ToString(), SH_ITEM_PROBERTIES = rd["SH_ITEM_PROBERTIES"].ToString(), SH_ITEM_UNIT = rd["SH_ITEM_UNIT"].ToString(), SH_NO_ITEMS = long.Parse(rd["SH_NO_ITEMS"].ToString()), SH_STOCK_MAN_NAME = rd["SH_STOCK_MAN_NAME"].ToString(), SH_ADDING_PERMISION_NUMBER = long.Parse(rd["SH_ADDING_PERMISION_NUMBER"].ToString()), SH_SUPPLIER_NAME = rd["SH_SUPPLIER_NAME"].ToString(), SH_SUPPLIER_ID = long.Parse(rd["SH_SUPPLIER_ID"].ToString()), SH_ADDIONDATE = DateTime.Parse(rd["SH_ADDIONDATE"].ToString()) });
                }
                conn.Close();
            }catch(Exception ex)
            {
                MessageBox.Show("The error is" + ex.Message);

            }
        }


        public void getQuantitiesElectricParts()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=sh_test_db;Integrated Security=true");
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from SH_QUANTITIES_ELECTRICAL_PARTS", conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    QuntElectricPartList.Add(new SH_QUANTITIES_ELECTRICAL_PARTS { SH_ID = long.Parse(rd["SH_ID"].ToString()), SH_ITEM_NAME = rd["SH_ITEM_NAME"].ToString(), SH_ITEM_PROBERTIES = rd["SH_ITEM_PROBERTIES"].ToString(), SH_ITEM_UNIT = rd["SH_ITEM_UNIT"].ToString(), SH_NO_ITEMS = long.Parse(rd["SH_NO_ITEMS"].ToString()), SH_STOCK_MAN_NAME = rd["SH_STOCK_MAN_NAME"].ToString(), SH_ADDING_PERMISION_NUMBER = long.Parse(rd["SH_ADDING_PERMISION_NUMBER"].ToString()), SH_SUPPLIER_NAME = rd["SH_SUPPLIER_NAME"].ToString(), SH_SUPPLIER_ID = long.Parse(rd["SH_SUPPLIER_ID"].ToString()), SH_ADDIONDATE = DateTime.Parse(rd["SH_ADDIONDATE"].ToString()) });
                }
               
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The error is"+ex.Message);

            }
        }

        public void getQuantitiesComputerParts()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=sh_test_db;Integrated Security=true");
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from SH_QUANTITIES_ELECTRICAL_PARTS", conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    QuntComputerPartList.Add(new SH_QUANTITIES_COMPUTER_PARTS { SH_ID = long.Parse(rd["SH_ID"].ToString()), SH_ITEM_NAME = rd["SH_ITEM_NAME"].ToString(), SH_ITEM_PROBERTIES = rd["SH_ITEM_PROBERTIES"].ToString(), SH_ITEM_UNIT = rd["SH_ITEM_UNIT"].ToString(), SH_NO_ITEMS = long.Parse(rd["SH_NO_ITEMS"].ToString()), SH_STOCK_MAN_NAME = rd["SH_STOCK_MAN_NAME"].ToString(), SH_ADDING_PERMISION_NUMBER = long.Parse(rd["SH_ADDING_PERMISION_NUMBER"].ToString()), SH_SUPPLIER_NAME = rd["SH_SUPPLIER_NAME"].ToString(), SH_SUPPLIER_ID = long.Parse(rd["SH_SUPPLIER_ID"].ToString()), SH_ADDIONDATE = DateTime.Parse(rd["SH_ADDIONDATE"].ToString()) });
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The error is" + ex.Message);

            }
        }

        public void getQntproduction_requirment()
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"server=SH_PC202\SH_SYSTEM_DB;Initial Catalog=sh_test_db;Integrated Security=true");
                conn.Open();
                SqlCommand comm = new SqlCommand("select * from SH_QUANTITIES_ELECTRICAL_PARTS", conn);
                SqlDataReader rd = comm.ExecuteReader();
                while (rd.Read())
                {
                    QuntProRequirmentList.Add(new SH_QUANTITIES_PRODUCTION_REQUIREMENTS { SH_ID = long.Parse(rd["SH_ID"].ToString()), SH_ITEM_NAME = rd["SH_ITEM_NAME"].ToString(), SH_ITEM_PROBERTIES = rd["SH_ITEM_PROBERTIES"].ToString(), SH_ITEM_UNIT = rd["SH_ITEM_UNIT"].ToString(), SH_NO_ITEMS = long.Parse(rd["SH_NO_ITEMS"].ToString()), SH_STOCK_MAN_NAME = rd["SH_STOCK_MAN_NAME"].ToString(), SH_ADDING_PERMISION_NUMBER = long.Parse(rd["SH_ADDING_PERMISION_NUMBER"].ToString()), SH_SUPPLIER_NAME = rd["SH_SUPPLIER_NAME"].ToString(), SH_SUPPLIER_ID = long.Parse(rd["SH_SUPPLIER_ID"].ToString()), SH_ADDIONDATE = DateTime.Parse(rd["SH_ADDIONDATE"].ToString()) });
                }
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The error is" + ex.Message);

            }
        }







    }
}
