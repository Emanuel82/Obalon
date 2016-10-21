using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Obalon.Services;

namespace Obalon.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IPatientService patientService;

        public HomeController(IPatientService pacientService)
        {
            this.patientService = pacientService;
        }

        public ActionResult Index()
        {

            string x = patientService.Test();

            return View();
        }

    }
}