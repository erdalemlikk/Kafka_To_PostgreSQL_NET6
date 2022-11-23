using KafkaToPsql.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace KafkaToPsql.Repository;

public class TestDbContext : DbContext
{
	public TestDbContext(DbContextOptions<TestDbContext> options) :base(options)
	{
	}
	public DbSet<TestModel> TestModels { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TestModel>()
            .ToTable("kafkatesttable")
            .HasKey(x => x.Id);
    }
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
