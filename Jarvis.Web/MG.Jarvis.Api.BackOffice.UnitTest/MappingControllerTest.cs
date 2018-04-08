//using MG.Jarvis.Api.BackOffice.Controllers;
//using MG.Jarvis.Api.BackOffice.Helper;
//using MG.Jarvis.Api.BackOffice.Interfaces;
//using MG.Jarvis.Api.BackOffice.Models;
//using MG.Jarvis.Core.Model;
//using MG.Jarvis.Core.Model.Hotel;
//using MG.Jarvis.Core.Model.MasterData;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Moq;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace MG.Jarvis.Api.BackOffice.UnitTest
//{
//    [TestFixture]
//    public class MappingControllerTest
//    {
//        #region private variable
//        private MappingController mappingController;
//        private Mock<IMasterData<Supplier>> supplierMasterDataMock;
//        private Mock<IMasterData<Nationality>> nationalityMasterDataMock;
//        private Mock<IMasterData<Core.Model.Mappings.Nationality>> nationalityMappingMock;
//        private Mock<IMasterData<Core.Model.Mappings.Country>> countryMappingMock;
//        private Mock<IMasterData<Country>> countryMasterDataMock;
//        private Mock<IMasterData<Core.Model.Mappings.City>> cityMappingMock;
//        private Mock<IMasterData<City>> cityMasterDataMock;
//        private Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMasterData;        
//        private Mock<IMasterData<Hotel>> hotelMasterData;
//        private Mock<IMasterData<Core.Model.Mappings.Promotions>> promotionCodeMappingData;
//        private Mock<IMasterData<RoomTypes>> roomTypeMasterData;
//        private Mock<IMasterData<Core.Model.Mappings.RoomTypes>> roomTypeCodeMappingData;
//        private Mock<IMasterData<Core.Model.Mappings.MealTypes>> mealTypeMappingDataMock;
//        private Mock<IMasterData<Meals>> mealMasterDataMock;
//        private Mock<IConfiguration> iConfigurationMock;
//        #endregion Private Variables

//        public MappingControllerTest()
//        {
//            supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            nationalityMasterDataMock = new Mock<IMasterData<Nationality>>();
//            nationalityMappingMock = new Mock<IMasterData<Core.Model.Mappings.Nationality>>();
//            countryMappingMock = new Mock<IMasterData<Core.Model.Mappings.Country>>();
//            countryMasterDataMock = new Mock<IMasterData<Country>>();
//            cityMappingMock = new Mock<IMasterData<Core.Model.Mappings.City>>();
//            cityMasterDataMock = new Mock<IMasterData<City>>();
//            hotelMappingMasterData = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();            
//            hotelMasterData = new Mock<IMasterData<Hotel>>();
//            promotionCodeMappingData = new Mock<IMasterData<Core.Model.Mappings.Promotions>>();
//            roomTypeMasterData = new Mock<IMasterData<RoomTypes>>();
//            roomTypeCodeMappingData = new Mock<IMasterData<Core.Model.Mappings.RoomTypes>>();
//            mealTypeMappingDataMock = new Mock<IMasterData<Core.Model.Mappings.MealTypes>>();
//            mealMasterDataMock = new Mock<IMasterData<Meals>>();
//            iConfigurationMock = new Mock<IConfiguration>();
//            mappingController = new MappingController(supplierMasterDataMock.Object,
//                                                      nationalityMasterDataMock.Object,
//                                                      nationalityMappingMock.Object,
//                                                      countryMappingMock.Object,
//                                                      countryMasterDataMock.Object,
//                                                      cityMappingMock.Object,
//                                                      cityMasterDataMock.Object,
//                                                      hotelMappingMasterData.Object,
//                                                      hotelMasterData.Object,
//                                                      promotionCodeMappingData.Object,
//                                                      roomTypeMasterData.Object,
//                                                      roomTypeCodeMappingData.Object,
//                                                      mealTypeMappingDataMock.Object,
//                                                      mealMasterDataMock.Object,
//                                                      iConfigurationMock.Object);
//        }

//        #region MapNationality Test Cases

//        [Test]
//        public void TestMappingControllerMapNationalityInsertSuccessResponse()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",                
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            nationalityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
//            {
//                Result = new List<Nationality>() { new Nationality { Id = 1, Code = "ind", IsDeleted = false } }
//            }));

//            nationalityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Nationality>>()
//            {
//                Result = new List<Core.Model.Mappings.Nationality>() { new Core.Model.Mappings.Nationality() }
//            }));

//            nationalityMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Nationality>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<NationalityRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.MappingSuccessMessage);
//            Assert.IsFalse(resultValue.IsError);
//            Assert.IsNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityInsertPartialSuccessResponse()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" },
//                new SupplierNationalityCodeMap { MGNationalityCode = "XYZ", SupplierNationalityCode = "M_XYZ" } //nationality code does not exsits in database  
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",               
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            nationalityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
//            {
//                Result = new List<Nationality>() {
//                    new Nationality { Id = 1, Code = "IND", IsDeleted = false } //Only 'IND' nationality code exsits in database  
//                }
//            }));

//            nationalityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Nationality>>()
//            {
//                Result = new List<Core.Model.Mappings.Nationality>() { new Core.Model.Mappings.Nationality() }
//            }));

