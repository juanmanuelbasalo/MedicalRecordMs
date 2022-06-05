namespace MedicalRecordMs.DataAccessLayer.Entities
{
    public class PatientEntity : BaseEntity
    {
        public PatientEntity(Guid id) : base(id)
        {
        }

        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string FullName { get => $"{Name} {LastName}"; }
        public ICollection<MedicalRecordEntity> MedicalRecords { get; set; } = Array.Empty<MedicalRecordEntity>();
    }
}
