using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JDS_PRICELIST_2021.Models
{
    public class products
    {
     public  products()
        {
        }

        public int ItemID { get; set; }
        public string CLASS { get; set; }
        public string ITEM { get; set; }
        public string SHORT_DESCRIPTION { get; set; }
        public string DESCRIPTION_2 { get; set; }
        public int CASE_QTY { get; set; }
        public decimal LESS_THAN_CASE_PRICE { get; set; }
        public decimal ONE_CASE { get; set; }
        public decimal FIVE_CASE { get; set; }
        public decimal TEN_CASE { get; set; }
        public decimal WEIGHT { get; set; }
        public string IMAGE { get; set; }
        public string COLOR { get; set; }
        public string SIZE { get; set; }
        public string MATERIAL { get; set; }
        public string GENDER { get; set; }
        public string KEYWORD { get; set; }
        public string LONG_DESCRIPTION { get; set; }
        public string DESCRIPTION_1 { get; set; }
        public decimal LENGTH { get; set; }
        public decimal WIDTH { get; set; }
        public decimal HEIGHT { get; set; }
        public decimal PRICE_BREAK_4 { get; set; }
        public decimal PRICE_BREAK_5 { get; set; }
        public int PAGE { get; set; }
        public IEnumerable<Item> Items { get; set; }



    }
}
