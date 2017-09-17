using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ASF.Entities;

namespace ASF.Data
{
    public class ErrorDAC : DataAccessComponent
    {
        private static Error LoadError(IDataReader dr)
        {
            var error = new Error
            {
                Id = GetDataValue<int>(dr, "Id"),
                ClientId = GetDataValue<int>(dr, "ClientId"),
                ErrorDate = GetDataValue<DateTime>(dr, "ErrorDate"),
                IpAddress = GetDataValue<string>(dr, "IpAddress"),
                ClientAgent = GetDataValue<string>(dr, "ClientAgent"),
                Exception = GetDataValue<string>(dr, "Exception"),
                Message = GetDataValue<string>(dr, "Message"),
                Everything = GetDataValue<string>(dr, "Everything"),
                HttpReferer = GetDataValue<string>(dr, "HttpReferer"),
                PathAndQuery = GetDataValue<string>(dr, "PathAndQuery"),
                CreatedOn = GetDataValue<DateTime>(dr, "CreatedOn"),
                CreatedBy = GetDataValue<int>(dr, "CreatedBy"),
                ChangedOn = GetDataValue<DateTime>(dr, "ChangedOn"),
                ChangedBy = GetDataValue<int>(dr, "ChangedBy")
            };

            return error;
        }

        public List<Error> Select()
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ErrorDate], [IpAddress], [ClientAgent], [Exception], [Message], [Everything], [HttpReferer], [PathAndQuery], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy] FROM dbo.Error";

            var result = new List<Error>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var error = LoadError(dr); // Mapper
                        result.Add(error);
                    }
                }
            }

            return result;
        }

        public Error SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ClientId], [ErrorDate], [IpAddress], [ClientAgent], [Exception], [Message], [Everything], [HttpReferer], [PathAndQuery], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy]" +
                "FROM dbo.Error WHERE [Id]=@Id";

            Error error = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr.Read()) error = LoadError(dr);
                    }
                }
            }

            return error;

        }

        public Error Create(Error error)
        {
            const string sqlStatement = "INSERT INTO dbo.Error ([ClientId], [ErrorDate], [IpAddress], [ClientAgent], [Exception], [Message], [Everything], [HttpReferer], [PathAndQuery], [CreatedOn], [CreatedBy], [ChangedOn], [ChangedBy])" +
                "VALUES (@ClientId, @ErrorDate, @IpAddress, @ClientAgent, @Exception, @Message, @Everything, @HttpReferer, @PathAndQuery, @CreatedOn, @CreatedBy, @ChangedOn, @ChangedBy)";

            var db = DatabaseFactory.CreateDatabase(sqlStatement);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, error.ClientId);
                db.AddInParameter(cmd, "@ErrorDate", DbType.DateTime, error.ErrorDate);
                db.AddInParameter(cmd, "@IpAddress", DbType.String, error.IpAddress);
                db.AddInParameter(cmd, "@ClientAgent", DbType.String, error.ClientAgent);
                db.AddInParameter(cmd, "@Exception", DbType.String, error.Exception);
                db.AddInParameter(cmd, "@Message", DbType.String, error.Message);
                db.AddInParameter(cmd, "@Everything", DbType.String, error.Everything);
                db.AddInParameter(cmd, "@HttpReferer", DbType.String, error.HttpReferer);
                db.AddInParameter(cmd, "@PathAndQuery", DbType.String, error.PathAndQuery);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, error.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, error.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, error.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, error.ChangedBy);
                // Obtener el valor de la primary key.
                error.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }

            return error;
        }

        public void Delete(int id)
        {
            const string sqlStatement = "DELETE FROM dbo.Error WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(sqlStatement);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void Edit(Error error)
        {
            const string sqlStatement = "UPDATE db.Error" +
                "SET [ClientId]=@ClientId ," +
                    "[ErrorDate]=@ErrorDate ," +
                    "[IpAddress]=@IpAddress ," +
                    "[ClientAgent]=@ClientAgent ," +
                    "[Exception]=@Exception ," +
                    "[Message]=@Message ," +
                    "[Everything]=@Everything ," +
                    "[HttpReferer]=@HttpReferer ," +
                    "[PathAndQuery]=@PathAndQuery ," +
                    "[CreatedOn]=@CreatedOn ," +
                    "[CreatedBy]=@CreatedBy ," +
                    "[ChangedOn]=@ChangedOn ," +
                    "[ChangedBy]=@ChangedBy ," +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(sqlStatement);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ClientId", DbType.Int32, error.ClientId);
                db.AddInParameter(cmd, "@ErrorDate", DbType.DateTime, error.ErrorDate);
                db.AddInParameter(cmd, "@IpAddress", DbType.String, error.IpAddress);
                db.AddInParameter(cmd, "@ClientAgent", DbType.String, error.ClientAgent);
                db.AddInParameter(cmd, "@Exception", DbType.String, error.Exception);
                db.AddInParameter(cmd, "@Message", DbType.String, error.Message);
                db.AddInParameter(cmd, "@Everything", DbType.String, error.Everything);
                db.AddInParameter(cmd, "@HttpReferer", DbType.String, error.HttpReferer);
                db.AddInParameter(cmd, "@PathAndQuery", DbType.String, error.PathAndQuery);
                db.AddInParameter(cmd, "@CreatedOn", DbType.DateTime2, error.CreatedOn);
                db.AddInParameter(cmd, "@CreatedBy", DbType.Int32, error.CreatedBy);
                db.AddInParameter(cmd, "@ChangedOn", DbType.DateTime2, error.ChangedOn);
                db.AddInParameter(cmd, "@ChangedBy", DbType.Int32, error.ChangedBy);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
