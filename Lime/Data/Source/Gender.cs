using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLToolkit.DataAccess;
 

using BLToolkit.Data;
using BLToolkit.Mapping;
using BLToolkit.Reflection;

namespace Lime.Data.Source
{
    [TableName("Genders")]
    public class Gender
    {
        //private int _id;
        //public Gender()
        //{
            
        //}

        //public Gender(int id)
        //{
        //    using (var db = new LimeDataBase())
        //    {
        //        db.GetGenderById(id);
        //    }
        //}

        [PrimaryKey, Identity]
        [MapField("GenderId")]
        public int Id { get; set; }

        [NotNull]
        [MapField("GenderName")]
        public string Name { get; set; }
    }
}