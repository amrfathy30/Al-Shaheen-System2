using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_MOLD_BOTTEL_FACE
    {
        public long SH_ID { get; set; }
        public long SH_MOLD_SIZE_ID { get; set; }
        public long SH_MOLD_SIZE_VALUE { get; set; }
        public long SH_MOLD_TYPE_ID { get; set; }
        public Image SH_MOLD_TYPE_IMAGE { get; set; }
        public long SH_HAS_HAND_OR_NOT { get; set; }
        public long SH_HAND_TYPE_ID { get; set; }
        public string SH_HAND_TYPE_NAME { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_OF_CONTAINER { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
    }
}
