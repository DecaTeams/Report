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
        [Display(Name = "Department ID")]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        [RegularExpression(@"^([[\p{L}\s]{2,}|[\p{L}]{2,}])$")]
		public string NameDepartment { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}