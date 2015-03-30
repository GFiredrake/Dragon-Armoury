using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace Dragon_Armoury.Models
{
    public class Catagory
    {
        public int CatagoryId { get; set; }
        public string CatagoryName { get; set; }
        public string CatagoryDescription { get; set; }
    }
}