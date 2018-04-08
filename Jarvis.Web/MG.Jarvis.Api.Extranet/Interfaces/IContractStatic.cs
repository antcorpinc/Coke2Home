
namespace MG.Jarvis.Api.Extranet.Interfaces
{
    using System.Threading.Tasks;

    using MG.Jarvis.Api.Extranet.ViewModel;
    using MG.Jarvis.Core.Model;
    using MG.Jarvis.Core.Model.Contracts;

    /// <summary>
    /// The ContractStatic interface.
    /// </summary>
    public interface IContractStatic
    {
        /// <summary>
        /// The create contract.
        /// </summary>
        /// <param name="contractStaticViewModel">
        ///     The contract hotel properties.
        /// </param>
        /// <param name="loggedUser">logged in user</param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<BaseResult<ContractViewModel>> CreateContract(ContractStaticViewModel contractStaticViewModel, string loggedUser);

        /// <summary>
        /// The get contract by id.
        /// </summary>
        /// <param name="contractId">
        /// The contract id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<BaseResult<Contract>> GetContractById(int contractId);
    }
}
