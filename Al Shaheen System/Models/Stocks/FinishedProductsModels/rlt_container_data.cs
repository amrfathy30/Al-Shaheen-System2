using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class rlt_container_data
    {
        public string client_name { get; set; }
        public string container_name { get; set; }
        public string subcontainer_name { get; set; }
        public long total_number_of_sub_container { get; set; }
        public long no_items_per_sub_container { get; set; }
        public long no_of_sub_container_per_container { get; set; }
        public long total_number_of_items { get; set; }
        public long number_of_containers { get; set; }
        public long container_no_of_items { get; set; }

        public string first_face_name { get; set; }
        public long first_face_id { get; set; }
        public string second_face_name { get; set; }
        public long second_face_id { get; set; }
        public string size_name { get; set; }
        public long size_id { get; set; }
        public string raw_material_type { get; set; }
        public string usage { get; set; }
        public string printing_type_name { get; set; }
    }
}
