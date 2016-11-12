using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesfacaFacil.Models;
using DAL;

namespace DesfacaFacil.Controllers
{
    public class ANUNCIOsController : Controller
    {
        private Entidades db = new Entidades();

        // GET: ANUNCIOs
        public ActionResult Index()
        {
            IDBController dbcontroller = new DBController();
            List<DBAnuncios> anuncios = dbcontroller.getAnuncios();
            return View(anuncios.ToList());
        }


        [HttpGet]
        public ActionResult Visualizar(int id)
        {

            IDBController dbcontroller = new DBController();
            DBAnuncios anuncio = dbcontroller.getAnuncios("aid=" + id).Single();
            return View(anuncio);
        }
    }
}
