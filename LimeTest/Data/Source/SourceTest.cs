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
                            select new Person()
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
        public void ParameterPersonTest()
        {
            using (var db = new LimeDataBase())
            {
                var q = from p in db.Parameters
                        select new 
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Value = p.Value,
                                Type = p.Type,
                                PersonId = p.PersonId,
                                Person = p.Person
                            };

                foreach (var param in q)
                {
                    Console.WriteLine("{0} : {1} : {2}",param.Person.FullName, param.Name, param.Value);
                }
            }
        }

        [Test]
        public void PersonParametersTest()
        {
            using (var db = new LimeDataBase())
            {
               
            }
        }

        [Test]
        public void ParameterTest()
        {
            using (var db = new LimeDataBase())
            {
                foreach (var param in db.Parameters)
                {
                    Console.WriteLine("{0} : {1}", param.Name, param.Value);
                }
            }
        }

        [Test]
        public void LookupValueTest()
        {
            using (var db = new LimeDataBase())
            {
                var q = from lv in db.LookupValues
                        join p in db.Parameters on lv.ParamterId equals p.Id
                        join pr in db.Persons on p.PersonId equals pr.Id
                        select new
                            {
                                Id = lv.Id,
                                ParamterId = p.Id,
                                Parameter = p,
                                Value = lv.Value,
                                Person = pr
                            };
                
  

                foreach (var val in q)
                {
                    Console.WriteLine("{0} : {1} : {2}", val.Person.FullName, val.Parameter.Name, val.Value);
                }
            }
        }

        [Test]
        public void TextParameterTest()
        {
            using (var db = new LimeDataBase())
            {
                var q = (from p in db.Parameters
                            where p.PersonId == 6
                            select p);
                foreach (var param in q)
                {
                    Console.WriteLine("{0} : {1}", param.Name, param.Value);
                }
            }
        }

        [Test]
        public void UsersTest()
        {
            using(var db = new LimeDataBase())
            {
                var query = db.Users;

                foreach (var user in query)
                {
                    Console.WriteLine("{0}: {1}", user.Name, user.Password);
                }
            }
        }

        [Test]
        public void PersonInsertTest()
        {
            using (var db = new LimeDataBase())
            {
                var p = new Person()
                    {
                        FullName = "Мария Кюри",
                        Code = "354789658965",
                        GenderId = 2
                    };

                Console.WriteLine(@"Last Identity : {0}", db.AddPerson(p));
                PersonTest();
            }
        }

        [Test]
        public void PersonUpdateTest()
        {
            using (var db = new LimeDataBase())
            {
                var p = db.Persons.ElementAt(2);
                p.FullName = "Губка Боб Квадратные Штаны";
                p.GenderId = 1;
                Console.WriteLine(@"Last Identity : {0}", db.UpdatePerson(p));
            }
            PersonTest();
        }

        [Test]
        public void PersonDeleteTest()
        {
            using (var db = new LimeDataBase())
            {
                var p = db.Persons.ElementAt(4);
                db.DeletePerson(p);
            }
            PersonTest();
        }

        [Test]
        public void LogInsertTest()
        {
            using (var db=new LimeDataBase())
            {
                var rec = new Log
                    {
                        IpAddress = "192.168.171.127",
                        LodOperation = "Add",
                        PersonName = "bacd",
                        User = "scott",
                        Language = "sdgfsf",
                        Time = DateTime.Now

                    };
                db.AddLog(rec);
            }

        }

    }
}

