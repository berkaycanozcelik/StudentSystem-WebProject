using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentSystem.Models
{
    public class SisDbContext : DbContext
    {
        public SisDbContext(DbContextOptions<SisDbContext> options) : base(options)
        {
         
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Ders> Dersler { get; set; }
        public DbSet<StudentDers> StudentDersler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentDers>().HasKey(pk => new { pk.StudentId, pk.DersId  });
        }
    }
   
}
