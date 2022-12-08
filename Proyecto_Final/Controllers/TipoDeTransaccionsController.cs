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
    public class TipoDeTransaccionsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: TipoDeTransaccions
        public ActionResult Index()
        {
            var tipoDeTransaccion = db.TipoDeTransaccion.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeTransaccion.ToList());
        }

        // GET: TipoDeTransaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccion.Find(id);
            if (tipoDeTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: TipoDeTransaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeTransaccion,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeTransaccion tipoDeTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeTransaccion.Add(tipoDeTransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeTransaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeTransaccion.idUsuarioModifica);
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccion.Find(id);
            if (tipoDeTransaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeTransaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeTransaccion.idUsuarioModifica);
            return View(tipoDeTransaccion);
        }

        // POST: TipoDeTransaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeTransaccion,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeTransaccion tipoDeTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeTransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeTransaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeTransaccion.idUsuarioModifica);
            return View(tipoDeTransaccion);
        }

        // GET: TipoDeTransaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccion.Find(id);
            if (tipoDeTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeTransaccion);
        }

        // POST: TipoDeTransaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeTransaccion tipoDeTransaccion = db.TipoDeTransaccion.Find(id);
            db.TipoDeTransaccion.Remove(tipoDeTransaccion);
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
