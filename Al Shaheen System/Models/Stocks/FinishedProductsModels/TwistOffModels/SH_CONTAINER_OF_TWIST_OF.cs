﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_CONTAINER_OF_TWIST_OF
    {
        public long SH_ID { get; set; }
        public long SH_QUANTITY_OF_TWIST_OF_ID { get; set; }
        public DateTime SH_ADDTION_DATE { get; set; }
        public string SH_ADDITION_PERMISSION_NUMBER { get; set; }
        public long SH_NO_ITEMS { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SPECIFICATIONS_ID { get; set; }

        public string  type_kind { get; set; }
        public long first_Face_pillow_or_not { get; set; }
        public string  client_product_id { get; set; }
        public string client_product_name { get; set; }
        public  long pillow_color_id  { get; set; }
        public string pillow_color_name { get; set; }
        public long twist_of_size_id  { get; set; }
        public string  twist_of_size_name { get; set; }
        public string  twist_of_type { get; set; }

    }
}
