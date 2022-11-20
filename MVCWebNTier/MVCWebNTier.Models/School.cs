using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNTier.Models
{
    public class School
    {
        public string SchoolID { get; set; }
        public string SchoolName { get; set; }
        ICollection<Student> Students { get; set; }
    }
}
