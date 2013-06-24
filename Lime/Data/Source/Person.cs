using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using Lime.Data.Source;

namespace Lime.Data.Source
{
    [TableName("Persons")]
    public class Person
    {
        [PrimaryKey, Identity]
        [MapField("PersonId")]
        public int Id;

        [NotNull]
        [MapField("PersonFullName")]
        public string FullName { get; set; }

        [NotNull] [MapField("PersonCode")] 
        public string Code;

        [NotNull]
        [MapField("PersonGender")] 
        public int GenderId;

        [Association(ThisKey = "GenderId", OtherKey = "Id")]
        public Gender Gender;

        [Association(ThisKey = "Id", OtherKey = "PersonId")]
        public List<Parameter> Parameters;
    }
}