using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Manager
    {
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
    }
}