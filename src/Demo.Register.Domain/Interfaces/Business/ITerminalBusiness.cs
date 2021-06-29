using Proton.Core.Business;
using Proton.Register.Domain.Business.Communication;
using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proton.Register.Domain
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
