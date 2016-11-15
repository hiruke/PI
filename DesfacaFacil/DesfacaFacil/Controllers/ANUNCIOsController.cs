using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesfacaFacil.Models;
using System.Diagnostics;
using DAL;
using System.Runtime.InteropServices;

namespace DesfacaFacil.Controllers
{
    public class ANUNCIOsController : Controller
    {
        IDBController dbcontroller = new DBController();
        public ActionResult Criar()
        {
            List<DBCategorias> categorias = dbcontroller.getCategorias();
            ViewBag.categorias = categorias;
            Debug.WriteLine(dbcontroller.getCategorias()[0].nome);
            return View();
        }

        [HttpGet]
        public ActionResult Criar(string titulo, string descricao, int duracao, int categoria, string tipo)
        {
            Debug.WriteLine(tipo);
            Debug.WriteLine(titulo);
            Debug.WriteLine(descricao);
            Debug.WriteLine(duracao);
            Debug.WriteLine(categoria);
            return View("Criar");
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
