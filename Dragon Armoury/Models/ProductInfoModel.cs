using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Dragon_Armoury.Models
{
    [Serializable]
    public class ProductInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string ProductId { get; set; }
        public string StockNumber { get; set; }
        public string PayPalLink { get; set; }
        public string AlwayCustom { get; set; }
    }
}