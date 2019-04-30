using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_PLASTIC_MOLD
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public long SH_SIZE_ID { get; set; }
        public long SH_NO_OF_CONTAINERS { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
        public long SH_PILLOW_COLOR_ID { get; set; }
        public long SH_MOLD_TYPE_ID { get; set; }
    }
}
