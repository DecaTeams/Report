using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reporte.Models;
using Reporte.Repository;

namespace Reporte.Controllers
{
    public class EmployeesController : Controller
    {
        private Context db = new Context();

	    private readonly int _pageSize = 50;


		// GET: Employees
		public ActionResult Index()
		{
			var employees = db.Employees.OrderBy(e => e.Person.Name)
										.Include(e => e.Department);

			//var skip = (5 - 1) * _pageSize;
			//var employees = db.Employees.OrderBy(e => e.Person.Name)
			//	.Include(e => e.Department)
			//	.Skip(skip)
			//	.Take(10)
			//	.ToArray();

			//ViewBag.PreviousPage = 0;
			//ViewBag.NextPage = (Decimal.Divide(employees.Count(), _pageSize) > 1) ? 2 : -1;

			return View(employees.ToList());
        }
		//---------------------------------------------------
	    [Route("page/{page:int}")]
	    public ActionResult Page(int page = 1)
	    {
		    if (page < 50)
		    {
			    return RedirectToAction("index");
		    }
		    var skip = (5 - 1) * _pageSize;
		    var employees = db.Employees.OrderBy(e => e.Person.Name)
										.Include(e => e.Department)
										.Skip(skip)
										.Take(10)
										.ToArray();

			ViewBag.PreviousPage = page - 1;
		    ViewBag.NextPage = (Decimal.Divide(employees.Count(), _pageSize) > page) ? page + 1 : -1;

		    return View("index", employees);
	    }
		//---------------------------------------------------

		// GET: Employees/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "NameDepartment");
            ViewBag.Id = new SelectList(db.Persons, "Id", "FirstName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "NameDepartment", employee.DepartmentId);
            ViewBag.Id = new SelectList(db.Persons, "Id", "FirstName", employee.Id);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "NameDepartment", employee.DepartmentId);
            ViewBag.Id = new SelectList(db.Persons, "Id", "FirstName", employee.Id);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "NameDepartment", employee.DepartmentId);
            ViewBag.Id = new SelectList(db.Persons, "Id", "FirstName", employee.Id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
