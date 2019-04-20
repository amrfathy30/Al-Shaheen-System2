using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_QUANTITIES_OF_PRINTED_MATERIAL : SH_SPECIFICATION_OF_PRINTED_MATERIAL
    {
        public string SH_SPECIFICATION_OF_PRINTED_MATERIAL_ID { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public long SH_PRINTER_ID { get; set; }
        public string SH_PRINTER_NAME { get; set; }
        public string SH_WORK_ORDER_NUMBER { get; set; }
        public long SH_TOTAL_NUMBER_OF_BOTTELS { get; set; }
        public double SH_PARCEL_NET_WEIGHT { get; set; }
        public string SH_PRINTING_PERMISSION_NUMBER { get; set; }
        public long  SH_PARCEL_NO_SHEETS { get; set; }


    }
}
