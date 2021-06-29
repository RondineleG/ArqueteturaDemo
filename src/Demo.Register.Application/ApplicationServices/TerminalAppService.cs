using Proton.Register.Application.Base;
using Proton.Register.Application.Interface;
using Proton.Register.Domain;
using Proton.Register.Domain.Enums;
using Proton.Register.Domain.Models;
using Proton.Register.Domain.Notifications;
using Proton.Register.Domain.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proton.Register.Application.ApplicationServices
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
