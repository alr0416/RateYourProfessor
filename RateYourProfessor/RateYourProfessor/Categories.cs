using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RateYourProfessor
{
    public class Categories
    {
        public int ID { get; set; } // or use Guid for UUID
        public string Name { get; set; }
        public string Description { get; set; }

        // Constructor
        public Categories(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
