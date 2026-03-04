using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{

    [Table("Authors")]
    public class Author : Person
    {
        public int Id { get; set; }

        [Range(0, 2100)]
        public int Year_of_birth { get; set; }
        [Range(0, 2100)]
        public int Year_of_death { get; set; }
        public virtual List<Person> Person { get; set; } = new List<Person>();

    }
}
