namespace MedicalRecordMs.DataAccessLayer.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }
        protected BaseEntity(Guid id)
        {
            Id = id;
        }
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; } = "place_holder@hotmail.com";
        public DateTimeOffset? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
