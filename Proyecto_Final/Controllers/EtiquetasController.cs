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
    public class EtiquetasController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Etiquetas
        public ActionResult Index()
        {
            var etiqueta = db.Etiqueta.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(etiqueta.ToList());
        }

        // GET: Etiquetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta);
        }

        // GET: Etiquetas/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Etiquetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEtiqueta,codigo,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Etiqueta.Add(etiqueta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", etiqueta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", etiqueta.idUsuarioModifica);
            return View(etiqueta);
        }

        // GET: Etiquetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", etiqueta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", etiqueta.idUsuarioModifica);
            return View(etiqueta);
        }

        // POST: Etiquetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEtiqueta,codigo,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Etiqueta etiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etiqueta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", etiqueta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", etiqueta.idUsuarioModifica);
            return View(etiqueta);
        }

        // GET: Etiquetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            if (etiqueta == null)
            {
                return HttpNotFound();
            }
            return View(etiqueta);
        }

        // POST: Etiquetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etiqueta etiqueta = db.Etiqueta.Find(id);
            db.Etiqueta.Remove(etiqueta);
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
