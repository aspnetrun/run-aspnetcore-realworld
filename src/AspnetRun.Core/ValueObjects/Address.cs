namespace AspnetRun.Core.ValueObjects
{
    public class Address
    {
        public string AddressDesc { get; set; }
        public string City { get; set; }
        public string Region { get; set; }        
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public Address()
        {
        }

        public Address(string addressDesc, string city, string region, string country, string postalCode)
        {
            AddressDesc = addressDesc;
            City = city;
            Region = region;
            Country = country;
            PostalCode = postalCode;
        }
    }
}