//            nationalityMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Nationality>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<NationalityRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityUpdateSuccessResponse()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            nationalityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
//            {
//                Result = new List<Nationality>() { new Nationality { Id = 1, Code = "IND", IsDeleted = false } }
//            }));

//            nationalityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Nationality>>()
//            {
//                Result = new List<Core.Model.Mappings.Nationality>() {
//                    new Core.Model.Mappings.Nationality {
//                        Id=1,
//                        SupplierId =1,
//                        NationalityId =1,
//                        SupplierNationalityCode = "M_IND2" //Same record exist but SupplierNationalityCode is different hence update
//                    }
//                }
//            }));

//            nationalityMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Nationality>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<NationalityRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.MappingSuccessMessage);
//            Assert.IsFalse(resultValue.IsError);
//            Assert.IsNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityUpdatePartialSuccessResponse()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" },
//                new SupplierNationalityCodeMap { MGNationalityCode = "XYZ", SupplierNationalityCode = "M_XYZ" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            nationalityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
//            {
//                Result = new List<Nationality>() {
//                    new Nationality { Id = 1, Code = "IND", IsDeleted = false } //Only 'IND' nationality code exsits in database  
//                }
//            }));

//            nationalityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Nationality>>()
//            {
//                Result = new List<Core.Model.Mappings.Nationality>() {
//                    new Core.Model.Mappings.Nationality {
//                        Id=1,
//                        SupplierId =1,
//                        NationalityId =1,
//                        SupplierNationalityCode = "M_IND2" //Same record exist but SupplierNationalityCode is different hence update
//                    }
//                }
//            }));

//            nationalityMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Nationality>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<NationalityRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityBadRequestNoNationalityMasterDataExists()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            nationalityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Nationality>>()
//            {
//                Result = new List<Nationality>() // No Records in Nationality MasterData
//            }));

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Nationality MasterData"));
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityBadRequestSupplierNotExists()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "HB", IsDeleted = false } } // Only HotelBed "HB" exists in Supplier Master
//            }));

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Supplier"));
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityInvalidInputNullRequest()
//        {
//            NationalityRequest mockRequest = null;
//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityInvalidInputEmptySupplierCode()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = string.Empty, // Empty Supplier Code
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Supplier Code"));
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityInvalidInputEmptyCreatedBy()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = string.Empty,// Empty Created By
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityInvalidInputEmptyUpdatedBy()
//        {
//            List<SupplierNationalityCodeMap> mockSupplierNationalityInfoList = new List<SupplierNationalityCodeMap>
//            {
//                new SupplierNationalityCodeMap { MGNationalityCode = "IND", SupplierNationalityCode = "M_IND" }
//            };

//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                UpdatedBy = string.Empty,// Empty Updated By
//                CreatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierNationalityCodeMapping.AddRange(mockSupplierNationalityInfoList);

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapNationalityInvalidInputNullSupplierNationalityInfo()
//        {           
//            NationalityRequest mockRequest = new NationalityRequest
//            {
//                SupplierCode = "GTA",
//                UpdatedBy = "Bhavnaj",
//                CreatedBy = "Bhavnaj"
//            };       

//            var result = mappingController.MapNationality(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "SupplierNationalityInfo"));
//        }      
        
//        [Test]
//        public void TestMappingControllerGetNationalityMappingsExecptionServerError()
//        {
//            nationalityMappingMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetNationalityCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetNationalityMappings().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetNationalityMappingsExecptionNoContent()
//        {
//            nationalityMappingMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetNationalityCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetNationalityMappings().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetNationalityMappingsFailed()
//        {
//            Core.Model.Mappings.Nationality nationality = new Core.Model.Mappings.Nationality()
//            {
//                Id = 1,
//                NationalityId = 1,
//                SupplierId = 1,
//                SupplierNationalityCode = "IND",
//                IsActive = true,
//                IsDeleted = false

//            };
//            List<Core.Model.Mappings.Nationality> nationalityList = new List<Core.Model.Mappings.Nationality>()
//            {
//                nationality
//            };
//            Mock<IMasterData<Core.Model.Mappings.Nationality>> mock = new Mock<IMasterData<Core.Model.Mappings.Nationality>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetNationalityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = nationalityList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, mock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object,roomTypeMasterData.Object, roomTypeCodeMappingData.Object,mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetNationalityMappings().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }
//        [Test]
//        public void TestMappingControllerGetNationalityMappingsIsSuccess()
//        {
//            Core.Model.Mappings.Nationality nationality = new Core.Model.Mappings.Nationality()
//            {
//                Id = 1,
//                NationalityId = 1,
//                SupplierId = 1,
//                SupplierNationalityCode = "IND",
//                IsActive = true,
//                IsDeleted = false

//            };
//            List<Core.Model.Mappings.Nationality> nationalityList = new List<Core.Model.Mappings.Nationality>()
//            {
//                nationality
//            };
//            Mock<IMasterData<Core.Model.Mappings.Nationality>> mock = new Mock<IMasterData<Core.Model.Mappings.Nationality>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetNationalityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = nationalityList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, mock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetNationalityMappings().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetNationalityMappingsNoContent()
//        {


//            Mock<IMasterData<Core.Model.Mappings.Nationality>> mock = new Mock<IMasterData<Core.Model.Mappings.Nationality>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetNationalityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, mock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetNationalityMappings().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }
//        #endregion

//        #region MapCountry Test Cases

