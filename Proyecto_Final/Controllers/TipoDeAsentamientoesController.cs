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
    public class TipoDeAsentamientoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: TipoDeAsentamientoes
        public ActionResult Index()
        {
            var tipoDeAsentamiento = db.TipoDeAsentamiento.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeAsentamiento.ToList());
        }

        // GET: TipoDeAsentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamiento.Find(id);
            if (tipoDeAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAsentamiento);
        }

        // GET: TipoDeAsentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: TipoDeAsentamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeAsentamiento,tipo,codigo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeAsentamiento tipoDeAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeAsentamiento.Add(tipoDeAsentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeAsentamiento.idUsuarioModifica);
            return View(tipoDeAsentamiento);
        }

        // GET: TipoDeAsentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamiento.Find(id);
            if (tipoDeAsentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeAsentamiento.idUsuarioModifica);
            return View(tipoDeAsentamiento);
        }

        // POST: TipoDeAsentamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeAsentamiento,tipo,codigo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeAsentamiento tipoDeAsentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeAsentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeAsentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeAsentamiento.idUsuarioModifica);
            return View(tipoDeAsentamiento);
        }

        // GET: TipoDeAsentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamiento.Find(id);
            if (tipoDeAsentamiento == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeAsentamiento);
        }

        // POST: TipoDeAsentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeAsentamiento tipoDeAsentamiento = db.TipoDeAsentamiento.Find(id);
            db.TipoDeAsentamiento.Remove(tipoDeAsentamiento);
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
