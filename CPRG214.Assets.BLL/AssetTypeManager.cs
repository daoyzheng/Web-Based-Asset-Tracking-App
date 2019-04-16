using CPRG214.Assets.Data;
using CPRG214.Assets.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CPRG214.Assets.BLL {
    public class AssetTypeManager {
        public static List<AssetType> GetAllAssetTypes() {
            var context = new AssetsContext();
            var assetTypeList = context.AssetTypes.ToList();
            return assetTypeList;
        }
        public static AssetType GetAssetTypeById(int id) {
            var context = new AssetsContext();
            var assetType = context.AssetTypes.Find(id);
            return assetType;
        }

        public static IList GetAsKeyValuePairs() {
            var context = new AssetsContext();
            var types = context.AssetTypes.Select(a => new {
                a.Id,
                a.Name
            }).ToList();
            return types;
        }

        public static void UpdateAssetType(AssetType newAssetType) {
            var context = new AssetsContext();
            var assetType = context.AssetTypes.SingleOrDefault(a => a.Id == newAssetType.Id);
            assetType.Name = newAssetType.Name;

            context.SaveChanges();
        }

        public static void AddAssetType(AssetType assetType) {
            var context = new AssetsContext();
            context.AssetTypes.Add(assetType);

            context.SaveChanges();
        }
    }
}
