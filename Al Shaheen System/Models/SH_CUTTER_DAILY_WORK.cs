using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
 public class SH_CUTTER_DAILY_WORK
    {
     public long SH_ID { get; set; }
       public string SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_PRODUCT_NAME { get; set; }
        public string SH_PRODUCT_SIZE { get; set; }
        public double SH_PRODUCT_CAPACITY { get; set; }
        public double SH_PRODUCT_HIGHT { get; set; }
        public string SH_OUT_FACE { get; set; }
        public string SH_INSIDE_FACE { get; set; }
        public string SH_PRINTER_TYPE { get; set; }
        public string SH_PRINTER_STATUS { get; set; }
        public long SH_PRODUCT_NUMBER_OF_SHEET { get; set; }
        public double SH_PARCEL_HIGHT { get; set; }
        public double SH_PARCEL_WIDTH { get; set; }
        public long SH_NUMBER_OF_SHEETS_PER_ONE_PARCEL { get; set; }
        public long SH_QUANTITY_DESTROYED_BY_CUTTER { get; set; }
        public long SH_EXPECTED_QUNTITY { get; set; }
        public long SH_QUANTITY_DESTROYED_BY_PRINTER { get; set; }
        public long SH_ACTUAL_QUNTITY { get; set; }

    }
}
