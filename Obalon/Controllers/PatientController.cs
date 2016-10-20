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
        public ActionResult Index(int? id = null)
        {
            if (!id.HasValue)
                id = 77777;


            List<Models.Patient> patients = new List<Models.Patient>();
            using (var context = new Models.ObalonEntities())
            {
                patients = (from p in context.Patients where p.DoctorId == id select p).ToList();
            }
            return View(patients);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                using (var db = new Models.ObalonEntities())
                {
                    int docId = 77777;
                    bool gender = collection["Gender"] == "Male";
                    int heightFt = Int32.Parse(collection["heigthFt"]);
                    int heightIn = Int32.Parse(collection["heightIn"]);

                    int age = Int32.Parse(collection["years"]);


                    db.Patients.Add(new Models.Patient() { DoctorId = docId, Gender = gender, HeightFt = heightFt, HeightIn = heightIn, Age = age });
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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
