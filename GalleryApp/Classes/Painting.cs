using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    public enum Status { restoration, storage, exhibition };
    public class Painting
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public int Cost { get; set; }
        [Range(0, 2100)]
        public int Year { get; set; }
        public Status Status { get; set; }

        public virtual List<Genre> Genres { get; set; } = new List<Genre>();
        public virtual List<Location> Locations { get; set; } = new List<Location>();
        public virtual List<Location> Authors { get; set; } = new List<Location>();

    }
}
