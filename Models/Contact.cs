using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactType { get; set; }
        public string Contactinfo { get; set; }
        public int Id { get; set; }
        public virtual Employee Employee { get; set; }

    }
}