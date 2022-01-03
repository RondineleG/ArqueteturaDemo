using Browl.Core.Business;
using Browl.Domain.Business.Communication;
using Browl.Domain.Enums;
using Browl.Domain.Models;
using Browl.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Browl.Domain
{
    public interface ITerminalBusiness : IBusinessCrud<Terminal>
    {
        Task<IEnumerable<Terminal>> Search(string name, EStatus? status);

        Task<IEnumerable<Terminal>> GetAllDeleted();

        Task<TerminalResponse> SaveAsync(Terminal product);

        Task<bool> Adicionar(Terminal terminal);


        Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query);

        Task<List<Terminal>> GetAllTerminals();

    }
}
