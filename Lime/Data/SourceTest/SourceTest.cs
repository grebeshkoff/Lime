using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lime.Data.Source;

namespace Lime.Data.SourceTest
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;
    using Lime.Data.Source;



    namespace Lime.Data.Source
    {
        [TestFixture]
        internal class SourceTest
        {
            [Test]
            public void GenderTest()
            {
                using (var con = new SqlConnection(@"Server=MAIN-PC\MAINPCSQL;Database=LIMEBASE;Integrated Security=SSPI"))
                {
                    using (var db = new LimeDataBase(con))
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
    }

}