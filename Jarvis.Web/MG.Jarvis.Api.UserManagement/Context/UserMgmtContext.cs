using System;
using MG.Jarvis.Api.UserManagement.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MG.Jarvis.Api.UserManagement.Context
{
    public partial class UserMgmtContext : DbContext
    {
        public UserMgmtContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Entities.Application> Application { get; set; }
        public virtual DbSet<Entities.ApplicationFeature> ApplicationFeature { get; set; }
        public virtual DbSet<Entities.ApplicationRole> ApplicationRole { get; set; }
        public virtual DbSet<Entities.Department> Department { get; set; }
        public virtual DbSet<Entities.Feature> Feature { get; set; }
        public virtual DbSet<Entities.FeatureTypeRolePrivilege> FeatureTypeRolePrivilege { get; set; }
        public virtual DbSet<Entities.Role> Role { get; set; }
        public virtual DbSet<Entities.User> User { get; set; }
        public virtual DbSet<Entities.UserAppRoleMapping> UserAppRoleMapping { get; set; }
        public virtual DbSet<Entities.UserDepartments> UserDepartments { get; set; }

        public virtual DbSet<Entities.UserHotel> UserHotels { get; set; }

        public virtual DbSet<Entities.UserAgent> Agents    { get; set; }
        public virtual DbSet<Entities.UserType> UserType { get; set; }

        public virtual DbSet<Entities.Hotel> Hotels { get; set; }

        public virtual DbSet<Entities.Agency> Agencies { get; set; }

        public virtual DbSet<Entities.AgencyBranch> AgencyBranches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Hotel>(entity =>
            {
                entity.ToTable("Hotel", "Hotel");

               
            });

            modelBuilder.Entity<Entities.Agency>(entity =>
            {
                entity.ToTable("Agency", "Agency");


            });

            modelBuilder.Entity<Entities.AgencyBranch>(entity =>
            {
                entity.ToTable("Branch", "Agency");


            });

            modelBuilder.Entity<Entities.Application>(entity =>
            {
                entity.ToTable("Application", "AccessPermission");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Entities.ApplicationFeature>(entity =>
            {
                entity.ToTable("ApplicationFeature", "AccessPermission");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationFeature)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_ApplicationFeature_ApplicationId_AccessPermission_Application_Id");

                entity.HasOne(d => d.FeatureType)
                    .WithMany(p => p.ApplicationFeature)
                    .HasForeignKey(d => d.FeatureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_ApplicationFeature_FeatureTypeId_AccessPermission_FeatureType_Id");
            });

            modelBuilder.Entity<Entities.ApplicationRole>(entity =>
            {
                entity.ToTable("ApplicationRole", "AccessPermission");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.ApplicationRole)
                    .HasForeignKey(d => d.ApplicationId)
                    .HasConstraintName("FK_ApplicationRole_Application");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_ApplicationRole_Role");
            });

            modelBuilder.Entity<Entities.Department>(entity =>
            {
                entity.ToTable("Department", "AccessPermission");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Entities.Feature>(entity =>
            {
                entity.ToTable("Feature", "AccessPermission");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.HasOne(d => d.ParentFeature)
                    .WithMany(p => p.InverseParentFeature)
                    .HasForeignKey(d => d.ParentFeatureId)
                    .HasConstraintName("fk_AccessPermission_FeatureType_ParentFeatureId_AccessPermission_FeatureType_Id");
            });

            modelBuilder.Entity<Entities.FeatureTypeRolePrivilege>(entity =>
            {
                entity.ToTable("FeatureTypeRolePrivilege", "AccessPermission");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.HasOne(d => d.FeatureType)
                    .WithMany(p => p.FeatureTypeRolePrivilege)
                    .HasForeignKey(d => d.FeatureTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_FeatureTypeRolePrivilege_FeatureTypeId_AccessPermission_FeatureType_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.FeatureTypeRolePrivilege)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_FeatureTypeRolePrivilege_RoleId_AccessPermission_Role_Id");
            });

            modelBuilder.Entity<Entities.Role>(entity =>
            {
                entity.ToTable("Role", "AccessPermission");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");
            });

            modelBuilder.Entity<Entities.User>(entity =>
            {
                entity.ToTable("User", "AccessPermission");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy).HasMaxLength(256);

                entity.Property(e => e.DeActivateDate).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PhotoUrl).HasMaxLength(256);

                entity.Property(e => e.UpdatedBy).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.UserTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserType)
                    .HasConstraintName("FK_User_UserType");
            });

            modelBuilder.Entity<Entities.UserAppRoleMapping>(entity =>
            {
                entity.ToTable("UserAppRoleMapping", "AccessPermission");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasDefaultValueSql("(suser_sname())");

                entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(dateadd(hour,(7),getutcdate()))");

                entity.HasOne(d => d.Application)
                    .WithMany(p => p.UserAppRoleMapping)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_UserAppRoleMapping_ApplicationId_AccessPermission_Application_Id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserAppRoleMapping)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_UserAppRoleMapping_RoleId_AccessPermission_Role_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAppRoleMapping)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AccessPermission_UserAppRoleMapping_UserId_AccessPermission_User_Id");
            });

            modelBuilder.Entity<Entities.UserDepartments>(entity =>
            {
                entity.ToTable("UserDepartments", "AccessPermission");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.UserDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_UserDepartments_Department");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserDepartments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserDepartments_User");
            });

            modelBuilder.Entity<Entities.UserHotel>(entity =>
            {
                entity.ToTable("HotelUserRelation", "AccessPermission");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserHotels)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_AccessPermission_HotelUserRelation_UserId_AccessPermission_User_Id");
            });


            modelBuilder.Entity<Entities.UserAgent>(entity =>
            {
                entity.ToTable("Agents", "Agency");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserAgent)
                    //.HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Agency_Agents_UserId_AccessPermission_User_Id");
            });

            modelBuilder.Entity<Entities.UserType>(entity =>
            {
                entity.ToTable("UserType", "AccessPermission");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedBy)
                    .IsRequired()
                    .HasMaxLength(128);
            });
        }
    }
}
