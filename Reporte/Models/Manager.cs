using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Manager
    {
        [Key]
        [Display(Name = "Manager Name")]
        public int Id { get; set; }

	    [Range(0,10000)]
	    [Column(TypeName = "numeric")]
		public int Salary { get; set; }

	    public virtual Employee Employee { get; set; }
        public virtual Department Department { get; set; }
    }
}