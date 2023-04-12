using _3T.Gestproj.Domain.StaffSphere;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _3T.Gestproj.Persistence.PersistedObject
{
    [Table("People")]
    public class StoredPerson: Person
    {
        [JsonIgnore]
        [Key]
        public override int IdPerson { get => base.IdPerson; set => base.IdPerson = value; }
        [Computed]
        public override int Id { get => base.Id; set => base.Id = value; }
    }
}
