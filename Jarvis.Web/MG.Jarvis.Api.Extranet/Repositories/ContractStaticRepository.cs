using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Repositories
{
    using Dapper;

    using MG.Jarvis.Api.Extranet.Helper;
    using MG.Jarvis.Api.Extranet.Helper.Mapper;
    using MG.Jarvis.Api.Extranet.Interfaces;
    using MG.Jarvis.Api.Extranet.Models.ViewModels;
    using MG.Jarvis.Api.Extranet.ViewModel;
    using MG.Jarvis.Core.DAL.Interfaces;
    using MG.Jarvis.Core.Model;
    using MG.Jarvis.Core.Model.Contracts;
    using MG.Jarvis.Core.Model.Hotel;
    using Microsoft.Extensions.Configuration;

    public class ContractStaticRepository : IContractStatic
    {
        #region private variable
        private IConnection<Contract> iContract;
        private IConfiguration iConfiguration;
        private IConnection<ContractOverview> iContractListing;
        private IConnection<ContractHotelProperties> iContractHotelProperties;
        private IConnection<TemplateHotelField> iTemplateHotelProperties;
        private IConnection<TemplateRoomField> iTemplateRoomProperties;
        private IConnection<ContractRoomProperties> iContractRoomProperties;
        private IConnection<ContractHotel> iContractHotel;
        private IConnection<Hotel> iHotel;
        private IConnection<Contacts> iContacts;
        private IConnection<ContractContact> iContractContact;
        private IConnection<ContractHotelTaxRelation> iContractHotelTaxRelation;
        #endregion private variable

        public ContractStaticRepository(
            IConnection<Contract> iContract,
            IConnection<ContractOverview> iContractListing,
            IConfiguration iConfiguration,
            IConnection<ContractHotelProperties> iContractHotelProperties,
            IConnection<TemplateHotelField> iTemplateHotelProperties,
            IConnection<TemplateRoomField> iTemplateRoomProperties,
            IConnection<ContractRoomProperties> iContractRoomProperties,
            IConnection<ContractHotel> iContractHotel,
            IConnection<Hotel> iHotel,
            IConnection<ContractHotelTaxRelation> iContractHotelTaxRelation,
            IConnection<ContractContact> iContractContact)
        {
            this.iContract = iContract;
            this.iContractListing = iContractListing;
            this.iConfiguration = iConfiguration;
            this.iContractHotelProperties = iContractHotelProperties;
            this.iContractRoomProperties = iContractRoomProperties;
            this.iTemplateHotelProperties = iTemplateHotelProperties;
            this.iTemplateRoomProperties = iTemplateRoomProperties;
            this.iContractHotel = iContractHotel;
            this.iHotel = iHotel;
            this.iContractHotelTaxRelation = iContractHotelTaxRelation;
            this.iContractContact = iContractContact;
        }

        /// <summary>
        /// The create contract.
        /// </summary>
        /// <param name="contractStaticViewModel">
        ///     The contract view model.
        /// </param>
        /// <param name="loggedUser">Logged in user name</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<BaseResult<ContractViewModel>> CreateContract(
            ContractStaticViewModel contractStaticViewModel,
            string loggedUser)
        {
            var result = new BaseResult<ContractViewModel>();

            var contract = new Contract();
            contract = DbMapperMasterdata.AutomapperContract(contractStaticViewModel, contract, loggedUser);

            contract.StatusID = 1;

            var insertResult = await this.iContract.InsertEntity(contract).ConfigureAwait(false);
            contractStaticViewModel.ContractId =(int) insertResult.Result;

            var insertResultHotelFields = await this.InsertTemplateFieldsToContractFieldsHotel(contractStaticViewModel)
                                              .ConfigureAwait(false);

            var insertResultRoomFields = await this.InsertTemplateFieldsToContractFieldsRoom(contractStaticViewModel)
                                             .ConfigureAwait(false);

            await this.SaveContractHotel(contractStaticViewModel,loggedUser).ConfigureAwait(false);

            await this.SaveContractContact(contractStaticViewModel, loggedUser).ConfigureAwait(false);

            //await this.SaveContractHotelTax(contractStaticViewModel, loggedUser).ConfigureAwait(false);

            if (insertResult.IsError && insertResult.ExceptionMessage != null)
            {
                result.IsError = insertResult.IsError;
                result.ExceptionMessage = insertResult.ExceptionMessage;
            }

            result.Result.Id = (int)insertResult.Result;
            return result;
        }

        /// <summary>
        /// The get contract by id.
        /// </summary>
        /// <param name="contractId">
        /// The contract id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<BaseResult<Contract>> GetContractById(int contractId)
        {
            var hotelList = new List<ContractHotelProperties>();
            var roomList = new List<ContractRoomProperties>();

            var result1 = this.GetRoomAndHotelProperties(contractId, out hotelList, out roomList);

            var result = new BaseResult<Contract> { Result = result1 };
            return result;
        }

        /// <summary>
        /// The get room and hotel properties.
        /// </summary>
        /// <param name="contractId">
        /// The contract id.
        /// </param>
        /// <param name="hotelList">
        /// The hotel list.
        /// </param>
        /// <param name="roomList">
        /// The room list.
        /// </param>
        /// <returns>
        /// The <see cref="Contract"/>.
        /// </returns>
        private Contract GetRoomAndHotelProperties(int contractId, out List<ContractHotelProperties> hotelList, out List<ContractRoomProperties> roomList)
        {
            var result = this.iContract.GetEntity(contractId);
            var paramsDynamicParameters = new DynamicParameters();
            paramsDynamicParameters.Add("@ContractId", contractId);
            hotelList = this.iContractHotelProperties.ExecuteStoredProcedure(
                Constants.StoredProcedure.GetHotelFieldsByTemplateId_HotelContract,
                paramsDynamicParameters).Result.Result;
            roomList = this.iContractRoomProperties.ExecuteStoredProcedure(
                Constants.StoredProcedure.GetRoomFieldsByTemplateId_RoomContract,
                paramsDynamicParameters).Result.Result;
            return result.Result.Result;
        }

        /// <summary>
        /// The save contract template fields.
        /// </summary>
        /// <param name="contractViewModel">
        /// The contract view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<BaseResult<long>> InsertTemplateFieldsToContractFieldsHotel(ContractStaticViewModel contractViewModel)
        {
            var hotelFields = await this.iTemplateHotelProperties
                                  .GetListByPredicate(
                                      p => p.IsSelected == true && p.TemplateId == contractViewModel.TemplateId)
                                  .ConfigureAwait(false);

            var insertList = new List<ContractHotelProperties>();
            foreach (var item in hotelFields.Result)
            {
                var entity = new ContractHotelProperties
                {
                    ContractId = contractViewModel.ContractId,
                    IsDeleted = item.IsDeleted,
                    FieldId = item.FieldId,
                    UpdatedBy = "sa",
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "sa",
                    CreatedDate = DateTime.Now
                };
                insertList.Add(entity);
            }

            var insertResult = await this.iContractHotelProperties.InsertEntityList(insertList).ConfigureAwait(false);

            return insertResult;
        }

        /// <summary>
        /// The save contract hotel.
        /// </summary>
        /// <param name="contractStaticViewModel">
        /// The contract static view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<BaseResult<ContractHotel>> SaveContractHotel(ContractStaticViewModel contractStaticViewModel,string loggedUser)
        {
            var result = new BaseResult<ContractHotel>();

            var contractHotelViewModel = new ContractHotelViewModel
                                                                {
                                                                    HotelDetailsViewModel =
                                                                        contractStaticViewModel
                                                                            .HotelDetailsViewModel,
                                                                    ContractId = contractStaticViewModel.ContractId
                                                                };

            var mappedModel = DbMapperMasterdata.AutomapperContractHotel(contractHotelViewModel.HotelDetailsViewModel,loggedUser);
            mappedModel.ContractId = contractStaticViewModel.ContractId;
            var u = this.iHotel.GetEntity(mappedModel.HotelId).Result.Result;
            mappedModel.NameItemId = u.NameItemId;
            mappedModel.ShortDescriptionItemId = u.ShortDescriptionItemId;

            var insertResult = await this.iContractHotel.InsertEntity(mappedModel).ConfigureAwait(false);

            if (insertResult.IsError && insertResult.ExceptionMessage != null)
            {
                result.IsError = insertResult.IsError;
                result.ExceptionMessage = insertResult.ExceptionMessage;
            }

            return result;
        }

        private async Task<BaseResult<long>> SaveContractContact(ContractStaticViewModel contractStaticViewModel,string loggedUser)
        {
            var contractContactList = new List<ContractContact>();
            foreach (var item in contractStaticViewModel.HotelDetailsViewModel.ContactDetails)
            {
                if(item.ObjectState== ObjectState.Added)
                {
                    item.HotelId = contractStaticViewModel.HotelDetailsViewModel.HotelId;
                    var contractContactViewModel = DbMapperMasterdata.AutomapperContractContactViewModel(item);
                    var contractContactModel = DbMapperMasterdata.AutomapperContractContact(contractContactViewModel, loggedUser);
                    contractContactModel.Contractid = contractStaticViewModel.ContractId;
                    contractContactList.Add(contractContactModel);
                }
            }

           var result = await iContractContact.InsertEntityList(contractContactList).ConfigureAwait(false);
           return result;

        }

        private async Task<BaseResult<long>> SaveContractHotelTax(ContractStaticViewModel contractStaticViewModel,string loggedUser)
        {
            var result = new BaseResult<long>();
            var contractHotelTaxList = new List<ContractHotelTaxRelation>();
            foreach (var item in contractStaticViewModel.HotelDetailsViewModel.TaxDetails)
            {
                var mappedViewModel = AutoMapper.Mapper.Map<ContractHotelTaxRelationViewModel>(item);
                var mappedmodel = DbMapperMasterdata.AutomapperContractHotelTaxRelation(mappedViewModel, loggedUser);
                mappedmodel.HotelId = contractStaticViewModel.HotelDetailsViewModel.HotelId;
                mappedmodel.ContractId = contractStaticViewModel.ContractId;
                contractHotelTaxList.Add(mappedmodel);
                result = await this.iContractHotelTaxRelation.InsertEntity(mappedmodel).ConfigureAwait(false);
            }

            //var result = await this.iContractHotelTaxRelation.InsertEntityList(contractHotelTaxList).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// The save contract template fields.
        /// </summary>
        /// <param name="contractViewModel">
        /// The contract view model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task<BaseResult<long>> InsertTemplateFieldsToContractFieldsRoom(ContractStaticViewModel contractViewModel)
        {
            var roomFields = await this.iTemplateRoomProperties
                                 .GetListByPredicate(
                                     p => p.IsSelected == true && p.TemplateId == contractViewModel.TemplateId)
                                 .ConfigureAwait(false);

            var insertList = new List<ContractRoomProperties>();

            foreach (var item in roomFields.Result)
            {
                var entity = new ContractRoomProperties
                {
                    ContractId = contractViewModel.ContractId,
                    IsDeleted = item.IsDeleted,
                    FieldId = item.FieldId,
                    UpdatedBy = "sa",
                    UpdatedDate = DateTime.Now,
                    CreatedBy = "sa",
                    CreatedDate = DateTime.Now
                };
                insertList.Add(entity);
            }

            var insertResult = await this.iContractRoomProperties.InsertEntityList(insertList).ConfigureAwait(false);

            return insertResult;
        }

    }
}
