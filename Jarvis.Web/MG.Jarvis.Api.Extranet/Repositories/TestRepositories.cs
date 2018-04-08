using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Core.DAL.Interfaces;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Hotel;
using MG.Jarvis.Core.Model.Job;
using MG.Jarvis.Core.Model.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MG.Jarvis.Api.Extranet.Repositories
{
    public class TestRepositories : ITest
    {
        #region Private Variable
        private IConnection<Hotel> iConnectionLibrary;
        private IConnection<Test> iTestLibrary;
        private IConnection<Producers> iProducerLibrary;
        #endregion Private Variable

        public TestRepositories(IConnection<Hotel> iConnectionLibrary, IConnection<Test> iTestLibrary, IConnection<Producers> iProducerLibrary)
        {
            this.iConnectionLibrary = iConnectionLibrary;
            this.iTestLibrary = iTestLibrary;
            this.iProducerLibrary = iProducerLibrary;
        }


        public async Task<BaseResult<IEnumerable<Hotel>>> ExecuteStoredProcedureWithMultipleDataSet()
        {
            BaseResult<IEnumerable<Hotel>> result = new BaseResult<IEnumerable<Hotel>>();
            Dapper.DynamicParameters paramCollection = new Dapper.DynamicParameters();
            paramCollection.Add("@HotelId", 26);
            var result1 = await iConnectionLibrary.ExecuteStoredProcedureWithMultipleDataSet("usp_GetHotelAndContacts", paramCollection).ConfigureAwait(false);
            IEnumerable<Hotel> hotelResult = result1.Result.Read<Hotel>();
            IEnumerable<Contacts> contactResult = result1.Result.Read<Contacts>();
            return result;
        }


        public async Task<BaseResult<List<Hotel>>> GetHotelAndRooms()
        {
            Func<Hotel, bool> func = x => x.IsActive == true;
            return await iConnectionLibrary.GetListByPredicate(func).ConfigureAwait(false);
        }

        public async Task<BaseResult<List<Hotel>>> GetHotelAndRoomsByDapper()
        {
            return await iConnectionLibrary.GetList().ConfigureAwait(false);
        }

        public Task<BaseResult<dynamic>> GetHotelAndRoomsByDapperCustomModel()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<long>> InsertHotelAndRoomsByDapper()
        {
            iConnectionLibrary.SetConnectionStringKey("JarvisContextConnection");
            Hotel hotel = new Hotel
            {
               CreatedBy ="SA",
                Name = "Test Updated"
            };
            BaseResult<long> testResult = new BaseResult<long>();
            testResult = await iConnectionLibrary.InsertEntity(hotel);
            return testResult;
        }

        public Task<BaseResult<long>> InsertHotelAndRoomsByEntity()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<BaseResult<long>> InsertTestGuid(Test t)
        {
            BaseResult<long> testResult = new BaseResult<long>();
            // return await iTestLibrary.InsertEntity(t).ConfigureAwait(false);
            List<Producers> producerList = new List<Producers>
            {
                new Producers{ Id= Guid.NewGuid(), MachineName="172.27.127.64"},
                 new Producers{ Id= Guid.NewGuid(), MachineName="172.27.127.164"},
             };
            testResult = await iProducerLibrary.InsertEntityList(producerList).ConfigureAwait(false);
            return testResult;
        }



        public async Task<BaseResult<Hotel>> UpdateHotelAndRooms()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResult<bool>> UpdateHotelAndRoomsByDapper()
        {
        //    Hotel hotel = new Hotel
        //    {
        //        Id = 5,
        //        Name = "Test Updated"
        //    };
        //    BaseResult<bool> testResult = new BaseResult<bool>();
        //    testResult = await iConnectionLibrary.UpdateEntityByDapper(hotel);
        //    return testResult;
        //}

        //public BaseResult<bool> InsertHotelByContact()
        //{
        //    Hotel hotel = new Hotel
        //    {
        //        CityId = 101,
        //        Code = "Test Code for Transaction",
        //        // hotel.ContactList = new Models.ContactList();
        //        Contact = new List<Contacts>()
        //    };
        //    hotel.Contact.Add(new Contacts
        //    {
        //        ContactNumber = "2141234",
        //        //  PhoneNumber = "113444",
        //        CreatedBy = "RN", //Designation = new Designation { Title="Test Title", CreatedBy="sa",UpdatedBy="sa", CreatedDate=DateTime.Now            }
        //        DesignationId = 1,
        //        ContactPerson = "Test Contact1",
        //        CreatedDate = DateTime.Now.AddHours(-2),
        //        EmailAddress = "test@124.com",
        //        IsPrimary = true,
        //        UpdatedBy = "RN"
        //    });

        //    hotel.Contact.Add(new Contacts
        //    {
        //        ContactNumber = "2141234",
        //        //PhoneNumber = "113444",
        //        CreatedBy = "RN", //Designation = new Designation { Title="Test Title", CreatedBy="sa",UpdatedBy="sa", CreatedDate=DateTime.Now            }
        //        DesignationId = 1,
        //        ContactPerson = "Test Contact2",
        //        CreatedDate = DateTime.Now.AddHours(-2),
        //        EmailAddress = "test@1243.com",
        //        IsPrimary = true,
        //        UpdatedBy = "RN"
        //    });


        //    hotel.Longitude = 12.233425M;
        //    hotel.Latitude = 12.2452452M;
        //    hotel.HotelTypeId = 1;
        //    hotel.ShortDescription = "Test short Description";
        //    hotel.StarRatingID = 2;
        //    hotel.CreatedDate = DateTime.Now.AddHours(-2);
        //    //hotel.UpdatedDate = DateTime.Now;
        //    hotel.UpdatedBy = "sa";
        //    hotel.Name = "Test Hotel Name for Dapper Simple Save";
        //    hotel.CreatedBy = "sa";
        //   // hotel.CheckInFrom = DateTime.Now;
        //   // hotel.CheckInTo = DateTime.Now;
        //   // hotel.CheckOutFrom = DateTime.Now;
        //  //  hotel.CheckOutTo = DateTime.Now;
            BaseResult<bool> testResult = new BaseResult<bool>();
            //testResult =  iConnectionLibrary.CreateEntity(hotel);
            return testResult;
        }
    }
}
