using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SPECIFICATION_OF_TWIST_OF
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string clientname { get; set; }
        public long SH_CLIENT_PRODUCT_ID { get; set; }
        public string clientproductname { get; set; }
        public long SH_SIZE_ID { get; set; }
        public string sizetitle { get; set; }
        public long SH_PILLOW_COLOR_ID { get; set; }
        public string pillowcolorname { get; set; }
        public long SH_FACE_COLOR_ID { get; set; }
        public string facecolorname { get; set; }
        public long SH_TWIST_OF_TYPE_ID { get; set; }
        public string twisttypename { get; set; }
        public string SH_TYPE { get; set; }
        public string SH_CONTAINER_NAME { get; set; }
        public long SH_NO_OF_CONTAINERS { get; set; }
        public long SH_FIRST_FACE_PILLOW_OR_NOT { get; set; }

        public List<SH_QUANTITY_OF_TWIST_OF> quantities = new List<SH_QUANTITY_OF_TWIST_OF>();

    }
}
