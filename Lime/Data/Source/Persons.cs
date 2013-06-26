using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Lime.Data.Source;

namespace Lime.Data.Source
{
    public class Persons
    {
        public List<Person> _list;

        public List<Person> GetPersons()
        {
            using (var db = new LimeDataBase())
            {
                return db.Persons.ToList();
            }

        }

        public void UpdatePerson(Person person)
        {

        }
        public void InsertPerson(Person person)
        {
            
        }

        public void DeletePerson(Person person)
        {
            
        }

    }
}