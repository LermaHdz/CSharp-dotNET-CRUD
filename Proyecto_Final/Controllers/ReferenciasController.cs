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
    public class ReferenciasController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Referencias
        public ActionResult Index()
        {
            var referencia = db.Referencia.Include(r => r.Usuario).Include(r => r.Usuario1);
            return View(referencia.ToList());
        }

        // GET: Referencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referencia referencia = db.Referencia.Find(id);
            if (referencia == null)
            {
                return HttpNotFound();
            }
            return View(referencia);
        }

        // GET: Referencias/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Referencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idReferencia,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Referencia referencia)
        {
            if (ModelState.IsValid)
            {
                db.Referencia.Add(referencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", referencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", referencia.idUsuarioModifica);
            return View(referencia);
        }

        // GET: Referencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referencia referencia = db.Referencia.Find(id);
            if (referencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", referencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", referencia.idUsuarioModifica);
            return View(referencia);
        }

        // POST: Referencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idReferencia,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Referencia referencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(referencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", referencia.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", referencia.idUsuarioModifica);
            return View(referencia);
        }

        // GET: Referencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Referencia referencia = db.Referencia.Find(id);
            if (referencia == null)
            {
                return HttpNotFound();
            }
            return View(referencia);
        }

        // POST: Referencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Referencia referencia = db.Referencia.Find(id);
            db.Referencia.Remove(referencia);
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
