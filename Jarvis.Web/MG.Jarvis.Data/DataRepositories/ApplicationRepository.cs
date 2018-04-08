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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly JarvisContext _context;
        public ApplicationRepository(JarvisContext context)
        {
            _context = context;
        }

        public void Add(Application newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<long> ExecuteStoredProcedure(string storedProcedurename, object[] parameterCollection)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Application> Find(Expression<Func<Application, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Application Get(Guid id)
        {
            return _context.Application
               .Where(app => app.Id == id).FirstOrDefault();
        }

        public void Remove(Application entity)
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
