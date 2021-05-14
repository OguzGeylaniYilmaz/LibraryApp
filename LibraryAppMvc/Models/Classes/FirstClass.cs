using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryAppMvc.Models.Entity;

namespace LibraryAppMvc.Models.Classes
{
    public class FirstClass
    {
        public IEnumerable<Kitaplar> Deger1 { get; set; }
        public IEnumerable<Hakkimizda> Deger2 { get; set; }
    }
}