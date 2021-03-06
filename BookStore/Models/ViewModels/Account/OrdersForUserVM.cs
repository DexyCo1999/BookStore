using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels.Account
{
    public class OrdersForUserVM
    {

        public int OrderNumber { get; set; }
       
        public decimal Total { get; set; }

        public Dictionary<String, int> ProductsAndQty { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}