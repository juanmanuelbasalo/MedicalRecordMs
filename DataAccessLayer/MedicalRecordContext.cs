using MedicalRecordMs.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalRecordMs.DataAccessLayer
{
    public class MedicalRecordContext : DbContext
    {
        public MedicalRecordContext(DbContextOptions<MedicalRecordContext> options) : base(options)
        {
        }

        public async Task<bool> SaveChangesAsync(string userEmail, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving(userEmail);
            return await (SaveChangesAsync(acceptAllChangesOnSuccess: true, cancellationToken)) > 0;
        }

        protected virtual void OnBeforeSaving(string userEmail)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTimeOffset.UtcNow.UtcDateTime;
                        entry.Entity.CreatedBy = userEmail;
                        break;

                    // Write modification date
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTimeOffset.UtcNow.UtcDateTime;
                        entry.Entity.UpdatedBy = userEmail;
                        break;
                }
        }
    }
}
