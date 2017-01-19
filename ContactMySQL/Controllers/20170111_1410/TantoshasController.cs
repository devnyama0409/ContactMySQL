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
    public class TantoshasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tantoshas
        public ActionResult Index()
        {
            var tantoshas = db.Tantoshas.Include(t => t.Busho);
            return View(tantoshas.ToList());
        }

        // GET: Tantoshas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tantosha tantosha = db.Tantoshas.Find(id);
            if (tantosha == null)
            {
                return HttpNotFound();
            }
            return View(tantosha);
        }

        // GET: Tantoshas/Create
        public ActionResult Create()
        {
            ViewBag.BushoId = new SelectList(db.Bushos, "Id", "Name");
            return View();
        }

        // POST: Tantoshas/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Kana,ShortName,BushoId")] Tantosha tantosha)
        {
            if (ModelState.IsValid)
            {
                db.Tantoshas.Add(tantosha);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BushoId = new SelectList(db.Bushos, "Id", "Name", tantosha.BushoId);
            return View(tantosha);
        }

        // GET: Tantoshas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tantosha tantosha = db.Tantoshas.Find(id);
            if (tantosha == null)
            {
                return HttpNotFound();
            }
            ViewBag.BushoId = new SelectList(db.Bushos, "Id", "Name", tantosha.BushoId);
            return View(tantosha);
        }

        // POST: Tantoshas/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Kana,ShortName,BushoId")] Tantosha tantosha)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tantosha).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BushoId = new SelectList(db.Bushos, "Id", "Name", tantosha.BushoId);
            return View(tantosha);
        }

        // GET: Tantoshas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tantosha tantosha = db.Tantoshas.Find(id);
            if (tantosha == null)
            {
                return HttpNotFound();
            }
            return View(tantosha);
        }

        // POST: Tantoshas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tantosha tantosha = db.Tantoshas.Find(id);
            db.Tantoshas.Remove(tantosha);
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
