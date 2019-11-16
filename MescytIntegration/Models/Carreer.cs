using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MescytIntegration.Models
{
    public class Carreer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public string Modality { get; set; }

        public virtual ICollection<NewStudentsFat> NewStudentsFat { get; set; }

    }
}