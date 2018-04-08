using AutoMapper;
using MG.Jarvis.Api.BackOffice.Interfaces;
using MG.Jarvis.Api.BackOffice.Models.Response;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.BackOffice.Repositories
{
    public class AgencyRepository : IAgency
    {
        private IConnection<Core.Model.Agency.Agency> iAgency;
        private IConnection<Core.Model.Agency.AgencyContacts> iAgencyContact;
        private IConnection<Core.Model.Agency.IncludedCountryRelation> iAgencyIncludedCountry;
        private IConnection<Core.Model.Agency.ExcludedCountryRelation> iAgencyExcludedCountry;
        private IConnection<Core.Model.Agency.AgencySupplierRelation> iAgencySupplierRelation;
        private IConnection<Core.Model.Agency.Bank> iAgencyBank;
        private IConnection<Core.Model.Agency.Payment> iAgencyPayment;
        private IConnection<Core.Model.Agency.Agents> iAgencySuperUser;
        private IConnection<Core.Model.Agency.Branch> iAgencyBranch;
        private IConnection<Core.Model.Agency.BranchAgentRelation> iAgencyBranchAgentRelation;
        private IConnection<Currency> iCurrency;
        private IConnection<Country> iCountry;
        private AgencyViewModel agencyViewModel;
        private AgencyIncludedCountry agencyIncludedCountryViewModel;
        private AgencyExcludedCountry agencyExcludedCountryViewModel;


        private readonly string ClassName = "";

        public AgencyRepository(IConnection<Core.Model.Agency.Agency> iAgencyConnection,
                                                              IConnection<Core.Model.Agency.AgencyContacts> iAgencyContacts,
                                                              IConnection<Core.Model.Agency.IncludedCountryRelation> iAgencyIncludedCountry,
                                                              IConnection<Core.Model.Agency.ExcludedCountryRelation> iAgencyExcludedCountry,
                                                              IConnection<Core.Model.Agency.Payment> iAgencyPayment,
                                                              IConnection<Core.Model.Agency.Bank> iAgencyBank,
                                                              IConnection<Core.Model.Agency.AgencySupplierRelation> iAgencySupplier,
                                                              IConnection<Core.Model.Agency.Agents> iAgencySuperUser,
                                                              IConnection<Core.Model.Agency.Branch> iAgencyBranch,
                                                              IConnection<Core.Model.Agency.BranchAgentRelation> iBranchAgentRelation,
                                                              IConnection<Currency> iCurrency,
                                                              IConnection<Country> iCountry)
        {

            this.iAgency = iAgencyConnection;
            this.iAgencyContact = iAgencyContacts;
            this.iAgencyIncludedCountry = iAgencyIncludedCountry;
            this.iAgencyExcludedCountry = iAgencyExcludedCountry;
            this.iAgencySupplierRelation = iAgencySupplier;
            this.iAgencyBank = iAgencyBank;
            this.iAgencyPayment = iAgencyPayment;
            this.iAgencySuperUser = iAgencySuperUser;
            this.iAgencyBranch = iAgencyBranch;
            this.iAgencyBranchAgentRelation = iBranchAgentRelation;
            this.iCurrency = iCurrency;
            this.ClassName = "AgencyRepository";
            this.agencyViewModel = new AgencyViewModel();
            this.agencyIncludedCountryViewModel = new AgencyIncludedCountry();
            this.agencyExcludedCountryViewModel = new AgencyExcludedCountry();
            this.iCountry = iCountry;

        }

        public virtual async Task<BaseResult<List<Models.Response.Agency>>> Get()
        {
            BaseResult<List<Models.Response.Agency>> agencyList = new BaseResult<List<Models.Response.Agency>>();
            List<AgencyIncludedCountry> includedCountryList = new List<AgencyIncludedCountry>();
            List<AgencyExcludedCountry> excludedCountryList = new List<AgencyExcludedCountry>();


            var list = await iAgency.GetListByPredicate(s => s.IsActive && !s.IsDeleted);
            var currencyCodeList = await iCurrency.GetListByPredicate(c => c.IsActive && !c.IsDeleted);
            var countryCodeList = await iCountry.GetListByPredicate(c => c.IsActive && !c.IsDeleted);

            if (list != null && list.Result != null && list.Result.Count > 0)
            {
                agencyList.Result = new List<Models.Response.Agency>();
                foreach (var agency in list.Result)
                {
                    var agencyContacts = await iAgencyContact.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.AgencyId == agency.Id);
                    var agencyPayment = await iAgencyPayment.GetListByPredicate(a => !a.IsDeleted && a.AgencyId == agency.Id);
                    var agencyBank = await iAgencyBank.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.AgencyId == agency.Id);
                    var agencyIncludedCountries = await iAgencyIncludedCountry.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.AgencyId == agency.Id);
                    var agencyExcludedCountries = await iAgencyExcludedCountry.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.AgencyId == agency.Id);
                    var agencySuppliers = await iAgencySupplierRelation.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.AgencyId == agency.Id);

                    var branchId = iAgencyBranch.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.AgencyId == agency.Id &&
                                                                        a.IsHeadOffice == true).Result.Result.Select(x => x.Id).FirstOrDefault();

                    var agentId = iAgencyBranchAgentRelation.GetListByPredicate(a => a.IsActive
                                                            && !a.IsDeleted && a.BranchId == branchId && a.IsSuperUser == true).Result.Result.Select(x => x.AgentId).FirstOrDefault();

                    var agencyAgents = await iAgencySuperUser.GetListByPredicate(a => a.IsActive && !a.IsDeleted && a.Id == agentId);

                    var currencyCode = currencyCodeList.Result.Where(c => c.Id == agency.CurrencyId).Select(x => x.Code).FirstOrDefault();


                    agencyViewModel = Mapper.Map<AgencyViewModel>(agency);
                    agencyViewModel.CurrencyCode = currencyCode;

                    foreach (var inCountry in agencyIncludedCountries.Result)
                    {
                        var countryCode = countryCodeList.Result.Where(c => c.Id == inCountry.CountryId).Select(x => x.Code).FirstOrDefault();

                        agencyIncludedCountryViewModel = Mapper.Map<AgencyIncludedCountry>(inCountry);
                        agencyIncludedCountryViewModel.CountryCode = countryCode;
                        includedCountryList.Add(agencyIncludedCountryViewModel);
                    }

                    foreach (var exCountry in agencyExcludedCountries.Result)
                    {
                        var countryCode = countryCodeList.Result.Where(c => c.Id == exCountry.CountryId).Select(x => x.Code).FirstOrDefault();

                        agencyExcludedCountryViewModel = Mapper.Map<AgencyExcludedCountry>(exCountry);
                        agencyExcludedCountryViewModel.CountryCode = countryCode;
                        excludedCountryList.Add(agencyExcludedCountryViewModel);
                    }

                    agencyList.Result.Add(new Agency
                    {
                        MGAgency = agencyViewModel,                        
                        AgencyContacts = (agencyContacts.IsError == false && agencyContacts.Result != null && agencyContacts.Result.Count > 0) ? agencyContacts.Result : null,
                        Payment = (agencyPayment.IsError == false && agencyPayment.Result != null && agencyPayment.Result.Count > 0) ? agencyPayment.Result[0] : null,
                        Bank = (agencyBank.IsError == false && agencyBank.Result != null && agencyBank.Result.Count > 0) ? agencyBank.Result[0] : null,
                        IncludedCountryRelation = includedCountryList.Count() > 0 ? includedCountryList : null,
                        ExcludedCountryRelation = excludedCountryList.Count() > 0 ? excludedCountryList : null,
                        AgencySupplierRelation = (agencySuppliers.IsError == false && agencySuppliers.Result != null && agencySuppliers.Result.Count > 0) ? agencySuppliers.Result : null,
                        SuperUserAgent = (agencyAgents.IsError == false && agencyAgents.Result != null && agencyAgents.Result.Count > 0) ? agencyAgents.Result[0] : null,
                    });

                }
            }
            else
            {
                agencyList.IsError = list.IsError;
                agencyList.ErrorCode = list.ErrorCode;
                agencyList.ExceptionMessage = list.ExceptionMessage;
                agencyList.Message = list.Message;
            }

            return agencyList;
        }


    }
}
