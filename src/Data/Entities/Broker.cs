using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core2WebApi.Data.Entities
{
    [Table("DimBroker")]
    public class Broker
    {
        public Broker()
        {
            //SpotTrading = new HashSet<SpotTrading>();
        }

        public int BrokerKey { get; set; }
        public int? BrokerSpotKey { get; set; }
        public int? BrokerDerivativeKey { get; set; }
        public string BrokerPersianName { get; set; }
        public string BrokerEnglishName { get; set; }
        public string BrokerCeoName { get; set; }
        public string BrokerAddress { get; set; }
        public string BrokerPostalCode { get; set; }
        public string BrokerTel { get; set; }

        //public ICollection<SpotTrading> SpotTrading { get; set; }
    }
}