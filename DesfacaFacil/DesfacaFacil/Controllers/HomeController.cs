using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace DesfacaFacil.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if (Session["IdUsuario"] == null)
            {
                Session["IdUsuario"] = -1;
            }
            return View();
        }
        /*public ActionResult Pesquisa(string busca)
        {
            IDBController dbcontroller = new DBController();
            List<DBAnuncios> lista = dbcontroller.getAnuncios("titulo like '%" + busca + "%' or descricao like '%" + busca + "%'");
            if (lista.Count > 10) {

            }
            return View(lista);

        }*/

        public ActionResult Pesquisa(string busca,int pg)
        {
            IDBController dbcontroller = new DBController();
            ViewBag.Busca = busca;
            List<DBAnuncios> lista = dbcontroller.getAnuncios("titulo like '%" + busca + "%' or descricao like '%" + busca + "%'");
            if (pg>1)
            {
                lista.RemoveRange(0,(pg-1)*10);
            }
            return View(lista);

        }
    }
}