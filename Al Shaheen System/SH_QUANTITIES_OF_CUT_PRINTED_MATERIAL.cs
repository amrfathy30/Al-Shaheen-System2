using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_QUANTITIES_OF_CUT_PRINTED_MATERIAL
    {
        public long SH_ID { get; set; }
        public long SH_SPECIFICATION_OF_CU_PRINTED_MATERIAL_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_PRODUCT_ID { get; set; }
        public string SH_PRODUCT_NAME { get; set; }
        public long SH_STOCK_ID { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public long SH_CUTTER_ID { get; set; }
        public string SH_CUTTER_NAME { get; set; }
        public string SH_CUTTER_TECHNICAL_MAN { get; set; }
        public long SH_TOTAL_NUMBER_OF_PALLETS { get; set; }
        public long SH_TOTAL_NUMBER_OF_BOTTELS { get; set; }
        public DateTime SH_ADDTTION_DATE { get; set; }
        public string SH_WORK_ORDER_NUMBER { get; set; }
        public string SH_ADDTION_PERMISSION_NUMBER { get; set; }

        public List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL> pallets = new List<SH_PALLETS_OF_CUT_PRINTED_MATERIAL>();

    }
}
