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
    public class TipoDeProductoesController : Controller
    {
        private TiendaEntities db = new TiendaEntities();

        // GET: TipoDeProductoes
        public ActionResult Index()
        {
            var tipoDeProducto = db.TipoDeProducto.Include(t => t.Usuario).Include(t => t.Usuario1);
            return View(tipoDeProducto.ToList());
        }

        // GET: TipoDeProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProducto tipoDeProducto = db.TipoDeProducto.Find(id);
            if (tipoDeProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProducto);
        }

        // GET: TipoDeProductoes/Create
        public ActionResult Create()
        {
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario");
            return View();
        }

        // POST: TipoDeProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTipoDeProducto,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProducto tipoDeProducto)
        {
            if (ModelState.IsValid)
            {
                db.TipoDeProducto.Add(tipoDeProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProducto.idUsuarioModifica);
            return View(tipoDeProducto);
        }

        // GET: TipoDeProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProducto tipoDeProducto = db.TipoDeProducto.Find(id);
            if (tipoDeProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProducto.idUsuarioModifica);
            return View(tipoDeProducto);
        }

        // POST: TipoDeProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTipoDeProducto,tipo,estatus,idUsuarioCrea,fechaCrea,idUsuarioModifica,fechaModifica")] TipoDeProducto tipoDeProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDeProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idUsuarioCrea = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProducto.idUsuarioCrea);
            ViewBag.idUsuarioModifica = new SelectList(db.Usuario, "idUsuario", "nombreUsuario", tipoDeProducto.idUsuarioModifica);
            return View(tipoDeProducto);
        }

        // GET: TipoDeProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDeProducto tipoDeProducto = db.TipoDeProducto.Find(id);
            if (tipoDeProducto == null)
            {
                return HttpNotFound();
            }
            return View(tipoDeProducto);
        }

        // POST: TipoDeProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDeProducto tipoDeProducto = db.TipoDeProducto.Find(id);
            db.TipoDeProducto.Remove(tipoDeProducto);
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
