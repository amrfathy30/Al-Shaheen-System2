using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_QUANTITY_OF_PLASTIC_COVER
    {
        public long SH_ID { get; set; }
        public long SH_SPECIFICATION_OF_PLASTIC_COVER_ID { get; set; }
        public long SH_SUPPLIER_ID { get; set; }
        public long SH_SUPPLIER_BRANCH_ID { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public string SH_ADDITION_PERMISSION_NUMBER { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_OF_ITEMS_PER_CONTAINER { get; set; }
        public long SH_NO_OF_CONTAINERS { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
        public string  suppliername { get; set; }
        public string supplierbranchname { get; set; }
    }
}
