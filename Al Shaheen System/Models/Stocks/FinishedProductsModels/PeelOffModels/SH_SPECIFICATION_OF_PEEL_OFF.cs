using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_PEEL_OFF
    {
        public long SH_ID { get; set; }
        public string SH_RAW_MATERIAL_TYPE { get; set; }
        public string SH_USAGE { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string SH_SIZE_NAME { get; set; }
        public long SH_PRINTING_TYPE { get; set; }
        public string SH_PRINTING_TYPE_NAME { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public long SH_CLIENT_PRODUCT_ID { get; set; }
        public string SH_CLIENT_PRODUCT_NAME { get; set; }
        public long SH_FIRST_FACE_ID { get; set; }
        public string SH_FIRST_FACE_NAME { get; set; }
        public long SH_SECOND_FACE_ID { get; set; }
        public string SH_SECOND_FACE_NAME { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
    }
}
