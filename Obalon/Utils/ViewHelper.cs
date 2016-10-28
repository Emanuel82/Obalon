using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obalon.Services;

namespace Obalon.Utils
{
    public class ViewHelper
    {
        private static ViewHelper instance;
        private ITicketValidator ticketValidator;

        public static ViewHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new ViewHelper();

                return instance;
            }
        }


        private ViewHelper()
        {

            ticketValidator = new TicketValidator(ubiServices, keyStorageProxy, logger);

        }
    }
}