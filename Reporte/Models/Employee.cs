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
        public int Id { get; set; }

        public string FullName { get; set; }
        //[ForeignKey("Department")]
        //public int DepartmentId { get; set; }
        //public int ManagerId { get; set; }
        
        public virtual Person Person { get; set; }
        //[ForeignKey("ManagerId")]
        //public virtual Manager Manager { get; set; }
        //public virtual Department Department { get; set; }
    }
}