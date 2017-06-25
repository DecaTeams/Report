using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class PeopleViewModel
    {
        public int GenderId { get; set; }
        public IList<Gender> Gender { get; set; }
        public Person Person { get; set; }
    }
}