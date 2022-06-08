using MedicalRecordMs.DataAccessLayer.Repository;

namespace MedicalRecordMs.BusinessLayer.Services
{
    public class RecordManagerService : IRecordManagerService
    {
        private readonly IGenericRepository _genericRepo;
        public RecordManagerService(IGenericRepository genericRepo)
        {
            _genericRepo = genericRepo;
        }
    }
}
