using System;
using System.Collections.Generic;

namespace Core2WebApi.Data.Entities
{
    public partial class ContractFuture
    {
        public int ContractId { get; set; }
        public int? CommodityId { get; set; }
        public string CommodityAbbreviation { get; set; }
        public string CommoditySymbol { get; set; }
        public string CommodityName { get; set; }
        public string ContractCode { get; set; }
        public string ContractDescription { get; set; }
        public int? ContractSize { get; set; }
        public DateTime? FirstTradingDate { get; set; }
        public DateTime? LastTradingDate { get; set; }
        public decimal? LastIm { get; set; }
        public decimal? LastMm { get; set; }
    }
}
