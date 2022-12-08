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
    public class EstudiosController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Estudios
        public ActionResult Index()
        {
            var estudios = db.Estudios.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estudios.ToList());
        }

        // GET: Estudios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return HttpNotFound();
            }
            return View(estudios);
        }

        // GET: Estudios/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Estudios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstudios,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estudios estudios)
        {
            if (ModelState.IsValid)
            {
                db.Estudios.Add(estudios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estudios.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estudios.idUsuarioModifica);
            return View(estudios);
        }

        // GET: Estudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estudios.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estudios.idUsuarioModifica);
            return View(estudios);
        }

        // POST: Estudios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstudios,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estudios estudios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estudios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estudios.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estudios.idUsuarioModifica);
            return View(estudios);
        }

        // GET: Estudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estudios estudios = db.Estudios.Find(id);
            if (estudios == null)
            {
                return HttpNotFound();
            }
            return View(estudios);
        }

        // POST: Estudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estudios estudios = db.Estudios.Find(id);
            db.Estudios.Remove(estudios);
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
