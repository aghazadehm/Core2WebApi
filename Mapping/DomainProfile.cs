using System;
using AutoMapper;
using Core2WebApi.Models;
using Core2WebApi.Models.Derivatives.Future;

namespace src.Mapping {
    public class DomainProfile : Profile {
        public DomainProfile () {
            BrokerMappingProfile ();
            FutureContractMapping ();
        }

        private void FutureContractMapping () {
            CreateMap<Core2WebApi.Data.Entities.ContractFuture, FutureContract> ()
                .ForMember (dest => dest.CommodityAbbreviation, opt => opt.MapFrom (src => src.CommodityAbbreviation))
                .ForMember (dest => dest.CommodityID, opt => opt.MapFrom (src => src.CommodityId))
                .ForMember (dest => dest.CommodityName, opt => opt.MapFrom (src => src.CommodityName))
                .ForMember (dest => dest.CommoditySymbol, opt => opt.MapFrom (src => src.CommoditySymbol))
                .ForMember (dest => dest.ContractCode, opt => opt.MapFrom (src => src.ContractCode))
                .ForMember (dest => dest.ContractDescription, opt => opt.MapFrom (src => src.ContractDescription))
                .ForMember (dest => dest.ContractID, opt => opt.MapFrom (src => src.ContractId))
                .ForMember (dest => dest.ContractSize, opt => opt.MapFrom (src => src.ContractSize))
                .ForMember (dest => dest.FirstTradingDate, opt => opt.MapFrom (src => src.FirstTradingDate))
                .ForMember (dest => dest.LastIM, opt => opt.MapFrom (src => src.LastIm))
                .ForMember (dest => dest.LastMM, opt => opt.MapFrom (src => src.LastMm))
                .ForMember (dest => dest.LastTradingDate, opt => opt.MapFrom (src => src.LastTradingDate));
        }

        private void BrokerMappingProfile () {
            //CreateMap<Broker, Broker> ();

            CreateMap<Core2WebApi.Data.Entities.Broker, Broker> ()
                .ForMember (dest => dest.Address, opt => opt.MapFrom (src => src.BrokerAddress))
                .ForMember (dest => dest.CheifExecutiveOfficer, opt => opt.MapFrom (src => src.BrokerCeoName))
                .ForMember (dest => dest.DerivativeCode, opt => opt.MapFrom (src => src.BrokerDerivativeKey))
                .ForMember (dest => dest.EnglishName, opt => opt.MapFrom (src => src.BrokerEnglishName))
                .ForMember (dest => dest.PersianName, opt => opt.MapFrom (src => src.BrokerPersianName))
                .ForMember (dest => dest.PostalCode, opt => opt.MapFrom (src => src.BrokerPostalCode))
                .ForMember (dest => dest.SpotCode, opt => opt.MapFrom (src => src.BrokerSpotKey))
                .ForMember (dest => dest.Tel, opt => opt.MapFrom (src => src.BrokerTel))
                .ForMember (dest => dest.Id, opt => opt.MapFrom (src => src.BrokerKey));
            //.ForMember(dest => dest.SpotTrading, opt => opt.MapFrom(src => src.))
        }
    }
}