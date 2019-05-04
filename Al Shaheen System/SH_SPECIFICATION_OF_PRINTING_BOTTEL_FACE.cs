using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE
    {
        public long SH_ID { get; set; }
        public long SH_PAINTING_SHAPE_TYPE_ID { get; set; }
        public string SH_PAINTING_SHAPE_TYPE_NAME { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_CONTAINER { get; set; }
        public long SH_NO_ITEMS_PER_CONTAINER { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
    }
}
