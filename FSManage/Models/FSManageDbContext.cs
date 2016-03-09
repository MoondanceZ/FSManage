using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace FSManage.Models
{
    public class FSManageDbContext : DbContext
    {
        public FSManageDbContext()
            : base("name=ConnStr")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new UnintentionalCodeFirstException();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<UType> UType { get; set; }
        public DbSet<Product> Product { get; set; }
        //public DbSet<ProductType> ProductType { get; set; }
        //public DbSet<AdminAuthority> AdminAuthority { get; set; }
        //public DbSet<AdminRole> AdminRole { get; set; }
        public DbSet<AdminUser> AdminUser { get; set; }
        //public DbSet<RoleAuthority> RoleAuthority { get; set; }
        //public DbSet<RoleType> RoleType { get; set; }
    }
}