using System;

/// <summary>
/// فرارداد اخنیار معامله
/// </summary>
namespace Core2WebApi.Models.Derivatives.Option {
    public class OptionContract {
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
    }
}