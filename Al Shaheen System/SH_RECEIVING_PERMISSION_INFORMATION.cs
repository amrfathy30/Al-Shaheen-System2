using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_RECEIVING_PERMISSION_INFORMATION
    {
        public long SH_ID { get; set; }
        public string SH_RECEIVING_PERMISSION_NUMBER { get; set; }
        public long SH_ITEM_NUMBER { get; set; }
        public string SH_ITEM_RECEIT_NUMBER { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_ITEM_NAME { get; set; }
        public string SH_ITEM_TYPE { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_CONTAINERS { get; set; }
        public long SH_NO_ITEMS_PER_CONTAINER { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public long SH_DATA_ENTRY_USER_ID { get; set; }
        public long SH_DATA_ENTRY_EMPLOYEE_ID { get; set; }
        public long SH_STOCK_ID { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public string SH_DRIVER_NAME { get; set; }
        public string SH_DRIVER_TELEPHONE_NUMBER { get; set; }
        public string SH_DRIVER_LICENSE_NUMBER { get; set; }
        public string SH_DRIVER_CAR_NUMBER { get; set; }
        public string SH_ORDER_NUMBER { get; set; }
    }
}
