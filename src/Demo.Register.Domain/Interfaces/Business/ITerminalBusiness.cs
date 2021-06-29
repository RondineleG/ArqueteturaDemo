using Demo.Core.Business;
using Demo.Register.Domain.Business.Communication;
using Demo.Register.Domain.Enums;
using Demo.Register.Domain.Models;
using Demo.Register.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Register.Domain
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
