using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class allsolditemsfullinformationdetails
    {
        public string receival_permission_number { get; set; }
        public DateTime receival_permission_date { get; set; }
        public string client_name { get; set; }
        public string client_branch_name { get; set; }
        public string container_name { get; set; }
        public long no_containers { get; set; }
        public long no_items_per_container { get; set; }
        public long total_number_of_items { get; set; }
        public string driver_name { get; set; }
        public string stock_name { get; set; }
        public string stock_man_name { get; set; }

        public long no_pallets { get; set; }
        public long no_carton_dividers { get; set; }
        public long no_wooden_faces { get; set; }

    }
}
