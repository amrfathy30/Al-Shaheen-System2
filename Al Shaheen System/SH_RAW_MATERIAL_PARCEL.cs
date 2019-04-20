using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_RAW_MATERIAL_PARCEL : SH_QUANTITY_OF_RAW_MATERIAL
    {
        public long SH_ITEM_ID { get; set; }
        public long SH_QUANTITY_OF_RAW_MATERIAL_ID { get; set; }
       // public long SH_SPECIFICATION_OF_RAW_MATERIAL_ID { get; set; }
        public string SH_PARCEL_NUMBER { get; set; }
        public long SH_ITEM_NUMBER_OF_SHEETS { get; set; }
        public double SH_ITEM_PARCEL_NET_WEIGHT { get; set; }
        public double SH_ITEM_PARCEL_GROSS_WEIGHT { get; set; }
        //public string SH_STOCK_NAME { get; set; }
       // public DateTime SH_ADDITION_DATE { get; set; }
        public List<SH_RAW_MATERIAL_PARCEL> get_parcels (List<SH_RAW_MATERIAL_PARCEL> p_parcels)
        {
            return p_parcels;
        }
    }
}
