using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPRG214.Assets.BLL;
using CPRG214.Assets.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPRG214.Assets.App.Controllers
{
    public class AssetTypesController : Controller
    {
        // GET: AssetTypes
        public ActionResult Index()
        {
            var AssetTypeList = AssetTypeManager.GetAllAssetTypes();
            return View(AssetTypeList);
        }

        // GET: AssetTypes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetType assetType)
        {
            try
            {
                AssetTypeManager.AddAssetType(assetType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypes/Edit/5
        public ActionResult Edit(int id)
        {
            var assetType = AssetTypeManager.GetAssetTypeById(id);
            return View(assetType);
        }

        // POST: AssetTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetType assetType)
        {
            try
            {
                AssetTypeManager.UpdateAssetType(assetType);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AssetTypes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetTypes/Delete/5
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
    }
}