using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class summary_receiving_information_quantity_data
    {
        public long client_id { get; set; }
        public string client_name { get; set; }
        public string client_branch_name { get; set; }
        public string item_name { get; set; }
        public long no_containers { get; set; }
        public long no_items { get; set; }
        public string container_name { get; set; }
    }
}
