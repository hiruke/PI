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

        public ActionResult Chat()
        {
            return View();
        }

        /*public ActionResult Index()
        {
            var mENSAGENS = db.MENSAGENS.Include(m => m.ANUNCIO);
            return View(mENSAGENS.ToList());
        }

        // GET: MENSAGENs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENSAGEN mENSAGEN = db.MENSAGENS.Find(id);
            if (mENSAGEN == null)
            {
                return HttpNotFound();
            }
            return View(mENSAGEN);
        }

        // GET: MENSAGENs/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO");
            return View();
        }

        // POST: MENSAGENs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MID,USIDREMETENTE,USIDDESTINATARIO,CONTEUDO,AID")] MENSAGEN mENSAGEN)
        {
            if (ModelState.IsValid)
            {
                db.MENSAGENS.Add(mENSAGEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO", mENSAGEN.AID);
            return View(mENSAGEN);
        }

        // GET: MENSAGENs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENSAGEN mENSAGEN = db.MENSAGENS.Find(id);
            if (mENSAGEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO", mENSAGEN.AID);
            return View(mENSAGEN);
        }

        // POST: MENSAGENs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MID,USIDREMETENTE,USIDDESTINATARIO,CONTEUDO,AID")] MENSAGEN mENSAGEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mENSAGEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO", mENSAGEN.AID);
            return View(mENSAGEN);
        }

        // GET: MENSAGENs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENSAGEN mENSAGEN = db.MENSAGENS.Find(id);
            if (mENSAGEN == null)
            {
                return HttpNotFound();
            }
            return View(mENSAGEN);
        }

        // POST: MENSAGENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MENSAGEN mENSAGEN = db.MENSAGENS.Find(id);
            db.MENSAGENS.Remove(mENSAGEN);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/


    }
}
