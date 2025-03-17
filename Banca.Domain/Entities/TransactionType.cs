
using CleanArchitecture.Domain.Common;

namespace Banca.Domain.Entities
{
    public class TransactionType : BaseDomainModel 
    {
        public string Description { get; set; }
        public string TransactionTypeCode { get; set; }
    }
}
