using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using MG.Jarvis.Model;
using MG.Jarvis.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using MG.Jarvis.Model.DTOs;
using System.Threading.Tasks;

namespace MG.Jarvis.Data.DataRepositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly JarvisContext _context;

        public RoleRepository(JarvisContext context)
        {
            _context = context;
        }
        public void Add(JarvisRole newEntity)
        {
            throw new NotImplementedException();
        }

        public Task<long> ExecuteStoredProcedure(string storedProcedurename, object[] parameterCollection)
        {
            throw new NotImplementedException();
        }

        public IQueryable<JarvisRole> Find(Expression<Func<JarvisRole, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public JarvisRole Get(Guid id)
        {
            return _context.Roles.Include(role => role.FeatureTypeRolePrivilege)
               .Where(role => role.Id == id).FirstOrDefault();
        }       

        public List<RolePrivilege> GetRelatedPrivilegesForRoleAndApp(Guid roleId, Guid appId)
        {
            List<RolePrivilege> rolePrivileges = new List<RolePrivilege>();
            var role = _context.Roles.Where(r => r.Id == roleId).FirstOrDefault();

            rolePrivileges = _context.Entry(role).Collection(r => r.FeatureTypeRolePrivilege).Query()
                .Join(_context.ApplicationFeature, ftp => ftp.FeatureTypeId, ap => ap.FeatureTypeId, (r, ftp) => new { r, ftp })
                .Where(a => a.ftp.ApplicationId == appId)
                // .Select(m => new { m.ftp.FeatureTypeId, m.r.Privileges, m.r.Role.Name, m.ftp.FeatureType.TypeName, m.ftp.FeatureType.ParentFeatureId, m.ftp.FeatureType.Order });
                .Select(m => new RolePrivilege { FeatureTypeId= m.ftp.FeatureTypeId,
                    Privileges=m.r.Privileges,
                    RoleName= m.r.Role.Name,
                    FeatureTypeName= m.ftp.FeatureType.TypeName,
                    FeatureLabel = m.ftp.FeatureType.Description,
                    ParentFeatureId=m.ftp.FeatureType.ParentFeatureId,
                    Order=m.ftp.FeatureType.Order,
                    ApplicationName = m.ftp.Application.Name
                }).OrderBy(rp=>rp.ParentFeatureId).ThenBy(p=>p.Order).ToList();
            return rolePrivileges;            
        }
      
        public void Remove(JarvisRole entity)
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
