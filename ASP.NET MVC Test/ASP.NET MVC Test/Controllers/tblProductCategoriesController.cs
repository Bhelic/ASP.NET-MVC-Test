using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_Test.Models;

namespace ASP.NET_MVC_Test.Controllers
{
    public class tblProductCategoriesController : Controller
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: tblProductCategories
        public async Task<ActionResult> Index()
        {
            return View(await db.tblProductCategory.ToListAsync());
        }

        // GET: tblProductCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductCategory tblProductCategory = await db.tblProductCategory.FindAsync(id);
            if (tblProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblProductCategory);
        }

        // GET: tblProductCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblProductCategories/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CatId,CatNombre,CatObservacion")] tblProductCategory tblProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.tblProductCategory.Add(tblProductCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblProductCategory);
        }

        // GET: tblProductCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductCategory tblProductCategory = await db.tblProductCategory.FindAsync(id);
            if (tblProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblProductCategory);
        }

        // POST: tblProductCategories/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CatId,CatNombre,CatObservacion")] tblProductCategory tblProductCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProductCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblProductCategory);
        }

        // GET: tblProductCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProductCategory tblProductCategory = await db.tblProductCategory.FindAsync(id);
            if (tblProductCategory == null)
            {
                return HttpNotFound();
            }
            return View(tblProductCategory);
        }

        // POST: tblProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblProductCategory tblProductCategory = await db.tblProductCategory.FindAsync(id);
            db.tblProductCategory.Remove(tblProductCategory);
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
