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
        IDBController dbcontroller = new DBController();
        // GET: Login
        public ActionResult Index()
        {
            //IEnumerable<DesfacaFacil.Models.Anuncio> modelo =    
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Login, string Senha)
        {

            List<DBUsuarios> lista = dbcontroller.getUsuarios("email='" + Login + "' and senha='" + Senha + "'");
            if (lista.Count > 0)
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
            List<DBAnuncios> lista = new List<DBAnuncios>();
            lista = dbcontroller.getAnuncios();
            if (lista.Count >= 4)
            {
                ViewBag.Anuncios = dbcontroller.getAnuncios("usid=" + id).Take(4);
            }
            else
            {
                List<DBAnuncios> anuncios = new List<DBAnuncios>();
                foreach (DBAnuncios a in lista)
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
        public ActionResult Sair()
        {
            Session.Clear();
            Session["IdUsuario"] = -1;
            return RedirectToAction("Index", "Home");
        }
    }

}