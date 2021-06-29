using Proton.Core.Repository;
using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Proton.Register.Domain.Interfaces.Repositories
{
    public interface ITerminalRepository : IRepositoryCrud<Terminal>
    {

        Task<IEnumerable<Terminal>> Search(string name, EStatus? status);

        Task<IEnumerable<Terminal>> GetAllDeleted();

        IEnumerable<Terminal> FindByName(string name);

        IQueryable<Terminal> List(Expression<Func<Terminal, bool>> expression);

        Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query);

        Task<List<Terminal>> GetAllTerminals();
    }
}




