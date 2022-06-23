using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MobileStore.Models
{
    public class Client
    {
        

        public int ClientID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Phone]
        public int PhoneNumber { get; set; }
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
        public BuyCart BuyCarts { get; set; }
    }
}
