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
    }
}