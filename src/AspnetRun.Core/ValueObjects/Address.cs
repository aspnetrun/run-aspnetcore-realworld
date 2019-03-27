using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.ValueObjects
{
    public class Address
    {        
        public string AddressDesc { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
