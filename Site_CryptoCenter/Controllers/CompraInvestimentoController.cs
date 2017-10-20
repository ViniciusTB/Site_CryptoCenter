﻿using System;
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
    public class CompraInvestimentoController : Controller
    {
        private CryptoCenterContext db = new CryptoCenterContext();

        // GET: CompraInvestimento
        public ActionResult Index()
        {
            var compraInvestimento = db.CompraInvestimento.Include(c => c.Usuario);
            return View(compraInvestimento.ToList());
        }

        // GET: CompraInvestimento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraInvestimento compraInvestimento = db.CompraInvestimento.Find(id);
            if (compraInvestimento == null)
            {
                return HttpNotFound();
            }
            return View(compraInvestimento);
        }

        // GET: CompraInvestimento/Create
        public ActionResult Create()
        {
            //ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome");
            ViewBag.InvestimentoId = new SelectList(db.Investimento, "InvestimentoId", "Descricao");

            return View();
        }

        // POST: CompraInvestimento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompraInvestimentoId,DataCompra,Quantidade,UsuarioId,InvestimentoId")] CompraInvestimento compraInvestimento)
        {
            if (ModelState.IsValid)
            {
                if(Session["Id"] != null)
                {

                }
                compraInvestimento.DataCompra = DateTime.Now;
                db.CompraInvestimento.Add(compraInvestimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

           // ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", compraInvestimento.UsuarioId);
            ViewBag.InvestimentoId = new SelectList(db.Investimento, "InvestimentoId", "Descricao", compraInvestimento.InvestimentoId);
            return View(compraInvestimento);
        }

        // GET: CompraInvestimento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraInvestimento compraInvestimento = db.CompraInvestimento.Find(id);
            if (compraInvestimento == null)
            {
                return HttpNotFound();
            }
            ViewBag.InvestimentoId = new SelectList(db.Investimento, "InvestimentoId", "Descricao", compraInvestimento.InvestimentoId);
            //ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", compraInvestimento.UsuarioId);
            return View(compraInvestimento);
        }

        // POST: CompraInvestimento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompraInvestimentoId,DataCompra,Quantidade,UsuarioId,InvestimentoId")] CompraInvestimento compraInvestimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraInvestimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InvestimentoId = new SelectList(db.Investimento, "InvestimentoId", "Descricao", compraInvestimento.InvestimentoId);

            //ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Nome", compraInvestimento.UsuarioId);
            return View(compraInvestimento);
        }

        // GET: CompraInvestimento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraInvestimento compraInvestimento = db.CompraInvestimento.Find(id);
            if (compraInvestimento == null)
            {
                return HttpNotFound();
            }
            return View(compraInvestimento);
        }

        // POST: CompraInvestimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraInvestimento compraInvestimento = db.CompraInvestimento.Find(id);
            db.CompraInvestimento.Remove(compraInvestimento);
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