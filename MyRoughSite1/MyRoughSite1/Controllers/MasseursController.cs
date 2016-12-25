using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyRoughSite1.Models;

namespace MyRoughSite1.Controllers
{
    public class MasseursController : Controller
    {
        private MasseurContext db = new MasseurContext();

        // GET: Masseurs
        public async Task<ActionResult> Index()
        {
            return View(await db.Masseurs.ToListAsync());
        }

        // GET: Masseurs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masseur masseur = await db.Masseurs.FindAsync(id);
            if (masseur == null)
            {
                return HttpNotFound();
            }
            return View(masseur);
        }

        public ActionResult ToList()
        {
            var masseurs = db.Masseurs;
            return View(masseurs.ToList());
        }

        // GET: Masseurs/Create
        public ActionResult Create()
        {
            ViewBag.Genders = new SelectList(new List<char> { 'М', 'Ж' });
            return View();
        }

        // POST: Masseurs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,Description")] Masseur masseur)
        {
            if (ModelState.IsValid)
            {
                db.Masseurs.Add(masseur);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(masseur);
        }

        // GET: Masseurs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masseur masseur = await db.Masseurs.FindAsync(id);
            if (masseur == null)
            {
                return HttpNotFound();
            }
            ViewBag.Genders = new SelectList(new List<char> { 'М', 'Ж' });
            return View(masseur);
        }

        // POST: Masseurs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Gender,Description")] Masseur masseur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masseur).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(masseur);
        }

        // GET: Masseurs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Masseur masseur = await db.Masseurs.FindAsync(id);
            if (masseur == null)
            {
                return HttpNotFound();
            }
            return View(masseur);
        }

        // POST: Masseurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Masseur masseur = await db.Masseurs.FindAsync(id);
            db.Masseurs.Remove(masseur);
            await db.SaveChangesAsync();
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
