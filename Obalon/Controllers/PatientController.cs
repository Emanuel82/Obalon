using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obalon.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index(int id)
        {
            return View(Models.Patient.Get(id));
          //  return Content(ceva); //View();
        }

        // GET: Patient/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Patient/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public ActionResult Create (FormCollection collection)
        {
            try
            {
                using (var db = new Models.ObalonEntities())
                {
                    db.Patients.Add(new Models.Patient() { DoctorId = 77777, Gender = false, Height = 1110 });
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddEvent(int id)
        {
            return View(Models.PatientModel.Dummy); //RedirectToAction("Index");
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Patient/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patient/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        

    }
}
