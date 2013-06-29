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

        public string GenderImageUrl() {
            //Todo Get Data from DataBase
            string url;
            switch (GenderId)
            {
                case 1:
                    url = @"/Theme/Images/gender-male.png";
                    break;
                case 2:
                    url = @"/Theme/Images/gender-female.png";
                    break;
                case 3:
                    url = @"/Theme/Images/gender-unknown.png";
                    break;
                case 4:
                    url = @"/Theme/Images/gender-other.png";
                    break;
                default:
                    url = @"/Theme/Images/gender-unknown.png";
                    break;
            }
            return url;
        }
    }
}