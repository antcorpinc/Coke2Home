using MG.Jarvis.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using MG.Jarvis.Model;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MG.Jarvis.Data.DataRepositories
{
    public class UserRepository : IUserRepository
    {
            // ToDo: Inject the UserManager - For adding Users
        private readonly JarvisContext _context;
       // private readonly UserManager<JarvisUser> _userManager;
        public UserRepository(JarvisContext context)
        {
            _context = context;
          //  _userManager = userManager;
        }
        public void Add(JarvisUser newEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<long> ExecuteStoredProcedure(string storedProcedurename, object[] parameterCollection)
        {
           return await  _context.Database.ExecuteSqlCommandAsync(storedProcedurename, parameterCollection);
        }

        public IQueryable<JarvisUser> Find(Expression<Func<JarvisUser, bool>> predicate)
        {
            return _context.Users.Where(predicate);
            //throw new NotImplementedException();
        }

        public JarvisUser Get(Guid id)
        {           
            return _context.Users.Include(approle=>approle.UserAppRoleMappings)  
                
                .Where(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(JarvisUser entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
