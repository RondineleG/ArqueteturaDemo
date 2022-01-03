using Browl.Domain.Models;

namespace Browl.Domain.Business.Communication
{
    public class TerminalResponse : BaseResponse<Terminal>
    {
        public TerminalResponse(Terminal terminal) : base(terminal) { }

        public TerminalResponse(string message) : base(message) { }
    }
}