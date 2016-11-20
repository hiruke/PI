using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DesfacaFacil.Models;
using DAL;

namespace DesfacaFacil.Controllers
{
    public class CANDIDATOSController : Controller
    {
        private Entidades db = new Entidades();

        // GET: CANDIDATOS
        public ActionResult Index()
        {
            IDBController dbcontroller = new DBController();
            List<DBCandidatos> candidatos = dbcontroller.getCandidatos();
            return View(candidatos);
        }

        public ActionResult SalvarCandidato(int idanuncio)
        {
            if (Int32.Parse(Session["IdUsuario"].ToString()) != -1)
            {
                IDBController dbcontroller = new DBController();
                dbcontroller.addCandidato(int.Parse(Session["IdUsuario"].ToString()), idanuncio);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Login");
        }

        /*public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATO cANDIDATO = db.CANDIDATOS.Find(id);
            if (cANDIDATO == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATO);
        }*/



        public ActionResult verCandidatos(int idanuncio)
        {
            IDBController dbcontroller = new DBController();
            List<DBCandidatos> candidatos = dbcontroller.getCandidatos("where aid="+idanuncio);
            return View(candidatos);
        }
    }
}
