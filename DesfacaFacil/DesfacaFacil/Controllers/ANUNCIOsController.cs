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
            string caminho = Server.MapPath("~/Repositorio/Imagens/Anuncios/");
            string nome = "";
            if (arquivo != null)
            {
                nome = geraNome(0, arquivo.FileName, caminho);
                Debug.WriteLine("Salvando arquivo: " + caminho+nome);
                arquivo.SaveAs(caminho+nome);
            }

            List<DBCategorias> categorias = dbcontroller.getCategorias();
            ViewBag.categorias = categorias;
            TempData["resultado"] = dbcontroller.addAnuncio(int.Parse(Session["IdUsuario"].ToString().ToString()), categoria, tipo, 1, duracao, descricao, titulo, caminho, nome);
            return View("Criar");
        }

        private string geraNome(int _i, string _nome, string caminho)
        {

            string nome = _nome;
            int i = _i + 1;
            if (System.IO.File.Exists(caminho + i + "_" + nome))
            {
                Debug.WriteLine(i);
                return geraNome(i, nome, caminho);
            }
            else
            {
                nome =i + "_" + nome;
                return nome;
            }

        }

        public ActionResult Alterar(int aid)
        {

            return View(dbcontroller.getAnuncios("aid=" + aid).Single());
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
