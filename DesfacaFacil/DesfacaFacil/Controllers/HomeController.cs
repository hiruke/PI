using System.Collections.Generic;
using System.Web.Mvc;
using DAL;
using System.Diagnostics;

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

        public ActionResult Pesquisa(string busca, int pg, string categoria)
        {
            IDBController dbcontroller = new DBController();
            ViewBag.Busca = busca;
            string filtro;
            if (categoria != "*")
            {
                filtro = "and cid=" + categoria;
            }
            else
            {
                filtro = "";
            }
            List<DBAnuncios> lista = dbcontroller.getAnuncios("status=1 " + filtro + " and (titulo like '%" + busca + "%' or descricao like '%" + busca + "%')");
            if (pg > 1)
            {
                lista.RemoveRange(0, (pg - 1) * 10);
            }
            ViewBag.categoria = categoria;
            return View(lista);

        }

        public ActionResult Missao()
        {
            return View();
        }

        public ActionResult SobreNos()
        {
            return View();
        }
    }
}