//        [Test]
//        public void TestMappingControllerMapCountryInsertSuccessResponse()
//        {
//            List<SupplierCountryCodeMap> mockmockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockmockSupplierCountryInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            countryMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
//            {
//                Result = new List<Country>() { new Country { Id = 1, Code = "IN", IsDeleted = false } }
//            }));

//            countryMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Country>>()
//            {
//                Result = new List<Core.Model.Mappings.Country>() { new Core.Model.Mappings.Country() }
//            }));

//            countryMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Country>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<CountryRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.MappingSuccessMessage);
//            Assert.IsFalse(resultValue.IsError);
//            Assert.IsNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInsertPartialSuccessResponse()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" },
//                new SupplierCountryCodeMap { MGCountryCode = "XY", SupplierCountryCode = "M_XY" } //country code does not exsits in database  
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            countryMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
//            {
//                Result = new List<Country>() {
//                    new Country { Id = 1, Code = "IN", IsDeleted = false } //Only 'IN' country code exsits in database  
//                }
//            }));

//            countryMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Country>>()
//            {
//                Result = new List<Core.Model.Mappings.Country>() { new Core.Model.Mappings.Country() }
//            }));

//            countryMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Country>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<CountryRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryUpdateSuccessResponse()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            countryMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
//            {
//                Result = new List<Country>() { new Country { Id = 1, Code = "IN", IsDeleted = false } }
//            }));

//            countryMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Country>>()
//            {
//                Result = new List<Core.Model.Mappings.Country>() {
//                    new Core.Model.Mappings.Country {
//                        Id=1,
//                        SupplierId =1,
//                        MGCountryId =1,
//                        SupplierCountryCode = "M_IN2" //Same record exist but SupplierCountryCode is different hence update
//                    }
//                }
//            }));

//            countryMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Country>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<CountryRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.MappingSuccessMessage);
//            Assert.IsFalse(resultValue.IsError);
//            Assert.IsNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryUpdatePartialSuccessResponse()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" },
//                new SupplierCountryCodeMap { MGCountryCode = "XY", SupplierCountryCode = "M_XY" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            countryMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
//            {
//                Result = new List<Country>() {
//                    new Country { Id = 1, Code = "IN", IsDeleted = false } //Only 'IND' country code exsits in database  
//                }
//            }));

//            countryMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Country>>()
//            {
//                Result = new List<Core.Model.Mappings.Country>() {
//                    new Core.Model.Mappings.Country {
//                        Id=1,
//                        SupplierId =1,
//                        MGCountryId =1,
//                        SupplierCountryCode = "M_IN2" //Same record exist but SupplierCountryCode is different hence update
//                    }
//                }
//            }));

//            countryMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Country>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<CountryRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInsertionFailedPartialSuccessResponse()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            countryMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
//            {
//                Result = new List<Country>() { new Country { Id = 1, Code = "IN", IsDeleted = false } }
//            }));

//            countryMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Country>>()
//            {
//                Result = new List<Core.Model.Mappings.Country>() { new Core.Model.Mappings.Country() }
//            }));

//            countryMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Country>())).Returns(
//                Task.FromResult(new BaseResult<long>() { Result = 0, IsError = true, ExceptionMessage = new Exception () }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((BaseResult<CountryRequest>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }


//        [Test]
//        public void TestMappingControllerMapCountryBadRequestNoCountryMasterDataExists()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            countryMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Country>>()
//            {
//                Result = new List<Country>() // No Records in Country MasterData
//            }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Country MasterData"));
//        }

//        [Test]
//        public void TestMappingControllerMapCountryBadRequestSupplierNotExists()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "HB", IsDeleted = false } } // Only HotelBed "HB" exists in Supplier Master
//            }));

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Supplier"));
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInvalidInputNullRequest()
//        {
//            CountryRequest mockRequest = null;
//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInvalidInputEmptySupplierCode()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = string.Empty, // Empty Supplier Code
//                CreatedBy = "Bhavnaj",
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Supplier Code"));
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInvalidInputEmptyCreatedBy()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = string.Empty,// Empty Created By
//                UpdatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInvalidInputEmptyUpdatedBy()
//        {
//            List<SupplierCountryCodeMap> mockSupplierCountryInfoList = new List<SupplierCountryCodeMap>
//            {
//                new SupplierCountryCodeMap { MGCountryCode = "IN", SupplierCountryCode = "M_IN" }
//            };

//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                UpdatedBy = string.Empty,// Empty Updated By
//                CreatedBy = "Bhavnaj"
//            };
//            mockRequest.SupplierCountryCodeMapping.AddRange(mockSupplierCountryInfoList);

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapCountryInvalidInputNullSupplierCountryInfo()
//        {            
//            CountryRequest mockRequest = new CountryRequest
//            {
//                SupplierCode = "GTA",
//                UpdatedBy = "Bhavnaj",
//                CreatedBy = "Bhavnaj"
//            };         

//            var result = mappingController.MapCountry(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((BaseResult<long>)(((ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "SupplierCountryCodeMapping"));
//        }    
        
