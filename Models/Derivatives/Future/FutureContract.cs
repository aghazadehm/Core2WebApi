using System;
using System.Collections.Generic;

namespace Core2WebApi.Models.Derivatives.Future {
    /// <summary>
    /// فرارداد آتی
    /// </summary>
    public class FutureContract : ILinkContaining {
        private List<Link> _links;
        public string CommodityAbbreviation { get; internal set; }
        public int CommodityID { get; internal set; }
        public string CommodityName { get; internal set; }
        public string CommoditySymbol { get; internal set; }
        public string ContractCode { get; internal set; }
        public string ContractDescription { get; internal set; }
        public int ContractID { get; internal set; }
        public int ContractSize { get; internal set; }
        public DateTime FirstTradingDate { get; internal set; }
        public decimal LastIM { get; internal set; }
        public decimal LastMM { get; internal set; }
        public DateTime LastTradingDate { get; internal set; }
        public List<Link> Links {
            get => _links ?? (_links = new List<Link> ());
            set => _links = value;
        }
        public void AddLink (Link link) {
            Links.Add (link);
        }
    }
}