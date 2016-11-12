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

                /*ViewBag.OutrosAnuncios = db.ANUNCIOs.Where(x => x.USID == db.ANUNCIOs.FirstOrDefault(y => y.AID == prodid).USID).Take(4);
                ViewBag.Usuarios = db.USUARIOS;
                return View(ViewBag.Candidatos = db.CANDIDATOS.Where(x => x.AID == prodid));
                //return View(db.ANUNCIOs.Single(x => x.AID == prodid));*/
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Chat(int _canid, int _aid)
        {
            DBAnuncios anuncio = dbcontroller.getAnuncios("aid="+_aid).Single();
            ViewBag.Candidato = anuncio.getCandidatos();
            ViewBag.CandidatoId = _canid;
            ViewBag.Dono = dbcontroller.getUsuarios("usid=" + Session["IdUsuario"].ToString()).Single().nome;
            return View(dbcontroller.getCandidatos("canid =" + _canid));
        }




    }
}
