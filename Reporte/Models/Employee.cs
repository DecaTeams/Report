using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Employee
    {
        [Key]
        [ForeignKey("Person")]
        [Required]
        [Display(Name = "Employee Name")]
        public int Id { get; set; }
	    //[Range(typeof(decimal), "0", "79228162514264337593543950335")]
		[Range(0,10000)]
		[Column(TypeName = "numeric")]
		public int Salary { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department Name")]
        public int? DepartmentId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Department Department { get; set; }
    }
}