using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_DISMISSAL_FINISHED_PRODUCTS_FORM_DATA
    {
        public long product_type { get; set; }
        public string product_name { get; set; }
        public long no_of_selected_containers { get; set; }
        public long total_no_of_items_of_selected_containers { get; set; }
        public List<SH_ADDED_PARCELS_OF_FINISHED_PRODUCT> cans_parcels { get; set; }
        public List<SH_CONTAINER_OF_BOTTOM> bottom_containers { get; set; }
        public List<SH_CONTAINER_OF_RLT> rlt_containers { get; set; }
        public List<SH_CONTAINER_OF_BILL_OFF> peel_off_containers { get; set; }
        public List<SH_CONTAINER_OF_EASY_OPEN> easy_open_containers { get; set; }
        public List<SH_CONTAINER_OF_TWIST_OF> twist_of_containers { get; set; }
        public List<SH_CONTAINERS_OF_PLASTIC_COVER> plastic_cover_containers { get; set; }
        public List<SH_CONTAINERS_OF_PLASTIC_MOLD> plastic_mold_containers { get; set; }
    }
}
