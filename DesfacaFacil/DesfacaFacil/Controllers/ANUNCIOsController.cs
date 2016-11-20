using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using DAL;
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
        public ActionResult Criar(string titulo, string descricao, int duracao, int categoria, int tipo, HttpPostedFileBase arquivo)
        {

            if (arquivo != null)
            {
                string caminho = "C:\\TesteImagens\\";
                string nome = arquivo.FileName;
                string destino = "";
                for (int i = 0; System.IO.File.Exists(caminho + i + "_" + nome) || destino == ""; i++)
                {
                    Debug.WriteLine("Checando caminho");
                    destino = caminho + i + "_" + nome;
                }

                //string path = System.IO.Path.Combine(Server.MapPath("~"),nomeimagem);
                // file is uploaded
                Debug.WriteLine("Salvando arquivo: " + destino);
                arquivo.SaveAs(destino);
                using (MemoryStream ms = new MemoryStream())
                {
                    arquivo.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }
            else
            {
                Debug.WriteLine("Imagem nula");
            }
            List<DBCategorias> categorias = dbcontroller.getCategorias();
            ViewBag.categorias = categorias;
            TempData["resultado"] = dbcontroller.addAnuncio(int.Parse(Session["IdUsuario"].ToString().ToString()), categoria, tipo, 1, duracao, descricao, titulo);
            return View("Criar");
        }

        public ActionResult Alterar(int aid) {
            
            return View(dbcontroller.getAnuncios("aid=" + aid).Single());
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
