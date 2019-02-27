using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoAuctrack.DAL;
using DemoAuctrack.Models;

namespace DemoAuctrack.Controllers
{
    public class ItemController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: Item
        public ActionResult Index(string sortOrder, string currentFilter, string searchString)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = sortOrder == "Name" ? "name_desc" : "Name";
            ViewBag.ValueSortParm = sortOrder == "Value" ? "value_desc" : "Value";
            ViewBag.BidSortParm = sortOrder == "Bid" ? "bid_desc" : "Bid";
            ViewBag.IDSortParm = sortOrder == "Id" ? "id_desc" : "Id";

            //First filter the results from the database
            if (searchString == null)
            {
                searchString = currentFilter;
            }

            // See if there's any sort order.
            if (sortOrder != null)
            {
                sortOrder = sortOrder.ToLower();
            }

            IQueryable<Item> items;
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                switch (sortOrder)
                {
                    case "name_desc":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderByDescending(u => u.ItemName).ThenBy(u => u.Description)
                                select s;
                        break;
                    case "name":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderBy(u => u.ItemName).ThenBy(u => u.Description)
                                select s;
                        break;
                    case "value_desc":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderByDescending(u => u.Value)
                                select s;
                        break;
                    case "value":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderBy(u => u.Value)
                                select s;
                        break;
                    case "bid_desc":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderByDescending(u => u.Current)
                                select s;
                        break;
                    case "bid":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderBy(u => u.Current)
                                select s;
                        break;
                    case "id_desc":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderByDescending(u => u.Current)
                                select s;
                        break;
                    case "id":
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderBy(u => u.ItemID)
                                select s;
                        break;
                    default:
                        items = from s in db.Items.Where(u => u.ItemName.ToLower().Contains(searchString))
                                .OrderBy(u => u.ItemID)
                                select s;
                        break;
                }
            }
            else
            {
                switch (sortOrder)
                {
                    case "name_desc":
                        items = from s in db.Items
                                .OrderByDescending(u => u.ItemName).ThenBy(u => u.Description)
                                select s;
                        break;
                    case "name":
                        items = from s in db.Items
                                .OrderBy(u => u.ItemName).ThenBy(u => u.Description)
                                select s;
                        break;
                    case "value_desc":
                        items = from s in db.Items
                                .OrderByDescending(u => u.Value)
                                select s;
                        break;
                    case "value":
                        items = from s in db.Items
                                .OrderBy(u => u.Value)
                                select s;
                        break;
                    case "bid_desc":
                        items = from s in db.Items
                                .OrderByDescending(u => u.Current)
                                select s;
                        break;
                    case "bid":
                        items = from s in db.Items
                                .OrderByDescending(u => u.Current)
                                select s;
                        break;
                    case "id_desc":
                        items = from s in db.Items
                                .OrderByDescending(u => u.ItemID)
                                select s;
                        break;
                    case "id":
                        items = from s in db.Items
                                .OrderBy(u => u.ItemID)
                                select s;
                        break;
                        //
                    default:
                        items = from s in db.Items
                                .OrderBy(u => u.ItemID)
                                select s;
                        break;
                }
            }

            ViewBag.CurrentFilter = searchString;
            return View(items);
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = db.Items.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,Description,Value,Current,Winner,Donator,TimeFrame")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated) { 
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("NiceTryBuddy");
                }
            }
            else
            {
                return RedirectToAction("NiceTryBuddy");
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Item item = db.Items.Find(id);
                if (item == null)
                {
                    return HttpNotFound();
                }
                if (Request.IsAuthenticated)
                {
                    return View(item);
                }
                return View();
            }
            else
            {
                return RedirectToAction("NiceTryBuddy");
            }
        }
        public ActionResult NiceTryBuddy(int? id)
        {
            if (!Request.IsAuthenticated) { 
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,Description,Value,Current,Winner,Donator,TimeFrame")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (Request.IsAuthenticated)
                {
                    db.Entry(item).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("NiceTryBuddy");
                }
            }
            else
            {
                return RedirectToAction("NiceTryBuddy");
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Request.IsAuthenticated) { 
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("NiceTryBuddy");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
