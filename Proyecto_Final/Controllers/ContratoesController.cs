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
    public class ContratoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Contratoes
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Empleado).Include(c => c.Usuario).Include(c => c.Usuario1);
            return View(contrato.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Contratoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContrato,codigo,fechaInicio,fechaTermino,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", contrato.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", contrato.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", contrato.idUsuarioModifica);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", contrato.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", contrato.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", contrato.idUsuarioModifica);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContrato,codigo,fechaInicio,fechaTermino,idEmpleado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "apellidoPaterno", contrato.idEmpleado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", contrato.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", contrato.idUsuarioModifica);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
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
