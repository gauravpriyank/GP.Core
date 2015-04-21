using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Core.Data.EntityFramework
{
    public class DbContextAdapter : IDbContext
    {
        private readonly DbContext _dbContext;

        public DbContextAdapter(DbContext context)
        {
            _dbContext = context;
        }

        public ObjectContext objectContext
        {
            get { return ((IObjectContextAdapter)_dbContext).ObjectContext; }
        }

        #region IDbContext Members

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public DbSet<T> CreateDbSet<T>() where T : class
        {
            return _dbContext.Set<T>();
        }

        public void ChangeObjectState<T>(T entity, EntityState entityState) where T : class
        {
            objectContext.ObjectStateManager.ChangeObjectState(entity, entityState);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        #endregion
    }
}
