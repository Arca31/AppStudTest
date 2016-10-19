using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppStudTest
{
    public class RootObject
    {
        public List<Contact> contacts { get; set; }
        public List<Boolean> Bookmarked { get; set; }

    }
}
