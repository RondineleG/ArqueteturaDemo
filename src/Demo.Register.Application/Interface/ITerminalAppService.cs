using Demo.Register.Domain.Enums;
using Demo.Register.Domain.Models;
using Demo.Register.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Register.Application.Interface
{
    public interface ITerminalAppService : IAppServiceBase<Terminal>
    {
        Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query);

        Task<IEnumerable<Terminal>> GetAllDeleted();

        Task<IEnumerable<Terminal>> Search(string name, EStatus? status);

        Task<List<Terminal>> GetAllTerminals();
    }
}
