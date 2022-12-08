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
    public class ServiciosController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Servicios
        public ActionResult Index()
        {
            var servicio = db.Servicio.Include(s => s.Referencia).Include(s => s.Usuario).Include(s => s.Usuario1);
            return View(servicio.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.idReferencia = new SelectList(db.Referencia, "idReferencia", "descripcion");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idServicio,idReferencia,descripcion,comision,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idReferencia = new SelectList(db.Referencia, "idReferencia", "descripcion", servicio.idReferencia);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuarioModifica);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuarioCrea);
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idReferencia = new SelectList(db.Referencia, "idReferencia", "descripcion", servicio.idReferencia);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuarioModifica);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuarioCrea);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idServicio,idReferencia,descripcion,comision,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idReferencia = new SelectList(db.Referencia, "idReferencia", "descripcion", servicio.idReferencia);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuarioModifica);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", servicio.idUsuarioCrea);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = db.Servicio.Find(id);
            db.Servicio.Remove(servicio);
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
