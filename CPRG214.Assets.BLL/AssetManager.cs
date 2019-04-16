using CPRG214.Assets.Data;
using CPRG214.Assets.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Assets.BLL {
    public class AssetManager {
        public static List<Asset> GetAllAssets() {
            var context = new AssetsContext();
            var AssetList = context.Assets.Include(a => a.AssetType).ToList(); // Join the AssetType table
            return AssetList;
        }

        public static Asset GetAssetByAssetId(int id) {
            var context = new AssetsContext();
            var asset = context.Assets.Include(a => a.AssetType).SingleOrDefault(a => a.Id == id);
            return asset;
        }

        public static List<Asset> GetAssetsByAssetType(int assetTypeId) {
            var context = new AssetsContext();
            var AssetList = context.Assets.Include(a => a.AssetType).Where(a => a.AssetTypeId == assetTypeId).ToList();
            return AssetList;
        }

        public static void UpdateAsset(Asset newAsset) {
            var context = new AssetsContext();
            // Find the domain entity with this context, that has the same Id as the entity pass in
            var oldAsset = context.Assets.SingleOrDefault(a => a.Id == newAsset.Id);
            // Assign properties from newAsset to properties in oldAsset
            oldAsset.TagNumber = newAsset.TagNumber;
            oldAsset.AssetTypeId = newAsset.AssetTypeId;
            oldAsset.Manufacturer = newAsset.Manufacturer;
            oldAsset.Model = newAsset.Model;
            oldAsset.Description = newAsset.Description;
            oldAsset.SerialNumber = newAsset.SerialNumber;

            context.SaveChanges();
        }

        public static void AddAsset(Asset asset) {
            var context = new AssetsContext();
            context.Assets.Add(asset);

            context.SaveChanges();
        }
    }
}
