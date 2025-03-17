namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastModifiedDate { get; set; } = DateTime.UtcNow;
    }
}
