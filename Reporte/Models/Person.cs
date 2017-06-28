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
        [RegularExpression(@"^([[\p{L}\s]{2,}|[\p{L}]{2,}])$")]
		[Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"^([[\p{L}\s]{2,}|[\p{L}]{2,}])$")]
		[Required]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Name {
	        get { return FirstName + " " + LastName; }
	         private set { }
        }
        [Display(Name = "Marreied")]
        public bool IsMarreid { get; set; }
        [Required]
        public int Age { get; set; }
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        
        public virtual Gender Gender { get; set; }
        public virtual Employee Employee { get; set; }
    }
}