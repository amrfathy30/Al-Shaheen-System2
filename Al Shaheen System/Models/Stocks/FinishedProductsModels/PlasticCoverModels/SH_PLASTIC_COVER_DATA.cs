using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_PLASTIC_COVER_DATA
    {
        public SH_CLIENT_COMPANY client { get; set; }
        public SH_ITEM_SIZE size { get; set; }
        public SH_SUPPLY_COMPANY supplier { get; set; }
        public SH_SUPPLY_COMPANY_BRANCHES supplier_branch { get; set; }
        public DateTime addition_date { get; set; }
        public string addition_permission_number { get; set; }
        public SH_COLOR_PILLOW pillow_color { get; set; }
        public SH_EMPLOYEES  STOCK_MAN { get; set; }
        public long logo_or_not { get; set; }
        public string container_name { get; set; }
        public long no_of_containers { get; set; }
        public long  no_items_per_container { get; set; }
        public long total_no_items ()
        {
            return no_of_containers * no_items_per_container;
        }
    }
}
