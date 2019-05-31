using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_FILM_CLIENTS_AND_PRODUCTS
    {
        public long SH_ID { get; set; }
        public long SH_CLIENT_PRODUCT_FILM_ID { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public string client_name { get; set; }
        public long SH_CLIENT_PRODUCT_ID { get; set; }
        public string product_name { get; set; }
        public long SH_NO_BOTTELS_PER_SHEET { get; set; }
        public long SH_DATA_ENTRY_USER_ID { get; set; }
        public long SH_DATA_ENTRY_EMPLOYEE_ID { get; set; }
    }
}
