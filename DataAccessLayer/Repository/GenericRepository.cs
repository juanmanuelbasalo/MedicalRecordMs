﻿using MedicalRecordMs.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MedicalRecordMs.DataAccessLayer.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly MedicalRecordContext _dbContext;
        public GenericRepository(MedicalRecordContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAllReadOnly<TEntity>() where TEntity : BaseEntity
        {
            var entities = _dbContext.Set<TEntity>().AsNoTracking();
            return entities;
        }
        public void Insert<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            var entities = _dbContext.Set<TEntity>();
            entities.Add(entity);
        }
        public async Task<TEntity?> FindAsync<TEntity>(Expression<Func<TEntity, bool>> searchTerm) where TEntity : BaseEntity
        {
            var entities = _dbContext.Set<TEntity>();
            var entity = await entities.FirstOrDefaultAsync(searchTerm);

            return entity;
        }
        public IQueryable<TEntity> FindAll<TEntity>(Expression<Func<TEntity, bool>> searchTerm) where TEntity : BaseEntity
        {
            var entities = _dbContext.Set<TEntity>();
            var allEntities = entities.Where(searchTerm);

            return allEntities;
        }
        public async Task<bool> SaveAsync(string userEmail)
        {
            var result = await _dbContext.SaveChangesAsync(userEmail);
            return result;
        }

    }

    public static class RepositoryExtensions
    {
        public static IQueryable<TEntity> IncludeRelatedEntities<TEntity>(this IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes) where TEntity : BaseEntity
        {
            foreach (var include in includes)
            {
                if (include.Body is MemberExpression)
                    query = query.Include(include);
            }

            return query;
        }
    }
}
