using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
  public   class SH_QUANTITY_OF_EXCHANGED_PRINTED_MATERIAL
    {

        public long SH_ID { get; set; }
        public long SH_NUMBER_OF_PARCELS { get; set; }
        public long SH_NUMBER_OF_SHEETS { get; set; }
        DateTime SH_EXCHANGE_DATE { get; set; }
        public string SH_EXCHANGE_PERMISSION_NUMBER { get; set; }
        public string SH_STOCK_MAN_NAME { get; set; }
        public long SH_STOCK_MAN_ID { get; set; }
        public long SH_STOCK_ID { get; set; }
        public long SH_CUTTER_ID { get; set; }
        public string SH_CUTTER_NAME { get; set; }
        public string SH_CUTTER_MAN_NAME { get; set; }
        public string SH_RECEIVED_MAN_NAME { get; set; }
        public long SH_RECEIVED_MAN_ID { get; set; }
        public string SH_CONFIDENTIAL_MAN_NAME { get; set; }
        public long SH_CONFIDENTIAL_MAN_ID { get; set; }
        public string SH_DEPARTMENT_NAME { get; set; }
        public long SH_DEPARTMENET_ID { get; set; }
        public string SH_STOCK_NAME { get; set; }

    }
}
