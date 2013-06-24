using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
using NUnit.Framework;

using BLToolkit.Data;
using BLToolkit.Mapping;
using BLToolkit.Reflection;

namespace Lime.Data.Source
{
    [TableName("Genders")]
    public class Gender
    {
        [PrimaryKey, Identity]
        public int GenderId;
        [NotNull]
        public string GenderName;
    }
}