using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BotonesRelease.Models
{
    public class Cart
    {
        public List<ItemCart> ItemList { get; set; } = new List<ItemCart>();
    }
}