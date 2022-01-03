using Browl.API.ViewModes;
using System.Collections.Generic;

namespace Browl.API.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Application Error Message",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

    }
}