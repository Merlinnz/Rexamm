using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<EmployeeHistory> EmployeeHistories { get; set; }
    public DbSet<AboutEmployee> AboutEmployees { get; set; }
    public DbSet<About> AboutEs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId); 
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.EmployeeHistory)
                .WithOne(i => i.Employee)
                .HasForeignKey<Employee>(e => e.EmployeeId);

        modelBuilder.Entity<Employee>().HasKey(r => r.EmployeeId);
            modelBuilder.Entity<Employee>()
                .HasOne(r => r.Job)
                .WithOne(o => o.Employee)
                .HasForeignKey<Employee>(r => r.EmployeeId);
    }
}