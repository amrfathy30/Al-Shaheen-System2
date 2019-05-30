using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class rawtinaddingprinterdata
    {
        public string addition_permission_number { get; set; }
        public DateTime additiondate { get; set; }
        public SH_EMPLOYEES stock_man_name { get; set; }
        public SH_SHAHEEN_STOCK stock { get; set; }
        public List<SH_QUANTITY_OF_RAW_MATERIAL> quantities = new List<SH_QUANTITY_OF_RAW_MATERIAL>();
    }
}
