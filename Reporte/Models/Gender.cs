using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reporte.Models
{
    public class Gender
    {
        public Gender()
        {
            Persons = new HashSet<Person>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}