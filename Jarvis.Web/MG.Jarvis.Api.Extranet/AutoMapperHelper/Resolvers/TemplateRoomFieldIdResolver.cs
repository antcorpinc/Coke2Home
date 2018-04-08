using AutoMapper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model.Contracts;

namespace MG.Jarvis.Api.Extranet.AutoMapperHelper.Resolvers
{
    public class TemplateRoomFieldIdResolver : IValueResolver<RoomFieldViewModel, TemplateRoomField, int>
    {
        public int Resolve(RoomFieldViewModel source, TemplateRoomField destination, int destMember, ResolutionContext context)
        {
            return source.Id;
        }
    }
}
