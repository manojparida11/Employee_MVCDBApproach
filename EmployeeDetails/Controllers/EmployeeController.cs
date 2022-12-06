using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EmployeeDetails.Models;

namespace EmployeeDetails.Controllers
{
    public class EmployeeController : Controller
    {
        private db_employeeEntities db = new db_employeeEntities();

        // GET: Employee
        public ActionResult Index()
        {
            return View(db.tbl_employeeinfo.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employeeinfo tbl_employeeinfo = db.tbl_employeeinfo.Find(id);
            if (tbl_employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employeeinfo);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] tbl_employeeinfo tbl_employeeinfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tbl_employeeinfo.Add(tbl_employeeinfo);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tbl_employeeinfo);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] tbl_employeeinfo tbl_employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.tbl_employeeinfo.Add(tbl_employeeinfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_employeeinfo);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employeeinfo tbl_employeeinfo = db.tbl_employeeinfo.Find(id);
            if (tbl_employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employeeinfo);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,EmpName,EmpContact,EmpAddress,EmpDept")] tbl_employeeinfo tbl_employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_employeeinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_employeeinfo);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_employeeinfo tbl_employeeinfo = db.tbl_employeeinfo.Find(id);
            if (tbl_employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_employeeinfo);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_employeeinfo tbl_employeeinfo = db.tbl_employeeinfo.Find(id);
            db.tbl_employeeinfo.Remove(tbl_employeeinfo);
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
