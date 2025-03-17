using CleanArchitecture.Domain.Common;

namespace Banca.Domain.Entities
{
    public class TransferType : BaseDomainModel
    {
        public string Description { get; set; }
        public string TransferTypeCode { get; set; }
    }
}
