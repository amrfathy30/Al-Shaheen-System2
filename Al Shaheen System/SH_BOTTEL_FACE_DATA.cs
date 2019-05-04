using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_BOTTEL_FACE_DATA
    {
        public string addition_permission_number { get; set; }
        public string work_order_number { get; set; }
        public SH_SHAHEEN_STOCK stock { get; set; }
        public SH_EMPLOYEES stock_man { get; set; }
        public DateTime addition_date { get; set; }
        public SH_BOTTLE_FACE_TYPES bottle_face_type { get; set; }
        public long no_items_per_box { get; set; }
        public long no_of_boxes { get; set; }
        public long total_no_items { get; set; }
        public SH_ITEM_SIZE sizes { get; set; }

        //mold info
        public SH_MOLD_SIZE mold_size { get; set; }
        public string  mold_type { get; set; }
        public long mold_type_id { get; set; }
        public long hand_or_not { get; set; }
        public SH_HAND_TYPES hand_type { get; set; }
        //printing info
        public SH_BOTTLE_FACE_PAINTINGS_TYPES printing_type { get; set; }

        //aerosol info 
        public SH_AEROSOL_SIZE aerosol_size { get; set; }
        public SH_AEROSOL_TYPE aerosol_type { get; set; }
        //screw info
        public SH_SCREW_SIZE screw_size { get; set; }
        public SH_SCREW_USAGE screw_usage { get; set; }

    }
}
