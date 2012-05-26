
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CalabashMedia.EmiEurope.Domain.Entities;

namespace CalabashMedia.EmiEurope.DataAccess
{
    public class VacancyContext : DbContext 
    {
        public VacancyContext()
        {
            
        }
        public DbSet<Vacancy> Vacancy { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<EmploymentType> EmploymentType { get; set; }
        public DbSet<State> State { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