//        [Test]
//        public void TestMappingControllerGetCountryMappingsExecptionServerError()
//        {
//            countryMappingMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCountryCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetCountryMappings().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetCountryMappingsExecptionNoContent()
//        {
//            countryMappingMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCountryCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetCountryMappings().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetCountryMappingsIsSuccess()
//        {
//            Core.Model.Mappings.Country country = new Core.Model.Mappings.Country()
//            {
//                Id = 1,
//                MGCountryId = 1,
//                SupplierId = 1,
//                SupplierCountryCode = "",
//                IsActive = true,
//                IsDeleted = false

//            };
//            List<Core.Model.Mappings.Country> countryList = new List<Core.Model.Mappings.Country>()
//            {
//                country
//            };
//            Mock<IMasterData<Core.Model.Mappings.Country>> mock = new Mock<IMasterData<Core.Model.Mappings.Country>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCountryCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = countryList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, mock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object,promotionCodeMappingData.Object,roomTypeMasterData.Object,roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetCountryMappings().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetCountryMappingsFailed()
//        {
//            Core.Model.Mappings.Country country = new Core.Model.Mappings.Country()
//            {
//                Id = 1,
//                MGCountryId = 1,
//                SupplierId = 1,
//                SupplierCountryCode = "",
//                IsActive = true,
//                IsDeleted = false

//            };
//            List<Core.Model.Mappings.Country> countryList = new List<Core.Model.Mappings.Country>()
//            {
//                country
//            };
//            Mock<IMasterData<Core.Model.Mappings.Country>> mock = new Mock<IMasterData<Core.Model.Mappings.Country>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = countryList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, mock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetCountryMappings().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }

//        [Test]
//        public void TestMappingControllerGetCountryMappingsNoContent()
//        {
//            Mock<IMasterData<Core.Model.Mappings.Country>> mock = new Mock<IMasterData<Core.Model.Mappings.Country>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCountryCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, mock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetCountryMappings().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }
        
//        # endregion

//        #region MapCity Test Cases

//        [Test]
//        public void TestMappingControllerMapCityInsertSuccessResponse()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            cityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.City>>()
//            {
//                Result = new List<Core.Model.MasterData.City>() { new Core.Model.MasterData.City { Id = 1, Code = "BBSR", IsDeleted = false } }
//            }));

//            cityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.City>>()
//            {
//                Result = new List<Core.Model.Mappings.City>() { new Core.Model.Mappings.City() }
//            }));

//            cityMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.City>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<CityRequest>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.MappingSuccessMessage);
//            Assert.IsFalse(resultValue.IsError);
//            Assert.IsNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCityInsertPartialSuccessResponse()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" },
//                new SupplierCityCodeMap { MGCityCode = "MAA", SupplierCityCode = "M_MAA" } //city code does not exsits in database  
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            cityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.City>>()
//            {
//                Result = new List<Core.Model.MasterData.City>() {
//                    new Core.Model.MasterData.City { Id = 1, Code = "MAA", IsDeleted = false } //Only 'MAA' city code exsits in database  
//                }
//            }));

//            cityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.City>>()
//            {
//                Result = new List<Core.Model.Mappings.City>() { new Core.Model.Mappings.City() }
//            }));

//            cityMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.City>())).Returns(Task.FromResult(new BaseResult<long>() { Result = 1, IsError = false }));

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<CityRequest>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCityUpdateSuccessResponse()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            cityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.City>>()
//            {
//                Result = new List<Core.Model.MasterData.City>() { new Core.Model.MasterData.City { Id = 1, Code = "BBSR", IsDeleted = false } }
//            }));

//            cityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.City>>()
//            {
//                Result = new List<Core.Model.Mappings.City>() {
//                    new Core.Model.Mappings.City {
//                        Id=1,
//                        SupplierId =1,
//                        MGCityId =1,
//                        SupplierCityCode = "M_BBSR2" //Same record exist but SupplierCityCode is different hence update
//                    }
//                }
//            }));

//            cityMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.City>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<CityRequest>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.MappingSuccessMessage);
//            Assert.IsFalse(resultValue.IsError);
//            Assert.IsNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCityUpdatePartialSuccessResponse()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "MAA", SupplierCityCode = "M_MAA" },
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            cityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.City>>()
//            {
//                Result = new List<Core.Model.MasterData.City>() {
//                    new Core.Model.MasterData.City { Id = 1, Code = "MAA", IsDeleted = false } //Only 'MAA' city code exsits in database  
//                }
//            }));

//            cityMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.City>>()
//            {
//                Result = new List<Core.Model.Mappings.City>() {
//                    new Core.Model.Mappings.City {
//                        Id=1,
//                        SupplierId =1,
//                        MGCityId =1,
//                        SupplierCityCode = "M_MAA2" //Same record exist but SupplierCityCode is different hence update
//                    }
//                }
//            }));

//            cityMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.City>())).Returns(Task.FromResult(new BaseResult<bool>() { Result = true, IsError = false }));

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<CityRequest>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.PartialMappingSuccessMsg);
//            Assert.IsTrue(resultValue.IsError);
//            Assert.IsNotNull(resultValue.Result);
//        }

//        [Test]
//        public void TestMappingControllerMapCityBadRequestNoCityMasterDataExists()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "GTA", IsDeleted = false } }
//            }));

//            cityMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.MasterData.City>>()
//            {
//                Result = new List<Core.Model.MasterData.City>() // No Records in City MasterData
//            }));

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "City MasterData"));
//        }

