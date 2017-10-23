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
    public class InvestimentoController : Controller
    {
        private CryptoCenterContext db = new CryptoCenterContext();

        // GET: Investimento
        public ActionResult Index()
        {
            return View(db.Investimento.ToList());
        }

        // GET: Investimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investimento investimento = db.Investimento.Find(id);
            if (investimento == null)
            {
                return HttpNotFound();
            }
            return View(investimento);
        }

        // GET: Investimento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Investimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvestimentoId,Descricao,QuantidadeDisponivel,Valor,QuantidadeVendida")] Investimento investimento)
        {
            if (ModelState.IsValid)
            {
                db.Investimento.Add(investimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(investimento);
        }

        // GET: Investimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investimento investimento = db.Investimento.Find(id);
            if (investimento == null)
            {
                return HttpNotFound();
            }
            return View(investimento);
        }

        // POST: Investimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvestimentoId,Descricao,QuantidadeDisponivel,Valor,QuantidadeVendida")] Investimento investimento)
        {
                if (ModelState.IsValid)
                {
                    db.Entry(investimento).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            return View(investimento);
        }

        // GET: Investimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Investimento investimento = db.Investimento.Find(id);
            if (investimento == null)
            {
                return HttpNotFound();
            }
            return View(investimento);
        }

        // POST: Investimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Investimento investimento = db.Investimento.Find(id);
            db.Investimento.Remove(investimento);
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
