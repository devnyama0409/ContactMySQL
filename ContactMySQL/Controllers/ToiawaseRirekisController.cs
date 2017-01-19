using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactMySQL.Models;
using PagedList;

namespace ContactMySQL.Controllers
{
    public class ToiawaseRirekisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToiawaseRirekis
        public ActionResult Index(int? page)
        {
            int pageSize = 3;
            int pageNumber = page ?? 1;

            //var toiawaseRirekis = db.ToiawaseRirekis.Include(t => t.Jyuyodo);
            //return View(toiawaseRirekis.ToList());
            return View(db.ToiawaseRirekis.OrderBy(t => t.Id).ToPagedList(pageNumber, pageSize));
        }

        // GET: ToiawaseRirekis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToiawaseRireki toiawaseRireki = db.ToiawaseRirekis.Find(id);
            if (toiawaseRireki == null)
            {
                return HttpNotFound();
            }
            return View(toiawaseRireki);
        }

        // GET: ToiawaseRirekis/Create
        public ActionResult Create()
        {
            ViewBag.TantoshaId = new SelectList(db.Tantoshas, "Id", "Name");
            ViewBag.UketsukeshaId = new SelectList(db.Tantoshas, "Id", "Name");
            ViewBag.JyuyodoId = new SelectList(db.Jyuyodoes, "Id", "Name");
            ViewBag.ShafukuUserId = new SelectList(db.ShafukuUsers, "Id", "Name");
            ViewBag.SystemId = new SelectList(db.SystemMasters, "Id", "Name");
            ViewBag.BunruiId = new SelectList(db.Bunruis, "Id", "Name");

            ViewBag.Shoribi = DateTime.Today.ToString("yyyy-MM-dd");
            ViewBag.Kanryobi = DateTime.Today.ToString("yyyy-MM-dd");

            return View();
        }

        // POST: ToiawaseRirekis/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Shoribi,TantoshaId,UserId,UserTantoshaMei,SystemId,BunruiId,ShoriJikan,JyuyodoId,Naiyo,Taio,Kanryobi,UketsukeshaMei,Toiawasesaki")] ToiawaseRireki toiawaseRireki)
        {
            if (ModelState.IsValid)
            {
                db.ToiawaseRirekis.Add(toiawaseRireki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JyuyodoId = new SelectList(db.Jyuyodoes, "Id", "Name", toiawaseRireki.JyuyodoId);
            return View(toiawaseRireki);
        }

        // GET: ToiawaseRirekis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToiawaseRireki toiawaseRireki = db.ToiawaseRirekis.Find(id);
            if (toiawaseRireki == null)
            {
                return HttpNotFound();
            }
            ViewBag.JyuyodoId = new SelectList(db.Jyuyodoes, "Id", "Name", toiawaseRireki.JyuyodoId);
            return View(toiawaseRireki);
        }

        // POST: ToiawaseRirekis/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Shoribi,TantoshaId,UserId,UserTantoshaMei,SystemId,BunruiId,ShoriJikan,JyuyodoId,Naiyo,Taio,Kanryobi,UketsukeshaMei,Toiawasesaki")] ToiawaseRireki toiawaseRireki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toiawaseRireki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JyuyodoId = new SelectList(db.Jyuyodoes, "Id", "Name", toiawaseRireki.JyuyodoId);
            return View(toiawaseRireki);
        }

        // GET: ToiawaseRirekis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToiawaseRireki toiawaseRireki = db.ToiawaseRirekis.Find(id);
            if (toiawaseRireki == null)
            {
                return HttpNotFound();
            }
            return View(toiawaseRireki);
        }

        // POST: ToiawaseRirekis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToiawaseRireki toiawaseRireki = db.ToiawaseRirekis.Find(id);
            db.ToiawaseRirekis.Remove(toiawaseRireki);
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
