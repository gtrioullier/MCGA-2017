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
    public class LocaleStringResourceDAC : DataAccessComponent
    {
        private static LocaleStringResource LoadLocaleStringResource(IDataReader dr)
        {
            var localestringresource = new LocaleStringResource
            {
                Id = GetDataValue<int>(dr, "Id"),
                ResourceValue = GetDataValue<string>(dr, "ResourceValue"),
                LocaleResourceKey_Id = GetDataValue<int>(dr, "LocaleResourceKey_Id"),
                Language_Id = GetDataValue<int>(dr, "Language_Id")
            };

            return localestringresource;
        }

        public List<LocaleStringResource> Select()
        {
            const string sqlStatement = "SELECT [Id], [ResourceValue], [LocaleResourceKey_Id], [Language_Id] FROM dbo.LocaleStringResource";

            var result = new List<LocaleStringResource>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var localstringresource = LoadLocaleStringResource(dr); //Mapper
                        result.Add(localstringresource);
                    }
                }
            }
            return result;
        }

        public LocaleStringResource SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [ResourceValue], [LocaleResourceKey_Id], [Language_Id]" +
                "FROM dbo.LocaleStringResource WHERE [Id]=@Id";

            LocaleStringResource localestringresource = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) localestringresource = LoadLocaleStringResource(dr);
                }
            }
            return localestringresource;
        }

        public LocaleStringResource Create(LocaleStringResource localestringresource)
        {
            const string sqlStatement = "INSERT INTO dbo.LocaleStringResource ([ResourceValue], [LocaleResourceKey_Id], [Language_Id])" +
                "VALUES (@ResourceValue, @LocaleResourceKey_Id, @Language_Id)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ResourceValue", DbType.String, localestringresource.ResourceValue);
                db.AddInParameter(cmd, "@LocaleResourceKey_Id", DbType.Int32, localestringresource.LocaleResourceKey_Id);
                db.AddInParameter(cmd, "@Language_Id", DbType.Int32, localestringresource.Language_Id);

                //Obtener el valor de la primary key.
                localestringresource.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return localestringresource;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE FROM dbo.LocaleStringResource WHERE [Id[]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(LocaleStringResource localestringresource)
        {
            const string sqlStatement = "UPDATE dbo.LocaleStringResource" +
                "SET [ResourceValue]=@ResourceValue, " +
                    "[LocaleResourceKey_Id]=@LocaleResourceKey_Id, " +
                    "[Language_Id]=@Language_Id, " +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@ResourceValue", DbType.String, localestringresource.ResourceValue);
                db.AddInParameter(cmd, "@LocaleResourceKey_Id", DbType.Int32, localestringresource.LocaleResourceKey_Id);
                db.AddInParameter(cmd, "@Language_Id", DbType.Int32, localestringresource.Language_Id);

                db.ExecuteNonQuery(cmd);
            }
        }

    }
}
