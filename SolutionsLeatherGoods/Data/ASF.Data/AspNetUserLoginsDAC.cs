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
    public class AspNetUserLoginsDAC : DataAccessComponent
    {
        private static AspNetUserLogins LoadAspNetUserLogins(IDataReader dr)
        {
            var aspnetuserlogins = new AspNetUserLogins
            {
                UserId = GetDataValue<string>(dr, "UserId"),
                ProviderKey = GetDataValue<string>(dr, "ProviderKey"),
                LoginProvider = GetDataValue<string>(dr, "LoginProvider")
            };
            return aspnetuserlogins;
        }

        public List<AspNetUserLogins> Select()
        {
            const string sqlStatement = "SELECT [UserId], [ProviderKey], [LoginProvider] FROM dbo.AspNetUserLogins";

            var result = new List<AspNetUserLogins>();
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                using (var dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())
                    {
                        var aspnetuserclaims = LoadAspNetUserLogins(dr);
                        result.Add(aspnetuserclaims);
                    }
                }
            }

            return result;
        }

        public AspNetUserLogins SelectById(string UserId, string ProviderKey, string LoginProvider)
        {
            const string sqlStatement = "SELECT [UserId], [ProviderKey], [LoginProvider] FROM dbo.AspNetUserLogins" +
                "WHERE [UserId]=@UserId, [ProviderKey]=@ProviderKey, [LoginProvider]=@LoginProvider";

            AspNetUserLogins aspnetuserlogins = null;
            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@ProviderKey", DbType.String, "ProviderKey");
                db.AddInParameter(cmd, "@LoginProvider", DbType.String, "LoginProvider");
                using (var dr = db.ExecuteReader(cmd))
                {
                    if (dr.Read()) aspnetuserlogins = LoadAspNetUserLogins(dr);
                }
            }
            return aspnetuserlogins;
        }

        public AspNetUserLogins Create(AspNetUserLogins aspnetuserlogins)
        {
            const string sqlStatement = "INSERT INTO dbo.AspNetUserLogins ([UserId], [ProviderKey], [LoginProvider])" +
                "VALUES(@UserId,@ProviderKey,@LoginProvider)";

            var db = DatabaseFactory.CreateDatabase(ConnectionName);
            using (var cmd = db.GetSqlStringCommand(sqlStatement))
            {
                db.AddInParameter(cmd, "@UserId", DbType.String, "UserId");
                db.AddInParameter(cmd, "@ProviderKey", DbType.String, "ProviderKey");
                db.AddInParameter(cmd, "@LoginProvider", DbType.String, "LoginProvider");

                aspnetuserlogins.UserId = db.ExecuteScalar(cmd).ToString();
                aspnetuserlogins.LoginProvider = db.ExecuteScalar(cmd).ToString();
                aspnetuserlogins.ProviderKey = db.ExecuteScalar(cmd).ToString();
            }
            return aspnetuserlogins;
        }

        public void DeleteById() { }

        public void UpdateById() { }
    }
}
