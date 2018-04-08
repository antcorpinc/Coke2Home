using AutoMapper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Contracts;

namespace MG.Jarvis.Api.Extranet.AutoMapperHelper.Resolvers
{
    public class TemplateHotelFieldIdResolver : IValueResolver<HotelFieldViewModel, TemplateHotelField, int>
    {
        public int Resolve(HotelFieldViewModel source, TemplateHotelField destination, int destMember, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
