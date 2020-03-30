using System;
using Microsoft.EntityFrameworkCore;
using MV.Web.Models;

namespace MV.Web.Data
{
  public class MembershipsContext : DbContext
  {
    public MembershipsContext(DbContextOptions<MembershipsContext> options)
        : base(options)
    {
    }

    public DbSet<Membership> Memberships { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Membership>().ToTable("Membership");
      modelBuilder.Entity<Person>().ToTable("Person");
    }
  }
}
