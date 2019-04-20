using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_QUANTITIES_RAW_MATERIAL_SPECIFICATION_COILS : SH_SPECIFICATION_OF_RAW_MATERIAL_COILS
    {
        public long SH_SPECIFICATION_OF_RAW_MATERIAL_COILS_ID { get; set; }
        public long SH_ITEM_TOTAL_NO_COILS { get; set; }
        public double SH_ITEM_TON_PRICE { get; set; }
        public string SH_ITEM_SUPPLY_TYPE { get; set; }
        public double SH_ITEM_TOTAL_QUANTITY_COST { get; set; }
        public string SH_ITEM_STOCK_NAME { get; set; }
        public DateTime SH_DATE_OF_SUPPLY { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public string SH_SUPPLIER_NAME { get; set; }

        public List<SH_COILS_RAW_MATERIAL> QuantityCoils = new List<SH_COILS_RAW_MATERIAL>();
    }
}
