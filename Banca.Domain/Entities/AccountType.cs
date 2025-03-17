
using CleanArchitecture.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Banca.Domain.Entities
{
    public  class AccountType : BaseDomainModel 
    {

        public string Description { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
