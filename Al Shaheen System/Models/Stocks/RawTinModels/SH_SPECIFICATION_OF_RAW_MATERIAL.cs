using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_RAW_MATERIAL : SH_RAW_TIN_GENERAL_INFO
    { 
        public long SH_ITEM_TOTAL_NUMBER_OF_PACKAGES { get; set; }
        public double SH_ITEM_TOTAL_NET_WEIGHT { get; set; }
        public double SH_ITEM_TOTAL_GROSS_WEIGHT { get; set; }
        public long SH_ITEM_TOTAL_NUMBER_OF_SHEETS { get; set; }

        public long SH_DATA_ENTRY_USER_ID { get; set; }
        public string SH_DATA_ENTRY_USER_NAME { get; set; }
        public long SH_DATA_ENTRY_EMPLOYEE_ID { get; set; }
        public string SH_DATA_ENTRY_EMPLOYEE_NAME { get; set; }



        public DateTime SH_CREATION_DATE { get; set; }

        //public double TOTAL_NET_WEIGHT ()
        //{
            
        //   //calculate total_net_weight
        //}
    }
}
