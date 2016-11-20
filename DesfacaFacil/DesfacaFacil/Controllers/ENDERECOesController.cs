using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DesfacaFacil.Models;

namespace DesfacaFacil.Controllers
{
    public class ENDERECOesController : Controller
    {
        private Entidades db = new Entidades();

        // GET: ENDERECOes
        public ActionResult Index()
        {
            var eNDERECOes = db.ENDERECOes.Include(e => e.USUARIO);
            return View(eNDERECOes.ToList());
        }

        // GET: ENDERECOes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENDERECO eNDERECO = db.ENDERECOes.Find(id);
            if (eNDERECO == null)
            {
                return HttpNotFound();
            }
            return View(eNDERECO);
        }

        // GET: ENDERECOes/Create
        public ActionResult Create()
        {
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME");
            return View();
        }

        // POST: ENDERECOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EID,USID,PAIS,ESTADO,CIDADE,BAIRRO,RUA,NUMERO,CEP")] ENDERECO eNDERECO)
        {
            if (ModelState.IsValid)
            {
                db.ENDERECOes.Add(eNDERECO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", eNDERECO.USID);
            return View(eNDERECO);
        }

        // GET: ENDERECOes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENDERECO eNDERECO = db.ENDERECOes.Find(id);
            if (eNDERECO == null)
            {
                return HttpNotFound();
            }
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", eNDERECO.USID);
            return View(eNDERECO);
        }

        // POST: ENDERECOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EID,USID,PAIS,ESTADO,CIDADE,BAIRRO,RUA,NUMERO,CEP")] ENDERECO eNDERECO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eNDERECO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.USID = new SelectList(db.USUARIOS, "USID", "NOME", eNDERECO.USID);
            return View(eNDERECO);
        }

        // GET: ENDERECOes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ENDERECO eNDERECO = db.ENDERECOes.Find(id);
            if (eNDERECO == null)
            {
                return HttpNotFound();
            }
            return View(eNDERECO);
        }

        // POST: ENDERECOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ENDERECO eNDERECO = db.ENDERECOes.Find(id);
            db.ENDERECOes.Remove(eNDERECO);
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
