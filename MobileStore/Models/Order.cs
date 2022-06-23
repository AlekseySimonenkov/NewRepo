using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStore.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
       // public int CartID { get; set; }
        public decimal? Cost { get; set; }
       // public Cart Cart { get; set; }
        //public Client Client { get; set; }
    }
}
