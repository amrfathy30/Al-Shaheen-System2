using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_PLASTIC_MOLD_DATA
    {
        public SH_CLIENT_COMPANY client { get; set; }
        public SH_SUPPLY_COMPANY supplier { get; set; }
        public SH_SUPPLY_COMPANY_BRANCHES supplier_branch { get; set; }
        public SH_SHAHEEN_STOCK stock { get; set; }
        public SH_MOLD_TYPES mold_types { get; set; }
        public SH_MOLD_SIZE size { get; set; }
        public SH_COLOR_PILLOW color { get; set; }
        public string  container_name { get; set; }
        public DateTime  Addition_date { get; set; }
        public string  addition_permission_number { get; set; }
        public long no_of_containers { get; set; }
        public long no_of_items_per_container { get; set; }
        public long total_number_of_items ()
        {
            return no_of_containers * no_of_items_per_container;
        }
       
    }
}
