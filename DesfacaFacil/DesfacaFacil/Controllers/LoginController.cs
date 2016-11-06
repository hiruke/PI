using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Diagnostics;
using DAL;

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
            IDBController dbcontroller = new DBController();
            List<DBUsuarios> lista = dbcontroller.getUsuarios("email='" + Login + "' and senha='" + Senha + "'");
            if (lista.Count != 0)
            {
                Session["IdUsuario"] = lista[0].usid;
                Session["Email"] = lista[0].email;
                return RedirectToAction("PainelUsuario", new { id = lista[0].usid });
            }
            else
            {
                ViewBag.Erro("Usuario ou senha invalidos");
                return View();
            }

        }

        public ActionResult PainelUsuario(int id)
        {
            if (Session["IdUsuario"].ToString() == id.ToString())
            {
                ViewBag.Pronome = "Meus";
            }

            List<DBAnuncio> lista = new List<DBAnuncio>();
            IDBController dbcontroller = new DBController();
            lista = dbcontroller.getAnuncios();
            if (lista.Count >= 4)
            {
                ViewBag.Anuncios = dbcontroller.getAnuncios("rownum <=4 and usid=" + id);
            }
            else
            {
                List<DBAnuncio> anuncios = new List<DBAnuncio>();
                foreach (DBAnuncio a in lista)
                {
                    if (a.usid == id)
                    {
                        anuncios.Add(a);
                    }
                }
                ViewBag.Anuncios = anuncios;
            }
            List<DBUsuarios> user = dbcontroller.getUsuarios("usid=" + id);
            return View(user);

        }
    }

}