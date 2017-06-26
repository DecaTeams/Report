//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Web;

//namespace Reporte.Models
//{
//    public class Manager
//    {
//        [Key]
//        public int Id { get; set; }
//        public int EmployeeId { get; set; }

//        [ForeignKey("EmployeeId")]
//        public virtual Employee Employee { get; set; }
//        public virtual Department Department { get; set; }
//    }
//}