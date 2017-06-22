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
    public class tblProductsController : BaseController
    {
        private TestDBEntities db = new TestDBEntities();

        // GET: tblProducts
        public async Task<ActionResult> Index()
        {
            var tblProduct = db.tblProduct.Include(t => t.tblProductCategory);
            return View(await tblProduct.ToListAsync());
        }

        // GET: tblProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = await db.tblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // GET: tblProducts/Create
        public ActionResult Create()
        {
            var aux = db.tblProductCategory.ToDictionary(s => s.CatId,
                s => (s.CatNombre.PadRight(20) + s.CatObservacion).ToString().Replace(" ", "\xA0"));

            ViewBag.CatId = new SelectList(aux, "Key", "Value");
            //ViewBag.CatId = new SelectList(db.tblProductCategory, "CatId", "CatNombre");
            return View();
        }

        // POST: tblProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProdId,ProdNombre,CatId,Precio,ProdObservacion")] tblProduct tblProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.tblProduct.Add(tblProduct);
                    await db.SaveChangesAsync();

                    Success(string.Format("<b>{0}</b> fue exitosamente agregado.", tblProduct.ProdNombre), true);

                    //TempData["UserMessage"] = new { CssClassName = "alert-sucess", Title = "Success!", Message = "Operation Done." };

                    return RedirectToAction("Index");
                }

                ViewBag.CatId = new SelectList(db.tblProductCategory, "CatId", "CatNombre", tblProduct.CatId);
                return View(tblProduct);

            }
            catch (Exception)
            {
                throw;
            }

        }

        // GET: tblProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = await db.tblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatId = new SelectList(db.tblProductCategory, "CatId", "CatNombre", tblProduct.CatId);
            return View(tblProduct);
        }

        // POST: tblProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProdId,ProdNombre,CatId,Precio,ProdObservacion")] tblProduct tblProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CatId = new SelectList(db.tblProductCategory, "CatId", "CatNombre", tblProduct.CatId);
            return View(tblProduct);
        }

        // GET: tblProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct tblProduct = await db.tblProduct.FindAsync(id);
            if (tblProduct == null)
            {
                return HttpNotFound();
            }
            return View(tblProduct);
        }

        // POST: tblProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblProduct tblProduct = await db.tblProduct.FindAsync(id);
            db.tblProduct.Remove(tblProduct);
            await db.SaveChangesAsync();

            Danger(string.Format("<b>{0}</b> fue eliminado permanentemente.", tblProduct.ProdNombre), true);

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
