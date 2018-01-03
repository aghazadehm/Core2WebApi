using System;
using System.Collections.Generic;

namespace Core2WebApi.Data.Entities
{
    public partial class FutureMarketDailyStatistics
    {
        public int ContractId { get; set; }
        public string ContractCode { get; set; }
        public int? TradesVolume { get; set; }
        public decimal? TradesValue { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? LastPrice { get; set; }
        public decimal? FirstPrice { get; set; }
        public int? OpenInterest { get; set; }
        public int? ChangeOpenInterest { get; set; }
        public int? ActiveCustomers { get; set; }
        public int? ActiveBrokers { get; set; }
        public int? CBuy { get; set; }
        public int? CSell { get; set; }
        public int? VolHoghooghiBuy { get; set; }
        public decimal? ValHoghooghiBuy { get; set; }
        public int? VolHoghooghiSell { get; set; }
        public decimal? ValHoghooghiSell { get; set; }
        public int? VolHaghighiBuy { get; set; }
        public decimal? ValHaghighiBuy { get; set; }
        public int? VolHaghighiSell { get; set; }
        public decimal? ValHaghighiSell { get; set; }
        public decimal? LastSettlementPrice { get; set; }
        public decimal TodaySettlementPrice { get; set; }
        public decimal? SettlementPricePercent { get; set; }
        public DateTime Dt { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Expired { get; set; }
    }
}
