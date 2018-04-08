using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.MasterData;
using System.Collections.Generic;

namespace MG.Jarvis.Api.Extranet.Mapper.Response
{
    public static class AllocationsResponseMapper
    {
        /// <summary>
        /// Maps Calendar dates to DateListViewModel
        /// </summary>
        /// <param name="dates"></param>
        /// <returns> List<DateListViewModel> </returns>
        public static List<DateListViewModel> MapDatesToDateListViewModel(List<Calendar> dates)
        {
            List<DateListViewModel> response = new List<DateListViewModel>();
            foreach (var item in dates)
            {
                DateListViewModel date = new DateListViewModel()
                {
                    Date = string.Format(item.EnglishDayNameOfWeek.Substring(0, 3) + " " + item.FullDateAlternatekey.Day + " " + item.EnglishMonthName.Substring(0, 3)),
                    DateKey = item.DateKey,
                    IsWeekend = false                  
                };
                if(item.DayNumberOfWeek==1||item.DayNumberOfWeek==7)
                {
                    date.IsWeekend = true;
                }
                response.Add(date);
            }
            return response;
        }
    }
}
