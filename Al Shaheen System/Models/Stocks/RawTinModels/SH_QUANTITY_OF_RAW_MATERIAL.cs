using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_QUANTITY_OF_RAW_MATERIAL : SH_RAW_TIN_GENERAL_INFO
    {
        public long SH_SPECIFICATION_OF_RAW_MATERIAL_ID { get; set; }
        public long SH_TOTAL_NUMBER_OF_PACKAGES { get; set; }
        public long SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE { get; set; }
        public double SH_NET_WEIGHT { get; set; }
        public DateTime SH_DATE_SUPPLY { get; set; }
        public string SH_SUPPLIER_NAME { get; set; }
        public string SH_STOCK_NAME  { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public double SH_TON_PRICE { get; set; }
        public double SH_COST_OF_QUANTITY { get; set; }
        public string SH_SUPPLY_TYPE_NAME { get; set; }
        public double SH_ITEM_GROSS_WEIGHT { get; set; }
        public long SH_TOTAL_NUMBER_OF_SHEETS()
        {
            return SH_TOTAL_NUMBER_OF_PACKAGES * SH_TOTAL_NUMBER_OF_SHEETS_OF_PACKAGE;
        }

        public List<SH_RAW_MATERIAL_PARCEL> SH_QUANTITY_PARCELS;


    }
}
