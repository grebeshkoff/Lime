using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Lime.Data.Source
{
    [TableName("Users")]
    public class Log
    {
        [PrimaryKey, Identity]
        [MapField("LogId")]
        public int Id { get; set; }

        [NotNull]
        [MapField("LogUser")]
        public string User { get; set; }

        [NotNull]
        [MapField("LogIPAddress")]
        public string IpAddress { get; set; }

        [NotNull]
        [MapField("LodOperation")]
        public string LodOperation { get; set; }

        [NotNull]
        [MapField("LodPerson")]
        public string PersonName { get; set; }
    }
}