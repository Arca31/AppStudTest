using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStudTest
{
    public class Contact
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string status { get; set; }
        public string hisface { get; set; }
        public string fullname()
        {
            return firstname + " " + lastname;
        }

    }
}
