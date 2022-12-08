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
    public class ProductoEtiquetasController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: ProductoEtiquetas
        public ActionResult Index()
        {
            var productoEtiqueta = db.ProductoEtiqueta.Include(p => p.Etiqueta).Include(p => p.Producto).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(productoEtiqueta.ToList());
        }

        // GET: ProductoEtiquetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoEtiqueta productoEtiqueta = db.ProductoEtiqueta.Find(id);
            if (productoEtiqueta == null)
            {
                return HttpNotFound();
            }
            return View(productoEtiqueta);
        }

        // GET: ProductoEtiquetas/Create
        public ActionResult Create()
        {
            ViewBag.idEtiqueta = new SelectList(db.Etiqueta, "idEtiqueta", "codigo");
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: ProductoEtiquetas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProductoEtiqueta,idProducto,idEtiqueta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoEtiqueta productoEtiqueta)
        {
            if (ModelState.IsValid)
            {
                db.ProductoEtiqueta.Add(productoEtiqueta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEtiqueta = new SelectList(db.Etiqueta, "idEtiqueta", "codigo", productoEtiqueta.idEtiqueta);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre", productoEtiqueta.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", productoEtiqueta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", productoEtiqueta.idUsuarioModifica);
            return View(productoEtiqueta);
        }

        // GET: ProductoEtiquetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoEtiqueta productoEtiqueta = db.ProductoEtiqueta.Find(id);
            if (productoEtiqueta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEtiqueta = new SelectList(db.Etiqueta, "idEtiqueta", "codigo", productoEtiqueta.idEtiqueta);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre", productoEtiqueta.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", productoEtiqueta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", productoEtiqueta.idUsuarioModifica);
            return View(productoEtiqueta);
        }

        // POST: ProductoEtiquetas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProductoEtiqueta,idProducto,idEtiqueta,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] ProductoEtiqueta productoEtiqueta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoEtiqueta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEtiqueta = new SelectList(db.Etiqueta, "idEtiqueta", "codigo", productoEtiqueta.idEtiqueta);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre", productoEtiqueta.idProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", productoEtiqueta.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", productoEtiqueta.idUsuarioModifica);
            return View(productoEtiqueta);
        }

        // GET: ProductoEtiquetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoEtiqueta productoEtiqueta = db.ProductoEtiqueta.Find(id);
            if (productoEtiqueta == null)
            {
                return HttpNotFound();
            }
            return View(productoEtiqueta);
        }

        // POST: ProductoEtiquetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoEtiqueta productoEtiqueta = db.ProductoEtiqueta.Find(id);
            db.ProductoEtiqueta.Remove(productoEtiqueta);
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
