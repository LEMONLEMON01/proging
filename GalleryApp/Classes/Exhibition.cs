using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    public abstract class Exhibition
    {
        public int Id { get; set; }
        public String Street_Name { get; set; }
        [Range(1, 1000)]
        public int House_Number { get; set; }
        [MaxLength(250)]
        public String City { get; set; }
    }
}
