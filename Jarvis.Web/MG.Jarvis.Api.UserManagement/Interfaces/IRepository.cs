namespace MG.Jarvis.Api.UserManagement.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Interface for repository
    /// </summary>
    /// <typeparam name="TEntity"> entity list </typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// generic get method which accept expression
        /// </summary>
        /// <param name="filter">filter criteria applied in expression</param>
        /// <param name="orderBy">order by </param>
        /// <param name="includeProperties"> if any include</param>
        /// <returns>return list</returns>
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        
        /// <summary>
        /// get a entity based on passed id
        /// </summary>
        /// <param name="id">primary id</param>
        /// <returns>return entity list</returns>
        TEntity GetById(object id);
        
        /// <summary>
        /// inert method
        /// </summary>
        /// <param name="entity">entity to insert</param>
        void Insert(TEntity entity);

        void Insert(List<TEntity> entityList);
        
        /// <summary>
        /// delete method
        /// </summary>
        /// <param name="id">pass the primary id</param>
        void Delete(object id);

        void Delete(List<TEntity> entityToDelete);
        /// <summary>
        /// delete method
        /// </summary>
        /// <param name="entityToDelete">accept entity to delete</param>
        void Delete(TEntity entityToDelete);
        
        /// <summary>
        /// update method
        /// </summary>
        /// <param name="entityToUpdate"> entity list to update</param>
        void Update(TEntity entityToUpdate);

        void Update(List<TEntity> entityListToUpdate);
        
        /// <summary>
        /// save method
        /// </summary>
        void Save();
    }
}
