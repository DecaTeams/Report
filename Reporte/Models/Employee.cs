using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public virtual Person Person { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Department Departments { get; set; }
    }
}