//        [Test]
//        public void TestMappingControllerMapCityBadRequestSupplierNotExists()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>()
//            {
//                Result = new List<Supplier>() { new Supplier { Id = 1, Code = "HB", IsDeleted = false } } // Only HotelBed "HB" exists in Supplier Master
//            }));

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.EntityNotExists, "Supplier"));
//        }

//        [Test]
//        public void TestMappingControllerMapCityInvalidInputNullRequest()
//        {
//            CityRequest mockRequest = null;
//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapCityInvalidInputEmptySupplierCode()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = string.Empty, // Empty Supplier Code
//                CreatedBy = "biswameeth",
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "Supplier Code"));
//        }

//        [Test]
//        public void TestMappingControllerMapCityInvalidInputEmptyCreatedBy()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                CreatedBy = string.Empty,// Empty Created By
//                UpdatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapCityInvalidInputEmptyUpdatedBy()
//        {
//            List<SupplierCityCodeMap> mockSupplierCityInfoList = new List<SupplierCityCodeMap>
//            {
//                new SupplierCityCodeMap { MGCityCode = "BBSR", SupplierCityCode = "M_BBSR" }
//            };

//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                UpdatedBy = string.Empty,// Empty Updated By
//                CreatedBy = "biswameeth"
//            };
//            mockRequest.SupplierCityCodeMapping.AddRange(mockSupplierCityInfoList);

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, Constants.InvalidRequest);
//        }

//        [Test]
//        public void TestMappingControllerMapCityInvalidInputNullSupplierCityInfo()
//        {           
//            CityRequest mockRequest = new CityRequest
//            {
//                SupplierCode = "GTA",
//                UpdatedBy = "biswameeth",
//                CreatedBy = "biswameeth"
//            };          

//            var result = mappingController.MapCity(mockRequest).Result;
//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//            var resultValue = ((MG.Jarvis.Core.Model.BaseResult<long>)(((Microsoft.AspNetCore.Mvc.ObjectResult)result).Value));
//            Assert.AreEqual(resultValue.Message, string.Format(Constants.IsNullOrEmpty, "SupplierCityCodeMapping"));
//        }
       
//        [Test]
//        public void TestMappingControllerGetCityMappingsExecptionServerError()
//        {
//            cityMappingMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCityCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetCityMappings().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetCityMappingsExecptionNoContent()
//        {
//            cityMappingMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCityCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetCityMappings().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetCityMappingsIsSuccess()
//        {
//            Core.Model.Mappings.City city = new Core.Model.Mappings.City()
//            {
//                Id = 1,
//                MGCityId = 1,
//                SupplierId = 1,
//                SupplierCityCode = "",
//                IsActive = true,
//                IsDeleted = false

//            };
//            List<Core.Model.Mappings.City> cityList = new List<Core.Model.Mappings.City>()
//            {
//                city
//            };
//            Mock<IMasterData<Core.Model.Mappings.City>> mock = new Mock<IMasterData<Core.Model.Mappings.City>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = cityList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, mock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object,promotionCodeMappingData.Object,roomTypeMasterData.Object,roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetCityMappings().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetCityMappingsFailed()
//        {
//            Core.Model.Mappings.City city = new Core.Model.Mappings.City()
//            {
//                Id = 1,
//                MGCityId = 1,
//                SupplierId = 1,
//                SupplierCityCode = "",
//                IsActive = true,
//                IsDeleted = false

//            };
//            List<Core.Model.Mappings.City> cityList = new List<Core.Model.Mappings.City>()
//            {
//                city
//            };
//            Mock<IMasterData<Core.Model.Mappings.City>> mock = new Mock<IMasterData<Core.Model.Mappings.City>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = cityList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, mock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetCityMappings().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }

//        [Test]
//        public void TestMappingControllerGetCityMappingsNoContent()
//        {


//            Mock<IMasterData<Core.Model.Mappings.City>> mock = new Mock<IMasterData<Core.Model.Mappings.City>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetCityCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, mock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetCityMappings().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }
        
//        #endregion

//        #region MapHotel Test cases    

//        [Test]
//        public void TestMappingControllerMapHotelSuccessOKResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            HotelsAndSuppliersHotelMappingCode mappingBaseModel = new HotelsAndSuppliersHotelMappingCode()
//            {
//                MGHotelCode = "TEST",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "BRA",
//                SupplierHotelCode = "TESTMAP"
//            };

//            mappingBaseModelList.Add(mappingBaseModel);
//            hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel.AddRange(mappingBaseModelList);

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TEST",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 2
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelNullRequestObjectFailResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = null;

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TEST",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 2
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object,roomTypeMasterData.Object, roomTypeCodeMappingData.Object,mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelNullMappingListObjectFailResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            //List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            //HotelsAndSuppliersHotelMappingCode mappingBaseModel = null;
//            //mappingBaseModelList.Add(mappingBaseModel);
//            //hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel = mappingBaseModelList;

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TEST",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 2
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object,roomTypeMasterData.Object, roomTypeCodeMappingData.Object,mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelNoSupplierFailResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            HotelsAndSuppliersHotelMappingCode mappingBaseModel = new HotelsAndSuppliersHotelMappingCode()
//            {
//                MGHotelCode = "TEST",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "BRA",
//                SupplierHotelCode = "TESTMAP"
//            };

