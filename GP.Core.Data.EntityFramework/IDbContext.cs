using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Objects;
using System.Data;


namespace GP.Core.Data.EntityFramework
{
    public interface IDbContext : IDisposable
    {
        DbSet<T> CreateDbSet<T>() where T : class;
        void SaveChanges();
        void ChangeObjectState<T>(T entity, EntityState entityState) where T : class;
        ObjectContext objectContext { get; }
    }
}
