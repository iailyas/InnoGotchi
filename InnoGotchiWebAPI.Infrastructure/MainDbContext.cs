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
        public DbSet<Tamagochi> Tamagochis { get; set; }

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
            modelBuilder.Entity<Look>().HasData(
                new Look
                {
                    Id = 1,
                    Body = "＼( ❤‿❤ *)／"
                },
                new Look
                {
                    Id = 2,
                    Body = "ヽ(￣～￣　)ノ"
                },
                new Look
                {
                    Id = 3,
                    Body = "(ｏ・_・)"
                },
                new Look
                {
                    Id = 4,
                    Body = "(o-_-o)"
                },
                new Look
                {
                    Id = 5,
                    Body = "(｡•́︿•̀｡)"
                },
                new Look
                {
                    Id = 6,
                    Body = "(￣□￣」)"
                },
                new Look
                {
                    Id = 7,
                    Body = "＼(〇_ｏ)／"
                },
                new Look
                {
                    Id = 8,
                    Body = "ヽ(‵﹏´)ノ"
                },
                new Look
                {
                    Id = 9,
                    Body = "٩(╬ʘ益ʘ╬)۶"
                },
                new Look
                {
                    Id = 10,
                    Body = "~(> _ < ~)"
                },
                new Look
                {
                    Id = 11,
                    Body = "ψ(▼へ▼メ)～→"
                },
                //bear
                new Look
                {
                    Id = 12,
                    Body = "ʕ ◕ᴥ◕ ʔ"
                },
                new Look
                {
                    Id = 13,
                    Body = "┏ʕ •ᴥ•ʔ┛"
                },
                new Look
                {
                    Id = 14,
                    Body = "ᵔᴥᵔ"
                },
                new Look
                {
                    Id = 15,
                    Body = "ʕ•̮͡•ʔ"
                },
                new Look
                {
                    Id = 16,
                    Body = "ᶘಠᴥಠᶅ"
                },
                new Look
                {
                    Id = 17,
                    Body = "ʕ •ₒ• ʔ"
                },
                new Look
                {
                    Id = 18,
                    Body = "ʕ – ᴥ – ʔ"
                },
                new Look
                {
                    Id = 19,
                    Body = "ʕ╯• ⊱ •╰ʔ"
                },
                new Look
                {
                    Id = 20,
                    Body = "ʕ ´•̥̥̥ ᴥ•̥̥̥`ʔ"
                },
                new Look
                {
                    Id = 21,
                    Body = "ʕ≧ᴥ≦ʔ"
                },
                new Look
                {
                    Id = 22,
                    Body = "・・・ʕ ˵ ̿–ᴥ ̿– ˵ ʔ"
                }

                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
