using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Assets.App.Models;
using CPRG214.Assets.BLL;
using CPRG214.Assets.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CPRG214.Assets.App.Controllers
{
    public class AssetsController : Controller
    {
        // GET: Assets
        public ActionResult Index()
        {
            var Assets = AssetManager.GetAllAssets().
                Select(a => new AssetsViewModel {
                    Id = a.Id,
                    AssetTypes = a.AssetType.Name,
                    Description = a.Description,
                    Manufacturer = a.Manufacturer,
                    Model = a.Model,
                    SerialNumber = a.SerialNumber,
                    TagNumber = a.TagNumber
                });
            // Populate Drop Down list with selection of AssetTypes 
            var AssetTypes = AssetTypeManager.GetAsKeyValuePairs();
            ViewBag.AssetTypes = new SelectList(AssetTypes, "Id", "Name");
            return View(Assets);
        }

        // GET: Assets/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Assets/Create
        public ActionResult Create()
        {
            // Populate dropdown boxes for asset type
            var AssetTypes = AssetTypeManager.GetAsKeyValuePairs();
            ViewBag.AssetTypes = new SelectList(AssetTypes, "Id", "Name");
            return View();
        }

        // POST: Assets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Asset asset) 
        {
            try
            {
                // Add new asset into database
                AssetManager.AddAsset(asset);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Assets/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Assets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Assets/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Assets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult GetAssetsByAssetType (int id) {
            return ViewComponent("AssetsByAssetType", id);
        }
    }
}