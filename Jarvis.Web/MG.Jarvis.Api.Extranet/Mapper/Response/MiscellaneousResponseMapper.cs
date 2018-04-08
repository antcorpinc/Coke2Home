using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public class MiscellaneousResponseMapper
    {
        /// <summary>
        /// Maps list of languages to LanguageViewModel
        /// </summary>
        /// <param name="languageList"></param>
        /// <returns></returns>
        public static BaseResult<List<LanguageViewModel>> MapLanguages(BaseResult<List<Langauges>> languageList)
        {
            BaseResult<List<LanguageViewModel>> responseModelList = new BaseResult<List<LanguageViewModel>>();
            List<LanguageViewModel> modelList = new List<LanguageViewModel>();
            foreach (var item in languageList.Result)
            {
                if (item.IsActive)
                {
                    LanguageViewModel languageModel = new LanguageViewModel
                    {
                        Id = item.Id,
                        Code = item.Code,
                        Name = item.Name
                    };

                    modelList.Add(languageModel);
                }
            }
            responseModelList.Result = modelList;

            return responseModelList;
        }
        

        /// <summary>
        /// Map Designations
        /// </summary>
        /// <param name="designationList"></param>
        /// <returns></returns>
        public static BaseResult<List<DesignationViewModel>> MapDesignations(BaseResult<List<Designation>> designationList)
        {
            BaseResult<List<DesignationViewModel>> designationListResult = new BaseResult<List<DesignationViewModel>>();
            List<DesignationViewModel> modelList = new List<DesignationViewModel>();
            DesignationViewModel model = new DesignationViewModel();
            foreach (var item in designationList.Result)
            {
                //Map
                model = AutoMapper.Mapper.Map<Designation, DesignationViewModel>(item);
                modelList.Add(model);
            }
            designationListResult.Result = modelList;
            return designationListResult;
        }

        /// <summary>
        /// Return the mapped ChannelManager viewmodel
        /// </summary>
        /// <param name="ChannelManagersListDetail"></param>
        /// <returns></returns>
        public static BaseResult<List<ChannelManagerViewModel>> MapChannelManager(BaseResult<List<ChannelManagers>> ChannelManagersListDetail)
        {
            BaseResult<List<ChannelManagerViewModel>> channelManagerViewModelList = new BaseResult<List<ChannelManagerViewModel>>();
            List<ChannelManagerViewModel> modelList = new List<ChannelManagerViewModel>();
            foreach (var item in ChannelManagersListDetail.Result)
            {
                ChannelManagerViewModel model = new ChannelManagerViewModel
                {
                    Id = item.Id,
                    ChannelManager = item.ChannelManager
                };
                modelList.Add(model);
            }
            channelManagerViewModelList.Result = modelList;
            return channelManagerViewModelList;
        }

    }
}
