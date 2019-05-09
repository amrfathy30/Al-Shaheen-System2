using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
   
    class receival_permission_order_items
    {
        public long finished_product_type_id { get; set; }
        public string finished_product_type_name { get; set; }
        public long finished_product_specifications_id { get; set; }
        public string finished_product_container_name { get; set; }
        public long finished_product_no_containers { get; set; }
        public long finished_product_no_items_per_container { get; set; }
        public long finished_product_total_no_items { get; set; }
    }
}
