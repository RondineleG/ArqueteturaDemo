using Browl.Domain.Enums;
using Browl.Domain.Models;
using Browl.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Browl.Application.Interface
{
    public interface ITerminalAppService : IAppServiceBase<Terminal>
    {
        Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query);

        Task<IEnumerable<Terminal>> GetAllDeleted();

        Task<IEnumerable<Terminal>> Search(string name, EStatus? status);

        Task<List<Terminal>> GetAllTerminals();
    }
}
