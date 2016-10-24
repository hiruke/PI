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
    public class ANUNCIOsController : Controller
    {
        private Entidades db = new Entidades();

        // GET: ANUNCIOs
        public ActionResult Index()
        {
            var aNUNCIOs = db.ANUNCIOs.Include(a => a.USUARIO).Include(a => a.CATEGORIA);
            return View(aNUNCIOs.ToList());
        }

        // GET: ANUNCIOs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            if (aNUNCIO == null)
            {
                return HttpNotFound();
            }
            return View(aNUNCIO);
        }

        // GET: ANUNCIOs/Create
        public ActionResult Create()
        {
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME");
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME");
            return View();
        }

        // POST: ANUNCIOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AID,USID,CID,TIPO,STATUS,DATACRIACAO,DATAEXPIRACAO,DESCRICAO,TITULO")] ANUNCIO aNUNCIO)
        {
            if (ModelState.IsValid)
            {
                db.ANUNCIOs.Add(aNUNCIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", aNUNCIO.USID);
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME", aNUNCIO.CID);
            return View(aNUNCIO);
        }

        // GET: ANUNCIOs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            if (aNUNCIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", aNUNCIO.USID);
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME", aNUNCIO.CID);
            return View(aNUNCIO);
        }

        // POST: ANUNCIOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AID,USID,CID,TIPO,STATUS,DATACRIACAO,DATAEXPIRACAO,DESCRICAO,TITULO")] ANUNCIO aNUNCIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aNUNCIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", aNUNCIO.USID);
            ViewBag.CID = new SelectList(db.CATEGORIAS, "CID", "NOME", aNUNCIO.CID);
            return View(aNUNCIO);
        }

        // GET: ANUNCIOs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            if (aNUNCIO == null)
            {
                return HttpNotFound();
            }
            return View(aNUNCIO);
        }

        // POST: ANUNCIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            ANUNCIO aNUNCIO = db.ANUNCIOs.Find(id);
            db.ANUNCIOs.Remove(aNUNCIO);
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

        [HttpGet]
        public ActionResult Visualizar(int id)
        {
            ANUNCIO a = db.ANUNCIOs.Where(x => x.AID == id).FirstOrDefault();
            if (Int32.Parse(Session["IdUsuario"].ToString()) == a.USID) {
                a.CANDIDATOS = db.CANDIDATOS.Where(x => x.AID == a.AID).AsEnumerable() ;
                ViewBag.Dono = true;
            }
            ViewBag.Dono = false;
            return View(a);
        }
    }
}
