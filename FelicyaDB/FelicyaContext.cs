using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FelicyaDB.Entities;
using FelicyaDB.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FelicyaDB
{
  public class FelicyaContext : DbContext
  {
    public DbSet<Project> Projects { get; set; }
    public DbSet<Material> Materials { get; set; }

    public FelicyaContext(DbContextOptions<FelicyaContext> options) : base(options)
    {
      //TODO: 
    }

    //Til test
    public FelicyaContext()
    {
      //TODO: 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RFTest;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Project>()
        .HasMany(p => p.Materials)
        .WithOne(m => m.Project);

      //TODO: Index-keys.
    }

    public override int SaveChanges()
    {
      // TODO: Skal vi danne entries. 
      List<(EntityState, object)> entries = EntityChange();
      int result = base.SaveChanges();

      return result;
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
      // TODO: Skal vi danne entries. 
      List<(EntityState, object)> entries = EntityChange();
      int result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

      return result;
    }

    private List<(EntityState, object)> EntityChange()
    {
      DateTime now = DateTime.UtcNow;
      List<(EntityState, object)> entityEntries = new List<(EntityState, object)>();

      foreach (EntityEntry item in ChangeTracker.Entries())
      {
        if ((item.State == EntityState.Added || item.State == EntityState.Modified) && item.Entity is IUpdatedOn asUpdatedOn)
          asUpdatedOn.UpdatedOn = now;

        if (item.State == EntityState.Added && item.Entity is ICreatedOn asCreatedOn)
          asCreatedOn.CreatedOn = now;

        entityEntries.Add((item.State, item.Entity));
      }

      return entityEntries;
    }
  }
}

