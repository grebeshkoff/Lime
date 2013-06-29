using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Lime.Data.Source
{
    [TableName("ParamValues")]
    public class LookupValue
    {
        [PrimaryKey, Identity]
        [MapField("ParamValueId")]
        public int Id { get; set; }

        [NotNull]
        [MapField("ParamId")]
        public int ParamterId { get; set; }

        [NotNull]
        [MapField("ParamValueText")]
        public string Value { get; set; }

        [Association(ThisKey = "ParamterId", OtherKey = "Id")]
        public Parameter Parameter { get; set; }


    }
}