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
        [MapField("ParamValueId")]
        public int Id;

        [MapField("ParamId")]
        public int ParamterId;

        [Association(ThisKey = "ParamterId", OtherKey = "Id", CanBeNull = false)] 
        public Parameter Parameter;

        [MapField("ParamValueText")]
        public string Value;
    }
}