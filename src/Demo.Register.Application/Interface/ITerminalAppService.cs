using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proton.Register.Application.Interface
{
    public interface ITerminalAppService : IAppServiceBase<Terminal>
    {
        Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query);

        Task<IEnumerable<Terminal>> GetAllDeleted();

        Task<IEnumerable<Terminal>> Search(string name, EStatus? status);

        Task<List<Terminal>> GetAllTerminals();
    }
}
