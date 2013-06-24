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
        private string _personCode ;

        [PrimaryKey, Identity]
        public int PersonId;
        [NotNull]
        public string PersonFullName { get; set; }
        [NotNull]
        public string PersonCode {
            get { return _personCode; }
            set
            {
                //Todo: Check count and signs
                _personCode = value;
            }
        }


        [Association(ThisKey = "PersonGender", OtherKey = "GenderId")]
        public Gender PersonGender;

        [Association(ThisKey = "PersonId", OtherKey = "PersonId")]
        public List<Parameter> Parameters;
    }
}