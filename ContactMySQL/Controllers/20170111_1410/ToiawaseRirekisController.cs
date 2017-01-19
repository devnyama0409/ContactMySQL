using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ContactMySQL.Models;

namespace ContactMySQL.Controllers
{
    public class ToiawaseRirekisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToiawaseRirekis
        public ActionResult Index()
        {
            return View(db.ToiawaseRirekis.ToList());
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
            

            return View();
        }

        // POST: ToiawaseRirekis/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Shoribi,TantoshaCode,UserCode,UserTantoshaMei,SystemCode,BunruiCode,ShoriJikan,JyuyodoCode,Naiyo,Taio,Kanryobi,UketsukeshaMei,Toiawasesaki")] ToiawaseRireki toiawaseRireki)
        {
            if (ModelState.IsValid)
            {
                db.ToiawaseRirekis.Add(toiawaseRireki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(toiawaseRireki);
        }

        // POST: ToiawaseRirekis/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Shoribi,TantoshaCode,UserCode,UserTantoshaMei,SystemCode,BunruiCode,ShoriJikan,JyuyodoCode,Naiyo,Taio,Kanryobi,UketsukeshaMei,Toiawasesaki")] ToiawaseRireki toiawaseRireki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toiawaseRireki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
