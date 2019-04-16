using CPRG214.Assets.App.Models;
using CPRG214.Assets.BLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CPRG214.Assets.App.ViewComponents {
    public class AssetsByAssetTypeViewComponent : ViewComponent {
        public async Task<IViewComponentResult> InvokeAsync (int id) {
            // Get the model asynchronously and pass to the view (viewModel)
            if (id == -1) {
                var AllAssets = AssetManager.GetAllAssets().
                Select(a => new AssetsViewModel {
                    Id = a.Id,
                    AssetTypes = a.AssetType.Name,
                    Description = a.Description,
                    Manufacturer = a.Manufacturer,
                    Model = a.Model,
                    SerialNumber = a.SerialNumber,
                    TagNumber = a.TagNumber
                });

                return View(AllAssets);
            } else {
                var AssetsByAssetType = AssetManager.GetAssetsByAssetType(id).
                    Select(a => new AssetsViewModel {
                        Id = a.Id,
                        AssetTypes = a.AssetType.Name,
                        Description = a.Description,
                        Manufacturer = a.Manufacturer,
                        Model = a.Model,
                        SerialNumber = a.SerialNumber,
                        TagNumber = a.TagNumber
                    });
                return View(AssetsByAssetType);
            }
        }
    }
}
