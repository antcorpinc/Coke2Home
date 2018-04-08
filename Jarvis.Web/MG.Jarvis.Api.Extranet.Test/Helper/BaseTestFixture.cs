namespace MG.Jarvis.Api.Extranet.Test.Helper
{
    public class BaseTestFixture
    { 
        public BaseTestFixture()
        {
            AutoMapper.Mapper.Reset();
            AutoMapperHelper.AutoMapper.Initialize();
        }            
    }
}
