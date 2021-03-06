﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_EXCHANGE_OF_MURAN_MATERIAL
    {
        public long SH_ID { get; set; }
        public long SH_SPECIFICATION_OF_MURAN_MATERIAL_ID { get; set; }
        public string SH_EXCHANGE_PERMISSION_NUMBER { get; set; }
        public long SH_STOCK_ID { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public DateTime SH_EXCHANGE_DATE { get; set; }
        public string SH_RECEIVED_MAN_NAME { get; set; }
        public string SH_STOCK_MAN_NAME { get; set; }
        public string SH_WORK_ORDER_NUMBER { get; set; }
        public string SH_REASON_OF_EXCHANGE { get; set; }
        public string SH_PLACE_OF_EXCHANGE { get; set; }
    }
}
