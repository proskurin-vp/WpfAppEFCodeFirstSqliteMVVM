using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppEF_MVVM_promUa.Models;

namespace WpfAppEF_MVVM_promUa.DbLayer
{
    public class PromuaDb : DbContext
    {
        public PromuaDb(string name) : base(name)
        {}
        public PromuaDb() : base("conStr")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>();            
            modelBuilder.Entity<Company>();
            modelBuilder.Entity<Product>();

           PromuaInitializer initializer = new PromuaInitializer(modelBuilder);
           Database.SetInitializer(initializer);            
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
