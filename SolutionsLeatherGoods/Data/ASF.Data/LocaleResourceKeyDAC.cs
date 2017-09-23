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
    public class LocaleResourceKeyDAC : DataAccessComponent
    {
        private static LocaleResourceKey LoadLocaleResourceKey(IDataReader dr)
        {
            var localeresourcekey = new LocaleResourceKey
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                Notes = GetDataValue<string>(dr, "Notes"),
                DateAdded = GetDataValue<DateTime>(dr, "DateAdded")
            };
            return localeresourcekey;
        }

        public List<LocaleResourceKey> Select()
        {
            const string sqlStatement = "SELECT [Id], [Name], [Notes], [DateAdded] FROM dbo.LocaleResourceKey";

            var result = new List<LocaleResourceKey>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var localeresourcekey = LoadLocaleResourceKey(dr); //Mapper
                        result.Add(localeresourcekey);
                    }
                }
            }
            return result;
        }

        public LocaleResourceKey SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [Notes], [DateAdded] FROM dbo.LocaleResourceKey" + 
                "WHERE [Id]=@Id";

            LocaleResourceKey localeresourcekey = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) localeresourcekey = LoadLocaleResourceKey(dr);
                }
            }
            return localeresourcekey;
        }

        public LocaleResourceKey Create(LocaleResourceKey localeresourcekey)
        {
            const string sqlStatement = "INSERT INTO dbo.LocaleResourceKey ([Name], [Notes], [DateAdded])" +
                "VALUES(@Name, @Notes, @DateAdded)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, localeresourcekey.Name);
                db.AddInParameter(cmd, "@Notes", DbType.String, localeresourcekey.Notes);
                db.AddInParameter(cmd, "@DateAdded", DbType.DateTime, localeresourcekey.DateAdded);
                //Obtener el valor de la primary key.
                localeresourcekey.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return localeresourcekey;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE FROM dbo.LocaleResourceKey WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(LocaleResourceKey localeresourcekey)
        {
            const string sqlStatement = "UPDATE dbo.LocaleResourceKey" +
                "SET [Name]=@Name, " +
                    "[Notes]=@Notes, " +
                    "[DateAdded]=@DateAdded, " +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, localeresourcekey.Name);
                db.AddInParameter(cmd, "@Notes", DbType.String, localeresourcekey.Notes);
                db.AddInParameter(cmd, "@DateAdded", DbType.DateTime, localeresourcekey.DateAdded);

                db.ExecuteNonQuery(cmd);
            }
        }

        public int getId(string key)
        {
            const string sqlStatement = "SELECT [Id] FROM dbo.LocaleResourceKey" + 
                "WHERE [Name]=@key";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, key);

                return Convert.ToInt32(db.ExecuteScalar(cmd));
            }
        }
    }
}
