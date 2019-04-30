using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_TWIST_OF_DATA
    {
        //public long SH_ID { get; set; }
        public SH_CLIENT_COMPANY client { get; set; }
        public SH_CLIENTS_PRODUCTS product { get; set; }
        public SH_SUPPLY_COMPANY supplier { get; set; }
        public SH_SUPPLY_COMPANY_BRANCHES supplier_branch { get; set; }
        public SH_TWIST_OF_SIZE size { get; set; }
        public SH_COLOR_PILLOW pillow_color { get; set; }
        public SH_FACE_COLOR second_face { get; set; }
        public SH_TWIST_OF_TYPE twist_type { get; set; }
        public string item_type { get; set; }
        public string container_name { get; set; }
        public long  no_of_containers { get; set; }
        public long no_of_item_per_container { get; set; }
        public long total_no_items()
        {
            return no_of_containers * no_of_item_per_container;
        }
        public long first_face_pillow_or_not { get; set; }
        public DateTime AdditionDate { get; set; }
        public string addition_permission_number { get; set; }
    }
}
