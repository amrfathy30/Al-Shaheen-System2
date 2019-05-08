using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public string SH_FIRST_FACE { get; set; }
        public string SH_SECOND_FACE { get; set; }
        public string SH_MURAN_TYPE { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string SH_SIZE_NAME { get; set; }
        public double SH_HEIGHT { get; set; }
        public double SH_CAPACITY { get; set; }
        public long SH_TOTAL_NO_BOTTELS { get; set; }
        public long SH_TOTAL_NO_PALLETS { get; set; }

    }
}
