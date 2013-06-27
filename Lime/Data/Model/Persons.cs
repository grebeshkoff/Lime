using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lime.Data.Source;

namespace Lime.Data.Model
{
    public class Persons
    {
        private LimeDataBase db = new LimeDataBase();


        private List<Person> _list = new LimeDataBase().Persons.ToList();

        public List<Person> GetPersons()
        {
            return _list;
        }

        public Person GetPersonById(int id)
        {
            return (from p in _list
                    where p.Id == id
                    select p).First();
        }


        public List<Person> GetPersonByFullName(string namePart)
        {
            return (from p in _list
                    where p.FullName.Contains(namePart)
                    select p).ToList();
        }
        public List<Person> GetPersonByCode(string namePart)
        {
            return (from p in _list
                    where p.Code.Contains(namePart)
                    select p).ToList();
        }
    }
}