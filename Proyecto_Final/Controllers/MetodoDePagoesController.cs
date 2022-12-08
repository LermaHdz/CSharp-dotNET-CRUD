using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto_Final.Models;

namespace Proyecto_Final.Controllers
{
    public class MetodoDePagoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: MetodoDePagoes
        public ActionResult Index()
        {
            var metodoDePago = db.MetodoDePago.Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(metodoDePago.ToList());
        }

        // GET: MetodoDePagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            if (metodoDePago == null)
            {
                return HttpNotFound();
            }
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: MetodoDePagoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMetodoDePago,metodo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MetodoDePago metodoDePago)
        {
            if (ModelState.IsValid)
            {
                db.MetodoDePago.Add(metodoDePago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", metodoDePago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", metodoDePago.idUsuarioModifica);
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            if (metodoDePago == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", metodoDePago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", metodoDePago.idUsuarioModifica);
            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMetodoDePago,metodo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] MetodoDePago metodoDePago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodoDePago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", metodoDePago.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", metodoDePago.idUsuarioModifica);
            return View(metodoDePago);
        }

        // GET: MetodoDePagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            if (metodoDePago == null)
            {
                return HttpNotFound();
            }
            return View(metodoDePago);
        }

        // POST: MetodoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MetodoDePago metodoDePago = db.MetodoDePago.Find(id);
            db.MetodoDePago.Remove(metodoDePago);
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
