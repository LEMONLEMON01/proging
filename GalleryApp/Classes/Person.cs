using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    [Table("Person")]
    abstract public class Person
    {
        public int Id { get; set; }
        public DateTime date_of_birth { get; set; }
        public string full_name { get; set; }

    }
}
