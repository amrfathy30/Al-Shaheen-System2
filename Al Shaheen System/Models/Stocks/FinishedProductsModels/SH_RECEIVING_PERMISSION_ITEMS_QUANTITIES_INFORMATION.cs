using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_RECEIVING_PERMISSION_ITEMS_QUANTITIES_INFORMATION
    {
        public long SH_ID { get; set; }
        public string SH_ITEM_RECEIT_NUMBER { get; set; }
        public long SH_RECEIVING_PERMISSION_INFORMATION_ID { get; set; }
        public string SH_RECEIVING_PERMISSION_NUMBER { get; set; }
        public string SH_ITEM_NAME { get; set; }
        public string SH_ITEM_CONTAINER { get; set; }
        public long SH_NO_ITEMS_PER_CONTAINER { get; set; }
        public long SH_NO_CONTAINERS { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
        public string SH_ITEM_TYPE_NAME { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
    }
}
