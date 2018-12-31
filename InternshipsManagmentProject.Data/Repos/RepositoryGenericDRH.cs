using InternshipsManagmentProject.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InternshipsManagmentProject.Data.Repos
{
    public class RepositoryGenericDRH<TEntity> where TEntity : class
    {

        protected readonly Func<Entities> _dbContextCreator;
        public RepositoryGenericDRH(Func<Entities> dbContextCreator)
        {
            if (dbContextCreator == null)
            {
                throw new ArgumentNullException(nameof(dbContextCreator), "The parameter dbContextCreator can not be null");
            }

            _dbContextCreator = dbContextCreator;
        }
        //FINDS BY PRIMARY KEY
        public DataResponseHandler<TEntity> GetById(params object[] pks)
        {
            try
            {
                if (pks == null) throw new ArgumentNullException(nameof(pks), "The parameter pks can not be null");
                TEntity result = null;
                using (var context = _dbContextCreator())
                {
                    var dbSet = context.Set<TEntity>();
                    var role = new DataResponseHandler<TEntity> { Succes = true };
                    result = dbSet.Find(pks);
                    if(result!=null)
                    {
                        role.Container = result;

                    } 
                    else if(result==null)
                    {
                        return new DataResponseHandler<TEntity> { Succes = false };

                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                return new DataResponseHandler<TEntity> { Succes = false };
            }
            
        }
        public Task<DataResponseHandler<TEntity>> GetByIdAsync(params object[] pks)
        {
            return Task.Run(() =>
            {
                return GetById(pks);
            });
        }
        //returns all the elements of the table
        public DataResponseHandler<IEnumerable<TEntity>> GetAll()
        {
            var result = Enumerable.Empty<TEntity>();
            using (var context = _dbContextCreator())
            {
                var dbSet = context.Set<TEntity>();
                var role = new DataResponseHandler<IEnumerable<TEntity>> { Succes = true };
                result = dbSet.ToList();
                role.Container = result;
                return role;
            }
        }
        public Task<DataResponseHandler<IEnumerable<TEntity>>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                return GetAll();
            });
        }
        //returns data filtered with the given expression
        public DataResponseHandler<IEnumerable<TEntity>> GetData(Expression<Func<TEntity, bool>> filter)
        {try
            {
                if (filter == null) throw new ArgumentNullException(nameof(filter), "The parameter filter can not be null");
                var result = Enumerable.Empty<TEntity>();
                using (var context = _dbContextCreator())
                {
                    var role = new DataResponseHandler<IEnumerable<TEntity>> { Succes = true };
                    var dbSet = context.Set<TEntity>();
                    result = dbSet.Where(filter).ToList();
                    role.Container = result;
                    return role;

                }
            }
            catch (Exception ex)
            {
                return new DataResponseHandler<IEnumerable<TEntity>> { Succes = false };

            }
        }
        public Task<DataResponseHandler<IEnumerable<TEntity>>> GetDataAsync(Expression<Func<TEntity, bool>> filter)
        {
            return Task.Run(() =>
            {
                return GetData(filter);
            });
        }
        //Adds a new entity
        public DataResponseHandler<string> AddEntity(TEntity newEntity)
        {
            using (var context = _dbContextCreator())
            {
                try
                {
                    var result = 0;

                    var role = new DataResponseHandler<string> { Succes = true };
                    var dbSet = context.Set<TEntity>();
                    dbSet.Add(newEntity);
                    result = context.SaveChanges();
                    if (result == 0)
                    {
                        role = new DataResponseHandler<string> { Succes = false };
                    }
                    return role;
                }
                catch (Exception ex)
                {
                    return new DataResponseHandler<string> { Succes = false, Container = ex.Message };
                }
            }
        }
        public Task<DataResponseHandler<string>> AddAsync(TEntity newEntity)
        {
            return Task.Run(() =>
            {
                return AddEntity(newEntity);
            });
        }
        //adds multiple entities
        public DataResponseHandler<string> AddEntity(IEnumerable<TEntity> newEntities)
        {
            try
            {
                if (newEntities == null) throw new ArgumentNullException(nameof(newEntities), "The parameter newEntities can not be null");
                var result = 0;
                using (var context = _dbContextCreator())
                {
                    var dbSet = context.Set<TEntity>();
                    var role = new DataResponseHandler<string> { Succes = true };

                    dbSet.AddRange(newEntities);
                    result = context.SaveChanges();
                    if (result == 0)
                    {
                        return new DataResponseHandler<string> { Succes = false };
                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                return new DataResponseHandler<string> { Succes = false, Container = ex.Message };
            }
        }
        public Task<DataResponseHandler<string>> AddAsync(IEnumerable<TEntity> newEntities)
        {
            return Task.Run(() =>
            {
                return AddEntity(newEntities);
            });
        }
        /// For Object (TEntity) removes the entity  
        public DataResponseHandler<string> Remove(TEntity removeEntity)
        {
            try
            {
                if (removeEntity == null) throw new ArgumentNullException(nameof(removeEntity), "The parameter removeEntity can not be null");
                var result = 0;
                using (var context = _dbContextCreator())
                {
                    var dbSet = context.Set<TEntity>();
                    var role = new DataResponseHandler<string> { Succes = true };

                    dbSet.Attach(removeEntity);
                    context.Entry(removeEntity).State = EntityState.Deleted;
                    result = context.SaveChanges();
                    if (result == 0)
                    {
                        return new DataResponseHandler<string> { Succes = false };
                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                return new DataResponseHandler<string> { Succes = false, Container = ex.Message };
            };
        }

        public Task<DataResponseHandler<string>> RemoveAsync(TEntity removeEntity)
        {
            return Task.Run(() =>
            {
                return Remove(removeEntity);
            });
        }
        //removes a list of entries
        public DataResponseHandler<string> Remove(IEnumerable<TEntity> removeEntities)
        {
            try
            {
                if (removeEntities == null) throw new ArgumentNullException(nameof(removeEntities), "The parameter removeEntities can not be null");
                var result = 0;
                using (var context = _dbContextCreator())
                {
                    var role = new DataResponseHandler<string> { Succes = true };

                    var dbSet = context.Set<TEntity>();
                    foreach (var removeEntity in removeEntities)
                    {
                        dbSet.Attach(removeEntity);
                        context.Entry(removeEntity).State = EntityState.Deleted;
                    }
                    dbSet.RemoveRange(removeEntities);
                    result = context.SaveChanges();
                    if (result == 0)
                    {
                        return new DataResponseHandler<string> { Succes = false };
                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                return new DataResponseHandler<string> { Succes = false, Container = ex.Message };
            }
        }
        public Task<DataResponseHandler<string>> RemoveAsync(IEnumerable<TEntity> removeEntities)
        {
            return Task.Run(() =>
            {
                return Remove(removeEntities);
            });
        }
        /// Remove 
        public DataResponseHandler<string> Remove(params object[] pks)
        {
            try {
                if (pks == null) throw new ArgumentNullException(nameof(pks), "The parameter removeEntity can not be null");
                var result = 0;
                using (var context = _dbContextCreator())
                {
                    var role = new DataResponseHandler<string> { Succes = true };

                    var dbSet = context.Set<TEntity>();
                    var entity = GetById(pks);
                    dbSet.Attach(entity.Container);
                    context.Entry(entity).State = EntityState.Deleted;
                    result = context.SaveChanges();
                    if (result == 0)
                    {
                        return new DataResponseHandler<string> { Succes = false };
                    }
                    return role;
                }
            }
            catch (Exception ex)
            {
                return new DataResponseHandler<string> { Succes = false, Container = ex.Message };

            }
           
        }
        public Task<DataResponseHandler<string>> RemoveAsync(params object[] pks)
        {
            return Task.Run(() =>
            {
                return Remove(pks);
            });
        }
        //Update an entity
        public DataResponseHandler<string> UpdateEntity(TEntity updateEntity)
        {   try
            {
                var role = new DataResponseHandler<string> { Succes = true };
                if (updateEntity == null) throw new ArgumentNullException(nameof(updateEntity), "The parameter updateEntity can not be null");
                var result = 0;
                using (var context = _dbContextCreator())
                {
                    var dbSet = context.Set<TEntity>();
                    dbSet.Attach(updateEntity);
                    context.Entry(updateEntity).State = EntityState.Modified;
                    result = context.SaveChanges();
                    if (result == 0)
                    {
                        return new DataResponseHandler<string> { Succes = false };
                    }
                    return role;
                }

            }
            catch (Exception ex)
            {
                return new DataResponseHandler<string> { Succes = false, Container = ex.Message };

            }
           
        }
        public Task<DataResponseHandler<string>> UpdateEntityAsync(TEntity updateEntity)
        {
            return Task.Run(() =>
            {
                return UpdateEntity(updateEntity);
            });
        }


    }
}
