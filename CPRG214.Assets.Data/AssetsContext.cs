using CPRG214.Assets.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace CPRG214.Assets.Data {
    public class AssetsContext : DbContext{
        // Inherits base constructor
        public AssetsContext() : base() { }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            //Change the connection string here for your home computer/lab computer
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;
                                          Database=Assets;
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //seed data created here
            modelBuilder.Entity<AssetType>().HasData(
                new AssetType { Id = 1, Name = "Computer"  },
                new AssetType { Id = 2, Name = "Monitors" },
                new AssetType { Id = 3, Name = "Phone" }
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = 1, TagNumber = "A100", AssetTypeId = 1, Manufacturer = "Dell", Model = null, SerialNumber = "xbi-2938-1029", Description = "Out of Stock"  },
                new Asset { Id = 2, TagNumber = "A101", AssetTypeId = 2, Manufacturer = "LG", Model = "UltraSharp", SerialNumber = "nlw-8439-4839", Description = "On Sale"},
                new Asset { Id = 3, TagNumber = "A103", AssetTypeId = 2, Manufacturer = "Acer", Model = "V256HQL", SerialNumber = "ixn-4938-2785", Description = "On Sale" },
                new Asset { Id = 4, TagNumber = "A132", AssetTypeId = 1, Manufacturer = "Acer", Model = "Aspire E 17", SerialNumber = "bnx-4823-9857", Description = "Shipped" },
                new Asset { Id = 5, TagNumber = "A423", AssetTypeId = 3, Manufacturer = "Cisco", Model = "CP-7841-K9", SerialNumber = "osn-3928-9201", Description = "Refurbished" },
                new Asset { Id = 6, TagNumber = "A435", AssetTypeId = 1, Manufacturer = "HP", Model = "Pavillion", SerialNumber = "aie-1235-4987", Description = "Order Paid"}
            );
        }
    }
}
