using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesfacaFacil.Models;

namespace DesfacaFacil.Controllers
{
    public class CANDIDATOSController : Controller
    {
        private Entidades db = new Entidades();

        // GET: CANDIDATOS
        public ActionResult Index()
        {
            var cANDIDATOS = db.CANDIDATOS.Include(c => c.ANUNCIO).Include(c => c.USUARIO);
            return View(cANDIDATOS.ToList());
        }

        public ActionResult SalvarCandidato(int idusuario, int idanuncio) {
            DesfacaFacil.Models.CANDIDATO c = new CANDIDATO(idusuario, idanuncio);
            db.CANDIDATOS.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: CANDIDATOS/Details/5
        public ActionResult Details(string id)
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
        }

        // GET: CANDIDATOS/Create
        public ActionResult Create()
        {
            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO");
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME");
            return View();
        }

        // POST: CANDIDATOS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CANID,USID,AID")] CANDIDATO cANDIDATO)
        {
            if (ModelState.IsValid)
            {
                db.CANDIDATOS.Add(cANDIDATO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO", cANDIDATO.AID);
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", cANDIDATO.USID);
            return View(cANDIDATO);
        }

        // GET: CANDIDATOS/Edit/5
        public ActionResult Edit(string id)
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
            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO", cANDIDATO.AID);
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", cANDIDATO.USID);
            return View(cANDIDATO);
        }

        // POST: CANDIDATOS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CANID,USID,AID")] CANDIDATO cANDIDATO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANDIDATO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AID = new SelectList(db.ANUNCIOs, "AID", "DESCRICAO", cANDIDATO.AID);
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", cANDIDATO.USID);
            return View(cANDIDATO);
        }

        // GET: CANDIDATOS/Delete/5
        public ActionResult Delete(string id)
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
        }

        // POST: CANDIDATOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CANDIDATO cANDIDATO = db.CANDIDATOS.Find(id);
            db.CANDIDATOS.Remove(cANDIDATO);
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
        }
    }
}
