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
    public class LanguageDAC : DataAccessComponent
    {
        private static Language LoadLanguage(IDataReader dr)
        {
            var language = new Language
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                LanguageCulture = GetDataValue<string>(dr, "LanguageCulture"),
                FlagImageFileName = GetDataValue<string>(dr, "FlagImageFileName"),
                RightToLeft = GetDataValue<bool>(dr, "RightToLeft")
            };
            return language;
        }

        public List<Language> Select()
        {
            const string sqlStatement = "SELECT [Id], [Name], [LanguageCulture], [FlagImageFileName], [RightToLeft] FROM dbo.Language";

            var result = new List<Language>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var language = LoadLanguage(dr); // Mapper
                        result.Add(language);
                    }
                }
            }
            return result;
        }

        public Language SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [LanguageCulture], [FlagImageFileName], [RightToLeft]" +
                "FROM dbo.Language WHERE [Id]=@Id";

            Language language = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) language = LoadLanguage(dr);
                }
            }
            return language;
        }

        public Language Create(Language language)
        {
            const string sqlStatement = "INSERT INTO dbo.Language ([Name], [LanguageCulture], [FlagImageFileName], [RightToLeft])" +
                "VALUES (@Name, @LanguageCulture, @FlagImageFileName, @RightToLeft)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, language.Name);
                db.AddInParameter(cmd, "@LanguageCulture", DbType.String, language.LanguageCulture);
                db.AddInParameter(cmd, "@FlagImageFileName", DbType.String, language.FlagImageFileName);
                db.AddInParameter(cmd, "@RightToLeft", DbType.Boolean, language.RightToLeft);

                // Obtener el valor de la primary key.
                language.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return language;   
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Language WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(Language language)
        {
            const string sqlStatement = "UPDATE dbo.Language" +
                "SET [Name]=@Name, " +
                    "[LanguageCulture]=@LanguageCulture," +
                    "[FlagImageFileName]=@FlagImageFileName," +
                    "[RightToLeft]=@,RightToLeft" +
                "WHERE [Id]=@Id";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, language.Name);
                db.AddInParameter(cmd, "@LanguageCulture", DbType.String, language.LanguageCulture);
                db.AddInParameter(cmd, "@FlagImageFileName", DbType.String, language.FlagImageFileName);
                db.AddInParameter(cmd, "@RightToLeft", DbType.Boolean, language.RightToLeft);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
