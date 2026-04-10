using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    public enum StatusP { restoration, storage, exhibition };

    [Table("Painting")]
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int Cost { get; set; }
        [Range(0, 2100)]
        public int Year { get; set; }
        public StatusP StatusP { get; set; }
        public Location Location { get; set; }
        public virtual List<Genre> Genres { get; set; } = new List<Genre>();
        public virtual List<Author> Authors { get; set; } = new List<Author>();

    }
}
