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

    public class MENSAGENsController : Controller
    {
        IDBController dbcontroller = new DBController();

        public ActionResult Mensagens(int prodid)
        {
            if (Int32.Parse(Session["IdUsuario"].ToString()) != -1)
            {
                //int usid = dbcontroller.getAnuncios("aid=" + prodid)[0].usid;

                DBAnuncios anuncio = dbcontroller.getAnuncios("aid=" + prodid).Single();
                List<DBMensagens> listaMensagens = anuncio.getMensagens("usidremetente=" + anuncio.usid + " or " + "usiddestinatario=" + anuncio.usid + "order by hora");
                ViewBag.OutrosAnuncios = dbcontroller.getAnuncios("usid=" + Int32.Parse(Session["IdUsuario"].ToString()) + " and aid=" + prodid).Take(4);
                return View(listaMensagens);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult Chat(int canid, int aid)
        {

            DBAnuncios anuncio = dbcontroller.getAnuncios("aid=" + aid).Single();
            List<DBCandidatos> candidatos = anuncio.getCandidatos();
            DBCandidatos candidato = candidatos.Where(x => x.canid == canid).Single();
            ViewBag.Candidato = candidato;
            ViewBag.Dono = dbcontroller.getUsuarios("usid=" + Session["IdUsuario"].ToString()).Single();
            return View(anuncio.getMensagens("usidremetente=" + candidato.usid + " or usiddestinatario=" + candidato.usid));
        }




    }
}
