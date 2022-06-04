namespace MedicalRecordMs.DataAccessLayer.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTimeOffset CreatedAt { get; set; }
        public string CreatedBy { get; set; } = "place_holder@hotmail.com";
        public DateTimeOffset? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
