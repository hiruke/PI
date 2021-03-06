﻿using System;
using System.Collections.Generic;
using System.Data;
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
            List<DBCandidatos> todosCandidatos = anuncio.getCandidatos();
            DBCandidatos candidato = todosCandidatos.Where(x => x.canid == canid).Single();
            ViewBag.Candidato = candidato;
            ViewBag.Anuncio = anuncio;
            ViewBag.Proprietario = anuncio.getUsuario();
            return View(anuncio.getMensagens("usidremetente=" + candidato.usid + " or usiddestinatario=" + candidato.usid + " order by hora"));
        }

        [HttpPost]
        public ActionResult Enviar(string mensagem, int remetente, int destinatario, int _aid)
        {
            dbcontroller.enviaMensagem(remetente, destinatario, mensagem, _aid);
            DBAnuncios anuncio = dbcontroller.getAnuncios("aid= " + _aid).Single();
            int can = 0;
            if (anuncio.usid.ToString() == remetente.ToString())
            {
                can = dbcontroller.getCandidatos("usid=" + destinatario + " and aid=" + _aid).Single().canid;
            }
            else
            {
                can = dbcontroller.getCandidatos("usid=" + remetente + " and aid=" + _aid).Single().canid;
            }
            return RedirectToAction("Chat", "Mensagens", new { canid = can, aid = _aid });

        }


    }
}
