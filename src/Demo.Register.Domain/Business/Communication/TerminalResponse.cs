using Proton.Register.Domain.Models;

namespace Proton.Register.Domain.Business.Communication
{
    public class TerminalResponse : BaseResponse<Terminal>
    {
        public TerminalResponse(Terminal terminal) : base(terminal) { }

        public TerminalResponse(string message) : base(message) { }
    }
}