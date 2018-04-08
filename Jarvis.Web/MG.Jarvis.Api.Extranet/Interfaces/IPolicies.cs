using MG.Jarvis.Api.Extranet.Helper;
using MG.Jarvis.Api.Extranet.ViewModel;
using MG.Jarvis.Core.Model;
using MG.Jarvis.Core.Model.Policies;
using MG.Jarvis.Core.Model.Room;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MG.Jarvis.Api.Extranet.Interfaces
{
    public interface IPolicies
    {
        Task<BaseResult<List<ChildrenAndExtraBedPolicies>>> GetChildrenAndExtraBedPolicyListingByHotelId(int hotelId);

        Task<BaseResult<List<MaxChildAndExtraBedPerRoom>>> GetMaxChildAndExtraBedPerRoom(int hotelId);
        Task<BaseResult<List<Room>>> GetRoomsById(List<MaxChildAndExtraBedPerRoomViewModel> maxChildAndExtraBedPerRoomViewModelList);
        Task<BaseResult<ChildrenAndExtraBedPolicies>> SaveAndUpdateChildAndExtraBedPolicy(ChildrenAndExtraBedPolicies childrenAndExtraBedPoliciesRequest, ObjectState? objectState);
        Task<BaseResult<bool>> UpdateRoomList(List<Room> roomList);
        Task<BaseResult<List<CancellationPolicyType>>> GetCancellationPolicyType();
        Task<BaseResult<List<CancellationCharges>>> GetCancellationCharges();
        BaseResult<List<CancellationPolicyViewModel>> GetCancellationPolicies(int hotelId);
        Task<BaseResult<CancellationPolicy>> GetCancellationPolicyById(int? policyId);
        Task<BaseResult<List<CancellationPolicyClauses>>> GetCancellationPolicyClausesById(int? policyId);
        Task<BaseResult<CancellationPolicy>> SaveAndUpdateCancellationPolicy(CancellationPolicyViewModel cancellationPolicyViewModel,string loggedUserName);
        Task<BaseResult<CancellationPolicyClauses>> DeleteCancellationPolicyClauses(int? clauseId);


    }
}