//            mappingBaseModelList.Add(mappingBaseModel);
//            hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel.AddRange(mappingBaseModelList);

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TEST",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 2
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = new List<Supplier>(), IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelNoHotelFailResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            HotelsAndSuppliersHotelMappingCode mappingBaseModel = new HotelsAndSuppliersHotelMappingCode()
//            {
//                MGHotelCode = "TEST",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "BRA",
//                SupplierHotelCode = "TESTMAP"
//            };

//            mappingBaseModelList.Add(mappingBaseModel);
//            hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel.AddRange(mappingBaseModelList);

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 2
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = new List<Hotel>(), IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelNoMatchingHotelCodefailResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            HotelsAndSuppliersHotelMappingCode mappingBaseModel = new HotelsAndSuppliersHotelMappingCode()
//            {
//                MGHotelCode = "TEST",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "BRA",
//                SupplierHotelCode = "TESTMAP"
//            };

//            mappingBaseModelList.Add(mappingBaseModel);
//            hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel.AddRange(mappingBaseModelList);

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TESTFail",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 2
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelUpdateMappingSuccessOkResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            HotelsAndSuppliersHotelMappingCode mappingBaseModel = new HotelsAndSuppliersHotelMappingCode()
//            {
//                MGHotelCode = "TEST",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "BRA",
//                SupplierHotelCode = "TESTMAP"
//            };

//            mappingBaseModelList.Add(mappingBaseModel);
//            hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel.AddRange (mappingBaseModelList);

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TEST",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 1
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object,roomTypeMasterData.Object,roomTypeCodeMappingData.Object,mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);
//        }

//        [Test]
//        public void TestMappingControllerMapHotelUpdateMappingFailResponse()
//        {
//            HotelMappingRequest hotelMappingRequest = new HotelMappingRequest()
//            {
//                CreatedBy = "jayeshka",
//                SupplierCode = "TEST",
//                UpdatedBy = "jayeshka"
//            };

//            List<HotelsAndSuppliersHotelMappingCode> mappingBaseModelList = new List<HotelsAndSuppliersHotelMappingCode>();
//            HotelsAndSuppliersHotelMappingCode mappingBaseModel = new HotelsAndSuppliersHotelMappingCode()
//            {
//                MGHotelCode = "TEST",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "BRA",
//                SupplierHotelCode = "TESTMAP"
//            };

//            mappingBaseModelList.Add(mappingBaseModel);
//            hotelMappingRequest.HotelsAndSuppliersHotelMappingCodeModel.AddRange(mappingBaseModelList);

//            List<Hotel> hotelList = new List<Hotel>
//            {
//                new Hotel()
//                {
//                    ChannelManagerId = 1,
//                    Name = "TestHotel",
//                    Code = "TEST",
//                    Id = 3,
//                    IsActive = true
//                }
//            };

//            List<Supplier> supplierlist = new List<Supplier>()
//            {
//                new Supplier()
//                {
//                    Code = "TEST",
//                    IsDeleted = false,
//                    Id = 1
//                }
//            };

//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {
//                Id = 1,
//                IsActive = true,
//                IsDeleted = false,
//                MGHotelId = 3,
//                SupplierCityCode = "MUM",
//                SupplierCountryCode = "IND",
//                SupplierHotelCode = "Test",
//                SupplierId = 1
//            };

//            List<Core.Model.Mappings.Hotel> hotelMappList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };

//            Mock<IMasterData<Hotel>> hotelMasterDatamock = new Mock<IMasterData<Hotel>>();
//            hotelMasterDatamock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Hotel>>() { Result = hotelList, IsError = false }));

//            Mock<IMasterData<Supplier>> supplierMasterDataMock = new Mock<IMasterData<Supplier>>();
//            supplierMasterDataMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Supplier>>() { Result = supplierlist, IsError = false }));

//            Mock<IMasterData<Core.Model.Mappings.Hotel>> hotelMappingMock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            hotelMappingMock.Setup(x => x.InsertEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetInsertResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.UpdateEntity(It.IsAny<Core.Model.Mappings.Hotel>())).Returns(Task.FromResult(GetUpdateFailResponseFromRepository()));
//            hotelMappingMock.Setup(x => x.GetList()).Returns(Task.FromResult(new BaseResult<List<Core.Model.Mappings.Hotel>>() { IsError = false, Result = hotelMappList }));

//            //var controller = new MappingController(hotelMasterDatamock.Object, hotelMappingMock.Object, supplierMasterDataMock.Object, roomTypeMasterData.Object, roomTypeMappingData.Object, promotionMasterData.Object, iConfiguration.Object);
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMock.Object, hotelMasterDatamock.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.MapHotels(hotelMappingRequest).Result;

//            Assert.IsTrue(result is BadRequestObjectResult);
//            Assert.AreEqual(((BadRequestObjectResult)result).StatusCode, 400);
//        }

//        private BaseResult<long> GetInsertResponseFromRepository()
//        {
//            return new BaseResult<long>()
//            {
//                IsError = false,
//                Result = 1
//            };
//        }

//        private BaseResult<bool> GetUpdateResponseFromRepository()
//        {
//            return new BaseResult<bool>()
//            {
//                IsError = false,
//                Result = true
//            };
//        }

//        private BaseResult<long> GetInsertFailResponseFromRepository()
//        {
//            return new BaseResult<long>()
//            {
//                IsError = true,
//                Result = -1
//            };
//        }

