using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSchool.Models;
using WebSchoolDomainModel.Models;

namespace WebSchoolDomainModel
{
    public class WSContext : IdentityDbContext<ApplicationUser>
    {
        public WSContext()
            : base("WSContext", throwIfV1Schema: false)
        {
        }

        public static WSContext Create()
        {
            return new WSContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<EducationalClass> EducationalClasses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Pupil> Pupils { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
