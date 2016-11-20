using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
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
            ViewBag.Candidato2 = candidato;
            ViewBag.Candidato = candidato.usid;
            ViewBag.AID = aid;
            ViewBag.Dono = anuncio.usid;
            ViewBag.Dono2 = dbcontroller.getUsuarios("usid=" + Session["IdUsuario"].ToString()).Single();
            return View(anuncio.getMensagens("usidremetente=" + candidato.usid + " or usiddestinatario=" + candidato.usid+"order by hora"));
        }

        [HttpPost]
        public ActionResult Enviar(string mensagem, int remetente, int destinatario,int _aid) {
            dbcontroller.enviaMensagem(remetente, destinatario, mensagem, _aid);
            DBAnuncios a = dbcontroller.getAnuncios("aid= " + _aid).Single();
            int can = 0;
            if (a.usid.ToString() == remetente.ToString())
            {
                can = destinatario;
            }
            else {
                can = remetente;
            }
            Debug.WriteLine(can);
            Debug.WriteLine(_aid);
            return RedirectToAction("Chat", "Mensagens", new { canid = can, aid = _aid });

        }
        

    }
}
