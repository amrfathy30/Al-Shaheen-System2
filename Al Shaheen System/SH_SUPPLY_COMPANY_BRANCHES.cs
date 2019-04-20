using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_SUPPLY_COMPANY_BRANCHES
    {
        public long SH_ID { get; set; }
        public long SH_SUPPLY_COMAPNY_ID { get; set; }
        public string SH_SUPPLY_COMPANY_NAME { get; set; }
        public string SH_COMPANY_BRANCH_NAME { get; set; }
        public string SH_COMPANY_BRANCH_TYPE { get; set; }
        public string SH_COMPANY_BRANCH_ADDRESS_TEXT { get; set; }
        public string SH_COMPANY_BRANCH_ADDRESS_GPS_LINK { get; set; }
    }
}
