using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Areas.Admin.Data.ViewModels.Shop
{
    public class OrdersForAdminVM
    {
        public int OrderNumber { get; set; }
        public string Username { get; set; }
        public decimal Total { get; set; }

        public Dictionary<String, int> ProductsAndQty { get; set; }
      
        public DateTime CreatedAt { get; set; }
    }
}