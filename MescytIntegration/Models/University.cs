using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MescytIntegration.Models
{
    public class University
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        public string name { get; set;}
        public string acronym { get; set; }

        public virtual ICollection<NewStudentsFat> NewStudentsFat { get; set; }
    }
}