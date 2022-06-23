using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileStore.Models
{
    public class AboutPhone
    {
        public int AboutPhoneID { get; set; }
        public int PhoneID { get; set; }
        public string Firm { get; set; }
        public string Model { get; set; }
        public string CPU { get; set; }
        public string Camera { get; set; }
        public string Color { get; set; }
        public Phone Phones { get; set; }

    }
}
