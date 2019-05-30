using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
     public class SH_QUANTITY_OF_EXCHANGED_MURAN_MATERIAL
    {
     public long    SH_ID { get; set; }
        public long SH_EXCHANGE_OF_MURAN_MATERIAL_SPECIFICATIONS_ID { get; set; }
        public long SH_NUMBER_OF_PARCELS { get; set; }
        public long SH_TOTAL_NUMBER_OF_SHEETS { get; set; }
        public  DateTime  SH_EXCHANGE_DATE { get; set; }
        public string  SH_EXCHANGE_PERMISSION_NUMBER { get; set; }
    }
}
