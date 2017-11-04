using System.Collections.Generic;

namespace Core2WebApi.Models
{
    public class Broker : ILinkContaining
    {
        private List<Link> _links;
        public int Id { get; internal set; }
        public int SpotCode { get; internal set; }
        public int DerivativeCode { get; internal set; }
        public string EnglishName { get; internal set; }
        public string PersianName { get; internal set; }
        public string CheifExecutiveOfficer { get; internal set; }
        public string Address { get; internal set; }
        public string PostalCode { get; internal set; }
        public string Tel { get; internal set; }
        public List<Link> Links
        {
            get => _links ?? (_links = new List<Link>());
            set => _links = value;
        }

        public void AddLink(Link link) => Links.Add(link);
    }
}