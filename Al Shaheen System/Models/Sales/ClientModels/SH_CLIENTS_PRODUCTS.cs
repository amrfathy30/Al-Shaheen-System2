using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_CLIENTS_PRODUCTS
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public string SH_PRODUCT_NAME { get; set; }
        public string SH_PRINTING_TYPE { get; set; }
        public double SH_BOTTLE_HEIGHT { get; set; }   
     public double SH_BOTTLE_CAPACITY { get; set; }
        public long SH_SECOND_FACE_ID { get; set; }
        public string SH_SECOND_FACE_NAME { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string SH_SIZE_NAME { get; set; }
    }
}
