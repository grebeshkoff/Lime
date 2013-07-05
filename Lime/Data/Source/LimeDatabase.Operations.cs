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

    public partial class LimeDataBase : DbManager
    {

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

        public List<Parameter> GetParametersByPerson(Person person)
        {
            return (from param in Parameters
                    where param.PersonId == person.Id
                    select param).ToList();
        }

        public int  AddParameter(Parameter parameter)
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

        public void UpdateParameter(Parameter parameter)
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

        public int  UpdateParameterValue(int paramId, string paramValue)
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

        public void DeleteParameter(int id)
        {
            BeginTransaction();
                DeleteLookupValuesSet(id);
                SetCommand("DELETE FROM Params WHERE ParamId = @id",
                            Parameter("@id", id))
                        .ExecuteNonQuery();
            CommitTransaction();
        }

        public void DeleteParameter(Parameter param)
        {
            DeleteParameter(param.Id);
        }

        #endregion

#region * LookupValue Methods *
        public int  AddLookupValue(LookupValue value)
        {
            return SetCommand(@"
                        INSERT INTO ParamValues
                            ( ParamId,  ParamValueText)
                        VALUES
                            ( @ParamId,  @ParamValueText)
                        SELECT Cast(SCOPE_IDENTITY() as int)",
                    CreateParameters(value)).ExecuteScalar<int>();
        }
        public void DeleteLookupValue(int id)
        {
            SetCommand("DELETE FROM ParamValues WHERE ParamValueId = @id",
                        Parameter("@id", id))
                    .ExecuteNonQuery();
        }
        public void DeleteLookupValue(LookupValue valie)
        {
            DeleteLookupValue(valie.Id);
        }
        public void DeleteLookupValuesSet(int paramId)
        {
            SetCommand("DELETE FROM ParamValues WHERE ParamId = @ParamId",
                        Parameter("@ParamId", paramId))
                    .ExecuteNonQuery();
        }
        public void DeleteLookupValuesSet(Parameter param)
        {
            DeleteLookupValuesSet(param.Id);
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