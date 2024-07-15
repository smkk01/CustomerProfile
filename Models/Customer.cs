using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Age { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
