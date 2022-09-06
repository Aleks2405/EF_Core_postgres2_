using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF_Core_postgres2
{
    public class Visit
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
     
        public Student? Student { get; set; } 
        public Subject? Subject { get; set; }
    }
}
