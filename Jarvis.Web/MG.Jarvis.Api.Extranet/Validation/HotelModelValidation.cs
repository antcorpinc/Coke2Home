using MG.Jarvis.Api.Extranet.Models.ViewModels;
using MG.Jarvis.Core.Model;
using System;

namespace MG.Jarvis.Api.Extranet.Validation
{
    public static class HotelModelValidation
    {
        public static BaseResult<string> ValidateModelHotelCreate(HotelDetailsViewModel model)
        {
            BaseResult<string> validationResult = new BaseResult<string>();

            if (String.IsNullOrEmpty(model.HotelName))
            {
                validationResult.Message = model.HotelName;
                validationResult.IsError = true;
                return validationResult;
            }
            else if (model.HotelTypeId <= 0)
            {
                validationResult.Message = Convert.ToString(model.HotelTypeId);
                validationResult.IsError = true;
                return validationResult;
            }
            else if (model.CountryId <= 0)
            {
                validationResult.Message = Convert.ToString(model.CountryId);
                validationResult.IsError = true;
                return validationResult;
            }
            else if (model.CityId <= 0)
            {
                validationResult.Message = Convert.ToString(model.CityId);
                validationResult.IsError = true;
                return validationResult;
            }
            else if (model.Latitude.GetType() != typeof(decimal))
            {
                validationResult.Message = Convert.ToString(model.Latitude);
                validationResult.IsError = true;
                return validationResult;
            }
            else if (model.Latitude.GetType() != typeof(decimal))
            {
                validationResult.Message = Convert.ToString(model.Longitude);
                validationResult.IsError = true;
                return validationResult;
            }
            else if (String.IsNullOrEmpty(model.ShortDescription))
            {
                validationResult.Message = model.ShortDescription;
                validationResult.IsError = true;
                return validationResult;
            }

            
            validationResult.IsError = false;
            return validationResult;
        }
    }
}
