using CleanArchitecture.Domain.Common;

namespace Banca.Domain.Entities
{
    public class User : BaseDomainModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; } = true;  

        public byte[] EncryptedPassword { get; set; }  // Password encrypted with AES
        public string Hmac { get; set; }  // HMAC of the password
        public ICollection<Account> Accounts { get; set; }
    }

}
