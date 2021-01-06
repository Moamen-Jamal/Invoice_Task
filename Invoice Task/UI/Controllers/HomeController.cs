using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoreService storeService;
        private readonly UnitService unitService;
        private readonly ItemService itemService;
        private readonly ItemUnitService itemUnitService;
        private readonly InvoiceService invoiceService;
        private readonly InvoiceItemUnitService invoiceItemUnitService;
        public HomeController(StoreService _storeService, UnitService _unitService,
            ItemService _itemService, ItemUnitService _itemUnitService,
            InvoiceService _invoiceService, InvoiceItemUnitService _invoiceItemUnitService)
        {
            storeService = _storeService;
            unitService = _unitService;
            itemService = _itemService;
            itemUnitService = _itemUnitService;
            invoiceService = _invoiceService;
            invoiceItemUnitService = _invoiceItemUnitService;
        }

        [HttpGet]
        public IActionResult Index() 
        {
            var Stores = storeService.GetList();
            ViewBag.Store = Stores;

            return View(Stores);
        }
        [HttpGet]
        public JsonResult GetItemList(int StoreId)
        {
            //var itemlist = itemService.GetList().Where(c => c.StoreID == StoreId);
            //ViewBag.Items = itemlist;
            var itemlist = new SelectList(itemService.GetList().Where(c => c.StoreID == StoreId), "ID", "Name");
            return Json(itemlist);

        }
        [HttpGet]
        public JsonResult GetUnitList(int ItemId)
        {
            var unitlist = new SelectList(unitService.GetList().Where(c => c.ItemUnit.Where(i => i.UnitID == c.ID).Select(a => a.ItemID).FirstOrDefault() == ItemId), "Id", "UnitName");
            return Json(unitlist);

        }
    }
}
