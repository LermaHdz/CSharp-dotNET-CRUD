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
    public class TipoDeProveedorsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: TipoDeProveedors
        public ActionResult Index()
        {
            var tipoDeProveedor = db.TipoDeProveedor.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeProveedor.ToList());
        }

        // GET: TipoDeProveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedor.Find(id);
            if (tipoDeProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProveedor);
        }

        // GET: TipoDeProveedors/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: TipoDeProveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeProveedor,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProveedor tipoDeProveedor)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeProveedor.Add(tipoDeProveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProveedor.idUsuarioModifica);
            return View(tipoDeProveedor);
        }

        // GET: TipoDeProveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedor.Find(id);
            if (tipoDeProveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProveedor.idUsuarioModifica);
            return View(tipoDeProveedor);
        }

        // POST: TipoDeProveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeProveedor,descripcion,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProveedor tipoDeProveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeProveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProveedor.idUsuarioModifica);
            return View(tipoDeProveedor);
        }

        // GET: TipoDeProveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedor.Find(id);
            if (tipoDeProveedor == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProveedor);
        }

        // POST: TipoDeProveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeProveedor tipoDeProveedor = db.TipoDeProveedor.Find(id);
            db.TipoDeProveedor.Remove(tipoDeProveedor);
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