//        private BaseResult<bool> GetUpdateFailResponseFromRepository()
//        {
//            return new BaseResult<bool>()
//            {
//                IsError = true,
//                Result = false
//            };
//        }

//        [Test]
//        public void TestMappingControllerGetHotelMappingsExecptionServerError()
//        {
//            hotelMappingMasterData.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetHotelCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetMappedHotels().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetHotelMappingsExecptionNoContent()
//        {
//            hotelMappingMasterData.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetHotelCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetMappedHotels().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetHotelMappingsFailed()
//        {
//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {

//                Id = 1,
//                MGHotelId=19,
//                SupplierId=1,
//                SupplierHotelCode="HT101",
//                SupplierCityCode="PUN",
//                SupplierCountryCode="IND",
//                IsActive=true,
//                IsDeleted=false
            

//            };
//            List<Core.Model.Mappings.Hotel> hotelList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };
//            Mock<IMasterData<Core.Model.Mappings.Hotel>> mock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetHotelCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = hotelList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, mock.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMappedHotels().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }
        
//        [Test]
//        public void TestMappingControllerGetHotelMappingsIsSuccess()
//        {
//            Core.Model.Mappings.Hotel hotel = new Core.Model.Mappings.Hotel()
//            {

//                Id = 1,
//                MGHotelId = 19,
//                SupplierId = 1,
//                SupplierHotelCode = "HT101",
//                SupplierCityCode = "PUN",
//                SupplierCountryCode = "IND",
//                IsActive = true,
//                IsDeleted = false


//            };
//            List<Core.Model.Mappings.Hotel> hotelList = new List<Core.Model.Mappings.Hotel>()
//            {
//                hotel
//            };
//            Mock<IMasterData<Core.Model.Mappings.Hotel>> mock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetHotelCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = hotelList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, mock.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMappedHotels().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetHotelMappingsNoContent()
//        {


//            Mock<IMasterData<Core.Model.Mappings.Hotel>> mock = new Mock<IMasterData<Core.Model.Mappings.Hotel>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetHotelCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, mock.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMappedHotels().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }
//        #endregion

//        #region MapPromotion Test Cases
//        [Test]
//        public void TestMappingControllerGetPromotionCodeMappingsExecptionServerError()
//        {
//            promotionCodeMappingData.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetPromotionCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetPromotionCodeMappings().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetPromotionCodeMappingsExecptionNoContent()
//        {
//            promotionCodeMappingData.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetPromotionCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetPromotionCodeMappings().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetPromotionCodelMappingsFailed()
//        {
//            Core.Model.Mappings.Promotions promotions = new Core.Model.Mappings.Promotions()
//            {
//                SupplierId = 1,
//                SupplierPromotionCode = "MG",
//                SupplierHotelCode = "HT109",
//                IsActive = true,
//                IsDeleted = false,
//                PromotionId = 10,
//            };
//            List<Core.Model.Mappings.Promotions> promotionList = new List<Core.Model.Mappings.Promotions>()
//            {
//                promotions
//            };
//            Mock<IMasterData<Core.Model.Mappings.Promotions>> mock = new Mock<IMasterData<Core.Model.Mappings.Promotions>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetPromotionCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = promotionList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, mock.Object,roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMappedHotels().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }
//        [Test]
//        public void TestMappingControllerGetPromotionCodeMappingsIsSuccess()
//        {
//            Core.Model.Mappings.Promotions promotions = new Core.Model.Mappings.Promotions()
//            {
//                SupplierId = 1,
//                SupplierPromotionCode = "MG",
//                SupplierHotelCode = "HT109",
//                IsActive = true,
//                IsDeleted = false,
//                PromotionId = 10,
//            };
//            List<Core.Model.Mappings.Promotions> promotionList = new List<Core.Model.Mappings.Promotions>()
//            {
//                promotions
//            };
//            Mock<IMasterData<Core.Model.Mappings.Promotions>> mock = new Mock<IMasterData<Core.Model.Mappings.Promotions>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetPromotionCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = promotionList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, mock.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetPromotionCodeMappings().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetPromotionCodeMappingsNoContent()
//        {


//            Mock<IMasterData<Core.Model.Mappings.Promotions>> mock = new Mock<IMasterData<Core.Model.Mappings.Promotions>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetPromotionCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, mock.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetPromotionCodeMappings().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }

//        #endregion

//        #region MapRoom Test Cases

//        [Test]
//        public void TestMappingControllerGetRoomTypeCodeMappingsExecptionServerError()
//        {
//            roomTypeCodeMappingData.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetRoomTypeCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetRoomTypeCodeMappings().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetRoomTypeCodeMappingsExecptionNoContent()
//        {
//            roomTypeCodeMappingData.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetRoomTypeCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetRoomTypeCodeMappings().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetRoomTypeCodelMappingsFailed()
//        {
//            Core.Model.Mappings.RoomTypes roomTypes = new Core.Model.Mappings.RoomTypes()
//            {
                 
//                MGRoomId=1,
//                MGHotelId=10,
//                SupplierId = 1,
//                SupplierRoomCode = "MG",
//                SupplierHotelCode = "HT109",
//                IsActive = true,
//                IsDeleted = false,
                
