using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateYourProfessor
{
    public class Rating
    {
        public int ID { get; set; } // or use Guid for UUID
        public int ProfessorID { get; set; }
        public int CategoryID { get; set; }
        public int Value { get; set; }

        // Constructor
        public Rating(int id, int professorID, int categoryID, int value)
        {
            ID = id;
            ProfessorID = professorID;
            CategoryID = categoryID;
            Value = value;
        }
    }
}
