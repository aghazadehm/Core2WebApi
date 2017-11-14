using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core2WebApi.Data.Entities {
        public partial class InformingDBContext : DbContext {
            public virtual DbSet<Broker> Brokers { get; set; }

            protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
                if (!optionsBuilder.IsConfigured) {

                    optionsBuilder.UseSqlServer (
                        @"Data Source=172.16.1.122;Initial Catalog=InformingDB;Persist Security Info=True;User ID =aghazadeh;Password=2494829");
                        //Configuration.GetConnectionString("InformingDb"));
                    }
                }

                protected override void OnModelCreating (ModelBuilder modelBuilder) {
                    modelBuilder.Entity<Broker> (entity => {
                        entity.HasKey (e => e.BrokerKey)
                            .ForSqlServerIsClustered (false);

                        entity.ToTable ("Brokers", "Baseinfo");

                        entity.HasIndex (e => e.BrokerDerivativeKey)
                            .HasName ("UniqueExceptNullsDerivKeyBrokers")
                            .IsUnique ()
                            .HasFilter ("([BrokerDerivativeKey] IS NOT NULL)");

                        entity.HasIndex (e => e.BrokerSpotKey)
                            .HasName ("UniqueExceptNullsSpotKeyBrokers")
                            .IsUnique ()
                            .HasFilter ("([BrokerSpotKey] IS NOT NULL)");

                        entity.Property (e => e.BrokerAddress).HasMaxLength (200);

                        entity.Property (e => e.BrokerCeoName).HasMaxLength (30);

                        entity.Property (e => e.BrokerEnglishName)
                            .HasMaxLength (50)
                            .IsUnicode (false);

                        entity.Property (e => e.BrokerPersianName)
                            .IsRequired ()
                            .HasMaxLength (30);

                        entity.Property (e => e.BrokerPostalCode)
                            .HasMaxLength (11)
                            .IsUnicode (false);

                        entity.Property (e => e.BrokerTel)
                            .HasMaxLength (11)
                            .IsUnicode (false);
                    });
                }
            }
        }