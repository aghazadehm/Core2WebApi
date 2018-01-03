using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core2WebApi.Data.Entities
{
    public partial class FutureSnapshotContext : DbContext
    {
        public virtual DbSet<ContractFuture> ContractFuture { get; set; }
        public virtual DbSet<FutureMarketDailyStatistics> FutureMarketDailyStatistics { get; set; }

        // Unable to generate entity type for table 'Contract.SettlementPrice_Future'. Please see the warning messages.

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

            modelBuilder.Entity<FutureMarketDailyStatistics>(entity =>
            {
                entity.HasKey(e => new { e.ContractId, e.Dt });

                entity.ToTable("FutureMarketDailyStatistics", "Log");

                entity.Property(e => e.ContractId).HasColumnName("ContractID");

                entity.Property(e => e.Dt)
                    .HasColumnName("DT")
                    .HasColumnType("date");

                entity.Property(e => e.CBuy).HasColumnName("C_Buy");

                entity.Property(e => e.CSell).HasColumnName("C_Sell");

                entity.Property(e => e.ContractCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.DeliveryDate).HasColumnType("smalldatetime");

                entity.Property(e => e.FirstPrice).HasColumnType("money");

                entity.Property(e => e.LastPrice).HasColumnType("money");

                entity.Property(e => e.LastSettlementPrice).HasColumnType("money");

                entity.Property(e => e.MaxPrice).HasColumnType("money");

                entity.Property(e => e.MinPrice).HasColumnType("money");

                entity.Property(e => e.SettlementPricePercent).HasColumnType("numeric(, 15)");

                entity.Property(e => e.TodaySettlementPrice).HasColumnType("money");

                entity.Property(e => e.TradesValue).HasColumnType("money");

                entity.Property(e => e.ValHaghighiBuy)
                    .HasColumnName("Val_Haghighi_Buy")
                    .HasColumnType("money");

                entity.Property(e => e.ValHaghighiSell)
                    .HasColumnName("Val_Haghighi_Sell")
                    .HasColumnType("money");

                entity.Property(e => e.ValHoghooghiBuy)
                    .HasColumnName("Val_Hoghooghi_Buy")
                    .HasColumnType("money");

                entity.Property(e => e.ValHoghooghiSell)
                    .HasColumnName("Val_Hoghooghi_Sell")
                    .HasColumnType("money");

                entity.Property(e => e.VolHaghighiBuy).HasColumnName("Vol_Haghighi_Buy");

                entity.Property(e => e.VolHaghighiSell).HasColumnName("Vol_Haghighi_Sell");

                entity.Property(e => e.VolHoghooghiBuy).HasColumnName("Vol_Hoghooghi_Buy");

                entity.Property(e => e.VolHoghooghiSell).HasColumnName("Vol_Hoghooghi_Sell");
            });
        }
    }
}
