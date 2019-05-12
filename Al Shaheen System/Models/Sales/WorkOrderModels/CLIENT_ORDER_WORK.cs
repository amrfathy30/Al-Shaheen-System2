using System;


namespace Al_Shaheen_System
{
    
     public class CLIENT_ORDER_WORK
    {
        public long SH_ID { get; set; }
        public string SH_ID_STRING { get; set; }
        public string SH_CLIENT_NAME { get; set; }
        public string SH_ITEM_TYPE { get; set; }
        public long SH_CLIENT_ID { get; set; }
        public DateTime SH_TODAY_DATE { get; set; }
        public string SH_CLIENT_SUPPLY_ORDER_NUM { get; set; }
        public string SH_ITEM_NAME = "";
        public double SH_QUANTITY { get; set; }
        public double SH_UNIT_PRICE { get; set; }
        public double SH_TOTAL_PRICE { get; set; }
        public string SH_CURRENCY_NAME { get; set; }
        public double SH_TAX1 { get; set; }
        public double SH_TAX14 { get; set; }
        public double SH_TOTAL_COST_AFTER_TAXES { get; set; }
        public DateTime SH_START_SUPPLY_DATE { get; set; }
        public DateTime SH_END_SUPPLY_DATE { get; set; }
        public string SH_NOWLON { get; set; }
        public string SH_DELIVERING_ADDRESS = "";
        public double SH_SUBMITTED_MONEY { get; set; }
        public string SH_PAYMENT_WAY_SUBMITTED { get; set; }
        public string SH_DATE_OF_THE_CKECK_SUBMITTED = "";
        public double SH_MONEY_PAID_WHEN_DELIVERING { get; set; }
        public string SH_DATE_OF_THE_CKECK_WHEN_DELIVERD = "";
        public string SH_PAYMENT_WAY_WHEN_DELIVERING { get; set; }
        public double SH_MONEY_AFTER_RECIVING { get; set; }
        public string SH_PAYMENT_WAY_AFTER_RECIVING { get; set; }
        public string SH_DATE_OF_THE_CKECK_AFTER_RECIVING = "";
        public string SH_DURATION_AFTER_RECIVING = "";
        public long SH_CAN_DAIMETR = 0;
        public double SH_CAN_BUTTLE_HIGHT = 0;
        public long SH_LEHAM = 0;
        public long SH_LEHAM_AUTOMATIC = 0;
        public long SH_LEHAM_MANUAL = 0;
        public long SH_HAS_NECK = 0;
        public long SH_HAS_POWDER = 0;
        public string SH_POWER_COLOR = "";

        public long SH_NUMBER_OF_PEICES = 2; //في حاله العلبة فقط  
        public double SH_CANS_THICKNESS = 0;
        public long SH_THICKNESS_INCREASE_DECREASE_01 = 0;
        public long SH_NUMBER_OF_COLORS_OF_CAN = 0;


        public long SH_HAS_MURAN = 0;//ورنيش خارجي
        public long SH_HAS_PINDING = 0;
        public long SH_INSIDE_BEAD = 0;
        public long SH_OUT_BEAD = 0;
        public long SH_TAFLEEG = 0;
        public long SH_INSIDE_PULS = 0;
        public long SH_OUTSIDE_PULS = 0;
        public long SH_HAS_CAN_COVER = 0;
        public string SH_CAN_COVER_TYPE = "";
        public long SH_DIAMETR_TAPPA = 0;
        public string SH_TABA_TYPE = "";
        public string SH_TABA_COLOR = "";
        public long SH_HAS_PLASTIC_COVER_CAN = 0;
        public string SH_PLASTIC_COVER_COLOR_CAN = "";
        public long SH_HAS_PLASTIC_COVER_LOGO_CAN = 0;
        public string SH_INSIDE_MURAN = "";
        public string SH_OUTSIDE_MURAN = "";
        public string SH_EASY_OPEN_MATERIAL = "";
        public string SH_OPEN_WAY = "";
        public long SH_EASY_OPEN_DAIAMETR = 0;
        public long SH_RLT_DAIAMETR = 0;
        public string SH_TWIST_TYPE = "";
        public long SH_TWIST_SIZE = 0;
        public string SH_TWIST_DEEP_NORMAL_MEDIUM = "";
        public string SH_TWIST_COLOR = "";
        public string SH_PLASTIC_COVER_COLOR_ONLY = "";
        public long SH_PLASTIC_COVER_COVER_DAIMETR_ONLY = 0;
        public long SH_PLASTIC_COVER_HAS_AKLASHEH = 0;
        public string SH_PLASTIC_TABA_TYPE = "";
        public long SH_PLASTIC_TABA_DAIMETR = 0;
        public string SH_PLASTIC_TABA_LOCAL_OR_IMPORTED = "";
        public string SH_FACE_TYPE = "";
        public string SH_BOYATE_FACE_TYPE = "";
        public long SH_FACE_DAIMETR = 0;
        public long SH_PEELOFF_DAIMETR = 0;
        public long SH_CAN_HAS_TIN_COVER_OR_NOT = 0;
        public long SH_CAN_HAS_BUTTOM_OR_NOT = 0;
        public string SH_BANK_NAME_SUBMITTED = "";
        public string SH_BANK_NAME_WHEN_RECIVING = "";
        public string SH_BANK_NAME_AFTER_RECIVING = "";
        public string SH_CAN_BUTTUM_OUTSIDE_MURAN = "";

        public string SH_CAN_BUTTUM_INSIDE_MURAN = "";
        public string SH_CAN_TIN_COVER_INSIDE_MURAN = "";
        public string SH_CAN_TIN_COVER_OUTSIDE_MURAN = "";
        public string SH_CAN_MOLD_FACE_SHAPE = "";
        public string SH_PRINTING_STATE = "";

    }
}
