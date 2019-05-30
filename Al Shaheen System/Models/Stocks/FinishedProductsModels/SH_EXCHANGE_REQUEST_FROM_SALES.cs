using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
  public  class SH_EXCHANGE_REQUEST_FROM_SALES
    {

      public long SH_ID { get; set; }
        public string    SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_ORDER_SUPPLY_WORK { get; set; }
        public string SH_PRODUCT_NAME { get; set; }
        public string SH_PRODUCT_TYPE { get; set; }
        public long SH_QUANTITIY_REQUIRED { get; set; }
        public long SH_TOTAL_QUANTITY_IN_STOCKS { get; set; }
        public string SH_DATA_ENTERED_BY { get; set; }
        public  DateTime  SH_REGISTERED_DATE { get; set; }
        public string SH_CLIENT_SUPPLY_ORDER_NUM { get; set; }
        public long SH_RLT_DAIMETR { get; set; }
        public long SH_PRODUCT_ID_SPECIFICATION { get; set; }
        public string SH_NORMAL_END_OPENWAY { get; set; }
        public string SH_NORMAL_END_OUTSIDE_MURAN { get; set; }
        public string SH_NORMAL_END_INSIDE_MURAN { get; set; }
        public string SH_NORMAL_END_MATERIAL { get; set; }
        public long SH_NORMAL_END_DAIMETR { get; set; }
        public long SH_TWIST_SIZE { get; set; }
        public string SH_TWIST_COLOR { get; set; }
        public string SH_TWIST_TYPE { get; set; }

        public string SH_PLASTIC_COVER_COLOR { get; set; }
        public long SH_PLASTIC_COVER_DAIMETR { get; set; }
        public long SH_PLASTIC_COVER_HAS_AKLASHEH { get; set; }
        public string SH_PLASTIC_MOLD_TYPE { get; set; }
        public long SH_PLASTIC_MOLD_DAIMETR { get; set; }
        public string SH_PLASTIC_MOLD_IMPORTEDOR_LOCAL { get; set; }

        public long SH_STATUS { get; set; }

    }
}
