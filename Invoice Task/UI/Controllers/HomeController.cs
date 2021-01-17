using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Services;
using UI.Models;
using ViewModels;
using Microsoft.AspNetCore.Session;
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
        public HomeController( StoreService _storeService, UnitService _unitService,
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

        InvoiceEditViewModel invoice = new InvoiceEditViewModel();
        
        public static List<InvoiceItemUnitEditViewModel> list = new List<InvoiceItemUnitEditViewModel>();
        public static List<Cart> cartli = new List<Cart>();
        public static IEnumerable<ItemViewModel> ItemList = new List<ItemViewModel>();
        public static IEnumerable<StoreViewModel> StoreList = new List<StoreViewModel>();
        public static IEnumerable<UnitViewModel> UnitList = new List<UnitViewModel>();

        [HttpGet]
        public IActionResult Index() 
        {
            
            TempData["Cart"] = JsonConvert.SerializeObject(li);
            ViewData["Cart"] = JsonConvert.DeserializeObject<List<Cart>>(TempData["Cart"].ToString());
            ViewBag.Total = invoice.Total;
            ViewBag.Net = invoice.Net;
            if (TempData["SelectStoreChanged"] == null ) 
            {
                //When the program starts and there is no any change in all dropdownlists

                if (HttpContext.Session.GetInt32("SelectUntID") == null && HttpContext.Session.GetInt32("SelectItemID") == null)
                {
                    HttpContext.Session.SetString("SelectStoreChanged", "yes");
                    TempData["SelectStoreID"] = 1;
                    TempData["SelectItemID"] = 1;
                    TempData["SelectUnitID"] = 1;
                    var Stores = storeService.GetList();
                    StoreList = Stores;
                    
                    var Items = itemService.GetList().Where(i => i.StoreID == 1);
                    ItemList = Items;
                    var ItemName = itemService.GetList().Where(i => i.ID == 1).Select(x => x.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);
                    
     
                    var Units = unitService.GetList();
                    UnitList = Units;
                    var UnitName = unitService.GetList().Where(i => i.ID == 1).Select(x => x.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    decimal price = itemUnitService.GetList().Where(i => i.ItemID == 1 && i.UnitID == 1).Select(x => x.Price).FirstOrDefault();
                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    var ItemUnitID = itemUnitService.GetList().Where(i => i.ItemID == 1 && i.UnitID == 1).Select(x => x.ID).FirstOrDefault();
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);

                    
                    ViewBag.ItemUnitID = ItemUnitID;
                    ViewBag.Store = Stores;
                    ViewBag.Item = Items;
                    ViewBag.Unit = Units;
                    
                    return View();
                }

                //When the program starts and make changing in Unit dropdownlist only and there is no change in other dropdownlists
              
                else if (HttpContext.Session.GetInt32("SelectUntID") != null && HttpContext.Session.GetInt32("SelectItemID") == null)
                {
                    TempData["SelectStoreID"] = 1;
                    TempData["SelectItemID"] = 1;


                    var Stores = storeService.GetList();
                    StoreList = Stores;
                    var Items = itemService.GetList().Where(i => i.StoreID == 1);
                    ItemList = Items;
                    var ItemName = itemService.GetList().Where(i => i.ID == 1).Select(x => x.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);

                    var Units = unitService.GetList();
                    UnitList = Units;
                    var SelectUnitID = HttpContext.Session.GetInt32("SelectUntID");
                    var UnitName = unitService.GetList().Where(i => i.ID == SelectUnitID).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    decimal price = itemUnitService.GetList().Where(i => i.ItemID == 1 && i.UnitID == SelectUnitID).Select(x => x.Price).FirstOrDefault();
                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    var ItemUnitID = itemUnitService.GetList().Where(i => i.ItemID == 1 && i.UnitID == SelectUnitID).Select(x => x.ID).FirstOrDefault();
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);
                    
                    ViewBag.ItemUnitID = ItemUnitID;
                    ViewBag.Store = Stores;
                    ViewBag.Item = Items;
                    ViewBag.Unit = Units;
                    
                    return View();
                }

                //When the program starts and make changing in Unit and Item dropdownlist and there is no change in Store dropdownlist

                else
                {
                    TempData["SelectStoreID"] = 1;
                    


                    var Stores = storeService.GetList();
                    StoreList = Stores;
                    var Items = itemService.GetList().Where(i => i.StoreID == 1);
                    ItemList = Items;
                    
                    var Units = unitService.GetList();
                    UnitList = Units;
                    var SelectUnitID = HttpContext.Session.GetInt32("SelectUntID");
                    var SelectItemID = HttpContext.Session.GetInt32("SelectItemID");
                    var ItemName = itemService.GetList().Where(i => i.ID == SelectItemID).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);
                    var UnitName = unitService.GetList().Where(i => i.ID == SelectUnitID).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    decimal price = itemUnitService.GetList().Where(i => i.ItemID == SelectItemID && i.UnitID == SelectUnitID).Select(x => x.Price).FirstOrDefault();
                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    var ItemUnitID = itemUnitService.GetList().Where(i => i.ItemID == SelectItemID && i.UnitID == SelectUnitID).Select(x => x.ID).FirstOrDefault();
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);
                    
                    ViewBag.ItemUnitID = ItemUnitID;
                    ViewBag.Store = Stores;
                    ViewBag.Item = Items;
                    ViewBag.Unit = Units;
                    
                    return View();
                }

            }

            //When the program starts and make changing in all dropdownlists

            else
            {
                //When the program starts and make changing in store dropdownlist only

                if (HttpContext.Session.GetInt32("SelectStoreID") !=null && HttpContext.Session.GetInt32("SelectItemID") == null)
                {
                    
                    
                    
                    var stores = storeService.GetList();
                    StoreList = stores;
                    var selectStoreID = HttpContext.Session.GetInt32("SelectStoreID");
                    var items = itemService.GetList().Where(i => i.StoreID == selectStoreID);
                    ItemList = items;
                    TempData["SelectItemID"] = HttpContext.Session.GetInt32("GetItemID");
                    var ItemName = itemService.GetList().Where(i => i.StoreID == selectStoreID).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);
                    var units = unitService.GetList();
                    UnitList = units;
                    var UnitName = unitService.GetList().Where(i => i.ID == 1).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    ViewBag.Store = stores;
                    ViewBag.Item = items;
                    ViewBag.Unit = units;
                    decimal price = 0;
                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    var ItemUnitID = 1;
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);
                    
                    ViewBag.ItemUnitID = ItemUnitID;
                    
                    return View();
                }

                //When the program starts and make changing in store and Item dropdownlists

                else if (HttpContext.Session.GetInt32("SelectItemID") != null && HttpContext.Session.GetInt32("SelectUntID") == 1)
                {
                    //TempData["SelectItemID"] = HttpContext.Session.GetInt32("SelectItemID");
                    
                    var stores = storeService.GetList();
                    StoreList = stores;
                    var selectStoreID = HttpContext.Session.GetInt32("SelectStoreID");
                    var items = itemService.GetList().Where(i => i.StoreID == selectStoreID);
                    ItemList = items;
                    var SelectedItemID = HttpContext.Session.GetInt32("SelectItemID");
                    var ItemName = itemService.GetList().Where(i => i.ID == SelectedItemID)
                        .Select(w => w.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);
                    var units = unitService.GetList();
                    UnitList = units;
                    var UnitName = unitService.GetList().Where(i => i.ID == 1).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    ViewBag.Store = stores;
                    ViewBag.Item = items;
                    ViewBag.Unit = units;
                    var  SelectUnitID = HttpContext.Session.GetInt32("SelectUntID");
                    decimal price = itemUnitService.GetList().Where(i => i.ItemID == HttpContext.Session.GetInt32("SelectItemID")
                    && i.UnitID == SelectUnitID)
                        .Select(x => x.Price).FirstOrDefault();

                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    
                    var ItemUnitID = itemUnitService.GetList().Where(i => i.ItemID == HttpContext.Session.GetInt32("SelectItemID")
                    && i.UnitID == SelectUnitID)
                        .Select(x => x.ID).FirstOrDefault();
                    ViewBag.ItemUnitID = ItemUnitID;
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);
                    
                    return View();

                }

                //When the program starts and make changing in all dropdownlists

                else if (HttpContext.Session.GetInt32("SelectStoreID") != null && HttpContext.Session.GetInt32("SelectItemID") != null && HttpContext.Session.GetInt32("SelectUntID") != null)
                {
                    var SelectedItemID = HttpContext.Session.GetInt32("SelectItemID");
                    var selectStoreID = HttpContext.Session.GetInt32("SelectStoreID");
                    var SelectUnitID = HttpContext.Session.GetInt32("SelectUntID");
                    var Stores = storeService.GetList();
                    StoreList = Stores;
                    var Items = itemService.GetList().Where(i => i.StoreID == selectStoreID);
                    ItemList = Items;
                    var ItemName = itemService.GetList().Where(i => i.ID == SelectedItemID)
                        .Select(w => w.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);
                    var Units = unitService.GetList();
                    UnitList = Units;
                    var UnitName = unitService.GetList().Where(i => i.ID == SelectUnitID).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    decimal price = itemUnitService.GetList().Where(i => i.ItemID == SelectedItemID
                    && i.UnitID == SelectUnitID)
                        .Select(x => x.Price).FirstOrDefault();

                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    var ItemUnitID = itemUnitService.GetList().Where(i => i.ItemID == SelectedItemID
                    && i.UnitID == SelectUnitID)
                        .Select(x => x.ID).FirstOrDefault();
                    ViewBag.Store = Stores;
                    ViewBag.Item = Items;
                    ViewBag.Unit = Units;
                    
                    ViewBag.ItemUnitID = ItemUnitID;
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);
                    
                    return View();
                }
                else
                {
                    var SelectedItemID = HttpContext.Session.GetInt32("SelectItemID");
                    var SelectUnitID = HttpContext.Session.GetInt32("SelectUntID");
                    var Stores = storeService.GetList();
                    StoreList = Stores;
                    TempData["SelectStoreID"] = 1;
                    var Items = itemService.GetList().Where(i => i.StoreID == 1);
                    ItemList = Items;
                    var ItemName = itemService.GetList().Where(i => i.ID == SelectedItemID)
                        .Select(w => w.Name).FirstOrDefault();
                    HttpContext.Session.SetString("ItemName", ItemName);
                    var Units = unitService.GetList();
                    UnitList = Units;
                    var UnitName = unitService.GetList().Where(i => i.ID == SelectUnitID).Select(a => a.Name).FirstOrDefault();
                    HttpContext.Session.SetString("UnitName", UnitName);
                    decimal price = itemUnitService.GetList().Where(i => i.ItemID == SelectedItemID && i.UnitID == SelectUnitID)
                        .Select(x => x.Price).FirstOrDefault();

                    HttpContext.Session.SetString("Price", JsonConvert.SerializeObject(price));
                    ViewBag.Store = Stores;
                    ViewBag.Item = Items;
                    ViewBag.Unit = Units;
                    
                    var ItemUnitID = itemUnitService.GetList().Where(i => i.ItemID == SelectedItemID && i.UnitID == SelectUnitID)
                        .Select(x => x.ID).FirstOrDefault();
                    ViewBag.ItemUnitID = ItemUnitID;
                    HttpContext.Session.SetInt32("ItemUnitID", ItemUnitID);
                    
                    return View();
                }
                
            }
           

        }

        //Cascading Item dropdownlist on store dropdownlist

        [HttpGet]
        public IActionResult GetItemList(int selectedId)
        {
            //When the program starts and there is no any change in all dropdownlists

            if (HttpContext.Session.GetString("SelectStoreChanged") == null)
            {
                var Items = itemService.GetList().Where(i => i.StoreID == selectedId);
                TempData["SelectStoreID"] = 1;
                TempData["SelectStoreChanged"] = "yes";
                HttpContext.Session.SetString("SelectStoreChanged", "yes");
                HttpContext.Session.SetInt32("SelectStoreID", 1);
                HttpContext.Session.SetInt32("GetItemID", 1);
                HttpContext.Session.SetInt32("SelectUntID", 1);
                return RedirectToAction("Index", "Home");
            }

            //When the program starts and make changing in store dropdownlist and Cascading Item on Store dropdownlist

            else
            {
                var Items = itemService.GetList().Where(i => i.StoreID == selectedId);
                TempData["SelectStoreID"] = selectedId;
                TempData["SelectStoreChanged"] = "yes";
                HttpContext.Session.SetString("SelectStoreChanged", "yes");
                HttpContext.Session.SetInt32("SelectStoreID", selectedId);
                HttpContext.Session.SetInt32("SelectItemID", 1);
                HttpContext.Session.SetInt32("SelectUntID", 1);
                return RedirectToAction("Index", "Home");
            }
        }   

        //Get Units of the Items
        [HttpGet]
        public IActionResult GetUnitList(int ItemId)
        {

            if (HttpContext.Session.GetString("SelectStoreChanged") == null)
            {
                
                TempData["SelectItemID"] = 1;
                HttpContext.Session.SetInt32("SelectItemID", 1);
                TempData["SelectStoreID"] = 1;
                TempData["SelectUnitID"] = 1;
                HttpContext.Session.SetInt32("SelectUntID", 1);
                TempData["SelectStoreChanged"] = "yes";
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //When the program starts and there is no any change in all dropdownlists

                if (HttpContext.Session.GetInt32("SelectStoreID") == null)
                {
                    TempData["SelectItemID"] = ItemId;
                    HttpContext.Session.SetInt32("SelectItemID", ItemId);
                    TempData["SelectStoreID"] = 1;
                    TempData["SelectUnitID"] = 1;
                    HttpContext.Session.SetInt32("SelectUntID",1);

                    return RedirectToAction("Index", "Home");
                }

                //When the program starts and make changing in store dropdownlist

                else
                {
                    TempData["SelectItemID"] = ItemId;

                    HttpContext.Session.SetInt32("SelectItemID", ItemId);
                    TempData["SelectStoreID"] = HttpContext.Session.GetInt32("SelectStoreID");
                   
                    TempData["SelectUnitID"] = 1;
                    TempData["SelectStoreChanged"] = "yes";
                    HttpContext.Session.SetInt32("SelectUntID", 1);

                    return RedirectToAction("Index", "Home");
                }
                
            }
                

        }


        //Get Price of all Items
        [HttpGet]
        public IActionResult GetPrice(int UnitId)
        {
            if(HttpContext.Session.GetString("SelectStoreChanged")  == null) 
            {
                TempData["SelectItemID"] = HttpContext.Session.GetInt32("SelectItemID");
                TempData["SelectStoreID"] = HttpContext.Session.GetInt32("SelectStoreID");
                HttpContext.Session.SetInt32("SelectUntID", UnitId);
                TempData["SelectUnitID"] = HttpContext.Session.GetInt32("SelectUntID");
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //When the program starts and there is no any change in all dropdownlists

                if (HttpContext.Session.GetInt32("SelectItemID") == null)
                {
                    
                    
                    TempData["SelectStoreID"] = HttpContext.Session.GetInt32("SelectStoreID");
                    HttpContext.Session.SetInt32("SelectUntID", UnitId);
                    TempData["SelectUnitID"] = HttpContext.Session.GetInt32("SelectUntID");
                   
                    return RedirectToAction("Index", "Home");
                }

                //When the program starts and make changing in store  or Item dropdownlists

                else
                {
                    TempData["SelectStoreChanged"] = "yes";
                    TempData["SelectItemID"] = HttpContext.Session.GetInt32("SelectItemID");
                    TempData["SelectStoreID"] = HttpContext.Session.GetInt32("SelectStoreID");
                    HttpContext.Session.SetInt32("SelectUntID", UnitId);
                    TempData["SelectUnitID"] = HttpContext.Session.GetInt32("SelectUntID");
                    
                    return RedirectToAction("Index", "Home");
                }
                    
            }

        }
       
        public static List<Cart> li = new List<Cart>();
        
        [HttpGet]
        public IActionResult Cart(int id) 
        {
            if (HttpContext.Session.GetString("InvoiceDone") != null)
            {
                HttpContext.Session.Remove("InvoiceDone");
                li.Clear();
                HttpContext.Session.Remove("InvoiceTotal");
                HttpContext.Session.Remove("InvoiceTaxes");
                HttpContext.Session.Remove("InvoiceNet");
                return RedirectToAction("Index", "Home");
            }

            invoice.Total = 0;
            invoice.Taxes = 5;
            
            var cart = li.FirstOrDefault(i => i.ID == HttpContext.Session.GetInt32("ItemUnitID"));

            if (cart == null)
            {
                Cart c = new Cart();
                c.ID = HttpContext.Session.GetInt32("ItemUnitID");
                c.ItemName = HttpContext.Session.GetString("ItemName"); 
                c.UnitName = HttpContext.Session.GetString("UnitName"); 
                c.Price = decimal.Parse(HttpContext.Session.GetString("Price"));
                c.Quantity = 1;
                c.TotalPrice = c.Quantity * c.Price;
                c.Discount = 10;
                c.Net = c.TotalPrice - c.Discount;
                li.Add(c);
            }

            else
            {
                cart.ID = HttpContext.Session.GetInt32("ItemUnitID");
                cart.ItemName = HttpContext.Session.GetString("ItemName");
                cart.UnitName = HttpContext.Session.GetString("UnitName");
                cart.Price = decimal.Parse(HttpContext.Session.GetString("Price"));
                cart.Quantity = cart.Quantity + 1;
                cart.TotalPrice = cart.Quantity * cart.Price;
                cart.Discount = 10;
                cart.Net = cart.TotalPrice - cart.Discount;
            }
            foreach (var i in li)
            {
                invoice.Total += i.Net;
                
            }
            invoice.Net = invoice.Total - invoice.Taxes;
            HttpContext.Session.SetString("InvoiceTotal", JsonConvert.SerializeObject(invoice.Total));
            HttpContext.Session.SetString("InvoiceTaxes", JsonConvert.SerializeObject(invoice.Taxes));
            HttpContext.Session.SetString("InvoiceNet", JsonConvert.SerializeObject(invoice.Net));
            
            ViewBag.Store = StoreList;
            ViewBag.Item = ItemList;
            ViewBag.Unit = UnitList;
            ViewBag.Price = 20;
            
            TempData["Cart"] = JsonConvert.SerializeObject(li);
            ViewData["Cart"] = JsonConvert.DeserializeObject<List<Cart>>(TempData["Cart"].ToString());
            TempData["SelectItemID"] = HttpContext.Session.GetInt32("SelectItemID");
            TempData["SelectStoreID"] = HttpContext.Session.GetInt32("SelectStoreID");
            TempData["SelectUnitID"] = HttpContext.Session.GetInt32("SelectUntID");
            
            return View("Index");
        }

        [HttpPost]
        public ActionResult Save(InvoiceEditViewModel _invoice)
        {
            if (li.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            invoice.ID = 0;
            invoice.Total = decimal.Parse(HttpContext.Session.GetString("InvoiceTotal"));
            invoice.Taxes = decimal.Parse(HttpContext.Session.GetString("InvoiceTaxes"));
            invoice.Net = decimal.Parse(HttpContext.Session.GetString("InvoiceNet"));
            invoice.Date = DateTime.Now;
            foreach (var i in li)
            {
                InvoiceItemUnitEditViewModel invoiceItemUnit = new InvoiceItemUnitEditViewModel();
                invoiceItemUnit.ID = 0;
                invoiceItemUnit.InvoiceID = invoice.ID;
                invoiceItemUnit.ItemUnitID = i.ID;
                invoiceItemUnit.Quantity = i.Quantity;
                invoiceItemUnit.TotalPrice = i.TotalPrice;
                invoiceItemUnit.NetPrice = i.Net;
                invoiceItemUnit.Discount = i.Discount;
                list.Add(invoiceItemUnit);
            }

            invoice.InvoiceItemUnit = list;
            cartli = li;
            
            TempData["Cartli"] = JsonConvert.SerializeObject(cartli);
            ViewData["Cartli"] = JsonConvert.DeserializeObject<List<Cart>>(TempData["Cartli"].ToString());
            InvoiceEditViewModel Invoice = invoiceService.Add(invoice);
            HttpContext.Session.SetString("InvoiceDone", "Yes");
            return View(Invoice);
        }
        [HttpGet]
        public IActionResult Clear()
        {
            li.Clear();
            HttpContext.Session.SetString("InvoiceTotal", JsonConvert.SerializeObject(0));
            HttpContext.Session.SetString("InvoiceTaxes", JsonConvert.SerializeObject(0));
            HttpContext.Session.SetString("InvoiceNet", JsonConvert.SerializeObject(0));
            return RedirectToAction("Index", "Home");
        }
    }
}
