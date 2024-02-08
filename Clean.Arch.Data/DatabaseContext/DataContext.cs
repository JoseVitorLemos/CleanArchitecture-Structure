using Clean.Arch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Arch.Data.DatabaseContext;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    { }

    public DbSet<IndividualEntity> IndividualEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}
