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
    public class BidderController : Controller
    {
        private AuctionContext db = new AuctionContext();

        // GET: Bidder
        public ActionResult Index()
        {
            if (Request.IsAuthenticated) { 
                return View(db.Bidders.ToList());
            }
            else { 
                return RedirectToAction("AccessDenied");
            }
        }
        public ActionResult AccessDenied()
        {
            return View();
        }

        // GET: Bidder/Details/5
        public ActionResult Details(int? id)
        {
            if (Request.IsAuthenticated)
                {
                    if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bidder bidder = db.Bidders.Find(id);
                if (bidder == null)
                {
                    return HttpNotFound();
                }
            
                    return View(bidder);
            }
            else {
                return RedirectToAction("AccessDenied");
            }
        }

        // GET: Bidder/Create
        public ActionResult Create()
        {
            if (Request.IsAuthenticated) { 
                return View();
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        // POST: Bidder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BidderNum,Name,ContactInfo")] Bidder bidder)
        {
            if (ModelState.IsValid && Request.IsAuthenticated)
            {
                db.Bidders.Add(bidder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        // GET: Bidder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Request.IsAuthenticated)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Bidder bidder = db.Bidders.Find(id);
                if (bidder == null)
                {
                    return HttpNotFound();
                }
                return View(bidder);
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        // POST: Bidder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BidderNum,Name,ContactInfo")] Bidder bidder)
        {
            if (ModelState.IsValid && Request.IsAuthenticated)
            {
                db.Entry(bidder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        // GET: Bidder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Request.IsAuthenticated) { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
            }
            else
            {
                return RedirectToAction("AccessDenied");
            }
        }

        // POST: Bidder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Request.IsAuthenticated) { 
                Bidder bidder = db.Bidders.Find(id);
                db.Bidders.Remove(bidder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AccessDenied");
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
