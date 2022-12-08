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
    public class TransaccionsController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Transaccions
        public ActionResult Index()
        {
            var transaccion = db.Transaccion.Include(t => t.Empleado).Include(t => t.MetodoDePago).Include(t => t.Producto).Include(t => t.Servicio).Include(t => t.TipoDeTransaccion).Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(transaccion.ToList());
        }

        // GET: Transaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // GET: Transaccions/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno");
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePago, "idMetodoDePago", "metodo");
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre");
            ViewBag.idServicio = new SelectList(db.Servicio, "idServicio", "descripcion");
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccion, "idTipoDeTransaccion", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Transaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTransaccion,monto,idMetodoDePago,idProducto,idServicio,idEmpleado,idTipoDeTransaccion,numeroReferencia,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Transaccion.Add(transaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", transaccion.idEmpleado);
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePago, "idMetodoDePago", "metodo", transaccion.idMetodoDePago);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre", transaccion.idProducto);
            ViewBag.idServicio = new SelectList(db.Servicio, "idServicio", "descripcion", transaccion.idServicio);
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccion, "idTipoDeTransaccion", "tipo", transaccion.idTipoDeTransaccion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", transaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", transaccion.idUsuarioModifica);
            return View(transaccion);
        }

        // GET: Transaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", transaccion.idEmpleado);
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePago, "idMetodoDePago", "metodo", transaccion.idMetodoDePago);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre", transaccion.idProducto);
            ViewBag.idServicio = new SelectList(db.Servicio, "idServicio", "descripcion", transaccion.idServicio);
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccion, "idTipoDeTransaccion", "tipo", transaccion.idTipoDeTransaccion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", transaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", transaccion.idUsuarioModifica);
            return View(transaccion);
        }

        // POST: Transaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTransaccion,monto,idMetodoDePago,idProducto,idServicio,idEmpleado,idTipoDeTransaccion,numeroReferencia,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Transaccion transaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", transaccion.idEmpleado);
            ViewBag.idMetodoDePago = new SelectList(db.MetodoDePago, "idMetodoDePago", "metodo", transaccion.idMetodoDePago);
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "nombre", transaccion.idProducto);
            ViewBag.idServicio = new SelectList(db.Servicio, "idServicio", "descripcion", transaccion.idServicio);
            ViewBag.idTipoDeTransaccion = new SelectList(db.TipoDeTransaccion, "idTipoDeTransaccion", "tipo", transaccion.idTipoDeTransaccion);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", transaccion.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", transaccion.idUsuarioModifica);
            return View(transaccion);
        }

        // GET: Transaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaccion transaccion = db.Transaccion.Find(id);
            if (transaccion == null)
            {
                return HttpNotFound();
            }
            return View(transaccion);
        }

        // POST: Transaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaccion transaccion = db.Transaccion.Find(id);
            db.Transaccion.Remove(transaccion);
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
