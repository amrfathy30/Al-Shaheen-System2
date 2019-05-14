using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_PRINTED_MATERIAL
    {
        public long SH_ID { get; set; }
        public double SH_ITEM_LENGTH { get; set; }
        public double SH_ITEM_WIDTH { get; set; }
        public double SH_ITEM_THICKNESS { get; set; }
        public string SH_ITEM_CODE { get; set; }
        public string SH_ITEM_TYPE { get; set; }
        public double SH_ITEM_SHEET_WEIGHT { get; set; }
        public long SH_ITEM_TOTAL_NO_SHEETS { get; set; }
        public double SH_ITEM_TOTAL_NET_WEIGHT { get; set; }
        public double SH_ITEM_TOTAL_GROSS_WEIGHT { get; set; }
        public long SH_ITEM_TOTAL_NO_PARCELS { get; set; }
        public string SH_ITEM_TEMPER { get; set; }
        public string SH_ITEM_COATING { get; set; }
        public string SH_ITEM_FINISH { get; set; }
    }
}
