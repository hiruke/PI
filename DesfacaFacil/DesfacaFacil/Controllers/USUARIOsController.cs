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
using System.Diagnostics;

namespace DesfacaFacil.Controllers
{
    public class USUARIOsController : Controller
    {
        //private Entidades db = new Entidades();
        IDBController dbcontroller = new DBController();
        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(string nome, string email, string senha, string estado, string cidade, string telefone)
        {
            Debug.WriteLine(nome + "-" + email + "-" + senha + "-" + estado + "-" + cidade);
            TempData["resultado"] = dbcontroller.addUsuario(nome, email, telefone, senha, estado, cidade);
            return View("Cadastro");
        }
    }
}
