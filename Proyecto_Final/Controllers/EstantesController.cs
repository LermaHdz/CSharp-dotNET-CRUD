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
    public class EstantesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Estantes
        public ActionResult Index()
        {
            var estante = db.Estante.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estante.ToList());
        }

        // GET: Estantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View(estante);
        }

        // GET: Estantes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Estantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstante,numero,columna,fila,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estante estante)
        {
            if (ModelState.IsValid)
            {
                db.Estante.Add(estante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estante.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estante.idUsuarioModifica);
            return View(estante);
        }

        // GET: Estantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estante.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estante.idUsuarioModifica);
            return View(estante);
        }

        // POST: Estantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstante,numero,columna,fila,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estante estante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estante.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estante.idUsuarioModifica);
            return View(estante);
        }

        // GET: Estantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estante estante = db.Estante.Find(id);
            if (estante == null)
            {
                return HttpNotFound();
            }
            return View(estante);
        }

        // POST: Estantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estante estante = db.Estante.Find(id);
            db.Estante.Remove(estante);
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
