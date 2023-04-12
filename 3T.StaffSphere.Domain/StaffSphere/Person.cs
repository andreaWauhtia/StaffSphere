using _3T.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _3T.StaffSphere.Domain.StaffSphere
{
    public class Person: IEntity
    {
        
        public virtual int IdPerson { get; set; }
        public virtual int Id { get => IdPerson; set => IdPerson = value; }
        public DateTime BirthDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Gender Gender { get; set; }
       
    }

    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

}
