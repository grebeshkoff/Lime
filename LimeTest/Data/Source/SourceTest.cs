﻿using System;
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
                                    Code = person.Code,
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
                var query = from param in db.Parameters
                            select new
                                {
                                    Person = param.Person
                                };

                foreach (var param in query)
                {
                    Console.WriteLine("{0}", param.Person.FullName);
                }
            }
        }

        [Test]
        public void LookupValueTest()
        {
            using (var db = new LimeDataBase())
            {
                var query = from val in db.LookupValues
                            select new
                                {
                                    Id = val.Id,
                                    Value = val.Value,
                                    Person = val.Parameter.Person
                                };
                foreach (var val in query)
                {
                    Console.WriteLine("{0} {1}", val.Person.FullName, val.Value);
                }
            }
        }
    }
}

