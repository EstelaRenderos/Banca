
using CleanArchitecture.Domain.Common;

namespace Banca.Domain.Entities
{
    public class Transfer : BaseDomainModel
    {
        public int UserId { get; set; }  
        public int SourceAccountId { get; set; }  
        public int DestinationAccountId { get; set; } 
        public int TransferTypeId { get; set; } 
        public decimal Amount { get; set; }
        public DateTime DateApplication { get; set; } = DateTime.Now;
    }
}
