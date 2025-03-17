
namespace Banca.Domain.Common
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static class Errors
        {
            public static class Account
            {
                public static Error NotFound => new Error("account.not_found", "La cuenta no existe");
                public static Error InsufficientFunds => new Error("account.insufficient_funds", "No se cuenta con fondos suficientes");
            }

        }
    }
}
