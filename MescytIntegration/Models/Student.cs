using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MescytIntegration.Models
{
    public class Student
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Genmunicipality { get; set; }
        public string CountryOfBirth { get; set; }
        public string CountryBeforeStartStudying { get; set; }

        public virtual ICollection<NewStudentsFat> NewStudentsFat { get; set; }
    }
}