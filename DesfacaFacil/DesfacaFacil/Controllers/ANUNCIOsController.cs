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
using System.IO;

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
            if (imagem != null) {
                string nomeimagem = titulo;
                //string path = System.IO.Path.Combine(Server.MapPath("~"),nomeimagem);
                // file is uploaded
                imagem.SaveAs(Server.MapPath("imagens/"+ nomeimagem));
                using (MemoryStream ms = new MemoryStream())
                {
                    imagem.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
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
