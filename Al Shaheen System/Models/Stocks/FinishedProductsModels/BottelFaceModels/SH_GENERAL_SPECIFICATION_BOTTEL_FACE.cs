using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_GENERAL_SPECIFICATION_BOTTEL_FACE
    {
        public long SH_ID { get; set; }
        public long SH_BOTTEL_FACE_TYPE_ID { get; set; }
        public string SH_BOTTEL_FACE_TYPE_NAME { get; set; }
        public long SH_SPECIFICATION_AEROSOL_BOTTEL_FACE_ID { get; set; }
        public long SH_SPECIFICATION_MOLD_BOTTEL_FACE_ID { get; set; }
        public long SH_SPECIFICATION_OF_COVER_PLATE_BOTTEL_FACE_ID { get; set; }
        public long SH_SPECIFICATION_OF_SCREW_BOTTEL_FACE_ID { get; set; }
        public long SH_SPECIFICATION_OF_PRINTING_BOTTEL_FACE_ID { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_CONTAINERS { get; set; }
        public long SH_TOTAL_NO_ITEMS { get; set; }
    }
}
