using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSystem.Models
{
    public class CardData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Barcode { get; set; }
    }
}