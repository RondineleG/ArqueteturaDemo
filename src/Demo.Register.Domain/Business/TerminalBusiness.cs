using Demo.Core.UnitOfWork;
using Demo.Register.Domain.Base;
using Demo.Register.Domain.Business.Communication;
using Demo.Register.Domain.Enums;
using Demo.Register.Domain.Interfaces.Repositories;
using Demo.Register.Domain.Models;
using Demo.Register.Domain.Notifications;
using Demo.Register.Domain.Queries;
using Demo.Register.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Register.Domain
{
    public class TerminalBusiness : BusinessCrud<Terminal>, ITerminalBusiness
    {

        private readonly ITerminalRepository _terminalRepository;
        private readonly IUnitOfWork _unitOfWork;
        public TerminalBusiness(ITerminalRepository terminalRepository,
                                IUnitOfWork unitOfWork,
                                INotifier notifier) : base(terminalRepository, unitOfWork, notifier)
        {
            _terminalRepository = terminalRepository;
            _unitOfWork = unitOfWork; ;

        }

        public async Task<IEnumerable<Terminal>> Search(string name, EStatus? status)
        {
            return await _terminalRepository.Search(name, status);

        }

        public async Task<IEnumerable<Terminal>> GetAllDeleted()
        {
            return await _terminalRepository.GetAllDeleted();

        }

        public async Task<TerminalResponse> SaveAsync(Terminal terminal)
        {
            try
            {
                var existingCity = await _terminalRepository.GetById(terminal.CityId);
                if (existingCity == null)
                {
                    return new TerminalResponse("Invalid city.");
                }

                await _terminalRepository.Create(terminal);
                await _unitOfWork.CompleteAsync();

                return new TerminalResponse(terminal);
            }
            catch (Exception ex)
            {
                return new TerminalResponse($"An error occurred when saving the terminal: {ex.Message}");
            }
        }

        public async Task<bool> Adicionar(Terminal terminal)
        {
            if (!ExecuteValidation(new TerminalValidation(), terminal))
            {
                return false;
            }

            await _terminalRepository.Create(terminal);
            return true;
        }


        public async Task<QueryResult<Terminal>> ListAsync(TerminalsQuery query)
        {
            var products = await _terminalRepository.ListAsync(query);
            return products;
        }

        public async Task<List<Terminal>> GetAllTerminals()
        {
            return await _terminalRepository.GetAllTerminals();
        }
    }
}


