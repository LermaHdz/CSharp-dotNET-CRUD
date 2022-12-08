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
    public class EstadoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Estadoes
        public ActionResult Index()
        {
            var estado = db.Estado.Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(estado.ToList());
        }

        // GET: Estadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // GET: Estadoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Estadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEstado,descripcion,codigo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Estado.Add(estado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estado.idUsuarioModifica);
            return View(estado);
        }

        // GET: Estadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estado.idUsuarioModifica);
            return View(estado);
        }

        // POST: Estadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEstado,descripcion,codigo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", estado.idUsuarioModifica);
            return View(estado);
        }

        // GET: Estadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estado estado = db.Estado.Find(id);
            if (estado == null)
            {
                return HttpNotFound();
            }
            return View(estado);
        }

        // POST: Estadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estado estado = db.Estado.Find(id);
            db.Estado.Remove(estado);
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
