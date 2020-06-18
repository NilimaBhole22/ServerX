using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimesheetApplication.Models
{
  public class RegistrationDetailContext : IdentityDbContext<ApplicationUser>
  {
    public RegistrationDetailContext(DbContextOptions<RegistrationDetailContext> options) : base(options)
    {

    }

    public DbSet<RegistrationDetail> RegistrationDetails { get; set; }
    public DbSet<LoginDetail> LoginDetails { get; set; }
    public DbSet<TimesheetDetail> TimesheetDetails { get; set; }
    public DbSet<ProjectDetail> ProjectDetails { get; set; }
    public DbSet<AssignedProject> ProjectsAssignmentDetails { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<RegistrationDetail>().ToTable("RegistrationDetails");
      builder.Entity<LoginDetail>().ToTable("LoginDetails");
      builder.Entity<TimesheetDetail>().ToTable("TimesheetDetails");
      builder.Entity<ProjectDetail>().ToTable("ProjectDetails");
      builder.Entity<AssignedProject>().ToTable("ProjectsAssignmentDetails");
    }
  }
}
