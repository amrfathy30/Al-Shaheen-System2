using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
   public  class SH_QUANTITY_OF_MURAN_MATERIAL : SH_SPECIFICATION_OF_MURAN_MATERIAL 
    {
        public long SH_SPECIFICATION_OF_MURAN_MATERIAL_ID { get; set; }
        public double SH_ITEM_PACKAGE_NET_WEIGHT { get; set; }
        public long SH_ITEM_NUMBER_OF_PACKAGES { get; set; }
        //  public long SH_ITEM_TOTAL_NUMBER_OF_SHEETS { get; set; }
        public double SH_QUANTITY_NET_WEIGHT { get; set; }
        public double SH_PACKAGE_GROSS_WEIGHT { get; set; }  
        public double SH_QUANTITY_GROSS_WEIGHT { get; set; }
        public long SH_PARCELS_NO_SHEETS { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public string SH_WORK_ORDER_NUMBER { get; set; }

    }
}
