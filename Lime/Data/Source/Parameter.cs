using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;


namespace Lime.Data.Source
{
    public enum ParameterType
    {
        [MapValue(0)] Text,
        [MapValue(1)] Lookup
    }

    [TableName("Params")]
    public class Parameter
    {
        [PrimaryKey, Identity]
        [MapField("ParamId")] 
        public int Id;

        [NotNull]
        [MapField("ParamName")]
        public string Name;

        [NotNull] 
        [MapField("ParamType")] 
        public ParameterType Type;

        [NotNull]
        [MapField("ParamPersonId")] 
        public int PersonId;

        [MapValue("ParamValue")] 
        [Nullable]
        public string Value;

        [Association(ThisKey = "PersonId", OtherKey = "Id")] 
        public Person Person;
    }
}
