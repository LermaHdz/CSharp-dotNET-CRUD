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
    public class EmpleadoTurnoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: EmpleadoTurnoes
        public ActionResult Index()
        {
            var empleadoTurno = db.EmpleadoTurno.Include(e => e.Empleado).Include(e => e.Turno).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleadoTurno.ToList());
        }

        // GET: EmpleadoTurnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTurno empleadoTurno = db.EmpleadoTurno.Find(id);
            if (empleadoTurno == null)
            {
                return HttpNotFound();
            }
            return View(empleadoTurno);
        }

        // GET: EmpleadoTurnoes/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno");
            ViewBag.idTurno = new SelectList(db.Turno, "idTurno", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: EmpleadoTurnoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleadoTurno,idEmpleado,idTurno,fechaInicio,fechaFinal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoTurno empleadoTurno)
        {
            if (ModelState.IsValid)
            {
                db.EmpleadoTurno.Add(empleadoTurno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", empleadoTurno.idEmpleado);
            ViewBag.idTurno = new SelectList(db.Turno, "idTurno", "descripcion", empleadoTurno.idTurno);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleadoTurno.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleadoTurno.idUsuarioModifica);
            return View(empleadoTurno);
        }

        // GET: EmpleadoTurnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTurno empleadoTurno = db.EmpleadoTurno.Find(id);
            if (empleadoTurno == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", empleadoTurno.idEmpleado);
            ViewBag.idTurno = new SelectList(db.Turno, "idTurno", "descripcion", empleadoTurno.idTurno);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleadoTurno.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleadoTurno.idUsuarioModifica);
            return View(empleadoTurno);
        }

        // POST: EmpleadoTurnoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleadoTurno,idEmpleado,idTurno,fechaInicio,fechaFinal,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] EmpleadoTurno empleadoTurno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoTurno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", empleadoTurno.idEmpleado);
            ViewBag.idTurno = new SelectList(db.Turno, "idTurno", "descripcion", empleadoTurno.idTurno);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleadoTurno.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleadoTurno.idUsuarioModifica);
            return View(empleadoTurno);
        }

        // GET: EmpleadoTurnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoTurno empleadoTurno = db.EmpleadoTurno.Find(id);
            if (empleadoTurno == null)
            {
                return HttpNotFound();
            }
            return View(empleadoTurno);
        }

        // POST: EmpleadoTurnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoTurno empleadoTurno = db.EmpleadoTurno.Find(id);
            db.EmpleadoTurno.Remove(empleadoTurno);
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
