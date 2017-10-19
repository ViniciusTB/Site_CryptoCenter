using Domain_CryptoCenter.Domain;
using Infra_CryptoCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_CryptoCenter.Controllers
{
    public class ContaController : Controller
    {
        // GET: Conta
        public ActionResult Index()
        {
            using (CryptoCenterContext db = new CryptoCenterContext())
            {
                return View(db.Usuarios.ToList());
            }
        }

        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using(CryptoCenterContext db =  new CryptoCenterContext())
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = usuario.Nome + " registrado com sucesso!";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            using (CryptoCenterContext db = new CryptoCenterContext())
            {
                var usr = db.Usuarios.Where(u => u.Login == usuario.Login &&
                u.Senha == usuario.Senha).FirstOrDefault();
                if(usr != null)
                {
                    Session["Id"] = usr.UsuarioId.ToString();
                    Session["Nome"] = usr.Nome.ToString();
                    return RedirectToAction("Logado");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario ou senha invalidos!");
                }
            }
            return View();
        }

        public ActionResult Logado()
        {
            if(Session["Id"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}