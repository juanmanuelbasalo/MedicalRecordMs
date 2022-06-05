namespace MedicalRecordMs.DataAccessLayer.Entities
{
    public class MedicalRecordEntity : BaseEntity
    {
        public MedicalRecordEntity() : base(Guid.NewGuid())
        {
        }

        public Guid PatientId { get; set; }
        public PatientEntity? Patient { get; set; }
    }
}
