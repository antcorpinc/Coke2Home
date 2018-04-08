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
    public class FeatureTypeRepository : IFeatureTypeRepository
    {
        private readonly JarvisContext _context;
        public FeatureTypeRepository(JarvisContext context)
        {
            _context = context;
        }
        public void Add(FeatureType newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<long> ExecuteStoredProcedure(string storedProcedurename, object[] parameterCollection)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FeatureType> Find(Expression<Func<FeatureType, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public FeatureType Get(int id)
        {
            
            return _context.FeatureType
               .Where(feat => feat.Id == id).FirstOrDefault();
        }

        public object GetApplicationRoleFeaturePrivileges(Guid applicationId, Guid roleId, Guid userId)
        {
            throw new NotImplementedException();

        }

        public void Remove(FeatureType entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
