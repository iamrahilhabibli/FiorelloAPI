﻿using Fiorello.Domain.Entities;
using Fiorello.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Persistence.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
