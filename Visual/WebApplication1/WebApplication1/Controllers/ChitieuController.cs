using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ChitieuController : Controller
    {
        private ChitieuEntities db = new ChitieuEntities();

        // GET: /Chitieu/
        public ActionResult Index()
        {
            var model = db.Expenditures.ToList();
            return View(model);
        }

        // GET: /Expenditure/Details/5
        public ActionResult Details(int? id)
        {
            var model = db.Expenditures.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        // GET: /Chitieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Chitieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Expenditure model)
        {
            ValidateExpenditure(model);
            if (ModelState.IsValid)
            {
                model.Ngày = DateTime.Today;
                db.Expenditures.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        private void ValidateExpenditure(Expenditure model)
        {
            if (model.SốTiền <= 0)
            {
                ModelState.AddModelError("Sốtiền", "Số tiền quá ít!");
            }

        }

        // GET: /Expenditure/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenditure quanlichitieu = db.Expenditures.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /Expenditure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ngày,Sốtiền,Ghichú")] Expenditure quanlichitieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanlichitieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quanlichitieu);
        }

        // GET: /Expenditure/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expenditure quanlichitieu = db.Expenditures.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /Expenditure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expenditure quanlichitieu = db.Expenditures.Find(id);
            db.Expenditures.Remove(quanlichitieu);
            db.SaveChanges();
            return RedirectToAction("Index");
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
