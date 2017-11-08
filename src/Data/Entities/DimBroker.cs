using System;
using System.Collections.Generic;

namespace Core2WebApi.Data.Entities
{
    public partial class DimBroker
    {
        public int BrokerKey { get; set; }
        public int? BrokerSpotKey { get; set; }
        public int? BrokerDerivativeKey { get; set; }
        public string BrokerPersianName { get; set; }
        public string BrokerEnglishName { get; set; }
        public string BrokerCeoName { get; set; }
        public string BrokerAddress { get; set; }
        public string BrokerPostalCode { get; set; }
        public string BrokerTel { get; set; }
    }
}
