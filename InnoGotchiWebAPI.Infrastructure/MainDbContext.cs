﻿using InnoGotchiWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchiWebAPI.Infrastructure
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
             : base(options)
        {
        }
        public DbSet<Collaboration> Collaboration {get; set;}
        public DbSet<Look> Look { get; set; }
        public DbSet<Characteristic> Characteristic { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Pet> Pet { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaboration>()
                .HasMany(p => p.User)
                .WithMany(b => b.Collaborations);

            modelBuilder.Entity<Farm>()
                .HasOne(p => p.User)
                .WithMany(b => b.Farms)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Farm>()
                .HasMany(p => p.Pets)
                .WithOne(b => b.Farm)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Characteristic>()
                .HasOne(p => p.Pet)
                .WithMany(b => b.Characteristics);

            modelBuilder.Entity<Look>()
                .HasOne(p => p.Pet)
                .WithMany(b => b.Looks);

            modelBuilder.Entity<Pet>()
               .HasMany(p => p.Characteristics)
               .WithOne(b => b.Pet);

            modelBuilder.Entity<Pet>()
               .HasOne(p => p.Farm)
               .WithMany(b => b.Pets);

            modelBuilder.Entity<Pet>()
               .HasMany(p => p.Looks)
               .WithOne(b => b.Pet);

            modelBuilder.Entity<User>()
               .HasMany(p => p.Collaborations)
               .WithMany(b => b.User);

            modelBuilder.Entity<User>()
               .HasMany(p => p.Farms)
               .WithOne(b => b.User);
        }
    }
}
