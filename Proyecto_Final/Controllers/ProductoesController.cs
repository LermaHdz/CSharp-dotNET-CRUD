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
    public class ProductoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Productoes
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Estante).Include(p => p.Marca).Include(p => p.Proveedor).Include(p => p.TipoDeProducto).Include(p => p.Usuario).Include(p => p.Usuario1);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.idEstante = new SelectList(db.Estante, "idEstante", "idEstante");
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "marca1");
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre");
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProducto, "idTipoDeProducto", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,nombre,cantidad,precio,idMarca,idProveedor,idEstante,idTipoDeProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstante = new SelectList(db.Estante, "idEstante", "idEstante", producto.idEstante);
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "marca1", producto.idMarca);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", producto.idProveedor);
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProducto, "idTipoDeProducto", "tipo", producto.idTipoDeProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", producto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", producto.idUsuarioModifica);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstante = new SelectList(db.Estante, "idEstante", "idEstante", producto.idEstante);
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "marca1", producto.idMarca);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", producto.idProveedor);
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProducto, "idTipoDeProducto", "tipo", producto.idTipoDeProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", producto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", producto.idUsuarioModifica);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,nombre,cantidad,precio,idMarca,idProveedor,idEstante,idTipoDeProducto,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstante = new SelectList(db.Estante, "idEstante", "idEstante", producto.idEstante);
            ViewBag.idMarca = new SelectList(db.Marca, "idMarca", "marca1", producto.idMarca);
            ViewBag.idProveedor = new SelectList(db.Proveedor, "idProveedor", "nombre", producto.idProveedor);
            ViewBag.idTipoDeProducto = new SelectList(db.TipoDeProducto, "idTipoDeProducto", "tipo", producto.idTipoDeProducto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", producto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", producto.idUsuarioModifica);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
