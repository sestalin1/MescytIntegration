using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MescytIntegration.Models
{
    public class NewStudentsFat
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        
        public int StudentID { get; set; }
        public int CarreerID { get; set; }
        public int UniversityID { get; set; }

        public string period { get; set; }

        public virtual Carreer Carreer { get; set; }
        public virtual Student Student { get; set; }
        public virtual University University { get; set; }
    }
}