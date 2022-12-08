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
    public class MunicipiosController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Municipios
        public ActionResult Index()
        {
            var municipio = db.Municipio.Include(m => m.Estado).Include(m => m.Usuario).Include(m => m.Usuario1);
            return View(municipio.ToList());
        }

        // GET: Municipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "descripcion");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: Municipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idMunicipio,codigo,descripcion,idEstado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Municipio.Add(municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "descripcion", municipio.idEstado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", municipio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", municipio.idUsuarioModifica);
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "descripcion", municipio.idEstado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", municipio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", municipio.idUsuarioModifica);
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idMunicipio,codigo,descripcion,idEstado,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(municipio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.Estado, "idEstado", "descripcion", municipio.idEstado);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", municipio.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", municipio.idUsuarioModifica);
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Municipio municipio = db.Municipio.Find(id);
            if (municipio == null)
            {
                return HttpNotFound();
            }
            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Municipio municipio = db.Municipio.Find(id);
            db.Municipio.Remove(municipio);
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
