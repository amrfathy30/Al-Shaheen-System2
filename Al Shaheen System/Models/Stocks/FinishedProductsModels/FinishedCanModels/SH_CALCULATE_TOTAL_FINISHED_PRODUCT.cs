using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_CALCULATE_TOTAL_FINISHED_PRODUCT
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_PRODUCT_ID { get; set; }
        public string SH_CLIENT_PRODUCT_NAME { get; set; }

        public long SH_PARCEL_NO_OF_CANS { get; set; }

        public string size_name { get; set; }
        public long SH_TOTAL_NUMBER_OF_PALLET { get; set; }
        public long SH_TOTAL_NUMBER_OF_CANS { get; set; }
        public long SH_TOTAL_NUMBER_OF_ENTERED_CANS { get; set; }
        public long SH_TOTAL_NUMBER_OF_ENTERED_PALLETS { get; set; }
        public long SH_TOTAL_NUMBER_OF_EXCHANGED_CANS { get; set; }
        public long SH_TOTAL_NUMBER_OF_EXCHANGED_PALLETS { get; set; }
    }
}
