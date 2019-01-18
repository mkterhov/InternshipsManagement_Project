using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternshipsManagmentProject.Data.Repos
{
    public class Repository <TEntity> where TEntity : class
    {
        protected readonly Func<Entities> _dbContextCreator;
        public Repository(Func<Entities> dbContextCreator)
        {
            if (dbContextCreator == null)
            {
                throw new ArgumentNullException(nameof(dbContextCreator), "The parameter dbContextCreator can not be null");
            }

            _dbContextCreator = dbContextCreator;
        }
        public Repository()
        {
            Func<Entities> contextCreator = () => new Entities();
            _dbContextCreator = contextCreator;
        }
        //FINDS BY PRIMARY KEY
        public TEntity GetById(params object[] pks)
        {
            if (pks == null) throw new ArgumentNullException(nameof(pks), "The parameter pks can not be null");
            TEntity result = null;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                result = dbSet.Find(pks);
            }
            return result;
        }
        public Task<TEntity> GetByIdAsync(params object[] pks)
        {
            return Task.Run(() => {
                return GetById(pks);
            });
        }
        //returns all the elements of the table
        public IEnumerable<TEntity> GetAll()
        {
            var result = Enumerable.Empty<TEntity>();
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                result = dbSet.ToList();
            }
            return result;
        }
        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return Task.Run(() => {
                return GetAll();
            });
        }
        //returns data filtered with the given expression
        public IEnumerable<TEntity> GetData(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null) throw new ArgumentNullException(nameof(filter), "The parameter filter can not be null");
            var result = Enumerable.Empty<TEntity>();
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                result = dbSet.Where(filter).ToList();
            }
            return result;
        }
        public Task<IEnumerable<TEntity>> GetDataAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Task.Run(() => {
                return GetData(filter);
            });
        }
        //Adds a new entity
        public int AddEntity(TEntity newEntity)
        {
            if (newEntity == null) throw new ArgumentNullException(nameof(newEntity), "The parameter newEntity can not be null");
            var result = 0;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                dbSet.Add(newEntity);
                result = context.SaveChanges();
            }
            return result;
        }
        public Task<int> AddAsync(TEntity newEntity)
        {
            return Task.Run(() => {
                return AddEntity(newEntity);
            });
        }
        //adds multiple entities
        public int AddEntity(IEnumerable<TEntity> newEntities)
        {
            if (newEntities == null) throw new ArgumentNullException(nameof(newEntities), "The parameter newEntities can not be null");
            var result = 0;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                dbSet.AddRange(newEntities);
                result = context.SaveChanges();
            }
            return result;
        }
        public Task<int> AddAsync(IEnumerable<TEntity> newEntities)
        {
            return Task.Run(() => {
                return AddEntity(newEntities);
            });
        }
        /// For Object (TEntity) removes the entity  
        public int Remove(TEntity removeEntity)
        {
            if (removeEntity == null) throw new ArgumentNullException(nameof(removeEntity), "The parameter removeEntity can not be null");
            var result = 0;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                dbSet.Attach(removeEntity);
                context.Entry(removeEntity).State = EntityState.Deleted;
                result = context.SaveChanges();
            }
            return result;
        }
        public Task<int> RemoveAsync(TEntity removeEntity)
        {
            return Task.Run(() => {
                return Remove(removeEntity);
            });
        }
        //removes a list of entries
        public int Remove(IEnumerable<TEntity> removeEntities)
        {
            if (removeEntities == null) throw new ArgumentNullException(nameof(removeEntities), "The parameter removeEntities can not be null");
            var result = 0;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                foreach (var removeEntity in removeEntities)
                {
                    dbSet.Attach(removeEntity);
                    context.Entry(removeEntity).State = EntityState.Deleted;
                }
                dbSet.RemoveRange(removeEntities);
                result = context.SaveChanges();
            }
            return result;
        }
        public Task<int> RemoveAsync(IEnumerable<TEntity> removeEntities)
        {
            return Task.Run(() => {
                return Remove(removeEntities);
            });
        }
        /// Remove 
        public int Remove(params object[] pks)
        {
            if (pks == null) throw new ArgumentNullException(nameof(pks), "The parameter removeEntity can not be null");
            var result = 0;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                var entity = GetById(pks);
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Deleted;
                result = context.SaveChanges();
            }
            return result;
        }
        public Task<int> RemoveAsync(params object[] pks)
        {
            return Task.Run(() => {
                return Remove(pks);
            });
        }
        //Update an entity
        public int UpdateEntity(TEntity updateEntity)
        {
            if (updateEntity == null) throw new ArgumentNullException(nameof(updateEntity), "The parameter updateEntity can not be null");
            var result = 0;
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                dbSet.Attach(updateEntity);
                context.Entry(updateEntity).State = EntityState.Modified;
                result = context.SaveChanges();
            }
            return result;
        }
        public Task<int> UpdateEntityAsync(TEntity updateEntity)
        {
            return Task.Run(() => {
                return UpdateEntity(updateEntity);
            });
        }
       
    }
}
