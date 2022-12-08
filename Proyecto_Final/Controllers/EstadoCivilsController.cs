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
    public class EstadoCivilsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: EstadoCivils
        public ActionResult Index()
        {
            var estadoCivil = db.EstadoCivil.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estadoCivil.ToList());
        }

        // GET: EstadoCivils/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCivil estadoCivil = db.EstadoCivil.Find(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            return View(estadoCivil);
        }

        // GET: EstadoCivils/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: EstadoCivils/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstadoCivil,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                db.EstadoCivil.Add(estadoCivil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estadoCivil.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estadoCivil.idUsuarioModifica);
            return View(estadoCivil);
        }

        // GET: EstadoCivils/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCivil estadoCivil = db.EstadoCivil.Find(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estadoCivil.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estadoCivil.idUsuarioModifica);
            return View(estadoCivil);
        }

        // POST: EstadoCivils/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstadoCivil,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EstadoCivil estadoCivil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoCivil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estadoCivil.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estadoCivil.idUsuarioModifica);
            return View(estadoCivil);
        }

        // GET: EstadoCivils/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoCivil estadoCivil = db.EstadoCivil.Find(id);
            if (estadoCivil == null)
            {
                return HttpNotFound();
            }
            return View(estadoCivil);
        }

        // POST: EstadoCivils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoCivil estadoCivil = db.EstadoCivil.Find(id);
            db.EstadoCivil.Remove(estadoCivil);
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
