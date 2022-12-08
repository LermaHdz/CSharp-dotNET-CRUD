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
    public class ProveedorsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Proveedors
        public ActionResult Index()
        {
            var proveedor = db.Proveedor.Include(p => p.TipoDeProveedor).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(proveedor.ToList());
        }

        // GET: Proveedors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // GET: Proveedors/Create
        public ActionResult Create()
        {
            ViewBag.idTipoDeProveedor = new SelectList(db.TipoDeProveedor, "idTipoDeProveedor", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Proveedors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProveedor,nombre,idTipoDeProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Proveedor.Add(proveedor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTipoDeProveedor = new SelectList(db.TipoDeProveedor, "idTipoDeProveedor", "descripcion", proveedor.idTipoDeProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", proveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", proveedor.idUsuarioModifica);
            return View(proveedor);
        }

        // GET: Proveedors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTipoDeProveedor = new SelectList(db.TipoDeProveedor, "idTipoDeProveedor", "descripcion", proveedor.idTipoDeProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", proveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", proveedor.idUsuarioModifica);
            return View(proveedor);
        }

        // POST: Proveedors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProveedor,nombre,idTipoDeProveedor,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proveedor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTipoDeProveedor = new SelectList(db.TipoDeProveedor, "idTipoDeProveedor", "descripcion", proveedor.idTipoDeProveedor);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", proveedor.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", proveedor.idUsuarioModifica);
            return View(proveedor);
        }

        // GET: Proveedors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proveedor proveedor = db.Proveedor.Find(id);
            if (proveedor == null)
            {
                return HttpNotFound();
            }
            return View(proveedor);
        }

        // POST: Proveedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proveedor proveedor = db.Proveedor.Find(id);
            db.Proveedor.Remove(proveedor);
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
