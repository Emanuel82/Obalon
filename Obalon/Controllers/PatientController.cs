using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Obalon.Services;
using Obalon.Utils;
using Obalon.Models;

namespace Obalon.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService patientService;
        private readonly ITicketValidator ticketValidator;

        public PatientController(ITicketValidator ticketValidator, IPatientService pacientService) : base(ticketValidator)
        {
            this.patientService = pacientService;
        }

        // GET: Patient
        public ActionResult Index(int? id)
        {
            if (!UserLoggedIn())
            {
                return Redirect("~/Home/Index");
            }

            ResponseItemList<Patient> patients = null;

            if (!id.HasValue)
                patients = patientService.GetPatients(77777);
            else
                patients = patientService.GetPatients(id.Value);

            return View(patients);
        }

        public ActionResult Details(int id)
        {
            ResponseItem<Patient> patient = patientService.GetPatient(id);

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
                bool gender = collection["Gender"] == "Male";
                int heightFt = Int32.Parse(collection["heigthFt"]);
                int heightIn = Int32.Parse(collection["heightIn"]);

                int age = Int32.Parse(collection["years"]);

                patientService.Add(new Patient() { Gender = gender, HeightFt = heightFt, HeightIn = heightIn, Age = age });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult AddEvent(int id)
        {
            return View(); //RedirectToAction("Index");
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
