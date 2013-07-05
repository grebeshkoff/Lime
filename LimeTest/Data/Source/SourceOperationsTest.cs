using System;
using System.Linq;
using Lime;
using Lime.Data.Source;
using NUnit.Framework;

namespace LimeTest.Data.Source
{
    [TestFixture]
    internal partial class SourceOperationTest
    {
        [Test]
        public void DeleteParameterTest ()
        {
            using (var db = new LimeDataBase())
            {
                db.DeleteParameter(12);
            }
        }

        [Test]
        public void AddParameterTest()
        {

        }
    }
}
