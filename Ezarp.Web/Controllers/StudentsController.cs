using Ezarp.Data.Models;
using Ezarp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ezarp.Web.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Student
        IStudentData data;
        public StudentsController(IStudentData data)
        {
            this.data = data;
        }
        public ActionResult Index()
        {
            var model = data.GetAll();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = data.Get(id);
            if (model == null)
            {
                return View("Student not found");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                data.Add(student);
                return RedirectToAction("Details", new { id = student.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = data.Get(id);
            if (model == null)
            {
                return View();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                data.Update(student);
                return RedirectToAction("Details", new { id = student.Id });
            }
            return View();
            
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = data.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection form)
        {
            data.Delete(id);
            return RedirectToAction("Index");
        }
    }
}