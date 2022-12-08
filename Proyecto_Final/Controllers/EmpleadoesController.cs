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
    public class EmpleadoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Asentamiento).Include(e => e.EstadoCivil).Include(e => e.Estudios).Include(e => e.Nacionalidad).Include(e => e.Puesto).Include(e => e.Usuario).Include(e => e.Usuario1);
            return View(empleado.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "descripcion");
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivil, "idEstadoCivil", "descripcion");
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion");
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion");
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,apellidoPaterno,apellidoMaterno,nombre,RFC,telefono,idAsentamiento,idEstadoCivil,idEstudios,idPuesto,idNacionalidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "descripcion", empleado.idAsentamiento);
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivil, "idEstadoCivil", "descripcion", empleado.idEstadoCivil);
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion", empleado.idEstudios);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "descripcion", empleado.idPuesto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleado.idUsuarioModifica);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "descripcion", empleado.idAsentamiento);
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivil, "idEstadoCivil", "descripcion", empleado.idEstadoCivil);
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion", empleado.idEstudios);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "descripcion", empleado.idPuesto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleado.idUsuarioModifica);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,apellidoPaterno,apellidoMaterno,nombre,RFC,telefono,idAsentamiento,idEstadoCivil,idEstudios,idPuesto,idNacionalidad,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsentamiento = new SelectList(db.Asentamiento, "idAsentamiento", "descripcion", empleado.idAsentamiento);
            ViewBag.idEstadoCivil = new SelectList(db.EstadoCivil, "idEstadoCivil", "descripcion", empleado.idEstadoCivil);
            ViewBag.idEstudios = new SelectList(db.Estudios, "idEstudios", "descripcion", empleado.idEstudios);
            ViewBag.idNacionalidad = new SelectList(db.Nacionalidad, "idNacionalidad", "descripcion", empleado.idNacionalidad);
            ViewBag.idPuesto = new SelectList(db.Puesto, "idPuesto", "descripcion", empleado.idPuesto);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleado.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", empleado.idUsuarioModifica);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
