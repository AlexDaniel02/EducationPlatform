using EducationPlatform.Models.EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models
{
    public class EducationPlatformDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        //public DbSet<ClassSubject> SubjectClasses { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Absence> Absences { get; set; }
/*        public DbSet<Average> Averages { get; set; }
*/        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=EducationPlatform;Integrated Security=SSPI;TrustServerCertificate=True").LogTo(Console.WriteLine); 
        }
/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
         .HasOne(e => e.ClassMaster)
            .WithOne(e => e.ClassMaster)
         .HasForeignKey<Class>(e => e.ClassMasterId)
         .IsRequired();
        }*/
    }
    
}
