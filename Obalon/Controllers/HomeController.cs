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
        private readonly ITicketValidator ticketValidator;

        public HomeController(ITicketValidator ticketValidator, IPatientService pacientService) : base(ticketValidator)
        {
            this.patientService = pacientService;
            this.ticketValidator = ticketValidator;
        }

        public ActionResult Index()
        {

            string x = patientService.Test();

            return View();
        }

    }
}