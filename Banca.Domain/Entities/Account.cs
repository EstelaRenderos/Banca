
using CleanArchitecture.Domain.Common;
namespace Banca.Domain.Entities
{
    public sealed class Account : BaseDomainModel
    {
        public int UserId { get; set; }
        public string AccountNumber { get; set; } 
        public decimal AccountBalance { get; set; } = 0.00m;  
        public int AccountTypeId { get; set; }  
    }
}
