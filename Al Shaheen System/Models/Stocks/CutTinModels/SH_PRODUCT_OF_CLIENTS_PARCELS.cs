using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_PRODUCT_OF_CLIENTS_PARCELS
    {
        public long SH_SPECIFICTION_OF_PRINTED_MATERIAL_ID { get; set; }
        public long SH_QUANTITIES_OF_PRINTED_MATERIAL_ID { get; set; }
        public long SH_PRINTED_MATERIAL_PARCEL_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_PRODUCT_ID { get; set; }
        public string SH_CLIENT_PRODUCT_NAME { get; set; }
        public long SH_NO_BOTTLES_PER_SHEET { get; set; }
        public long SH_TOTAL_NUMBER_OF_BOTTELS { get; set; }

        public List<SH_PRINTED_MATERIAL_PARCEL> printed_material_parcels = new List<SH_PRINTED_MATERIAL_PARCEL>();

    }
}
