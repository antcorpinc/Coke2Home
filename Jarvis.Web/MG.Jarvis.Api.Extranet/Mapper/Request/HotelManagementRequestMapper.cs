using Dapper;
using MG.Jarvis.Api.Extranet.Helper;

namespace MG.Jarvis.Api.Extranet.Mapper.Request
{
    public static class HotelManagementRequestMapper
    {
        public static DynamicParameters CreateGetHotelsByCityRequest(string cityCode, int languageId=1)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(Constants.StoredProcedureParameters.CityCode, cityCode);
            parameters.Add(Constants.StoredProcedureParameters.LanguageId, languageId);
            return parameters;
        }
    }
}
