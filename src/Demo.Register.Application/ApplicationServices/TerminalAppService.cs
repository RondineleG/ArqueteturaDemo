using Demo.Register.Application.Base;
using Demo.Register.Application.Interface;
using Demo.Register.Domain;
using Demo.Register.Domain.Enums;
using Demo.Register.Domain.Models;
using Demo.Register.Domain.Notifications;
using Demo.Register.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Register.Application.ApplicationServices
{
    public class TerminalAppService : AppServiceBase<Terminal>, ITerminalAppService
    {
        private readonly ITerminalBusiness _terminalBusiness;

        public TerminalAppService(ITerminalBusiness terminalBusiness, INotifier notifier
                                      ) : base(terminalBusiness, notifier)
        {
            _terminalBusiness = terminalBusiness;
        }

        public async Task<IEnumerable<Terminal>> GetAllDeleted()
        {
            return await _terminalBusiness.GetAllDeleted();

        }

        public async Task<List<Terminal>> GetAllTerminals()
        {
            return await _terminalBusiness.GetAllTerminals();
        }

        public async Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query)
        {
            var queryResult = await _terminalBusiness.ListAsync(query);
            return queryResult;
        }

        public async Task<IEnumerable<Terminal>> Search(string name, EStatus? status)
        {
            return await _terminalBusiness.Search(name, status);
        }
    }
}
