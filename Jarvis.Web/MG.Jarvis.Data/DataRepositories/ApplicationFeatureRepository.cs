using MG.Jarvis.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using MG.Jarvis.Model;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MG.Jarvis.Data.DataRepositories
{
    public class ApplicationFeatureRepository : IApplicationFeatureRepository
    {
        private readonly JarvisContext _context;
        public ApplicationFeatureRepository(JarvisContext context)
        {
            _context = context;
        }
        public void Add(ApplicationFeature newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<long> ExecuteStoredProcedure(string storedProcedurename, object[] parameterCollection)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ApplicationFeature> Find(Expression<Func<ApplicationFeature, bool>> predicate)
        {
            return _context.ApplicationFeature.Where(predicate);
        }

        public ApplicationFeature Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(ApplicationFeature entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
