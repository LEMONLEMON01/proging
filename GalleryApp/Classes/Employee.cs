using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Classes
{
    public enum Position { Restorator, Manager, Admin };
    public enum Access { Add, Change, Delete };

    [Table("Employees")]
    public class Employee : Person
    {
        public int Id { get; set; }
        public Position Position { get; set; }
        [MaxLength(200)]

        public string Accesses { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public virtual List<Move_history> Move_Histories { get; set; } = new List<Move_history>();

        public override string ToString()
        {
            return $"{full_name}";
        }
    }
}
