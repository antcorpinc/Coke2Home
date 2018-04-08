using System;
using static MG.Jarvis.Api.Extranet.Helper.Enums;
using cmEnums = MG.Jarvis.Core.Model.Helper.Enums;

[assembly: CLSCompliant(false)]
namespace MG.Jarvis.Api.Extranet.Helper
{
    public static class Common
    {

        public static DateTime JakartaOffset(this DateTime date)
        {
            //TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Constants.JakartaTimeZone);
            ////Get date and time in US Mountain Standard Time
            //return TimeZoneInfo.ConvertTime(date, timeZoneInfo);
            return date.ToUniversalTime().AddHours(7);
        }

        public static DateTime JakartaOffset(this string date)
        {

            DateTime dateTime = DateTime.Now;
            DateTime.TryParse(date, out dateTime);
            //TimeZoneInfo timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(Constants.JakartaTimeZone);
            ////Get date and time in US Mountain Standard Time
            //return TimeZoneInfo.ConvertTime(dateTime, timeZoneInfo);
            return dateTime.ToUniversalTime().AddHours(7);
        }
        public static EntityState GetEntityStatus(int? id)
        {
            return id == null ? EntityState.New : EntityState.Inserted;
        }
        public static cmEnums.ContractType  GetContractType(ContractType type)
        {
            return type == ContractType.NonMg ? cmEnums.ContractType.NonMG : cmEnums.ContractType.MG;
        }
        public static cmEnums.TemplateType? GetTemplateType(ContractType type)
        {
            if(type == ContractType.MgStatic)
            {
                return cmEnums.TemplateType.Static;
            }
            else if (type == ContractType.MgDynamic)
            {
                return cmEnums.TemplateType.Dynamic;
            }
            else
            {
                return null;
            }
        }
    }


}
