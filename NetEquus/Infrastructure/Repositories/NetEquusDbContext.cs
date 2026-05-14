using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.Models.Users;
using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.Horses;
using Domain.Entities.Models.Horses.Relations;

namespace Infrastructure
{
    public class NetEquusDbContext : DbContext
    {
        public NetEquusDbContext(DbContextOptions<NetEquusDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Breed> Breeds { get; set; }

        public virtual DbSet<EquineEstate> EquineEstates { get; set; }

        public virtual DbSet<EstateOwnership> EstateOwnerships { get; set; }

        public virtual DbSet<HorseArtist> HorseArtists { get; set; }

        public virtual DbSet<Horse> Horses { get; set; }

        public virtual DbSet<HorseOwnership> HorseOwnerships { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<HorseArtist>()
            .HasOne(h => h.User)
            .WithOne(u => u.HorseArtist)
            .HasForeignKey<HorseArtist>(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
