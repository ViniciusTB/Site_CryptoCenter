using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain_CryptoCenter.Domain;
using Infra_CryptoCenter;

namespace Site_CryptoCenter.Controllers
{
    public class MoedaController : Controller
    {
        private CryptoCenterContext db = new CryptoCenterContext();

        // GET: Moeda
        public ActionResult Index()
        {
            return View(db.Moeda.ToList());
        }

        // GET: Moeda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moeda.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // GET: Moeda/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Moeda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MoedaId,Nome,Apelido,Preco,Saldo")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                db.Moeda.Add(moeda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(moeda);
        }

        // GET: Moeda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moeda.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // POST: Moeda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MoedaId,Nome,Apelido,Preco,Saldo")] Moeda moeda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moeda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moeda);
        }

        // GET: Moeda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Moeda moeda = db.Moeda.Find(id);
            if (moeda == null)
            {
                return HttpNotFound();
            }
            return View(moeda);
        }

        // POST: Moeda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Moeda moeda = db.Moeda.Find(id);
            db.Moeda.Remove(moeda);
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
