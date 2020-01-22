using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GerenciadorNegocios.Data;
using GerenciadorNegocios.Models;

namespace GerenciadorNegocios.Controllers
{
    public class NegociosController : Controller
    {
        private GerenciadorNegociosContext db = new GerenciadorNegociosContext();

        // GET: Negocios
        public ActionResult Index()
        {
            var negocios = db.Negocios.Include(n => n.Cliente).Include(n => n.Produto);
            return View(negocios.ToList());
        }

        // GET: Negocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // GET: Negocios/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "Id", "Descricao");
            return View();
        }

        // POST: Negocios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Etapas,ClienteId,ProdutoId,Valor")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Negocios.Add(negocio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", negocio.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "Id", "Descricao", negocio.ProdutoId);
            return View(negocio);
        }

        // GET: Negocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", negocio.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "Id", "Descricao", negocio.ProdutoId);
            return View(negocio);
        }

        // POST: Negocios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Etapas,ClienteId,ProdutoId,Valor")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(negocio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", negocio.ClienteId);
            ViewBag.ProdutoId = new SelectList(db.Produtoes, "Id", "Descricao", negocio.ProdutoId);
            return View(negocio);
        }

        // GET: Negocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = db.Negocios.Find(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Negocio negocio = db.Negocios.Find(id);
            db.Negocios.Remove(negocio);
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
