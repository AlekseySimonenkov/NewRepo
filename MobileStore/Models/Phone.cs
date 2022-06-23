using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStore.Models
{
    public class Phone
    {
        public int PhoneID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Firm")]
        public string Firm { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters.")]
        [Column("Model")]
        [Display(Name = "Model")]
        public string? Model { get; set; }
        [Required]
        [Column("Price")]
        public decimal? Price { get; set; }
        public int AbouPhoneID { get; set; }
        public AboutPhone AboutPhone { get; set; }
        public ICollection<BuyCart> BuyCarts { get; set; }
    }
}
