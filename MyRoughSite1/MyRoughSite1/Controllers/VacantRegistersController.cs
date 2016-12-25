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
using MyRoughSite1.Helpers;

namespace MyRoughSite1.Controllers
{
    public class VacantRegistersController : Controller
    {
        private MasseurContext db = new MasseurContext();

        // GET: VacantRegisters
        public async Task<ActionResult> Index()
        {
            var registers = db.VacantRegisters.Include(p => p.Masseur);
            return View(await registers.ToListAsync());
        }

        // GET: VacantRegisters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacantRegister vacantRegister = await db.VacantRegisters.FindAsync(id);
            if (vacantRegister == null)
            {
                return HttpNotFound();
            }
            return View(vacantRegister);
        }

        // GET: VacantRegisters/Create
        public ActionResult Create()
        {
            SelectList masseurs = new SelectList(db.Masseurs, "Id", "Name");
            ViewBag.Masseurs = masseurs;
            ViewBag.CurrentDate = DateTime.Now;
            return View();
        }

        // POST: VacantRegisters/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int[] calendar, [Bind(Include = "Id,DateTime,Duration,MasseurId")] VacantRegister vacantRegister)
        {
            if (ModelState.IsValid)
            {
                db.VacantRegisters.Add(vacantRegister);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vacantRegister);
        }

        [HttpPost]
        public ActionResult ReloadCalendar(DateTime monthToDisplay)
        {
            ViewBag.Calendar = CalendarHelper.CreateCalendar(monthToDisplay);
            return PartialView();
        }

        [HttpPost]
        public ActionResult GetTimes()
        {
            ViewBag.TimeSpans = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0) };
            return PartialView();
        }

        // GET: VacantRegisters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacantRegister vacantRegister = await db.VacantRegisters.FindAsync(id);
            if (vacantRegister == null)
            {
                return HttpNotFound();
            }
            return View(vacantRegister);
        }

        // POST: VacantRegisters/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,DateTime,MasseurId,Duration")] VacantRegister vacantRegister)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacantRegister).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vacantRegister);
        }

        // GET: VacantRegisters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VacantRegister vacantRegister = await db.VacantRegisters.FindAsync(id);
            if (vacantRegister == null)
            {
                return HttpNotFound();
            }
            return View(vacantRegister);
        }

        // POST: VacantRegisters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VacantRegister vacantRegister = await db.VacantRegisters.FindAsync(id);
            db.VacantRegisters.Remove(vacantRegister);
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
