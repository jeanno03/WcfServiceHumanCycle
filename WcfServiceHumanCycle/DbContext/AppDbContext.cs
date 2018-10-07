using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;


namespace WcfServiceHumanCycle.Model
{

    public class AppDbContext:DbContext
    {

        public AppDbContext()
        {
            SetConfigurationOptions();
        }

        private void SetConfigurationOptions()
        {
            //Configuration.LazyLoadingEnabled = false;
            //Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Human> Humans { get; set; }
        //public DbSet<Human> Parents { get; set; }
        //public DbSet<Human> Children { get; set; }
        public DbSet<Slice> Slices { get; set; }
        public DbSet<Statut> Statuts { get; set; }
        public DbSet<Town> Towns { get; set; }
    }
}