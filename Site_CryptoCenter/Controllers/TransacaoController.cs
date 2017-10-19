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
    public class TransacaoController : Controller
    {
        private CryptoCenterContext db = new CryptoCenterContext();

        // GET: Transacao
        public ActionResult Index()
        {
            var transacao = db.Transacao.Include(t => t.Moeda).Include(t => t.Usuario);
            return View(transacao.ToList());
        }

        // GET: Transacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // GET: Transacao/Create
        public ActionResult Create()
        {
            ViewBag.MoedaId = new SelectList(db.Moeda, "MoedaId", "Nome");
            return View();
        }

        // POST: Transacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TransacaoId,MoedaId,Quantidade")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                transacao.DataTransacao = DateTime.Now;
                transacao.UsuarioId = int.Parse(Session["Id"].ToString());
                db.Transacao.Add(transacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MoedaId = new SelectList(db.Moeda, "MoedaId", "Nome", transacao.MoedaId);
            return View(transacao);
        }

        // GET: Transacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.MoedaId = new SelectList(db.Moeda, "MoedaId", "Nome", transacao.MoedaId);
            return View(transacao);
        }

        // POST: Transacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TransacaoId,MoedaId,Quantidade")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                transacao.DataTransacao = DateTime.Now;
                transacao.UsuarioId = int.Parse(Session["Id"].ToString());
                db.Entry(transacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MoedaId = new SelectList(db.Moeda, "MoedaId", "Nome", transacao.MoedaId);
            return View(transacao);
        }

        // GET: Transacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacao.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacao transacao = db.Transacao.Find(id);
            db.Transacao.Remove(transacao);
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
