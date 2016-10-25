using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesfacaFacil.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            Session["IdUsuario"] = -1;
            return View();
        }
        public ActionResult Pesquisa(string busca)
        {
            Models.Entidades c = new Models.Entidades ();
            IEnumerable<Models.ANUNCIO> resultado = c.ANUNCIOs.Where(x => x.TITULO.Contains(busca) || x.DESCRICAO.Contains(busca));
            int i = 0;
            /*foreach (var anuncio in resultado)
            {
                ViewBag.i = c.USUARIOS.Where(x => x.USID == anuncio.USID);
                i++;
            }*/
            return View(resultado);
        }
    }
}