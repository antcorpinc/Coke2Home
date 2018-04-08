using MG.Jarvis.Api.Extranet.AutoMapperHelper.Resolvers;
using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Mapper.Request;
using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.RatesCategory;
using MG.Jarvis.Core.Model.Reservation;
using MG.Jarvis.Core.Model.Room;
using MG.Jarvis.Model.Response.Reservation;
using am = AutoMapper;

namespace MG.Jarvis.Api.Extranet.AutoMapperHelper
{
    public static class AutoMapper
    {
        public static void Initialize()
        {
            am.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<HotelDetailsViewModel, Hotel>()
                .ForMember(dto => dto.Code, opt => opt.ResolveUsing<HotelCodeResolver>())
                .ForMember(dto => dto.Id, opt => opt.ResolveUsing<HotelIdResolver>())
                .ForMember(dto => dto.Name, opt => opt.ResolveUsing<HotelNameResolver>())
                .ForMember(dto => dto.CheckInFrom, opt => opt.ResolveUsing<CheckInFromResolver>())
                 //.ForMember(dto => dto.CheckInTo, opt => opt.ResolveUsing<CheckInToResolver>())
                 //.ForMember(dto => dto.CheckOutFrom, opt => opt.ResolveUsing<CheckOutFromFromResolver>())
                 .ForMember(dto => dto.CheckOutTo, opt => opt.ResolveUsing<CheckOutToResolver>());
                cfg.CreateMap<ContactDetailsViewModel, MG.Jarvis.Core.Model.Hotel.Contacts>()
                    .ForMember(dto => dto.Id, opt => opt.ResolveUsing<ContactIdResolver>());
                cfg.CreateMap<HotelTaxRelationViewModel, HotelTaxRelation>();
                cfg.CreateMap<CancellationPolicyViewModel, CancellationPolicy>()
              .ForMember(dto => dto.Id, opt => opt.ResolveUsing<CancellationPolicyIdResolver>());
                cfg.CreateMap<CancellationPolicyClausesViewModel, CancellationPolicyClauses>()
                    .ForMember(dto => dto.Id, opt => opt.ResolveUsing<CancellationPolicyClausesIdResolver>());
                cfg.CreateMap<HotelPaymentMethodRelationViewModel, HotelPaymentMethodRelation>()
                    .ForMember(dto => dto.Id, opt => opt.ResolveUsing<HotelPaymentMethodRelationIdResolver>());
                cfg.CreateMap<HotelMessageViewModel, Message>()
                    .ForMember(dto => dto.Id, opt => opt.ResolveUsing<MessageIdResolver>());
                cfg.CreateMap<HotelRoomTypeViewModel, Room>()
                    .ForMember(dto => dto.Id, opt => opt.ResolveUsing<RoomIdResolver>());
                cfg.CreateMap<RoomBedListViewModel, RoomBedRelation>();
                // cfg.CreateMap<HotelField, HotelFacilityGroupViewModel>().ReverseMap();
                // cfg.CreateMap<HotelField, HotelFacilityGroupViewModel>().ForMember(d => d.HotelFacilityTypes, opt=> opt.MapFrom(src=>src.FacilityTypeName)).ReverseMap();
                //    cfg.CreateMap<HotelField, HotelFacilityTypeViewModel>().ForMember(d => d.FacilityList, opt => opt.MapFrom(src => src.FieldName)).ReverseMap();

                //cfg.CreateMap<HotelField, HotelFacilityGroupViewModel>()
                //.ForMember(
                //    dest => dest.HotelFacilityTypes,
                //    opt => opt.MapFrom(
                //        src => new HotelFacilityTypeViewModel  { FacilityTypeName = src.FacilityTypeName, FacilityTypeId =src.FacilityTypeId }));
                //            }
                cfg.CreateMap<TemplateRoomField, RoomFacilityGroupViewModel>().
                        ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FieldId)).
                        ForMember(dest => dest.Status, opt => opt.ResolveUsing(source => Common.GetEntityStatus(source.TemplateId)));
                cfg.CreateMap<TemplateHotelField, HotelFacilityGroupViewModel>().
                    ForMember(dest => dest.IsConfigurable, opt => opt.MapFrom(src => src.IsConfigurable)).
                        ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FieldId)).
                        ForMember(dest => dest.Status, opt => opt.ResolveUsing(source => Common.GetEntityStatus(source.TemplateId)));
                cfg.CreateMap<HotelField, HotelFieldViewModel>();
                cfg.CreateMap<RoomField, RoomFieldViewModel>();
                cfg.CreateMap<TemplateHotelField, HotelFieldViewModel>().
                        ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FieldId)).
                        ForMember(dest => dest.Status, opt => opt.ResolveUsing(source => Common.GetEntityStatus(source.TemplateId)));
                cfg.CreateMap<TemplateRoomField, RoomFieldViewModel>().
                        ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FieldId)).
                        ForMember(dest => dest.Status, opt => opt.ResolveUsing(source => Common.GetEntityStatus(source.TemplateId)));
                cfg.CreateMap<ContractTemplate, ContractTemplateViewModel>();
                cfg.CreateMap<HotelFieldViewModel, TemplateHotelField>()
                .ForMember(dto => dto.FieldId, opt => opt.ResolveUsing<TemplateHotelFieldIdResolver>());
                cfg.CreateMap<RoomFieldViewModel, TemplateRoomField>()
                .ForMember(dto => dto.FieldId, opt => opt.ResolveUsing<TemplateRoomFieldIdResolver>());
                cfg.CreateMap<ContractTemplateViewModel, ContractTemplate>();
                cfg.CreateMap<HotelFacilityGroupViewModel, TemplateHotelField>().
                ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.Id)).
                ForMember(dest => dest.IsSelected, opt => opt.MapFrom(src => src.IsSelected));
                cfg.CreateMap<RoomFacility, RoomFacilityViewModel>();
                cfg.CreateMap<RoomFacilityType, RoomFacilityTypeViewModel>();
                cfg.CreateMap<RoomFacilityGroup, RoomFacilityGroupViewModel>();
                cfg.CreateMap<RoomFacilityGroupViewModel, TemplateRoomField>().
               ForMember(dest => dest.FieldId, opt => opt.MapFrom(src => src.Id));
                cfg.CreateMap<TemplateClauseLibrary, TemplateClauseLibraryViewModel>().
                   ForMember(dest => dest.Status, opt => opt.ResolveUsing(source => Common.GetEntityStatus(source.TemplateId)));
                cfg.CreateMap<TemplateClauseLibraryViewModel, TemplateClauseLibraryRelation>();

                //cfg.CreateMap<HotelField, HotelFacilityGroupViewModel>()
                //.ForMember(
                //    dest => dest.HotelFacilityTypes,
                //    opt => opt.MapFrom(
                //        src => new HotelFacilityTypeViewModel  { FacilityTypeName = src.FacilityTypeName, FacilityTypeId =src.FacilityTypeId }));
                //            }
                cfg.CreateMap<Reservation, ReservationMaster>().
                        ForMember(dest => dest.Hotel,
                        opt => opt.MapFrom(src => new HotelDetail { Code = src.HotelCode, Id = src.HotelId, Name = src.HotelName })).
                         ForMember(dest => dest.Currency,
                        opt => opt.MapFrom(src => new ReservationCurrency { Id = src.ReservationCurrencyId, Name = src.CurrencyName, Symbol = src.CurrencySymbol })).
                        ForMember(dest => dest.CheckIn, opt => opt.MapFrom(src => src.CheckIn)).
                        ForMember(dest => dest.CheckOut, opt => opt.MapFrom(src => src.CheckOut));

                cfg.CreateMap<Reservation, ReservationRoom>().
                ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.RoomCode)).
                ForMember(dest => dest.ReservationId, opt => opt.MapFrom(src => src.RoomReservationId)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoomName)).
                ForMember(dest => dest.TotalNumberOfAdults, opt => opt.MapFrom(src => src.NumberOfAdults)).
                ForMember(dest => dest.TotalNumberOfChildren, opt => opt.MapFrom(src => src.NumberOfChildren)).
                ForMember(dest => dest.TotalNumberOfGuest, opt => opt.MapFrom(src => src.NumberOfGuest));

                cfg.CreateMap<Reservation, RoomPrice>();
                cfg.CreateMap<RateCategoryViewModel, RateCategory>();
                cfg.CreateMap<RatePlansViewModel, RatePlans>();
                cfg.CreateMap<RateCategory, RateCategoryViewModel>();
                cfg.CreateMap<RatePlans, RatePlansViewModel>();
                cfg.CreateMap<MarketDetailsViewModel, Market>().
                ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MarketName));
                cfg.CreateMap<MarketCountriesViewModel, MarketIncludedCountryRelation>();
                cfg.CreateMap<MarketCountriesViewModel, MarketExcludedCountryRelation>();
                cfg.CreateMap<MarketIncludedAndExcludedCountries, MarketIncludedAndExcludedCountriesViewModel>();
                cfg.CreateMap<ContractViewModel, Contract>().
                    ForMember(dest => dest.ContractType, opt => opt.MapFrom(src => Common.GetContractType(src.ContractType.Value))).
                    ForMember(dest => dest.TemplateType, opt => opt.MapFrom(src => Common.GetTemplateType(src.ContractType.Value)));
                cfg.CreateMap<ContractViewModel, HotelContractRelation>().
                   ForMember(dest => dest.ContractId, opt => opt.MapFrom(src => src.Id));
                cfg.CreateMap<Designation, DesignationViewModel>().
                ForMember(dest => dest.DesignationId, opt => opt.MapFrom(src => src.Id));
                // ForMember(dest => dest.BasePrice, opt => opt.MapFrom(src => src.BasePrice)).
                //  ForMember(dest => dest., opt => opt.MapFrom(src => src.RoomReservationId)).
                // ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.RoomName));

                cfg.CreateMap<ContractHotelPropertiesViewModel, ContractHotelProperties>();
                cfg.CreateMap<ContractStaticViewModel, Contract>();
                cfg.CreateMap<ContractStaticViewModel, ContractHotelViewModel>();
                cfg.CreateMap<HotelDetailsViewModel, ContractHotel>();
                cfg.CreateMap<ContractContactViewModel, ContractContact>();
                cfg.CreateMap<ContactDetailsViewModel, ContractContactViewModel>();
                cfg.CreateMap<ContractHotelTaxRelationViewModel, ContractHotelTaxRelation>();
                cfg.CreateMap<HotelTaxRelationViewModel, ContractHotelTaxRelationViewModel>();
            });
        }
    }
}
