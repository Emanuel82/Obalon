using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obalon.Utils
{
    public class ResponseItemList<T>
    {
        public ICollection<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }
}
