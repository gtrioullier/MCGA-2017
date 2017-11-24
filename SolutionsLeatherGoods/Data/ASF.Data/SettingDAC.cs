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
    public class SettingDAC : DataAccessComponent
    {
        private static Setting loadSetting(IDataReader dr)
        {
            var setting = new Setting()
            {
                Id = GetDataValue<int>(dr, "Id"),
                Name = GetDataValue<string>(dr, "Name"),
                Value = GetDataValue<string>(dr, "Value"),
                Description = GetDataValue<string>(dr, "Description"),
                LastChangeDate = GetDataValue<DateTime>(dr, "LastChangeDate"),
                WebSiteName = GetDataValue<string>(dr, "WebSiteName"),
                WebSiteUrl = GetDataValue<string>(dr, "WebSiteUrl"),
                PageTitle = GetDataValue<string>(dr, "PageTitle"),
                AdminEmailAddress = GetDataValue<string>(dr, "AdminEmailAddress"),
                SMTP = GetDataValue<string>(dr, "SMTP"),
                SMTPUsername = GetDataValue<string>(dr, "SMTPUsername"),
                SMTPPassword = GetDataValue<string>(dr, "SMTPPassword"),
                SMTPPort = GetDataValue<string>(dr, "SMTPPort"),
                SMTPEnableSSL = GetDataValue<bool>(dr, "SMTPEnableSSL"),
                Theme = GetDataValue<string>(dr, "Theme"),
                DefaultLanguageId = GetDataValue<int>(dr, "DefaultLanguageId")
            };

            return setting;
        }

        public List<Setting> Select()
        {
            const string sqlStatement = "SELECT [Id], [Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId] FROM dbo.Setting";

            var result = new List<Setting>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var setting = loadSetting(dr); // Mapper
                        result.Add(setting);
                    }
                }
            }
            return result;
        }

        public Setting SelectById(int id)
        {
            const string sqlStatement = "SELECT [Id], [Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId] " +
                "FROM dbo.Setting WHERE [Id]=@Id";

            Setting setting = null;

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "Id", DbType.Int32, id);
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        if (dr.Read()) setting = loadSetting(dr);
                    }
                }
            }

            return setting;
        }

        public Setting Create(Setting setting)
        {
            const string sqlStatement = "INSERT INTO dbo.Setting ([Name], [Value], [Description], [LastChangeDate], [WebSiteName], [WebSiteUrl], [PageTitle], [AdminEmailAddress], [SMTP], [SMTPUsername], [SMTPPassword], [SMTPPort], [SMTPEnableSSL], [Theme], [DefaultLanguageId]) " +
                "VALUES(@Name, @Value, @Description, @LastChangeDate, @WebSiteName, @WebSiteUrl, @PageTitle, @AdminEmailAddress, @SMTP, @SMTPUsername, @SMTPPassword, @SMTPPort, @SMTPEnableSSL, @Theme, @DefaultLanguageId)";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, setting.Name);
                db.AddInParameter(cmd, "@Value", DbType.String, setting.Value);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime, setting.LastChangeDate);
                db.AddInParameter(cmd, "@WebSiteName", DbType.String, setting.WebSiteName);
                db.AddInParameter(cmd, "@WebSiteUrl", DbType.String, setting.WebSiteUrl);
                db.AddInParameter(cmd, "@PageTitle", DbType.String, setting.PageTitle);
                db.AddInParameter(cmd, "@AdminEmailAddress", DbType.String, setting.AdminEmailAddress);
                db.AddInParameter(cmd, "@SMTP", DbType.String, setting.SMTP);
                db.AddInParameter(cmd, "@SMTPUsername", DbType.String, setting.SMTPUsername);
                db.AddInParameter(cmd, "@SMTPPassword", DbType.String, setting.SMTPPassword);
                db.AddInParameter(cmd, "@SMTPPort", DbType.String, setting.SMTPPort);
                db.AddInParameter(cmd, "@SMTPEnableSSL", DbType.Boolean, setting.SMTPEnableSSL);
                db.AddInParameter(cmd, "@Theme", DbType.String, setting.Theme);
                db.AddInParameter(cmd, "@DefaultLanguageId", DbType.Int32, setting.DefaultLanguageId);
                // Obtener el valor de la primary key.
                setting.Id = Convert.ToInt32(db.ExecuteScalar(cmd));
            }
            return setting;
        }

        public void DeleteById(int id)
        {
            const string sqlStatement = "DELETE dbo.Setting WHERE [Id]=@Id ";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Id", DbType.Int32, id);
                db.ExecuteNonQuery(cmd);
            }
        }

        public void UpdateById(Setting setting)
        {
            const string sqlStatement = "UPDATE dbo.Setting" +
                "SET [Name]=@Name, " +
                    "[Value]=@Value, " +
                    "[Description]=@Description, " +
                    "[LastChangeDate]=@LastChangeDate, " +
                    "[WebSiteName]=@WebSiteName, " +
                    "[WebSiteUrl]=@WebSiteUrl, " +
                    "[PageTitle]=@PageTitle, " +
                    "[AdminEmailAddress]=@AdminEmailAddress, " +
                    "[SMTP]=@SMTP, " +
                    "[SMTPUsername]=@SMTPUsername, " +
                    "[SMTPPassword]=@SMTPPassword, " +
                    "[SMTPPort]=@SMTPPort, " +
                    "[SMTPEnableSSL]=@SMTPEnableSSL, " +
                    "[Theme]=@Theme, " +
                    "[DefaultLanguageId]=@DefaultLanguageId " +
                "WHERE [Id]=@Id";
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@Name", DbType.String, setting.Name);
                db.AddInParameter(cmd, "@Value", DbType.String, setting.Value);
                db.AddInParameter(cmd, "@Description", DbType.String, setting.Description);
                db.AddInParameter(cmd, "@LastChangeDate", DbType.DateTime, setting.LastChangeDate);
                db.AddInParameter(cmd, "@WebSiteName", DbType.String, setting.WebSiteName);
                db.AddInParameter(cmd, "@WebSiteUrl", DbType.String, setting.WebSiteUrl);
                db.AddInParameter(cmd, "@PageTitle", DbType.String, setting.PageTitle);
                db.AddInParameter(cmd, "@AdminEmailAddress", DbType.String, setting.AdminEmailAddress);
                db.AddInParameter(cmd, "@SMTP", DbType.String, setting.SMTP);
                db.AddInParameter(cmd, "@SMTPUsername", DbType.String, setting.SMTPUsername);
                db.AddInParameter(cmd, "@SMTPPassword", DbType.String, setting.SMTPPassword);
                db.AddInParameter(cmd, "@SMTPPort", DbType.String, setting.SMTPPort);
                db.AddInParameter(cmd, "@SMTPEnableSSL", DbType.Boolean, setting.SMTPEnableSSL);
                db.AddInParameter(cmd, "@Theme", DbType.String, setting.Theme);
                db.AddInParameter(cmd, "@DefaultLanguageId", DbType.Int32, setting.DefaultLanguageId);

                db.ExecuteNonQuery(cmd);
            }
        }
    }
}
