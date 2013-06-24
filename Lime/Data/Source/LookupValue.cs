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
        public int Id;

        [NotNull]
        [MapField("ParamId")]
        public int ParamterId;

        [NotNull]
        [MapField("ParamValueText")]
        public string Value;

        [Association(ThisKey = "ParamterId", OtherKey = "Id", CanBeNull = false)] 
        public Parameter Parameter;


    }
}