
using CleanArchitecture.Domain.Common;

namespace Banca.Domain.Entities
{
    public class Transaction : BaseDomainModel
    {
        public int AccountId { get; set; }  
        public int TransactionTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Successful";
        public Account Account { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
