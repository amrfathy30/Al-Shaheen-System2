using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
public class SH_RLT_EXCHANGE_BY_CLIENT_ORDER_WORK
    {

        public long SH_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public long SH_QUNTITY_OF_CLIENT { get; set; }
        DateTime SH_DATE_OF_EXCHANGE { get; set; }
        public string SH_CLIENT_ORDER_SUPPLAY_WORK { get; set; }
        public string SH_CLIENT_SUPPLAY_NUM { get; set; }
        public long SH_STOCK_MAN_ID { get; set; }
        public string SH_STOCK_MAN_NAME { get; set; }
        public string SH_SALES_RESPOSIBLE_NAME { get; set; }
        public long SH_RLT_DAIMETR { get; set; }

    }
}
