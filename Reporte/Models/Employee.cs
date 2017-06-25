﻿using System;
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
        public int Id { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Department Department { get; set; }
    }
}