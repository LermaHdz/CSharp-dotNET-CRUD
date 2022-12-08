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
    public class NacionalidadsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Nacionalidads
        public ActionResult Index()
        {
            var nacionalidad = db.Nacionalidad.Include(n => n.Usuario).Include(n => n.Usuario1);
            return View(nacionalidad.ToList());
        }

        // GET: Nacionalidads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidad.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // GET: Nacionalidads/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Nacionalidads/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNacionalidad,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Nacionalidad.Add(nacionalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", nacionalidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", nacionalidad.idUsuarioModifica);
            return View(nacionalidad);
        }

        // GET: Nacionalidads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidad.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", nacionalidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", nacionalidad.idUsuarioModifica);
            return View(nacionalidad);
        }

        // POST: Nacionalidads/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNacionalidad,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nacionalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", nacionalidad.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", nacionalidad.idUsuarioModifica);
            return View(nacionalidad);
        }

        // GET: Nacionalidads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidad.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // POST: Nacionalidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nacionalidad nacionalidad = db.Nacionalidad.Find(id);
            db.Nacionalidad.Remove(nacionalidad);
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
