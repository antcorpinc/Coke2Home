using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.Helper.Mapper;
using MG.Jarvis.Api.Extranet.Interfaces;
using MG.Jarvis.Api.Extranet.Mapper.Response;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Cache;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MG.Jarvis.Api.Extranet.Controllers
{
    public class MiscellaneousController : BaseController
    {
        IMiscellaneous iMiscellaneous;
        public MiscellaneousController(IMiscellaneous iMiscellaneous)
        {
            this.iMiscellaneous = iMiscellaneous;
        }

        /// <summary>
        /// Return list of Languages
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> GetLanguages()
        {
            BaseResult<List<LanguageViewModel>> languageResult = new BaseResult<List<LanguageViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<LanguageViewModel>>(Constants.CacheKeys.LanguageList)
            };
            if (languageResult.Result == null || languageResult.Result.Count == 0)
            {
                BaseResult<List<Langauges>> languages = await iMiscellaneous.GetLanguages().ConfigureAwait(false);

                if (languages.IsError && languages.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (languages.Result == null || languages.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var languageVm = MiscellaneousResponseMapper.MapLanguages(languages); //mapping to LanguageViewaModel
                    RedisCacheHelper.Instance.Set<List<LanguageViewModel>>(Constants.CacheKeys.LanguageList, languageVm.Result);
                    return Ok(languageVm);
                }
            }



            return Ok(languageResult);//200
        }

        /// <summary>
        /// Return the designations 
        /// </summary>
        /// <returns>designations</returns>
        [HttpPost]
        public async Task<IActionResult> GetDesignation([FromBody]string userType)
        {
            BaseResult<List<DesignationViewModel>> designationResult = new BaseResult<List<DesignationViewModel>>();

            BaseResult<List<Designation>> designations = await iMiscellaneous.GetDesignationByUserType(userType).ConfigureAwait(false);
            if (designations.IsError && designations.ExceptionMessage != null)
            {
                return new StatusCodeResult(500);
            }
            else if (designations.Result == null || !designations.Result.Any())
            {
                return new NoContentResult();
            }
            designationResult = MiscellaneousResponseMapper.MapDesignations(designations);

            return Ok(designationResult);
        }

        /// <summary>
        /// Return the list of ChannelManager
        /// </summary>
        /// <returns>ChannelManagerList</returns>
        public async Task<IActionResult> GetChannelManager()
        {
            BaseResult<List<ChannelManagerViewModel>> channelManagerListResult = new BaseResult<List<ChannelManagerViewModel>>
            {
                Result = RedisCacheHelper.Instance.Get<List<ChannelManagerViewModel>>(Constants.CacheKeys.ChannelManagerList)
            };

            if (channelManagerListResult.Result == null || channelManagerListResult.Result.Count == 0)
            {
                BaseResult<List<ChannelManagers>> channelManagerList = await iMiscellaneous.GetChannelManager().ConfigureAwait(false);

                if (channelManagerList.IsError && channelManagerList.ExceptionMessage != null)
                {
                    return new StatusCodeResult(500);
                }
                else if (channelManagerList.Result == null || channelManagerList.Result.Count == 0)
                {
                    return NoContent(); //204
                }
                else
                {
                    var channelManagersVm = MiscellaneousResponseMapper.MapChannelManager(channelManagerList); // mapping to Supplier viewmodel
                    RedisCacheHelper.Instance.Set<List<ChannelManagerViewModel>>(Constants.CacheKeys.ChannelManagerList, channelManagersVm.Result);
                    return Ok(channelManagersVm);//200
                }
            }
            return Ok(channelManagerListResult); //200
        }
    }
}