using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class ContractTemplateResponseMapper
    {
        public static void MapToHotelFieldViewModel(List<TemplateHotelField> source, List<HotelFieldViewModel> destination)
        {
            foreach (var item in source)
            {
                destination.Add(AutoMapper.Mapper.Map<TemplateHotelField, HotelFieldViewModel>(item));
            }
        }
        public static void MapToRoomFieldViewModel(List<TemplateRoomField> source, List<RoomFieldViewModel> destination)
        {
            foreach (var item in source)
            {
                destination.Add(AutoMapper.Mapper.Map<TemplateRoomField, RoomFieldViewModel>(item));
            }
        }
        public static ContractTemplateViewModel MapToContractTemplateHotelViewModel(ContractTemplate sourcePrimary, List<TemplateHotelField> sourceSecondary)
        {
            var destination = AutoMapper.Mapper.Map<ContractTemplate, ContractTemplateViewModel>(sourcePrimary);
            MapToHotelFieldViewModel(sourceSecondary, destination.HotelFields);
            return destination;
        }
        public static ContractTemplateViewModel MapToContractTemplateRoomViewModel(ContractTemplate sourcePrimary, List<TemplateRoomField> sourceSecondary)
        {
            var destination = AutoMapper.Mapper.Map<ContractTemplate, ContractTemplateViewModel>(sourcePrimary);
            MapToRoomFieldViewModel(sourceSecondary, destination.RoomFields);
            return destination;
        }

        public static void MapToFacilityFieldToViewModel(List<TemplateHotelField> source, List<HotelFacilityGroupViewModel> destination)
        {
            foreach (var item in source)
            {
                // destination.Add(AutoMapper.Mapper.Map<TemplateHotelField, HotelFacilityGroupViewModel>(item));
                HotelFacilityGroupViewModel selectedDestination = destination.Where(d => d.FacilityGroupId == item.FacilityGroupId).FirstOrDefault();
                AutoMapper.Mapper.Map<TemplateHotelField, HotelFacilityGroupViewModel>(item, selectedDestination);
            }


            //foreach (var item in source)
            //{

            //    FacilityViewModel hotelFacilityModel = new FacilityViewModel
            //    {
            //        Id = item.Id,
            //        Name = item.Name,
            //        FacilityTypeId = item.FacilityTypeId,
            //        FacilityGroupId = item.FacilityGroupId,
            //        IsActive = item.IsActive,
            //        IsSelected = false
            //    };



            //}
        }
        public static List<RoomFacilityGroupViewModel> MapToRoomFacilityFieldViewModel(List<TemplateRoomField> sourcePrimary, List<RoomFacilityGroupViewModel> sourceSecondary)
        {
            var destination = new List<RoomFacilityGroupViewModel>();
            foreach (var item in sourcePrimary)
            {
                var selectedDestination = sourceSecondary.Where(d => d.Id == item.FacilityGroupId).First();
                AutoMapper.Mapper.Map<TemplateRoomField, RoomFacilityGroupViewModel>(item, selectedDestination);
                destination.Add(selectedDestination);
            }
            return destination;
        }

        /// <summary>
        /// MapTo Clause Library Fields To ViewModel
        /// </summary>
        /// <param name="source">source</param>
        /// <returns>List TemplateClauseLibraryViewModel</returns>
        public static List<TemplateClauseLibraryViewModel> MapToClauseLibraryFieldsToViewModel(List<TemplateClauseLibrary> source)
        {
           var destination = new List<TemplateClauseLibraryViewModel>();
            foreach (var item in source)
            {
                var field = AutoMapper.Mapper.Map<TemplateClauseLibrary, TemplateClauseLibraryViewModel>(item);
                destination.Add(field);
            }

            return destination;
        }
        /// <summary>
        /// Map count of facilities and amenities
        /// </summary>
        /// <param name="facilityCount"></param>
        /// <param name="amenityCount"></param>
        /// <returns>HotelFacilityRoomAmenity</returns>
        public static HotelFacilityRoomAmenity MapCountOfHotelFacilityRoomAmenity(int facilityCount,int amenityCount)
        {
            var hoteFacilityRoomAmenity = new HotelFacilityRoomAmenity()
            {
                AmenityCount = amenityCount,
                FacilityCount = facilityCount
            };
            return hoteFacilityRoomAmenity;
        }
    }
}
