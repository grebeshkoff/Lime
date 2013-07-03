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
    public class LimeDataBase: DbManager
    {
        //Todo For debug
        //private const string WorkConnectionString = @"Data Source=CO-PRG-05\SHAREPOINT;Initial Catalog=LIMEBASE;Integrated Security=True";
        //private const string HomeConnectionString = @"Server=MAIN-PC\MAINPCSQL;Database=LIMEBASE;Integrated Security=SSPI";


        public LimeDataBase()
            : base(new SqlConnection(ConfigurationManager.ConnectionStrings["LimeWork"].ConnectionString))
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
                using (var db = new LimeDataBase())
                {
                    return GetTable<LookupValue>();
                }
            }
        }

        public Table<User> Users
        {
            get
            {
                using (var db = new LimeDataBase())
                {
                    return GetTable<User>();
                }
            }
        }

        public Table<Log> Logs
        {
            get
            {
                using (var db = new LimeDataBase())
                {
                    return GetTable<Log>();
                }
            }
        }



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

#region * Parameters Methods *

        public List<Parameter> GetParameterListByPerson(Person person)
        {
            return (from param in Parameters
                   where param.PersonId == person.Id
                   select param).ToList();
        }

        public int AddNewParameter(Parameter parameter)
        {
            return SetCommand(@"
                        INSERT INTO Params
                            ( ParamName,  ParamType,  ParamPersonId, ParamValue)
                        VALUES
                            (  @ParamName,  @ParamType,  @ParamPersonId, @ParamValue)
                        SELECT Cast(SCOPE_IDENTITY() as int)",
                        CreateParameters(parameter))
                    .ExecuteScalar<int>();
        }


        public void UpdatesExistParameter(Parameter parameter)
        {
            SetCommand(@"
                        UPDATE
                            Params
                        SET
                            ParamName = @ParamName,
                            ParamType = @ParamType,
                            ParamPersonId = @ParamPersonId,
                            ParamValue = @ParamValue
                        WHERE
                            ParamId = @ParamId",
            CreateParameters(parameter)).ExecuteNonQuery();
        }


        public int UpdateParameterValue(int paramId, string paramValue)
        {
            var param = new Parameter
                {
                    Id = paramId,
                    Value = paramValue
                };
            return SetCommand(@"
                        UPDATE
                            Params
                        SET
                            ParamValue = @ParamValue
                        WHERE
                            ParamId = @ParamId",
            CreateParameters(param)).ExecuteNonQuery();
        }

#endregion

#region * LookupValue Methods *

        public void DeleteLookupValue(int id)
        {
            SetCommand("DELETE FROM ParamValues WHERE ParamValueId = @id",
                        Parameter("@id", id))
                    .ExecuteNonQuery();
        }

        public int AddLookupValue(int paramId, string lockupValue)
        {
            var lookup = new LookupValue()
                {
                    ParamterId = paramId,
                    Value = lockupValue
                };
            return SetCommand(@"
                        INSERT INTO ParamValues
                            ( ParamId,  ParamValueText)
                        VALUES
                            ( @ParamId,  @ParamValueText)
                        SELECT Cast(SCOPE_IDENTITY() as int)",
                    CreateParameters(lookup)).ExecuteScalar<int>();
        }

#endregion

#region * Log Methods *

        public int AddLog(Log record)
        {
            return SetCommand(@"
                        INSERT INTO Logs
                            ( LogUser,  LogIPAddress,  LogOperation, LogPerson, LogLang, LogTime)
                        VALUES
                            ( @LogUser, @LogIPAddress, @LogOperation, @LogPerson, @LogLang, @LogTime)
                        SELECT Cast(SCOPE_IDENTITY() as int)",
                        CreateParameters(record))
                    .ExecuteScalar<int>();
        }

        #endregion
    }
}