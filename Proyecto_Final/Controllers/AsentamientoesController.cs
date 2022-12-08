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
    public class AsentamientoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: Asentamientoes
        public ActionResult Index()
        {
            var asentamiento = db.Asentamiento.Include(a => a.Municipio).Include(a => a.TipoDeAsentamiento).Include(a => a.Usuario).Include(a => a.Usuario1).Include(a => a.Zona);
            return View(asentamiento.ToList());
        }

        // GET: Asentamientoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // GET: Asentamientoes/Create
        public ActionResult Create()
        {
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "codigo");
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamiento, "idTipoDeAsentamiento", "tipo");
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre");
            return View();
        }

        // POST: Asentamientoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAsentamiento,id,descripcion,codigoPostal,idTipoDeAsentamiento,idMunicipio,idZona,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Asentamiento.Add(asentamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "codigo", asentamiento.idMunicipio);
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamiento, "idTipoDeAsentamiento", "tipo", asentamiento.idTipoDeAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", asentamiento.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre", asentamiento.idZona);
            return View(asentamiento);
        }

        // GET: Asentamientoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "codigo", asentamiento.idMunicipio);
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamiento, "idTipoDeAsentamiento", "tipo", asentamiento.idTipoDeAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", asentamiento.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre", asentamiento.idZona);
            return View(asentamiento);
        }

        // POST: Asentamientoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAsentamiento,id,descripcion,codigoPostal,idTipoDeAsentamiento,idMunicipio,idZona,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] Asentamiento asentamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asentamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMunicipio = new SelectList(db.Municipio, "idMunicipio", "codigo", asentamiento.idMunicipio);
            ViewBag.idTipoDeAsentamiento = new SelectList(db.TipoDeAsentamiento, "idTipoDeAsentamiento", "tipo", asentamiento.idTipoDeAsentamiento);
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", asentamiento.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", asentamiento.idUsuarioModifica);
            ViewBag.idZona = new SelectList(db.Zona, "idZona", "nombre", asentamiento.idZona);
            return View(asentamiento);
        }

        // GET: Asentamientoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            if (asentamiento == null)
            {
                return HttpNotFound();
            }
            return View(asentamiento);
        }

        // POST: Asentamientoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asentamiento asentamiento = db.Asentamiento.Find(id);
            db.Asentamiento.Remove(asentamiento);
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
