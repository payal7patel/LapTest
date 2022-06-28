using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LapAPI.Models;

namespace LapAPI.Data
{
    public partial class LapContext : DbContext
    {
        public LapContext()
        {
        }

        public LapContext(DbContextOptions<LapContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<LapInfo> LapInfos { get; set; } = null!;
        public virtual DbSet<Race> Races { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.HasIndex(e => e.Number, "IX_Car_Number")
                    .IsUnique();

                entity.Property(e => e.Number).HasColumnType("VARCHAR (10)");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.Name).HasColumnType("VARCHAR (100)");
            });

            modelBuilder.Entity<LapInfo>(entity =>
            {
                entity.ToTable("LapInfo");

                entity.Property(e => e.Time).HasColumnType("BIGINT");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.LapInfos)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Driver)
                    .WithMany(p => p.LapInfos)
                    .HasForeignKey(d => d.DriverId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.LapInfos)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Race>(entity =>
            {
                entity.ToTable("Race");

                entity.Property(e => e.Name).HasColumnType("VARCHAR (100)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
