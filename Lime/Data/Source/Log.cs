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
        [MapField("LogOperation")]
        public string LodOperation { get; set; }

        [NotNull]
        [MapField("LogPerson")]
        public string PersonName { get; set; }

        [NotNull]
        [MapField("LogLang")]
        public string Language { get; set; }

        [NotNull]
        [MapField("LogTime")]
        public DateTime Time { get; set; }
    }
}