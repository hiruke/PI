using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DesfacaFacil.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //IEnumerable<DesfacaFacil.Models.Anuncio> modelo =    
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Login, string Senha)
        {
            using (Models.Entidades ctx = new Models.Entidades())
            {
                var usr = ctx.USUARIOS.Where(x => x.EMAIL == Login && x.SENHA == Senha).Single();
                //var usr = ctx.USUARIOS.Single(x => x.EMAIL == Login && x.SENHA == Senha);
                if (usr != null)
                {
                    Session["IdUsuario"] = usr.USID;
                    Session["Email"] = usr.EMAIL;
                    return RedirectToAction("PainelUsuario", new { id = usr.USID });
                }
                else
                {
                    ViewBag.Erro("Usuario ou senha invalidos");
                    return View();
                }
            }
        }

        public ActionResult PainelUsuario(int id)
        {
            Models.Entidades c = new Models.Entidades();
            IEnumerable<Models.USUARIO> user = c.USUARIOS.Where(x => x.USID == id);
            return View(user);
        }
    }

}