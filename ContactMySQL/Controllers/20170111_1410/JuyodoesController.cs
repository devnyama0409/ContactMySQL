using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactMySQL.Models;

namespace ContactMySQL.Controllers
{
    public class JuyodoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Juyodoes
        public ActionResult Index()
        {
            return View(db.Juyodoes.ToList());
        }

        // GET: Juyodoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juyodo juyodo = db.Juyodoes.Find(id);
            if (juyodo == null)
            {
                return HttpNotFound();
            }
            return View(juyodo);
        }

        // GET: Juyodoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Juyodoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Juyodo juyodo)
        {
            if (ModelState.IsValid)
            {
                db.Juyodoes.Add(juyodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(juyodo);
        }

        // GET: Juyodoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juyodo juyodo = db.Juyodoes.Find(id);
            if (juyodo == null)
            {
                return HttpNotFound();
            }
            return View(juyodo);
        }

        // POST: Juyodoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Juyodo juyodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(juyodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(juyodo);
        }

        // GET: Juyodoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Juyodo juyodo = db.Juyodoes.Find(id);
            if (juyodo == null)
            {
                return HttpNotFound();
            }
            return View(juyodo);
        }

        // POST: Juyodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Juyodo juyodo = db.Juyodoes.Find(id);
            db.Juyodoes.Remove(juyodo);
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
