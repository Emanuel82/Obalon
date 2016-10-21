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

        public HomeController(IPatientService pacientService)
        {
            this.pacientService = pacientService;
        }

        public ActionResult Index()
        {

            string x = pacientService.Test();

            return View();
        }

    }
}