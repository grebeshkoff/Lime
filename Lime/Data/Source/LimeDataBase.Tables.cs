using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using BLToolkit.Data;
using BLToolkit.Data.DataProvider;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;
using Telerik.Web.UI;


namespace Lime.Data.Source
{
    public partial class LimeDataBase: DbManager
    {
        //Todo For debug
        private const string WorkConnectionString = @"Data Source=CO-PRG-05\SHAREPOINT;Initial Catalog=LIMEBASE;Integrated Security=True";
        private const string HomeConnectionString = @"Server=MAIN-PC\MAINPCSQL;Database=LIMEBASE;Integrated Security=SSPI";

        private readonly HttpContext _context;
#region * Tables *
        public LimeDataBase()
            : base(new SqlConnection(WorkConnectionString))
        {

        }

        public LimeDataBase(HttpContext ctx)
            : base(new SqlConnection(WorkConnectionString))
        {
            _context = ctx;
        }

        public Table<Gender> Genders
        {
            get
            {
                return GetTable<Gender>();
            }
        }

        public Table<Person> Persons
        {
            get
            {
                return GetTable<Person>();
            }
        }

        public Table<Parameter> Parameters
        {
            get
            {
                return GetTable<Parameter>();
            }
        }

        public Table<LookupValue> LookupValues
        {
            get
            {
                return GetTable<LookupValue>();
            }
        }

        public Table<User> Users
        {
            get
            {
                return GetTable<User>();
            }
        }

        public Table<Log> Logs
        {
            get
            {
                return GetTable<Log>();
            }
        }
#endregion





    }
}