using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_postgres2
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

       // public Groupp? Groupp { get; set; }
        public List<Visit>? Visit { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
