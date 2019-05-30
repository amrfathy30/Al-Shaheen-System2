using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class sh_plastic_mold_finished_product_data
    {
        public long sh_id { get; set; }
        public long client_id { get; set; }
        public string client_name { get; set; }
        public long size_id { get; set; }
        public string size_name { get; set; }
        public string container_name { get; set; }
        public long SH_NO_OF_CONTAINERS { get; set; }
        public long SH_PILLOW_COLOR_ID { get; set; }
        public string SH_PILLOW_COLOR_NAME { get; set; }
        public long SH_MOLD_TYPE_ID { get; set; }
        public string SH_MOLD_TYPE_NAME { get; set; }
        public long total_number_of_items { get; set; }
    }
}
