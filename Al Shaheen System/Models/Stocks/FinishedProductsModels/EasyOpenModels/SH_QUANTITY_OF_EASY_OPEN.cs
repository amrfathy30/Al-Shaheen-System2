using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_QUANTITY_OF_EASY_OPEN
    {
        public long SH_ID { get; set; }
        public long SH_SPECIFICATION_OF_EASY_OPEN_ID { get; set; }
        public DateTime SH_ADDTION_DATE { get; set; }
        public string SH_ADDITION_PERMISSION_NUMBER { get; set; }
        public long SH_STOCK_ID { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public long SH_STOCK_MAN_ID { get; set; }
        public string SH_STOCK_MAN_NAME { get; set; }
        public DateTime SH_SUPPLY_DATE { get; set; }
        public long SH_SUPPLIER_ID { get; set; }
        public string SH_SUPPLIER_NAME { get; set; }
        public long SH_SUPPLIER_BRANCH_ID { get; set; }
        public string SH_SUPPLIER_BRANCH_NAME { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_ITEMS_PER_CONTAINER { get; set; }
        public long SH_NO_OF_CONTAINERS { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
    }
}
