using System;
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
                    Console.WriteLine("{0} {1}", gender.GenderId, gender.GenderName);
                }
            }
        }
        

    }
}

