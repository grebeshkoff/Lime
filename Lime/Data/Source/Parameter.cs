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
        [MapValue(0)] Text = 0,
        [MapValue(1)] Lookup = 1
    }

    [TableName("Params")]
    //[InheritanceMapping(Code = ParameterType.Text, Type = typeof(TextParameter))]
    //[InheritanceMapping(Code = ParameterType.Lookup, Type=typeof(LookupParameter))]
    public abstract class Parameter
    {
        [PrimaryKey, Identity]
        [MapField("ParamId")]
        public int Id { get; set; }

        [NotNull]
        [MapField("ParamName")]
        public string Name { get; set; }

        [NotNull]
        [MapField("ParamValue")]
        public string Value { get; set; }

        [NotNull]
        [MapField("ParamType")]
        public ParameterType Type { get; set; }

        [NotNull]
        [MapField("ParamPersonId")]
        public int PersonId { get; set; }

        [Association(ThisKey = "PersonId", OtherKey = "Id")]
        public Person Person;

        
    }

    public class LookupParameter : Parameter
    {
    }

    public class TextParameter :Parameter
    {
    }
}
