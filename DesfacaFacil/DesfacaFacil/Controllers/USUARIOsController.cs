using System;
using System.Linq;
using System.Web.Mvc;
using DesfacaFacil.Models;
using DAL;
using System.Text;
using System.Diagnostics;

namespace DesfacaFacil.Controllers
{
    public class USUARIOsController : Controller
    {
        IDBController dbcontroller = new DBController();
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Validar(string id)
        {
            string email = Encoding.UTF8.GetString(Convert.FromBase64String(id.ToString()));
            TempData["resultado"] = dbcontroller.validaEmail(email);
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(string nome, string email, string senha, string estado, string cidade, string telefone)
        {
            Debug.WriteLine(nome + "-" + email + "-" + senha + "-" + estado + "-" + cidade);
            TempData["resultado"] = dbcontroller.addUsuario(nome, email, telefone, senha, estado, cidade);
            if (TempData["resultado"] == "0x00")
            {
                Notificacao.confirmaCadastro(dbcontroller.getUsuarios("email='" + email + "'").Single());
            }
            return View("Cadastro");
        }

        public ActionResult Alterar(int usid) {
            return View(dbcontroller.getUsuarios("usid=" + usid).Single());
        }

        [HttpPost]
        public ActionResult Alterar(int usid, string nome, string email, string telefone) {
            DBUsuarios us = dbcontroller.getUsuarios("usid=" + usid).Single();
            us.Alterar(nome, email, telefone);
            return View("Index","Home");
        }
    }
}
