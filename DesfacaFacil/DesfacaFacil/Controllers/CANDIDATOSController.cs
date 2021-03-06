﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DAL;
using System.Web.Routing;

namespace DesfacaFacil.Controllers
{
    public class CANDIDATOSController : Controller
    {
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
                return RedirectToAction("Visualizar", "Anuncios", new RouteValueDictionary(new { id = idanuncio }));
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult verCandidatos(int idanuncio)
        {
            IDBController dbcontroller = new DBController();
            List<DBCandidatos> candidatos = dbcontroller.getCandidatos("where aid=" + idanuncio);
            return View(candidatos);
        }
    }
}
