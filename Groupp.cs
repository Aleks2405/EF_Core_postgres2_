using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_postgres2
{
    public class Groupp
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        List<Student>? Students { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
