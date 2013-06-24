using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Lime.Data.Source
{
    public class LimeDataBase: DbManager 
    {
        private const string ConnectionString = @"Server=MAIN-PC\MAINPCSQL;Database=LIMEBASE;Integrated Security=SSPI";

        public LimeDataBase()
            : base(new SqlConnection(ConnectionString))
        {
        }

        public Table<Gender> Genders
        {
            get
            {
                using (var db = new LimeDataBase())
                {
                    return GetTable<Gender>(); ;
                }
            }
        }

        public Table<Person> Persons
        {
            get
            {
                using (var db = new LimeDataBase())
                {
                    return GetTable<Person>(); 
                }
            }
        }

        public Table<Parameter> Parameters
        {
            get
            {
                using (var db = new LimeDataBase())
                {
                    return GetTable<Parameter>();
                }
            }
        }

        public Table<LookupValue> LookupValues
        {
            get
            {
                using (var db = new LimeDataBase())
                {
                    return GetTable<LookupValue>();
                }
            }
        }


    }
}