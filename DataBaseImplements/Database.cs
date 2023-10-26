using DataBaseImplements.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseImplements
{
    public class Database : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=COP;Username=postgres;Password=postgres");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Education> Educations { set; get; }
    }
}
