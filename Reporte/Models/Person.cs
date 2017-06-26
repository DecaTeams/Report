using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Person
    {

        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LName { get; set; }
        [Display(Name = "Full Name")]
        public string Name => FName + LName;
        [Display(Name = "Marreied")]
        public bool IsMarreid { get; set; }
        [Required]
        public int Age { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        
        public virtual Gender Gender { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Student Student { get; set; }
    }
}