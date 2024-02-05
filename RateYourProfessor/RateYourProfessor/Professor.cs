using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateYourProfessor
{
    public class Professor
    {
        public int ID { get; set; } // or use Guid for UUID
        public string Name { get; set; }

        public List<Rating> Ratings { get; set; }
        // Constructor
        public Professor(int id, string name)
        {
            ID = id;
            Name = name;
            Ratings = new List<Rating>();
        }
    }
}
