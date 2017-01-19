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
    public class BushoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bushoes
        public ActionResult Index()
        {
            return View(db.Bushos.ToList());
        }

        // GET: Bushoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Busho busho = db.Bushos.Find(id);
            if (busho == null)
            {
                return HttpNotFound();
            }
            return View(busho);
        }

        // GET: Bushoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bushoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Busho busho)
        {
            if (ModelState.IsValid)
            {
                db.Bushos.Add(busho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(busho);
        }

        // GET: Bushoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Busho busho = db.Bushos.Find(id);
            if (busho == null)
            {
                return HttpNotFound();
            }
            return View(busho);
        }

        // POST: Bushoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Busho busho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(busho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(busho);
        }

        // GET: Bushoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Busho busho = db.Bushos.Find(id);
            if (busho == null)
            {
                return HttpNotFound();
            }
            return View(busho);
        }

        // POST: Bushoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Busho busho = db.Bushos.Find(id);
            db.Bushos.Remove(busho);
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
