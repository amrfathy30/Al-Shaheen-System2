using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_RLT_DATA
    {
        public SH_MATERIAL_TYPES SH_RAW_MATERIAL_TYPE { get; set; }
        public SH_EASY_OPEN_USAGE SH_USAGE { get; set; }
        public SH_SUPPLY_COMPANY_BRANCHES supplier_branch { get; set; }
        public SH_ITEM_SIZE size { get; set; }
        public SH_SHAHEEN_STOCK stock { get; set; }
        public SH_SUPPLY_COMPANY supplier { get; set; }
        public string addition_permission_number { get; set; }
        public DateTime addition_date { get; set; }
        public SH_EMPLOYEES stock_man { get; set; }
        public SH_FACE_COLOR first_face { get; set; }
        public SH_FACE_COLOR second_face { get; set; }
        public long SH_PRINTING_TYPE { get; set; }
        public string SH_PRINTING_TYPE_NAME { get; set; }
        public SH_CLIENT_COMPANY client { get; set; }
        public SH_CLIENTS_PRODUCTS product { get; set; }
        public string sub_container_name { get; set; }
        public long no_of_subcontainer_per_container { get; set; }
        public long no_items_per_subcontainer { get; set; }
        public long total_number_of_sub_container { get; set; }
        public string container_name { get; set; }
        public long no_of_container { get; set; }
        public long no_of_items_per_container { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
    }
}
