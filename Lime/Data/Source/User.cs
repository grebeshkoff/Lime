using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Lime.Data.Source
{
    [TableName("Users")]
    public class User
    {
        [PrimaryKey, Identity]
        [MapField("UserId")]
        public int Id { get; set; }

        [NotNull]
        [MapField("UserName")]
        public string Name { get; set; }

        [NotNull]
        [MapField("UserPassword")]
        public string Password { get; set; }
    }
}