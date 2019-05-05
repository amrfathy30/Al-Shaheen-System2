using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    public class SH_ACCOUNTING_ACCOUNTS_TREE
    {
        public long SH_ID { get; set; }
        public string SH_ACCOUNT_NO { get; set; }
        public long SH_PARENT_ACCOUNT_ID { get; set; }
        public string SH_PARENT_ACCOUNT_NO { get; set; }
        public string SH_ACCOUNT_NAME { get; set; }
        public long SH_ACCOUNT_LEVEL { get; set; }
        public long SH_ACCOUNT_ACTIVE { get; set; }
        public long SH_LAST_LEVEL_OR_NOT { get; set; }
        public long SH_ACCOUNT_TYPE_ID { get; set; }
        public string SH_ACCOUNT_TYPE_NAME { get; set; }
        public long SH_ACCOUNT_REVENU_AND_COST_CENTER_ID { get; set; }
        public string SH_ACCOUNT_REVENU_AND_COST_CENTER_NAME { get; set; }
    }
}
