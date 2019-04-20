using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_MURAN_MATERIAL : SH_RAW_TIN_GENERAL_INFO
    { 
        public long SH_ITEM_TOTAL_NUMBER_OF_PACKAGES { get; set; }
        public long SH_ITEM_TOTAL_NUMBER_OF_SHEETS { get; set; }
        public DateTime SH_CREATION_DATE { get; set; }

        //MURAN PROPERTIES
        public string SH_MURAN_TYPE { get; set; } // BOTTOM OR BODY
       
        public string SH_SIZE_NAME { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string SH_BOTTLE_CAPACITY { get; set; }
        public string SH_ITEM_FIRST_FACE { get; set; }
        public string SH_ITEM_SECOND_FACE { get; set; }
        public double SH_NUMBER_OF_GRAMS_IN_THE_FIRST_FACE { get; set; }
        public double SH_FIRST_FACE_NET_WEIGHT { get; set; }
        public double SH_NUMBER_OF_GRAMS_IN_THE_SECOND_FACE { get; set; }
        public double SH_SECOND_FACE_NET_WEIGHT { get; set; }
        public double SH_FIRST_FACE_SHEET_WEIGHT { get; set; }
        public double SH_SECOND_FACE_SHEET_WEIGHT { get; set; }
        public double SH_BOTTLE_HEIGHT { get; set; }








        //public double TOTAL_NET_WEIGHT ()
        //{

        //   //calculate total_net_weight
        //}







    }
}
