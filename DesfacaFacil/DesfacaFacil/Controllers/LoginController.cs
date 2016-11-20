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

            try
            {
                DBUsuarios usuario = dbcontroller.getUsuarios("email='" + Login + "' and senha='" + Senha + "'").Single();
                switch (usuario.status)
                {
                    case 0:
                        TempData["resultado"] = "Usuário ainda não confirmado, por favor verifique sua caixa de email";
                        return View();
                    case 1:
                        Session["IdUsuario"] = usuario.usid;
                        Session["Email"] = usuario.email;
                        Session["Nome"] = usuario.nome;
                        TempData["resultado"] = null;
                        return RedirectToAction("PainelUsuario", new { id = usuario.usid });
                    case 2:
                        TempData["resultado"] = "A conta do usuário foi desativada!";
                        return View();
                    default:
                        TempData["resultado"] = "Erro desconhecido, por favor tente novamente.";
                        return View();
                }
            }
            catch (InvalidOperationException ex)
            {
                TempData["resultado"] = "Usuario e/ou senha inválidos";
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
            lista = dbcontroller.getAnuncios("usid=" + id);
            if (lista.Count >= 4)
            {

                ViewBag.Anuncios = lista.Take(4).ToList<DBAnuncios>();
            }
            else
            {
                ViewBag.Anuncios = lista;
            }
            /*List<DBAnuncios> anuncios = new List<DBAnuncios>();
            foreach (DBAnuncios a in lista)
            {
                if (a.usid == id)
                {
                    anuncios.Add(a);
                }
            }
            ViewBag.Anuncios = anuncios;
        }*/
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