//            };
//            List<Core.Model.Mappings.RoomTypes> roomTypeList = new List<Core.Model.Mappings.RoomTypes>()
//            {
//                roomTypes
//            };
//            Mock<IMasterData<Core.Model.Mappings.RoomTypes>> mock = new Mock<IMasterData<Core.Model.Mappings.RoomTypes>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetRoomTypeCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = roomTypeList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, mock.Object, mealTypeMappingDataMock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetRoomTypeCodeMappings().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }
//        [Test]
//        public void TestMappingControllerGetRoomTypeCodeMappingsIsSuccess()
//        {
//            Core.Model.Mappings.RoomTypes roomTypes = new Core.Model.Mappings.RoomTypes()
//            {

//                MGRoomId = 1,
//                MGHotelId = 10,
//                SupplierId = 1,
//                SupplierRoomCode = "MG",
//                SupplierHotelCode = "HT109",
//                IsActive = true,
//                IsDeleted = false,

//            };
//            List<Core.Model.Mappings.RoomTypes> roomTypeList = new List<Core.Model.Mappings.RoomTypes>()
//            {
//                roomTypes
//            };
//            Mock<IMasterData<Core.Model.Mappings.RoomTypes>> mock = new Mock<IMasterData<Core.Model.Mappings.RoomTypes>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetRoomTypeCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = roomTypeList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object,roomTypeMasterData.Object, mock.Object,mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetRoomTypeCodeMappings().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetRoomTypeCodeMappingsNoContent()
//        {


//            Mock<IMasterData<Core.Model.Mappings.RoomTypes>> mock = new Mock<IMasterData<Core.Model.Mappings.RoomTypes>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetRoomTypeCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object,roomTypeMasterData.Object, mock.Object,mealTypeMappingDataMock.Object,mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetRoomTypeCodeMappings().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }
//        #endregion

//        #region MapMeals Test Cases

//        [Test]
//        public void TestMappingControllerGetMealMappingsExecptionServerError()
//        {
//            mealTypeMappingDataMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetMealTypeCodeMappings, null))
//                .Throws(new Exception());

//            var result = mappingController.GetMealMappings().Result;
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);
//        }
//        [Test]
//        public void TestMappingControllerGetMealMappingsExecptionNoContent()
//        {
//            mealTypeMappingDataMock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetMealTypeCodeMappings, null))
//                .Throws(new Exception(message: Constants.NoContentExceptionMessage));

//            var result = mappingController.GetMealMappings().Result;
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);
//        }
//        [Test]
//        public void TestMappingControllerGetMealMappingsIsSuccess()
//        {
//            Core.Model.Mappings.MealTypes meal = new Core.Model.Mappings.MealTypes()
//            {
//                MGMealTypeId = 1,
//                SupplierId = 1,
//                SupplierMealTypeCode = "",
//                IsActive = true

//            };
//            List<Core.Model.Mappings.MealTypes> mealList = new List<Core.Model.Mappings.MealTypes>()
//            {
//                meal
//            };
//            Mock<IMasterData<Core.Model.Mappings.MealTypes>> mock = new Mock<IMasterData<Core.Model.Mappings.MealTypes>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetMealTypeCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = mealList, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMealMappings().Result;
//            Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((OkObjectResult)result).StatusCode, 200);

//        }
//        [Test]
//        public void TestMappingControllerGetMealMappingsFailed()
//        {
//            Core.Model.Mappings.MealTypes meal = new Core.Model.Mappings.MealTypes()
//            {
//                MGMealTypeId = 1,
//                SupplierId = 1,
//                SupplierMealTypeCode = "",
//                IsActive = true

//            };
//            List<Core.Model.Mappings.MealTypes> mealList = new List<Core.Model.Mappings.MealTypes>()
//            {
//                meal
//            };
//            Mock<IMasterData<Core.Model.Mappings.MealTypes>> mock = new Mock<IMasterData<Core.Model.Mappings.MealTypes>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetMealTypeCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = mealList, IsError = true }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object, promotionCodeMappingData.Object, roomTypeMasterData.Object, roomTypeCodeMappingData.Object, mock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMealMappings().Result;
//            //Assert.IsTrue(result is OkObjectResult);
//            Assert.AreEqual(((StatusCodeResult)result).StatusCode, 500);

//        }

//        [Test]
//        public void TestMappingControllerGetMealMappingsNoContent()
//        {


//            Mock<IMasterData<Core.Model.Mappings.MealTypes>> mock = new Mock<IMasterData<Core.Model.Mappings.MealTypes>>();
//            mock.Setup(x => x.ExecuteStoredProcedureDynamicModel(Constants.GetMealTypeCodeMappings, null)).Returns(Task.FromResult(new BaseResult<IEnumerable<dynamic>>() { Result = null, IsError = false }));
//            var controller = new MappingController(supplierMasterDataMock.Object, nationalityMasterDataMock.Object, nationalityMappingMock.Object, countryMappingMock.Object, countryMasterDataMock.Object, cityMappingMock.Object, cityMasterDataMock.Object, hotelMappingMasterData.Object, hotelMasterData.Object,promotionCodeMappingData.Object,roomTypeMasterData.Object,roomTypeCodeMappingData.Object, mock.Object, mealMasterDataMock.Object, iConfigurationMock.Object);
//            var result = controller.GetMealMappings().Result;
//            Assert.IsTrue(result is NoContentResult);
//            Assert.AreEqual(((NoContentResult)result).StatusCode, 204);

//        }

//        #endregion


//    }
//}
