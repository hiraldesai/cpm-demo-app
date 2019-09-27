using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NonprofitPlatform.Core.BusinessModel.CPM
{
    public class AddressIdentity
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("name")]
        public NameSettings Name { get; set; }
    }

    public class Address
    {
        [JsonProperty("addressLine1")]
        public string AddressLine1 { get; set; }
        [JsonProperty("addressLine2")]
        public string AddressLine2 { get; set; }
        [JsonProperty("addressLine3")]
        public string AddressLine3 { get; set; }
        [JsonProperty("unitNumber")]
        public string UnitNumber { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
    }
}
