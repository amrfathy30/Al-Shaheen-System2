using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_QUANTITIES_OF_CUT_MURAN_MATERIAL
    {
        public long SH_ID { get; set; }
        public long SH_SPECIFICATION_OF_CUT_MURAN_MATERIAL_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public string SH_FIRST_FACE { get; set; }
        public string SH_SECOND_FACE { get; set; }
        public string SH_MURAN_TYPE { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string SH_SIZE_NAME { get; set; }
        public double SH_HEIGHT { get; set; }
        public double SH_CAPACITY { get; set; }
        public DateTime SH_ADDTION_DATE { get; set; }
        public string SH_ADDTION_PERMISSION_NUMBER { get; set; }
        public string SH_WORK_ORDER_NUMBER { get; set; }
        public long SH_CUTTER_ID { get; set; }
        public string SH_CUTTER_NAME { get; set; }
        public long SH_STOCK_ID { get; set; }
        public string SH_STOCK_NAME { get; set; }
        public string SH_CUTTER_TECHNICAL_MAN { get; set; }
        public long SH_TOTAL_NUMBER_OF_BOTTELS { get; set; }
        public long SH_TOTAL_NUMBER_OF_PALLETS { get; set; }

        public List<SH_PALLETS_OF_CUT_MURAN_MATERIAL> q_pallets = new List<SH_PALLETS_OF_CUT_MURAN_MATERIAL>();
     
          }
}
