using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class finished_cans_model_data
    {
        public long client_id { get; set; }
        public long client_product_id { get; set; }
        public long size_id { get; set; }
        public string client_name { get; set; }
        public long  specification_id { get; set; }
        public string size_name { get; set; }
        public string  product_name { get; set; }
        public long  no_pallets { get; set; }
        public long no_cans_per_pallet { get; set; }
        public long total_no_cans { get; set; }
    }
}
