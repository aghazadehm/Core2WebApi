using AutoMapper;
using Core2WebApi.Models;

namespace src.Mapping {
    public class DomainProfile : Profile {
        public DomainProfile () {
            BrokerMappingProfile ();
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