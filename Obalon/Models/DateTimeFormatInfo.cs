using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obalon.Models
{
    public class DateTimeFormatInfo
    {
        public int UtcHours { get; set; }
        public int UtcMinutes { get; set; }
        public string DateTimeFormat { get; set; }

        public DateTimeFormatInfo()
        {
            // default values
            this.DateTimeFormat = "F";
            this.UtcHours = 0;
            this.UtcMinutes = 0;
        }
    }
}