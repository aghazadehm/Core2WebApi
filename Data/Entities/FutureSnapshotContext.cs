using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core2WebApi.Data.Entities
{
    public partial class FutureSnapshotContext : DbContext
    {
        public virtual DbSet<ContractFuture> ContractFutures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=172.16.1.122;Initial Catalog=FutureSnapshot;Persist Security Info=True;User ID=aghazadeh;Password=2494829");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractFuture>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.ToTable("Contract_Future", "Contract");

                entity.Property(e => e.ContractId)
                    .HasColumnName("ContractID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommodityAbbreviation).HasMaxLength(10);

                entity.Property(e => e.CommodityId).HasColumnName("CommodityID");

                entity.Property(e => e.CommodityName).HasMaxLength(50);

                entity.Property(e => e.CommoditySymbol).HasMaxLength(50);

                entity.Property(e => e.ContractCode).HasMaxLength(20);

                entity.Property(e => e.ContractDescription).HasMaxLength(500);

                entity.Property(e => e.FirstTradingDate).HasColumnType("smalldatetime");

                entity.Property(e => e.LastIm)
                    .HasColumnName("LastIM")
                    .HasColumnType("money");

                entity.Property(e => e.LastMm)
                    .HasColumnName("LastMM")
                    .HasColumnType("money");

                entity.Property(e => e.LastTradingDate).HasColumnType("smalldatetime");
            });
        }
    }
}
