using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al_Shaheen_System
{
    class SH_CLIENT_PRODUCT_FILM
    {
        public long SH_ID { get; set; }
        public string SH_FILM_CODE { get; set; }
        public double SH_FILM_LENGTH { get; set; }
        public double SH_FILM_WIDTH { get; set; }
        public Image SH_FILM_IMAGE { get; set; }
        public DateTime SH_ADDITION_DATE { get; set; }
        public long SH_DATA_ENTRY_USER_ID { get; set; }
        public long SH_DATA_ENTRY_EMPLOYEE_ID { get; set; }
    }
}
