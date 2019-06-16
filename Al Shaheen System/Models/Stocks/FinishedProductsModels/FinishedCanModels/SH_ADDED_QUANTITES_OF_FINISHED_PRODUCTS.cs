using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_ADDED_QUANTITES_OF_FINISHED_PRODUCTS
    {
        public long SH_ID { get; set; }
        public long SH_CALCULATE_TOTAL_FINISHED_PRODUCT_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_PRODUCT_ID { get; set; }
        public string SH_CLIENT_PRODUCT_NAME { get; set; }
        public long SH_TOTAL_NUMBER_OF_PALLETS { get; set; }
        public long SH_TOTAL_NUMBER_OF_CANS { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public long SH_STOCK_ID { get; set; }
        public string SH_ADDING_PERMISSION_NUMBER { get; set; }
        public string SH_WORK_ORDER_NUMBER { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public  List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT> mparcels = new List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT>();
    }
}
