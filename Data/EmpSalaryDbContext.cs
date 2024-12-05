using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalaryCalculationAPI.Models;

namespace SalaryCalculationAPI.Data
{
    public class EmpSalaryDbContext : DbContext
    {
        public EmpSalaryDbContext(DbContextOptions<EmpSalaryDbContext> options) : base (options){}

        public DbSet<SalaryModel> SalaryModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<SalaryModel>()
        .HasKey(s => s.SalaryId); // Define primary key explicitly
}
    }
}