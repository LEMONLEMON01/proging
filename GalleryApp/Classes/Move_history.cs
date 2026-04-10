using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    [Table("Move_histories")]
    public class Move_history
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public Location location_from { get; set; }
        public Location location_to { get; set; }
        public virtual List<Employee> employees { get; set; } = new List<Employee>();
        public virtual List<Painting> paintings { get; set; } = new List<Painting>();

    }
}
