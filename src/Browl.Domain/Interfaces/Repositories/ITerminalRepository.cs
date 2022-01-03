using Browl.Core.Repository;
using Browl.Domain.Enums;
using Browl.Domain.Models;
using Browl.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Browl.Domain.Interfaces.Repositories
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




