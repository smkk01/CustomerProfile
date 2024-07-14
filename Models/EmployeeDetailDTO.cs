using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCwithWebAPI.Models
{
    public class EmployeeDetailDTO
    {
        public string  EmployeeID
        {
            get;
            set;
        }
        public string FristName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string ContactType
        {
            get;
            set;
        }
        public string ContactInfo
        {
            get;
            set;
        }
    }
}