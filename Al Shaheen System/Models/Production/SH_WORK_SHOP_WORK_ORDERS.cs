using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
     public class SH_WORK_SHOP_WORK_ORDERS
    {
        public long  SH_ID { get; set; }
        public string SH_ITEM_NAME { get; set; }
        public long SH_ITEM_QUANTITY { get; set; }
        public string SH_WORKING_MACHINE { get; set; }
        public string SH_NOTES { get; set; }
        public string SH_ASKED_MAN_NAME { get; set; }
        public DateTime SH_START_WORK_DATE { get; set; }
        public long SH_WORKING_TOTAL_HOURS { get; set; }
        public DateTime SH_FINISH_DATE { get; set; }
        public long SH_WORK_STAT { get; set; }
        public string SH_WORK_STAT_NAME { get; set; }


    }
}
