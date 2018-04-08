using MG.Jarvis.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MG.Jarvis.Data
{
    public class JarvisContext : IdentityDbContext<JarvisUser, JarvisRole, Guid>
    {
        public DbSet<Application> Application { get; set; }
        public DbSet<ApplicationFeature> ApplicationFeature { get; set; }         
        public DbSet<FeatureType> FeatureType { get; set; }
        public DbSet<FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        public DbSet<UserAppRoleMapping> UserAppRoleMapping { get; set; }
        public JarvisContext(DbContextOptions<JarvisContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
                // Change the JarvisUser entity to point to the User   Table instead of the default
            builder.Entity<JarvisUser>().ToTable("User", "AccessPermission");
                // Change the JarvisUser entity to point to the User   Table instead of the default
            builder.Entity<JarvisRole>().ToTable("Role", "AccessPermission");

            // Changing the Default Schemas
            // https://stackoverflow.com/questions/28948309/how-to-remove-dbo-aspnetuserclaims-and-dbo-aspnetuserlogins-tables-identityuser/28950804
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AspNetUserClaims", "AccessPermission");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AspNetUserRoles", "AccessPermission");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AspNetRoleClaims", "AccessPermission");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AspNetUserLogins", "AccessPermission");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AspNetUserTokens", "AccessPermission");
            //builder.Entity<IdentityRoleClaim<int>>().ToTable("AspNetRoleClaims", "AccessPermission");
            //builder.Entity<IdentityUserLogin<int>>().ToTable("AspNetUserLogins", "AccessPermission");

            //builder.Ignore<IdentityRoleClaim<int>>();
            //builder.Ignore<IdentityUserClaim<int>>();
            //builder.Ignore<IdentityUserLogin<int>>();
            //builder.Ignore<IdentityUserRole<int>>();
            //builder.Ignore<IdentityUserToken<int>>();
        }
    }
}
