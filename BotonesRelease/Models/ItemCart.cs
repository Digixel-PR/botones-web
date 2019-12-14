using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotonesRelease.Models
{
    public class ItemCart:Item
    {
        public int QtyInCart { get; set; }
        public decimal Total { get; set; }
    }
}