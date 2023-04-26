using InnoGotchiWebAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InnoGotchiWebAPI.Infrastructure
{
    public class MainDbContext : IdentityDbContext<IdentityUser>
    {
        public MainDbContext(DbContextOptions<MainDbContext> options)
             : base(options)
        {
        }
        public DbSet<Collaboration> Collaboration { get; set; }
        public DbSet<Look> Look { get; set; }
        public DbSet<Characteristic> Characteristic { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Pet> Pet { get; set; }
        public DbSet<RegisterModel> Registration { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaboration>()
                .HasOne(p => p.User)
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
                .WithMany(b => b.Characteristics)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Look>()
                .HasOne(p => p.Pet)
                .WithMany(b => b.Looks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pet>()
               .HasMany(p => p.Characteristics)
               .WithOne(b => b.Pet)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pet>()
               .HasOne(p => p.Farm)
               .WithMany(b => b.Pets)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Pet>()
               .HasMany(p => p.Looks)
               .WithOne(b => b.Pet)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
               .HasMany(p => p.Collaborations)
               .WithOne(b => b.User);

            modelBuilder.Entity<User>()
               .HasMany(p => p.Farms)
               .WithOne(b => b.User)
               .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
