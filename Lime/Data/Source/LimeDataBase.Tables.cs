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
        //private const string HomeConnectionString = @"Server=MAIN-PC\MAINPCSQL;Database=LIMEBASE;Integrated Security=SSPI";


#region * Tables *
        public LimeDataBase()
            : base(new SqlConnection(WorkConnectionString))
        {
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

#region * Gender Methods *
        public Gender GetGenderById(int id)
        {
            return (from g in Genders
                   where g.Id == id
                   select g).First();
        }
#endregion

#region * Persons Methods *

        public Person GetPersonById(int id)
        {
            return (from p in Persons
                    where p.Id == id
                    select p).First();
        }

        public Person GetPersonByCode(string code)
        {
            return (from p in Persons
                    where p.Code == code
                    select p).First();
        }

        public int AddPerson(Person person)
        {
            return SetCommand(@"
                        INSERT INTO Persons
                            ( PersonCode,  PersonFullName,  PersonGender)
                        VALUES
                            ( @PersonCode,  @PersonFullName,  @PersonGender)
                        SELECT Cast(SCOPE_IDENTITY() as int)",
                        CreateParameters(person))
                    .ExecuteScalar<int>();
        }

        public int UpdatePerson(Person person)
        {
            return SetCommand(@"
                        UPDATE
                            Persons
                        SET
                            PersonCode   = @PersonCode,
                            PersonFullName  = @PersonFullName,
                            PersonGender = @PersonGender
                        WHERE
                            PersonId = @PersonId",
            CreateParameters(person)).ExecuteNonQuery();
        }

        public void DeletePerson(int id)
        {

            var q = (from p in Parameters
                               where p.PersonId == id && p.Type == ParameterType.Lookup
                               select p);
            var peson = GetPersonById(id);

            SetCommand("DELETE FROM Persons WHERE PersonId = @id",
                Parameter("@id", id))
                    .ExecuteNonQuery();

            
            if (q.Any())
            {
                var lookupParam = q.First();

                SetCommand("DELETE FROM ParamValues WHERE ParamId = @id",
                           Parameter("@id", lookupParam.Id)).ExecuteNonQuery(); 
            }

            SetCommand("DELETE FROM Params WHERE ParamPersonId = @id",
               Parameter("@id", id)).ExecuteNonQuery();
        }

        public void DeletePerson(Person person)
        {
            DeletePerson(person.Id);
        }
#endregion






    }
}