using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Repositories;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Contracts;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using core = MG.Jarvis.Core.Model.Contracts;

namespace MG.Jarvis.Api.Extranet.Test.Repositories
{
    [TestFixture]
    public class ContractRepositoryTest
    {
        private Mock<IConnection<Contract>> iContract;
        private Mock<IConnection<ContractOverview>> iContractListing;
        private Mock<IConfiguration> iconfiguration;
        private Mock<IConnection<HotelContractRelation>> iHotelContractRelation;
        private Mock<IConnection<ContractStatus>> iContractStatus;
        private IContract contractRepository;

        public ContractRepositoryTest()
        {
            iContract = new Mock<IConnection<Contract>>();
            iContractListing= new Mock<IConnection<ContractOverview>>();
            iconfiguration = new Mock<IConfiguration>();
            iHotelContractRelation = new Mock<IConnection<HotelContractRelation>>();
            iContractStatus = new Mock<IConnection<ContractStatus>>();
            contractRepository = new ContractRepository(
                                                        iContract.Object,
                                                        iContractListing.Object,
                                                        iconfiguration.Object,
                                                        iHotelContractRelation.Object,
                                                        iContractStatus.Object
                                                        );

        }
    }
}
