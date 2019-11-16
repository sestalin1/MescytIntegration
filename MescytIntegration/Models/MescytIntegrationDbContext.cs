using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MescytIntegration.Models
{
    public class MescytIntegrationDbContext : System.Data.Entity.DbContext
    {
        public MescytIntegrationDbContext() : base("MescytIntegration")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MescytIntegrationDbContext, Migrations.Configuration>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<NewStudentsFat> NewStudents { get; set; }
        public DbSet<Carreer> Carreers { get; set; }
        public DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}