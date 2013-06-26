using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Lime.Data.Source
{
    [TableName("Persons")]
    public class Person
    {
        [PrimaryKey, Identity]
        [MapField("PersonId")]
        public int Id { get; set; }

    

        [NotNull]
        [MapField("PersonFullName")]
        public string FullName { get; set; }

        [NotNull] 
        [MapField("PersonCode")]
        public string Code { get; set; }

        [NotNull]
        [MapField("PersonGender")]
        public int GenderId { get; set; }

        [Association(ThisKey = "GenderId", OtherKey = "Id")]
        public Gender Gender { get; set; }

        [Association(ThisKey = "Id", OtherKey = "PersonId")]
        public List<Parameter> Parameters { get; set; }
    }
}