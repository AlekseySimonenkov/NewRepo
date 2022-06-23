using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStore.Models
{
    public class BuyCart
    {
        [Key]
        public int PhoneID { get; set; }
        
        public int ClientID { get; set; }
        public string Firm { get; set; }
        public string Model { get; set; }
        public ICollection<Phone> Phones { get; set; }
        public Client Client { get; set; }
    }
}
