using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ContactMySQL.Models;

namespace ContactMySQL.Controllers
{
    public class JyuyodoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jyuyodoes
        public ActionResult Index()
        {
            return View(db.Jyuyodoes.ToList());
        }

        // GET: Jyuyodoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jyuyodo jyuyodo = db.Jyuyodoes.Find(id);
            if (jyuyodo == null)
            {
                return HttpNotFound();
            }
            return View(jyuyodo);
        }

        // GET: Jyuyodoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jyuyodoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Jyuyodo jyuyodo)
        {
            if (ModelState.IsValid)
            {
                db.Jyuyodoes.Add(jyuyodo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jyuyodo);
        }

        // GET: Jyuyodoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jyuyodo jyuyodo = db.Jyuyodoes.Find(id);
            if (jyuyodo == null)
            {
                return HttpNotFound();
            }
            return View(jyuyodo);
        }

        // POST: Jyuyodoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Jyuyodo jyuyodo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jyuyodo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jyuyodo);
        }

        // GET: Jyuyodoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jyuyodo jyuyodo = db.Jyuyodoes.Find(id);
            if (jyuyodo == null)
            {
                return HttpNotFound();
            }
            return View(jyuyodo);
        }

        // POST: Jyuyodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jyuyodo jyuyodo = db.Jyuyodoes.Find(id);
            db.Jyuyodoes.Remove(jyuyodo);
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
