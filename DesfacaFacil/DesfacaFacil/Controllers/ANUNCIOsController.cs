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

        [HttpPost]
        public ActionResult Criar(string titulo, string descricao, int duracao, int categoria, int tipo, HttpPostedFile imagem)
        {
            //if (imagem.ContentLength > 0)
            //{

            //    imagem.SaveAs("C:\\Users\ronne\\Desktop\\test.png");
            //}
            List<DBCategorias> categorias = dbcontroller.getCategorias();
            ViewBag.categorias = categorias;
            TempData["resultado"] = dbcontroller.addAnuncio(int.Parse(Session["IdUsuario"].ToString().ToString()), categoria, tipo, 1, duracao, descricao, titulo);
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
