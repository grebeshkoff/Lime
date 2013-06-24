using System;
using System.Linq;
using Lime.Data.Source;
using NUnit.Framework;

namespace LimeTest.Data.Source
{
    [TestFixture]
    internal class SourceTest
    {
        [Test]
        public void GenderTest()
        {
            using (var db = new LimeDataBase())
            {
                var query = db.Genders;
                foreach (var gender in query)
                {
                    Console.WriteLine("{0} {1}", gender.Id , gender.Name);
                }
            }
        }

        [Test]
        public void PersonTest()
        {
            using (var db = new LimeDataBase())
            {
                var query = from person in db.Persons
                            select new
                                {
                                    FullName = person.FullName,
                                    Gender = person.Gender
                                };
                foreach (var person in query)
                {
                    Console.WriteLine("{0} : {1}", person.FullName, person.Gender.Name);
                }
            }
        }

        [Test]
        public void ParameterTest()
        {
            using (var db = new LimeDataBase())
            {
                var query = db.Parameters;
                foreach (var param in query)
                {
                    Console.WriteLine("{0} {1}", param.Name, param.Value);
                }
            }
        }
    }
}

