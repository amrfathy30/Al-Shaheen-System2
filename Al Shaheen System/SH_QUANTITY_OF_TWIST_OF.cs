using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_QUANTITY_OF_TWIST_OF
    {
        public long SH_ID { get; set; }
        public long SH_SPECIFICATION_OF_TWIST_OF_ID { get; set; }
        public long SH_NO_CONTAINERS { get; set; }
        public long SH_NO_ITEMS_PER_CONTAINER { get; set; }
        public long SH_TOTAL_NO_OF_ITEMS { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public string SH_ADDITION_PERMISSION_NUMBER { get; set; }
        public long SH_SUPPLIER_ID { get; set; }
        public string suppliername { get; set; }
        public long SH_SUPPLIER_BRANCH_ID { get; set; }
        public string supplierbranchname { get; set; }

        public List<SH_CONTAINER_OF_TWIST_OF> containers;
        
    }
}
