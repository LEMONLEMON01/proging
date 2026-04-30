using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    [Table("Locations")]
    public class Location : Exhibition
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public virtual List<Painting> Paintings { get; set; } = new List<Painting>();

        public override string ToString()
        {
            return Name;
        }
    }
}
