using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_SPECIFICATION_OF_CUT_PRINTED_MATERIAL
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_PRODUCT_ID { get; set; }
        public string SH_PRODUCT_NAME { get; set; }
        public long SH_TOTAL_NUMBER_OF_BOTTELS { get; set; }
        public long SH_TOTAL_NUMBER_OF_PALLETS { get; set; }
    }
}
