using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_CUTTER_BALANCEcs
    {
        public long SH_ID{ get; set; }
    
    public double SH_ITEM_LENGTH { get; set; }
        public double SH_ITEM_WIDTH { get; set; }
        public double SH_ITEM_THICKNESS { get; set; }
        public string SH_ITEM_TYPE { get; set; }
        public string SH_ITEM_NAME { get; set; }
        public string SH_ITEM_CODE { get; set; }
        public string SH_ITEM_FIRST_FACE { get; set; }
        public string SH_ITEM_SECOND_FACE { get; set; }
        public string SH_MURAN_TYPE { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string SH_SIZE_NAME { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public DateTime SH_ADDITION_DATE { get; set;}
        public string SH_ENTERED_BY { get; set;}
    }
}
