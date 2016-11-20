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
            string caminho = "C:\\TesteImagens\\";
            string nome = "";
            string destino = "";
            if (arquivo != null)
            {
                nome = arquivo.FileName;
                for (int i = 0; System.IO.File.Exists(caminho + i + "_" + nome) || destino == ""; i++)
                {
                    Debug.WriteLine("Checando caminho");
                    destino = caminho + i + "_" + nome;
                }

                Debug.WriteLine("Salvando arquivo: " + destino);
                arquivo.SaveAs(destino);
            }

            List<DBCategorias> categorias = dbcontroller.getCategorias();
            ViewBag.categorias = categorias;
            TempData["resultado"] = dbcontroller.addAnuncio(int.Parse(Session["IdUsuario"].ToString().ToString()), categoria, tipo, 1, duracao, descricao, titulo, caminho, nome);
            return View("Criar");
        }

        [HttpGet]
        public ActionResult Visualizar(int id)
        {

            IDBController dbcontroller = new DBController();
            DBAnuncios anuncio = dbcontroller.getAnuncios("aid=" + id).Single();
            ViewBag.Imagens = dbcontroller.getImagens("aid=" + id);
            return View(anuncio);
        }
    }
}
