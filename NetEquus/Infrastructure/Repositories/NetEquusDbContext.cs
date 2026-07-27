using Domain.Entities.Models.Breeds;
using Domain.Entities.Models.EquineEstates;
using Domain.Entities.Models.Horses;
using Domain.Entities.Models.Horses.Relations;
using Domain.Entities.Models.Users;
using Domain.Entities.Sales;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual DbSet<HorseBoarding> HorseBoardings { get; set; }

        public virtual DbSet<Horse> Horses { get; set; }

        public virtual DbSet<Foaling> Foalings { get; set; }

        public virtual DbSet<HorseOwnership> HorseOwnerships { get; set; }

        public virtual DbSet<HorseTraderSale> HorseTraderSales { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                    modelBuilder.Entity<HorseArtist>()
            .HasOne(h => h.User)
            .WithOne(u => u.HorseArtist)
            .HasForeignKey<HorseArtist>(h => h.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Foaling>(entity =>
            {
                entity.HasOne(d => d.Dam).WithMany(p => p.FoalingDams)
                .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Sire).WithMany(p => p.FoalingSires)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<HorseSaleBase>(entity =>
            {

                entity.HasOne(x => x.SellerUser)
                .WithMany()
                .HasForeignKey(x => x.SellerUserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(x => x.SellerEstate)
                .WithMany()
                .HasForeignKey(x => x.SellerEstateId)
                .OnDelete(DeleteBehavior.NoAction);

            });




            modelBuilder.Entity<HorseTraderSale>()
                .HasOne(x => x.BuyerUser)
                .WithMany()
                .HasForeignKey(x => x.BuyerUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EquineEstate>()
                .Property(e => e.CurrentBalance)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Horse>()
                .Property(h => h.EquinsValue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HorseTraderSale>()
                .Property(h => h.SalesPrice)
                .HasPrecision(18, 0);

        }





    }
}
