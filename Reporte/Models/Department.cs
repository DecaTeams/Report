using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}